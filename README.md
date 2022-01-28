# .NET to Rust bindgen experiments

## Problems

- Consume Rust libraries in C#. Supporting other languages is secondary here, but still a good bonus.
- We want to automate to avoid out-of-sync API issues and support CI checks.
- Keep handwritten boilerplate to a minimum (exposing a Rust library to C# code should be fun)

## Initial approach: cbindgen & ClangSharp

Workflow:

- Write a Rust crate exposing a C API (*manual*)
- Let `cbindgen` generate C headers (*automatic*)
- Let `ClangSharp` generate C# native raw bindings (_not_ idiomatic) (*automatic*)
- Handwrite idiomatic C# wrappers around raw C# API (*manual*)

Advantages:

- Bindings are synced.
- Fine-grained control of the C API and other implementation details.

Drawbacks:

- No stdlib types are supported seamlessly.
- Idiomatic wrapper must be handwritten. It's critical because users should not have to write unsafe code using the raw API (unergonomic and error-prone).
- For simplicity and safety, API copying into buffers allocated in user-code are written.
  - e.g: PEM representation and error messages. An intermediate local buffer is written into, then its contents is copied into another user-provided buffer.
      To work consistently, another function returning required buffer size must be provided.
      When required size can't be known without actually doing the work, work must be done twice.
      In such case, a growable buffer would be better.

[Prototype](./cbindgen_clangsharp)

## Can we do better?

- We want (mostly) automatic idiomatic C# wrapper.
- It's fine to not have the best C API, as our goal is good C# support.

## Alternative: COM API

This section is written assuming [`com-rs`](https://github.com/microsoft/com-rs) crate is used.

Advantages:

- Polymorphic API: with "interfaces", COM can be used to expose polymorphic objects.
- No need to wrap everything: COM objects are "managed" on C# side (memory is allocated and freed when appropriate).

Drawbacks:

- Functions are basically like raw C API, requiring unsafe code when working with non-primitive types.
- No support for enums.
- No stdlib types are supported seamlessly.
- Linux support is not necessarily a priority when it comes to COM ecosystem. Some tricks are required to make it work on both Rust and C# side.
- No tool to sync interfaces in Rust or C#. This can however be written quite easily if we were to choose this approach.
- Opaque types only.
- Future of the crate [`com-rs`](https://github.com/microsoft/com-rs/issues/206) is not clear.
  - `windows-rs` crate will simply never support Linux out of the box.
  - Current `com-rs` state is not bad. Maybe it's not a problem if it's not maintained anymore.
  - We can fork if necessary.

[Prototype](./com) (credits to [awakecoding](https://github.com/awakecoding))

Note: for strings, [`intercom`](https://github.com/Rantanen/intercom) crate has an interesting approach:

- https://github.com/Rantanen/intercom/blob/4333bc1e58cb121809cc2ee8b2d392a66360815c/intercom/src/strings.rs
- https://github.com/Rantanen/intercom-site/blob/0c6356fa7898be1d6d9c9f0fc6e53a3af832c012/content/docs/types/strings.md

## Diplomat

Advantages:

- Support for both opaque and non-opaque types.
- Able to generate managed idiomatic C# wrapper.
- Rust FFI interface can be written in safe Rust only.
- Safer alternative to raw pointers when writing functions (`arg: &str` instead of `arg: *const c_char, arg_sz: c_int`, etc).
- `DiplomatWrite` type implementing `core::fmt::Write` to write strings in a growable buffer using convenient stdlib macros such as `write!`.
- Some stdlib types such as `Result` and `Option` are also supported and used to generate better C# wrappers.
- Cross-platform.

Drawbacks:

- Project is still young (one year of existence as of 2022-01-28)
    - However, one of the maintainers is [ManishEarth](https://github.com/Manishearth) (author of `rust-clippy` among other things).
        `Diplomat` is used in `unicode-org/icu4x` project by Google engineers (including ManishEarth).

Note: I had to implement C# target myself (only C, C++, and JS/NodeJS were supported). I [sent a PR](https://github.com/rust-diplomat/diplomat/pull/124) for that.

[Prototype](./diplomat)

## Interoptopus

Advantages:

- Provides a lot of helpers for *options*, *results*, *slices*, *strings*, *callbacks*, …
- Cross-platform.

Drawbacks:

- No stdlib types are supported seamlessly, generally less elegant and more verbose than `Diplomat` alternative.
- Generated code is not idiomatic: working mostly with raw interface using `IntPtr`. We still need to write the idiomatic managed C# wrapper manually.
- Project is still young (one year of existence as of 2022-01-28)
- It's pretty close to the initial approach, except with more helpers and a single tool instead of two.

Note: apparently, it's easy to create one's own backend. Maybe we can write another backend for generating the idiomatic wrapper as well.
However, even with that, `Diplomat` still wins on Rust side.

[Prototype](./interoptopus)

## Conclusion

`Diplomat` had the approach looking the most compelling to me, and I didn't push other experiments as far as I could have.
I personally think we can get pretty decent results with any of the alternate approaches mentioned above by putting more work to develop them.


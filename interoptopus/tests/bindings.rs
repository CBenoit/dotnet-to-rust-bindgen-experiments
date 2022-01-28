use interoptopus::util::NamespaceMappings;
use interoptopus::Error;
use interoptopus::Interop;

#[test]
#[cfg_attr(miri, ignore)]
fn bindings_csharp() -> Result<(), Error> {
    use interoptopus_backend_csharp::overloads::DotNet;
    use interoptopus_backend_csharp::{Config, Generator};

    let config = Config {
        class: "Interop".to_string(),
        dll_name: "picky_ffi".to_string(),
        namespace_mappings: NamespaceMappings::new("Devolutions.Picky"),
        ..Config::default()
    };

    Generator::new(config, picky_ffi::ffi_pem())
        .add_overload_writer(DotNet::new())
        .write_file("dotnet/Picky.cs")?;

    Ok(())
}

#!/bin/bash
cargo build
mkdir -p dotnet/src/Picky/lib/Debug/linux-x64/
cp target/debug/libpicky.so dotnet/src/Picky/lib/Debug/linux-x64/libpicky.so
cargo run --manifest-path=../../diplomat/tool/Cargo.toml -- csharp dotnet/src/Picky/ -l ./dotnet-interop-conf.toml
cd dotnet && dotnet test

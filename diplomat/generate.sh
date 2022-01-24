#!/bin/bash
set -x

# Build library
cargo build
mkdir -p dotnet/src/Picky/lib/Debug/linux-x64/
cp target/debug/libpicky.so dotnet/src/Picky/lib/Debug/linux-x64/libpicky.so

# Generate dotnet bindings
rm dotnet/src/Picky/Generated/*.cs
diplomat-tool dotnet dotnet/src/Picky/Generated/ -l ./dotnet-interop-conf.toml

# Run dotnet tests
cd dotnet && dotnet test

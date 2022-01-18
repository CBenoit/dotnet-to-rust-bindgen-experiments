#!/bin/bash
set -x

# Build library
cargo build
mkdir -p dotnet/src/Picky/lib/Debug/linux-x64/
cp target/debug/libpicky.so dotnet/src/Picky/lib/Debug/linux-x64/libpicky.so

# Generate dotnet bindings
diplomat-tool dotnet dotnet/src/Picky/ -l ./dotnet-interop-conf.toml

# Run dotnet tests
cd dotnet && dotnet test

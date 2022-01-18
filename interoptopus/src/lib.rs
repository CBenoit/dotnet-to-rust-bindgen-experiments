#[macro_use]
mod helper;

pub mod pem;

interoptopus::inventory!(ffi_pem, [], [pem::picky_pem_parse], [], []);

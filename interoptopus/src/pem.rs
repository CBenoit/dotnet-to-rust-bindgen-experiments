use interoptopus::patterns::result::FFIError;
use interoptopus::patterns::string::AsciiPointer;
use interoptopus::{ffi_function, ffi_type};

#[ffi_type(patterns(ffi_error))]
#[repr(C)]
pub enum PemError {
    Ok = 0,
    NullPassed = 1,
    Panic = 2,
    Other = 3,
}

impl FFIError for PemError {
    const SUCCESS: Self = Self::Ok;
    const NULL: Self = Self::NullPassed;
    const PANIC: Self = Self::Panic;
}

impl From<interoptopus::Error> for PemError {
    fn from(_: interoptopus::Error) -> Self {
        Self::Other
    }
}

impl From<picky::pem::PemError> for PemError {
    fn from(_: picky::pem::PemError) -> Self {
        Self::Other
    }
}

#[ffi_type(opaque)]
#[repr(C)]
pub struct Pem(picky::pem::Pem<'static>);

#[ffi_function]
#[no_mangle]
pub extern "C" fn picky_pem_parse(
    input: AsciiPointer,
    ctx: Option<&mut *mut Pem>,
) -> PemError {
    let input = err_check!(input.as_str());
    let ctx = none_check!(ctx);

    let pem = err_check!(picky::pem::parse_pem(input));
    let pem = Box::new(Pem(pem));
    *ctx = Box::into_raw(pem);

    PemError::Ok
}

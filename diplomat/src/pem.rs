#[diplomat::bridge]
pub mod ffi {
    use crate::error::ffi::PickyError;
    use diplomat_runtime::{DiplomatResult, DiplomatWriteable};
    use std::fmt::Write;

    /// Opaque type for picky PEM object.
    #[diplomat::opaque]
    pub struct PickyPem(picky::pem::Pem<'static>);

    impl PickyPem {
        pub fn load_from_file(path: &str) -> DiplomatResult<Box<PickyPem>, Box<PickyError>> {
            println!("I'm trying to read {}", path);
            let contents = err_check!(std::fs::read_to_string(path));
            Self::parse(&contents)
        }

        /// Parses a PEM-encoded string representation into a PEM object.
        pub fn parse(input: &str) -> DiplomatResult<Box<PickyPem>, Box<PickyError>> {
            let pem = err_check!(picky::pem::parse_pem(input));
            Ok(Box::new(PickyPem(pem))).into()
        }

        /// Creates a PEM object with a copy of the data.
        pub fn create(label: &str, data: &[u8]) -> DiplomatResult<Box<PickyPem>, Box<PickyError>> {
            let data = data.to_owned();
            let pem = picky::pem::Pem::new(label, data);
            Ok(Box::new(PickyPem(pem))).into()
        }

        /// Copy the label associated to the data contained in the PEM object.
        pub fn label(
            &self,
            writeable: &mut DiplomatWriteable,
        ) -> DiplomatResult<(), Box<PickyError>> {
            err_check!(write!(writeable, "{}", self.0.label()));
            writeable.flush();
            Ok(()).into()
        }

        pub fn print_label(
            &self,
        ) {
            println!("{}", self.0.label());
        }
    }
}

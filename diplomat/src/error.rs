#[diplomat::bridge]
pub mod ffi {
    use diplomat_runtime::DiplomatWriteable;
    use std::fmt::Write;

    #[diplomat::opaque]
    #[derive(Debug)]
    pub struct PickyError(pub String);

    impl PickyError {
        pub fn display(&self, writeable: &mut DiplomatWriteable) {
            let _ = write!(writeable, "{}", self.0);
        }

        pub fn print(&self) {
            println!("{}", self.0);
        }
    }
}

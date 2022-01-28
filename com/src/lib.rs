use com::interfaces::IUnknown;

com::interfaces! {
    #[uuid("EFF8970E-C50F-45E0-9284-291CE5A6F771")]
    pub unsafe interface IAnimal: IUnknown {
        fn Eat(&self) -> u32;
    }
}

com::class! {
    pub class Monkey : IAnimal {}

    impl IAnimal for Monkey {
        fn Eat(&self) -> u32 {
            return 57;
        }
    }
}

pub extern "C" fn create_monkey() -> IAnimal {
    let instance = Monkey::allocate();
    let interface_handle = instance.query_interface::<IAnimal>().unwrap();
    interface_handle
}

#[test]
pub fn test() {
    let animal = create_monkey();
    let value = unsafe { animal.Eat() };
    assert_eq!(value, 57);
}

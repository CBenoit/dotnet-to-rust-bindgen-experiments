using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ComInterop.Client
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EFF8970E-C50F-45E0-9284-291CE5A6F771")]
    public interface IAnimal
    {
        [MethodImpl(MethodImplOptions.PreserveSig)]
        UInt32 Eat();
    }

    public static class ComTest
    {
        private static Guid IID_IAnimal =
            new Guid(0xEFF8970E, 0xC50F, 0x45E0, 0x92, 0x84, 0x29, 0x1C, 0xE5, 0xA6, 0xF7, 0x71);

        public static IAnimal CreateMonkey()
        {
            object instance = create_monkey();
            return (IAnimal)instance;
        }

        [DllImport("com_test")]
        [return: MarshalAs(UnmanagedType.IUnknown)] 
        public static extern object create_monkey();
    }

    class Program
    {
        static void TestComClient()
        {
            IAnimal monkey = ComTest.CreateMonkey();
            UInt32 num = monkey.Eat();
            Console.WriteLine("Monkey.Eat: {0}", num);
        }

        static void Main(string[] args)
        {
            TestComClient();
        }
    }
}

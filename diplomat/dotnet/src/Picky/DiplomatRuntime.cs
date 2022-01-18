using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Devolutions.Picky.Diplomat {
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct DiplomatWriteable
    {
        IntPtr context;
        IntPtr buf;
        nuint len;
        nuint cap;
        WriteableFlush flush;
        WriteableGrow grow;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void WriteableFlush(IntPtr self);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate bool WriteableGrow(IntPtr self, nuint capacity);
}


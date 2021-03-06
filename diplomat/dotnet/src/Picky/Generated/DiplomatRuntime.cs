// Automatically generated by Diplomat

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Devolutions.Picky.Diplomat;

#nullable enable

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
delegate void WriteableFlush(IntPtr self);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
[return: MarshalAs(UnmanagedType.U1)]
delegate bool WriteableGrow(IntPtr self, nuint capacity);

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct DiplomatWriteable : IDisposable
{
    readonly IntPtr context;
    IntPtr buf;
    nuint len;
    nuint cap;
    readonly IntPtr flush;
    readonly IntPtr grow;

    public DiplomatWriteable()
    {
        WriteableFlush flushFunc = Flush;
        WriteableGrow growFunc = Grow;

        context = IntPtr.Zero; // We don't need to use context
        buf = Marshal.AllocHGlobal(64);
        len = 0;
        cap = 64;
        flush = Marshal.GetFunctionPointerForDelegate(flushFunc);
        grow = Marshal.GetFunctionPointerForDelegate(growFunc);
    }

    public byte[] ToUtf8Bytes()
    {
        if (len > int.MaxValue)
        {
            throw new IndexOutOfRangeException("DiplomatWriteable buffer is too big");
        }
        byte[] managedArray = new byte[(int)len];
        Marshal.Copy(buf, managedArray, 0, (int)len);
        return managedArray;
    }

    public string ToUnicode()
    {
#if NET6_0_OR_GREATER
        if (len > int.MaxValue)
        {
            throw new IndexOutOfRangeException("DiplomatWriteable buffer is too big");
        }
        return Marshal.PtrToStringUTF8(buf, (int) len);
#else
        byte[] utf8 = ToUtf8Bytes();
        return DiplomatUtils.Utf8ToString(utf8);
#endif
    }

    public void Dispose()
    {
        if (buf != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(buf);
            buf = IntPtr.Zero;
        }
    }

    private static void Flush(IntPtr self)
    {
        // Nothing to do
    }

    [return: MarshalAs(UnmanagedType.U1)]
    private unsafe static bool Grow(IntPtr writeable, nuint capacity)
    {
        if (writeable == IntPtr.Zero)
        {
            return false;
        }
        DiplomatWriteable* self = (DiplomatWriteable*)writeable;

        nuint newCap = capacity;
        if (newCap > int.MaxValue)
        {
            return false;
        }

        IntPtr newBuf;
        try
        {
            newBuf = Marshal.AllocHGlobal((int)newCap);
        }
        catch (OutOfMemoryException)
        {
            return false;
        }

        Buffer.MemoryCopy((void*)self->buf, (void*)newBuf, newCap, self->cap);
        Marshal.FreeHGlobal(self->buf);
        self->buf = newBuf;
        self->cap = newCap;

        return true;
    }
}

internal static class DiplomatUtils
{
    internal static byte[] StringToUtf8(string s)
    {
        int size = Encoding.UTF8.GetByteCount(s);
        byte[] buf = new byte[size];
        Encoding.UTF8.GetBytes(s, 0, s.Length, buf, 0);
        return buf;
    }

    internal static string Utf8ToString(byte[] utf8)
    {
        char[] chars = new char[utf8.Length];
        Encoding.UTF8.GetChars(utf8, 0, utf8.Length, chars, 0);
        return new string(chars);
    }
}

public class DiplomatOpaqueException : Exception
{
    public DiplomatOpaqueException() : base("The FFI function failed with an opaque error") { }
}

public class DiplomatUnmovableObject : Exception
{
    private string _objectName;

    public string ObjectName
    {
        get
        {
            return _objectName;
        }
    }

    public DiplomatUnmovableObject(string objectName, string message) : base($"Can't move this instance of {objectName}: {message}") {
        _objectName = objectName;
    }
}

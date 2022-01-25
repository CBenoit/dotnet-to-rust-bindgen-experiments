// Automatically generated by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky.Raw;

#nullable enable

/// <summary>
/// SSH datetime.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct PickySshTime
{
    private const string NativeLib = "picky";

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PickySshTime_now", ExactSpelling = true)]
    public static unsafe extern PickySshTime* Now();

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PickySshTime_from_timestamp", ExactSpelling = true)]
    public static unsafe extern PickySshTime* FromTimestamp(ulong timestamp);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PickySshTime_timestamp", ExactSpelling = true)]
    public static unsafe extern ulong Timestamp(PickySshTime* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PickySshTime_month", ExactSpelling = true)]
    public static unsafe extern byte Month(PickySshTime* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PickySshTime_day", ExactSpelling = true)]
    public static unsafe extern byte Day(PickySshTime* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PickySshTime_hour", ExactSpelling = true)]
    public static unsafe extern byte Hour(PickySshTime* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PickySshTime_minute", ExactSpelling = true)]
    public static unsafe extern byte Minute(PickySshTime* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PickySshTime_second", ExactSpelling = true)]
    public static unsafe extern byte Second(PickySshTime* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PickySshTime_year", ExactSpelling = true)]
    public static unsafe extern ushort Year(PickySshTime* self);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PickySshTime_destroy", ExactSpelling = true)]
    public static unsafe extern void Destroy(PickySshTime* self);
}

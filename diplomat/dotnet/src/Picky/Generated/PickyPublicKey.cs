// Automatically generated by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky;

#nullable enable

public partial class PickyPublicKey: IDisposable
{
    private unsafe Raw.PickyPublicKey* _inner;

    /// <summary>
    /// Creates a managed <c>PickyPublicKey</c> from a raw handle.
    /// </summary>
    /// <remarks>
    /// Safety: you should not build two managed objects using the same raw handle (may causes use-after-free and double-free).
    /// </remarks>
    /// <remarks>
    /// This constructor assumes the raw struct is allocated on Rust side.
    /// If implemented, the custom Drop implementation on Rust side WILL run on destruction.
    /// </remarks>
    public unsafe PickyPublicKey(Raw.PickyPublicKey* handle)
    {
        _inner = handle;
    }

    /// <summary>
    /// Extracts public key from PEM object.
    /// </summary>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>PickyPublicKey</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public static PickyPublicKey FromPem(PickyPem pem)
    {
        unsafe
        {
            Raw.PickyPem* pemRaw;
            pemRaw = pem.AsFFI();
            if (pemRaw == null)
            {
                throw new ObjectDisposedException("PickyPem");
            }
            Raw.KeyFfiResultBoxPickyPublicKeyBoxPickyError result = Raw.PickyPublicKey.FromPem(pemRaw);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            Raw.PickyPublicKey* retVal = result.Ok;
            return new PickyPublicKey(retVal);
        }
    }

    /// <summary>
    /// Reads a public key from its DER encoding.
    /// </summary>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>PickyPublicKey</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public static PickyPublicKey FromDer(byte[] der)
    {
        unsafe
        {
            nuint derLength = (nuint)der.Length;
            fixed (byte* derPtr = der)
            {
                Raw.KeyFfiResultBoxPickyPublicKeyBoxPickyError result = Raw.PickyPublicKey.FromDer(derPtr, derLength);
                if (!result.isOk)
                {
                    throw new PickyException(new PickyError(result.Err));
                }
                Raw.PickyPublicKey* retVal = result.Ok;
                return new PickyPublicKey(retVal);
            }
        }
    }

    /// <summary>
    /// Exports the public key into a PEM object
    /// </summary>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>PickyPem</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public PickyPem ToPem()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickyPublicKey");
            }
            Raw.KeyFfiResultBoxPickyPemBoxPickyError result = Raw.PickyPublicKey.ToPem(_inner);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            Raw.PickyPem* retVal = result.Ok;
            return new PickyPem(retVal);
        }
    }

    /// <summary>
    /// Returns the underlying raw handle.
    /// </summary>
    public unsafe Raw.PickyPublicKey* AsFFI()
    {
        return _inner;
    }

    /// <summary>
    /// Marks this object as moved into Rust side.
    /// </summary>
    public void MarkAsMoved()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickyPublicKey");
            }
            _inner = null;
        }
    }

    /// <summary>
    /// Restores unmanaged ressource handle to this object.
    /// </summary>
    public unsafe void RestoreHandle(Raw.PickyPublicKey* handle)
    {
        _inner = handle;
    }

    /// <summary>
    /// Destroys the underlying object immediately.
    /// </summary>
    public void Dispose()
    {
        unsafe
        {
            if (_inner == null)
            {
                return;
            }

            Raw.PickyPublicKey.Destroy(_inner);
            _inner = null;

            GC.SuppressFinalize(this);
        }
    }

    ~PickyPublicKey()
    {
        Dispose();
    }
}

// Automatically generated by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky;

#nullable enable

/// <summary>
/// SSH Public Key.
/// </summary>
public partial class PickySshPublicKey: IDisposable
{
    private unsafe Raw.PickySshPublicKey* _inner;

    public string Comment
    {
        get
        {
            return GetComment();
        }
    }

    /// <summary>
    /// Creates a managed <c>PickySshPublicKey</c> from a raw handle.
    /// </summary>
    /// <remarks>
    /// Safety: you should not build two managed objects using the same raw handle (may causes use-after-free and double-free).
    /// </remarks>
    /// <remarks>
    /// This constructor assumes the raw struct is allocated on Rust side.
    /// If implemented, the custom Drop implementation on Rust side WILL run on destruction.
    /// </remarks>
    public unsafe PickySshPublicKey(Raw.PickySshPublicKey* handle)
    {
        _inner = handle;
    }

    /// <summary>
    /// Parses string representation of a SSH Public Key.
    /// </summary>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>PickySshPublicKey</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public static PickySshPublicKey Parse(string repr)
    {
        unsafe
        {
            byte[] reprBuf = DiplomatUtils.StringToUtf8(repr);
            nuint reprBufLength = (nuint)reprBuf.Length;
            fixed (byte* reprBufPtr = reprBuf)
            {
                Raw.SshFfiResultBoxPickySshPublicKeyBoxPickyError result = Raw.PickySshPublicKey.Parse(reprBufPtr, reprBufLength);
                if (!result.isOk)
                {
                    throw new PickyException(new PickyError(result.Err));
                }
                Raw.PickySshPublicKey* retVal = result.Ok;
                return new PickySshPublicKey(retVal);
            }
        }
    }

    /// <summary>
    /// Returns the SSH Public Key string representation.
    /// </summary>
    /// <remarks>
    /// It is generally represented as:
    /// "<algorithm> <der for the key> <comment>"
    /// where <comment> is usually an email address.
    /// </remarks>
    /// <exception cref="PickyException"></exception>
    public void ToRepr(DiplomatWriteable writeable)
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshPublicKey");
            }
            Raw.SshFfiResultVoidBoxPickyError result = Raw.PickySshPublicKey.ToRepr(_inner, &writeable);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
        }
    }

    /// <summary>
    /// Returns the SSH Public Key string representation.
    /// </summary>
    /// <remarks>
    /// It is generally represented as:
    /// "<algorithm> <der for the key> <comment>"
    /// where <comment> is usually an email address.
    /// </remarks>
    /// <exception cref="PickyException"></exception>
    public string ToRepr()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshPublicKey");
            }
            DiplomatWriteable writeable = new DiplomatWriteable();
            Raw.SshFfiResultVoidBoxPickyError result = Raw.PickySshPublicKey.ToRepr(_inner, &writeable);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            string retVal = writeable.ToUnicode();
            writeable.Dispose();
            return retVal;
        }
    }

    /// <exception cref="PickyException"></exception>
    public void GetComment(DiplomatWriteable writeable)
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshPublicKey");
            }
            Raw.SshFfiResultVoidBoxPickyError result = Raw.PickySshPublicKey.GetComment(_inner, &writeable);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
        }
    }

    /// <exception cref="PickyException"></exception>
    public string GetComment()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshPublicKey");
            }
            DiplomatWriteable writeable = new DiplomatWriteable();
            Raw.SshFfiResultVoidBoxPickyError result = Raw.PickySshPublicKey.GetComment(_inner, &writeable);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            string retVal = writeable.ToUnicode();
            writeable.Dispose();
            return retVal;
        }
    }

    /// <summary>
    /// Returns the underlying raw handle.
    /// </summary>
    public unsafe Raw.PickySshPublicKey* AsFFI()
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
                throw new ObjectDisposedException("PickySshPublicKey");
            }
            _inner = null;
        }
    }

    /// <summary>
    /// Restores unmanaged ressource handle to this object.
    /// </summary>
    public unsafe void RestoreHandle(Raw.PickySshPublicKey* handle)
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

            Raw.PickySshPublicKey.Destroy(_inner);
            _inner = null;

            GC.SuppressFinalize(this);
        }
    }

    ~PickySshPublicKey()
    {
        Dispose();
    }
}

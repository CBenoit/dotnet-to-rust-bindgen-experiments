// Automatically generated by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky;

#nullable enable

public partial class PickySshCert: IDisposable
{
    private unsafe Raw.PickySshCert* _inner;

    public PickySshCertType CertType
    {
        get
        {
            return GetCertType();
        }
    }

    public string Comment
    {
        get
        {
            return GetComment();
        }
    }

    public string KeyId
    {
        get
        {
            return GetKeyId();
        }
    }

    public PickySshPublicKey PublicKey
    {
        get
        {
            return GetPublicKey();
        }
    }

    public PickySshPublicKey SignatureKey
    {
        get
        {
            return GetSignatureKey();
        }
    }

    public PickySshCertKeyType SshKeyType
    {
        get
        {
            return GetSshKeyType();
        }
    }

    public PickySshTime ValidAfter
    {
        get
        {
            return GetValidAfter();
        }
    }

    public PickySshTime ValidBefore
    {
        get
        {
            return GetValidBefore();
        }
    }

    /// <summary>
    /// Creates a managed <c>PickySshCert</c> from a raw handle.
    /// </summary>
    /// <remarks>
    /// Safety: you should not build two managed objects using the same raw handle (may causes use-after-free and double-free).
    /// </remarks>
    /// <remarks>
    /// This constructor assumes the raw struct is allocated on Rust side.
    /// If implemented, the custom Drop implementation on Rust side WILL run on destruction.
    /// </remarks>
    public unsafe PickySshCert(Raw.PickySshCert* handle)
    {
        _inner = handle;
    }

    /// <returns>
    /// A <c>PickySshCertBuilder</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public static PickySshCertBuilder Builder()
    {
        unsafe
        {
            Raw.PickySshCertBuilder* retVal = Raw.PickySshCert.Builder();
            return new PickySshCertBuilder(retVal);
        }
    }

    /// <summary>
    /// Parses string representation of a SSH Certificate.
    /// </summary>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>PickySshCert</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public static PickySshCert Parse(string repr)
    {
        unsafe
        {
            byte[] reprBuf = DiplomatUtils.StringToUtf8(repr);
            nuint reprBufLength = (nuint)reprBuf.Length;
            fixed (byte* reprBufPtr = reprBuf)
            {
                Raw.SshFfiResultBoxPickySshCertBoxPickyError result = Raw.PickySshCert.Parse(reprBufPtr, reprBufLength);
                if (!result.isOk)
                {
                    throw new PickyException(new PickyError(result.Err));
                }
                Raw.PickySshCert* retVal = result.Ok;
                return new PickySshCert(retVal);
            }
        }
    }

    /// <summary>
    /// Returns the SSH Certificate string representation.
    /// </summary>
    /// <exception cref="PickyException"></exception>
    public void ToRepr(DiplomatWriteable writeable)
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshCert");
            }
            Raw.SshFfiResultVoidBoxPickyError result = Raw.PickySshCert.ToRepr(_inner, &writeable);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
        }
    }

    /// <summary>
    /// Returns the SSH Certificate string representation.
    /// </summary>
    /// <exception cref="PickyException"></exception>
    public string ToRepr()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshCert");
            }
            DiplomatWriteable writeable = new DiplomatWriteable();
            Raw.SshFfiResultVoidBoxPickyError result = Raw.PickySshCert.ToRepr(_inner, &writeable);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            string retVal = writeable.ToUnicode();
            writeable.Dispose();
            return retVal;
        }
    }

    /// <returns>
    /// A <c>PickySshPublicKey</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public PickySshPublicKey GetPublicKey()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshCert");
            }
            Raw.PickySshPublicKey* retVal = Raw.PickySshCert.GetPublicKey(_inner);
            return new PickySshPublicKey(retVal);
        }
    }

    /// <returns>
    /// A <c>PickySshCertKeyType</c> allocated on C# side.
    /// If a custom Drop implementation is implemented on Rust side, it will NOT run on destruction.
    /// </returns>
    public PickySshCertKeyType GetSshKeyType()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshCert");
            }
            Raw.PickySshCertKeyType retVal = Raw.PickySshCert.GetSshKeyType(_inner);
            return (PickySshCertKeyType)retVal;
        }
    }

    /// <returns>
    /// A <c>PickySshCertType</c> allocated on C# side.
    /// If a custom Drop implementation is implemented on Rust side, it will NOT run on destruction.
    /// </returns>
    public PickySshCertType GetCertType()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshCert");
            }
            Raw.PickySshCertType retVal = Raw.PickySshCert.GetCertType(_inner);
            return (PickySshCertType)retVal;
        }
    }

    /// <returns>
    /// A <c>PickySshTime</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public PickySshTime GetValidAfter()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshCert");
            }
            Raw.PickySshTime* retVal = Raw.PickySshCert.GetValidAfter(_inner);
            return new PickySshTime(retVal);
        }
    }

    /// <returns>
    /// A <c>PickySshTime</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public PickySshTime GetValidBefore()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshCert");
            }
            Raw.PickySshTime* retVal = Raw.PickySshCert.GetValidBefore(_inner);
            return new PickySshTime(retVal);
        }
    }

    /// <returns>
    /// A <c>PickySshPublicKey</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public PickySshPublicKey GetSignatureKey()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshCert");
            }
            Raw.PickySshPublicKey* retVal = Raw.PickySshCert.GetSignatureKey(_inner);
            return new PickySshPublicKey(retVal);
        }
    }

    /// <exception cref="PickyException"></exception>
    public void GetKeyId(DiplomatWriteable writeable)
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshCert");
            }
            Raw.SshFfiResultVoidBoxPickyError result = Raw.PickySshCert.GetKeyId(_inner, &writeable);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
        }
    }

    /// <exception cref="PickyException"></exception>
    public string GetKeyId()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickySshCert");
            }
            DiplomatWriteable writeable = new DiplomatWriteable();
            Raw.SshFfiResultVoidBoxPickyError result = Raw.PickySshCert.GetKeyId(_inner, &writeable);
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
                throw new ObjectDisposedException("PickySshCert");
            }
            Raw.SshFfiResultVoidBoxPickyError result = Raw.PickySshCert.GetComment(_inner, &writeable);
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
                throw new ObjectDisposedException("PickySshCert");
            }
            DiplomatWriteable writeable = new DiplomatWriteable();
            Raw.SshFfiResultVoidBoxPickyError result = Raw.PickySshCert.GetComment(_inner, &writeable);
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
    public unsafe Raw.PickySshCert* AsFFI()
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
                throw new ObjectDisposedException("PickySshCert");
            }
            _inner = null;
        }
    }

    /// <summary>
    /// Restores unmanaged ressource handle to this object.
    /// </summary>
    public unsafe void RestoreHandle(Raw.PickySshCert* handle)
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

            Raw.PickySshCert.Destroy(_inner);
            _inner = null;

            GC.SuppressFinalize(this);
        }
    }

    ~PickySshCert()
    {
        Dispose();
    }
}

﻿// <copyright file="Exceptions.cs" company="Techyian">
// Copyright (c) Techyian. All rights reserved.
// Licensed under the MIT License. Please see LICENSE.txt for License info.
// </copyright>

using MMALSharp.Native;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;

namespace MMALSharp
{
    /// <summary>
    /// Represents unspecific errors that occur during working with the Pi Camera.
    /// </summary>
    public class PiCameraError : Exception
    {
        /// <summary>
        /// Creates a new instance of the <see cref="PiCameraError"/> exception.
        /// </summary>
        public PiCameraError() : base() { }
        /// <summary>
        /// Creates a new instance of the <see cref="PiCameraError"/> exception with a specified message.
        /// </summary>
        /// <param name="msg">A message that describes the current error.</param>
        public PiCameraError(string msg) : base(msg) { }
    }

    /// <summary>
    /// Base class for all native error exception wrappers.
    /// </summary>
    public class MMALException : Exception
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALException"/> class with the specified error code and message.
        /// This exception is the base class for all exception wrappers.
        /// </summary>
        /// <param name="status">The native status code.</param>
        /// <param name="message">The error message to print.</param>
        public MMALException(MMALUtil.MMAL_STATUS_T status, string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Native error corresponding to an <see cref="OutOfMemoryException"/>.
    /// </summary>
    public class MMALNoMemoryException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALNoMemoryException"/> class with the specified message.
        /// This exception is similar to an <see cref="OutOfMemoryException"/>.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALNoMemoryException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_ENOMEM, $"Out of memory. {message}")
        {
        }
    }

    /// <summary>
    /// Native error that occurs when running out of resources other than memory.
    /// </summary>
    public class MMALNoSpaceException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALNoSpaceException"/> class with the specified message.
        /// This exception indicates running out of resources other than memory.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALNoSpaceException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_ENOSPC, $"Out of resources. {message}")
        {
        }
    }

    /// <summary>
    /// Native error corresponding to an <see cref="ArgumentException"/>.
    /// </summary>
    public class MMALInvalidException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALInvalidException"/> class with the specified message.
        /// This exception is similar to an <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALInvalidException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_EINVAL, $"Argument is invalid. {message}")
        {
        }
    }

    /// <summary>
    /// Native error corresponding to a <see cref="NotImplementedException"/>.
    /// </summary>
    public class MMALNotImplementedException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALNotImplementedException"/> class with the specified message.
        /// This exception is similar to a <see cref="NotImplementedException"/>.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALNotImplementedException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_ENOSYS, $"Function not implemented. {message}")
        {
        }
    }

    /// <summary>
    /// Native error corresponding to a <see cref="System.IO.FileNotFoundException"/> or <see cref="System.IO.DirectoryNotFoundException"/>.
    /// </summary>
    public class MMALInvalidDirectoryException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALInvalidDeviceException"/> class with the specified message.
        /// This exception is similar to a <see cref="System.IO.FileNotFoundException"/> or <see cref="System.IO.DirectoryNotFoundException"/>.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALInvalidDirectoryException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_ENOENT, $"No such file or directory. {message}")
        {
        }
    }

    /// <summary>
    /// Native error that occurs when a device or address does not exist. For example when SDL initialisation fails.
    /// </summary>
    public class MMALInvalidDeviceException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALInvalidDeviceException"/> class with the specified message.
        /// This exception indicates a non existent device or address.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALInvalidDeviceException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_ENXIO, $"No such device or address. {message}")
        {
        }
    }

    /// <summary>
    /// Native error corresponding to an <see cref="System.IO.IOException"/>.
    /// </summary>
    public class MMALIOException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALIOException"/> class with the specified message.
        /// This exception is similar to an <see cref="System.IO.IOException"/>.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALIOException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_EIO, $"I/O error. {message}")
        {
        }
    }

    /// <summary>
    /// Native error that occurs when performing an illegal seek operation.
    /// </summary>
    public class MMALIllegalSeekException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALIllegalSeekException"/> class with the specified message.
        /// This exception indicates an illegal seek operation.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALIllegalSeekException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_ESPIPE, $"Illegal seek. {message}")
        {
            // This native error seems to unused in the underlying MMAL code.
        }
    }

    /// <summary>
    /// Native error that occurs when an underlying VideoCore container faces corrupted data.
    /// </summary>
    public class MMALCorruptException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALCorruptException"/> class with the specified message.
        /// This exception indicates corrupted data.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALCorruptException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_ECORRUPT, $"Data is corrupt. {message}")
        {
        }
    }

    /// <summary>
    /// Native error that occurs when a native VideoCore component is not ready.
    /// </summary>
    public class MMALComponentNotReadyException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALComponentNotReadyException"/> class with the specified message.
        /// This exception indicates that a component is not ready.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALComponentNotReadyException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_ENOTREADY, $"Component is not ready. {message}")
        {
        }
    }

    /// <summary>
    /// Native error that occurs when a component is not configured.
    /// </summary>
    public class MMALComponentNotConfiguredException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALComponentNotConfiguredException"/> class with the specified message.
        /// This exception indicates a not configured component.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALComponentNotConfiguredException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_ECONFIG, $"Component is not configured. {message}")
        {
            // This native error seems to unused in the underlying MMAL code.
        }
    }

    /// <summary>
    /// Native error that occurs when a port is already connected.
    /// </summary>
    public class MMALPortConnectedException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALPortNotConnectedException"/> class with the specified message.
        /// This exception indicates an already connected port.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALPortConnectedException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_EISCONN, $"Port is already connected. {message}")
        {
        }
    }

    /// <summary>
    /// Native error that occurs when a port is not connected.
    /// </summary>
    public class MMALPortNotConnectedException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALPortNotConnectedException"/> class with the specified message.
        /// This exception indicates a disconnected port.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALPortNotConnectedException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_ENOTCONN, $"Port is disconnected. {message}")
        {
        }
    }

    /// <summary>
    /// Native error that occurs when resource (e.g. a buffer) is temporarily unavailable. You should try again later.
    /// </summary>
    public class MMALResourceUnavailableException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALResourceUnavailableException"/> class with the specified message.
        /// This exception indicates a temporiarily unavailable resource.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALResourceUnavailableException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_EAGAIN, $"Resource temporarily unavailable; try again later. {message}")
        {
        }
    }

    /// <summary>
    /// Native error that occurs when facing a bad address. For example when a property illegaly gets over overridden.
    /// </summary>
    public class MMALBadAddressException : MMALException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MMALBadAddressException"/> class with the specified message.
        /// This exception indicates a bad address.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public MMALBadAddressException(string message) : base(MMALUtil.MMAL_STATUS_T.MMAL_EFAULT, $"Bad address. {message}")
        {
        }
    }

    /// <summary>
    /// Provides methods which support calling native methods.
    /// </summary>
    public static class MMALCallerHelper
    {
        /// <summary>
        /// Checks whether the provided MMAL_STATUS_T is equal to MMAL_SUCCESS and throws the associated exception in case of an error.
        /// </summary>
        /// <param name="status">The MMAL_STATUS_T to search for an error.</param>
        /// <param name="message">The message for the exception that will be thrown if an error occurred.</param>
        public static void MMALCheck(MMALUtil.MMAL_STATUS_T status, string message)
        {
            if (status != MMALUtil.MMAL_STATUS_T.MMAL_SUCCESS)
            {
                switch (status)
                {
                    case MMALUtil.MMAL_STATUS_T.MMAL_ENOMEM:
                        throw new MMALNoMemoryException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_ENOSPC:
                        throw new MMALNoSpaceException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_EINVAL:
                        throw new MMALInvalidException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_ENOSYS:
                        throw new MMALNotImplementedException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_ENOENT:
                        throw new MMALInvalidDirectoryException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_ENXIO:
                        throw new MMALInvalidDeviceException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_EIO:
                        throw new MMALIOException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_ESPIPE:
                        throw new MMALIllegalSeekException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_ECORRUPT:
                        throw new MMALCorruptException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_ENOTREADY:
                        throw new MMALComponentNotReadyException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_ECONFIG:
                        throw new MMALComponentNotConfiguredException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_EISCONN:
                        throw new MMALPortConnectedException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_ENOTCONN:
                        throw new MMALPortNotConnectedException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_EAGAIN:
                        throw new MMALResourceUnavailableException(message);
                    case MMALUtil.MMAL_STATUS_T.MMAL_EFAULT:
                        throw new MMALBadAddressException(message);
                    default:
                        throw new MMALException(status, $"Unknown error occurred. {message}");
                }
            }
        }
    }

}

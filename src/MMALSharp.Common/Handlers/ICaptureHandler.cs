﻿// <copyright file="ICaptureHandler.cs" company="Techyian">
// Copyright (c) Techyian. All rights reserved.
// Licensed under the MIT License. Please see LICENSE.txt for License info.
// </copyright>

using System;

namespace MMALSharp.Handlers
{
    public interface ICaptureHandler : IDisposable
    {
        /// <summary>
        /// Used to return user provided image data.
        /// </summary>
        /// <returns>A ProcessResult object containing the user provided image data.</returns>
        ProcessResult Process(uint allocSize);
        /// <summary>
        /// Used to process the byte array containing our image data from an output port.
        /// </summary>
        /// <param name="data">A byte array containing image data.</param>
        void Process(byte[] data);     
        /// <summary>
        /// Used for any further processing once we have completed capture.
        /// </summary>
        void PostProcess();
    }
}

﻿// <copyright file="BcmHost.cs" company="Techyian">
// Copyright (c) Techyian. All rights reserved.
// Licensed under the MIT License. Please see LICENSE.txt for License info.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MMALSharp.Native
{
    public static class BcmHost
    {
#pragma warning disable 1591

        [DllImport("libbcm_host.so", EntryPoint = "bcm_host_init", CallingConvention = CallingConvention.Cdecl)]
        public static extern void bcm_host_init();

        [DllImport("libbcm_host.so", EntryPoint = "bcm_host_deinit", CallingConvention = CallingConvention.Cdecl)]
        public static extern void bcm_host_deinit();

        [DllImport("libbcm_host.so", EntryPoint = "graphics_get_display_size", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int graphics_get_display_size(ushort display_number, uint* width, uint* height);
    }
}

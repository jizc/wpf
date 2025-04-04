// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Runtime.InteropServices;

#if WINDOWS_BASE
namespace MS.Internal.WindowsBase.Interop
#elif PRESENTATION_CORE
namespace System.Windows.Interop
#elif PRESENTATIONFRAMEWORK
namespace MS.Internal.PresentationFramework.Interop
#elif REACHFRAMEWORK
namespace MS.Internal.ReachFramework.Interop
#elif UIAUTOMATIONTYPES
namespace MS.Internal.UIAutomationTypes.Interop
#else
namespace Microsoft.Internal.Interop
#endif
{
    /// <summary>
    /// DevDiv:1158540
    /// Adding wrapper around OSVersionHelper native code.  This is linked into PresentationNative so we just PInvoke it from there.
    ///
    /// To add a new OS:
    ///     Make sure you have followed the instructions in OperatingSystemVersion.cs to get here
    ///     Add appropriate PInvoke to your new Is{OSName}OrGreater function
    ///     Add case to switch statement in IsOsVersionOrGreater
    ///     Add new if statement to the TOP of GetOsVersion
    /// </summary>
    internal static class OSVersionHelper
    {
        #region Static OS Members

        internal static bool IsOsWindows10RS5OrGreater { get; set; }

        internal static bool IsOsWindows10RS4OrGreater { get; set; }

        internal static bool IsOsWindows10RS3OrGreater { get; set; }

        internal static bool IsOsWindows10RS2OrGreater { get; set; }

        internal static bool IsOsWindows10RS1OrGreater { get; set; }

        internal static bool IsOsWindows10TH2OrGreater { get; set; }

        internal static bool IsOsWindows10TH1OrGreater { get; set; }

        internal static bool IsOsWindows10OrGreater { get; set; }

        internal static bool IsOsWindows8Point1OrGreater { get; set; }

        internal static bool IsOsWindows8OrGreater { get; set; }

        internal static bool IsOsWindows7SP1OrGreater { get; set; }

        internal static bool IsOsWindows7OrGreater { get; set; }

        internal static bool IsOsWindowsVistaSP2OrGreater { get; set; }

        internal static bool IsOsWindowsVistaSP1OrGreater { get; set; }

        internal static bool IsOsWindowsVistaOrGreater { get; set; }

        internal static bool IsOsWindowsXPSP3OrGreater { get; set; }

        internal static bool IsOsWindowsXPSP2OrGreater { get; set; }

        internal static bool IsOsWindowsXPSP1OrGreater { get; set; }

        internal static bool IsOsWindowsXPOrGreater { get; set; }

        internal static bool IsOsWindowsServer { get; set; }

        #endregion

        #region Constructor

        static OSVersionHelper()
        {
            IsOsWindows10RS5OrGreater = IsWindows10RS5OrGreater();

            IsOsWindows10RS4OrGreater = IsWindows10RS4OrGreater();

            IsOsWindows10RS3OrGreater = IsWindows10RS3OrGreater();

            IsOsWindows10RS2OrGreater = IsWindows10RS2OrGreater();

            IsOsWindows10RS1OrGreater = IsWindows10RS1OrGreater();

            IsOsWindows10TH2OrGreater = IsWindows10TH2OrGreater();

            IsOsWindows10TH1OrGreater = IsWindows10TH1OrGreater();

            IsOsWindows10OrGreater = IsWindows10OrGreater();

            IsOsWindows8Point1OrGreater = IsWindows8Point1OrGreater();

            IsOsWindows8OrGreater = IsWindows8OrGreater();

            IsOsWindows7SP1OrGreater = IsWindows7SP1OrGreater();

            IsOsWindows7OrGreater = IsWindows7OrGreater();

            IsOsWindowsVistaSP2OrGreater = IsWindowsVistaSP2OrGreater();

            IsOsWindowsVistaSP1OrGreater = IsWindowsVistaSP1OrGreater();

            IsOsWindowsVistaOrGreater = IsWindowsVistaOrGreater();

            IsOsWindowsXPSP3OrGreater = IsWindowsXPSP3OrGreater();

            IsOsWindowsXPSP2OrGreater = IsWindowsXPSP2OrGreater();

            IsOsWindowsXPSP1OrGreater = IsWindowsXPSP1OrGreater();

            IsOsWindowsXPOrGreater = IsWindowsXPOrGreater();

            IsOsWindowsServer = IsWindowsServer();
        }

        #endregion

        #region DLL Imports

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows10RS5OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows10RS4OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows10RS3OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows10RS2OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows10RS1OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows10TH2OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows10TH1OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows10OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows8Point1OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows8OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows7SP1OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindows7OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindowsVistaSP2OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindowsVistaSP1OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindowsVistaOrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindowsXPSP3OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindowsXPSP2OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindowsXPSP1OrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindowsXPOrGreater();

        [DllImport(DllImport.PresentationNative, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsWindowsServer();

        #endregion

        #region Managed API

        internal static bool IsOsVersionOrGreater(OperatingSystemVersion osVer)
        {
            switch (osVer)
            {
                case OperatingSystemVersion.Windows10RS5:
                    return IsOsWindows10RS5OrGreater;
                case OperatingSystemVersion.Windows10RS4:
                    return IsOsWindows10RS4OrGreater;
                case OperatingSystemVersion.Windows10RS3:
                    return IsOsWindows10RS3OrGreater;
                case OperatingSystemVersion.Windows10RS2:
                    return IsOsWindows10RS2OrGreater;
                case OperatingSystemVersion.Windows10RS1:
                    return IsOsWindows10RS1OrGreater;
                case OperatingSystemVersion.Windows10TH2:
                    return IsOsWindows10TH2OrGreater;
                case OperatingSystemVersion.Windows10:
                    return IsOsWindows10OrGreater;
                case OperatingSystemVersion.Windows8Point1:
                    return IsOsWindows8Point1OrGreater;
                case OperatingSystemVersion.Windows8:
                    return IsOsWindows8OrGreater;
                case OperatingSystemVersion.Windows7SP1:
                    return IsOsWindows7SP1OrGreater;
                case OperatingSystemVersion.Windows7:
                    return IsOsWindows7OrGreater;
                case OperatingSystemVersion.WindowsVistaSP2:
                    return IsOsWindowsVistaSP2OrGreater;
                case OperatingSystemVersion.WindowsVistaSP1:
                    return IsOsWindowsVistaSP1OrGreater;
                case OperatingSystemVersion.WindowsVista:
                    return IsOsWindowsVistaOrGreater;
                case OperatingSystemVersion.WindowsXPSP3:
                    return IsOsWindowsXPSP3OrGreater;
                case OperatingSystemVersion.WindowsXPSP2:
                    return IsOsWindowsXPSP2OrGreater;
            }

            throw new ArgumentException($"{osVer} is not a valid OS!", nameof(osVer));
        }

        internal static OperatingSystemVersion GetOsVersion()
        {
            if (IsOsWindows10RS5OrGreater)
            {
                return OperatingSystemVersion.Windows10RS5;
            }
            else if (IsOsWindows10RS4OrGreater)
            {
                return OperatingSystemVersion.Windows10RS4;
            }
            else if (IsOsWindows10RS3OrGreater)
            {
                return OperatingSystemVersion.Windows10RS3;
            }
            else if (IsOsWindows10RS2OrGreater)
            {
                return OperatingSystemVersion.Windows10RS2;
            }
            else if (IsOsWindows10RS1OrGreater)
            {
                return OperatingSystemVersion.Windows10RS1;
            }
            else if (IsOsWindows10TH2OrGreater)
            {
                return OperatingSystemVersion.Windows10TH2;
            }
            else if (IsOsWindows10OrGreater)
            {
                return OperatingSystemVersion.Windows10;
            }
            else if (IsOsWindows8Point1OrGreater)
            {
                return OperatingSystemVersion.Windows8Point1;
            }
            else if (IsOsWindows8OrGreater)
            {
                return OperatingSystemVersion.Windows8;
            }
            else if (IsOsWindows7SP1OrGreater)
            {
                return OperatingSystemVersion.Windows7SP1;
            }
            else if (IsOsWindows7OrGreater)
            {
                return OperatingSystemVersion.Windows7;
            }
            else if (IsOsWindowsVistaSP2OrGreater)
            {
                return OperatingSystemVersion.WindowsVistaSP2;
            }
            else if (IsOsWindowsVistaSP1OrGreater)
            {
                return OperatingSystemVersion.WindowsVistaSP1;
            }
            else if (IsOsWindowsVistaOrGreater)
            {
                return OperatingSystemVersion.WindowsVista;
            }
            else if (IsOsWindowsXPSP3OrGreater)
            {
                return OperatingSystemVersion.WindowsXPSP3;
            }
            else if (IsOsWindowsXPSP2OrGreater)
            {
                return OperatingSystemVersion.WindowsXPSP2;
            }

            throw new Exception("OSVersionHelper.GetOsVersion Could not detect OS!");
        }

        #endregion
    }
}

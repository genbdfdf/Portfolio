﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Android.App;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

#if DEBUG 
[assembly: Application(Debuggable=true)]
#else 
[assembly: Application(Debuggable=false)]
#endif

//[assembly: AssemblyTitle("PenghuSpace")]
//[assembly: AssemblyDescription("")]
//[assembly: AssemblyConfiguration("")]
//[assembly: AssemblyCompany("")]
//[assembly: AssemblyProduct("PenghuSpace")]
//[assembly: AssemblyCopyright("Copyright ©  2022")]
//[assembly: AssemblyTrademark("")]
//[assembly: AssemblyCulture("")]
//[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//[assembly: AssemblyVersion("1.0.0.0")]
//[assembly: AssemblyFileVersion("1.0.0.0")]

//[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]
//[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
//[assembly: UsesFeature("android.hardware.location", Required = false)]
//[assembly: UsesFeature("android.hardware.location.gps", Required = false)]
//[assembly: UsesFeature("android.hardware.location.network", Required = false)]

//[assembly: UsesPermission(Android.Manifest.Permission.AccessBackgroundLocation)]

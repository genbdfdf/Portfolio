; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [93 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [186 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 58
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 57
	i32 42639949, ; 2: System.Threading.Thread => 0x28aa24d => 82
	i32 57263871, ; 3: Xamarin.Forms.Core.dll => 0x369c6ff => 27
	i32 66541672, ; 4: System.Diagnostics.StackTrace => 0x3f75868 => 45
	i32 117431740, ; 5: System.Runtime.InteropServices => 0x6ffddbc => 73
	i32 122350210, ; 6: System.Threading.Channels.dll => 0x74aea82 => 81
	i32 142721839, ; 7: System.Net.WebHeaderCollection => 0x881c32f => 65
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 23
	i32 205061960, ; 9: System.ComponentModel => 0xc38ff48 => 41
	i32 209399409, ; 10: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 9
	i32 318968648, ; 11: Xamarin.AndroidX.Activity.dll => 0x13031348 => 6
	i32 321597661, ; 12: System.Numerics => 0x132b30dd => 66
	i32 342366114, ; 13: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 17
	i32 347068432, ; 14: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 4
	i32 375677976, ; 15: System.Net.ServicePoint.dll => 0x16646418 => 62
	i32 379916513, ; 16: System.Threading.Thread.dll => 0x16a510e1 => 82
	i32 385762202, ; 17: System.Memory.dll => 0x16fe439a => 55
	i32 395744057, ; 18: _Microsoft.Android.Resource.Designer => 0x17969339 => 0
	i32 442521989, ; 19: Xamarin.Essentials => 0x1a605985 => 25
	i32 442565967, ; 20: System.Collections => 0x1a61054f => 38
	i32 450948140, ; 21: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 15
	i32 459347974, ; 22: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 76
	i32 465846621, ; 23: mscorlib => 0x1bc4415d => 87
	i32 469710990, ; 24: System.dll => 0x1bff388e => 86
	i32 498788369, ; 25: System.ObjectModel => 0x1dbae811 => 67
	i32 601371474, ; 26: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 672442732, ; 27: System.Collections.Concurrent => 0x2814a96c => 35
	i32 683518922, ; 28: System.Net.Security => 0x28bdabca => 61
	i32 690569205, ; 29: System.Xml.Linq.dll => 0x29293ff5 => 84
	i32 748832960, ; 30: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 2
	i32 759454413, ; 31: System.Net.Requests => 0x2d445acd => 60
	i32 775507847, ; 32: System.IO.Compression => 0x2e394f87 => 51
	i32 823281589, ; 33: System.Private.Uri.dll => 0x311247b5 => 69
	i32 830298997, ; 34: System.IO.Compression.Brotli => 0x317d5b75 => 50
	i32 904024072, ; 35: System.ComponentModel.Primitives.dll => 0x35e25008 => 39
	i32 967690846, ; 36: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 17
	i32 974778368, ; 37: FormsViewGroup.dll => 0x3a19f000 => 26
	i32 986514023, ; 38: System.Private.DataContractSerialization.dll => 0x3acd0267 => 68
	i32 992768348, ; 39: System.Collections.dll => 0x3b2c715c => 38
	i32 1012816738, ; 40: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 22
	i32 1019214401, ; 41: System.Drawing => 0x3cbffa41 => 48
	i32 1035644815, ; 42: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 7
	i32 1036536393, ; 43: System.Drawing.Primitives.dll => 0x3dc84a49 => 47
	i32 1042160112, ; 44: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 29
	i32 1044663988, ; 45: System.Linq.Expressions.dll => 0x3e444eb4 => 53
	i32 1052210849, ; 46: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 19
	i32 1082857460, ; 47: System.ComponentModel.TypeConverter => 0x408b17f4 => 40
	i32 1084122840, ; 48: Xamarin.Kotlin.StdLib => 0x409e66d8 => 32
	i32 1098259244, ; 49: System => 0x41761b2c => 86
	i32 1219128291, ; 50: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1292207520, ; 51: SQLitePCLRaw.core.dll => 0x4d0585a0 => 3
	i32 1293217323, ; 52: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 14
	i32 1309188875, ; 53: System.Private.DataContractSerialization => 0x4e08a30b => 68
	i32 1324164729, ; 54: System.Linq => 0x4eed2679 => 54
	i32 1376866003, ; 55: Xamarin.AndroidX.SavedState => 0x52114ed3 => 22
	i32 1406073936, ; 56: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 11
	i32 1408764838, ; 57: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 75
	i32 1452070440, ; 58: System.Formats.Asn1.dll => 0x568cd628 => 49
	i32 1458022317, ; 59: System.Net.Security.dll => 0x56e7a7ad => 61
	i32 1460219004, ; 60: Xamarin.Forms.Xaml => 0x57092c7c => 30
	i32 1462112819, ; 61: System.IO.Compression.dll => 0x57261233 => 51
	i32 1469204771, ; 62: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 8
	i32 1480492111, ; 63: System.IO.Compression.Brotli.dll => 0x583e844f => 50
	i32 1543031311, ; 64: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 80
	i32 1592978981, ; 65: System.Runtime.Serialization.dll => 0x5ef2ee25 => 77
	i32 1604827217, ; 66: System.Net.WebClient => 0x5fa7b851 => 64
	i32 1622152042, ; 67: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 20
	i32 1636350590, ; 68: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 13
	i32 1639515021, ; 69: System.Net.Http.dll => 0x61b9038d => 56
	i32 1639986890, ; 70: System.Text.RegularExpressions => 0x61c036ca => 80
	i32 1657153582, ; 71: System.Runtime => 0x62c6282e => 78
	i32 1658251792, ; 72: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 31
	i32 1677501392, ; 73: System.Net.Primitives.dll => 0x63fca3d0 => 59
	i32 1679769178, ; 74: System.Security.Cryptography => 0x641f3e5a => 79
	i32 1711441057, ; 75: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 4
	i32 1729485958, ; 76: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 10
	i32 1763938596, ; 77: System.Diagnostics.TraceSource.dll => 0x69239124 => 46
	i32 1766324549, ; 78: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 23
	i32 1776026572, ; 79: System.Core.dll => 0x69dc03cc => 43
	i32 1780572499, ; 80: Mono.Android.Runtime.dll => 0x6a216153 => 91
	i32 1788241197, ; 81: Xamarin.AndroidX.Fragment => 0x6a96652d => 15
	i32 1808609942, ; 82: Xamarin.AndroidX.Loader => 0x6bcd3296 => 20
	i32 1813058853, ; 83: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 32
	i32 1813201214, ; 84: Xamarin.Google.Android.Material => 0x6c13413e => 31
	i32 1824722060, ; 85: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 75
	i32 1858542181, ; 86: System.Linq.Expressions => 0x6ec71a65 => 53
	i32 1867746548, ; 87: Xamarin.Essentials.dll => 0x6f538cf4 => 25
	i32 1878053835, ; 88: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 30
	i32 1910275211, ; 89: System.Collections.NonGeneric.dll => 0x71dc7c8b => 36
	i32 1922975269, ; 90: UniversityAndroidApp.dll => 0x729e4625 => 34
	i32 1939592360, ; 91: System.Private.Xml.Linq => 0x739bd4a8 => 70
	i32 2019465201, ; 92: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 19
	i32 2045470958, ; 93: System.Private.Xml => 0x79eb68ee => 71
	i32 2055257422, ; 94: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 18
	i32 2070888862, ; 95: System.Diagnostics.TraceSource => 0x7b6f419e => 46
	i32 2079903147, ; 96: System.Runtime.dll => 0x7bf8cdab => 78
	i32 2097448633, ; 97: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 16
	i32 2103459038, ; 98: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 5
	i32 2126786730, ; 99: Xamarin.Forms.Platform.Android => 0x7ec430aa => 28
	i32 2127167465, ; 100: System.Console => 0x7ec9ffe9 => 42
	i32 2142473426, ; 101: System.Collections.Specialized => 0x7fb38cd2 => 37
	i32 2193016926, ; 102: System.ObjectModel.dll => 0x82b6c85e => 67
	i32 2201107256, ; 103: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 33
	i32 2201231467, ; 104: System.Net.Http => 0x8334206b => 56
	i32 2279755925, ; 105: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 21
	i32 2295906218, ; 106: System.Net.Sockets => 0x88d8bfaa => 63
	i32 2305521784, ; 107: System.Private.CoreLib.dll => 0x896b7878 => 89
	i32 2340441535, ; 108: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 72
	i32 2353062107, ; 109: System.Net.Primitives => 0x8c40e0db => 59
	i32 2435356389, ; 110: System.Console.dll => 0x912896e5 => 42
	i32 2458678730, ; 111: System.Net.Sockets.dll => 0x928c75ca => 63
	i32 2465273461, ; 112: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 2
	i32 2471841756, ; 113: netstandard.dll => 0x93554fdc => 88
	i32 2475788418, ; 114: Java.Interop.dll => 0x93918882 => 90
	i32 2484371297, ; 115: System.Net.ServicePoint => 0x94147f61 => 62
	i32 2605712449, ; 116: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 33
	i32 2617129537, ; 117: System.Private.Xml.dll => 0x9bfe3a41 => 71
	i32 2620871830, ; 118: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 13
	i32 2665622720, ; 119: System.Drawing.Primitives => 0x9ee22cc0 => 47
	i32 2720934335, ; 120: UniversityAndroidApp => 0xa22e29bf => 34
	i32 2724373263, ; 121: System.Runtime.Numerics.dll => 0xa262a30f => 74
	i32 2732626843, ; 122: Xamarin.AndroidX.Activity => 0xa2e0939b => 6
	i32 2735172069, ; 123: System.Threading.Channels => 0xa30769e5 => 81
	i32 2737747696, ; 124: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 8
	i32 2766581644, ; 125: Xamarin.Forms.Core => 0xa4e6af8c => 27
	i32 2778768386, ; 126: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 24
	i32 2810250172, ; 127: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 11
	i32 2819470561, ; 128: System.Xml.dll => 0xa80db4e1 => 85
	i32 2853208004, ; 129: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 24
	i32 2905242038, ; 130: mscorlib.dll => 0xad2a79b6 => 87
	i32 2909740682, ; 131: System.Private.CoreLib => 0xad6f1e8a => 89
	i32 2940926066, ; 132: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 45
	i32 2959614098, ; 133: System.ComponentModel.dll => 0xb0682092 => 41
	i32 2978675010, ; 134: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 14
	i32 3038032645, ; 135: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 0
	i32 3044182254, ; 136: FormsViewGroup => 0xb57288ee => 26
	i32 3059408633, ; 137: Mono.Android.Runtime => 0xb65adef9 => 91
	i32 3059793426, ; 138: System.ComponentModel.Primitives => 0xb660be12 => 39
	i32 3103600923, ; 139: System.Formats.Asn1 => 0xb8fd311b => 49
	i32 3111772706, ; 140: System.Runtime.Serialization => 0xb979e222 => 77
	i32 3220365878, ; 141: System.Threading => 0xbff2e236 => 83
	i32 3258312781, ; 142: Xamarin.AndroidX.CardView => 0xc235e84d => 10
	i32 3286872994, ; 143: SQLite-net.dll => 0xc3e9b3a2 => 1
	i32 3316684772, ; 144: System.Net.Requests.dll => 0xc5b097e4 => 60
	i32 3353484488, ; 145: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 16
	i32 3360279109, ; 146: SQLitePCLRaw.core => 0xc849ca45 => 3
	i32 3362522851, ; 147: Xamarin.AndroidX.Core => 0xc86c06e3 => 12
	i32 3366347497, ; 148: Java.Interop => 0xc8a662e9 => 90
	i32 3374999561, ; 149: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 21
	i32 3429136800, ; 150: System.Xml => 0xcc6479a0 => 85
	i32 3430777524, ; 151: netstandard => 0xcc7d82b4 => 88
	i32 3471940407, ; 152: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 40
	i32 3476120550, ; 153: Mono.Android => 0xcf3163e6 => 92
	i32 3509114376, ; 154: System.Xml.Linq => 0xd128d608 => 84
	i32 3536029504, ; 155: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 28
	i32 3608519521, ; 156: System.Linq.dll => 0xd715a361 => 54
	i32 3624195450, ; 157: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 72
	i32 3632359727, ; 158: Xamarin.Forms.Platform => 0xd881692f => 29
	i32 3641597786, ; 159: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 18
	i32 3660523487, ; 160: System.Net.NetworkInformation => 0xda2f27df => 58
	i32 3672681054, ; 161: Mono.Android.dll => 0xdae8aa5e => 92
	i32 3682565725, ; 162: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 9
	i32 3732100267, ; 163: System.Net.NameResolution => 0xde7354ab => 57
	i32 3748608112, ; 164: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 44
	i32 3754567612, ; 165: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 5
	i32 3792276235, ; 166: System.Collections.NonGeneric => 0xe2098b0b => 36
	i32 3802395368, ; 167: System.Collections.Specialized.dll => 0xe2a3f2e8 => 37
	i32 3823082795, ; 168: System.Security.Cryptography.dll => 0xe3df9d2b => 79
	i32 3829621856, ; 169: System.Numerics.dll => 0xe4436460 => 66
	i32 3849253459, ; 170: System.Runtime.InteropServices.dll => 0xe56ef253 => 73
	i32 3876362041, ; 171: SQLite-net => 0xe70c9739 => 1
	i32 3885497537, ; 172: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 65
	i32 3896106733, ; 173: System.Collections.Concurrent.dll => 0xe839deed => 35
	i32 3896760992, ; 174: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 12
	i32 3955647286, ; 175: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 7
	i32 4025784931, ; 176: System.Memory => 0xeff49a63 => 55
	i32 4068434129, ; 177: System.Private.Xml.Linq.dll => 0xf27f60d1 => 70
	i32 4073602200, ; 178: System.Threading.dll => 0xf2ce3c98 => 83
	i32 4099507663, ; 179: System.Drawing.dll => 0xf45985cf => 48
	i32 4100113165, ; 180: System.Private.Uri => 0xf462c30d => 69
	i32 4151237749, ; 181: System.Core => 0xf76edc75 => 43
	i32 4181436372, ; 182: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 76
	i32 4196529839, ; 183: System.Net.WebClient.dll => 0xfa21f6af => 64
	i32 4213026141, ; 184: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 44
	i32 4274976490 ; 185: System.Runtime.Numerics => 0xfecef6ea => 74
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [186 x i32] [
	i32 58, ; 0
	i32 57, ; 1
	i32 82, ; 2
	i32 27, ; 3
	i32 45, ; 4
	i32 73, ; 5
	i32 81, ; 6
	i32 65, ; 7
	i32 23, ; 8
	i32 41, ; 9
	i32 9, ; 10
	i32 6, ; 11
	i32 66, ; 12
	i32 17, ; 13
	i32 4, ; 14
	i32 62, ; 15
	i32 82, ; 16
	i32 55, ; 17
	i32 0, ; 18
	i32 25, ; 19
	i32 38, ; 20
	i32 15, ; 21
	i32 76, ; 22
	i32 87, ; 23
	i32 86, ; 24
	i32 67, ; 25
	i32 52, ; 26
	i32 35, ; 27
	i32 61, ; 28
	i32 84, ; 29
	i32 2, ; 30
	i32 60, ; 31
	i32 51, ; 32
	i32 69, ; 33
	i32 50, ; 34
	i32 39, ; 35
	i32 17, ; 36
	i32 26, ; 37
	i32 68, ; 38
	i32 38, ; 39
	i32 22, ; 40
	i32 48, ; 41
	i32 7, ; 42
	i32 47, ; 43
	i32 29, ; 44
	i32 53, ; 45
	i32 19, ; 46
	i32 40, ; 47
	i32 32, ; 48
	i32 86, ; 49
	i32 52, ; 50
	i32 3, ; 51
	i32 14, ; 52
	i32 68, ; 53
	i32 54, ; 54
	i32 22, ; 55
	i32 11, ; 56
	i32 75, ; 57
	i32 49, ; 58
	i32 61, ; 59
	i32 30, ; 60
	i32 51, ; 61
	i32 8, ; 62
	i32 50, ; 63
	i32 80, ; 64
	i32 77, ; 65
	i32 64, ; 66
	i32 20, ; 67
	i32 13, ; 68
	i32 56, ; 69
	i32 80, ; 70
	i32 78, ; 71
	i32 31, ; 72
	i32 59, ; 73
	i32 79, ; 74
	i32 4, ; 75
	i32 10, ; 76
	i32 46, ; 77
	i32 23, ; 78
	i32 43, ; 79
	i32 91, ; 80
	i32 15, ; 81
	i32 20, ; 82
	i32 32, ; 83
	i32 31, ; 84
	i32 75, ; 85
	i32 53, ; 86
	i32 25, ; 87
	i32 30, ; 88
	i32 36, ; 89
	i32 34, ; 90
	i32 70, ; 91
	i32 19, ; 92
	i32 71, ; 93
	i32 18, ; 94
	i32 46, ; 95
	i32 78, ; 96
	i32 16, ; 97
	i32 5, ; 98
	i32 28, ; 99
	i32 42, ; 100
	i32 37, ; 101
	i32 67, ; 102
	i32 33, ; 103
	i32 56, ; 104
	i32 21, ; 105
	i32 63, ; 106
	i32 89, ; 107
	i32 72, ; 108
	i32 59, ; 109
	i32 42, ; 110
	i32 63, ; 111
	i32 2, ; 112
	i32 88, ; 113
	i32 90, ; 114
	i32 62, ; 115
	i32 33, ; 116
	i32 71, ; 117
	i32 13, ; 118
	i32 47, ; 119
	i32 34, ; 120
	i32 74, ; 121
	i32 6, ; 122
	i32 81, ; 123
	i32 8, ; 124
	i32 27, ; 125
	i32 24, ; 126
	i32 11, ; 127
	i32 85, ; 128
	i32 24, ; 129
	i32 87, ; 130
	i32 89, ; 131
	i32 45, ; 132
	i32 41, ; 133
	i32 14, ; 134
	i32 0, ; 135
	i32 26, ; 136
	i32 91, ; 137
	i32 39, ; 138
	i32 49, ; 139
	i32 77, ; 140
	i32 83, ; 141
	i32 10, ; 142
	i32 1, ; 143
	i32 60, ; 144
	i32 16, ; 145
	i32 3, ; 146
	i32 12, ; 147
	i32 90, ; 148
	i32 21, ; 149
	i32 85, ; 150
	i32 88, ; 151
	i32 40, ; 152
	i32 92, ; 153
	i32 84, ; 154
	i32 28, ; 155
	i32 54, ; 156
	i32 72, ; 157
	i32 29, ; 158
	i32 18, ; 159
	i32 58, ; 160
	i32 92, ; 161
	i32 9, ; 162
	i32 57, ; 163
	i32 44, ; 164
	i32 5, ; 165
	i32 36, ; 166
	i32 37, ; 167
	i32 79, ; 168
	i32 66, ; 169
	i32 73, ; 170
	i32 1, ; 171
	i32 65, ; 172
	i32 35, ; 173
	i32 12, ; 174
	i32 7, ; 175
	i32 55, ; 176
	i32 70, ; 177
	i32 83, ; 178
	i32 48, ; 179
	i32 69, ; 180
	i32 43, ; 181
	i32 76, ; 182
	i32 64, ; 183
	i32 44, ; 184
	i32 74 ; 185
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}

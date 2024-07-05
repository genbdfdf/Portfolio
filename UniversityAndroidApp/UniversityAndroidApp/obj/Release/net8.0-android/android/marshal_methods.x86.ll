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
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 59
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 58
	i32 42639949, ; 2: System.Threading.Thread => 0x28aa24d => 82
	i32 57263871, ; 3: Xamarin.Forms.Core.dll => 0x369c6ff => 28
	i32 66541672, ; 4: System.Diagnostics.StackTrace => 0x3f75868 => 46
	i32 117431740, ; 5: System.Runtime.InteropServices => 0x6ffddbc => 73
	i32 122350210, ; 6: System.Threading.Channels.dll => 0x74aea82 => 81
	i32 142721839, ; 7: System.Net.WebHeaderCollection => 0x881c32f => 66
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 24
	i32 205061960, ; 9: System.ComponentModel => 0xc38ff48 => 42
	i32 209399409, ; 10: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 10
	i32 318968648, ; 11: Xamarin.AndroidX.Activity.dll => 0x13031348 => 7
	i32 321597661, ; 12: System.Numerics => 0x132b30dd => 67
	i32 342366114, ; 13: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 18
	i32 347068432, ; 14: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 5
	i32 375677976, ; 15: System.Net.ServicePoint.dll => 0x16646418 => 63
	i32 379916513, ; 16: System.Threading.Thread.dll => 0x16a510e1 => 82
	i32 385762202, ; 17: System.Memory.dll => 0x16fe439a => 56
	i32 395744057, ; 18: _Microsoft.Android.Resource.Designer => 0x17969339 => 0
	i32 442521989, ; 19: Xamarin.Essentials => 0x1a605985 => 26
	i32 442565967, ; 20: System.Collections => 0x1a61054f => 39
	i32 450948140, ; 21: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 16
	i32 459347974, ; 22: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 76
	i32 465846621, ; 23: mscorlib => 0x1bc4415d => 87
	i32 469710990, ; 24: System.dll => 0x1bff388e => 86
	i32 498788369, ; 25: System.ObjectModel => 0x1dbae811 => 68
	i32 601371474, ; 26: System.IO.IsolatedStorage.dll => 0x23d83352 => 53
	i32 672442732, ; 27: System.Collections.Concurrent => 0x2814a96c => 36
	i32 683518922, ; 28: System.Net.Security => 0x28bdabca => 62
	i32 690569205, ; 29: System.Xml.Linq.dll => 0x29293ff5 => 84
	i32 748832960, ; 30: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 2
	i32 759454413, ; 31: System.Net.Requests => 0x2d445acd => 61
	i32 775507847, ; 32: System.IO.Compression => 0x2e394f87 => 52
	i32 823281589, ; 33: System.Private.Uri.dll => 0x311247b5 => 70
	i32 830298997, ; 34: System.IO.Compression.Brotli => 0x317d5b75 => 51
	i32 904024072, ; 35: System.ComponentModel.Primitives.dll => 0x35e25008 => 40
	i32 952358589, ; 36: SQLitePCLRaw.nativelibrary => 0x38c3d6bd => 3
	i32 967690846, ; 37: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 18
	i32 974778368, ; 38: FormsViewGroup.dll => 0x3a19f000 => 27
	i32 986514023, ; 39: System.Private.DataContractSerialization.dll => 0x3acd0267 => 69
	i32 992768348, ; 40: System.Collections.dll => 0x3b2c715c => 39
	i32 1012816738, ; 41: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 23
	i32 1019214401, ; 42: System.Drawing => 0x3cbffa41 => 49
	i32 1035644815, ; 43: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 8
	i32 1036536393, ; 44: System.Drawing.Primitives.dll => 0x3dc84a49 => 48
	i32 1042160112, ; 45: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 30
	i32 1044663988, ; 46: System.Linq.Expressions.dll => 0x3e444eb4 => 54
	i32 1052210849, ; 47: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 20
	i32 1082857460, ; 48: System.ComponentModel.TypeConverter => 0x408b17f4 => 41
	i32 1084122840, ; 49: Xamarin.Kotlin.StdLib => 0x409e66d8 => 33
	i32 1098259244, ; 50: System => 0x41761b2c => 86
	i32 1219128291, ; 51: System.IO.IsolatedStorage => 0x48aa6be3 => 53
	i32 1292207520, ; 52: SQLitePCLRaw.core.dll => 0x4d0585a0 => 4
	i32 1293217323, ; 53: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 15
	i32 1309188875, ; 54: System.Private.DataContractSerialization => 0x4e08a30b => 69
	i32 1324164729, ; 55: System.Linq => 0x4eed2679 => 55
	i32 1376866003, ; 56: Xamarin.AndroidX.SavedState => 0x52114ed3 => 23
	i32 1406073936, ; 57: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 12
	i32 1408764838, ; 58: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 75
	i32 1452070440, ; 59: System.Formats.Asn1.dll => 0x568cd628 => 50
	i32 1458022317, ; 60: System.Net.Security.dll => 0x56e7a7ad => 62
	i32 1460219004, ; 61: Xamarin.Forms.Xaml => 0x57092c7c => 31
	i32 1462112819, ; 62: System.IO.Compression.dll => 0x57261233 => 52
	i32 1469204771, ; 63: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 9
	i32 1480492111, ; 64: System.IO.Compression.Brotli.dll => 0x583e844f => 51
	i32 1543031311, ; 65: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 80
	i32 1592978981, ; 66: System.Runtime.Serialization.dll => 0x5ef2ee25 => 77
	i32 1604827217, ; 67: System.Net.WebClient => 0x5fa7b851 => 65
	i32 1622152042, ; 68: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 21
	i32 1636350590, ; 69: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 14
	i32 1639515021, ; 70: System.Net.Http.dll => 0x61b9038d => 57
	i32 1639986890, ; 71: System.Text.RegularExpressions => 0x61c036ca => 80
	i32 1657153582, ; 72: System.Runtime => 0x62c6282e => 78
	i32 1658251792, ; 73: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 32
	i32 1677501392, ; 74: System.Net.Primitives.dll => 0x63fca3d0 => 60
	i32 1679769178, ; 75: System.Security.Cryptography => 0x641f3e5a => 79
	i32 1711441057, ; 76: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 5
	i32 1729485958, ; 77: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 11
	i32 1763938596, ; 78: System.Diagnostics.TraceSource.dll => 0x69239124 => 47
	i32 1766324549, ; 79: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 24
	i32 1776026572, ; 80: System.Core.dll => 0x69dc03cc => 44
	i32 1780572499, ; 81: Mono.Android.Runtime.dll => 0x6a216153 => 91
	i32 1788241197, ; 82: Xamarin.AndroidX.Fragment => 0x6a96652d => 16
	i32 1808609942, ; 83: Xamarin.AndroidX.Loader => 0x6bcd3296 => 21
	i32 1813058853, ; 84: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 33
	i32 1813201214, ; 85: Xamarin.Google.Android.Material => 0x6c13413e => 32
	i32 1824722060, ; 86: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 75
	i32 1858542181, ; 87: System.Linq.Expressions => 0x6ec71a65 => 54
	i32 1867746548, ; 88: Xamarin.Essentials.dll => 0x6f538cf4 => 26
	i32 1878053835, ; 89: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 31
	i32 1910275211, ; 90: System.Collections.NonGeneric.dll => 0x71dc7c8b => 37
	i32 1922975269, ; 91: UniversityAndroidApp.dll => 0x729e4625 => 35
	i32 1939592360, ; 92: System.Private.Xml.Linq => 0x739bd4a8 => 71
	i32 2019465201, ; 93: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 20
	i32 2045470958, ; 94: System.Private.Xml => 0x79eb68ee => 72
	i32 2055257422, ; 95: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 19
	i32 2070888862, ; 96: System.Diagnostics.TraceSource => 0x7b6f419e => 47
	i32 2079903147, ; 97: System.Runtime.dll => 0x7bf8cdab => 78
	i32 2097448633, ; 98: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 17
	i32 2103459038, ; 99: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 6
	i32 2126786730, ; 100: Xamarin.Forms.Platform.Android => 0x7ec430aa => 29
	i32 2127167465, ; 101: System.Console => 0x7ec9ffe9 => 43
	i32 2142473426, ; 102: System.Collections.Specialized => 0x7fb38cd2 => 38
	i32 2193016926, ; 103: System.ObjectModel.dll => 0x82b6c85e => 68
	i32 2201107256, ; 104: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 34
	i32 2201231467, ; 105: System.Net.Http => 0x8334206b => 57
	i32 2279755925, ; 106: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 22
	i32 2295906218, ; 107: System.Net.Sockets => 0x88d8bfaa => 64
	i32 2305521784, ; 108: System.Private.CoreLib.dll => 0x896b7878 => 89
	i32 2353062107, ; 109: System.Net.Primitives => 0x8c40e0db => 60
	i32 2435356389, ; 110: System.Console.dll => 0x912896e5 => 43
	i32 2458678730, ; 111: System.Net.Sockets.dll => 0x928c75ca => 64
	i32 2465273461, ; 112: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 2
	i32 2471841756, ; 113: netstandard.dll => 0x93554fdc => 88
	i32 2475788418, ; 114: Java.Interop.dll => 0x93918882 => 90
	i32 2484371297, ; 115: System.Net.ServicePoint => 0x94147f61 => 63
	i32 2605712449, ; 116: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 34
	i32 2617129537, ; 117: System.Private.Xml.dll => 0x9bfe3a41 => 72
	i32 2620871830, ; 118: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 14
	i32 2665622720, ; 119: System.Drawing.Primitives => 0x9ee22cc0 => 48
	i32 2720934335, ; 120: UniversityAndroidApp => 0xa22e29bf => 35
	i32 2724373263, ; 121: System.Runtime.Numerics.dll => 0xa262a30f => 74
	i32 2732626843, ; 122: Xamarin.AndroidX.Activity => 0xa2e0939b => 7
	i32 2735172069, ; 123: System.Threading.Channels => 0xa30769e5 => 81
	i32 2737747696, ; 124: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 9
	i32 2754540824, ; 125: SQLitePCLRaw.nativelibrary.dll => 0xa42ef518 => 3
	i32 2766581644, ; 126: Xamarin.Forms.Core => 0xa4e6af8c => 28
	i32 2778768386, ; 127: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 25
	i32 2810250172, ; 128: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 12
	i32 2819470561, ; 129: System.Xml.dll => 0xa80db4e1 => 85
	i32 2853208004, ; 130: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 25
	i32 2905242038, ; 131: mscorlib.dll => 0xad2a79b6 => 87
	i32 2909740682, ; 132: System.Private.CoreLib => 0xad6f1e8a => 89
	i32 2940926066, ; 133: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 46
	i32 2959614098, ; 134: System.ComponentModel.dll => 0xb0682092 => 42
	i32 2978675010, ; 135: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 15
	i32 3038032645, ; 136: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 0
	i32 3044182254, ; 137: FormsViewGroup => 0xb57288ee => 27
	i32 3059408633, ; 138: Mono.Android.Runtime => 0xb65adef9 => 91
	i32 3059793426, ; 139: System.ComponentModel.Primitives => 0xb660be12 => 40
	i32 3103600923, ; 140: System.Formats.Asn1 => 0xb8fd311b => 50
	i32 3111772706, ; 141: System.Runtime.Serialization => 0xb979e222 => 77
	i32 3220365878, ; 142: System.Threading => 0xbff2e236 => 83
	i32 3258312781, ; 143: Xamarin.AndroidX.CardView => 0xc235e84d => 11
	i32 3286872994, ; 144: SQLite-net.dll => 0xc3e9b3a2 => 1
	i32 3316684772, ; 145: System.Net.Requests.dll => 0xc5b097e4 => 61
	i32 3353484488, ; 146: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 17
	i32 3360279109, ; 147: SQLitePCLRaw.core => 0xc849ca45 => 4
	i32 3362522851, ; 148: Xamarin.AndroidX.Core => 0xc86c06e3 => 13
	i32 3366347497, ; 149: Java.Interop => 0xc8a662e9 => 90
	i32 3374999561, ; 150: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 22
	i32 3429136800, ; 151: System.Xml => 0xcc6479a0 => 85
	i32 3430777524, ; 152: netstandard => 0xcc7d82b4 => 88
	i32 3471940407, ; 153: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 41
	i32 3476120550, ; 154: Mono.Android => 0xcf3163e6 => 92
	i32 3509114376, ; 155: System.Xml.Linq => 0xd128d608 => 84
	i32 3536029504, ; 156: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 29
	i32 3608519521, ; 157: System.Linq.dll => 0xd715a361 => 55
	i32 3632359727, ; 158: Xamarin.Forms.Platform => 0xd881692f => 30
	i32 3641597786, ; 159: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 19
	i32 3660523487, ; 160: System.Net.NetworkInformation => 0xda2f27df => 59
	i32 3672681054, ; 161: Mono.Android.dll => 0xdae8aa5e => 92
	i32 3682565725, ; 162: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 10
	i32 3732100267, ; 163: System.Net.NameResolution => 0xde7354ab => 58
	i32 3748608112, ; 164: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 45
	i32 3754567612, ; 165: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 6
	i32 3792276235, ; 166: System.Collections.NonGeneric => 0xe2098b0b => 37
	i32 3802395368, ; 167: System.Collections.Specialized.dll => 0xe2a3f2e8 => 38
	i32 3823082795, ; 168: System.Security.Cryptography.dll => 0xe3df9d2b => 79
	i32 3829621856, ; 169: System.Numerics.dll => 0xe4436460 => 67
	i32 3849253459, ; 170: System.Runtime.InteropServices.dll => 0xe56ef253 => 73
	i32 3876362041, ; 171: SQLite-net => 0xe70c9739 => 1
	i32 3885497537, ; 172: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 66
	i32 3896106733, ; 173: System.Collections.Concurrent.dll => 0xe839deed => 36
	i32 3896760992, ; 174: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 13
	i32 3955647286, ; 175: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 8
	i32 4025784931, ; 176: System.Memory => 0xeff49a63 => 56
	i32 4068434129, ; 177: System.Private.Xml.Linq.dll => 0xf27f60d1 => 71
	i32 4073602200, ; 178: System.Threading.dll => 0xf2ce3c98 => 83
	i32 4099507663, ; 179: System.Drawing.dll => 0xf45985cf => 49
	i32 4100113165, ; 180: System.Private.Uri => 0xf462c30d => 70
	i32 4151237749, ; 181: System.Core => 0xf76edc75 => 44
	i32 4181436372, ; 182: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 76
	i32 4196529839, ; 183: System.Net.WebClient.dll => 0xfa21f6af => 65
	i32 4213026141, ; 184: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 45
	i32 4274976490 ; 185: System.Runtime.Numerics => 0xfecef6ea => 74
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [186 x i32] [
	i32 59, ; 0
	i32 58, ; 1
	i32 82, ; 2
	i32 28, ; 3
	i32 46, ; 4
	i32 73, ; 5
	i32 81, ; 6
	i32 66, ; 7
	i32 24, ; 8
	i32 42, ; 9
	i32 10, ; 10
	i32 7, ; 11
	i32 67, ; 12
	i32 18, ; 13
	i32 5, ; 14
	i32 63, ; 15
	i32 82, ; 16
	i32 56, ; 17
	i32 0, ; 18
	i32 26, ; 19
	i32 39, ; 20
	i32 16, ; 21
	i32 76, ; 22
	i32 87, ; 23
	i32 86, ; 24
	i32 68, ; 25
	i32 53, ; 26
	i32 36, ; 27
	i32 62, ; 28
	i32 84, ; 29
	i32 2, ; 30
	i32 61, ; 31
	i32 52, ; 32
	i32 70, ; 33
	i32 51, ; 34
	i32 40, ; 35
	i32 3, ; 36
	i32 18, ; 37
	i32 27, ; 38
	i32 69, ; 39
	i32 39, ; 40
	i32 23, ; 41
	i32 49, ; 42
	i32 8, ; 43
	i32 48, ; 44
	i32 30, ; 45
	i32 54, ; 46
	i32 20, ; 47
	i32 41, ; 48
	i32 33, ; 49
	i32 86, ; 50
	i32 53, ; 51
	i32 4, ; 52
	i32 15, ; 53
	i32 69, ; 54
	i32 55, ; 55
	i32 23, ; 56
	i32 12, ; 57
	i32 75, ; 58
	i32 50, ; 59
	i32 62, ; 60
	i32 31, ; 61
	i32 52, ; 62
	i32 9, ; 63
	i32 51, ; 64
	i32 80, ; 65
	i32 77, ; 66
	i32 65, ; 67
	i32 21, ; 68
	i32 14, ; 69
	i32 57, ; 70
	i32 80, ; 71
	i32 78, ; 72
	i32 32, ; 73
	i32 60, ; 74
	i32 79, ; 75
	i32 5, ; 76
	i32 11, ; 77
	i32 47, ; 78
	i32 24, ; 79
	i32 44, ; 80
	i32 91, ; 81
	i32 16, ; 82
	i32 21, ; 83
	i32 33, ; 84
	i32 32, ; 85
	i32 75, ; 86
	i32 54, ; 87
	i32 26, ; 88
	i32 31, ; 89
	i32 37, ; 90
	i32 35, ; 91
	i32 71, ; 92
	i32 20, ; 93
	i32 72, ; 94
	i32 19, ; 95
	i32 47, ; 96
	i32 78, ; 97
	i32 17, ; 98
	i32 6, ; 99
	i32 29, ; 100
	i32 43, ; 101
	i32 38, ; 102
	i32 68, ; 103
	i32 34, ; 104
	i32 57, ; 105
	i32 22, ; 106
	i32 64, ; 107
	i32 89, ; 108
	i32 60, ; 109
	i32 43, ; 110
	i32 64, ; 111
	i32 2, ; 112
	i32 88, ; 113
	i32 90, ; 114
	i32 63, ; 115
	i32 34, ; 116
	i32 72, ; 117
	i32 14, ; 118
	i32 48, ; 119
	i32 35, ; 120
	i32 74, ; 121
	i32 7, ; 122
	i32 81, ; 123
	i32 9, ; 124
	i32 3, ; 125
	i32 28, ; 126
	i32 25, ; 127
	i32 12, ; 128
	i32 85, ; 129
	i32 25, ; 130
	i32 87, ; 131
	i32 89, ; 132
	i32 46, ; 133
	i32 42, ; 134
	i32 15, ; 135
	i32 0, ; 136
	i32 27, ; 137
	i32 91, ; 138
	i32 40, ; 139
	i32 50, ; 140
	i32 77, ; 141
	i32 83, ; 142
	i32 11, ; 143
	i32 1, ; 144
	i32 61, ; 145
	i32 17, ; 146
	i32 4, ; 147
	i32 13, ; 148
	i32 90, ; 149
	i32 22, ; 150
	i32 85, ; 151
	i32 88, ; 152
	i32 41, ; 153
	i32 92, ; 154
	i32 84, ; 155
	i32 29, ; 156
	i32 55, ; 157
	i32 30, ; 158
	i32 19, ; 159
	i32 59, ; 160
	i32 92, ; 161
	i32 10, ; 162
	i32 58, ; 163
	i32 45, ; 164
	i32 6, ; 165
	i32 37, ; 166
	i32 38, ; 167
	i32 79, ; 168
	i32 67, ; 169
	i32 73, ; 170
	i32 1, ; 171
	i32 66, ; 172
	i32 36, ; 173
	i32 13, ; 174
	i32 8, ; 175
	i32 56, ; 176
	i32 71, ; 177
	i32 83, ; 178
	i32 49, ; 179
	i32 70, ; 180
	i32 44, ; 181
	i32 76, ; 182
	i32 65, ; 183
	i32 45, ; 184
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

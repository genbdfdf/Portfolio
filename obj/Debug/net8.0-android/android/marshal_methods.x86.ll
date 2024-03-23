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

@assembly_image_cache = dso_local local_unnamed_addr global [259 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [512 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 217
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 249
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 39485524, ; 6: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42639949, ; 7: System.Threading.Thread => 0x28aa24d => 145
	i32 57263871, ; 8: Xamarin.Forms.Core.dll => 0x369c6ff => 244
	i32 66541672, ; 9: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 68219467, ; 10: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 82292897, ; 11: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 101534019, ; 12: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 232
	i32 117431740, ; 13: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 14: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 232
	i32 122350210, ; 15: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 142721839, ; 16: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 17: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 18: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 19: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 193
	i32 176265551, ; 20: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 21: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 234
	i32 184328833, ; 22: System.ValueTuple.dll => 0xafca281 => 151
	i32 205061960, ; 23: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 24: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 191
	i32 220171995, ; 25: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 26: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 211
	i32 230752869, ; 27: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 28: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 29: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 30: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 261689757, ; 31: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 196
	i32 261882112, ; 32: DocumentFormat.OpenXml.Framework.dll => 0xf9c0100 => 174
	i32 276479776, ; 33: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 278686392, ; 34: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 214
	i32 280482487, ; 35: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 209
	i32 291076382, ; 36: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 298918909, ; 37: System.Net.Ping.dll => 0x11d123fd => 69
	i32 318968648, ; 38: Xamarin.AndroidX.Activity.dll => 0x13031348 => 182
	i32 321597661, ; 39: System.Numerics => 0x132b30dd => 83
	i32 342366114, ; 40: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 213
	i32 347068432, ; 41: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 179
	i32 360082299, ; 42: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 43: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 44: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 45: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 46: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 47: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 48: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 49: _Microsoft.Android.Resource.Designer => 0x17969339 => 255
	i32 403441872, ; 50: WindowsBase => 0x180c08d0 => 165
	i32 441335492, ; 51: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 197
	i32 442521989, ; 52: Xamarin.Essentials => 0x1a605985 => 242
	i32 442565967, ; 53: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 54: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 208
	i32 451504562, ; 55: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 56: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 57: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 58: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 59: System.dll => 0x1bff388e => 164
	i32 476646585, ; 60: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 209
	i32 486930444, ; 61: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 221
	i32 498788369, ; 62: System.ObjectModel => 0x1dbae811 => 84
	i32 526420162, ; 63: System.Transactions.dll => 0x1f6088c2 => 150
	i32 530272170, ; 64: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 540030774, ; 65: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 66: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 67: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 68: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 577335427, ; 69: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 601371474, ; 70: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 71: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 72: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 73: Xamarin.AndroidX.CustomView => 0x2568904f => 202
	i32 639843206, ; 74: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 207
	i32 643868501, ; 75: System.Net => 0x2660a755 => 81
	i32 662205335, ; 76: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 77: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 239
	i32 666292255, ; 78: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 188
	i32 672442732, ; 79: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 80: System.Net.Security => 0x28bdabca => 73
	i32 690569205, ; 81: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 82: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 252
	i32 693804605, ; 83: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 84: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 85: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 250
	i32 700358131, ; 86: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 722857257, ; 87: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 735137430, ; 88: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 748832960, ; 89: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 176
	i32 752232764, ; 90: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 759454413, ; 91: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 92: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 93: System.IO.Compression => 0x2e394f87 => 46
	i32 804715423, ; 94: System.Data.Common => 0x2ff6fb9f => 22
	i32 823281589, ; 95: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 96: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 97: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 98: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 99: Xamarin.AndroidX.Print => 0x3246f6cd => 227
	i32 873119928, ; 100: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 101: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 102: System.Net.Http.Json => 0x3463c971 => 63
	i32 904024072, ; 103: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 104: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 928116545, ; 105: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 249
	i32 952186615, ; 106: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 952358589, ; 107: SQLitePCLRaw.nativelibrary => 0x38c3d6bd => 177
	i32 967690846, ; 108: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 213
	i32 974778368, ; 109: FormsViewGroup.dll => 0x3a19f000 => 243
	i32 975236339, ; 110: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 111: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 112: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 113: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 992768348, ; 114: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 115: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 1001831731, ; 116: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 117: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 231
	i32 1019214401, ; 118: System.Drawing => 0x3cbffa41 => 36
	i32 1035644815, ; 119: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 186
	i32 1036536393, ; 120: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1042160112, ; 121: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 246
	i32 1044663988, ; 122: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1052210849, ; 123: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 218
	i32 1082857460, ; 124: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1083751839, ; 125: System.IO.Packaging => 0x4098bd9f => 181
	i32 1084122840, ; 126: Xamarin.Kotlin.StdLib => 0x409e66d8 => 251
	i32 1098259244, ; 127: System => 0x41761b2c => 164
	i32 1170634674, ; 128: System.Web.dll => 0x45c677b2 => 153
	i32 1175144683, ; 129: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 238
	i32 1178241025, ; 130: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 224
	i32 1204270330, ; 131: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 188
	i32 1208641965, ; 132: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1219128291, ; 133: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1246548578, ; 134: Xamarin.AndroidX.Collection.Jvm.dll => 0x4a4cd262 => 194
	i32 1253011324, ; 135: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1264511973, ; 136: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 233
	i32 1264890200, ; 137: Xamarin.KotlinX.Coroutines.Core.dll => 0x4b64b158 => 253
	i32 1267360935, ; 138: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 237
	i32 1275534314, ; 139: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 252
	i32 1278448581, ; 140: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 185
	i32 1292207520, ; 141: SQLitePCLRaw.core.dll => 0x4d0585a0 => 178
	i32 1292843635, ; 142: DocumentFormat.OpenXml.Framework => 0x4d0f3a73 => 174
	i32 1293217323, ; 143: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 204
	i32 1309188875, ; 144: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1324164729, ; 145: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 146: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1338781641, ; 147: DocumentFormat.OpenXml.dll => 0x4fcc2fc9 => 173
	i32 1364015309, ; 148: System.IO => 0x514d38cd => 57
	i32 1376866003, ; 149: Xamarin.AndroidX.SavedState => 0x52114ed3 => 231
	i32 1379779777, ; 150: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1395857551, ; 151: Xamarin.AndroidX.Media.dll => 0x5333188f => 222
	i32 1402170036, ; 152: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 153: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 198
	i32 1408764838, ; 154: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 155: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 156: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1434145427, ; 157: System.Runtime.Handles => 0x557b5293 => 104
	i32 1439761251, ; 158: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 159: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 160: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 161: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 162: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1460219004, ; 163: Xamarin.Forms.Xaml => 0x57092c7c => 247
	i32 1461234159, ; 164: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 165: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 166: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 167: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 187
	i32 1479771757, ; 168: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 169: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 170: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1536373174, ; 171: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 172: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 173: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 174: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1565862583, ; 175: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 176: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 177: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 178: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 179: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 203
	i32 1592978981, ; 180: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1601112923, ; 181: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 182: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 183: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 184: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 220
	i32 1622358360, ; 185: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 186: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 241
	i32 1635184631, ; 187: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 207
	i32 1636350590, ; 188: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 201
	i32 1639515021, ; 189: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 190: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 191: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 192: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 193: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 235
	i32 1658251792, ; 194: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 248
	i32 1670060433, ; 195: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 196
	i32 1675553242, ; 196: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 197: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 198: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 199: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 200: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 201: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1701541528, ; 202: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1711441057, ; 203: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 179
	i32 1726116996, ; 204: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 205: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 206: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 192
	i32 1744735666, ; 207: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 208: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 209: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 210: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 211: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 212: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 213: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 234
	i32 1776026572, ; 214: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 215: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 216: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1788241197, ; 217: Xamarin.AndroidX.Fragment => 0x6a96652d => 208
	i32 1808609942, ; 218: Xamarin.AndroidX.Loader => 0x6bcd3296 => 220
	i32 1813058853, ; 219: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 251
	i32 1813201214, ; 220: Xamarin.Google.Android.Material => 0x6c13413e => 248
	i32 1818569960, ; 221: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 225
	i32 1818787751, ; 222: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 223: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 224: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1858542181, ; 225: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1867746548, ; 226: Xamarin.Essentials.dll => 0x6f538cf4 => 242
	i32 1870277092, ; 227: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1878053835, ; 228: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 247
	i32 1879696579, ; 229: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 230: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 189
	i32 1888955245, ; 231: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 232: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1898237753, ; 233: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 234: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 235: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1922975269, ; 236: UniversityAndroidApp.dll => 0x729e4625 => 0
	i32 1939592360, ; 237: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1956758971, ; 238: System.Resources.Writer => 0x74a1c5bb => 100
	i32 2011961780, ; 239: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 240: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 218
	i32 2045470958, ; 241: System.Private.Xml => 0x79eb68ee => 88
	i32 2055257422, ; 242: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 215
	i32 2060060697, ; 243: System.Windows.dll => 0x7aca0819 => 154
	i32 2070888862, ; 244: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 245: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 246: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2097448633, ; 247: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 210
	i32 2103459038, ; 248: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 180
	i32 2126786730, ; 249: Xamarin.Forms.Platform.Android => 0x7ec430aa => 245
	i32 2127167465, ; 250: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 251: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 252: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 253: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2193016926, ; 254: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 255: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 254
	i32 2201231467, ; 256: System.Net.Http => 0x8334206b => 64
	i32 2217644978, ; 257: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 238
	i32 2222056684, ; 258: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2244775296, ; 259: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 221
	i32 2252106437, ; 260: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 261: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2261435625, ; 262: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 212
	i32 2265110946, ; 263: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2279755925, ; 264: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 229
	i32 2293034957, ; 265: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 266: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 267: System.Net.Mail => 0x88ffe49e => 66
	i32 2305521784, ; 268: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 269: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 183
	i32 2320631194, ; 270: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 271: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 272: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 273: System.Net.Primitives => 0x8c40e0db => 70
	i32 2368005991, ; 274: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2378619854, ; 275: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 276: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2401565422, ; 277: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 278: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 206
	i32 2409053734, ; 279: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 226
	i32 2421380589, ; 280: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2435356389, ; 281: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 282: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 283: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 284: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 285: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465273461, ; 286: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 176
	i32 2465532216, ; 287: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 197
	i32 2471841756, ; 288: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 289: Java.Interop.dll => 0x93918882 => 168
	i32 2483903535, ; 290: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 291: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 292: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 293: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 294: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 217
	i32 2538310050, ; 295: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2562349572, ; 296: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 297: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2581819634, ; 298: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 237
	i32 2585220780, ; 299: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 300: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 301: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2605712449, ; 302: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 254
	i32 2617129537, ; 303: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 304: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 305: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 201
	i32 2624644809, ; 306: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 205
	i32 2627185994, ; 307: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 308: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 309: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 214
	i32 2663698177, ; 310: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 311: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 312: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2671474046, ; 313: Xamarin.KotlinX.Coroutines.Core => 0x9f3b757e => 253
	i32 2676780864, ; 314: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 315: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 316: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 317: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 235
	i32 2715334215, ; 318: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 319: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 320: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2720934335, ; 321: UniversityAndroidApp => 0xa22e29bf => 0
	i32 2724373263, ; 322: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 323: Xamarin.AndroidX.Activity => 0xa2e0939b => 182
	i32 2735172069, ; 324: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 325: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 187
	i32 2740948882, ; 326: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 327: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2754540824, ; 328: SQLitePCLRaw.nativelibrary.dll => 0xa42ef518 => 177
	i32 2765824710, ; 329: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2766581644, ; 330: Xamarin.Forms.Core => 0xa4e6af8c => 244
	i32 2770495804, ; 331: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 250
	i32 2778768386, ; 332: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 240
	i32 2779977773, ; 333: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 230
	i32 2803228030, ; 334: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2810250172, ; 335: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 198
	i32 2819470561, ; 336: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 337: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 338: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 230
	i32 2824502124, ; 339: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2849599387, ; 340: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 341: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 240
	i32 2855708567, ; 342: Xamarin.AndroidX.Transition => 0xaa36a797 => 236
	i32 2861098320, ; 343: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2875220617, ; 344: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2887636118, ; 345: System.Net.dll => 0xac1dd496 => 81
	i32 2899753641, ; 346: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 347: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 348: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 349: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 350: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2916838712, ; 351: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 241
	i32 2919462931, ; 352: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 353: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 184
	i32 2936416060, ; 354: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 355: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 356: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 357: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 358: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2972252294, ; 359: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 360: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 204
	i32 2996846495, ; 361: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 216
	i32 3016983068, ; 362: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 233
	i32 3023353419, ; 363: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 364: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 211
	i32 3038032645, ; 365: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 255
	i32 3044182254, ; 366: FormsViewGroup => 0xb57288ee => 243
	i32 3057625584, ; 367: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 223
	i32 3059408633, ; 368: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 369: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 370: System.Threading.Tasks => 0xb755818f => 144
	i32 3090735792, ; 371: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 372: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 373: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 374: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 375: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 376: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 377: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 378: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3159123045, ; 379: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 380: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3192346100, ; 381: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 382: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 383: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 384: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 385: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 203
	i32 3220365878, ; 386: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 387: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3251039220, ; 388: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 389: Xamarin.AndroidX.CardView => 0xc235e84d => 192
	i32 3265493905, ; 390: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 391: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3267021929, ; 392: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 190
	i32 3277815716, ; 393: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 394: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 395: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3286872994, ; 396: SQLite-net.dll => 0xc3e9b3a2 => 175
	i32 3290767353, ; 397: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 398: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 399: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3316684772, ; 400: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 401: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 202
	i32 3317144872, ; 402: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 403: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 189
	i32 3345895724, ; 404: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 228
	i32 3346324047, ; 405: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 224
	i32 3353484488, ; 406: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 210
	i32 3358260929, ; 407: System.Text.Json => 0xc82afec1 => 137
	i32 3360279109, ; 408: SQLitePCLRaw.core => 0xc849ca45 => 178
	i32 3362522851, ; 409: Xamarin.AndroidX.Core => 0xc86c06e3 => 199
	i32 3366347497, ; 410: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 411: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 229
	i32 3395150330, ; 412: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 413: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3429136800, ; 414: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 415: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 416: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 205
	i32 3445260447, ; 417: System.Formats.Tar => 0xcd5a809f => 39
	i32 3471940407, ; 418: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 419: Mono.Android => 0xcf3163e6 => 171
	i32 3485117614, ; 420: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 421: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 422: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 195
	i32 3501239056, ; 423: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 190
	i32 3509114376, ; 424: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 425: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 426: System.Configuration => 0xd2757232 => 19
	i32 3536029504, ; 427: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 245
	i32 3539954161, ; 428: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3560100363, ; 429: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 430: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3598340787, ; 431: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 432: System.Linq.dll => 0xd715a361 => 61
	i32 3618140916, ; 433: Xamarin.AndroidX.Preference => 0xd7a872f4 => 226
	i32 3624195450, ; 434: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 435: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 227
	i32 3632359727, ; 436: Xamarin.Forms.Platform => 0xd881692f => 246
	i32 3633644679, ; 437: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 184
	i32 3638274909, ; 438: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 439: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 215
	i32 3645089577, ; 440: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3660523487, ; 441: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 442: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 443: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 191
	i32 3684561358, ; 444: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 195
	i32 3700866549, ; 445: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 446: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 200
	i32 3716563718, ; 447: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 448: Xamarin.AndroidX.Annotation => 0xdda814c6 => 183
	i32 3724971120, ; 449: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 223
	i32 3732100267, ; 450: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 451: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 452: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 453: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3754567612, ; 454: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 180
	i32 3758932259, ; 455: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 212
	i32 3786282454, ; 456: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 193
	i32 3792276235, ; 457: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3802395368, ; 458: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 459: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3822443793, ; 460: DocumentFormat.OpenXml => 0xe3d5dd11 => 173
	i32 3822602673, ; 461: Xamarin.AndroidX.Media => 0xe3d849b1 => 222
	i32 3823082795, ; 462: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 463: System.Numerics.dll => 0xe4436460 => 83
	i32 3844307129, ; 464: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 465: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 466: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 467: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 468: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3876362041, ; 469: SQLite-net => 0xe70c9739 => 175
	i32 3885497537, ; 470: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 471: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 236
	i32 3888767677, ; 472: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 228
	i32 3896106733, ; 473: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 474: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 199
	i32 3901907137, ; 475: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3910130544, ; 476: Xamarin.AndroidX.Collection.Jvm => 0xe90fdb70 => 194
	i32 3920810846, ; 477: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 478: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 239
	i32 3928044579, ; 479: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 480: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 481: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 225
	i32 3945713374, ; 482: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3952357212, ; 483: System.IO.Packaging.dll => 0xeb942f5c => 181
	i32 3953953790, ; 484: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 485: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 186
	i32 3959773229, ; 486: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 216
	i32 4003436829, ; 487: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 488: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 185
	i32 4025784931, ; 489: System.Memory => 0xeff49a63 => 62
	i32 4054681211, ; 490: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 491: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 492: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4099507663, ; 493: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 494: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 495: Xamarin.AndroidX.Emoji2 => 0xf479582c => 206
	i32 4127667938, ; 496: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 497: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 498: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4151237749, ; 499: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 500: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 501: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 502: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 503: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 504: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 219
	i32 4185676441, ; 505: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 506: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 507: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4256097574, ; 508: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 200
	i32 4260525087, ; 509: System.Buffers => 0xfdf2741f => 7
	i32 4274976490, ; 510: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959 ; 511: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 219
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [512 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 217, ; 3
	i32 249, ; 4
	i32 48, ; 5
	i32 80, ; 6
	i32 145, ; 7
	i32 244, ; 8
	i32 30, ; 9
	i32 124, ; 10
	i32 102, ; 11
	i32 232, ; 12
	i32 107, ; 13
	i32 232, ; 14
	i32 139, ; 15
	i32 77, ; 16
	i32 124, ; 17
	i32 13, ; 18
	i32 193, ; 19
	i32 132, ; 20
	i32 234, ; 21
	i32 151, ; 22
	i32 18, ; 23
	i32 191, ; 24
	i32 26, ; 25
	i32 211, ; 26
	i32 1, ; 27
	i32 59, ; 28
	i32 42, ; 29
	i32 91, ; 30
	i32 196, ; 31
	i32 174, ; 32
	i32 147, ; 33
	i32 214, ; 34
	i32 209, ; 35
	i32 54, ; 36
	i32 69, ; 37
	i32 182, ; 38
	i32 83, ; 39
	i32 213, ; 40
	i32 179, ; 41
	i32 131, ; 42
	i32 55, ; 43
	i32 149, ; 44
	i32 74, ; 45
	i32 145, ; 46
	i32 62, ; 47
	i32 146, ; 48
	i32 255, ; 49
	i32 165, ; 50
	i32 197, ; 51
	i32 242, ; 52
	i32 12, ; 53
	i32 208, ; 54
	i32 125, ; 55
	i32 152, ; 56
	i32 113, ; 57
	i32 166, ; 58
	i32 164, ; 59
	i32 209, ; 60
	i32 221, ; 61
	i32 84, ; 62
	i32 150, ; 63
	i32 60, ; 64
	i32 51, ; 65
	i32 103, ; 66
	i32 114, ; 67
	i32 40, ; 68
	i32 120, ; 69
	i32 52, ; 70
	i32 44, ; 71
	i32 119, ; 72
	i32 202, ; 73
	i32 207, ; 74
	i32 81, ; 75
	i32 136, ; 76
	i32 239, ; 77
	i32 188, ; 78
	i32 8, ; 79
	i32 73, ; 80
	i32 155, ; 81
	i32 252, ; 82
	i32 154, ; 83
	i32 92, ; 84
	i32 250, ; 85
	i32 45, ; 86
	i32 109, ; 87
	i32 129, ; 88
	i32 176, ; 89
	i32 25, ; 90
	i32 72, ; 91
	i32 55, ; 92
	i32 46, ; 93
	i32 22, ; 94
	i32 86, ; 95
	i32 43, ; 96
	i32 160, ; 97
	i32 71, ; 98
	i32 227, ; 99
	i32 3, ; 100
	i32 42, ; 101
	i32 63, ; 102
	i32 16, ; 103
	i32 53, ; 104
	i32 249, ; 105
	i32 105, ; 106
	i32 177, ; 107
	i32 213, ; 108
	i32 243, ; 109
	i32 34, ; 110
	i32 158, ; 111
	i32 85, ; 112
	i32 32, ; 113
	i32 12, ; 114
	i32 51, ; 115
	i32 56, ; 116
	i32 231, ; 117
	i32 36, ; 118
	i32 186, ; 119
	i32 35, ; 120
	i32 246, ; 121
	i32 58, ; 122
	i32 218, ; 123
	i32 17, ; 124
	i32 181, ; 125
	i32 251, ; 126
	i32 164, ; 127
	i32 153, ; 128
	i32 238, ; 129
	i32 224, ; 130
	i32 188, ; 131
	i32 29, ; 132
	i32 52, ; 133
	i32 194, ; 134
	i32 5, ; 135
	i32 233, ; 136
	i32 253, ; 137
	i32 237, ; 138
	i32 252, ; 139
	i32 185, ; 140
	i32 178, ; 141
	i32 174, ; 142
	i32 204, ; 143
	i32 85, ; 144
	i32 61, ; 145
	i32 112, ; 146
	i32 173, ; 147
	i32 57, ; 148
	i32 231, ; 149
	i32 99, ; 150
	i32 222, ; 151
	i32 19, ; 152
	i32 198, ; 153
	i32 111, ; 154
	i32 101, ; 155
	i32 102, ; 156
	i32 104, ; 157
	i32 71, ; 158
	i32 38, ; 159
	i32 32, ; 160
	i32 103, ; 161
	i32 73, ; 162
	i32 247, ; 163
	i32 9, ; 164
	i32 123, ; 165
	i32 46, ; 166
	i32 187, ; 167
	i32 9, ; 168
	i32 43, ; 169
	i32 4, ; 170
	i32 31, ; 171
	i32 138, ; 172
	i32 92, ; 173
	i32 93, ; 174
	i32 49, ; 175
	i32 141, ; 176
	i32 112, ; 177
	i32 140, ; 178
	i32 203, ; 179
	i32 115, ; 180
	i32 157, ; 181
	i32 76, ; 182
	i32 79, ; 183
	i32 220, ; 184
	i32 37, ; 185
	i32 241, ; 186
	i32 207, ; 187
	i32 201, ; 188
	i32 64, ; 189
	i32 138, ; 190
	i32 15, ; 191
	i32 116, ; 192
	i32 235, ; 193
	i32 248, ; 194
	i32 196, ; 195
	i32 48, ; 196
	i32 70, ; 197
	i32 80, ; 198
	i32 126, ; 199
	i32 94, ; 200
	i32 121, ; 201
	i32 26, ; 202
	i32 179, ; 203
	i32 97, ; 204
	i32 28, ; 205
	i32 192, ; 206
	i32 149, ; 207
	i32 169, ; 208
	i32 4, ; 209
	i32 98, ; 210
	i32 33, ; 211
	i32 93, ; 212
	i32 234, ; 213
	i32 21, ; 214
	i32 41, ; 215
	i32 170, ; 216
	i32 208, ; 217
	i32 220, ; 218
	i32 251, ; 219
	i32 248, ; 220
	i32 225, ; 221
	i32 2, ; 222
	i32 134, ; 223
	i32 111, ; 224
	i32 58, ; 225
	i32 242, ; 226
	i32 95, ; 227
	i32 247, ; 228
	i32 39, ; 229
	i32 189, ; 230
	i32 25, ; 231
	i32 94, ; 232
	i32 89, ; 233
	i32 99, ; 234
	i32 10, ; 235
	i32 0, ; 236
	i32 87, ; 237
	i32 100, ; 238
	i32 7, ; 239
	i32 218, ; 240
	i32 88, ; 241
	i32 215, ; 242
	i32 154, ; 243
	i32 33, ; 244
	i32 116, ; 245
	i32 82, ; 246
	i32 210, ; 247
	i32 180, ; 248
	i32 245, ; 249
	i32 20, ; 250
	i32 11, ; 251
	i32 162, ; 252
	i32 3, ; 253
	i32 84, ; 254
	i32 254, ; 255
	i32 64, ; 256
	i32 238, ; 257
	i32 143, ; 258
	i32 221, ; 259
	i32 157, ; 260
	i32 41, ; 261
	i32 212, ; 262
	i32 117, ; 263
	i32 229, ; 264
	i32 131, ; 265
	i32 75, ; 266
	i32 66, ; 267
	i32 172, ; 268
	i32 183, ; 269
	i32 143, ; 270
	i32 106, ; 271
	i32 151, ; 272
	i32 70, ; 273
	i32 156, ; 274
	i32 121, ; 275
	i32 127, ; 276
	i32 152, ; 277
	i32 206, ; 278
	i32 226, ; 279
	i32 141, ; 280
	i32 20, ; 281
	i32 14, ; 282
	i32 135, ; 283
	i32 75, ; 284
	i32 59, ; 285
	i32 176, ; 286
	i32 197, ; 287
	i32 167, ; 288
	i32 168, ; 289
	i32 15, ; 290
	i32 74, ; 291
	i32 6, ; 292
	i32 23, ; 293
	i32 217, ; 294
	i32 91, ; 295
	i32 1, ; 296
	i32 136, ; 297
	i32 237, ; 298
	i32 134, ; 299
	i32 69, ; 300
	i32 146, ; 301
	i32 254, ; 302
	i32 88, ; 303
	i32 96, ; 304
	i32 201, ; 305
	i32 205, ; 306
	i32 31, ; 307
	i32 45, ; 308
	i32 214, ; 309
	i32 109, ; 310
	i32 158, ; 311
	i32 35, ; 312
	i32 253, ; 313
	i32 22, ; 314
	i32 114, ; 315
	i32 57, ; 316
	i32 235, ; 317
	i32 144, ; 318
	i32 118, ; 319
	i32 120, ; 320
	i32 0, ; 321
	i32 110, ; 322
	i32 182, ; 323
	i32 139, ; 324
	i32 187, ; 325
	i32 54, ; 326
	i32 105, ; 327
	i32 177, ; 328
	i32 133, ; 329
	i32 244, ; 330
	i32 250, ; 331
	i32 240, ; 332
	i32 230, ; 333
	i32 159, ; 334
	i32 198, ; 335
	i32 163, ; 336
	i32 132, ; 337
	i32 230, ; 338
	i32 161, ; 339
	i32 140, ; 340
	i32 240, ; 341
	i32 236, ; 342
	i32 169, ; 343
	i32 40, ; 344
	i32 81, ; 345
	i32 56, ; 346
	i32 37, ; 347
	i32 97, ; 348
	i32 166, ; 349
	i32 172, ; 350
	i32 241, ; 351
	i32 82, ; 352
	i32 184, ; 353
	i32 98, ; 354
	i32 30, ; 355
	i32 159, ; 356
	i32 18, ; 357
	i32 127, ; 358
	i32 119, ; 359
	i32 204, ; 360
	i32 216, ; 361
	i32 233, ; 362
	i32 165, ; 363
	i32 211, ; 364
	i32 255, ; 365
	i32 243, ; 366
	i32 223, ; 367
	i32 170, ; 368
	i32 16, ; 369
	i32 144, ; 370
	i32 125, ; 371
	i32 118, ; 372
	i32 38, ; 373
	i32 115, ; 374
	i32 47, ; 375
	i32 142, ; 376
	i32 117, ; 377
	i32 34, ; 378
	i32 95, ; 379
	i32 53, ; 380
	i32 129, ; 381
	i32 153, ; 382
	i32 24, ; 383
	i32 161, ; 384
	i32 203, ; 385
	i32 148, ; 386
	i32 104, ; 387
	i32 89, ; 388
	i32 192, ; 389
	i32 60, ; 390
	i32 142, ; 391
	i32 190, ; 392
	i32 100, ; 393
	i32 5, ; 394
	i32 13, ; 395
	i32 175, ; 396
	i32 122, ; 397
	i32 135, ; 398
	i32 28, ; 399
	i32 72, ; 400
	i32 202, ; 401
	i32 24, ; 402
	i32 189, ; 403
	i32 228, ; 404
	i32 224, ; 405
	i32 210, ; 406
	i32 137, ; 407
	i32 178, ; 408
	i32 199, ; 409
	i32 168, ; 410
	i32 229, ; 411
	i32 101, ; 412
	i32 123, ; 413
	i32 163, ; 414
	i32 167, ; 415
	i32 205, ; 416
	i32 39, ; 417
	i32 17, ; 418
	i32 171, ; 419
	i32 137, ; 420
	i32 150, ; 421
	i32 195, ; 422
	i32 190, ; 423
	i32 155, ; 424
	i32 130, ; 425
	i32 19, ; 426
	i32 245, ; 427
	i32 65, ; 428
	i32 147, ; 429
	i32 47, ; 430
	i32 79, ; 431
	i32 61, ; 432
	i32 226, ; 433
	i32 106, ; 434
	i32 227, ; 435
	i32 246, ; 436
	i32 184, ; 437
	i32 49, ; 438
	i32 215, ; 439
	i32 14, ; 440
	i32 68, ; 441
	i32 171, ; 442
	i32 191, ; 443
	i32 195, ; 444
	i32 78, ; 445
	i32 200, ; 446
	i32 108, ; 447
	i32 183, ; 448
	i32 223, ; 449
	i32 67, ; 450
	i32 63, ; 451
	i32 27, ; 452
	i32 160, ; 453
	i32 180, ; 454
	i32 212, ; 455
	i32 193, ; 456
	i32 10, ; 457
	i32 11, ; 458
	i32 78, ; 459
	i32 173, ; 460
	i32 222, ; 461
	i32 126, ; 462
	i32 83, ; 463
	i32 66, ; 464
	i32 107, ; 465
	i32 65, ; 466
	i32 128, ; 467
	i32 122, ; 468
	i32 175, ; 469
	i32 77, ; 470
	i32 236, ; 471
	i32 228, ; 472
	i32 8, ; 473
	i32 199, ; 474
	i32 2, ; 475
	i32 194, ; 476
	i32 44, ; 477
	i32 239, ; 478
	i32 156, ; 479
	i32 128, ; 480
	i32 225, ; 481
	i32 23, ; 482
	i32 181, ; 483
	i32 133, ; 484
	i32 186, ; 485
	i32 216, ; 486
	i32 29, ; 487
	i32 185, ; 488
	i32 62, ; 489
	i32 90, ; 490
	i32 87, ; 491
	i32 148, ; 492
	i32 36, ; 493
	i32 86, ; 494
	i32 206, ; 495
	i32 50, ; 496
	i32 6, ; 497
	i32 90, ; 498
	i32 21, ; 499
	i32 162, ; 500
	i32 96, ; 501
	i32 50, ; 502
	i32 113, ; 503
	i32 219, ; 504
	i32 130, ; 505
	i32 76, ; 506
	i32 27, ; 507
	i32 200, ; 508
	i32 7, ; 509
	i32 110, ; 510
	i32 219 ; 511
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
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ f1b7113872c8db3dfee70d11925e81bb752dc8d0"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}

; ModuleID = 'marshal_methods.x86_64.ll'
source_filename = "marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [259 x ptr] zeroinitializer, align 16

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [512 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 205
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 171
	i64 196720943101637631, ; 2: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 58
	i64 210515253464952879, ; 3: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 193
	i64 229794953483747371, ; 4: System.ValueTuple.dll => 0x330654aed93802b => 151
	i64 232391251801502327, ; 5: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 231
	i64 233177144301842968, ; 6: Xamarin.AndroidX.Collection.Jvm.dll => 0x33c696097d9f218 => 194
	i64 295915112840604065, ; 7: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 232
	i64 316157742385208084, ; 8: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 200
	i64 350667413455104241, ; 9: System.ServiceProcess.dll => 0x4ddd227954be8f1 => 132
	i64 422779754995088667, ; 10: System.IO.UnmanagedMemoryStream => 0x5de03f27ab57d1b => 56
	i64 560278790331054453, ; 11: System.Reflection.Primitives => 0x7c6829760de3975 => 95
	i64 634308326490598313, ; 12: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 217
	i64 649145001856603771, ; 13: System.Security.SecureString => 0x90239f09b62167b => 129
	i64 720058930071658100, ; 14: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 210
	i64 750875890346172408, ; 15: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 145
	i64 799765834175365804, ; 16: System.ComponentModel.dll => 0xb1956c9f18442ac => 18
	i64 870603111519317375, ; 17: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 179
	i64 872800313462103108, ; 18: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 204
	i64 940822596282819491, ; 19: System.Transactions => 0xd0e792aa81923a3 => 150
	i64 960778385402502048, ; 20: System.Runtime.Handles.dll => 0xd555ed9e1ca1ba0 => 104
	i64 996343623809489702, ; 21: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 246
	i64 1010599046655515943, ; 22: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 95
	i64 1120440138749646132, ; 23: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 248
	i64 1268860745194512059, ; 24: System.Drawing.dll => 0x119be62002c19ebb => 36
	i64 1301485588176585670, ; 25: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 178
	i64 1301626418029409250, ; 26: System.Diagnostics.FileVersionInfo => 0x12104e54b4e833e2 => 28
	i64 1315114680217950157, ; 27: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 188
	i64 1404195534211153682, ; 28: System.IO.FileSystem.Watcher.dll => 0x137cb4660bd87f12 => 50
	i64 1425944114962822056, ; 29: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 115
	i64 1476839205573959279, ; 30: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 70
	i64 1492954217099365037, ; 31: System.Net.HttpListener => 0x14b809f350210aad => 65
	i64 1513467482682125403, ; 32: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 170
	i64 1518315023656898250, ; 33: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 180
	i64 1537168428375924959, ; 34: System.Threading.Thread.dll => 0x15551e8a954ae0df => 145
	i64 1624659445732251991, ; 35: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 187
	i64 1628611045998245443, ; 36: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 219
	i64 1636321030536304333, ; 37: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 211
	i64 1651782184287836205, ; 38: System.Globalization.Calendars => 0x16ec4f2524cb982d => 40
	i64 1659332977923810219, ; 39: System.Reflection.DispatchProxy => 0x1707228d493d63ab => 89
	i64 1682513316613008342, ; 40: System.Net.dll => 0x17597cf276952bd6 => 81
	i64 1735388228521408345, ; 41: System.Net.Mail.dll => 0x181556663c69b759 => 66
	i64 1743969030606105336, ; 42: System.Memory.dll => 0x1833d297e88f2af8 => 62
	i64 1767386781656293639, ; 43: System.Private.Uri.dll => 0x188704e9f5582107 => 86
	i64 1795316252682057001, ; 44: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 186
	i64 1825687700144851180, ; 45: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 106
	i64 1836611346387731153, ; 46: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 231
	i64 1847446322536158010, ; 47: DocumentFormat.OpenXml.Framework.dll => 0x19a372a4645e933a => 174
	i64 1854145951182283680, ; 48: System.Runtime.CompilerServices.VisualC => 0x19bb3feb3df2e3a0 => 102
	i64 1875417405349196092, ; 49: System.Drawing.Primitives => 0x1a06d2319b6c713c => 35
	i64 1875917498431009007, ; 50: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 183
	i64 1972385128188460614, ; 51: System.Security.Cryptography.Algorithms => 0x1b5f51d2edefbe46 => 119
	i64 1981742497975770890, ; 52: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 218
	i64 2040001226662520565, ; 53: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 142
	i64 2062890601515140263, ; 54: System.Threading.Tasks.Dataflow => 0x1ca0dc1289cd44a7 => 141
	i64 2080945842184875448, ; 55: System.IO.MemoryMappedFiles => 0x1ce10137d8416db8 => 53
	i64 2102659300918482391, ; 56: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 35
	i64 2106033277907880740, ; 57: System.Threading.Tasks.Dataflow.dll => 0x1d3a221ba6d9cb24 => 141
	i64 2165725771938924357, ; 58: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 191
	i64 2203565783020068373, ; 59: Xamarin.KotlinX.Coroutines.Core => 0x1e94a367981dde15 => 253
	i64 2207662933261301575, ; 60: DocumentFormat.OpenXml => 0x1ea331bdb8d63747 => 173
	i64 2262844636196693701, ; 61: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 204
	i64 2287834202362508563, ; 62: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 8
	i64 2287887973817120656, ; 63: System.ComponentModel.DataAnnotations.dll => 0x1fc035fd8d41f790 => 14
	i64 2304837677853103545, ; 64: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0x1ffc6da80d5ed5b9 => 230
	i64 2315304989185124968, ; 65: System.IO.FileSystem.dll => 0x20219d9ee311aa68 => 51
	i64 2329709569556905518, ; 66: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 215
	i64 2335503487726329082, ; 67: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 136
	i64 2337758774805907496, ; 68: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 101
	i64 2470498323731680442, ; 69: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 198
	i64 2479423007379663237, ; 70: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 238
	i64 2497223385847772520, ; 71: System.Runtime => 0x22a7eb7046413568 => 116
	i64 2547086958574651984, ; 72: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 182
	i64 2592350477072141967, ; 73: System.Xml.dll => 0x23f9e10627330e8f => 163
	i64 2624866290265602282, ; 74: mscorlib.dll => 0x246d65fbde2db8ea => 166
	i64 2632269733008246987, ; 75: System.Net.NameResolution => 0x2487b36034f808cb => 67
	i64 2694427813909235223, ; 76: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 226
	i64 2706075432581334785, ; 77: System.Net.WebSockets => 0x258de944be6c0701 => 80
	i64 2783046991838674048, ; 78: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 101
	i64 2787234703088983483, ; 79: Xamarin.AndroidX.Startup.StartupRuntime => 0x26ae3f31ef429dbb => 233
	i64 2815524396660695947, ; 80: System.Security.AccessControl => 0x2712c0857f68238b => 117
	i64 2960931600190307745, ; 81: Xamarin.Forms.Core => 0x2917579a49927da1 => 244
	i64 3017136373564924869, ; 82: System.Net.WebProxy => 0x29df058bd93f63c5 => 78
	i64 3017704767998173186, ; 83: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 248
	i64 3106852385031680087, ; 84: System.Runtime.Serialization.Xml => 0x2b1dc1c88b637057 => 114
	i64 3110390492489056344, ; 85: System.Security.Cryptography.Csp.dll => 0x2b2a53ac61900058 => 121
	i64 3135773902340015556, ; 86: System.IO.FileSystem.DriveInfo.dll => 0x2b8481c008eac5c4 => 48
	i64 3281594302220646930, ; 87: System.Security.Principal => 0x2d8a90a198ceba12 => 128
	i64 3289520064315143713, ; 88: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 213
	i64 3303437397778967116, ; 89: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 184
	i64 3311221304742556517, ; 90: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 82
	i64 3325875462027654285, ; 91: System.Runtime.Numerics => 0x2e27e21c8958b48d => 110
	i64 3328853167529574890, ; 92: System.Net.Sockets.dll => 0x2e327651a008c1ea => 75
	i64 3344514922410554693, ; 93: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 254
	i64 3437845325506641314, ; 94: System.IO.MemoryMappedFiles.dll => 0x2fb5ae1beb8f7da2 => 53
	i64 3493805808809882663, ; 95: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 235
	i64 3508450208084372758, ; 96: System.Net.Ping => 0x30b084e02d03ad16 => 69
	i64 3522470458906976663, ; 97: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 234
	i64 3531994851595924923, ; 98: System.Numerics => 0x31042a9aade235bb => 83
	i64 3551103847008531295, ; 99: System.Private.CoreLib.dll => 0x31480e226177735f => 172
	i64 3571415421602489686, ; 100: System.Runtime.dll => 0x319037675df7e556 => 116
	i64 3647754201059316852, ; 101: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 156
	i64 3716579019761409177, ; 102: netstandard.dll => 0x3393f0ed5c8c5c99 => 167
	i64 3727469159507183293, ; 103: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 229
	i64 3772598417116884899, ; 104: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 205
	i64 3869649043256705283, ; 105: System.Diagnostics.Tools => 0x35b3c14d74bf0103 => 32
	i64 3919223565570527920, ; 106: System.Security.Cryptography.Encoding => 0x3663e111652bd2b0 => 122
	i64 3933965368022646939, ; 107: System.Net.Requests => 0x369840a8bfadc09b => 72
	i64 3966267475168208030, ; 108: System.Memory => 0x370b03412596249e => 62
	i64 4006972109285359177, ; 109: System.Xml.XmlDocument => 0x379b9fe74ed9fe49 => 161
	i64 4009997192427317104, ; 110: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 113
	i64 4073500526318903918, ; 111: System.Private.Xml.dll => 0x3887fb25779ae26e => 88
	i64 4148881117810174540, ; 112: System.Runtime.InteropServices.JavaScript.dll => 0x3993c9651a66aa4c => 105
	i64 4154383907710350974, ; 113: System.ComponentModel => 0x39a7562737acb67e => 18
	i64 4167269041631776580, ; 114: System.Threading.ThreadPool => 0x39d51d1d3df1cf44 => 146
	i64 4168469861834746866, ; 115: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 118
	i64 4187479170553454871, ; 116: System.Linq.Expressions => 0x3a1cea1e912fa117 => 58
	i64 4201423742386704971, ; 117: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 200
	i64 4205801962323029395, ; 118: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 17
	i64 4235503420553921860, ; 119: System.IO.IsolatedStorage.dll => 0x3ac787eb9b118544 => 52
	i64 4282138915307457788, ; 120: System.Reflection.Emit => 0x3b6d36a7ddc70cfc => 92
	i64 4337444564132831293, ; 121: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 176
	i64 4373617458794931033, ; 122: System.IO.Pipes.dll => 0x3cb235e806eb2359 => 55
	i64 4397634830160618470, ; 123: System.Security.SecureString.dll => 0x3d0789940f9be3e6 => 129
	i64 4477672992252076438, ; 124: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 152
	i64 4484706122338676047, ; 125: System.Globalization.Extensions.dll => 0x3e3ce07510042d4f => 41
	i64 4533124835995628778, ; 126: System.Reflection.Emit.dll => 0x3ee8e505540534ea => 92
	i64 4636684751163556186, ; 127: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 239
	i64 4672453897036726049, ; 128: System.IO.FileSystem.Watcher => 0x40d7e4104a437f21 => 50
	i64 4716677666592453464, ; 129: System.Xml.XmlSerializer => 0x417501590542f358 => 162
	i64 4743821336939966868, ; 130: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 13
	i64 4759461199762736555, ; 131: Xamarin.AndroidX.Lifecycle.Process.dll => 0x420d00be961cc5ab => 216
	i64 4782108999019072045, ; 132: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 190
	i64 4794310189461587505, ; 133: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 182
	i64 4795410492532947900, ; 134: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 234
	i64 4809057822547766521, ; 135: System.Drawing => 0x42bd349c3145ecf9 => 36
	i64 4814660307502931973, ; 136: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 67
	i64 4853321196694829351, ; 137: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 109
	i64 5003780535402192099, ; 138: UniversityAndroidApp => 0x4570ffe2c2a95ce3 => 0
	i64 5081566143765835342, ; 139: System.Resources.ResourceManager.dll => 0x4685597c05d06e4e => 99
	i64 5099468265966638712, ; 140: System.Resources.ResourceManager => 0x46c4f35ea8519678 => 99
	i64 5103417709280584325, ; 141: System.Collections.Specialized => 0x46d2fb5e161b6285 => 11
	i64 5142919913060024034, ; 142: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 245
	i64 5182934613077526976, ; 143: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 11
	i64 5203618020066742981, ; 144: Xamarin.Essentials => 0x4836f704f0e652c5 => 242
	i64 5205316157927637098, ; 145: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 221
	i64 5244375036463807528, ; 146: System.Diagnostics.Contracts.dll => 0x48c7c34f4d59fc28 => 25
	i64 5262971552273843408, ; 147: System.Security.Principal.dll => 0x4909d4be0c44c4d0 => 128
	i64 5278787618751394462, ; 148: System.Net.WebClient.dll => 0x4942055efc68329e => 76
	i64 5290786973231294105, ; 149: System.Runtime.Loader => 0x496ca6b869b72699 => 109
	i64 5348796042099802469, ; 150: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 222
	i64 5376510917114486089, ; 151: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 238
	i64 5408338804355907810, ; 152: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 236
	i64 5423376490970181369, ; 153: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 106
	i64 5440320908473006344, ; 154: Microsoft.VisualBasic.Core => 0x4b7fe70acda9f908 => 2
	i64 5446034149219586269, ; 155: System.Diagnostics.Debug => 0x4b94333452e150dd => 26
	i64 5451019430259338467, ; 156: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 196
	i64 5457765010617926378, ; 157: System.Xml.Serialization => 0x4bbde05c557002ea => 157
	i64 5507995362134886206, ; 158: System.Core.dll => 0x4c705499688c873e => 21
	i64 5527431512186326818, ; 159: System.IO.FileSystem.Primitives.dll => 0x4cb561acbc2a8f22 => 49
	i64 5570799893513421663, ; 160: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 43
	i64 5573260873512690141, ; 161: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 126
	i64 5574231584441077149, ; 162: Xamarin.AndroidX.Annotation.Jvm => 0x4d5ba617ae5f8d9d => 185
	i64 5591791169662171124, ; 163: System.Linq.Parallel => 0x4d9a087135e137f4 => 59
	i64 5626675072969102346, ; 164: SQLitePCLRaw.nativelibrary.dll => 0x4e15f72adede540a => 177
	i64 5650097808083101034, ; 165: System.Security.Cryptography.Algorithms.dll => 0x4e692e055d01a56a => 119
	i64 5692067934154308417, ; 166: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 241
	i64 5757522595884336624, ; 167: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 195
	i64 5783556987928984683, ; 168: Microsoft.VisualBasic => 0x504352701bbc3c6b => 3
	i64 5814345312393086621, ; 169: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 226
	i64 5896680224035167651, ; 170: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 214
	i64 5979151488806146654, ; 171: System.Formats.Asn1 => 0x52fa3699a489d25e => 38
	i64 5984759512290286505, ; 172: System.Security.Cryptography.Primitives => 0x530e23115c33dba9 => 124
	i64 6085203216496545422, ; 173: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 246
	i64 6086316965293125504, ; 174: FormsViewGroup.dll => 0x5476f10882baef80 => 243
	i64 6183170893902868313, ; 175: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 176
	i64 6222399776351216807, ; 176: System.Text.Json.dll => 0x565a67a0ffe264a7 => 137
	i64 6251069312384999852, ; 177: System.Transactions.Local => 0x56c0426b870da1ac => 149
	i64 6278736998281604212, ; 178: System.Private.DataContractSerialization => 0x57228e08a4ad6c74 => 85
	i64 6284145129771520194, ; 179: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 90
	i64 6319713645133255417, ; 180: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 217
	i64 6357457916754632952, ; 181: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 255
	i64 6401687960814735282, ; 182: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 215
	i64 6504860066809920875, ; 183: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 191
	i64 6548213210057960872, ; 184: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 202
	i64 6617685658146568858, ; 185: System.Text.Encoding.CodePages => 0x5bd6be0b4905fa9a => 133
	i64 6659513131007730089, ; 186: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 210
	i64 6713440830605852118, ; 187: System.Reflection.TypeExtensions.dll => 0x5d2aeeddb8dd7dd6 => 96
	i64 6739853162153639747, ; 188: Microsoft.VisualBasic.dll => 0x5d88c4bde075ff43 => 3
	i64 6772837112740759457, ; 189: System.Runtime.InteropServices.JavaScript => 0x5dfdf378527ec7a1 => 105
	i64 6786606130239981554, ; 190: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 33
	i64 6798329586179154312, ; 191: System.Windows => 0x5e5884bd523ca188 => 154
	i64 6814185388980153342, ; 192: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 158
	i64 6876862101832370452, ; 193: System.Xml.Linq => 0x5f6f85a57d108914 => 155
	i64 6894844156784520562, ; 194: System.Numerics.Vectors => 0x5faf683aead1ad72 => 82
	i64 7036436454368433159, ; 195: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 212
	i64 7060896174307865760, ; 196: System.Threading.Tasks.Parallel.dll => 0x61fd57a90988f4a0 => 143
	i64 7083547580668757502, ; 197: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 87
	i64 7101497697220435230, ; 198: System.Configuration => 0x628d9687c0141d1e => 19
	i64 7103753931438454322, ; 199: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 209
	i64 7112547816752919026, ; 200: System.IO.FileSystem => 0x62b4d88e3189b1f2 => 51
	i64 7270811800166795866, ; 201: System.Linq => 0x64e71ccf51a90a5a => 61
	i64 7299370801165188114, ; 202: System.IO.Pipes.AccessControl.dll => 0x654c9311e74f3c12 => 54
	i64 7316205155833392065, ; 203: Microsoft.Win32.Primitives => 0x658861d38954abc1 => 4
	i64 7338192458477945005, ; 204: System.Reflection => 0x65d67f295d0740ad => 97
	i64 7377312882064240630, ; 205: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 17
	i64 7488575175965059935, ; 206: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 155
	i64 7489048572193775167, ; 207: System.ObjectModel => 0x67ee71ff6b419e3f => 84
	i64 7592577537120840276, ; 208: System.Diagnostics.Process => 0x695e410af5b2aa54 => 29
	i64 7635363394907363464, ; 209: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 244
	i64 7637303409920963731, ; 210: System.IO.Compression.ZipFile.dll => 0x69fd26fcb637f493 => 45
	i64 7637365915383206639, ; 211: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 242
	i64 7654504624184590948, ; 212: System.Net.Http => 0x6a3a4366801b8264 => 64
	i64 7694700312542370399, ; 213: System.Net.Mail => 0x6ac9112a7e2cda5f => 66
	i64 7714652370974252055, ; 214: System.Private.CoreLib => 0x6b0ff375198b9c17 => 172
	i64 7735176074855944702, ; 215: Microsoft.CSharp => 0x6b58dda848e391fe => 1
	i64 7735352534559001595, ; 216: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 251
	i64 7791074099216502080, ; 217: System.IO.FileSystem.AccessControl.dll => 0x6c1f749d468bcd40 => 47
	i64 7820441508502274321, ; 218: System.Data => 0x6c87ca1e14ff8111 => 24
	i64 7836164640616011524, ; 219: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 187
	i64 8025517457475554965, ; 220: WindowsBase => 0x6f605d9b4786ce95 => 165
	i64 8031450141206250471, ; 221: System.Runtime.Intrinsics.dll => 0x6f757159d9dc03e7 => 108
	i64 8064050204834738623, ; 222: System.Collections.dll => 0x6fe942efa61731bf => 12
	i64 8083354569033831015, ; 223: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 213
	i64 8085230611270010360, ; 224: System.Net.Http.Json.dll => 0x703482674fdd05f8 => 63
	i64 8087206902342787202, ; 225: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 27
	i64 8103644804370223335, ; 226: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 23
	i64 8113615946733131500, ; 227: System.Reflection.Extensions => 0x70995ab73cf916ec => 93
	i64 8167236081217502503, ; 228: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 168
	i64 8185542183669246576, ; 229: System.Collections => 0x7198e33f4794aa70 => 12
	i64 8187640529827139739, ; 230: Xamarin.KotlinX.Coroutines.Android => 0x71a057ae90f0109b => 252
	i64 8264926008854159966, ; 231: System.Diagnostics.Process.dll => 0x72b2ea6a64a3a25e => 29
	i64 8290740647658429042, ; 232: System.Runtime.Extensions => 0x730ea0b15c929a72 => 103
	i64 8318905602908530212, ; 233: System.ComponentModel.DataAnnotations => 0x7372b092055ea624 => 14
	i64 8368701292315763008, ; 234: System.Security.Cryptography => 0x7423997c6fd56140 => 126
	i64 8398329775253868912, ; 235: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 197
	i64 8400357532724379117, ; 236: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 225
	i64 8410671156615598628, ; 237: System.Reflection.Emit.Lightweight.dll => 0x74b8b4daf4b25224 => 91
	i64 8426919725312979251, ; 238: Xamarin.AndroidX.Lifecycle.Process => 0x74f26ed7aa033133 => 216
	i64 8518412311883997971, ; 239: System.Collections.Immutable => 0x76377add7c28e313 => 9
	i64 8563666267364444763, ; 240: System.Private.Uri => 0x76d841191140ca5b => 86
	i64 8598790081731763592, ; 241: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x77550a055fc61d88 => 207
	i64 8601935802264776013, ; 242: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 236
	i64 8623059219396073920, ; 243: System.Net.Quic.dll => 0x77ab42ac514299c0 => 71
	i64 8626175481042262068, ; 244: Java.Interop => 0x77b654e585b55834 => 168
	i64 8638972117149407195, ; 245: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 1
	i64 8639588376636138208, ; 246: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 224
	i64 8648495978913578441, ; 247: Microsoft.Win32.Registry.dll => 0x7805a1456889bdc9 => 5
	i64 8684531736582871431, ; 248: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 44
	i64 8725526185868997716, ; 249: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 27
	i64 8941376889969657626, ; 250: System.Xml.XDocument => 0x7c1626e87187471a => 158
	i64 8951477988056063522, ; 251: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0x7c3a09cd9ccf5e22 => 228
	i64 8954753533646919997, ; 252: System.Runtime.Serialization.Json => 0x7c45ace50032d93d => 112
	i64 9031035476476434958, ; 253: Xamarin.KotlinX.Coroutines.Core.dll => 0x7d54aeead9541a0e => 253
	i64 9138683372487561558, ; 254: System.Security.Cryptography.Csp => 0x7ed3201bc3e3d156 => 121
	i64 9312692141327339315, ; 255: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 241
	i64 9324707631942237306, ; 256: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 186
	i64 9468215723722196442, ; 257: System.Xml.XPath.XDocument.dll => 0x8365dc09353ac5da => 159
	i64 9554839972845591462, ; 258: System.ServiceModel.Web => 0x84999c54e32a1ba6 => 131
	i64 9584643793929893533, ; 259: System.IO.dll => 0x85037ebfbbd7f69d => 57
	i64 9659729154652888475, ; 260: System.Text.RegularExpressions => 0x860e407c9991dd9b => 138
	i64 9662334977499516867, ; 261: System.Numerics.dll => 0x8617827802b0cfc3 => 83
	i64 9667360217193089419, ; 262: System.Diagnostics.StackTrace => 0x86295ce5cd89898b => 30
	i64 9678050649315576968, ; 263: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 198
	i64 9702891218465930390, ; 264: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 10
	i64 9711637524876806384, ; 265: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 222
	i64 9808709177481450983, ; 266: Mono.Android.dll => 0x881f890734e555e7 => 171
	i64 9825649861376906464, ; 267: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 195
	i64 9834056768316610435, ; 268: System.Transactions.dll => 0x8879968718899783 => 150
	i64 9836529246295212050, ; 269: System.Reflection.Metadata => 0x88825f3bbc2ac012 => 94
	i64 9907349773706910547, ; 270: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x897dfa20b758db53 => 207
	i64 9933555792566666578, ; 271: System.Linq.Queryable.dll => 0x89db145cf475c552 => 60
	i64 9974604633896246661, ; 272: System.Xml.Serialization.dll => 0x8a6cea111a59dd85 => 157
	i64 10038780035334861115, ; 273: System.Net.Http.dll => 0x8b50e941206af13b => 64
	i64 10051358222726253779, ; 274: System.Private.Xml => 0x8b7d990c97ccccd3 => 88
	i64 10078727084704864206, ; 275: System.Net.WebSockets.Client => 0x8bded4e257f117ce => 79
	i64 10089571585547156312, ; 276: System.IO.FileSystem.AccessControl => 0x8c055be67469bb58 => 47
	i64 10105485790837105934, ; 277: System.Threading.Tasks.Parallel => 0x8c3de5c91d9a650e => 143
	i64 10229024438826829339, ; 278: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 202
	i64 10236703004850800690, ; 279: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 74
	i64 10245369515835430794, ; 280: System.Reflection.Emit.Lightweight => 0x8e2edd4ad7fc978a => 91
	i64 10321854143672141184, ; 281: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 250
	i64 10360651442923773544, ; 282: System.Text.Encoding => 0x8fc86d98211c1e68 => 135
	i64 10364469296367737616, ; 283: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 90
	i64 10376576884623852283, ; 284: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 235
	i64 10406448008575299332, ; 285: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 254
	i64 10430153318873392755, ; 286: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 199
	i64 10546663366131771576, ; 287: System.Runtime.Serialization.Json.dll => 0x925d4673efe8e8b8 => 112
	i64 10566960649245365243, ; 288: System.Globalization.dll => 0x92a562b96dcd13fb => 42
	i64 10595762989148858956, ; 289: System.Xml.XPath.XDocument => 0x930bb64cc472ea4c => 159
	i64 10650478070646097812, ; 290: System.IO.Packaging => 0x93ce196068f2c794 => 181
	i64 10670374202010151210, ; 291: Microsoft.Win32.Primitives.dll => 0x9414c8cd7b4ea92a => 4
	i64 10714184849103829812, ; 292: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 103
	i64 10785150219063592792, ; 293: System.Net.Primitives => 0x95ac8cfb68830758 => 70
	i64 10822644899632537592, ; 294: System.Linq.Queryable => 0x9631c23204ca5ff8 => 60
	i64 10830817578243619689, ; 295: System.Formats.Tar => 0x964ecb340a447b69 => 39
	i64 10847732767863316357, ; 296: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 188
	i64 10899834349646441345, ; 297: System.Web => 0x9743fd975946eb81 => 153
	i64 10943875058216066601, ; 298: System.IO.UnmanagedMemoryStream.dll => 0x97e07461df39de29 => 56
	i64 10964653383833615866, ; 299: System.Diagnostics.Tracing => 0x982a4628ccaffdfa => 34
	i64 11019817191295005410, ; 300: Xamarin.AndroidX.Annotation.Jvm.dll => 0x98ee415998e1b2e2 => 185
	i64 11023048688141570732, ; 301: System.Core => 0x98f9bc61168392ac => 21
	i64 11037814507248023548, ; 302: System.Xml => 0x992e31d0412bf7fc => 163
	i64 11162124722117608902, ; 303: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 240
	i64 11188319605227840848, ; 304: System.Threading.Overlapped => 0x9b44e5671724e550 => 140
	i64 11235648312900863002, ; 305: System.Reflection.DispatchProxy.dll => 0x9bed0a9c8fac441a => 89
	i64 11299661109949763898, ; 306: Xamarin.AndroidX.Collection.Jvm => 0x9cd075e94cda113a => 194
	i64 11329751333533450475, ; 307: System.Threading.Timer.dll => 0x9d3b5ccf6cc500eb => 147
	i64 11340910727871153756, ; 308: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 201
	i64 11347436699239206956, ; 309: System.Xml.XmlSerializer.dll => 0x9d7a318e8162502c => 162
	i64 11392833485892708388, ; 310: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 227
	i64 11432101114902388181, ; 311: System.AppContext => 0x9ea6fb64e61a9dd5 => 6
	i64 11446671985764974897, ; 312: Mono.Android.Export => 0x9edabf8623efc131 => 169
	i64 11448276831755070604, ; 313: System.Diagnostics.TextWriterTraceListener => 0x9ee0731f77186c8c => 31
	i64 11485890710487134646, ; 314: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 107
	i64 11529969570048099689, ; 315: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 240
	i64 11578238080964724296, ; 316: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 212
	i64 11580057168383206117, ; 317: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 183
	i64 11591352189662810718, ; 318: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0xa0dcc167234c525e => 233
	i64 11597940890313164233, ; 319: netstandard => 0xa0f429ca8d1805c9 => 167
	i64 11672361001936329215, ; 320: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 209
	i64 11692977985522001935, ; 321: System.Threading.Overlapped.dll => 0xa245cd869980680f => 140
	i64 11707554492040141440, ; 322: System.Linq.Parallel.dll => 0xa27996c7fe94da80 => 59
	i64 11739066727115742305, ; 323: SQLite-net.dll => 0xa2e98afdf8575c61 => 175
	i64 11743665907891708234, ; 324: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 144
	i64 11806260347154423189, ; 325: SQLite-net => 0xa3d8433bc5eb5d95 => 175
	i64 11991047634523762324, ; 326: System.Net => 0xa668c24ad493ae94 => 81
	i64 12040886584167504988, ; 327: System.Net.ServicePoint => 0xa719d28d8e121c5c => 74
	i64 12063623837170009990, ; 328: System.Security => 0xa76a99f6ce740786 => 130
	i64 12096697103934194533, ; 329: System.Diagnostics.Contracts => 0xa7e019eccb7e8365 => 25
	i64 12102847907131387746, ; 330: System.Buffers => 0xa7f5f40c43256f62 => 7
	i64 12123043025855404482, ; 331: System.Reflection.Extensions.dll => 0xa83db366c0e359c2 => 93
	i64 12137774235383566651, ; 332: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 237
	i64 12145679461940342714, ; 333: System.Text.Json => 0xa88e1f1ebcb62fba => 137
	i64 12201331334810686224, ; 334: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 113
	i64 12269460666702402136, ; 335: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 9
	i64 12279246230491828964, ; 336: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 180
	i64 12332222936682028543, ; 337: System.Runtime.Handles => 0xab24db6c07db5dff => 104
	i64 12375446203996702057, ; 338: System.Configuration.dll => 0xabbe6ac12e2e0569 => 19
	i64 12451044538927396471, ; 339: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 208
	i64 12466513435562512481, ; 340: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 220
	i64 12475113361194491050, ; 341: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 255
	i64 12487638416075308985, ; 342: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 203
	i64 12517810545449516888, ; 343: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 33
	i64 12538491095302438457, ; 344: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 192
	i64 12550732019250633519, ; 345: System.IO.Compression => 0xae2d28465e8e1b2f => 46
	i64 12699999919562409296, ; 346: System.Diagnostics.StackTrace.dll => 0xb03f76a3ad01c550 => 30
	i64 12700543734426720211, ; 347: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 193
	i64 12708238894395270091, ; 348: System.IO => 0xb05cbbf17d3ba3cb => 57
	i64 12708922737231849740, ; 349: System.Text.Encoding.Extensions => 0xb05f29e50e96e90c => 134
	i64 12717050818822477433, ; 350: System.Runtime.Serialization.Xml.dll => 0xb07c0a5786811679 => 114
	i64 12835242264250840079, ; 351: System.IO.Pipes => 0xb21ff0d5d6c0740f => 55
	i64 12843770487262409629, ; 352: System.AppContext.dll => 0xb23e3d357debf39d => 6
	i64 12859557719246324186, ; 353: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 77
	i64 13068258254871114833, ; 354: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 111
	i64 13129914918964716986, ; 355: Xamarin.AndroidX.Emoji2.dll => 0xb636d40db3fe65ba => 206
	i64 13173818576982874404, ; 356: System.Runtime.CompilerServices.VisualC.dll => 0xb6d2ce32a8819924 => 102
	i64 13343850469010654401, ; 357: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 170
	i64 13370592475155966277, ; 358: System.Runtime.Serialization => 0xb98de304062ea945 => 115
	i64 13401370062847626945, ; 359: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 237
	i64 13404347523447273790, ; 360: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 197
	i64 13431476299110033919, ; 361: System.Net.WebClient => 0xba663087f18829ff => 76
	i64 13454009404024712428, ; 362: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 249
	i64 13463706743370286408, ; 363: System.Private.DataContractSerialization.dll => 0xbad8b1f3069e0548 => 85
	i64 13465488254036897740, ; 364: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 251
	i64 13491513212026656886, ; 365: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 189
	i64 13572454107664307259, ; 366: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 229
	i64 13578472628727169633, ; 367: System.Xml.XPath => 0xbc706ce9fba5c261 => 160
	i64 13580399111273692417, ; 368: Microsoft.VisualBasic.Core.dll => 0xbc77450a277fbd01 => 2
	i64 13647894001087880694, ; 369: System.Data.dll => 0xbd670f48cb071df6 => 24
	i64 13702626353344114072, ; 370: System.Diagnostics.Tools.dll => 0xbe29821198fb6d98 => 32
	i64 13710614125866346983, ; 371: System.Security.AccessControl.dll => 0xbe45e2e7d0b769e7 => 117
	i64 13713329104121190199, ; 372: System.Dynamic.Runtime => 0xbe4f8829f32b5737 => 37
	i64 13717397318615465333, ; 373: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 16
	i64 13768883594457632599, ; 374: System.IO.IsolatedStorage => 0xbf14e6adb159cf57 => 52
	i64 13881769479078963060, ; 375: System.Console.dll => 0xc0a5f3cade5c6774 => 20
	i64 13911222732217019342, ; 376: System.Security.Cryptography.OpenSsl.dll => 0xc10e975ec1226bce => 123
	i64 13928444506500929300, ; 377: System.Windows.dll => 0xc14bc67b8bba9714 => 154
	i64 13959074834287824816, ; 378: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 208
	i64 13967638549803255703, ; 379: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 245
	i64 14075334701871371868, ; 380: System.ServiceModel.Web.dll => 0xc355a25647c5965c => 131
	i64 14124974489674258913, ; 381: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 192
	i64 14125464355221830302, ; 382: System.Threading.dll => 0xc407bafdbc707a9e => 148
	i64 14148919944076435199, ; 383: DocumentFormat.OpenXml.dll => 0xc45b0fb9961d9eff => 173
	i64 14212104595480609394, ; 384: System.Security.Cryptography.Cng.dll => 0xc53b89d4a4518272 => 120
	i64 14220608275227875801, ; 385: System.Diagnostics.FileVersionInfo.dll => 0xc559bfe1def019d9 => 28
	i64 14226382999226559092, ; 386: System.ServiceProcess => 0xc56e43f6938e2a74 => 132
	i64 14232023429000439693, ; 387: System.Resources.Writer.dll => 0xc5824de7789ba78d => 100
	i64 14254574811015963973, ; 388: System.Text.Encoding.Extensions.dll => 0xc5d26c4442d66545 => 134
	i64 14261073672896646636, ; 389: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 227
	i64 14298246716367104064, ; 390: System.Web.dll => 0xc66d93a217f4e840 => 153
	i64 14327695147300244862, ; 391: System.Reflection.dll => 0xc6d632d338eb4d7e => 97
	i64 14327709162229390963, ; 392: System.Security.Cryptography.X509Certificates => 0xc6d63f9253cade73 => 125
	i64 14346402571976470310, ; 393: System.Net.Ping.dll => 0xc718a920f3686f26 => 69
	i64 14461014870687870182, ; 394: System.Net.Requests.dll => 0xc8afd8683afdece6 => 72
	i64 14486659737292545672, ; 395: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 214
	i64 14495724990987328804, ; 396: Xamarin.AndroidX.ResourceInspection.Annotation => 0xc92b2913e18d5d24 => 230
	i64 14551742072151931844, ; 397: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 136
	i64 14561513370130550166, ; 398: System.Security.Cryptography.Primitives.dll => 0xca14e3428abb8d96 => 124
	i64 14574160591280636898, ; 399: System.Net.Quic => 0xca41d1d72ec783e2 => 71
	i64 14622043554576106986, ; 400: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 111
	i64 14644440854989303794, ; 401: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 221
	i64 14690985099581930927, ; 402: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 152
	i64 14792063746108907174, ; 403: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 249
	i64 14832630590065248058, ; 404: System.Security.Claims => 0xcdd816ef5d6e873a => 118
	i64 14852515768018889994, ; 405: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 201
	i64 14912225920358050525, ; 406: System.Security.Principal.Windows => 0xcef2de7759506add => 127
	i64 14935719434541007538, ; 407: System.Text.Encoding.CodePages.dll => 0xcf4655b160b702b2 => 133
	i64 14984936317414011727, ; 408: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 77
	i64 14987728460634540364, ; 409: System.IO.Compression.dll => 0xcfff1ba06622494c => 46
	i64 14988210264188246988, ; 410: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 203
	i64 15015154896917945444, ; 411: System.Net.Security.dll => 0xd0608bd33642dc64 => 73
	i64 15024878362326791334, ; 412: System.Net.Http.Json => 0xd0831743ebf0f4a6 => 63
	i64 15055048765753425892, ; 413: SQLitePCLRaw.nativelibrary => 0xd0ee47165eea7fe4 => 177
	i64 15071021337266399595, ; 414: System.Resources.Reader.dll => 0xd127060e7a18a96b => 98
	i64 15076659072870671916, ; 415: System.ObjectModel.dll => 0xd13b0d8c1620662c => 84
	i64 15115185479366240210, ; 416: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 43
	i64 15133485256822086103, ; 417: System.Linq.dll => 0xd204f0a9127dd9d7 => 61
	i64 15150743910298169673, ; 418: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xd2424150783c3149 => 228
	i64 15234786388537674379, ; 419: System.Dynamic.Runtime.dll => 0xd36cd580c5be8a8b => 37
	i64 15250465174479574862, ; 420: System.Globalization.Calendars.dll => 0xd3a489469852174e => 40
	i64 15279429628684179188, ; 421: Xamarin.KotlinX.Coroutines.Android.dll => 0xd40b704b1c4c96f4 => 252
	i64 15299439993936780255, ; 422: System.Xml.XPath.dll => 0xd452879d55019bdf => 160
	i64 15338463749992804988, ; 423: System.Resources.Reader => 0xd4dd2b839286f27c => 98
	i64 15370334346939861994, ; 424: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 199
	i64 15526743539506359484, ; 425: System.Text.Encoding.dll => 0xd77a12fc26de2cbc => 135
	i64 15527772828719725935, ; 426: System.Console => 0xd77dbb1e38cd3d6f => 20
	i64 15530465045505749832, ; 427: System.Net.HttpListener.dll => 0xd7874bacc9fdb348 => 65
	i64 15541854775306130054, ; 428: System.Security.Cryptography.X509Certificates.dll => 0xd7afc292e8d49286 => 125
	i64 15557562860424774966, ; 429: System.Net.Sockets => 0xd7e790fe7a6dc536 => 75
	i64 15582737692548360875, ; 430: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 219
	i64 15609085926864131306, ; 431: System.dll => 0xd89e9cf3334914ea => 164
	i64 15661133872274321916, ; 432: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 156
	i64 15710114879900314733, ; 433: Microsoft.Win32.Registry => 0xda058a3f5d096c6d => 5
	i64 15755368083429170162, ; 434: System.IO.FileSystem.Primitives => 0xdaa64fcbde529bf2 => 49
	i64 15777549416145007739, ; 435: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 232
	i64 15810740023422282496, ; 436: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 247
	i64 15817206913877585035, ; 437: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 144
	i64 15847085070278954535, ; 438: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 139
	i64 15885744048853936810, ; 439: System.Resources.Writer => 0xdc75800bd0b6eaaa => 100
	i64 15934062614519587357, ; 440: System.Security.Cryptography.OpenSsl => 0xdd2129868f45a21d => 123
	i64 15937190497610202713, ; 441: System.Security.Cryptography.Cng => 0xdd2c465197c97e59 => 120
	i64 15963349826457351533, ; 442: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 142
	i64 15971679995444160383, ; 443: System.Formats.Tar.dll => 0xdda6ce5592a9677f => 39
	i64 16018552496348375205, ; 444: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 68
	i64 16054465462676478687, ; 445: System.Globalization.Extensions => 0xdecceb47319bdadf => 41
	i64 16154507427712707110, ; 446: System => 0xe03056ea4e39aa26 => 164
	i64 16219561732052121626, ; 447: System.Net.Security => 0xe1177575db7c781a => 73
	i64 16315482530584035869, ; 448: WindowsBase.dll => 0xe26c3ceb1e8d821d => 165
	i64 16337011941688632206, ; 449: System.Security.Principal.Windows.dll => 0xe2b8b9cdc3aa638e => 127
	i64 16454459195343277943, ; 450: System.Net.NetworkInformation => 0xe459fb756d988f77 => 68
	i64 16496768397145114574, ; 451: Mono.Android.Export.dll => 0xe4f04b741db987ce => 169
	i64 16621146507174665210, ; 452: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 196
	i64 16677317093839702854, ; 453: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 225
	i64 16702652415771857902, ; 454: System.ValueTuple => 0xe7cbbde0b0e6d3ee => 151
	i64 16709499819875633724, ; 455: System.IO.Compression.ZipFile => 0xe7e4118e32240a3c => 45
	i64 16737807731308835127, ; 456: System.Runtime.Intrinsics => 0xe848a3736f733137 => 108
	i64 16755018182064898362, ; 457: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 178
	i64 16758309481308491337, ; 458: System.IO.FileSystem.DriveInfo => 0xe89179af15740e49 => 48
	i64 16762783179241323229, ; 459: System.Reflection.TypeExtensions => 0xe8a15e7d0d927add => 96
	i64 16765015072123548030, ; 460: System.Diagnostics.TextWriterTraceListener.dll => 0xe8a94c621bfe717e => 31
	i64 16822611501064131242, ; 461: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 23
	i64 16833383113903931215, ; 462: mscorlib => 0xe99c30c1484d7f4f => 166
	i64 16856067890322379635, ; 463: System.Data.Common.dll => 0xe9ecc87060889373 => 22
	i64 16890310621557459193, ; 464: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 138
	i64 16933958494752847024, ; 465: System.Net.WebProxy.dll => 0xeb018187f0f3b4b0 => 78
	i64 16977952268158210142, ; 466: System.IO.Pipes.AccessControl => 0xeb9dcda2851b905e => 54
	i64 17008137082415910100, ; 467: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 10
	i64 17024911836938395553, ; 468: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 184
	i64 17031351772568316411, ; 469: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 223
	i64 17037200463775726619, ; 470: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 211
	i64 17062143951396181894, ; 471: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 16
	i64 17118171214553292978, ; 472: System.Threading.Channels => 0xed8ff6060fc420b2 => 139
	i64 17187273293601214786, ; 473: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 13
	i64 17201328579425343169, ; 474: System.ComponentModel.EventBasedAsync => 0xeeb76534d96c16c1 => 15
	i64 17202182880784296190, ; 475: System.Security.Cryptography.Encoding.dll => 0xeeba6e30627428fe => 122
	i64 17230721278011714856, ; 476: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 87
	i64 17234219099804750107, ; 477: System.Transactions.Local.dll => 0xef2c3ef5e11d511b => 149
	i64 17260702271250283638, ; 478: System.Data.Common => 0xef8a5543bba6bc76 => 22
	i64 17333249706306540043, ; 479: System.Diagnostics.Tracing.dll => 0xf08c12c5bb8b920b => 34
	i64 17338386382517543202, ; 480: System.Net.WebSockets.Client.dll => 0xf09e528d5c6da122 => 79
	i64 17470386307322966175, ; 481: System.Threading.Timer => 0xf27347c8d0d5709f => 147
	i64 17509662556995089465, ; 482: System.Net.WebSockets.dll => 0xf2fed1534ea67439 => 80
	i64 17544493274320527064, ; 483: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 190
	i64 17627500474728259406, ; 484: System.Globalization => 0xf4a176498a351f4e => 42
	i64 17685921127322830888, ; 485: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 26
	i64 17704177640604968747, ; 486: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 220
	i64 17710060891934109755, ; 487: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 218
	i64 17712670374920797664, ; 488: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 107
	i64 17777860260071588075, ; 489: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 110
	i64 17838668724098252521, ; 490: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 7
	i64 17882897186074144999, ; 491: FormsViewGroup => 0xf82cd03e3ac830e7 => 243
	i64 17891337867145587222, ; 492: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 250
	i64 17892495832318972303, ; 493: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 247
	i64 17928294245072900555, ; 494: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 44
	i64 17992315986609351877, ; 495: System.Xml.XmlDocument.dll => 0xf9b18c0ffc6eacc5 => 161
	i64 18025913125965088385, ; 496: System.Threading => 0xfa28e87b91334681 => 148
	i64 18075302676416259632, ; 497: UniversityAndroidApp.dll => 0xfad8600463756630 => 0
	i64 18116111925905154859, ; 498: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 189
	i64 18121036031235206392, ; 499: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 223
	i64 18146411883821974900, ; 500: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 38
	i64 18146811631844267958, ; 501: System.ComponentModel.EventBasedAsync.dll => 0xfbd66d08820117b6 => 15
	i64 18225059387460068507, ; 502: System.Threading.ThreadPool.dll => 0xfcec6af3cff4a49b => 146
	i64 18245806341561545090, ; 503: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 8
	i64 18260797123374478311, ; 504: Xamarin.AndroidX.Emoji2 => 0xfd6b623bde35f3e7 => 206
	i64 18284618658670613420, ; 505: System.IO.Packaging.dll => 0xfdc003cb438a93ac => 181
	i64 18305135509493619199, ; 506: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 224
	i64 18318849532986632368, ; 507: System.Security.dll => 0xfe39a097c37fa8b0 => 130
	i64 18341799084585866416, ; 508: DocumentFormat.OpenXml.Framework => 0xfe8b2916a25354b0 => 174
	i64 18370042311372477656, ; 509: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 179
	i64 18380184030268848184, ; 510: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 239
	i64 18439108438687598470 ; 511: System.Reflection.Metadata.dll => 0xffe4df6e2ee1c786 => 94
], align 16

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [512 x i32] [
	i32 205, ; 0
	i32 171, ; 1
	i32 58, ; 2
	i32 193, ; 3
	i32 151, ; 4
	i32 231, ; 5
	i32 194, ; 6
	i32 232, ; 7
	i32 200, ; 8
	i32 132, ; 9
	i32 56, ; 10
	i32 95, ; 11
	i32 217, ; 12
	i32 129, ; 13
	i32 210, ; 14
	i32 145, ; 15
	i32 18, ; 16
	i32 179, ; 17
	i32 204, ; 18
	i32 150, ; 19
	i32 104, ; 20
	i32 246, ; 21
	i32 95, ; 22
	i32 248, ; 23
	i32 36, ; 24
	i32 178, ; 25
	i32 28, ; 26
	i32 188, ; 27
	i32 50, ; 28
	i32 115, ; 29
	i32 70, ; 30
	i32 65, ; 31
	i32 170, ; 32
	i32 180, ; 33
	i32 145, ; 34
	i32 187, ; 35
	i32 219, ; 36
	i32 211, ; 37
	i32 40, ; 38
	i32 89, ; 39
	i32 81, ; 40
	i32 66, ; 41
	i32 62, ; 42
	i32 86, ; 43
	i32 186, ; 44
	i32 106, ; 45
	i32 231, ; 46
	i32 174, ; 47
	i32 102, ; 48
	i32 35, ; 49
	i32 183, ; 50
	i32 119, ; 51
	i32 218, ; 52
	i32 142, ; 53
	i32 141, ; 54
	i32 53, ; 55
	i32 35, ; 56
	i32 141, ; 57
	i32 191, ; 58
	i32 253, ; 59
	i32 173, ; 60
	i32 204, ; 61
	i32 8, ; 62
	i32 14, ; 63
	i32 230, ; 64
	i32 51, ; 65
	i32 215, ; 66
	i32 136, ; 67
	i32 101, ; 68
	i32 198, ; 69
	i32 238, ; 70
	i32 116, ; 71
	i32 182, ; 72
	i32 163, ; 73
	i32 166, ; 74
	i32 67, ; 75
	i32 226, ; 76
	i32 80, ; 77
	i32 101, ; 78
	i32 233, ; 79
	i32 117, ; 80
	i32 244, ; 81
	i32 78, ; 82
	i32 248, ; 83
	i32 114, ; 84
	i32 121, ; 85
	i32 48, ; 86
	i32 128, ; 87
	i32 213, ; 88
	i32 184, ; 89
	i32 82, ; 90
	i32 110, ; 91
	i32 75, ; 92
	i32 254, ; 93
	i32 53, ; 94
	i32 235, ; 95
	i32 69, ; 96
	i32 234, ; 97
	i32 83, ; 98
	i32 172, ; 99
	i32 116, ; 100
	i32 156, ; 101
	i32 167, ; 102
	i32 229, ; 103
	i32 205, ; 104
	i32 32, ; 105
	i32 122, ; 106
	i32 72, ; 107
	i32 62, ; 108
	i32 161, ; 109
	i32 113, ; 110
	i32 88, ; 111
	i32 105, ; 112
	i32 18, ; 113
	i32 146, ; 114
	i32 118, ; 115
	i32 58, ; 116
	i32 200, ; 117
	i32 17, ; 118
	i32 52, ; 119
	i32 92, ; 120
	i32 176, ; 121
	i32 55, ; 122
	i32 129, ; 123
	i32 152, ; 124
	i32 41, ; 125
	i32 92, ; 126
	i32 239, ; 127
	i32 50, ; 128
	i32 162, ; 129
	i32 13, ; 130
	i32 216, ; 131
	i32 190, ; 132
	i32 182, ; 133
	i32 234, ; 134
	i32 36, ; 135
	i32 67, ; 136
	i32 109, ; 137
	i32 0, ; 138
	i32 99, ; 139
	i32 99, ; 140
	i32 11, ; 141
	i32 245, ; 142
	i32 11, ; 143
	i32 242, ; 144
	i32 221, ; 145
	i32 25, ; 146
	i32 128, ; 147
	i32 76, ; 148
	i32 109, ; 149
	i32 222, ; 150
	i32 238, ; 151
	i32 236, ; 152
	i32 106, ; 153
	i32 2, ; 154
	i32 26, ; 155
	i32 196, ; 156
	i32 157, ; 157
	i32 21, ; 158
	i32 49, ; 159
	i32 43, ; 160
	i32 126, ; 161
	i32 185, ; 162
	i32 59, ; 163
	i32 177, ; 164
	i32 119, ; 165
	i32 241, ; 166
	i32 195, ; 167
	i32 3, ; 168
	i32 226, ; 169
	i32 214, ; 170
	i32 38, ; 171
	i32 124, ; 172
	i32 246, ; 173
	i32 243, ; 174
	i32 176, ; 175
	i32 137, ; 176
	i32 149, ; 177
	i32 85, ; 178
	i32 90, ; 179
	i32 217, ; 180
	i32 255, ; 181
	i32 215, ; 182
	i32 191, ; 183
	i32 202, ; 184
	i32 133, ; 185
	i32 210, ; 186
	i32 96, ; 187
	i32 3, ; 188
	i32 105, ; 189
	i32 33, ; 190
	i32 154, ; 191
	i32 158, ; 192
	i32 155, ; 193
	i32 82, ; 194
	i32 212, ; 195
	i32 143, ; 196
	i32 87, ; 197
	i32 19, ; 198
	i32 209, ; 199
	i32 51, ; 200
	i32 61, ; 201
	i32 54, ; 202
	i32 4, ; 203
	i32 97, ; 204
	i32 17, ; 205
	i32 155, ; 206
	i32 84, ; 207
	i32 29, ; 208
	i32 244, ; 209
	i32 45, ; 210
	i32 242, ; 211
	i32 64, ; 212
	i32 66, ; 213
	i32 172, ; 214
	i32 1, ; 215
	i32 251, ; 216
	i32 47, ; 217
	i32 24, ; 218
	i32 187, ; 219
	i32 165, ; 220
	i32 108, ; 221
	i32 12, ; 222
	i32 213, ; 223
	i32 63, ; 224
	i32 27, ; 225
	i32 23, ; 226
	i32 93, ; 227
	i32 168, ; 228
	i32 12, ; 229
	i32 252, ; 230
	i32 29, ; 231
	i32 103, ; 232
	i32 14, ; 233
	i32 126, ; 234
	i32 197, ; 235
	i32 225, ; 236
	i32 91, ; 237
	i32 216, ; 238
	i32 9, ; 239
	i32 86, ; 240
	i32 207, ; 241
	i32 236, ; 242
	i32 71, ; 243
	i32 168, ; 244
	i32 1, ; 245
	i32 224, ; 246
	i32 5, ; 247
	i32 44, ; 248
	i32 27, ; 249
	i32 158, ; 250
	i32 228, ; 251
	i32 112, ; 252
	i32 253, ; 253
	i32 121, ; 254
	i32 241, ; 255
	i32 186, ; 256
	i32 159, ; 257
	i32 131, ; 258
	i32 57, ; 259
	i32 138, ; 260
	i32 83, ; 261
	i32 30, ; 262
	i32 198, ; 263
	i32 10, ; 264
	i32 222, ; 265
	i32 171, ; 266
	i32 195, ; 267
	i32 150, ; 268
	i32 94, ; 269
	i32 207, ; 270
	i32 60, ; 271
	i32 157, ; 272
	i32 64, ; 273
	i32 88, ; 274
	i32 79, ; 275
	i32 47, ; 276
	i32 143, ; 277
	i32 202, ; 278
	i32 74, ; 279
	i32 91, ; 280
	i32 250, ; 281
	i32 135, ; 282
	i32 90, ; 283
	i32 235, ; 284
	i32 254, ; 285
	i32 199, ; 286
	i32 112, ; 287
	i32 42, ; 288
	i32 159, ; 289
	i32 181, ; 290
	i32 4, ; 291
	i32 103, ; 292
	i32 70, ; 293
	i32 60, ; 294
	i32 39, ; 295
	i32 188, ; 296
	i32 153, ; 297
	i32 56, ; 298
	i32 34, ; 299
	i32 185, ; 300
	i32 21, ; 301
	i32 163, ; 302
	i32 240, ; 303
	i32 140, ; 304
	i32 89, ; 305
	i32 194, ; 306
	i32 147, ; 307
	i32 201, ; 308
	i32 162, ; 309
	i32 227, ; 310
	i32 6, ; 311
	i32 169, ; 312
	i32 31, ; 313
	i32 107, ; 314
	i32 240, ; 315
	i32 212, ; 316
	i32 183, ; 317
	i32 233, ; 318
	i32 167, ; 319
	i32 209, ; 320
	i32 140, ; 321
	i32 59, ; 322
	i32 175, ; 323
	i32 144, ; 324
	i32 175, ; 325
	i32 81, ; 326
	i32 74, ; 327
	i32 130, ; 328
	i32 25, ; 329
	i32 7, ; 330
	i32 93, ; 331
	i32 237, ; 332
	i32 137, ; 333
	i32 113, ; 334
	i32 9, ; 335
	i32 180, ; 336
	i32 104, ; 337
	i32 19, ; 338
	i32 208, ; 339
	i32 220, ; 340
	i32 255, ; 341
	i32 203, ; 342
	i32 33, ; 343
	i32 192, ; 344
	i32 46, ; 345
	i32 30, ; 346
	i32 193, ; 347
	i32 57, ; 348
	i32 134, ; 349
	i32 114, ; 350
	i32 55, ; 351
	i32 6, ; 352
	i32 77, ; 353
	i32 111, ; 354
	i32 206, ; 355
	i32 102, ; 356
	i32 170, ; 357
	i32 115, ; 358
	i32 237, ; 359
	i32 197, ; 360
	i32 76, ; 361
	i32 249, ; 362
	i32 85, ; 363
	i32 251, ; 364
	i32 189, ; 365
	i32 229, ; 366
	i32 160, ; 367
	i32 2, ; 368
	i32 24, ; 369
	i32 32, ; 370
	i32 117, ; 371
	i32 37, ; 372
	i32 16, ; 373
	i32 52, ; 374
	i32 20, ; 375
	i32 123, ; 376
	i32 154, ; 377
	i32 208, ; 378
	i32 245, ; 379
	i32 131, ; 380
	i32 192, ; 381
	i32 148, ; 382
	i32 173, ; 383
	i32 120, ; 384
	i32 28, ; 385
	i32 132, ; 386
	i32 100, ; 387
	i32 134, ; 388
	i32 227, ; 389
	i32 153, ; 390
	i32 97, ; 391
	i32 125, ; 392
	i32 69, ; 393
	i32 72, ; 394
	i32 214, ; 395
	i32 230, ; 396
	i32 136, ; 397
	i32 124, ; 398
	i32 71, ; 399
	i32 111, ; 400
	i32 221, ; 401
	i32 152, ; 402
	i32 249, ; 403
	i32 118, ; 404
	i32 201, ; 405
	i32 127, ; 406
	i32 133, ; 407
	i32 77, ; 408
	i32 46, ; 409
	i32 203, ; 410
	i32 73, ; 411
	i32 63, ; 412
	i32 177, ; 413
	i32 98, ; 414
	i32 84, ; 415
	i32 43, ; 416
	i32 61, ; 417
	i32 228, ; 418
	i32 37, ; 419
	i32 40, ; 420
	i32 252, ; 421
	i32 160, ; 422
	i32 98, ; 423
	i32 199, ; 424
	i32 135, ; 425
	i32 20, ; 426
	i32 65, ; 427
	i32 125, ; 428
	i32 75, ; 429
	i32 219, ; 430
	i32 164, ; 431
	i32 156, ; 432
	i32 5, ; 433
	i32 49, ; 434
	i32 232, ; 435
	i32 247, ; 436
	i32 144, ; 437
	i32 139, ; 438
	i32 100, ; 439
	i32 123, ; 440
	i32 120, ; 441
	i32 142, ; 442
	i32 39, ; 443
	i32 68, ; 444
	i32 41, ; 445
	i32 164, ; 446
	i32 73, ; 447
	i32 165, ; 448
	i32 127, ; 449
	i32 68, ; 450
	i32 169, ; 451
	i32 196, ; 452
	i32 225, ; 453
	i32 151, ; 454
	i32 45, ; 455
	i32 108, ; 456
	i32 178, ; 457
	i32 48, ; 458
	i32 96, ; 459
	i32 31, ; 460
	i32 23, ; 461
	i32 166, ; 462
	i32 22, ; 463
	i32 138, ; 464
	i32 78, ; 465
	i32 54, ; 466
	i32 10, ; 467
	i32 184, ; 468
	i32 223, ; 469
	i32 211, ; 470
	i32 16, ; 471
	i32 139, ; 472
	i32 13, ; 473
	i32 15, ; 474
	i32 122, ; 475
	i32 87, ; 476
	i32 149, ; 477
	i32 22, ; 478
	i32 34, ; 479
	i32 79, ; 480
	i32 147, ; 481
	i32 80, ; 482
	i32 190, ; 483
	i32 42, ; 484
	i32 26, ; 485
	i32 220, ; 486
	i32 218, ; 487
	i32 107, ; 488
	i32 110, ; 489
	i32 7, ; 490
	i32 243, ; 491
	i32 250, ; 492
	i32 247, ; 493
	i32 44, ; 494
	i32 161, ; 495
	i32 148, ; 496
	i32 0, ; 497
	i32 189, ; 498
	i32 223, ; 499
	i32 38, ; 500
	i32 15, ; 501
	i32 146, ; 502
	i32 8, ; 503
	i32 206, ; 504
	i32 181, ; 505
	i32 224, ; 506
	i32 130, ; 507
	i32 174, ; 508
	i32 179, ; 509
	i32 239, ; 510
	i32 94 ; 511
], align 16

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

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
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 16

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ f1b7113872c8db3dfee70d11925e81bb752dc8d0"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}

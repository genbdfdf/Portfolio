; ModuleID = 'marshal_methods.arm64-v8a.ll'
source_filename = "marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [93 x ptr] zeroinitializer, align 8

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [186 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 92
	i64 196720943101637631, ; 1: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 53
	i64 232391251801502327, ; 2: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 22
	i64 720058930071658100, ; 3: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 16
	i64 750875890346172408, ; 4: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 82
	i64 799765834175365804, ; 5: System.ComponentModel.dll => 0xb1956c9f18442ac => 41
	i64 870603111519317375, ; 6: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 4
	i64 872800313462103108, ; 7: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 14
	i64 996343623809489702, ; 8: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 29
	i64 1120440138749646132, ; 9: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 31
	i64 1268860745194512059, ; 10: System.Drawing.dll => 0x119be62002c19ebb => 48
	i64 1301485588176585670, ; 11: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 3
	i64 1425944114962822056, ; 12: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 77
	i64 1476839205573959279, ; 13: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 59
	i64 1513467482682125403, ; 14: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 91
	i64 1518315023656898250, ; 15: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 5
	i64 1537168428375924959, ; 16: System.Threading.Thread.dll => 0x15551e8a954ae0df => 82
	i64 1624659445732251991, ; 17: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 8
	i64 1743969030606105336, ; 18: System.Memory.dll => 0x1833d297e88f2af8 => 55
	i64 1767386781656293639, ; 19: System.Private.Uri.dll => 0x188704e9f5582107 => 69
	i64 1795316252682057001, ; 20: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 7
	i64 1825687700144851180, ; 21: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 72
	i64 1836611346387731153, ; 22: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 22
	i64 1875417405349196092, ; 23: System.Drawing.Primitives => 0x1a06d2319b6c713c => 47
	i64 1981742497975770890, ; 24: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 19
	i64 2102659300918482391, ; 25: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 47
	i64 2165725771938924357, ; 26: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 9
	i64 2262844636196693701, ; 27: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 14
	i64 2287834202362508563, ; 28: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 35
	i64 2329709569556905518, ; 29: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 18
	i64 2470498323731680442, ; 30: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 11
	i64 2497223385847772520, ; 31: System.Runtime => 0x22a7eb7046413568 => 78
	i64 2547086958574651984, ; 32: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 6
	i64 2592350477072141967, ; 33: System.Xml.dll => 0x23f9e10627330e8f => 85
	i64 2624866290265602282, ; 34: mscorlib.dll => 0x246d65fbde2db8ea => 87
	i64 2632269733008246987, ; 35: System.Net.NameResolution => 0x2487b36034f808cb => 57
	i64 2960931600190307745, ; 36: Xamarin.Forms.Core => 0x2917579a49927da1 => 27
	i64 3017704767998173186, ; 37: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 31
	i64 3289520064315143713, ; 38: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 17
	i64 3325875462027654285, ; 39: System.Runtime.Numerics => 0x2e27e21c8958b48d => 74
	i64 3328853167529574890, ; 40: System.Net.Sockets.dll => 0x2e327651a008c1ea => 63
	i64 3344514922410554693, ; 41: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 33
	i64 3522470458906976663, ; 42: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 23
	i64 3531994851595924923, ; 43: System.Numerics => 0x31042a9aade235bb => 66
	i64 3551103847008531295, ; 44: System.Private.CoreLib.dll => 0x31480e226177735f => 89
	i64 3571415421602489686, ; 45: System.Runtime.dll => 0x319037675df7e556 => 78
	i64 3716579019761409177, ; 46: netstandard.dll => 0x3393f0ed5c8c5c99 => 88
	i64 3727469159507183293, ; 47: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 21
	i64 3933965368022646939, ; 48: System.Net.Requests => 0x369840a8bfadc09b => 60
	i64 3966267475168208030, ; 49: System.Memory => 0x370b03412596249e => 55
	i64 4009997192427317104, ; 50: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 76
	i64 4073500526318903918, ; 51: System.Private.Xml.dll => 0x3887fb25779ae26e => 71
	i64 4154383907710350974, ; 52: System.ComponentModel => 0x39a7562737acb67e => 41
	i64 4187479170553454871, ; 53: System.Linq.Expressions => 0x3a1cea1e912fa117 => 53
	i64 4205801962323029395, ; 54: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 40
	i64 4235503420553921860, ; 55: System.IO.IsolatedStorage.dll => 0x3ac787eb9b118544 => 52
	i64 4337444564132831293, ; 56: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 2
	i64 4794310189461587505, ; 57: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 6
	i64 4795410492532947900, ; 58: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 23
	i64 4809057822547766521, ; 59: System.Drawing => 0x42bd349c3145ecf9 => 48
	i64 4814660307502931973, ; 60: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 57
	i64 5003780535402192099, ; 61: UniversityAndroidApp => 0x4570ffe2c2a95ce3 => 34
	i64 5103417709280584325, ; 62: System.Collections.Specialized => 0x46d2fb5e161b6285 => 37
	i64 5142919913060024034, ; 63: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 28
	i64 5182934613077526976, ; 64: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 37
	i64 5203618020066742981, ; 65: Xamarin.Essentials => 0x4836f704f0e652c5 => 25
	i64 5278787618751394462, ; 66: System.Net.WebClient.dll => 0x4942055efc68329e => 64
	i64 5423376490970181369, ; 67: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 72
	i64 5507995362134886206, ; 68: System.Core.dll => 0x4c705499688c873e => 43
	i64 5570799893513421663, ; 69: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 50
	i64 5573260873512690141, ; 70: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 79
	i64 5979151488806146654, ; 71: System.Formats.Asn1 => 0x52fa3699a489d25e => 49
	i64 6085203216496545422, ; 72: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 29
	i64 6086316965293125504, ; 73: FormsViewGroup.dll => 0x5476f10882baef80 => 26
	i64 6183170893902868313, ; 74: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 2
	i64 6278736998281604212, ; 75: System.Private.DataContractSerialization => 0x57228e08a4ad6c74 => 68
	i64 6357457916754632952, ; 76: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 0
	i64 6401687960814735282, ; 77: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 18
	i64 6504860066809920875, ; 78: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 9
	i64 6659513131007730089, ; 79: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 16
	i64 6786606130239981554, ; 80: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 46
	i64 6876862101832370452, ; 81: System.Xml.Linq => 0x5f6f85a57d108914 => 84
	i64 7083547580668757502, ; 82: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 70
	i64 7270811800166795866, ; 83: System.Linq => 0x64e71ccf51a90a5a => 54
	i64 7377312882064240630, ; 84: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 40
	i64 7488575175965059935, ; 85: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 84
	i64 7489048572193775167, ; 86: System.ObjectModel => 0x67ee71ff6b419e3f => 67
	i64 7635363394907363464, ; 87: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 27
	i64 7637365915383206639, ; 88: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 25
	i64 7654504624184590948, ; 89: System.Net.Http => 0x6a3a4366801b8264 => 56
	i64 7714652370974252055, ; 90: System.Private.CoreLib => 0x6b0ff375198b9c17 => 89
	i64 7735352534559001595, ; 91: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 32
	i64 7836164640616011524, ; 92: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 8
	i64 8064050204834738623, ; 93: System.Collections.dll => 0x6fe942efa61731bf => 38
	i64 8083354569033831015, ; 94: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 17
	i64 8087206902342787202, ; 95: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 44
	i64 8167236081217502503, ; 96: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 90
	i64 8185542183669246576, ; 97: System.Collections => 0x7198e33f4794aa70 => 38
	i64 8368701292315763008, ; 98: System.Security.Cryptography => 0x7423997c6fd56140 => 79
	i64 8563666267364444763, ; 99: System.Private.Uri => 0x76d841191140ca5b => 69
	i64 8626175481042262068, ; 100: Java.Interop => 0x77b654e585b55834 => 90
	i64 8725526185868997716, ; 101: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 44
	i64 9324707631942237306, ; 102: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 7
	i64 9659729154652888475, ; 103: System.Text.RegularExpressions => 0x860e407c9991dd9b => 80
	i64 9662334977499516867, ; 104: System.Numerics.dll => 0x8617827802b0cfc3 => 66
	i64 9667360217193089419, ; 105: System.Diagnostics.StackTrace => 0x86295ce5cd89898b => 45
	i64 9678050649315576968, ; 106: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 11
	i64 9702891218465930390, ; 107: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 36
	i64 9808709177481450983, ; 108: Mono.Android.dll => 0x881f890734e555e7 => 92
	i64 10038780035334861115, ; 109: System.Net.Http.dll => 0x8b50e941206af13b => 56
	i64 10051358222726253779, ; 110: System.Private.Xml => 0x8b7d990c97ccccd3 => 71
	i64 10236703004850800690, ; 111: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 62
	i64 10406448008575299332, ; 112: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 33
	i64 10430153318873392755, ; 113: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 12
	i64 10785150219063592792, ; 114: System.Net.Primitives => 0x95ac8cfb68830758 => 59
	i64 11023048688141570732, ; 115: System.Core => 0x98f9bc61168392ac => 43
	i64 11037814507248023548, ; 116: System.Xml => 0x992e31d0412bf7fc => 85
	i64 11162124722117608902, ; 117: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 24
	i64 11340910727871153756, ; 118: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 13
	i64 11485890710487134646, ; 119: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 73
	i64 11529969570048099689, ; 120: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 24
	i64 11597940890313164233, ; 121: netstandard => 0xa0f429ca8d1805c9 => 88
	i64 11739066727115742305, ; 122: SQLite-net.dll => 0xa2e98afdf8575c61 => 1
	i64 11806260347154423189, ; 123: SQLite-net => 0xa3d8433bc5eb5d95 => 1
	i64 12040886584167504988, ; 124: System.Net.ServicePoint => 0xa719d28d8e121c5c => 62
	i64 12201331334810686224, ; 125: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 76
	i64 12279246230491828964, ; 126: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 5
	i64 12451044538927396471, ; 127: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 15
	i64 12466513435562512481, ; 128: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 20
	i64 12475113361194491050, ; 129: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 0
	i64 12517810545449516888, ; 130: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 46
	i64 12538491095302438457, ; 131: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 10
	i64 12550732019250633519, ; 132: System.IO.Compression => 0xae2d28465e8e1b2f => 51
	i64 12699999919562409296, ; 133: System.Diagnostics.StackTrace.dll => 0xb03f76a3ad01c550 => 45
	i64 12859557719246324186, ; 134: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 65
	i64 13068258254871114833, ; 135: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 75
	i64 13343850469010654401, ; 136: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 91
	i64 13370592475155966277, ; 137: System.Runtime.Serialization => 0xb98de304062ea945 => 77
	i64 13431476299110033919, ; 138: System.Net.WebClient => 0xba663087f18829ff => 64
	i64 13463706743370286408, ; 139: System.Private.DataContractSerialization.dll => 0xbad8b1f3069e0548 => 68
	i64 13465488254036897740, ; 140: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 32
	i64 13572454107664307259, ; 141: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 21
	i64 13717397318615465333, ; 142: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 39
	i64 13768883594457632599, ; 143: System.IO.IsolatedStorage => 0xbf14e6adb159cf57 => 52
	i64 13881769479078963060, ; 144: System.Console.dll => 0xc0a5f3cade5c6774 => 42
	i64 13959074834287824816, ; 145: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 15
	i64 13967638549803255703, ; 146: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 28
	i64 14124974489674258913, ; 147: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 10
	i64 14125464355221830302, ; 148: System.Threading.dll => 0xc407bafdbc707a9e => 83
	i64 14461014870687870182, ; 149: System.Net.Requests.dll => 0xc8afd8683afdece6 => 60
	i64 14622043554576106986, ; 150: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 75
	i64 14852515768018889994, ; 151: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 13
	i64 14984936317414011727, ; 152: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 65
	i64 14987728460634540364, ; 153: System.IO.Compression.dll => 0xcfff1ba06622494c => 51
	i64 15015154896917945444, ; 154: System.Net.Security.dll => 0xd0608bd33642dc64 => 61
	i64 15076659072870671916, ; 155: System.ObjectModel.dll => 0xd13b0d8c1620662c => 67
	i64 15115185479366240210, ; 156: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 50
	i64 15133485256822086103, ; 157: System.Linq.dll => 0xd204f0a9127dd9d7 => 54
	i64 15370334346939861994, ; 158: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 12
	i64 15527772828719725935, ; 159: System.Console => 0xd77dbb1e38cd3d6f => 42
	i64 15557562860424774966, ; 160: System.Net.Sockets => 0xd7e790fe7a6dc536 => 63
	i64 15609085926864131306, ; 161: System.dll => 0xd89e9cf3334914ea => 86
	i64 15810740023422282496, ; 162: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 30
	i64 15847085070278954535, ; 163: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 81
	i64 16018552496348375205, ; 164: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 58
	i64 16154507427712707110, ; 165: System => 0xe03056ea4e39aa26 => 86
	i64 16219561732052121626, ; 166: System.Net.Security => 0xe1177575db7c781a => 61
	i64 16454459195343277943, ; 167: System.Net.NetworkInformation => 0xe459fb756d988f77 => 58
	i64 16755018182064898362, ; 168: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 3
	i64 16833383113903931215, ; 169: mscorlib => 0xe99c30c1484d7f4f => 87
	i64 16890310621557459193, ; 170: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 80
	i64 17008137082415910100, ; 171: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 36
	i64 17062143951396181894, ; 172: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 39
	i64 17118171214553292978, ; 173: System.Threading.Channels => 0xed8ff6060fc420b2 => 81
	i64 17230721278011714856, ; 174: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 70
	i64 17704177640604968747, ; 175: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 20
	i64 17710060891934109755, ; 176: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 19
	i64 17712670374920797664, ; 177: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 73
	i64 17777860260071588075, ; 178: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 74
	i64 17882897186074144999, ; 179: FormsViewGroup => 0xf82cd03e3ac830e7 => 26
	i64 17892495832318972303, ; 180: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 30
	i64 18025913125965088385, ; 181: System.Threading => 0xfa28e87b91334681 => 83
	i64 18075302676416259632, ; 182: UniversityAndroidApp.dll => 0xfad8600463756630 => 34
	i64 18146411883821974900, ; 183: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 49
	i64 18245806341561545090, ; 184: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 35
	i64 18370042311372477656 ; 185: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 4
], align 8

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [186 x i32] [
	i32 92, ; 0
	i32 53, ; 1
	i32 22, ; 2
	i32 16, ; 3
	i32 82, ; 4
	i32 41, ; 5
	i32 4, ; 6
	i32 14, ; 7
	i32 29, ; 8
	i32 31, ; 9
	i32 48, ; 10
	i32 3, ; 11
	i32 77, ; 12
	i32 59, ; 13
	i32 91, ; 14
	i32 5, ; 15
	i32 82, ; 16
	i32 8, ; 17
	i32 55, ; 18
	i32 69, ; 19
	i32 7, ; 20
	i32 72, ; 21
	i32 22, ; 22
	i32 47, ; 23
	i32 19, ; 24
	i32 47, ; 25
	i32 9, ; 26
	i32 14, ; 27
	i32 35, ; 28
	i32 18, ; 29
	i32 11, ; 30
	i32 78, ; 31
	i32 6, ; 32
	i32 85, ; 33
	i32 87, ; 34
	i32 57, ; 35
	i32 27, ; 36
	i32 31, ; 37
	i32 17, ; 38
	i32 74, ; 39
	i32 63, ; 40
	i32 33, ; 41
	i32 23, ; 42
	i32 66, ; 43
	i32 89, ; 44
	i32 78, ; 45
	i32 88, ; 46
	i32 21, ; 47
	i32 60, ; 48
	i32 55, ; 49
	i32 76, ; 50
	i32 71, ; 51
	i32 41, ; 52
	i32 53, ; 53
	i32 40, ; 54
	i32 52, ; 55
	i32 2, ; 56
	i32 6, ; 57
	i32 23, ; 58
	i32 48, ; 59
	i32 57, ; 60
	i32 34, ; 61
	i32 37, ; 62
	i32 28, ; 63
	i32 37, ; 64
	i32 25, ; 65
	i32 64, ; 66
	i32 72, ; 67
	i32 43, ; 68
	i32 50, ; 69
	i32 79, ; 70
	i32 49, ; 71
	i32 29, ; 72
	i32 26, ; 73
	i32 2, ; 74
	i32 68, ; 75
	i32 0, ; 76
	i32 18, ; 77
	i32 9, ; 78
	i32 16, ; 79
	i32 46, ; 80
	i32 84, ; 81
	i32 70, ; 82
	i32 54, ; 83
	i32 40, ; 84
	i32 84, ; 85
	i32 67, ; 86
	i32 27, ; 87
	i32 25, ; 88
	i32 56, ; 89
	i32 89, ; 90
	i32 32, ; 91
	i32 8, ; 92
	i32 38, ; 93
	i32 17, ; 94
	i32 44, ; 95
	i32 90, ; 96
	i32 38, ; 97
	i32 79, ; 98
	i32 69, ; 99
	i32 90, ; 100
	i32 44, ; 101
	i32 7, ; 102
	i32 80, ; 103
	i32 66, ; 104
	i32 45, ; 105
	i32 11, ; 106
	i32 36, ; 107
	i32 92, ; 108
	i32 56, ; 109
	i32 71, ; 110
	i32 62, ; 111
	i32 33, ; 112
	i32 12, ; 113
	i32 59, ; 114
	i32 43, ; 115
	i32 85, ; 116
	i32 24, ; 117
	i32 13, ; 118
	i32 73, ; 119
	i32 24, ; 120
	i32 88, ; 121
	i32 1, ; 122
	i32 1, ; 123
	i32 62, ; 124
	i32 76, ; 125
	i32 5, ; 126
	i32 15, ; 127
	i32 20, ; 128
	i32 0, ; 129
	i32 46, ; 130
	i32 10, ; 131
	i32 51, ; 132
	i32 45, ; 133
	i32 65, ; 134
	i32 75, ; 135
	i32 91, ; 136
	i32 77, ; 137
	i32 64, ; 138
	i32 68, ; 139
	i32 32, ; 140
	i32 21, ; 141
	i32 39, ; 142
	i32 52, ; 143
	i32 42, ; 144
	i32 15, ; 145
	i32 28, ; 146
	i32 10, ; 147
	i32 83, ; 148
	i32 60, ; 149
	i32 75, ; 150
	i32 13, ; 151
	i32 65, ; 152
	i32 51, ; 153
	i32 61, ; 154
	i32 67, ; 155
	i32 50, ; 156
	i32 54, ; 157
	i32 12, ; 158
	i32 42, ; 159
	i32 63, ; 160
	i32 86, ; 161
	i32 30, ; 162
	i32 81, ; 163
	i32 58, ; 164
	i32 86, ; 165
	i32 61, ; 166
	i32 58, ; 167
	i32 3, ; 168
	i32 87, ; 169
	i32 80, ; 170
	i32 36, ; 171
	i32 39, ; 172
	i32 81, ; 173
	i32 70, ; 174
	i32 20, ; 175
	i32 19, ; 176
	i32 73, ; 177
	i32 74, ; 178
	i32 26, ; 179
	i32 30, ; 180
	i32 83, ; 181
	i32 34, ; 182
	i32 49, ; 183
	i32 35, ; 184
	i32 4 ; 185
], align 4

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
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" }

; Metadata
!llvm.module.flags = !{!0, !1, !7, !8, !9, !10}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"branch-target-enforcement", i32 0}
!8 = !{i32 1, !"sign-return-address", i32 0}
!9 = !{i32 1, !"sign-return-address-all", i32 0}
!10 = !{i32 1, !"sign-return-address-with-bkey", i32 0}

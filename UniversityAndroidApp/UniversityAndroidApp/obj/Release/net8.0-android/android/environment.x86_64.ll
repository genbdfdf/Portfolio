; ModuleID = 'environment.x86_64.ll'
source_filename = "environment.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.ApplicationConfig = type {
	i8, ; bool uses_mono_llvm
	i8, ; bool uses_mono_aot
	i8, ; bool aot_lazy_load
	i8, ; bool uses_assembly_preload
	i8, ; bool broken_exception_transitions
	i8, ; bool instant_run_enabled
	i8, ; bool jni_add_native_method_registration_attribute_present
	i8, ; bool have_runtime_config_blob
	i8, ; bool have_assemblies_blob
	i8, ; bool marshal_methods_enabled
	i8, ; uint8_t bound_stream_io_exception_type
	i32, ; uint32_t package_naming_policy
	i32, ; uint32_t environment_variable_count
	i32, ; uint32_t system_property_count
	i32, ; uint32_t number_of_assemblies_in_apk
	i32, ; uint32_t bundled_assembly_name_width
	i32, ; uint32_t number_of_assembly_store_files
	i32, ; uint32_t number_of_dso_cache_entries
	i32, ; uint32_t android_runtime_jnienv_class_token
	i32, ; uint32_t jnienv_initialize_method_token
	i32, ; uint32_t jnienv_registerjninatives_method_token
	i32, ; uint32_t jni_remapping_replacement_type_count
	i32, ; uint32_t jni_remapping_replacement_method_index_entry_count
	i32, ; uint32_t mono_components_mask
	ptr ; char* android_package_name
}

%struct.AssemblyStoreAssemblyDescriptor = type {
	i32, ; uint32_t data_offset
	i32, ; uint32_t data_size
	i32, ; uint32_t debug_data_offset
	i32, ; uint32_t debug_data_size
	i32, ; uint32_t config_data_offset
	i32 ; uint32_t config_data_size
}

%struct.AssemblyStoreRuntimeData = type {
	ptr, ; uint8_t data_start
	i32, ; uint32_t assembly_count
	ptr ; AssemblyStoreAssemblyDescriptor assemblies
}

%struct.AssemblyStoreSingleAssemblyRuntimeData = type {
	ptr, ; uint8_t image_data
	ptr, ; uint8_t debug_info_data
	ptr, ; uint8_t config_data
	ptr ; AssemblyStoreAssemblyDescriptor descriptor
}

%struct.DSOCacheEntry = type {
	i64, ; uint64_t hash
	i8, ; bool ignore
	ptr, ; char* name
	ptr ; void* handle
}

%struct.XamarinAndroidBundledAssembly = type {
	i32, ; int32_t apk_fd
	i32, ; uint32_t data_offset
	i32, ; uint32_t data_size
	ptr, ; uint8_t data
	i32, ; uint32_t name_length
	ptr ; char* name
}

; 0x15e6972616d58
@format_tag = dso_local local_unnamed_addr constant i64 385281960275288, align 8

@mono_aot_mode_name = dso_local local_unnamed_addr constant ptr @.str.0, align 8

; Application environment variables array, name:value
@app_environment_variables = dso_local local_unnamed_addr constant [8 x ptr] [
	ptr @.env.0, ; 0
	ptr @.env.1, ; 1
	ptr @.env.2, ; 2
	ptr @.env.3, ; 3
	ptr @.env.4, ; 4
	ptr @.env.5, ; 5
	ptr @.env.6, ; 6
	ptr @.env.7 ; 7
], align 16

; System properties defined by the application
@app_system_properties = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@application_config = dso_local local_unnamed_addr constant %struct.ApplicationConfig {
	i8 0, ; bool uses_mono_llvm
	i8 1, ; bool uses_mono_aot
	i8 1, ; bool aot_lazy_load
	i8 0, ; bool uses_assembly_preload
	i8 0, ; bool broken_exception_transitions
	i8 0, ; bool instant_run_enabled
	i8 0, ; bool jni_add_native_method_registration_attribute_present
	i8 1, ; bool have_runtime_config_blob
	i8 1, ; bool have_assemblies_blob
	i8 0, ; bool marshal_methods_enabled
	i8 0, ; uint8_t bound_stream_io_exception_type (0x0)
	i32 3, ; uint32_t package_naming_policy (0x3)
	i32 8, ; uint32_t environment_variable_count (0x8)
	i32 0, ; uint32_t system_property_count (0x0)
	i32 93, ; uint32_t number_of_assemblies_in_apk (0x5d)
	i32 0, ; uint32_t bundled_assembly_name_width (0x0)
	i32 2, ; uint32_t number_of_assembly_store_files (0x2)
	i32 586, ; uint32_t number_of_dso_cache_entries (0x24a)
	i32 33555251, ; uint32_t android_runtime_jnienv_class_token (0x2000333)
	i32 100672278, ; uint32_t jnienv_initialize_method_token (0x6002316)
	i32 100672277, ; uint32_t jnienv_registerjninatives_method_token (0x6002315)
	i32 0, ; uint32_t jni_remapping_replacement_type_count (0x0)
	i32 0, ; uint32_t jni_remapping_replacement_method_index_entry_count (0x0)
	i32 0, ; uint32_t mono_components_mask (0x0)
	ptr @.ApplicationConfig.0_android_package_name; char* android_package_name
}, align 16

; DSO cache entries
@dso_cache = dso_local local_unnamed_addr global [586 x %struct.DSOCacheEntry] [
	%struct.DSOCacheEntry {
		i64 16604595802139920, ; hash 0x3afdcaba6ced10, from name: libaot-Xamarin.AndroidX.CardView.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.18_name, ; name: libaot-Xamarin.AndroidX.CardView.dll.so
		ptr null; void* handle (0x0)
	}, ; 0
	%struct.DSOCacheEntry {
		i64 84283058636713278, ; hash 0x12b6efeca9fed3e, from name: aot-System.Threading.Channels.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.88_name, ; name: libaot-System.Threading.Channels.dll.so
		ptr null; void* handle (0x0)
	}, ; 1
	%struct.DSOCacheEntry {
		i64 120698629574877762, ; hash 0x1accec39cafe242, from name: Mono.Android
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.98_name, ; name: libaot-Mono.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 2
	%struct.DSOCacheEntry {
		i64 147907448127148234, ; hash 0x20d790a5940d0ca, from name: libaot-Xamarin.KotlinX.Coroutines.Core.Jvm
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.41_name, ; name: libaot-Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so
		ptr null; void* handle (0x0)
	}, ; 3
	%struct.DSOCacheEntry {
		i64 207649564881135132, ; hash 0x2e1b82dd881261c, from name: SQLitePCLRaw.core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.11_name, ; name: libaot-SQLitePCLRaw.core.dll.so
		ptr null; void* handle (0x0)
	}, ; 4
	%struct.DSOCacheEntry {
		i64 221057335580609593, ; hash 0x3115a79ba46cc39, from name: libaot-System.Threading.Thread.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.89_name, ; name: libaot-System.Threading.Thread.dll.so
		ptr null; void* handle (0x0)
	}, ; 5
	%struct.DSOCacheEntry {
		i64 290628453294630638, ; hash 0x4088509d83f66ee, from name: libaot-System.Net.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.66_name, ; name: libaot-System.Net.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 6
	%struct.DSOCacheEntry {
		i64 310829165835334582, ; hash 0x450497abf7233b6, from name: libaot-Xamarin.Google.Android.Material.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.39_name, ; name: libaot-Xamarin.Google.Android.Material.dll.so
		ptr null; void* handle (0x0)
	}, ; 7
	%struct.DSOCacheEntry {
		i64 327393534088447553, ; hash 0x48b22af451a0641, from name: libaot-System.Console.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.49_name, ; name: libaot-System.Console.dll.so
		ptr null; void* handle (0x0)
	}, ; 8
	%struct.DSOCacheEntry {
		i64 338732866619584657, ; hash 0x4b36bbf5c9c3091, from name: libaot-System.Net.WebClient
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.71_name, ; name: libaot-System.Net.WebClient.dll.so
		ptr null; void* handle (0x0)
	}, ; 9
	%struct.DSOCacheEntry {
		i64 379089755283511301, ; hash 0x542cc1fb9a9d805, from name: aot-Xamarin.AndroidX.Legacy.Support.Core.UI
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.24_name, ; name: libaot-Xamarin.AndroidX.Legacy.Support.Core.UI.dll.so
		ptr null; void* handle (0x0)
	}, ; 10
	%struct.DSOCacheEntry {
		i64 402181941873838466, ; hash 0x594d65864778982, from name: aot-SQLitePCLRaw.core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.11_name, ; name: libaot-SQLitePCLRaw.core.dll.so
		ptr null; void* handle (0x0)
	}, ; 11
	%struct.DSOCacheEntry {
		i64 472512565983034901, ; hash 0x68eb3acdf53be15, from name: libaot-System.ComponentModel.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.48_name, ; name: libaot-System.ComponentModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 12
	%struct.DSOCacheEntry {
		i64 483259409837255036, ; hash 0x6b4e1df71b6e97c, from name: libaot-Xamarin.AndroidX.RecyclerView.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.29_name, ; name: libaot-Xamarin.AndroidX.RecyclerView.dll.so
		ptr null; void* handle (0x0)
	}, ; 13
	%struct.DSOCacheEntry {
		i64 544667435434772016, ; hash 0x78f0c2591d00630, from name: libaot-mscorlib.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.94_name, ; name: libaot-mscorlib.dll.so
		ptr null; void* handle (0x0)
	}, ; 14
	%struct.DSOCacheEntry {
		i64 587670444148824379, ; hash 0x827d327c47c993b, from name: aot-Xamarin.Forms.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.35_name, ; name: libaot-Xamarin.Forms.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 15
	%struct.DSOCacheEntry {
		i64 603416640204715261, ; hash 0x85fc43cbaf634fd, from name: libaot-System.Net.NameResolution
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.64_name, ; name: libaot-System.Net.NameResolution.dll.so
		ptr null; void* handle (0x0)
	}, ; 16
	%struct.DSOCacheEntry {
		i64 626497116700919570, ; hash 0x8b1c3ceedc3c712, from name: aot-System.Text.RegularExpressions
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.87_name, ; name: libaot-System.Text.RegularExpressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 17
	%struct.DSOCacheEntry {
		i64 628522906763308403, ; hash 0x8b8f640eed2ad73, from name: libaot-System.ObjectModel.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.74_name, ; name: libaot-System.ObjectModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 18
	%struct.DSOCacheEntry {
		i64 680930311029487832, ; hash 0x973268299b578d8, from name: aot-System.IO.Compression.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.58_name, ; name: libaot-System.IO.Compression.dll.so
		ptr null; void* handle (0x0)
	}, ; 19
	%struct.DSOCacheEntry {
		i64 720058930071658100, ; hash 0x9fe29c82844de74, from name: Xamarin.AndroidX.Legacy.Support.Core.UI
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.24_name, ; name: libaot-Xamarin.AndroidX.Legacy.Support.Core.UI.dll.so
		ptr null; void* handle (0x0)
	}, ; 20
	%struct.DSOCacheEntry {
		i64 739739707383691399, ; hash 0xa44155834db3887, from name: aot-Xamarin.AndroidX.CursorAdapter.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.21_name, ; name: libaot-Xamarin.AndroidX.CursorAdapter.dll.so
		ptr null; void* handle (0x0)
	}, ; 21
	%struct.DSOCacheEntry {
		i64 741027209231504624, ; hash 0xa48a852172494f0, from name: aot-System.Private.DataContractSerialization.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.75_name, ; name: libaot-System.Private.DataContractSerialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 22
	%struct.DSOCacheEntry {
		i64 743359736279824557, ; hash 0xa50f1bddd4978ad, from name: libaot-Xamarin.AndroidX.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.20_name, ; name: libaot-Xamarin.AndroidX.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 23
	%struct.DSOCacheEntry {
		i64 750875890346172408, ; hash 0xa6ba5a4da7d1ff8, from name: System.Threading.Thread
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.89_name, ; name: libaot-System.Threading.Thread.dll.so
		ptr null; void* handle (0x0)
	}, ; 24
	%struct.DSOCacheEntry {
		i64 756290313852954525, ; hash 0xa7ee2089046279d, from name: System.Security.Cryptography.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.86_name, ; name: libaot-System.Security.Cryptography.dll.so
		ptr null; void* handle (0x0)
	}, ; 25
	%struct.DSOCacheEntry {
		i64 771524290733889039, ; hash 0xab5014134c7560f, from name: libaot-System.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.50_name, ; name: libaot-System.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 26
	%struct.DSOCacheEntry {
		i64 822824356401711891, ; hash 0xb6b426483dd0b13, from name: libaot-SQLitePCLRaw.lib.e_sqlite3.android.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.12_name, ; name: libaot-SQLitePCLRaw.lib.e_sqlite3.android.dll.so
		ptr null; void* handle (0x0)
	}, ; 27
	%struct.DSOCacheEntry {
		i64 870603111519317375, ; hash 0xc1500ead2756d7f, from name: SQLitePCLRaw.lib.e_sqlite3.android
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.12_name, ; name: libaot-SQLitePCLRaw.lib.e_sqlite3.android.dll.so
		ptr null; void* handle (0x0)
	}, ; 28
	%struct.DSOCacheEntry {
		i64 872800313462103108, ; hash 0xc1ccf42c3c21c44, from name: Xamarin.AndroidX.DrawerLayout
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.22_name, ; name: libaot-Xamarin.AndroidX.DrawerLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 29
	%struct.DSOCacheEntry {
		i64 883585091389430772, ; hash 0xc431ff58d191bf4, from name: SQLite-net.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.9_name, ; name: libaot-SQLite-net.dll.so
		ptr null; void* handle (0x0)
	}, ; 30
	%struct.DSOCacheEntry {
		i64 926729488379472330, ; hash 0xcdc678f45bce9ca, from name: aot-Java.Interop.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.96_name, ; name: libaot-Java.Interop.dll.so
		ptr null; void* handle (0x0)
	}, ; 31
	%struct.DSOCacheEntry {
		i64 926762996762141689, ; hash 0xcdc86090cfbe3f9, from name: libaot-Xamarin.AndroidX.Lifecycle.Common
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.25_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.Common.dll.so
		ptr null; void* handle (0x0)
	}, ; 32
	%struct.DSOCacheEntry {
		i64 995368324521637483, ; hash 0xdd04237abc9b66b, from name: aot-Xamarin.Forms.Platform.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.37_name, ; name: libaot-Xamarin.Forms.Platform.dll.so
		ptr null; void* handle (0x0)
	}, ; 33
	%struct.DSOCacheEntry {
		i64 996343623809489702, ; hash 0xdd3b93f3b63db26, from name: Xamarin.Forms.Platform
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.37_name, ; name: libaot-Xamarin.Forms.Platform.dll.so
		ptr null; void* handle (0x0)
	}, ; 34
	%struct.DSOCacheEntry {
		i64 1096321628016204463, ; hash 0xf36eab64d7bdaaf, from name: aot-System.Linq.Expressions
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.60_name, ; name: libaot-System.Linq.Expressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 35
	%struct.DSOCacheEntry {
		i64 1097501675994448902, ; hash 0xf3b1bf5a20b8406, from name: libaot-System.Collections
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.45_name, ; name: libaot-System.Collections.dll.so
		ptr null; void* handle (0x0)
	}, ; 36
	%struct.DSOCacheEntry {
		i64 1136601720422326463, ; hash 0xfc6053e24dee0bf, from name: libaot-Xamarin.Kotlin.StdLib.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.40_name, ; name: libaot-Xamarin.Kotlin.StdLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 37
	%struct.DSOCacheEntry {
		i64 1146928578970395727, ; hash 0xfeab5774446244f, from name: aot-System.ComponentModel.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.46_name, ; name: libaot-System.ComponentModel.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 38
	%struct.DSOCacheEntry {
		i64 1181472735908652530, ; hash 0x10656f318fa4e5f2, from name: System.Runtime.Numerics.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.81_name, ; name: libaot-System.Runtime.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 39
	%struct.DSOCacheEntry {
		i64 1195854703356721913, ; hash 0x109887844c8ebaf9, from name: libaot-SQLitePCLRaw.core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.11_name, ; name: libaot-SQLitePCLRaw.core.dll.so
		ptr null; void* handle (0x0)
	}, ; 40
	%struct.DSOCacheEntry {
		i64 1196280833168408863, ; hash 0x109a0b14609c811f, from name: libaot-System.Diagnostics.TraceSource
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.53_name, ; name: libaot-System.Diagnostics.TraceSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 41
	%struct.DSOCacheEntry {
		i64 1200280967012175695, ; hash 0x10a8412e1d6c4f4f, from name: libaot-netstandard.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.95_name, ; name: libaot-netstandard.dll.so
		ptr null; void* handle (0x0)
	}, ; 42
	%struct.DSOCacheEntry {
		i64 1288830572241085177, ; hash 0x11e2d893b217e2f9, from name: aot-_Microsoft.Android.Resource.Designer.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.7_name, ; name: libaot-_Microsoft.Android.Resource.Designer.dll.so
		ptr null; void* handle (0x0)
	}, ; 43
	%struct.DSOCacheEntry {
		i64 1301485588176585670, ; hash 0x120fce3f338e43c6, from name: SQLitePCLRaw.core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.11_name, ; name: libaot-SQLitePCLRaw.core.dll.so
		ptr null; void* handle (0x0)
	}, ; 44
	%struct.DSOCacheEntry {
		i64 1310390983169450822, ; hash 0x122f71a80cb0a346, from name: libaot-Xamarin.AndroidX.ViewPager.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.32_name, ; name: libaot-Xamarin.AndroidX.ViewPager.dll.so
		ptr null; void* handle (0x0)
	}, ; 45
	%struct.DSOCacheEntry {
		i64 1347602760944503386, ; hash 0x12b3a592386eca5a, from name: libaot-Xamarin.AndroidX.AppCompat
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.15_name, ; name: libaot-Xamarin.AndroidX.AppCompat.dll.so
		ptr null; void* handle (0x0)
	}, ; 46
	%struct.DSOCacheEntry {
		i64 1389945145833903457, ; hash 0x134a13bef2b55561, from name: libaot-UniversityAndroidApp
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.8_name, ; name: libaot-UniversityAndroidApp.dll.so
		ptr null; void* handle (0x0)
	}, ; 47
	%struct.DSOCacheEntry {
		i64 1408308371658705060, ; hash 0x138b5100a2ed08a4, from name: libaot-_Microsoft.Android.Resource.Designer.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.7_name, ; name: libaot-_Microsoft.Android.Resource.Designer.dll.so
		ptr null; void* handle (0x0)
	}, ; 48
	%struct.DSOCacheEntry {
		i64 1499327756876432029, ; hash 0x14ceaea6ae80c29d, from name: libSystem.Security.Cryptography.Native.Android
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.3_name, ; name: libSystem.Security.Cryptography.Native.Android.so
		ptr null; void* handle (0x0)
	}, ; 49
	%struct.DSOCacheEntry {
		i64 1513467482682125403, ; hash 0x1500eaa8245f6c5b, from name: Mono.Android.Runtime
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.97_name, ; name: libaot-Mono.Android.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 50
	%struct.DSOCacheEntry {
		i64 1518315023656898250, ; hash 0x151223783a354eca, from name: SQLitePCLRaw.provider.e_sqlite3
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.13_name, ; name: libaot-SQLitePCLRaw.provider.e_sqlite3.dll.so
		ptr null; void* handle (0x0)
	}, ; 51
	%struct.DSOCacheEntry {
		i64 1560574748131067758, ; hash 0x15a8467713cc076e, from name: System.Collections.NonGeneric.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.43_name, ; name: libaot-System.Collections.NonGeneric.dll.so
		ptr null; void* handle (0x0)
	}, ; 52
	%struct.DSOCacheEntry {
		i64 1620383766352397640, ; hash 0x167cc273493e8548, from name: libaot-Xamarin.Forms.Platform
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.37_name, ; name: libaot-Xamarin.Forms.Platform.dll.so
		ptr null; void* handle (0x0)
	}, ; 53
	%struct.DSOCacheEntry {
		i64 1730900776029750156, ; hash 0x18056515c8b3838c, from name: aot-System.Runtime.Numerics.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.81_name, ; name: libaot-System.Runtime.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 54
	%struct.DSOCacheEntry {
		i64 1836611346387731153, ; hash 0x197cf449ebe482d1, from name: Xamarin.AndroidX.SavedState
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.30_name, ; name: libaot-Xamarin.AndroidX.SavedState.dll.so
		ptr null; void* handle (0x0)
	}, ; 55
	%struct.DSOCacheEntry {
		i64 1875417405349196092, ; hash 0x1a06d2319b6c713c, from name: System.Drawing.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.54_name, ; name: libaot-System.Drawing.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 56
	%struct.DSOCacheEntry {
		i64 1893652335120276468, ; hash 0x1a479ac40aeedbf4, from name: libaot-Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.26_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 57
	%struct.DSOCacheEntry {
		i64 1992116407072771784, ; hash 0x1ba56b514acccec8, from name: libaot-SQLite-net
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.9_name, ; name: libaot-SQLite-net.dll.so
		ptr null; void* handle (0x0)
	}, ; 58
	%struct.DSOCacheEntry {
		i64 2010011812825262371, ; hash 0x1be4ff1821c9e923, from name: System.ComponentModel.TypeConverter.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.47_name, ; name: libaot-System.ComponentModel.TypeConverter.dll.so
		ptr null; void* handle (0x0)
	}, ; 59
	%struct.DSOCacheEntry {
		i64 2024202821639637893, ; hash 0x1c1769bdd92c8b85, from name: aot-System.IO.Compression
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.58_name, ; name: libaot-System.IO.Compression.dll.so
		ptr null; void* handle (0x0)
	}, ; 60
	%struct.DSOCacheEntry {
		i64 2054529855940994150, ; hash 0x1c832804c3cc2466, from name: aot-Xamarin.AndroidX.AppCompat
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.15_name, ; name: libaot-Xamarin.AndroidX.AppCompat.dll.so
		ptr null; void* handle (0x0)
	}, ; 61
	%struct.DSOCacheEntry {
		i64 2059885036233362492, ; hash 0x1c962e86d6d50c3c, from name: libaot-Xamarin.AndroidX.Legacy.Support.Core.UI
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.24_name, ; name: libaot-Xamarin.AndroidX.Legacy.Support.Core.UI.dll.so
		ptr null; void* handle (0x0)
	}, ; 62
	%struct.DSOCacheEntry {
		i64 2063968891640723124, ; hash 0x1ca4b0c585b3b6b4, from name: System.Xml.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.92_name, ; name: libaot-System.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 63
	%struct.DSOCacheEntry {
		i64 2165725771938924357, ; hash 0x1e0e341d75540745, from name: Xamarin.AndroidX.Browser
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.17_name, ; name: libaot-Xamarin.AndroidX.Browser.dll.so
		ptr null; void* handle (0x0)
	}, ; 64
	%struct.DSOCacheEntry {
		i64 2169143264332568652, ; hash 0x1e1a584e6979584c, from name: aot-System.Collections.Concurrent.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.42_name, ; name: libaot-System.Collections.Concurrent.dll.so
		ptr null; void* handle (0x0)
	}, ; 65
	%struct.DSOCacheEntry {
		i64 2178726392135891111, ; hash 0x1e3c641c3a0738a7, from name: System.Diagnostics.DiagnosticSource.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.51_name, ; name: libaot-System.Diagnostics.DiagnosticSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 66
	%struct.DSOCacheEntry {
		i64 2188053935818705699, ; hash 0x1e5d877639de8b23, from name: aot-Xamarin.AndroidX.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.20_name, ; name: libaot-Xamarin.AndroidX.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 67
	%struct.DSOCacheEntry {
		i64 2204262165896919438, ; hash 0x1e971cc2de1e798e, from name: Mono.Android.Runtime.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.97_name, ; name: libaot-Mono.Android.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 68
	%struct.DSOCacheEntry {
		i64 2220005773605754997, ; hash 0x1ecf0b7d2f165875, from name: libaot-Xamarin.AndroidX.Legacy.Support.Core.UI.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.24_name, ; name: libaot-Xamarin.AndroidX.Legacy.Support.Core.UI.dll.so
		ptr null; void* handle (0x0)
	}, ; 69
	%struct.DSOCacheEntry {
		i64 2278942814095671648, ; hash 0x1fa06e6a419a0160, from name: System.ObjectModel.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.74_name, ; name: libaot-System.ObjectModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 70
	%struct.DSOCacheEntry {
		i64 2285715472525506263, ; hash 0x1fb87e1cad7f36d7, from name: aot-Xamarin.AndroidX.Legacy.Support.Core.UI.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.24_name, ; name: libaot-Xamarin.AndroidX.Legacy.Support.Core.UI.dll.so
		ptr null; void* handle (0x0)
	}, ; 71
	%struct.DSOCacheEntry {
		i64 2287834202362508563, ; hash 0x1fc00515e8ce7513, from name: System.Collections.Concurrent
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.42_name, ; name: libaot-System.Collections.Concurrent.dll.so
		ptr null; void* handle (0x0)
	}, ; 72
	%struct.DSOCacheEntry {
		i64 2308032427487440447, ; hash 0x2007c743aa78ae3f, from name: libaot-System.Linq.Expressions.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.60_name, ; name: libaot-System.Linq.Expressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 73
	%struct.DSOCacheEntry {
		i64 2316119226167002719, ; hash 0x2024822a3523065f, from name: libaot-System.Net.WebClient.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.71_name, ; name: libaot-System.Net.WebClient.dll.so
		ptr null; void* handle (0x0)
	}, ; 74
	%struct.DSOCacheEntry {
		i64 2331926070505433189, ; hash 0x205caa67f2f2e865, from name: aot-Xamarin.Kotlin.StdLib
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.40_name, ; name: libaot-Xamarin.Kotlin.StdLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 75
	%struct.DSOCacheEntry {
		i64 2333458044347531801, ; hash 0x20621bba679cc219, from name: aot-SQLitePCLRaw.batteries_v2
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.10_name, ; name: libaot-SQLitePCLRaw.batteries_v2.dll.so
		ptr null; void* handle (0x0)
	}, ; 76
	%struct.DSOCacheEntry {
		i64 2383056933276923752, ; hash 0x211251a7a380b768, from name: System.Memory.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.62_name, ; name: libaot-System.Memory.dll.so
		ptr null; void* handle (0x0)
	}, ; 77
	%struct.DSOCacheEntry {
		i64 2470498323731680442, ; hash 0x2248f922dc398cba, from name: Xamarin.AndroidX.CoordinatorLayout
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.19_name, ; name: libaot-Xamarin.AndroidX.CoordinatorLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 78
	%struct.DSOCacheEntry {
		i64 2471278266606390833, ; hash 0x224bbe7d76378e31, from name: libaot-Xamarin.Forms.Platform.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.37_name, ; name: libaot-Xamarin.Forms.Platform.dll.so
		ptr null; void* handle (0x0)
	}, ; 79
	%struct.DSOCacheEntry {
		i64 2476879673203463353, ; hash 0x225fa4f090ad94b9, from name: libaot-System.Runtime.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.85_name, ; name: libaot-System.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 80
	%struct.DSOCacheEntry {
		i64 2497223385847772520, ; hash 0x22a7eb7046413568, from name: System.Runtime
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.85_name, ; name: libaot-System.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 81
	%struct.DSOCacheEntry {
		i64 2516268783161295760, ; hash 0x22eb952063bbc390, from name: _Microsoft.Android.Resource.Designer.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.7_name, ; name: libaot-_Microsoft.Android.Resource.Designer.dll.so
		ptr null; void* handle (0x0)
	}, ; 82
	%struct.DSOCacheEntry {
		i64 2522582145975789087, ; hash 0x23020318b7a1261f, from name: Xamarin.AndroidX.AppCompat.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.15_name, ; name: libaot-Xamarin.AndroidX.AppCompat.dll.so
		ptr null; void* handle (0x0)
	}, ; 83
	%struct.DSOCacheEntry {
		i64 2543609594401387459, ; hash 0x234cb7731191f3c3, from name: aot-System.Threading.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.90_name, ; name: libaot-System.Threading.dll.so
		ptr null; void* handle (0x0)
	}, ; 84
	%struct.DSOCacheEntry {
		i64 2551856100614770128, ; hash 0x236a039a6b0e8dd0, from name: libaot-SQLite-net.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.9_name, ; name: libaot-SQLite-net.dll.so
		ptr null; void* handle (0x0)
	}, ; 85
	%struct.DSOCacheEntry {
		i64 2552433275064631459, ; hash 0x236c108a511d40a3, from name: System.Runtime.InteropServices.RuntimeInformation.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.79_name, ; name: libaot-System.Runtime.InteropServices.RuntimeInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 86
	%struct.DSOCacheEntry {
		i64 2556787638847292301, ; hash 0x237b88cfa39a438d, from name: libaot-Mono.Android.Runtime
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.97_name, ; name: libaot-Mono.Android.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 87
	%struct.DSOCacheEntry {
		i64 2564867392456424521, ; hash 0x23983d4ddf58fc49, from name: libaot-Xamarin.AndroidX.SwipeRefreshLayout.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.31_name, ; name: libaot-Xamarin.AndroidX.SwipeRefreshLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 88
	%struct.DSOCacheEntry {
		i64 2583255201894690065, ; hash 0x23d990eb611ced11, from name: libaot-Xamarin.Forms.Xaml
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.38_name, ; name: libaot-Xamarin.Forms.Xaml.dll.so
		ptr null; void* handle (0x0)
	}, ; 89
	%struct.DSOCacheEntry {
		i64 2607857763146079109, ; hash 0x2430f8d18d111b85, from name: libaot-System.Runtime.Serialization.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.83_name, ; name: libaot-System.Runtime.Serialization.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 90
	%struct.DSOCacheEntry {
		i64 2621972009330107316, ; hash 0x24631da6932363b4, from name: libaot-System.Runtime.InteropServices.RuntimeInformation.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.79_name, ; name: libaot-System.Runtime.InteropServices.RuntimeInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 91
	%struct.DSOCacheEntry {
		i64 2632269733008246987, ; hash 0x2487b36034f808cb, from name: System.Net.NameResolution
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.64_name, ; name: libaot-System.Net.NameResolution.dll.so
		ptr null; void* handle (0x0)
	}, ; 92
	%struct.DSOCacheEntry {
		i64 2685939715526887227, ; hash 0x25465ff0c818073b, from name: Xamarin.Forms.Platform.Android.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.36_name, ; name: libaot-Xamarin.Forms.Platform.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 93
	%struct.DSOCacheEntry {
		i64 2696149129426007350, ; hash 0x256aa55930ea7536, from name: libaot-System.Net.NetworkInformation.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.65_name, ; name: libaot-System.Net.NetworkInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 94
	%struct.DSOCacheEntry {
		i64 2794448935210026949, ; hash 0x26c7e0803e2987c5, from name: aot-System.Net.ServicePoint
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.69_name, ; name: libaot-System.Net.ServicePoint.dll.so
		ptr null; void* handle (0x0)
	}, ; 95
	%struct.DSOCacheEntry {
		i64 2799603620072217830, ; hash 0x26da30a8d64d5ce6, from name: aot-Xamarin.Forms.Platform.Android.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.36_name, ; name: libaot-Xamarin.Forms.Platform.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 96
	%struct.DSOCacheEntry {
		i64 2817487320334772404, ; hash 0x2719b9ca47b8a8b4, from name: aot-SQLitePCLRaw.provider.e_sqlite3.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.13_name, ; name: libaot-SQLitePCLRaw.provider.e_sqlite3.dll.so
		ptr null; void* handle (0x0)
	}, ; 97
	%struct.DSOCacheEntry {
		i64 2837562181765940674, ; hash 0x27610bc5303dc5c2, from name: libaot-_Microsoft.Android.Resource.Designer
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.7_name, ; name: libaot-_Microsoft.Android.Resource.Designer.dll.so
		ptr null; void* handle (0x0)
	}, ; 98
	%struct.DSOCacheEntry {
		i64 2865936624365190494, ; hash 0x27c5da2cec11bd5e, from name: aot-System.ComponentModel.TypeConverter.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.47_name, ; name: libaot-System.ComponentModel.TypeConverter.dll.so
		ptr null; void* handle (0x0)
	}, ; 99
	%struct.DSOCacheEntry {
		i64 2895224535127013735, ; hash 0x282de760093db967, from name: libaot-System.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.93_name, ; name: libaot-System.dll.so
		ptr null; void* handle (0x0)
	}, ; 100
	%struct.DSOCacheEntry {
		i64 2960931600190307745, ; hash 0x2917579a49927da1, from name: Xamarin.Forms.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.35_name, ; name: libaot-Xamarin.Forms.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 101
	%struct.DSOCacheEntry {
		i64 2967592192117877398, ; hash 0x292f01603168aa96, from name: Xamarin.Forms.Platform.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.37_name, ; name: libaot-Xamarin.Forms.Platform.dll.so
		ptr null; void* handle (0x0)
	}, ; 102
	%struct.DSOCacheEntry {
		i64 2978076563348721961, ; hash 0x295440db18511129, from name: libaot-System.Collections.Specialized
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.44_name, ; name: libaot-System.Collections.Specialized.dll.so
		ptr null; void* handle (0x0)
	}, ; 103
	%struct.DSOCacheEntry {
		i64 3017704767998173186, ; hash 0x29e10a7f7d88a002, from name: Xamarin.Google.Android.Material
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.39_name, ; name: libaot-Xamarin.Google.Android.Material.dll.so
		ptr null; void* handle (0x0)
	}, ; 104
	%struct.DSOCacheEntry {
		i64 3023023456770706911, ; hash 0x29f3efd1387dcddf, from name: System.Runtime.Serialization.Formatters.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.82_name, ; name: libaot-System.Runtime.Serialization.Formatters.dll.so
		ptr null; void* handle (0x0)
	}, ; 105
	%struct.DSOCacheEntry {
		i64 3038175307180388234, ; hash 0x2a29c4584dd9af8a, from name: aot-Xamarin.AndroidX.CoordinatorLayout
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.19_name, ; name: libaot-Xamarin.AndroidX.CoordinatorLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 106
	%struct.DSOCacheEntry {
		i64 3064219428148914307, ; hash 0x2a864b55c0aaa883, from name: aot-System.Net.WebClient
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.71_name, ; name: libaot-System.Net.WebClient.dll.so
		ptr null; void* handle (0x0)
	}, ; 107
	%struct.DSOCacheEntry {
		i64 3073412500499229570, ; hash 0x2aa6f462b4806b82, from name: System.Threading.Channels.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.88_name, ; name: libaot-System.Threading.Channels.dll.so
		ptr null; void* handle (0x0)
	}, ; 108
	%struct.DSOCacheEntry {
		i64 3108167353802057239, ; hash 0x2b226dbd91d66617, from name: libaot-Xamarin.AndroidX.SavedState
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.30_name, ; name: libaot-Xamarin.AndroidX.SavedState.dll.so
		ptr null; void* handle (0x0)
	}, ; 109
	%struct.DSOCacheEntry {
		i64 3159715243761782120, ; hash 0x2bd99045f7cecd68, from name: aot-System.Linq.Expressions.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.60_name, ; name: libaot-System.Linq.Expressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 110
	%struct.DSOCacheEntry {
		i64 3207715548900369358, ; hash 0x2c84184be8b423ce, from name: e_sqlite3.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.0_name, ; name: libe_sqlite3.so
		ptr null; void* handle (0x0)
	}, ; 111
	%struct.DSOCacheEntry {
		i64 3228004203549710724, ; hash 0x2ccc2cb86e0c5984, from name: aot-System.Xml.Linq
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.91_name, ; name: libaot-System.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 112
	%struct.DSOCacheEntry {
		i64 3250939353211503980, ; hash 0x2d1da81e1682856c, from name: libaot-Xamarin.AndroidX.Browser.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.17_name, ; name: libaot-Xamarin.AndroidX.Browser.dll.so
		ptr null; void* handle (0x0)
	}, ; 113
	%struct.DSOCacheEntry {
		i64 3260817401620729492, ; hash 0x2d40c02675040e94, from name: libaot-System.Memory
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.62_name, ; name: libaot-System.Memory.dll.so
		ptr null; void* handle (0x0)
	}, ; 114
	%struct.DSOCacheEntry {
		i64 3282577833136852042, ; hash 0x2d8e0f25bbb18c4a, from name: aot-Xamarin.AndroidX.Lifecycle.Common
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.25_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.Common.dll.so
		ptr null; void* handle (0x0)
	}, ; 115
	%struct.DSOCacheEntry {
		i64 3289520064315143713, ; hash 0x2da6b911e3063621, from name: Xamarin.AndroidX.Lifecycle.Common
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.25_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.Common.dll.so
		ptr null; void* handle (0x0)
	}, ; 116
	%struct.DSOCacheEntry {
		i64 3325875462027654285, ; hash 0x2e27e21c8958b48d, from name: System.Runtime.Numerics
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.81_name, ; name: libaot-System.Runtime.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 117
	%struct.DSOCacheEntry {
		i64 3344514922410554693, ; hash 0x2e6a1a9a18463545, from name: Xamarin.KotlinX.Coroutines.Core.Jvm
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.41_name, ; name: libaot-Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so
		ptr null; void* handle (0x0)
	}, ; 118
	%struct.DSOCacheEntry {
		i64 3387343871458221356, ; hash 0x2f02434dde5d1d2c, from name: Xamarin.AndroidX.CoordinatorLayout.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.19_name, ; name: libaot-Xamarin.AndroidX.CoordinatorLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 119
	%struct.DSOCacheEntry {
		i64 3415134081241495173, ; hash 0x2f64fe5a4cbab685, from name: libaot-System.Runtime.Serialization.Formatters.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.82_name, ; name: libaot-System.Runtime.Serialization.Formatters.dll.so
		ptr null; void* handle (0x0)
	}, ; 120
	%struct.DSOCacheEntry {
		i64 3491308886800479652, ; hash 0x30739eef4ee835a4, from name: System.Net.Sockets.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.70_name, ; name: libaot-System.Net.Sockets.dll.so
		ptr null; void* handle (0x0)
	}, ; 121
	%struct.DSOCacheEntry {
		i64 3519863767463074839, ; hash 0x30d911728d679c17, from name: libaot-System.IO.Compression.Brotli
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.57_name, ; name: libaot-System.IO.Compression.Brotli.dll.so
		ptr null; void* handle (0x0)
	}, ; 122
	%struct.DSOCacheEntry {
		i64 3522470458906976663, ; hash 0x30e2543832f52197, from name: Xamarin.AndroidX.SwipeRefreshLayout
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.31_name, ; name: libaot-Xamarin.AndroidX.SwipeRefreshLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 123
	%struct.DSOCacheEntry {
		i64 3531994851595924923, ; hash 0x31042a9aade235bb, from name: System.Numerics
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.73_name, ; name: libaot-System.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 124
	%struct.DSOCacheEntry {
		i64 3657389980202273675, ; hash 0x32c1a8cf2f078b8b, from name: libaot-System.Private.CoreLib
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.99_name, ; name: libaot-System.Private.CoreLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 125
	%struct.DSOCacheEntry {
		i64 3673950514234315711, ; hash 0x32fc7e86fb4cd3bf, from name: System.Runtime.Serialization.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.84_name, ; name: libaot-System.Runtime.Serialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 126
	%struct.DSOCacheEntry {
		i64 3683086715764323178, ; hash 0x331cf3daaa17b36a, from name: aot-System.Net.NameResolution
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.64_name, ; name: libaot-System.Net.NameResolution.dll.so
		ptr null; void* handle (0x0)
	}, ; 127
	%struct.DSOCacheEntry {
		i64 3703096612151080118, ; hash 0x33640abfb837b4b6, from name: libaot-System.Net.Requests
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.67_name, ; name: libaot-System.Net.Requests.dll.so
		ptr null; void* handle (0x0)
	}, ; 128
	%struct.DSOCacheEntry {
		i64 3707216742628388692, ; hash 0x3372adfc59beef54, from name: aot-Xamarin.AndroidX.CardView.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.18_name, ; name: libaot-Xamarin.AndroidX.CardView.dll.so
		ptr null; void* handle (0x0)
	}, ; 129
	%struct.DSOCacheEntry {
		i64 3727469159507183293, ; hash 0x33baa1739ba646bd, from name: Xamarin.AndroidX.RecyclerView
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.29_name, ; name: libaot-Xamarin.AndroidX.RecyclerView.dll.so
		ptr null; void* handle (0x0)
	}, ; 130
	%struct.DSOCacheEntry {
		i64 3750968707670692760, ; hash 0x340e1e2a88515398, from name: aot-Xamarin.Forms.Xaml
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.38_name, ; name: libaot-Xamarin.Forms.Xaml.dll.so
		ptr null; void* handle (0x0)
	}, ; 131
	%struct.DSOCacheEntry {
		i64 3792734155220677803, ; hash 0x34a27f9e916b74ab, from name: libaot-System.Xml
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.92_name, ; name: libaot-System.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 132
	%struct.DSOCacheEntry {
		i64 3926486732424186854, ; hash 0x367daee1356d8be6, from name: aot-Xamarin.AndroidX.DrawerLayout
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.22_name, ; name: libaot-Xamarin.AndroidX.DrawerLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 133
	%struct.DSOCacheEntry {
		i64 3933965368022646939, ; hash 0x369840a8bfadc09b, from name: System.Net.Requests
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.67_name, ; name: libaot-System.Net.Requests.dll.so
		ptr null; void* handle (0x0)
	}, ; 134
	%struct.DSOCacheEntry {
		i64 3943677120668259164, ; hash 0x36bac1725e44535c, from name: aot-System.ObjectModel.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.74_name, ; name: libaot-System.ObjectModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 135
	%struct.DSOCacheEntry {
		i64 3966267475168208030, ; hash 0x370b03412596249e, from name: System.Memory
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.62_name, ; name: libaot-System.Memory.dll.so
		ptr null; void* handle (0x0)
	}, ; 136
	%struct.DSOCacheEntry {
		i64 4009997192427317104, ; hash 0x37a65f335cf1a770, from name: System.Runtime.Serialization.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.83_name, ; name: libaot-System.Runtime.Serialization.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 137
	%struct.DSOCacheEntry {
		i64 4017192615964119979, ; hash 0x37bfef6674dd13ab, from name: aot-System.Runtime.Serialization.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.83_name, ; name: libaot-System.Runtime.Serialization.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 138
	%struct.DSOCacheEntry {
		i64 4086833024669554468, ; hash 0x38b758fba3c39724, from name: aot-UniversityAndroidApp
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.8_name, ; name: libaot-UniversityAndroidApp.dll.so
		ptr null; void* handle (0x0)
	}, ; 139
	%struct.DSOCacheEntry {
		i64 4105760315252337620, ; hash 0x38fa9740e382ebd4, from name: libaot-System.Net.WebHeaderCollection.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.72_name, ; name: libaot-System.Net.WebHeaderCollection.dll.so
		ptr null; void* handle (0x0)
	}, ; 140
	%struct.DSOCacheEntry {
		i64 4115927144641244248, ; hash 0x391eb5ee51baac58, from name: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.26_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 141
	%struct.DSOCacheEntry {
		i64 4154383907710350974, ; hash 0x39a7562737acb67e, from name: System.ComponentModel
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.48_name, ; name: libaot-System.ComponentModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 142
	%struct.DSOCacheEntry {
		i64 4187479170553454871, ; hash 0x3a1cea1e912fa117, from name: System.Linq.Expressions
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.60_name, ; name: libaot-System.Linq.Expressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 143
	%struct.DSOCacheEntry {
		i64 4205801962323029395, ; hash 0x3a5e0299f7e7ad93, from name: System.ComponentModel.TypeConverter
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.47_name, ; name: libaot-System.ComponentModel.TypeConverter.dll.so
		ptr null; void* handle (0x0)
	}, ; 144
	%struct.DSOCacheEntry {
		i64 4243001330476888824, ; hash 0x3ae22b3acc95b2f8, from name: aot-Xamarin.AndroidX.Lifecycle.ViewModel
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.27_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.ViewModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 145
	%struct.DSOCacheEntry {
		i64 4253135428940497963, ; hash 0x3b062c2377a0842b, from name: aot-Xamarin.Forms.Xaml.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.38_name, ; name: libaot-Xamarin.Forms.Xaml.dll.so
		ptr null; void* handle (0x0)
	}, ; 146
	%struct.DSOCacheEntry {
		i64 4411920538413871651, ; hash 0x3d3a4a5ab568b223, from name: aot-netstandard
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.95_name, ; name: libaot-netstandard.dll.so
		ptr null; void* handle (0x0)
	}, ; 147
	%struct.DSOCacheEntry {
		i64 4459893396487739745, ; hash 0x3de4b96a21c31961, from name: libe_sqlite3.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.0_name, ; name: libe_sqlite3.so
		ptr null; void* handle (0x0)
	}, ; 148
	%struct.DSOCacheEntry {
		i64 4472958691645351923, ; hash 0x3e13243b368467f3, from name: aot-mscorlib
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.94_name, ; name: libaot-mscorlib.dll.so
		ptr null; void* handle (0x0)
	}, ; 149
	%struct.DSOCacheEntry {
		i64 4485509010103122468, ; hash 0x3e3fbaadf002ba24, from name: aot-System.Memory.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.62_name, ; name: libaot-System.Memory.dll.so
		ptr null; void* handle (0x0)
	}, ; 150
	%struct.DSOCacheEntry {
		i64 4519937209358600751, ; hash 0x3eba0af1bae3ca2f, from name: aot-Xamarin.AndroidX.Loader
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.28_name, ; name: libaot-Xamarin.AndroidX.Loader.dll.so
		ptr null; void* handle (0x0)
	}, ; 151
	%struct.DSOCacheEntry {
		i64 4533637005954432954, ; hash 0x3eeab6d6307abfba, from name: System.Text.RegularExpressions.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.87_name, ; name: libaot-System.Text.RegularExpressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 152
	%struct.DSOCacheEntry {
		i64 4562889186705488620, ; hash 0x3f52a38a430d3aec, from name: libaot-System.Memory.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.62_name, ; name: libaot-System.Memory.dll.so
		ptr null; void* handle (0x0)
	}, ; 153
	%struct.DSOCacheEntry {
		i64 4600564633383719664, ; hash 0x3fd87d28c30fd2f0, from name: aot-System.Net.NetworkInformation.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.65_name, ; name: libaot-System.Net.NetworkInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 154
	%struct.DSOCacheEntry {
		i64 4619841365973187374, ; hash 0x401cf93ed17cbb2e, from name: libaot-System.Private.Xml.Linq.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.77_name, ; name: libaot-System.Private.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 155
	%struct.DSOCacheEntry {
		i64 4624036676708874426, ; hash 0x402be0dbb79c38ba, from name: aot-Mono.Android.Runtime.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.97_name, ; name: libaot-Mono.Android.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 156
	%struct.DSOCacheEntry {
		i64 4676011426420077172, ; hash 0x40e4879e256fb274, from name: System.Drawing.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.55_name, ; name: libaot-System.Drawing.dll.so
		ptr null; void* handle (0x0)
	}, ; 157
	%struct.DSOCacheEntry {
		i64 4704458384224729820, ; hash 0x414997f9a452badc, from name: libaot-System.Net.WebHeaderCollection
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.72_name, ; name: libaot-System.Net.WebHeaderCollection.dll.so
		ptr null; void* handle (0x0)
	}, ; 158
	%struct.DSOCacheEntry {
		i64 4746643953623332214, ; hash 0x41df7786eaf97576, from name: libaot-mscorlib
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.94_name, ; name: libaot-mscorlib.dll.so
		ptr null; void* handle (0x0)
	}, ; 159
	%struct.DSOCacheEntry {
		i64 4748725187834767676, ; hash 0x41e6dc6604d7693c, from name: libaot-System.Private.DataContractSerialization
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.75_name, ; name: libaot-System.Private.DataContractSerialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 160
	%struct.DSOCacheEntry {
		i64 4778132833905139113, ; hash 0x424f567f2e8bdda9, from name: libaot-System.Runtime.InteropServices.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.80_name, ; name: libaot-System.Runtime.InteropServices.dll.so
		ptr null; void* handle (0x0)
	}, ; 161
	%struct.DSOCacheEntry {
		i64 4794310189461587505, ; hash 0x4288cfb749e4c631, from name: Xamarin.AndroidX.Activity
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.14_name, ; name: libaot-Xamarin.AndroidX.Activity.dll.so
		ptr null; void* handle (0x0)
	}, ; 162
	%struct.DSOCacheEntry {
		i64 4799618160137045028, ; hash 0x429bab49847b8424, from name: aot-System.Runtime.Serialization
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.84_name, ; name: libaot-System.Runtime.Serialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 163
	%struct.DSOCacheEntry {
		i64 4809057822547766521, ; hash 0x42bd349c3145ecf9, from name: System.Drawing
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.55_name, ; name: libaot-System.Drawing.dll.so
		ptr null; void* handle (0x0)
	}, ; 164
	%struct.DSOCacheEntry {
		i64 4821796847100292949, ; hash 0x42ea76af7a82ef55, from name: System.Private.Xml.Linq.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.77_name, ; name: libaot-System.Private.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 165
	%struct.DSOCacheEntry {
		i64 4904118099769380138, ; hash 0x440eed6db9514d2a, from name: Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.41_name, ; name: libaot-Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so
		ptr null; void* handle (0x0)
	}, ; 166
	%struct.DSOCacheEntry {
		i64 4919279375040431948, ; hash 0x4444ca873430c74c, from name: libaot-SQLitePCLRaw.lib.e_sqlite3.android
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.12_name, ; name: libaot-SQLitePCLRaw.lib.e_sqlite3.android.dll.so
		ptr null; void* handle (0x0)
	}, ; 167
	%struct.DSOCacheEntry {
		i64 4942169814716192606, ; hash 0x44961d4301d1175e, from name: aot-Xamarin.AndroidX.RecyclerView.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.29_name, ; name: libaot-Xamarin.AndroidX.RecyclerView.dll.so
		ptr null; void* handle (0x0)
	}, ; 168
	%struct.DSOCacheEntry {
		i64 4949216247540332023, ; hash 0x44af25f47f3bb5f7, from name: libaot-System.Diagnostics.StackTrace.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.52_name, ; name: libaot-System.Diagnostics.StackTrace.dll.so
		ptr null; void* handle (0x0)
	}, ; 169
	%struct.DSOCacheEntry {
		i64 4952410279526942859, ; hash 0x44ba7ee90532488b, from name: aot-System.Diagnostics.StackTrace.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.52_name, ; name: libaot-System.Diagnostics.StackTrace.dll.so
		ptr null; void* handle (0x0)
	}, ; 170
	%struct.DSOCacheEntry {
		i64 5003780535402192099, ; hash 0x4570ffe2c2a95ce3, from name: UniversityAndroidApp
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.8_name, ; name: libaot-UniversityAndroidApp.dll.so
		ptr null; void* handle (0x0)
	}, ; 171
	%struct.DSOCacheEntry {
		i64 5029111617119435182, ; hash 0x45cafe5ed231b9ae, from name: System.Net.WebClient.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.71_name, ; name: libaot-System.Net.WebClient.dll.so
		ptr null; void* handle (0x0)
	}, ; 172
	%struct.DSOCacheEntry {
		i64 5084339791899622993, ; hash 0x468f341a4d8f7e51, from name: aot-System.Xml
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.92_name, ; name: libaot-System.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 173
	%struct.DSOCacheEntry {
		i64 5103417709280584325, ; hash 0x46d2fb5e161b6285, from name: System.Collections.Specialized
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.44_name, ; name: libaot-System.Collections.Specialized.dll.so
		ptr null; void* handle (0x0)
	}, ; 174
	%struct.DSOCacheEntry {
		i64 5161979805990825802, ; hash 0x47a30948c1d2af4a, from name: libaot-Xamarin.Forms.Platform.Android.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.36_name, ; name: libaot-Xamarin.Forms.Platform.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 175
	%struct.DSOCacheEntry {
		i64 5203618020066742981, ; hash 0x4836f704f0e652c5, from name: Xamarin.Essentials
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.33_name, ; name: libaot-Xamarin.Essentials.dll.so
		ptr null; void* handle (0x0)
	}, ; 176
	%struct.DSOCacheEntry {
		i64 5232730255288553603, ; hash 0x489e647167e9d083, from name: aot-System.ComponentModel.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.48_name, ; name: libaot-System.ComponentModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 177
	%struct.DSOCacheEntry {
		i64 5245831624004909525, ; hash 0x48ccf0118452b9d5, from name: libaot-System.Runtime.Serialization.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.83_name, ; name: libaot-System.Runtime.Serialization.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 178
	%struct.DSOCacheEntry {
		i64 5255546469364035812, ; hash 0x48ef73ab370070e4, from name: aot-Xamarin.AndroidX.Activity.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.14_name, ; name: libaot-Xamarin.AndroidX.Activity.dll.so
		ptr null; void* handle (0x0)
	}, ; 179
	%struct.DSOCacheEntry {
		i64 5266401548478623734, ; hash 0x4916044e45a2aff6, from name: aot-Xamarin.Google.Android.Material
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.39_name, ; name: libaot-Xamarin.Google.Android.Material.dll.so
		ptr null; void* handle (0x0)
	}, ; 180
	%struct.DSOCacheEntry {
		i64 5308663384316065149, ; hash 0x49ac2938b648357d, from name: aot-System.Net.ServicePoint.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.69_name, ; name: libaot-System.Net.ServicePoint.dll.so
		ptr null; void* handle (0x0)
	}, ; 181
	%struct.DSOCacheEntry {
		i64 5334205502128732672, ; hash 0x4a06e7a471513a00, from name: aot-System.Runtime
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.85_name, ; name: libaot-System.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 182
	%struct.DSOCacheEntry {
		i64 5355160709108388812, ; hash 0x4a515a4ac588d3cc, from name: libaot-Xamarin.Essentials
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.33_name, ; name: libaot-Xamarin.Essentials.dll.so
		ptr null; void* handle (0x0)
	}, ; 183
	%struct.DSOCacheEntry {
		i64 5384941644731431548, ; hash 0x4abb27e52e6cba7c, from name: aot-Xamarin.Essentials
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.33_name, ; name: libaot-Xamarin.Essentials.dll.so
		ptr null; void* handle (0x0)
	}, ; 184
	%struct.DSOCacheEntry {
		i64 5423376490970181369, ; hash 0x4b43b42f2b7b6ef9, from name: System.Runtime.InteropServices.RuntimeInformation
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.79_name, ; name: libaot-System.Runtime.InteropServices.RuntimeInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 185
	%struct.DSOCacheEntry {
		i64 5479418050698653789, ; hash 0x4c0acdaf97c1b05d, from name: libaot-System.ComponentModel.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.46_name, ; name: libaot-System.ComponentModel.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 186
	%struct.DSOCacheEntry {
		i64 5517008375465427313, ; hash 0x4c9059e31a78c171, from name: SQLitePCLRaw.lib.e_sqlite3.android.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.12_name, ; name: libaot-SQLitePCLRaw.lib.e_sqlite3.android.dll.so
		ptr null; void* handle (0x0)
	}, ; 187
	%struct.DSOCacheEntry {
		i64 5550865768259438606, ; hash 0x4d08a301a8fac80e, from name: aot-FormsViewGroup
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.34_name, ; name: libaot-FormsViewGroup.dll.so
		ptr null; void* handle (0x0)
	}, ; 188
	%struct.DSOCacheEntry {
		i64 5554419957827635904, ; hash 0x4d154385e7a80ac0, from name: libaot-System.Net.Sockets
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.70_name, ; name: libaot-System.Net.Sockets.dll.so
		ptr null; void* handle (0x0)
	}, ; 189
	%struct.DSOCacheEntry {
		i64 5570799893513421663, ; hash 0x4d4f74fcdfa6c35f, from name: System.IO.Compression.Brotli
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.57_name, ; name: libaot-System.IO.Compression.Brotli.dll.so
		ptr null; void* handle (0x0)
	}, ; 190
	%struct.DSOCacheEntry {
		i64 5718066319469868703, ; hash 0x4f5aa7059e20769f, from name: System.Private.DataContractSerialization.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.75_name, ; name: libaot-System.Private.DataContractSerialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 191
	%struct.DSOCacheEntry {
		i64 5753633696766002394, ; hash 0x4fd9035cf77484da, from name: libaot-System.Drawing
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.55_name, ; name: libaot-System.Drawing.dll.so
		ptr null; void* handle (0x0)
	}, ; 192
	%struct.DSOCacheEntry {
		i64 5759268217942071081, ; hash 0x4fed07ee28a25729, from name: aot-Xamarin.AndroidX.AppCompat.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.15_name, ; name: libaot-Xamarin.AndroidX.AppCompat.dll.so
		ptr null; void* handle (0x0)
	}, ; 193
	%struct.DSOCacheEntry {
		i64 5900900230463535802, ; hash 0x51e4357ecbccbaba, from name: System.Security.Cryptography.Native.Android.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.3_name, ; name: libSystem.Security.Cryptography.Native.Android.so
		ptr null; void* handle (0x0)
	}, ; 194
	%struct.DSOCacheEntry {
		i64 5948985717485083712, ; hash 0x528f0afdb0921c40, from name: libSystem.Native.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.2_name, ; name: libSystem.Native.so
		ptr null; void* handle (0x0)
	}, ; 195
	%struct.DSOCacheEntry {
		i64 5958220530006169673, ; hash 0x52afda0108751849, from name: System.Net.Requests.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.67_name, ; name: libaot-System.Net.Requests.dll.so
		ptr null; void* handle (0x0)
	}, ; 196
	%struct.DSOCacheEntry {
		i64 5979151488806146654, ; hash 0x52fa3699a489d25e, from name: System.Formats.Asn1
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.56_name, ; name: libaot-System.Formats.Asn1.dll.so
		ptr null; void* handle (0x0)
	}, ; 197
	%struct.DSOCacheEntry {
		i64 6120656991460866797, ; hash 0x54f0f11ae8093aed, from name: aot-System.Runtime.Serialization.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.84_name, ; name: libaot-System.Runtime.Serialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 198
	%struct.DSOCacheEntry {
		i64 6183170893902868313, ; hash 0x55cf092b0c9d6f59, from name: SQLitePCLRaw.batteries_v2
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.10_name, ; name: libaot-SQLitePCLRaw.batteries_v2.dll.so
		ptr null; void* handle (0x0)
	}, ; 199
	%struct.DSOCacheEntry {
		i64 6278736998281604212, ; hash 0x57228e08a4ad6c74, from name: System.Private.DataContractSerialization
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.75_name, ; name: libaot-System.Private.DataContractSerialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 200
	%struct.DSOCacheEntry {
		i64 6308061292769401015, ; hash 0x578abc5300e958b7, from name: libSystem.Native
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.2_name, ; name: libSystem.Native.so
		ptr null; void* handle (0x0)
	}, ; 201
	%struct.DSOCacheEntry {
		i64 6309031637591895059, ; hash 0x578e2ed9035dac13, from name: aot-System.ComponentModel.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.46_name, ; name: libaot-System.ComponentModel.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 202
	%struct.DSOCacheEntry {
		i64 6342692645518226948, ; hash 0x5805c55b2798b604, from name: Xamarin.AndroidX.CursorAdapter.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.21_name, ; name: libaot-Xamarin.AndroidX.CursorAdapter.dll.so
		ptr null; void* handle (0x0)
	}, ; 203
	%struct.DSOCacheEntry {
		i64 6352489697598145066, ; hash 0x582893b918aa822a, from name: Xamarin.AndroidX.SwipeRefreshLayout.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.31_name, ; name: libaot-Xamarin.AndroidX.SwipeRefreshLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 204
	%struct.DSOCacheEntry {
		i64 6357457916754632952, ; hash 0x583a3a4ac2a7a0f8, from name: _Microsoft.Android.Resource.Designer
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.7_name, ; name: libaot-_Microsoft.Android.Resource.Designer.dll.so
		ptr null; void* handle (0x0)
	}, ; 205
	%struct.DSOCacheEntry {
		i64 6376181678372852540, ; hash 0x587cbf743ac4933c, from name: aot-Xamarin.Forms.Platform.Android
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.36_name, ; name: libaot-Xamarin.Forms.Platform.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 206
	%struct.DSOCacheEntry {
		i64 6401687960814735282, ; hash 0x58d75d486341cfb2, from name: Xamarin.AndroidX.Lifecycle.LiveData.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.26_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 207
	%struct.DSOCacheEntry {
		i64 6457195912600883720, ; hash 0x599c917887ae1208, from name: libaot-Xamarin.Forms.Platform.Android
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.36_name, ; name: libaot-Xamarin.Forms.Platform.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 208
	%struct.DSOCacheEntry {
		i64 6488258789742214262, ; hash 0x5a0aecfe3563fc76, from name: aot-System.Collections.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.45_name, ; name: libaot-System.Collections.dll.so
		ptr null; void* handle (0x0)
	}, ; 209
	%struct.DSOCacheEntry {
		i64 6558713382764477133, ; hash 0x5b053b127346facd, from name: mono-component-marshal-ilgen.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.4_name, ; name: libmono-component-marshal-ilgen.so
		ptr null; void* handle (0x0)
	}, ; 210
	%struct.DSOCacheEntry {
		i64 6560588458386133218, ; hash 0x5b0be47183a210e2, from name: libaot-Xamarin.AndroidX.RecyclerView
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.29_name, ; name: libaot-Xamarin.AndroidX.RecyclerView.dll.so
		ptr null; void* handle (0x0)
	}, ; 211
	%struct.DSOCacheEntry {
		i64 6786606130239981554, ; hash 0x5e2ede51877147f2, from name: System.Diagnostics.TraceSource
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.53_name, ; name: libaot-System.Diagnostics.TraceSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 212
	%struct.DSOCacheEntry {
		i64 6811092106988893788, ; hash 0x5e85dc2f418a365c, from name: aot-Xamarin.AndroidX.SwipeRefreshLayout.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.31_name, ; name: libaot-Xamarin.AndroidX.SwipeRefreshLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 213
	%struct.DSOCacheEntry {
		i64 6836385375498469829, ; hash 0x5edfb8473e4301c5, from name: Xamarin.AndroidX.RecyclerView.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.29_name, ; name: libaot-Xamarin.AndroidX.RecyclerView.dll.so
		ptr null; void* handle (0x0)
	}, ; 214
	%struct.DSOCacheEntry {
		i64 6876862101832370452, ; hash 0x5f6f85a57d108914, from name: System.Xml.Linq
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.91_name, ; name: libaot-System.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 215
	%struct.DSOCacheEntry {
		i64 6879679050593672945, ; hash 0x5f7987a57b551ef1, from name: libaot-Xamarin.AndroidX.CardView
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.18_name, ; name: libaot-Xamarin.AndroidX.CardView.dll.so
		ptr null; void* handle (0x0)
	}, ; 216
	%struct.DSOCacheEntry {
		i64 6913716284728566067, ; hash 0x5ff274549d146133, from name: System.IO.Compression.Native.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.1_name, ; name: libSystem.IO.Compression.Native.so
		ptr null; void* handle (0x0)
	}, ; 217
	%struct.DSOCacheEntry {
		i64 6983488022539651679, ; hash 0x60ea555b3cabca5f, from name: libaot-SQLitePCLRaw.provider.e_sqlite3
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.13_name, ; name: libaot-SQLitePCLRaw.provider.e_sqlite3.dll.so
		ptr null; void* handle (0x0)
	}, ; 218
	%struct.DSOCacheEntry {
		i64 7005231924406374519, ; hash 0x61379551e777d077, from name: libaot-Xamarin.AndroidX.Lifecycle.LiveData.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.26_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 219
	%struct.DSOCacheEntry {
		i64 7026076528261849631, ; hash 0x6181a3606fc1e21f, from name: libaot-Xamarin.Kotlin.StdLib
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.40_name, ; name: libaot-Xamarin.Kotlin.StdLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 220
	%struct.DSOCacheEntry {
		i64 7032820184502538532, ; hash 0x619998b242789124, from name: libaot-System.Net.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.66_name, ; name: libaot-System.Net.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 221
	%struct.DSOCacheEntry {
		i64 7086827931071621775, ; hash 0x62597874a7d72a8f, from name: aot-Xamarin.AndroidX.Lifecycle.Common.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.25_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.Common.dll.so
		ptr null; void* handle (0x0)
	}, ; 222
	%struct.DSOCacheEntry {
		i64 7106548671186296926, ; hash 0x629f885d4515605e, from name: libaot-System.Numerics
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.73_name, ; name: libaot-System.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 223
	%struct.DSOCacheEntry {
		i64 7110380120510801993, ; hash 0x62ad250c150ba849, from name: aot-SQLitePCLRaw.core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.11_name, ; name: libaot-SQLitePCLRaw.core.dll.so
		ptr null; void* handle (0x0)
	}, ; 224
	%struct.DSOCacheEntry {
		i64 7252784626773793767, ; hash 0x64a71130ef441be7, from name: System.Drawing.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.54_name, ; name: libaot-System.Drawing.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 225
	%struct.DSOCacheEntry {
		i64 7270811800166795866, ; hash 0x64e71ccf51a90a5a, from name: System.Linq
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.61_name, ; name: libaot-System.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 226
	%struct.DSOCacheEntry {
		i64 7286834274487352090, ; hash 0x6520092a53f5bb1a, from name: libaot-System.Diagnostics.DiagnosticSource.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.51_name, ; name: libaot-System.Diagnostics.DiagnosticSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 227
	%struct.DSOCacheEntry {
		i64 7338982286544642983, ; hash 0x65d94d818a60a3a7, from name: monodroid.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.6_name, ; name: libmonodroid.so
		ptr null; void* handle (0x0)
	}, ; 228
	%struct.DSOCacheEntry {
		i64 7357705307462257638, ; hash 0x661bd1fe8d4b4be6, from name: aot-Mono.Android.Runtime
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.97_name, ; name: libaot-Mono.Android.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 229
	%struct.DSOCacheEntry {
		i64 7407203823444058461, ; hash 0x66cbaca1e34c615d, from name: libaot-Xamarin.Forms.Xaml.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.38_name, ; name: libaot-Xamarin.Forms.Xaml.dll.so
		ptr null; void* handle (0x0)
	}, ; 230
	%struct.DSOCacheEntry {
		i64 7415347135721941512, ; hash 0x66e89aee86eaaa08, from name: libmono-component-marshal-ilgen
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.4_name, ; name: libmono-component-marshal-ilgen.so
		ptr null; void* handle (0x0)
	}, ; 231
	%struct.DSOCacheEntry {
		i64 7447924280570395180, ; hash 0x675c57ac2167ba2c, from name: libaot-Xamarin.AndroidX.AppCompat.AppCompatResources
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.16_name, ; name: libaot-Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so
		ptr null; void* handle (0x0)
	}, ; 232
	%struct.DSOCacheEntry {
		i64 7465578309990517956, ; hash 0x679b0feb29d88cc4, from name: aot-System.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.93_name, ; name: libaot-System.dll.so
		ptr null; void* handle (0x0)
	}, ; 233
	%struct.DSOCacheEntry {
		i64 7477302391979602800, ; hash 0x67c4b6e8b81f7370, from name: Xamarin.AndroidX.CardView.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.18_name, ; name: libaot-Xamarin.AndroidX.CardView.dll.so
		ptr null; void* handle (0x0)
	}, ; 234
	%struct.DSOCacheEntry {
		i64 7484096333359613774, ; hash 0x67dcd9f676b4074e, from name: libaot-System.Net.Security
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.68_name, ; name: libaot-System.Net.Security.dll.so
		ptr null; void* handle (0x0)
	}, ; 235
	%struct.DSOCacheEntry {
		i64 7489048572193775167, ; hash 0x67ee71ff6b419e3f, from name: System.ObjectModel
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.74_name, ; name: libaot-System.ObjectModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 236
	%struct.DSOCacheEntry {
		i64 7515511324144895830, ; hash 0x684c75bafd150756, from name: System.Collections.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.45_name, ; name: libaot-System.Collections.dll.so
		ptr null; void* handle (0x0)
	}, ; 237
	%struct.DSOCacheEntry {
		i64 7535601351437907993, ; hash 0x6893d580f968f819, from name: System.Net.Http.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.63_name, ; name: libaot-System.Net.Http.dll.so
		ptr null; void* handle (0x0)
	}, ; 238
	%struct.DSOCacheEntry {
		i64 7540556024932143097, ; hash 0x68a56fc0cb030ff9, from name: aot-System.Drawing.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.54_name, ; name: libaot-System.Drawing.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 239
	%struct.DSOCacheEntry {
		i64 7603299711682212348, ; hash 0x698458cdc3a5f1fc, from name: aot-System.Collections.NonGeneric.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.43_name, ; name: libaot-System.Collections.NonGeneric.dll.so
		ptr null; void* handle (0x0)
	}, ; 240
	%struct.DSOCacheEntry {
		i64 7639941140308737920, ; hash 0x6a0685fd2cfebf80, from name: libSystem.IO.Compression.Native.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.1_name, ; name: libSystem.IO.Compression.Native.so
		ptr null; void* handle (0x0)
	}, ; 241
	%struct.DSOCacheEntry {
		i64 7640815069151536100, ; hash 0x6a09a0d2973aa3e4, from name: libaot-System.Threading.Channels
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.88_name, ; name: libaot-System.Threading.Channels.dll.so
		ptr null; void* handle (0x0)
	}, ; 242
	%struct.DSOCacheEntry {
		i64 7654504624184590948, ; hash 0x6a3a4366801b8264, from name: System.Net.Http
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.63_name, ; name: libaot-System.Net.Http.dll.so
		ptr null; void* handle (0x0)
	}, ; 243
	%struct.DSOCacheEntry {
		i64 7658328537957887241, ; hash 0x6a47d93ace376d09, from name: libaot-Xamarin.Google.Android.Material
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.39_name, ; name: libaot-Xamarin.Google.Android.Material.dll.so
		ptr null; void* handle (0x0)
	}, ; 244
	%struct.DSOCacheEntry {
		i64 7675303261932883976, ; hash 0x6a8427a6b6e81008, from name: aot-System.Runtime.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.85_name, ; name: libaot-System.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 245
	%struct.DSOCacheEntry {
		i64 7714652370974252055, ; hash 0x6b0ff375198b9c17, from name: System.Private.CoreLib
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.99_name, ; name: libaot-System.Private.CoreLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 246
	%struct.DSOCacheEntry {
		i64 7740286304433625072, ; hash 0x6b6b0562539657f0, from name: libmonosgen-2.0
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.5_name, ; name: libmonosgen-2.0.so
		ptr null; void* handle (0x0)
	}, ; 247
	%struct.DSOCacheEntry {
		i64 7836164640616011524, ; hash 0x6cbfa6390d64d704, from name: Xamarin.AndroidX.AppCompat.AppCompatResources
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.16_name, ; name: libaot-Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so
		ptr null; void* handle (0x0)
	}, ; 248
	%struct.DSOCacheEntry {
		i64 7855888427540559711, ; hash 0x6d05b8e70ea8375f, from name: System.Console.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.49_name, ; name: libaot-System.Console.dll.so
		ptr null; void* handle (0x0)
	}, ; 249
	%struct.DSOCacheEntry {
		i64 7948127817007369596, ; hash 0x6e4d6c237a200d7c, from name: aot-System.Private.Xml.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.78_name, ; name: libaot-System.Private.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 250
	%struct.DSOCacheEntry {
		i64 7968925550521657015, ; hash 0x6e974f912860a6b7, from name: aot-System.Net.Sockets
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.70_name, ; name: libaot-System.Net.Sockets.dll.so
		ptr null; void* handle (0x0)
	}, ; 251
	%struct.DSOCacheEntry {
		i64 8022274032104026556, ; hash 0x6f54d7ba7666b1bc, from name: libaot-FormsViewGroup
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.34_name, ; name: libaot-FormsViewGroup.dll.so
		ptr null; void* handle (0x0)
	}, ; 252
	%struct.DSOCacheEntry {
		i64 8027067278921088108, ; hash 0x6f65df293440bc6c, from name: libe_sqlite3
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.0_name, ; name: libe_sqlite3.so
		ptr null; void* handle (0x0)
	}, ; 253
	%struct.DSOCacheEntry {
		i64 8045625500978714388, ; hash 0x6fa7cdc3fda91714, from name: libaot-UniversityAndroidApp.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.8_name, ; name: libaot-UniversityAndroidApp.dll.so
		ptr null; void* handle (0x0)
	}, ; 254
	%struct.DSOCacheEntry {
		i64 8087206902342787202, ; hash 0x703b87d46f3aa082, from name: System.Diagnostics.DiagnosticSource
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.51_name, ; name: libaot-System.Diagnostics.DiagnosticSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 255
	%struct.DSOCacheEntry {
		i64 8092331298404567383, ; hash 0x704dbc70de2e0957, from name: aot-_Microsoft.Android.Resource.Designer
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.7_name, ; name: libaot-_Microsoft.Android.Resource.Designer.dll.so
		ptr null; void* handle (0x0)
	}, ; 256
	%struct.DSOCacheEntry {
		i64 8129154283138605531, ; hash 0x70d08ec01ad261db, from name: mono-component-marshal-ilgen
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.4_name, ; name: libmono-component-marshal-ilgen.so
		ptr null; void* handle (0x0)
	}, ; 257
	%struct.DSOCacheEntry {
		i64 8185542183669246576, ; hash 0x7198e33f4794aa70, from name: System.Collections
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.45_name, ; name: libaot-System.Collections.dll.so
		ptr null; void* handle (0x0)
	}, ; 258
	%struct.DSOCacheEntry {
		i64 8189823481260868218, ; hash 0x71a819108db5027a, from name: libaot-System.Collections.Concurrent
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.42_name, ; name: libaot-System.Collections.Concurrent.dll.so
		ptr null; void* handle (0x0)
	}, ; 259
	%struct.DSOCacheEntry {
		i64 8245499330237193625, ; hash 0x726de5f44e825d99, from name: aot-System.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.50_name, ; name: libaot-System.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 260
	%struct.DSOCacheEntry {
		i64 8265825813513713813, ; hash 0x72b61cc87dbd3895, from name: aot-SQLitePCLRaw.lib.e_sqlite3.android
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.12_name, ; name: libaot-SQLitePCLRaw.lib.e_sqlite3.android.dll.so
		ptr null; void* handle (0x0)
	}, ; 261
	%struct.DSOCacheEntry {
		i64 8316843229190310146, ; hash 0x736b5cda38804902, from name: Xamarin.Forms.Xaml.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.38_name, ; name: libaot-Xamarin.Forms.Xaml.dll.so
		ptr null; void* handle (0x0)
	}, ; 262
	%struct.DSOCacheEntry {
		i64 8335746768722831773, ; hash 0x73ae85857f55a99d, from name: aot-System.Runtime.Numerics
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.81_name, ; name: libaot-System.Runtime.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 263
	%struct.DSOCacheEntry {
		i64 8340594550852286012, ; hash 0x73bfbe8dbb1bf63c, from name: aot-System.Runtime.InteropServices.RuntimeInformation.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.79_name, ; name: libaot-System.Runtime.InteropServices.RuntimeInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 264
	%struct.DSOCacheEntry {
		i64 8362087432769215690, ; hash 0x740c1a3742f79cca, from name: System.Private.Xml.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.78_name, ; name: libaot-System.Private.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 265
	%struct.DSOCacheEntry {
		i64 8368701292315763008, ; hash 0x7423997c6fd56140, from name: System.Security.Cryptography
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.86_name, ; name: libaot-System.Security.Cryptography.dll.so
		ptr null; void* handle (0x0)
	}, ; 266
	%struct.DSOCacheEntry {
		i64 8375722837974120975, ; hash 0x743c8b8b6e92fa0f, from name: aot-System.Runtime.Serialization.Formatters.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.82_name, ; name: libaot-System.Runtime.Serialization.Formatters.dll.so
		ptr null; void* handle (0x0)
	}, ; 267
	%struct.DSOCacheEntry {
		i64 8392333777418328833, ; hash 0x74778f1b27881b01, from name: libmonodroid.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.6_name, ; name: libmonodroid.so
		ptr null; void* handle (0x0)
	}, ; 268
	%struct.DSOCacheEntry {
		i64 8522025752637549819, ; hash 0x7644514538b12cfb, from name: aot-Mono.Android.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.98_name, ; name: libaot-Mono.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 269
	%struct.DSOCacheEntry {
		i64 8549577848454178208, ; hash 0x76a633c16ca8e5a0, from name: aot-SQLitePCLRaw.provider.e_sqlite3
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.13_name, ; name: libaot-SQLitePCLRaw.provider.e_sqlite3.dll.so
		ptr null; void* handle (0x0)
	}, ; 270
	%struct.DSOCacheEntry {
		i64 8563666267364444763, ; hash 0x76d841191140ca5b, from name: System.Private.Uri
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.76_name, ; name: libaot-System.Private.Uri.dll.so
		ptr null; void* handle (0x0)
	}, ; 271
	%struct.DSOCacheEntry {
		i64 8579148903550987409, ; hash 0x770f42793756ac91, from name: aot-System.Net.Security.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.68_name, ; name: libaot-System.Net.Security.dll.so
		ptr null; void* handle (0x0)
	}, ; 272
	%struct.DSOCacheEntry {
		i64 8612207396229290788, ; hash 0x7784b4ff583d1b24, from name: aot-System.Net.Http.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.63_name, ; name: libaot-System.Net.Http.dll.so
		ptr null; void* handle (0x0)
	}, ; 273
	%struct.DSOCacheEntry {
		i64 8626175481042262068, ; hash 0x77b654e585b55834, from name: Java.Interop
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.96_name, ; name: libaot-Java.Interop.dll.so
		ptr null; void* handle (0x0)
	}, ; 274
	%struct.DSOCacheEntry {
		i64 8626645781824515032, ; hash 0x77b800a1f4c5abd8, from name: System.Native
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.2_name, ; name: libSystem.Native.so
		ptr null; void* handle (0x0)
	}, ; 275
	%struct.DSOCacheEntry {
		i64 8628664141348535547, ; hash 0x77bf2c51e73afcfb, from name: Xamarin.AndroidX.Fragment.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.23_name, ; name: libaot-Xamarin.AndroidX.Fragment.dll.so
		ptr null; void* handle (0x0)
	}, ; 276
	%struct.DSOCacheEntry {
		i64 8658236679209272073, ; hash 0x78283c62ed86c309, from name: libaot-Xamarin.AndroidX.ViewPager
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.32_name, ; name: libaot-Xamarin.AndroidX.ViewPager.dll.so
		ptr null; void* handle (0x0)
	}, ; 277
	%struct.DSOCacheEntry {
		i64 8659486139845940425, ; hash 0x782cacc3a6ef94c9, from name: System.Runtime.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.85_name, ; name: libaot-System.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 278
	%struct.DSOCacheEntry {
		i64 8730145678495508517, ; hash 0x7927b53d8422e825, from name: Xamarin.AndroidX.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.20_name, ; name: libaot-Xamarin.AndroidX.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 279
	%struct.DSOCacheEntry {
		i64 8747763348793017252, ; hash 0x79664c6b07fd43a4, from name: libaot-System.Private.CoreLib.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.99_name, ; name: libaot-System.Private.CoreLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 280
	%struct.DSOCacheEntry {
		i64 8760858219412156768, ; hash 0x7994d2222f9f7160, from name: System.Linq.Expressions.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.60_name, ; name: libaot-System.Linq.Expressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 281
	%struct.DSOCacheEntry {
		i64 8761982123773840073, ; hash 0x7998d0518fdccac9, from name: aot-System.Text.RegularExpressions.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.87_name, ; name: libaot-System.Text.RegularExpressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 282
	%struct.DSOCacheEntry {
		i64 8772604801161716260, ; hash 0x79be8d9660216224, from name: aot-Mono.Android
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.98_name, ; name: libaot-Mono.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 283
	%struct.DSOCacheEntry {
		i64 8812786412666749070, ; hash 0x7a4d4e8cd864008e, from name: aot-System.Diagnostics.DiagnosticSource
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.51_name, ; name: libaot-System.Diagnostics.DiagnosticSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 284
	%struct.DSOCacheEntry {
		i64 8824907823227734965, ; hash 0x7a785ee8ab0e0bb5, from name: aot-System.Private.Uri
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.76_name, ; name: libaot-System.Private.Uri.dll.so
		ptr null; void* handle (0x0)
	}, ; 285
	%struct.DSOCacheEntry {
		i64 8879040545617680294, ; hash 0x7b38b05543d517a6, from name: libaot-Xamarin.AndroidX.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.20_name, ; name: libaot-Xamarin.AndroidX.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 286
	%struct.DSOCacheEntry {
		i64 8906503468682351602, ; hash 0x7b9a41b7519893f2, from name: aot-System.Threading.Channels
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.88_name, ; name: libaot-System.Threading.Channels.dll.so
		ptr null; void* handle (0x0)
	}, ; 287
	%struct.DSOCacheEntry {
		i64 8959200230209785136, ; hash 0x7c55792439408d30, from name: aot-Xamarin.AndroidX.Fragment.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.23_name, ; name: libaot-Xamarin.AndroidX.Fragment.dll.so
		ptr null; void* handle (0x0)
	}, ; 288
	%struct.DSOCacheEntry {
		i64 8967164847000689438, ; hash 0x7c71c4eb13d89b1e, from name: libaot-System.Private.Uri.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.76_name, ; name: libaot-System.Private.Uri.dll.so
		ptr null; void* handle (0x0)
	}, ; 289
	%struct.DSOCacheEntry {
		i64 8996927521954684202, ; hash 0x7cdb81e9d80b5d2a, from name: e_sqlite3
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.0_name, ; name: libe_sqlite3.so
		ptr null; void* handle (0x0)
	}, ; 290
	%struct.DSOCacheEntry {
		i64 9032777207089403703, ; hash 0x7d5adf031bcf1737, from name: libaot-System.ObjectModel
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.74_name, ; name: libaot-System.ObjectModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 291
	%struct.DSOCacheEntry {
		i64 9049979032622352945, ; hash 0x7d97fbfb38304a31, from name: libaot-System.IO.Compression
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.58_name, ; name: libaot-System.IO.Compression.dll.so
		ptr null; void* handle (0x0)
	}, ; 292
	%struct.DSOCacheEntry {
		i64 9055317871244365271, ; hash 0x7daaf3a073c44dd7, from name: monodroid
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.6_name, ; name: libmonodroid.so
		ptr null; void* handle (0x0)
	}, ; 293
	%struct.DSOCacheEntry {
		i64 9184990959724848206, ; hash 0x7f77a49d1b92e44e, from name: aot-Xamarin.AndroidX.AppCompat.AppCompatResources
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.16_name, ; name: libaot-Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so
		ptr null; void* handle (0x0)
	}, ; 294
	%struct.DSOCacheEntry {
		i64 9202553973257348394, ; hash 0x7fb60a14da5d252a, from name: libaot-System.Net.Security.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.68_name, ; name: libaot-System.Net.Security.dll.so
		ptr null; void* handle (0x0)
	}, ; 295
	%struct.DSOCacheEntry {
		i64 9207742526868940023, ; hash 0x7fc8790b2147e4f7, from name: libaot-System.Runtime.Serialization
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.84_name, ; name: libaot-System.Runtime.Serialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 296
	%struct.DSOCacheEntry {
		i64 9219236770475081177, ; hash 0x7ff14eff4462fdd9, from name: aot-Xamarin.AndroidX.ViewPager
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.32_name, ; name: libaot-Xamarin.AndroidX.ViewPager.dll.so
		ptr null; void* handle (0x0)
	}, ; 297
	%struct.DSOCacheEntry {
		i64 9225652551807385394, ; hash 0x80081a1dc3a7bf32, from name: libaot-Xamarin.AndroidX.CoordinatorLayout.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.19_name, ; name: libaot-Xamarin.AndroidX.CoordinatorLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 298
	%struct.DSOCacheEntry {
		i64 9293571162334492259, ; hash 0x80f965bb91c2f663, from name: libaot-System.Formats.Asn1.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.56_name, ; name: libaot-System.Formats.Asn1.dll.so
		ptr null; void* handle (0x0)
	}, ; 299
	%struct.DSOCacheEntry {
		i64 9324707631942237306, ; hash 0x8168042fd44a7c7a, from name: Xamarin.AndroidX.AppCompat
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.15_name, ; name: libaot-Xamarin.AndroidX.AppCompat.dll.so
		ptr null; void* handle (0x0)
	}, ; 300
	%struct.DSOCacheEntry {
		i64 9370897661222023495, ; hash 0x820c1dc613ad7147, from name: libaot-System.Runtime.InteropServices.RuntimeInformation
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.79_name, ; name: libaot-System.Runtime.InteropServices.RuntimeInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 301
	%struct.DSOCacheEntry {
		i64 9572878646085775350, ; hash 0x84d9b268c9dd6ff6, from name: aot-Xamarin.AndroidX.Browser.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.17_name, ; name: libaot-Xamarin.AndroidX.Browser.dll.so
		ptr null; void* handle (0x0)
	}, ; 302
	%struct.DSOCacheEntry {
		i64 9584802165301184279, ; hash 0x85040ec9712c0717, from name: System.Private.Uri.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.76_name, ; name: libaot-System.Private.Uri.dll.so
		ptr null; void* handle (0x0)
	}, ; 303
	%struct.DSOCacheEntry {
		i64 9641796949223436837, ; hash 0x85ce8b3daae87225, from name: libaot-Java.Interop.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.96_name, ; name: libaot-Java.Interop.dll.so
		ptr null; void* handle (0x0)
	}, ; 304
	%struct.DSOCacheEntry {
		i64 9659729154652888475, ; hash 0x860e407c9991dd9b, from name: System.Text.RegularExpressions
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.87_name, ; name: libaot-System.Text.RegularExpressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 305
	%struct.DSOCacheEntry {
		i64 9667360217193089419, ; hash 0x86295ce5cd89898b, from name: System.Diagnostics.StackTrace
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.52_name, ; name: libaot-System.Diagnostics.StackTrace.dll.so
		ptr null; void* handle (0x0)
	}, ; 306
	%struct.DSOCacheEntry {
		i64 9783785228567974479, ; hash 0x87c6fcd42382124f, from name: libaot-System.Threading.Thread
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.89_name, ; name: libaot-System.Threading.Thread.dll.so
		ptr null; void* handle (0x0)
	}, ; 307
	%struct.DSOCacheEntry {
		i64 9803047054801588640, ; hash 0x880b6b5b89e351a0, from name: Xamarin.AndroidX.Lifecycle.ViewModel.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.27_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.ViewModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 308
	%struct.DSOCacheEntry {
		i64 9812715920514560426, ; hash 0x882dc523c41731aa, from name: UniversityAndroidApp.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.8_name, ; name: libaot-UniversityAndroidApp.dll.so
		ptr null; void* handle (0x0)
	}, ; 309
	%struct.DSOCacheEntry {
		i64 9827999957722745190, ; hash 0x886411e3fc9e4966, from name: aot-SQLitePCLRaw.lib.e_sqlite3.android.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.12_name, ; name: libaot-SQLitePCLRaw.lib.e_sqlite3.android.dll.so
		ptr null; void* handle (0x0)
	}, ; 310
	%struct.DSOCacheEntry {
		i64 9878540403917854255, ; hash 0x8917a0289ade162f, from name: Xamarin.Kotlin.StdLib.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.40_name, ; name: libaot-Xamarin.Kotlin.StdLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 311
	%struct.DSOCacheEntry {
		i64 10015320022696718808, ; hash 0x8afd907f48b1f1d8, from name: aot-Xamarin.Kotlin.StdLib.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.40_name, ; name: libaot-Xamarin.Kotlin.StdLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 312
	%struct.DSOCacheEntry {
		i64 10036215306110403221, ; hash 0x8b47cca5920c8295, from name: System.Runtime.Serialization.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.83_name, ; name: libaot-System.Runtime.Serialization.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 313
	%struct.DSOCacheEntry {
		i64 10051358222726253779, ; hash 0x8b7d990c97ccccd3, from name: System.Private.Xml
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.78_name, ; name: libaot-System.Private.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 314
	%struct.DSOCacheEntry {
		i64 10100633424984079765, ; hash 0x8c2ca895a69cfd95, from name: libaot-System.Runtime
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.85_name, ; name: libaot-System.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 315
	%struct.DSOCacheEntry {
		i64 10117538216423255955, ; hash 0x8c68b7671f58ef93, from name: System.Collections.Specialized.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.44_name, ; name: libaot-System.Collections.Specialized.dll.so
		ptr null; void* handle (0x0)
	}, ; 316
	%struct.DSOCacheEntry {
		i64 10131599475156204988, ; hash 0x8c9aac0b0b383dbc, from name: libaot-System.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.50_name, ; name: libaot-System.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 317
	%struct.DSOCacheEntry {
		i64 10202443004866537339, ; hash 0x8d965bdbaa3d277b, from name: aot-System.Security.Cryptography
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.86_name, ; name: libaot-System.Security.Cryptography.dll.so
		ptr null; void* handle (0x0)
	}, ; 318
	%struct.DSOCacheEntry {
		i64 10224492561641212282, ; hash 0x8de4b1d0293f897a, from name: aot-System.Private.Xml.Linq.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.77_name, ; name: libaot-System.Private.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 319
	%struct.DSOCacheEntry {
		i64 10273345953350871244, ; hash 0x8e9241b6cc2ce8cc, from name: netstandard.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.95_name, ; name: libaot-netstandard.dll.so
		ptr null; void* handle (0x0)
	}, ; 320
	%struct.DSOCacheEntry {
		i64 10291981562957691400, ; hash 0x8ed476b3c6f67a08, from name: aot-System.ComponentModel.TypeConverter
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.47_name, ; name: libaot-System.ComponentModel.TypeConverter.dll.so
		ptr null; void* handle (0x0)
	}, ; 321
	%struct.DSOCacheEntry {
		i64 10318218263549127400, ; hash 0x8f31acd7a9cb2ae8, from name: aot-System.Formats.Asn1
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.56_name, ; name: libaot-System.Formats.Asn1.dll.so
		ptr null; void* handle (0x0)
	}, ; 322
	%struct.DSOCacheEntry {
		i64 10356807666685550219, ; hash 0x8fbac5b33bd59e8b, from name: libaot-System.Net.Http
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.63_name, ; name: libaot-System.Net.Http.dll.so
		ptr null; void* handle (0x0)
	}, ; 323
	%struct.DSOCacheEntry {
		i64 10360315726388337145, ; hash 0x8fc73c43084519f9, from name: libaot-System.Drawing.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.55_name, ; name: libaot-System.Drawing.dll.so
		ptr null; void* handle (0x0)
	}, ; 324
	%struct.DSOCacheEntry {
		i64 10385124814576326370, ; hash 0x901f5fff00ea96e2, from name: libaot-System.Private.Xml.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.78_name, ; name: libaot-System.Private.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 325
	%struct.DSOCacheEntry {
		i64 10387475612650146223, ; hash 0x9027ba08d50b89af, from name: libaot-System.Runtime.Serialization.Formatters
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.82_name, ; name: libaot-System.Runtime.Serialization.Formatters.dll.so
		ptr null; void* handle (0x0)
	}, ; 326
	%struct.DSOCacheEntry {
		i64 10430153318873392755, ; hash 0x90bf592ea44f6673, from name: Xamarin.AndroidX.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.20_name, ; name: libaot-Xamarin.AndroidX.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 327
	%struct.DSOCacheEntry {
		i64 10431089073467423858, ; hash 0x90c2ac3efc7bfc72, from name: libaot-System.Private.Xml
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.78_name, ; name: libaot-System.Private.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 328
	%struct.DSOCacheEntry {
		i64 10445573484590211502, ; hash 0x90f621bdc03d21ae, from name: aot-Xamarin.AndroidX.Activity
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.14_name, ; name: libaot-Xamarin.AndroidX.Activity.dll.so
		ptr null; void* handle (0x0)
	}, ; 329
	%struct.DSOCacheEntry {
		i64 10450970453325464374, ; hash 0x91094e4174914336, from name: aot-System.Runtime.Serialization.Formatters
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.82_name, ; name: libaot-System.Runtime.Serialization.Formatters.dll.so
		ptr null; void* handle (0x0)
	}, ; 330
	%struct.DSOCacheEntry {
		i64 10512098364414578010, ; hash 0x91e279c456e54d5a, from name: libaot-Xamarin.AndroidX.CursorAdapter
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.21_name, ; name: libaot-Xamarin.AndroidX.CursorAdapter.dll.so
		ptr null; void* handle (0x0)
	}, ; 331
	%struct.DSOCacheEntry {
		i64 10657322552275964462, ; hash 0x93e66a65792b122e, from name: aot-System.Runtime.InteropServices
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.80_name, ; name: libaot-System.Runtime.InteropServices.dll.so
		ptr null; void* handle (0x0)
	}, ; 332
	%struct.DSOCacheEntry {
		i64 10686502423950929984, ; hash 0x944e1555c6f23040, from name: libaot-netstandard
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.95_name, ; name: libaot-netstandard.dll.so
		ptr null; void* handle (0x0)
	}, ; 333
	%struct.DSOCacheEntry {
		i64 10738576877450676954, ; hash 0x950716c64dabcada, from name: aot-System.Security.Cryptography.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.86_name, ; name: libaot-System.Security.Cryptography.dll.so
		ptr null; void* handle (0x0)
	}, ; 334
	%struct.DSOCacheEntry {
		i64 10785150219063592792, ; hash 0x95ac8cfb68830758, from name: System.Net.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.66_name, ; name: libaot-System.Net.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 335
	%struct.DSOCacheEntry {
		i64 10827433220396269482, ; hash 0x9642c525d2fbbfaa, from name: aot-Xamarin.AndroidX.SavedState
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.30_name, ; name: libaot-Xamarin.AndroidX.SavedState.dll.so
		ptr null; void* handle (0x0)
	}, ; 336
	%struct.DSOCacheEntry {
		i64 10828441735335428004, ; hash 0x96465a6301aebfa4, from name: aot-System.Private.DataContractSerialization
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.75_name, ; name: libaot-System.Private.DataContractSerialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 337
	%struct.DSOCacheEntry {
		i64 10959662263064203642, ; hash 0x98188ac2f032117a, from name: aot-Xamarin.AndroidX.Fragment
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.23_name, ; name: libaot-Xamarin.AndroidX.Fragment.dll.so
		ptr null; void* handle (0x0)
	}, ; 338
	%struct.DSOCacheEntry {
		i64 11023048688141570732, ; hash 0x98f9bc61168392ac, from name: System.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.50_name, ; name: libaot-System.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 339
	%struct.DSOCacheEntry {
		i64 11025662355949164213, ; hash 0x9903057f0bbf16b5, from name: libaot-System.IO.IsolatedStorage.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.59_name, ; name: libaot-System.IO.IsolatedStorage.dll.so
		ptr null; void* handle (0x0)
	}, ; 340
	%struct.DSOCacheEntry {
		i64 11037814507248023548, ; hash 0x992e31d0412bf7fc, from name: System.Xml
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.92_name, ; name: libaot-System.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 341
	%struct.DSOCacheEntry {
		i64 11043797956829943227, ; hash 0x994373baac0895bb, from name: aot-System.Diagnostics.TraceSource
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.53_name, ; name: libaot-System.Diagnostics.TraceSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 342
	%struct.DSOCacheEntry {
		i64 11058657390679514429, ; hash 0x99783e4e38335d3d, from name: aot-System.Net.NetworkInformation
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.65_name, ; name: libaot-System.Net.NetworkInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 343
	%struct.DSOCacheEntry {
		i64 11063900969707219733, ; hash 0x998adf50197fab15, from name: libaot-System.Numerics.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.73_name, ; name: libaot-System.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 344
	%struct.DSOCacheEntry {
		i64 11158564309551918097, ; hash 0x9adb2f1e7231ac11, from name: libaot-System.Threading.Channels.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.88_name, ; name: libaot-System.Threading.Channels.dll.so
		ptr null; void* handle (0x0)
	}, ; 345
	%struct.DSOCacheEntry {
		i64 11162124722117608902, ; hash 0x9ae7d54b986d05c6, from name: Xamarin.AndroidX.ViewPager
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.32_name, ; name: libaot-Xamarin.AndroidX.ViewPager.dll.so
		ptr null; void* handle (0x0)
	}, ; 346
	%struct.DSOCacheEntry {
		i64 11164818937994912957, ; hash 0x9af167ab9cbda4bd, from name: System.Security.Cryptography.Native.Android
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.3_name, ; name: libSystem.Security.Cryptography.Native.Android.so
		ptr null; void* handle (0x0)
	}, ; 347
	%struct.DSOCacheEntry {
		i64 11171214345979581187, ; hash 0x9b08204291dc5303, from name: libaot-System.Text.RegularExpressions
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.87_name, ; name: libaot-System.Text.RegularExpressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 348
	%struct.DSOCacheEntry {
		i64 11212038206026375799, ; hash 0x9b9929582e4f6277, from name: aot-System.Runtime.InteropServices.RuntimeInformation
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.79_name, ; name: libaot-System.Runtime.InteropServices.RuntimeInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 349
	%struct.DSOCacheEntry {
		i64 11270596618290860596, ; hash 0x9c6933e8fff21234, from name: libaot-System.Net.Http.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.63_name, ; name: libaot-System.Net.Http.dll.so
		ptr null; void* handle (0x0)
	}, ; 350
	%struct.DSOCacheEntry {
		i64 11297620656358036086, ; hash 0x9cc936212d561276, from name: libaot-System.Linq
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.61_name, ; name: libaot-System.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 351
	%struct.DSOCacheEntry {
		i64 11327873123841536301, ; hash 0x9d34b096a744f12d, from name: aot-netstandard.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.95_name, ; name: libaot-netstandard.dll.so
		ptr null; void* handle (0x0)
	}, ; 352
	%struct.DSOCacheEntry {
		i64 11329407233932627207, ; hash 0x9d3a23da7e4b8d07, from name: aot-System.IO.Compression.Brotli
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.57_name, ; name: libaot-System.IO.Compression.Brotli.dll.so
		ptr null; void* handle (0x0)
	}, ; 353
	%struct.DSOCacheEntry {
		i64 11340910727871153756, ; hash 0x9d630238642d465c, from name: Xamarin.AndroidX.CursorAdapter
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.21_name, ; name: libaot-Xamarin.AndroidX.CursorAdapter.dll.so
		ptr null; void* handle (0x0)
	}, ; 354
	%struct.DSOCacheEntry {
		i64 11369008813813839762, ; hash 0x9dc6d547d3a8b792, from name: aot-Xamarin.AndroidX.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.20_name, ; name: libaot-Xamarin.AndroidX.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 355
	%struct.DSOCacheEntry {
		i64 11398019558505627056, ; hash 0x9e2de6662faebdb0, from name: libaot-FormsViewGroup.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.34_name, ; name: libaot-FormsViewGroup.dll.so
		ptr null; void* handle (0x0)
	}, ; 356
	%struct.DSOCacheEntry {
		i64 11413153824783247973, ; hash 0x9e63aaef2518aa65, from name: aot-System.Net.NameResolution.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.64_name, ; name: libaot-System.Net.NameResolution.dll.so
		ptr null; void* handle (0x0)
	}, ; 357
	%struct.DSOCacheEntry {
		i64 11459687736992758643, ; hash 0x9f08fd47e05a7b73, from name: libaot-System.Diagnostics.DiagnosticSource
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.51_name, ; name: libaot-System.Diagnostics.DiagnosticSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 358
	%struct.DSOCacheEntry {
		i64 11465353776621081442, ; hash 0x9f1d1e8387aed362, from name: aot-System.Collections.Concurrent
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.42_name, ; name: libaot-System.Collections.Concurrent.dll.so
		ptr null; void* handle (0x0)
	}, ; 359
	%struct.DSOCacheEntry {
		i64 11468049509916024921, ; hash 0x9f26b244d9232059, from name: System.Diagnostics.StackTrace.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.52_name, ; name: libaot-System.Diagnostics.StackTrace.dll.so
		ptr null; void* handle (0x0)
	}, ; 360
	%struct.DSOCacheEntry {
		i64 11468676103134815411, ; hash 0x9f28ec26f35ca4b3, from name: libaot-Xamarin.Forms.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.35_name, ; name: libaot-Xamarin.Forms.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 361
	%struct.DSOCacheEntry {
		i64 11485890710487134646, ; hash 0x9f6614bf0f8b71b6, from name: System.Runtime.InteropServices
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.80_name, ; name: libaot-System.Runtime.InteropServices.dll.so
		ptr null; void* handle (0x0)
	}, ; 362
	%struct.DSOCacheEntry {
		i64 11495032816624096970, ; hash 0x9f868f71845656ca, from name: aot-System.Collections.Specialized
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.44_name, ; name: libaot-System.Collections.Specialized.dll.so
		ptr null; void* handle (0x0)
	}, ; 363
	%struct.DSOCacheEntry {
		i64 11521729796983092563, ; hash 0x9fe56834a335f553, from name: libmonodroid
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.6_name, ; name: libmonodroid.so
		ptr null; void* handle (0x0)
	}, ; 364
	%struct.DSOCacheEntry {
		i64 11530669335547299986, ; hash 0xa0052aab27c94892, from name: System.Diagnostics.TraceSource.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.53_name, ; name: libaot-System.Diagnostics.TraceSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 365
	%struct.DSOCacheEntry {
		i64 11543093801659331803, ; hash 0xa0314ea798eaf4db, from name: aot-System.Memory
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.62_name, ; name: libaot-System.Memory.dll.so
		ptr null; void* handle (0x0)
	}, ; 366
	%struct.DSOCacheEntry {
		i64 11557754129944451209, ; hash 0xa065642544a49889, from name: System.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.50_name, ; name: libaot-System.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 367
	%struct.DSOCacheEntry {
		i64 11597940890313164233, ; hash 0xa0f429ca8d1805c9, from name: netstandard
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.95_name, ; name: libaot-netstandard.dll.so
		ptr null; void* handle (0x0)
	}, ; 368
	%struct.DSOCacheEntry {
		i64 11622665325505776179, ; hash 0xa14c0088b6058a33, from name: libaot-System.Runtime.InteropServices
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.80_name, ; name: libaot-System.Runtime.InteropServices.dll.so
		ptr null; void* handle (0x0)
	}, ; 369
	%struct.DSOCacheEntry {
		i64 11637972874768420528, ; hash 0xa18262ab42340eb0, from name: aot-System.Diagnostics.DiagnosticSource.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.51_name, ; name: libaot-System.Diagnostics.DiagnosticSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 370
	%struct.DSOCacheEntry {
		i64 11764213056097819061, ; hash 0xa342e171eeb919b5, from name: libaot-System.Collections.Specialized.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.44_name, ; name: libaot-System.Collections.Specialized.dll.so
		ptr null; void* handle (0x0)
	}, ; 371
	%struct.DSOCacheEntry {
		i64 11775896168281936811, ; hash 0xa36c632c765413ab, from name: aot-System.Private.CoreLib.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.99_name, ; name: libaot-System.Private.CoreLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 372
	%struct.DSOCacheEntry {
		i64 11782443198922974530, ; hash 0xa383a5a9d2056542, from name: aot-System.Collections.NonGeneric
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.43_name, ; name: libaot-System.Collections.NonGeneric.dll.so
		ptr null; void* handle (0x0)
	}, ; 373
	%struct.DSOCacheEntry {
		i64 11799183892646765925, ; hash 0xa3bf1f3c50b8a565, from name: aot-System.Net.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.66_name, ; name: libaot-System.Net.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 374
	%struct.DSOCacheEntry {
		i64 11806260347154423189, ; hash 0xa3d8433bc5eb5d95, from name: SQLite-net
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.9_name, ; name: libaot-SQLite-net.dll.so
		ptr null; void* handle (0x0)
	}, ; 375
	%struct.DSOCacheEntry {
		i64 11846332969256999943, ; hash 0xa466a1122b8fdc07, from name: aot-System.Numerics
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.73_name, ; name: libaot-System.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 376
	%struct.DSOCacheEntry {
		i64 11905546682503808667, ; hash 0xa538ffa12378469b, from name: aot-System.Xml.Linq.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.91_name, ; name: libaot-System.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 377
	%struct.DSOCacheEntry {
		i64 11925868684967371445, ; hash 0xa58132620d6f62b5, from name: aot-System.Net.Sockets.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.70_name, ; name: libaot-System.Net.Sockets.dll.so
		ptr null; void* handle (0x0)
	}, ; 378
	%struct.DSOCacheEntry {
		i64 11949219802464515130, ; hash 0xa5d42819c4f5f43a, from name: aot-System
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.93_name, ; name: libaot-System.dll.so
		ptr null; void* handle (0x0)
	}, ; 379
	%struct.DSOCacheEntry {
		i64 12025475895945156578, ; hash 0xa6e3129d18d557e2, from name: Xamarin.AndroidX.Loader.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.28_name, ; name: libaot-Xamarin.AndroidX.Loader.dll.so
		ptr null; void* handle (0x0)
	}, ; 380
	%struct.DSOCacheEntry {
		i64 12040886584167504988, ; hash 0xa719d28d8e121c5c, from name: System.Net.ServicePoint
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.69_name, ; name: libaot-System.Net.ServicePoint.dll.so
		ptr null; void* handle (0x0)
	}, ; 381
	%struct.DSOCacheEntry {
		i64 12050631976567110376, ; hash 0xa73c71ef8a3efae8, from name: aot-System.Linq
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.61_name, ; name: libaot-System.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 382
	%struct.DSOCacheEntry {
		i64 12051765732457062039, ; hash 0xa7407914a7541e97, from name: aot-System.Linq.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.61_name, ; name: libaot-System.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 383
	%struct.DSOCacheEntry {
		i64 12052751833701477691, ; hash 0xa743f9ef3db6ed3b, from name: System.Net.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.66_name, ; name: libaot-System.Net.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 384
	%struct.DSOCacheEntry {
		i64 12173441707462773849, ; hash 0xa8f0c0bc3b3e4c59, from name: aot-System.Xml.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.92_name, ; name: libaot-System.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 385
	%struct.DSOCacheEntry {
		i64 12192045520349597797, ; hash 0xa932d8cdf5d49065, from name: libaot-Xamarin.AndroidX.SavedState.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.30_name, ; name: libaot-Xamarin.AndroidX.SavedState.dll.so
		ptr null; void* handle (0x0)
	}, ; 386
	%struct.DSOCacheEntry {
		i64 12276086799428645623, ; hash 0xaa5d6be70fce72f7, from name: libaot-SQLitePCLRaw.provider.e_sqlite3.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.13_name, ; name: libaot-SQLitePCLRaw.provider.e_sqlite3.dll.so
		ptr null; void* handle (0x0)
	}, ; 387
	%struct.DSOCacheEntry {
		i64 12278824155482493573, ; hash 0xaa6725836f051285, from name: libaot-System.Threading.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.90_name, ; name: libaot-System.Threading.dll.so
		ptr null; void* handle (0x0)
	}, ; 388
	%struct.DSOCacheEntry {
		i64 12278928371408744993, ; hash 0xaa67844c1848b221, from name: System.Runtime.InteropServices.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.80_name, ; name: libaot-System.Runtime.InteropServices.dll.so
		ptr null; void* handle (0x0)
	}, ; 389
	%struct.DSOCacheEntry {
		i64 12299321273609848463, ; hash 0xaaaff788a3eb868f, from name: libaot-System.Xml.Linq
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.91_name, ; name: libaot-System.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 390
	%struct.DSOCacheEntry {
		i64 12319133490348723861, ; hash 0xaaf65aa3d0da8e95, from name: libaot-System.Drawing.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.54_name, ; name: libaot-System.Drawing.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 391
	%struct.DSOCacheEntry {
		i64 12338163837237862793, ; hash 0xab39f6a3bb222189, from name: libaot-Mono.Android.Runtime.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.97_name, ; name: libaot-Mono.Android.Runtime.dll.so
		ptr null; void* handle (0x0)
	}, ; 392
	%struct.DSOCacheEntry {
		i64 12362395135250488461, ; hash 0xab900ce0719f5c8d, from name: aot-System.Drawing
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.55_name, ; name: libaot-System.Drawing.dll.so
		ptr null; void* handle (0x0)
	}, ; 393
	%struct.DSOCacheEntry {
		i64 12405317157449198374, ; hash 0xac288a3a7fd16b26, from name: libaot-Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.41_name, ; name: libaot-Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so
		ptr null; void* handle (0x0)
	}, ; 394
	%struct.DSOCacheEntry {
		i64 12439793764729580087, ; hash 0xaca3068529d36a37, from name: libaot-System.ComponentModel.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.46_name, ; name: libaot-System.ComponentModel.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 395
	%struct.DSOCacheEntry {
		i64 12450626906808540265, ; hash 0xacc983349b3e5c69, from name: libaot-System.Net.ServicePoint.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.69_name, ; name: libaot-System.Net.ServicePoint.dll.so
		ptr null; void* handle (0x0)
	}, ; 396
	%struct.DSOCacheEntry {
		i64 12479103209920401597, ; hash 0xad2eae4096be10bd, from name: libaot-System.Net.NameResolution.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.64_name, ; name: libaot-System.Net.NameResolution.dll.so
		ptr null; void* handle (0x0)
	}, ; 397
	%struct.DSOCacheEntry {
		i64 12531980697337323275, ; hash 0xadea8a0c04d7df0b, from name: libaot-Xamarin.AndroidX.AppCompat.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.15_name, ; name: libaot-Xamarin.AndroidX.AppCompat.dll.so
		ptr null; void* handle (0x0)
	}, ; 398
	%struct.DSOCacheEntry {
		i64 12543648076616421447, ; hash 0xae13fd77723bd047, from name: aot-System.IO.IsolatedStorage.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.59_name, ; name: libaot-System.IO.IsolatedStorage.dll.so
		ptr null; void* handle (0x0)
	}, ; 399
	%struct.DSOCacheEntry {
		i64 12546341008866206308, ; hash 0xae1d8eac9862e264, from name: aot-SQLite-net
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.9_name, ; name: libaot-SQLite-net.dll.so
		ptr null; void* handle (0x0)
	}, ; 400
	%struct.DSOCacheEntry {
		i64 12550732019250633519, ; hash 0xae2d28465e8e1b2f, from name: System.IO.Compression
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.58_name, ; name: libaot-System.IO.Compression.dll.so
		ptr null; void* handle (0x0)
	}, ; 401
	%struct.DSOCacheEntry {
		i64 12674984561979589840, ; hash 0xafe6974dde5a84d0, from name: Xamarin.AndroidX.Activity.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.14_name, ; name: libaot-Xamarin.AndroidX.Activity.dll.so
		ptr null; void* handle (0x0)
	}, ; 402
	%struct.DSOCacheEntry {
		i64 12704269318333514606, ; hash 0xb04ea1a28a29c36e, from name: aot-Xamarin.Forms.Platform
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.37_name, ; name: libaot-Xamarin.Forms.Platform.dll.so
		ptr null; void* handle (0x0)
	}, ; 403
	%struct.DSOCacheEntry {
		i64 12872620911514443596, ; hash 0xb2a4bc8457155f4c, from name: aot-Xamarin.AndroidX.CoordinatorLayout.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.19_name, ; name: libaot-Xamarin.AndroidX.CoordinatorLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 404
	%struct.DSOCacheEntry {
		i64 12875951528938057945, ; hash 0xb2b091b2238030d9, from name: Xamarin.AndroidX.DrawerLayout.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.22_name, ; name: libaot-Xamarin.AndroidX.DrawerLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 405
	%struct.DSOCacheEntry {
		i64 12895691319166646681, ; hash 0xb2f6b2ee34043999, from name: aot-System.Runtime.Serialization.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.83_name, ; name: libaot-System.Runtime.Serialization.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 406
	%struct.DSOCacheEntry {
		i64 12937319369933575792, ; hash 0xb38a976c0eabd670, from name: aot-Xamarin.Google.Android.Material.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.39_name, ; name: libaot-Xamarin.Google.Android.Material.dll.so
		ptr null; void* handle (0x0)
	}, ; 407
	%struct.DSOCacheEntry {
		i64 12941098956319990056, ; hash 0xb39804ef96a1a128, from name: Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.16_name, ; name: libaot-Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so
		ptr null; void* handle (0x0)
	}, ; 408
	%struct.DSOCacheEntry {
		i64 12964673882120879242, ; hash 0xb3ebc634bc997c8a, from name: libaot-System.Runtime.Serialization.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.84_name, ; name: libaot-System.Runtime.Serialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 409
	%struct.DSOCacheEntry {
		i64 12996638905122625135, ; hash 0xb45d56399ddb166f, from name: System.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.93_name, ; name: libaot-System.dll.so
		ptr null; void* handle (0x0)
	}, ; 410
	%struct.DSOCacheEntry {
		i64 13006425725023322809, ; hash 0xb4801b49318482b9, from name: libaot-Xamarin.AndroidX.DrawerLayout
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.22_name, ; name: libaot-Xamarin.AndroidX.DrawerLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 411
	%struct.DSOCacheEntry {
		i64 13067966148190955579, ; hash 0xb55abdf987c0683b, from name: Xamarin.AndroidX.Browser.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.17_name, ; name: libaot-Xamarin.AndroidX.Browser.dll.so
		ptr null; void* handle (0x0)
	}, ; 412
	%struct.DSOCacheEntry {
		i64 13073566528136159500, ; hash 0xb56ea37d98fe210c, from name: aot-Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.16_name, ; name: libaot-Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so
		ptr null; void* handle (0x0)
	}, ; 413
	%struct.DSOCacheEntry {
		i64 13101809809254258831, ; hash 0xb5d2fa9aeb54188f, from name: aot-Xamarin.AndroidX.DrawerLayout.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.22_name, ; name: libaot-Xamarin.AndroidX.DrawerLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 414
	%struct.DSOCacheEntry {
		i64 13114936752209646297, ; hash 0xb6019d7d7f2bd2d9, from name: Xamarin.Google.Android.Material.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.39_name, ; name: libaot-Xamarin.Google.Android.Material.dll.so
		ptr null; void* handle (0x0)
	}, ; 415
	%struct.DSOCacheEntry {
		i64 13116315589229894972, ; hash 0xb606838901f75d3c, from name: aot-System.Net.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.66_name, ; name: libaot-System.Net.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 416
	%struct.DSOCacheEntry {
		i64 13222957746497227746, ; hash 0xb78162031ff78be2, from name: libaot-Xamarin.AndroidX.Fragment.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.23_name, ; name: libaot-Xamarin.AndroidX.Fragment.dll.so
		ptr null; void* handle (0x0)
	}, ; 417
	%struct.DSOCacheEntry {
		i64 13295020679054823969, ; hash 0xb88166de18891221, from name: SQLitePCLRaw.provider.e_sqlite3.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.13_name, ; name: libaot-SQLitePCLRaw.provider.e_sqlite3.dll.so
		ptr null; void* handle (0x0)
	}, ; 418
	%struct.DSOCacheEntry {
		i64 13314286428381311703, ; hash 0xb8c5d8f6e978f2d7, from name: libaot-System.Console
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.49_name, ; name: libaot-System.Console.dll.so
		ptr null; void* handle (0x0)
	}, ; 419
	%struct.DSOCacheEntry {
		i64 13343226877734096688, ; hash 0xb92caa265cc90f30, from name: libaot-Xamarin.Forms.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.35_name, ; name: libaot-Xamarin.Forms.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 420
	%struct.DSOCacheEntry {
		i64 13352871532007464144, ; hash 0xb94eede96cbb1cd0, from name: libaot-Xamarin.AndroidX.Activity
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.14_name, ; name: libaot-Xamarin.AndroidX.Activity.dll.so
		ptr null; void* handle (0x0)
	}, ; 421
	%struct.DSOCacheEntry {
		i64 13370592475155966277, ; hash 0xb98de304062ea945, from name: System.Runtime.Serialization
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.84_name, ; name: libaot-System.Runtime.Serialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 422
	%struct.DSOCacheEntry {
		i64 13384594276806126840, ; hash 0xb9bfa19483c16cf8, from name: aot-Xamarin.AndroidX.ViewPager.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.32_name, ; name: libaot-Xamarin.AndroidX.ViewPager.dll.so
		ptr null; void* handle (0x0)
	}, ; 423
	%struct.DSOCacheEntry {
		i64 13431476299110033919, ; hash 0xba663087f18829ff, from name: System.Net.WebClient
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.71_name, ; name: libaot-System.Net.WebClient.dll.so
		ptr null; void* handle (0x0)
	}, ; 424
	%struct.DSOCacheEntry {
		i64 13465488254036897740, ; hash 0xbadf06394d106fcc, from name: Xamarin.Kotlin.StdLib
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.40_name, ; name: libaot-Xamarin.Kotlin.StdLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 425
	%struct.DSOCacheEntry {
		i64 13488491921086969402, ; hash 0xbb30bfefe81d763a, from name: aot-System.ComponentModel
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.48_name, ; name: libaot-System.ComponentModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 426
	%struct.DSOCacheEntry {
		i64 13546874730744599821, ; hash 0xbc002acb0ebf550d, from name: System.Threading.Thread.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.89_name, ; name: libaot-System.Threading.Thread.dll.so
		ptr null; void* handle (0x0)
	}, ; 427
	%struct.DSOCacheEntry {
		i64 13589927487757454067, ; hash 0xbc991f0c2f198af3, from name: libaot-Xamarin.AndroidX.DrawerLayout.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.22_name, ; name: libaot-Xamarin.AndroidX.DrawerLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 428
	%struct.DSOCacheEntry {
		i64 13595227417690135694, ; hash 0xbcabf34e48125c8e, from name: System.IO.IsolatedStorage.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.59_name, ; name: libaot-System.IO.IsolatedStorage.dll.so
		ptr null; void* handle (0x0)
	}, ; 429
	%struct.DSOCacheEntry {
		i64 13646140969043279215, ; hash 0xbd60d4e936babd6f, from name: aot-FormsViewGroup.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.34_name, ; name: libaot-FormsViewGroup.dll.so
		ptr null; void* handle (0x0)
	}, ; 430
	%struct.DSOCacheEntry {
		i64 13699603031714047885, ; hash 0xbe1ec45fad2e278d, from name: libaot-Xamarin.AndroidX.Loader
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.28_name, ; name: libaot-Xamarin.AndroidX.Loader.dll.so
		ptr null; void* handle (0x0)
	}, ; 431
	%struct.DSOCacheEntry {
		i64 13768113933372556022, ; hash 0xbf122aad01c702f6, from name: libaot-System.Security.Cryptography
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.86_name, ; name: libaot-System.Security.Cryptography.dll.so
		ptr null; void* handle (0x0)
	}, ; 432
	%struct.DSOCacheEntry {
		i64 13768883594457632599, ; hash 0xbf14e6adb159cf57, from name: System.IO.IsolatedStorage
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.59_name, ; name: libaot-System.IO.IsolatedStorage.dll.so
		ptr null; void* handle (0x0)
	}, ; 433
	%struct.DSOCacheEntry {
		i64 13784476538474629663, ; hash 0xbf4c4c60e27c8a1f, from name: aot-mscorlib.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.94_name, ; name: libaot-mscorlib.dll.so
		ptr null; void* handle (0x0)
	}, ; 434
	%struct.DSOCacheEntry {
		i64 13786269793005612187, ; hash 0xbf52ab557dcc2c9b, from name: libaot-Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.16_name, ; name: libaot-Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so
		ptr null; void* handle (0x0)
	}, ; 435
	%struct.DSOCacheEntry {
		i64 13807487031629930123, ; hash 0xbf9e0c4cd11d5e8b, from name: libaot-Xamarin.AndroidX.Fragment
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.23_name, ; name: libaot-Xamarin.AndroidX.Fragment.dll.so
		ptr null; void* handle (0x0)
	}, ; 436
	%struct.DSOCacheEntry {
		i64 13839218887849320298, ; hash 0xc00ec84153229f6a, from name: aot-Xamarin.Forms.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.35_name, ; name: libaot-Xamarin.Forms.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 437
	%struct.DSOCacheEntry {
		i64 13842731643823728203, ; hash 0xc01b43168f2c264b, from name: libaot-System.Xml.Linq.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.91_name, ; name: libaot-System.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 438
	%struct.DSOCacheEntry {
		i64 13856099392739027244, ; hash 0xc04ac0fc24b7292c, from name: FormsViewGroup.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.34_name, ; name: libaot-FormsViewGroup.dll.so
		ptr null; void* handle (0x0)
	}, ; 439
	%struct.DSOCacheEntry {
		i64 13888993854737701709, ; hash 0xc0bf9e52e7395b4d, from name: System.Formats.Asn1.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.56_name, ; name: libaot-System.Formats.Asn1.dll.so
		ptr null; void* handle (0x0)
	}, ; 440
	%struct.DSOCacheEntry {
		i64 13900452450741477987, ; hash 0xc0e853db2fa76263, from name: Xamarin.AndroidX.ViewPager.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.32_name, ; name: libaot-Xamarin.AndroidX.ViewPager.dll.so
		ptr null; void* handle (0x0)
	}, ; 441
	%struct.DSOCacheEntry {
		i64 13904753614831582715, ; hash 0xc0f79bbdfd5d7dfb, from name: libaot-Xamarin.AndroidX.Lifecycle.ViewModel
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.27_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.ViewModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 442
	%struct.DSOCacheEntry {
		i64 13927427627500361954, ; hash 0xc14829a2f41ed8e2, from name: aot-System.Private.Uri.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.76_name, ; name: libaot-System.Private.Uri.dll.so
		ptr null; void* handle (0x0)
	}, ; 443
	%struct.DSOCacheEntry {
		i64 13934622921725558032, ; hash 0xc161b9b7f077bd10, from name: aot-Xamarin.AndroidX.RecyclerView
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.29_name, ; name: libaot-Xamarin.AndroidX.RecyclerView.dll.so
		ptr null; void* handle (0x0)
	}, ; 444
	%struct.DSOCacheEntry {
		i64 13959074834287824816, ; hash 0xc1b8989a7ad20fb0, from name: Xamarin.AndroidX.Fragment
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.23_name, ; name: libaot-Xamarin.AndroidX.Fragment.dll.so
		ptr null; void* handle (0x0)
	}, ; 445
	%struct.DSOCacheEntry {
		i64 13967638549803255703, ; hash 0xc1d70541e0134797, from name: Xamarin.Forms.Platform.Android
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.36_name, ; name: libaot-Xamarin.Forms.Platform.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 446
	%struct.DSOCacheEntry {
		i64 13972136905349029688, ; hash 0xc1e7007ce4745f38, from name: libaot-System.Net.Sockets.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.70_name, ; name: libaot-System.Net.Sockets.dll.so
		ptr null; void* handle (0x0)
	}, ; 447
	%struct.DSOCacheEntry {
		i64 14024723203617446143, ; hash 0xc2a1d37290cbd8ff, from name: libaot-System.ComponentModel.TypeConverter
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.47_name, ; name: libaot-System.ComponentModel.TypeConverter.dll.so
		ptr null; void* handle (0x0)
	}, ; 448
	%struct.DSOCacheEntry {
		i64 14037761671920318323, ; hash 0xc2d025dd88677773, from name: aot-System.Threading
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.90_name, ; name: libaot-System.Threading.dll.so
		ptr null; void* handle (0x0)
	}, ; 449
	%struct.DSOCacheEntry {
		i64 14058709349301150578, ; hash 0xc31a91aabd8ee372, from name: System.IO.Compression.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.58_name, ; name: libaot-System.IO.Compression.dll.so
		ptr null; void* handle (0x0)
	}, ; 450
	%struct.DSOCacheEntry {
		i64 14064151877224080280, ; hash 0xc32de79e0515a398, from name: aot-System.Formats.Asn1.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.56_name, ; name: libaot-System.Formats.Asn1.dll.so
		ptr null; void* handle (0x0)
	}, ; 451
	%struct.DSOCacheEntry {
		i64 14124974489674258913, ; hash 0xc405fd76067d19e1, from name: Xamarin.AndroidX.CardView
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.18_name, ; name: libaot-Xamarin.AndroidX.CardView.dll.so
		ptr null; void* handle (0x0)
	}, ; 452
	%struct.DSOCacheEntry {
		i64 14137679297576702812, ; hash 0xc433206aa074135c, from name: aot-System.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.50_name, ; name: libaot-System.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 453
	%struct.DSOCacheEntry {
		i64 14143988164198918098, ; hash 0xc4498a4c1a67e7d2, from name: System.Threading.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.90_name, ; name: libaot-System.Threading.dll.so
		ptr null; void* handle (0x0)
	}, ; 454
	%struct.DSOCacheEntry {
		i64 14152660198772281192, ; hash 0xc46859777ea18f68, from name: libaot-System.Collections.Concurrent.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.42_name, ; name: libaot-System.Collections.Concurrent.dll.so
		ptr null; void* handle (0x0)
	}, ; 455
	%struct.DSOCacheEntry {
		i64 14174671189317472550, ; hash 0xc4b68c58973b5126, from name: libaot-System.Text.RegularExpressions.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.87_name, ; name: libaot-System.Text.RegularExpressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 456
	%struct.DSOCacheEntry {
		i64 14182888721008485466, ; hash 0xc4d3be25c89ae45a, from name: aot-System.Console
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.49_name, ; name: libaot-System.Console.dll.so
		ptr null; void* handle (0x0)
	}, ; 457
	%struct.DSOCacheEntry {
		i64 14230396410514008665, ; hash 0xc57c8623b5ae6a59, from name: aot-System.Collections
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.45_name, ; name: libaot-System.Collections.dll.so
		ptr null; void* handle (0x0)
	}, ; 458
	%struct.DSOCacheEntry {
		i64 14244268896140588737, ; hash 0xc5adcf17779af6c1, from name: aot-System.Net.WebClient.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.71_name, ; name: libaot-System.Net.WebClient.dll.so
		ptr null; void* handle (0x0)
	}, ; 459
	%struct.DSOCacheEntry {
		i64 14317997431913345095, ; hash 0xc6b3becde8267047, from name: aot-System.Collections.Specialized.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.44_name, ; name: libaot-System.Collections.Specialized.dll.so
		ptr null; void* handle (0x0)
	}, ; 460
	%struct.DSOCacheEntry {
		i64 14343351667264400691, ; hash 0xc70dd258d7cd2d33, from name: libaot-Xamarin.AndroidX.Lifecycle.Common.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.25_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.Common.dll.so
		ptr null; void* handle (0x0)
	}, ; 461
	%struct.DSOCacheEntry {
		i64 14343849879592858025, ; hash 0xc70f9777f0a971a9, from name: System.Xml.Linq.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.91_name, ; name: libaot-System.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 462
	%struct.DSOCacheEntry {
		i64 14351510784141839845, ; hash 0xc72acf0546f64de5, from name: aot-Java.Interop
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.96_name, ; name: libaot-Java.Interop.dll.so
		ptr null; void* handle (0x0)
	}, ; 463
	%struct.DSOCacheEntry {
		i64 14360875924539294536, ; hash 0xc74c1490f19fc348, from name: Xamarin.AndroidX.Lifecycle.Common.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.25_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.Common.dll.so
		ptr null; void* handle (0x0)
	}, ; 464
	%struct.DSOCacheEntry {
		i64 14424844866220670826, ; hash 0xc82f57facf333f6a, from name: monosgen-2.0.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.5_name, ; name: libmonosgen-2.0.so
		ptr null; void* handle (0x0)
	}, ; 465
	%struct.DSOCacheEntry {
		i64 14562678984415238708, ; hash 0xca190761441dda34, from name: aot-Xamarin.AndroidX.SwipeRefreshLayout
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.31_name, ; name: libaot-Xamarin.AndroidX.SwipeRefreshLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 466
	%struct.DSOCacheEntry {
		i64 14604015534980822382, ; hash 0xcaabe2c0f0d1756e, from name: aot-System.Net.Http
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.63_name, ; name: libaot-System.Net.Http.dll.so
		ptr null; void* handle (0x0)
	}, ; 467
	%struct.DSOCacheEntry {
		i64 14611435504614518872, ; hash 0xcac63f2d3f143058, from name: System.Net.NetworkInformation.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.65_name, ; name: libaot-System.Net.NetworkInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 468
	%struct.DSOCacheEntry {
		i64 14622043554576106986, ; hash 0xcaebef2458cc85ea, from name: System.Runtime.Serialization.Formatters
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.82_name, ; name: libaot-System.Runtime.Serialization.Formatters.dll.so
		ptr null; void* handle (0x0)
	}, ; 469
	%struct.DSOCacheEntry {
		i64 14713405421650509891, ; hash 0xcc308446a9c90043, from name: libaot-System.Collections.NonGeneric.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.43_name, ; name: libaot-System.Collections.NonGeneric.dll.so
		ptr null; void* handle (0x0)
	}, ; 470
	%struct.DSOCacheEntry {
		i64 14726144688497773647, ; hash 0xcc5dc6925cea4c4f, from name: libaot-Xamarin.AndroidX.Loader.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.28_name, ; name: libaot-Xamarin.AndroidX.Loader.dll.so
		ptr null; void* handle (0x0)
	}, ; 471
	%struct.DSOCacheEntry {
		i64 14749613074536373161, ; hash 0xccb126f1ca329ba9, from name: aot-Xamarin.AndroidX.Lifecycle.ViewModel.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.27_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.ViewModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 472
	%struct.DSOCacheEntry {
		i64 14755978183439467193, ; hash 0xccc7c3fa3152c2b9, from name: aot-System.IO.IsolatedStorage
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.59_name, ; name: libaot-System.IO.IsolatedStorage.dll.so
		ptr null; void* handle (0x0)
	}, ; 473
	%struct.DSOCacheEntry {
		i64 14758955907351428233, ; hash 0xccd258339155bc89, from name: SQLitePCLRaw.batteries_v2.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.10_name, ; name: libaot-SQLitePCLRaw.batteries_v2.dll.so
		ptr null; void* handle (0x0)
	}, ; 474
	%struct.DSOCacheEntry {
		i64 14761658010069183920, ; hash 0xccdbf1bfe1f92db0, from name: libaot-Xamarin.AndroidX.Lifecycle.ViewModel.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.27_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.ViewModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 475
	%struct.DSOCacheEntry {
		i64 14797884060996115029, ; hash 0xcd5ca526a3169a55, from name: aot-System.Net.Requests
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.67_name, ; name: libaot-System.Net.Requests.dll.so
		ptr null; void* handle (0x0)
	}, ; 476
	%struct.DSOCacheEntry {
		i64 14848298015145851925, ; hash 0xce0fc06007e7fc15, from name: aot-Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.26_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 477
	%struct.DSOCacheEntry {
		i64 14852025521463078876, ; hash 0xce1cfe85b9d7afdc, from name: aot-Xamarin.AndroidX.Loader.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.28_name, ; name: libaot-Xamarin.AndroidX.Loader.dll.so
		ptr null; void* handle (0x0)
	}, ; 478
	%struct.DSOCacheEntry {
		i64 14984936317414011727, ; hash 0xcff5302fe54ff34f, from name: System.Net.WebHeaderCollection
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.72_name, ; name: libaot-System.Net.WebHeaderCollection.dll.so
		ptr null; void* handle (0x0)
	}, ; 479
	%struct.DSOCacheEntry {
		i64 15169277521300507936, ; hash 0xd28419890c6f4d20, from name: aot-System.Threading.Thread.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.89_name, ; name: libaot-System.Threading.Thread.dll.so
		ptr null; void* handle (0x0)
	}, ; 480
	%struct.DSOCacheEntry {
		i64 15216590919956829692, ; hash 0xd32c30d21c7615fc, from name: mscorlib.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.94_name, ; name: libaot-mscorlib.dll.so
		ptr null; void* handle (0x0)
	}, ; 481
	%struct.DSOCacheEntry {
		i64 15287759098695794728, ; hash 0xd42907e6f9824028, from name: System.IO.Compression.Brotli.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.57_name, ; name: libaot-System.IO.Compression.Brotli.dll.so
		ptr null; void* handle (0x0)
	}, ; 482
	%struct.DSOCacheEntry {
		i64 15361183609531804313, ; hash 0xd52de31b17b22a99, from name: System.Collections.Concurrent.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.42_name, ; name: libaot-System.Collections.Concurrent.dll.so
		ptr null; void* handle (0x0)
	}, ; 483
	%struct.DSOCacheEntry {
		i64 15371816955219117674, ; hash 0xd553aa13d029866a, from name: libaot-System.ComponentModel
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.48_name, ; name: libaot-System.ComponentModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 484
	%struct.DSOCacheEntry {
		i64 15394198501530322172, ; hash 0xd5a32df9a590c4fc, from name: libaot-Mono.Android
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.98_name, ; name: libaot-Mono.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 485
	%struct.DSOCacheEntry {
		i64 15420320794302889280, ; hash 0xd5fffc0fe2fe3d40, from name: aot-System.Numerics.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.73_name, ; name: libaot-System.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 486
	%struct.DSOCacheEntry {
		i64 15422501938551467493, ; hash 0xd607bbcd1b222de5, from name: System.ComponentModel.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.48_name, ; name: libaot-System.ComponentModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 487
	%struct.DSOCacheEntry {
		i64 15441728228412085485, ; hash 0xd64c0a028c9fd4ed, from name: libaot-System.Runtime.Numerics
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.81_name, ; name: libaot-System.Runtime.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 488
	%struct.DSOCacheEntry {
		i64 15465553130743477305, ; hash 0xd6a0aea1e4e53439, from name: System.Net.NameResolution.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.64_name, ; name: libaot-System.Net.NameResolution.dll.so
		ptr null; void* handle (0x0)
	}, ; 489
	%struct.DSOCacheEntry {
		i64 15489493229072521270, ; hash 0xd6f5bc0665af9836, from name: aot-Xamarin.AndroidX.CursorAdapter
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.21_name, ; name: libaot-Xamarin.AndroidX.CursorAdapter.dll.so
		ptr null; void* handle (0x0)
	}, ; 490
	%struct.DSOCacheEntry {
		i64 15503723175688157554, ; hash 0xd7284a1606e23972, from name: aot-System.Private.CoreLib
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.99_name, ; name: libaot-System.Private.CoreLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 491
	%struct.DSOCacheEntry {
		i64 15527772828719725935, ; hash 0xd77dbb1e38cd3d6f, from name: System.Console
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.49_name, ; name: libaot-System.Console.dll.so
		ptr null; void* handle (0x0)
	}, ; 492
	%struct.DSOCacheEntry {
		i64 15557562860424774966, ; hash 0xd7e790fe7a6dc536, from name: System.Net.Sockets
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.70_name, ; name: libaot-System.Net.Sockets.dll.so
		ptr null; void* handle (0x0)
	}, ; 493
	%struct.DSOCacheEntry {
		i64 15599084397433935389, ; hash 0xd87b149caa63561d, from name: Xamarin.Forms.Core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.35_name, ; name: libaot-Xamarin.Forms.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 494
	%struct.DSOCacheEntry {
		i64 15602862011767004647, ; hash 0xd88880550acf1de7, from name: aot-Xamarin.AndroidX.Lifecycle.LiveData.Core
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.26_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so
		ptr null; void* handle (0x0)
	}, ; 495
	%struct.DSOCacheEntry {
		i64 15617887668700861200, ; hash 0xd8bde2166ade5310, from name: aot-System.Net.Requests.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.67_name, ; name: libaot-System.Net.Requests.dll.so
		ptr null; void* handle (0x0)
	}, ; 496
	%struct.DSOCacheEntry {
		i64 15619787930512100580, ; hash 0xd8c4a25d991b8ce4, from name: libaot-System.Diagnostics.TraceSource.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.53_name, ; name: libaot-System.Diagnostics.TraceSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 497
	%struct.DSOCacheEntry {
		i64 15659595283356337508, ; hash 0xd9520ef12ed64564, from name: aot-System.Net.Security
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.68_name, ; name: libaot-System.Net.Security.dll.so
		ptr null; void* handle (0x0)
	}, ; 498
	%struct.DSOCacheEntry {
		i64 15742342285542832975, ; hash 0xda7808e6f6643b4f, from name: libaot-System.ComponentModel.TypeConverter.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.47_name, ; name: libaot-System.ComponentModel.TypeConverter.dll.so
		ptr null; void* handle (0x0)
	}, ; 499
	%struct.DSOCacheEntry {
		i64 15810740023422282496, ; hash 0xdb6b08484c22eb00, from name: Xamarin.Forms.Xaml
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.38_name, ; name: libaot-Xamarin.Forms.Xaml.dll.so
		ptr null; void* handle (0x0)
	}, ; 500
	%struct.DSOCacheEntry {
		i64 15847727014260307913, ; hash 0xdbee6fc12e58f7c9, from name: aot-Xamarin.AndroidX.SavedState.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.30_name, ; name: libaot-Xamarin.AndroidX.SavedState.dll.so
		ptr null; void* handle (0x0)
	}, ; 501
	%struct.DSOCacheEntry {
		i64 15869986477656553338, ; hash 0xdc3d849e5ef8b77a, from name: libaot-System.Collections.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.45_name, ; name: libaot-System.Collections.dll.so
		ptr null; void* handle (0x0)
	}, ; 502
	%struct.DSOCacheEntry {
		i64 15908591910761673656, ; hash 0xdcc6ac0e359a33b8, from name: aot-Xamarin.KotlinX.Coroutines.Core.Jvm
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.41_name, ; name: libaot-Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so
		ptr null; void* handle (0x0)
	}, ; 503
	%struct.DSOCacheEntry {
		i64 15920910109220503623, ; hash 0xdcf26f6449038047, from name: System.Private.CoreLib.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.99_name, ; name: libaot-System.Private.CoreLib.dll.so
		ptr null; void* handle (0x0)
	}, ; 504
	%struct.DSOCacheEntry {
		i64 15953629603678197891, ; hash 0xdd66ad993d651883, from name: libaot-System.Diagnostics.StackTrace
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.52_name, ; name: libaot-System.Diagnostics.StackTrace.dll.so
		ptr null; void* handle (0x0)
	}, ; 505
	%struct.DSOCacheEntry {
		i64 15958977808799221818, ; hash 0xdd79adc347d1c83a, from name: System.Net.Security.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.68_name, ; name: libaot-System.Net.Security.dll.so
		ptr null; void* handle (0x0)
	}, ; 506
	%struct.DSOCacheEntry {
		i64 15964641699753034279, ; hash 0xdd8dcd0aa82b0227, from name: libaot-Xamarin.AndroidX.SwipeRefreshLayout
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.31_name, ; name: libaot-Xamarin.AndroidX.SwipeRefreshLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 507
	%struct.DSOCacheEntry {
		i64 16004199028078918232, ; hash 0xde1a5638df4bba58, from name: System.Net.WebHeaderCollection.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.72_name, ; name: libaot-System.Net.WebHeaderCollection.dll.so
		ptr null; void* handle (0x0)
	}, ; 508
	%struct.DSOCacheEntry {
		i64 16011614235295386646, ; hash 0xde34ae50575e8c16, from name: System.Net.ServicePoint.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.69_name, ; name: libaot-System.Net.ServicePoint.dll.so
		ptr null; void* handle (0x0)
	}, ; 509
	%struct.DSOCacheEntry {
		i64 16113014851066227886, ; hash 0xdf9ceda2fa656cae, from name: Xamarin.Essentials.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.33_name, ; name: libaot-Xamarin.Essentials.dll.so
		ptr null; void* handle (0x0)
	}, ; 510
	%struct.DSOCacheEntry {
		i64 16140149539819930312, ; hash 0xdffd547e06a6c2c8, from name: libaot-Xamarin.AndroidX.CoordinatorLayout
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.19_name, ; name: libaot-Xamarin.AndroidX.CoordinatorLayout.dll.so
		ptr null; void* handle (0x0)
	}, ; 511
	%struct.DSOCacheEntry {
		i64 16151644148648336944, ; hash 0xe0262ac732b35e30, from name: aot-Xamarin.AndroidX.Browser
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.17_name, ; name: libaot-Xamarin.AndroidX.Browser.dll.so
		ptr null; void* handle (0x0)
	}, ; 512
	%struct.DSOCacheEntry {
		i64 16154507427712707110, ; hash 0xe03056ea4e39aa26, from name: System
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.93_name, ; name: libaot-System.dll.so
		ptr null; void* handle (0x0)
	}, ; 513
	%struct.DSOCacheEntry {
		i64 16210911171323730879, ; hash 0xe0f8b9d23c299bbf, from name: libaot-System.Private.DataContractSerialization.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.75_name, ; name: libaot-System.Private.DataContractSerialization.dll.so
		ptr null; void* handle (0x0)
	}, ; 514
	%struct.DSOCacheEntry {
		i64 16215129991522364183, ; hash 0xe107b6d0db792b17, from name: libaot-Xamarin.AndroidX.Activity.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.14_name, ; name: libaot-Xamarin.AndroidX.Activity.dll.so
		ptr null; void* handle (0x0)
	}, ; 515
	%struct.DSOCacheEntry {
		i64 16217712076265891113, ; hash 0xe110e3354f642529, from name: libmono-component-marshal-ilgen.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.4_name, ; name: libmono-component-marshal-ilgen.so
		ptr null; void* handle (0x0)
	}, ; 516
	%struct.DSOCacheEntry {
		i64 16219561732052121626, ; hash 0xe1177575db7c781a, from name: System.Net.Security
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.68_name, ; name: libaot-System.Net.Security.dll.so
		ptr null; void* handle (0x0)
	}, ; 517
	%struct.DSOCacheEntry {
		i64 16253390427661688581, ; hash 0xe18fa47ad4825f05, from name: libaot-System.Linq.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.61_name, ; name: libaot-System.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 518
	%struct.DSOCacheEntry {
		i64 16273606707797624453, ; hash 0xe1d7771458b10685, from name: System.Native.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.2_name, ; name: libSystem.Native.so
		ptr null; void* handle (0x0)
	}, ; 519
	%struct.DSOCacheEntry {
		i64 16354813168604688526, ; hash 0xe2f7f7ece290308e, from name: aot-System.Drawing.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.54_name, ; name: libaot-System.Drawing.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 520
	%struct.DSOCacheEntry {
		i64 16366947651169500459, ; hash 0xe323142c455f3d2b, from name: libaot-SQLitePCLRaw.batteries_v2
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.10_name, ; name: libaot-SQLitePCLRaw.batteries_v2.dll.so
		ptr null; void* handle (0x0)
	}, ; 521
	%struct.DSOCacheEntry {
		i64 16370340268830916137, ; hash 0xe32f21bd9ff07e29, from name: System.Linq.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.61_name, ; name: libaot-System.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 522
	%struct.DSOCacheEntry {
		i64 16411908373586787849, ; hash 0xe3c2cfb635e63e09, from name: libaot-System.Drawing.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.54_name, ; name: libaot-System.Drawing.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 523
	%struct.DSOCacheEntry {
		i64 16413721059704043258, ; hash 0xe3c940571601f6fa, from name: aot-System.Console.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.49_name, ; name: libaot-System.Console.dll.so
		ptr null; void* handle (0x0)
	}, ; 524
	%struct.DSOCacheEntry {
		i64 16454459195343277943, ; hash 0xe459fb756d988f77, from name: System.Net.NetworkInformation
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.65_name, ; name: libaot-System.Net.NetworkInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 525
	%struct.DSOCacheEntry {
		i64 16477862173331498088, ; hash 0xe4ad2057db452468, from name: Xamarin.AndroidX.SavedState.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.30_name, ; name: libaot-Xamarin.AndroidX.SavedState.dll.so
		ptr null; void* handle (0x0)
	}, ; 526
	%struct.DSOCacheEntry {
		i64 16500515576684549758, ; hash 0xe4fd9b7e5715167e, from name: aot-SQLitePCLRaw.batteries_v2.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.10_name, ; name: libaot-SQLitePCLRaw.batteries_v2.dll.so
		ptr null; void* handle (0x0)
	}, ; 527
	%struct.DSOCacheEntry {
		i64 16504549732499142624, ; hash 0xe50bf0896f6137e0, from name: libaot-System.IO.IsolatedStorage
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.59_name, ; name: libaot-System.IO.IsolatedStorage.dll.so
		ptr null; void* handle (0x0)
	}, ; 528
	%struct.DSOCacheEntry {
		i64 16527633514543998540, ; hash 0xe55df31d443c664c, from name: aot-UniversityAndroidApp.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.8_name, ; name: libaot-UniversityAndroidApp.dll.so
		ptr null; void* handle (0x0)
	}, ; 529
	%struct.DSOCacheEntry {
		i64 16717189724135467099, ; hash 0xe7ff637b8de7a85b, from name: libmonosgen-2.0.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.5_name, ; name: libmonosgen-2.0.so
		ptr null; void* handle (0x0)
	}, ; 530
	%struct.DSOCacheEntry {
		i64 16730696072636839813, ; hash 0xe82f5f6f5e8ab785, from name: libaot-Xamarin.AndroidX.CursorAdapter.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.21_name, ; name: libaot-Xamarin.AndroidX.CursorAdapter.dll.so
		ptr null; void* handle (0x0)
	}, ; 531
	%struct.DSOCacheEntry {
		i64 16733100980842614628, ; hash 0xe837eaafb1dd4f64, from name: libaot-System.IO.Compression.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.58_name, ; name: libaot-System.IO.Compression.dll.so
		ptr null; void* handle (0x0)
	}, ; 532
	%struct.DSOCacheEntry {
		i64 16768067971893542065, ; hash 0xe8b424faba51bcb1, from name: libaot-Mono.Android.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.98_name, ; name: libaot-Mono.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 533
	%struct.DSOCacheEntry {
		i64 16804602679676381986, ; hash 0xe935f11a41b02b22, from name: monosgen-2.0
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.5_name, ; name: libmonosgen-2.0.so
		ptr null; void* handle (0x0)
	}, ; 534
	%struct.DSOCacheEntry {
		i64 16812641203226435415, ; hash 0xe9528018de685f57, from name: libaot-System.Private.Xml.Linq
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.77_name, ; name: libaot-System.Private.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 535
	%struct.DSOCacheEntry {
		i64 16818814240165112060, ; hash 0xe9686e710852a8fc, from name: aot-System.Private.Xml
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.78_name, ; name: libaot-System.Private.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 536
	%struct.DSOCacheEntry {
		i64 16833383113903931215, ; hash 0xe99c30c1484d7f4f, from name: mscorlib
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.94_name, ; name: libaot-mscorlib.dll.so
		ptr null; void* handle (0x0)
	}, ; 537
	%struct.DSOCacheEntry {
		i64 16924802110373038789, ; hash 0xeae0f9d912910ac5, from name: libaot-System.IO.Compression.Brotli.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.57_name, ; name: libaot-System.IO.Compression.Brotli.dll.so
		ptr null; void* handle (0x0)
	}, ; 538
	%struct.DSOCacheEntry {
		i64 16926798323237543726, ; hash 0xeae8116499405f2e, from name: libaot-System.Formats.Asn1
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.56_name, ; name: libaot-System.Formats.Asn1.dll.so
		ptr null; void* handle (0x0)
	}, ; 539
	%struct.DSOCacheEntry {
		i64 16948040093346346617, ; hash 0xeb3388ab9afcb679, from name: System.ComponentModel.Primitives.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.46_name, ; name: libaot-System.ComponentModel.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 540
	%struct.DSOCacheEntry {
		i64 17008137082415910100, ; hash 0xec090a90408c8cd4, from name: System.Collections.NonGeneric
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.43_name, ; name: libaot-System.Collections.NonGeneric.dll.so
		ptr null; void* handle (0x0)
	}, ; 541
	%struct.DSOCacheEntry {
		i64 17062143951396181894, ; hash 0xecc8e986518c9786, from name: System.ComponentModel.Primitives
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.46_name, ; name: libaot-System.ComponentModel.Primitives.dll.so
		ptr null; void* handle (0x0)
	}, ; 542
	%struct.DSOCacheEntry {
		i64 17118171214553292978, ; hash 0xed8ff6060fc420b2, from name: System.Threading.Channels
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.88_name, ; name: libaot-System.Threading.Channels.dll.so
		ptr null; void* handle (0x0)
	}, ; 543
	%struct.DSOCacheEntry {
		i64 17230721278011714856, ; hash 0xef1fd1b5c7a72d28, from name: System.Private.Xml.Linq
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.77_name, ; name: libaot-System.Private.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	}, ; 544
	%struct.DSOCacheEntry {
		i64 17307240838015558791, ; hash 0xf02fabd8300d2487, from name: libaot-System.Net.NetworkInformation
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.65_name, ; name: libaot-System.Net.NetworkInformation.dll.so
		ptr null; void* handle (0x0)
	}, ; 545
	%struct.DSOCacheEntry {
		i64 17309541862275468045, ; hash 0xf037d89d25aecb0d, from name: Mono.Android.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.98_name, ; name: libaot-Mono.Android.dll.so
		ptr null; void* handle (0x0)
	}, ; 546
	%struct.DSOCacheEntry {
		i64 17435078777942294054, ; hash 0xf1f5d7c60633be26, from name: libaot-Xamarin.Essentials.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.33_name, ; name: libaot-Xamarin.Essentials.dll.so
		ptr null; void* handle (0x0)
	}, ; 547
	%struct.DSOCacheEntry {
		i64 17474527379847198219, ; hash 0xf281fe1165a1360b, from name: libaot-System
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.93_name, ; name: libaot-System.dll.so
		ptr null; void* handle (0x0)
	}, ; 548
	%struct.DSOCacheEntry {
		i64 17479433570620501354, ; hash 0xf2936c38f3df6d6a, from name: aot-System.Diagnostics.StackTrace
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.52_name, ; name: libaot-System.Diagnostics.StackTrace.dll.so
		ptr null; void* handle (0x0)
	}, ; 549
	%struct.DSOCacheEntry {
		i64 17501557440705411739, ; hash 0xf2e205c3dd573a9b, from name: libaot-System.Net.Requests.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.67_name, ; name: libaot-System.Net.Requests.dll.so
		ptr null; void* handle (0x0)
	}, ; 550
	%struct.DSOCacheEntry {
		i64 17577202782581072989, ; hash 0xf3eec4cd80c0a45d, from name: System.IO.Compression.Native
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.1_name, ; name: libSystem.IO.Compression.Native.so
		ptr null; void* handle (0x0)
	}, ; 551
	%struct.DSOCacheEntry {
		i64 17621652644066257425, ; hash 0xf48cafb75ce46a11, from name: libaot-System.Threading
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.90_name, ; name: libaot-System.Threading.dll.so
		ptr null; void* handle (0x0)
	}, ; 552
	%struct.DSOCacheEntry {
		i64 17623318455445168472, ; hash 0xf4929ac34c652158, from name: libaot-System.Linq.Expressions
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.60_name, ; name: libaot-System.Linq.Expressions.dll.so
		ptr null; void* handle (0x0)
	}, ; 553
	%struct.DSOCacheEntry {
		i64 17634962315631480230, ; hash 0xf4bbf8cac29d4da6, from name: aot-System.Drawing.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.55_name, ; name: libaot-System.Drawing.dll.so
		ptr null; void* handle (0x0)
	}, ; 554
	%struct.DSOCacheEntry {
		i64 17635730081727385264, ; hash 0xf4beb3123c080eb0, from name: libaot-Xamarin.AndroidX.Browser
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.17_name, ; name: libaot-Xamarin.AndroidX.Browser.dll.so
		ptr null; void* handle (0x0)
	}, ; 555
	%struct.DSOCacheEntry {
		i64 17672164719550421811, ; hash 0xf540242e68fe5b33, from name: aot-Xamarin.Essentials.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.33_name, ; name: libaot-Xamarin.Essentials.dll.so
		ptr null; void* handle (0x0)
	}, ; 556
	%struct.DSOCacheEntry {
		i64 17678238194885447556, ; hash 0xf555b7f994e3cf84, from name: aot-System.Diagnostics.TraceSource.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.53_name, ; name: libaot-System.Diagnostics.TraceSource.dll.so
		ptr null; void* handle (0x0)
	}, ; 557
	%struct.DSOCacheEntry {
		i64 17694752640166504414, ; hash 0xf59063c68187a7de, from name: libaot-System.Net.ServicePoint
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.69_name, ; name: libaot-System.Net.ServicePoint.dll.so
		ptr null; void* handle (0x0)
	}, ; 558
	%struct.DSOCacheEntry {
		i64 17700327150769387356, ; hash 0xf5a431c365cfb75c, from name: System.Numerics.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.73_name, ; name: libaot-System.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 559
	%struct.DSOCacheEntry {
		i64 17704177640604968747, ; hash 0xf5b1dfc36cac272b, from name: Xamarin.AndroidX.Loader
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.28_name, ; name: libaot-Xamarin.AndroidX.Loader.dll.so
		ptr null; void* handle (0x0)
	}, ; 560
	%struct.DSOCacheEntry {
		i64 17710060891934109755, ; hash 0xf5c6c68c9e45303b, from name: Xamarin.AndroidX.Lifecycle.ViewModel
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.27_name, ; name: libaot-Xamarin.AndroidX.Lifecycle.ViewModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 561
	%struct.DSOCacheEntry {
		i64 17729255244101106781, ; hash 0xf60af7b5fce0bc5d, from name: aot-System.Net.WebHeaderCollection
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.72_name, ; name: libaot-System.Net.WebHeaderCollection.dll.so
		ptr null; void* handle (0x0)
	}, ; 562
	%struct.DSOCacheEntry {
		i64 17743242089888636773, ; hash 0xf63ca8ac4b925f65, from name: aot-Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.41_name, ; name: libaot-Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so
		ptr null; void* handle (0x0)
	}, ; 563
	%struct.DSOCacheEntry {
		i64 17798155118191535816, ; hash 0xf6ffbfc8051b66c8, from name: Java.Interop.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.96_name, ; name: libaot-Java.Interop.dll.so
		ptr null; void* handle (0x0)
	}, ; 564
	%struct.DSOCacheEntry {
		i64 17806127868189959114, ; hash 0xf71c12f488a563ca, from name: libaot-SQLitePCLRaw.core.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.11_name, ; name: libaot-SQLitePCLRaw.core.dll.so
		ptr null; void* handle (0x0)
	}, ; 565
	%struct.DSOCacheEntry {
		i64 17882897186074144999, ; hash 0xf82cd03e3ac830e7, from name: FormsViewGroup
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.34_name, ; name: libaot-FormsViewGroup.dll.so
		ptr null; void* handle (0x0)
	}, ; 566
	%struct.DSOCacheEntry {
		i64 17895855011690415023, ; hash 0xf85ad9511bb383af, from name: Xamarin.AndroidX.Legacy.Support.Core.UI.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.24_name, ; name: libaot-Xamarin.AndroidX.Legacy.Support.Core.UI.dll.so
		ptr null; void* handle (0x0)
	}, ; 567
	%struct.DSOCacheEntry {
		i64 17902061051722335752, ; hash 0xf870e5ad67440608, from name: aot-System.Net.WebHeaderCollection.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.72_name, ; name: libaot-System.Net.WebHeaderCollection.dll.so
		ptr null; void* handle (0x0)
	}, ; 568
	%struct.DSOCacheEntry {
		i64 17927396739616034639, ; hash 0xf8cae859ec4f4f4f, from name: libaot-System.Xml.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.92_name, ; name: libaot-System.Xml.dll.so
		ptr null; void* handle (0x0)
	}, ; 569
	%struct.DSOCacheEntry {
		i64 17935984482491575587, ; hash 0xf8e96adb9fd42d23, from name: aot-System.Threading.Thread
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.89_name, ; name: libaot-System.Threading.Thread.dll.so
		ptr null; void* handle (0x0)
	}, ; 570
	%struct.DSOCacheEntry {
		i64 17936373173282875089, ; hash 0xf8eacc5ec05f26d1, from name: libaot-System.Runtime.Numerics.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.81_name, ; name: libaot-System.Runtime.Numerics.dll.so
		ptr null; void* handle (0x0)
	}, ; 571
	%struct.DSOCacheEntry {
		i64 17965456619802214728, ; hash 0xf9521f9c53004148, from name: libaot-SQLitePCLRaw.batteries_v2.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.10_name, ; name: libaot-SQLitePCLRaw.batteries_v2.dll.so
		ptr null; void* handle (0x0)
	}, ; 572
	%struct.DSOCacheEntry {
		i64 17966837238658391933, ; hash 0xf9570746b37e5f7d, from name: libaot-System.Collections.NonGeneric
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.43_name, ; name: libaot-System.Collections.NonGeneric.dll.so
		ptr null; void* handle (0x0)
	}, ; 573
	%struct.DSOCacheEntry {
		i64 18025913125965088385, ; hash 0xfa28e87b91334681, from name: System.Threading
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.90_name, ; name: libaot-System.Threading.dll.so
		ptr null; void* handle (0x0)
	}, ; 574
	%struct.DSOCacheEntry {
		i64 18086360900563295465, ; hash 0xfaffa969d596dce9, from name: aot-System.ObjectModel
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.74_name, ; name: libaot-System.ObjectModel.dll.so
		ptr null; void* handle (0x0)
	}, ; 575
	%struct.DSOCacheEntry {
		i64 18145848498878603418, ; hash 0xfbd30111a3b6e09a, from name: libSystem.IO.Compression.Native
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.1_name, ; name: libSystem.IO.Compression.Native.so
		ptr null; void* handle (0x0)
	}, ; 576
	%struct.DSOCacheEntry {
		i64 18165731239199853668, ; hash 0xfc19a450ddb94c64, from name: aot-SQLite-net.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.9_name, ; name: libaot-SQLite-net.dll.so
		ptr null; void* handle (0x0)
	}, ; 577
	%struct.DSOCacheEntry {
		i64 18226465753896977720, ; hash 0xfcf16a0903da0538, from name: libaot-System.Private.Uri
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.76_name, ; name: libaot-System.Private.Uri.dll.so
		ptr null; void* handle (0x0)
	}, ; 578
	%struct.DSOCacheEntry {
		i64 18253685954460439423, ; hash 0xfd521ea9d526d37f, from name: aot-Xamarin.AndroidX.CardView
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.18_name, ; name: libaot-Xamarin.AndroidX.CardView.dll.so
		ptr null; void* handle (0x0)
	}, ; 579
	%struct.DSOCacheEntry {
		i64 18257096356770733190, ; hash 0xfd5e3c67ff65dc86, from name: libSystem.Security.Cryptography.Native.Android.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.3_name, ; name: libSystem.Security.Cryptography.Native.Android.so
		ptr null; void* handle (0x0)
	}, ; 580
	%struct.DSOCacheEntry {
		i64 18292328407895211277, ; hash 0xfddb67c523617d0d, from name: aot-System.IO.Compression.Brotli.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.57_name, ; name: libaot-System.IO.Compression.Brotli.dll.so
		ptr null; void* handle (0x0)
	}, ; 581
	%struct.DSOCacheEntry {
		i64 18309516218928916979, ; hash 0xfe1877fe3e82e9f3, from name: libaot-System.Security.Cryptography.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.86_name, ; name: libaot-System.Security.Cryptography.dll.so
		ptr null; void* handle (0x0)
	}, ; 582
	%struct.DSOCacheEntry {
		i64 18327710550568384473, ; hash 0xfe591ba430ceb7d9, from name: libaot-Java.Interop
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.96_name, ; name: libaot-Java.Interop.dll.so
		ptr null; void* handle (0x0)
	}, ; 583
	%struct.DSOCacheEntry {
		i64 18347920244245135731, ; hash 0xfea0e8402d6e0173, from name: aot-System.Runtime.InteropServices.dll.so
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.80_name, ; name: libaot-System.Runtime.InteropServices.dll.so
		ptr null; void* handle (0x0)
	}, ; 584
	%struct.DSOCacheEntry {
		i64 18377348929170574574, ; hash 0xff09757bd49e0cee, from name: aot-System.Private.Xml.Linq
		i8 0, ; bool ignore
		ptr @.DSOCacheEntry.77_name, ; name: libaot-System.Private.Xml.Linq.dll.so
		ptr null; void* handle (0x0)
	} ; 585
], align 16

; Bundled assembly name buffers, all empty (unused when assembly stores are enabled)
@bundled_assemblies = dso_local local_unnamed_addr global [0 x %struct.XamarinAndroidBundledAssembly] zeroinitializer, align 8

@assembly_store_bundled_assemblies = dso_local local_unnamed_addr global [93 x %struct.AssemblyStoreSingleAssemblyRuntimeData] zeroinitializer, align 8

@assembly_stores = dso_local local_unnamed_addr global [2 x %struct.AssemblyStoreRuntimeData] zeroinitializer, align 8

; Strings
@.str.0 = private unnamed_addr constant [7 x i8] c"normal\00", align 1

; Application environment variables name:value pairs
@.env.0 = private unnamed_addr constant [15 x i8] c"MONO_GC_PARAMS\00", align 1
@.env.1 = private unnamed_addr constant [21 x i8] c"major=marksweep-conc\00", align 16
@.env.2 = private unnamed_addr constant [17 x i8] c"XAMARIN_BUILD_ID\00", align 16
@.env.3 = private unnamed_addr constant [37 x i8] c"90eec6bf-40bc-4e99-875c-4bf2833225b4\00", align 16
@.env.4 = private unnamed_addr constant [28 x i8] c"XA_HTTP_CLIENT_HANDLER_TYPE\00", align 16
@.env.5 = private unnamed_addr constant [42 x i8] c"Xamarin.Android.Net.AndroidMessageHandler\00", align 16
@.env.6 = private unnamed_addr constant [29 x i8] c"__XA_PACKAGE_NAMING_POLICY__\00", align 16
@.env.7 = private unnamed_addr constant [15 x i8] c"LowercaseCrc64\00", align 1

;ApplicationConfig
@.ApplicationConfig.0_android_package_name = private unnamed_addr constant [34 x i8] c"com.chunghwaminecraft.penghuspace\00", align 16

;DSOCacheEntry
@.DSOCacheEntry.0_name = private unnamed_addr constant [16 x i8] c"libe_sqlite3.so\00", align 16
@.DSOCacheEntry.1_name = private unnamed_addr constant [35 x i8] c"libSystem.IO.Compression.Native.so\00", align 16
@.DSOCacheEntry.2_name = private unnamed_addr constant [20 x i8] c"libSystem.Native.so\00", align 16
@.DSOCacheEntry.3_name = private unnamed_addr constant [50 x i8] c"libSystem.Security.Cryptography.Native.Android.so\00", align 16
@.DSOCacheEntry.4_name = private unnamed_addr constant [35 x i8] c"libmono-component-marshal-ilgen.so\00", align 16
@.DSOCacheEntry.5_name = private unnamed_addr constant [19 x i8] c"libmonosgen-2.0.so\00", align 16
@.DSOCacheEntry.6_name = private unnamed_addr constant [16 x i8] c"libmonodroid.so\00", align 16
@.DSOCacheEntry.7_name = private unnamed_addr constant [51 x i8] c"libaot-_Microsoft.Android.Resource.Designer.dll.so\00", align 16
@.DSOCacheEntry.8_name = private unnamed_addr constant [35 x i8] c"libaot-UniversityAndroidApp.dll.so\00", align 16
@.DSOCacheEntry.9_name = private unnamed_addr constant [25 x i8] c"libaot-SQLite-net.dll.so\00", align 16
@.DSOCacheEntry.10_name = private unnamed_addr constant [40 x i8] c"libaot-SQLitePCLRaw.batteries_v2.dll.so\00", align 16
@.DSOCacheEntry.11_name = private unnamed_addr constant [32 x i8] c"libaot-SQLitePCLRaw.core.dll.so\00", align 16
@.DSOCacheEntry.12_name = private unnamed_addr constant [49 x i8] c"libaot-SQLitePCLRaw.lib.e_sqlite3.android.dll.so\00", align 16
@.DSOCacheEntry.13_name = private unnamed_addr constant [46 x i8] c"libaot-SQLitePCLRaw.provider.e_sqlite3.dll.so\00", align 16
@.DSOCacheEntry.14_name = private unnamed_addr constant [40 x i8] c"libaot-Xamarin.AndroidX.Activity.dll.so\00", align 16
@.DSOCacheEntry.15_name = private unnamed_addr constant [41 x i8] c"libaot-Xamarin.AndroidX.AppCompat.dll.so\00", align 16
@.DSOCacheEntry.16_name = private unnamed_addr constant [60 x i8] c"libaot-Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so\00", align 16
@.DSOCacheEntry.17_name = private unnamed_addr constant [39 x i8] c"libaot-Xamarin.AndroidX.Browser.dll.so\00", align 16
@.DSOCacheEntry.18_name = private unnamed_addr constant [40 x i8] c"libaot-Xamarin.AndroidX.CardView.dll.so\00", align 16
@.DSOCacheEntry.19_name = private unnamed_addr constant [49 x i8] c"libaot-Xamarin.AndroidX.CoordinatorLayout.dll.so\00", align 16
@.DSOCacheEntry.20_name = private unnamed_addr constant [36 x i8] c"libaot-Xamarin.AndroidX.Core.dll.so\00", align 16
@.DSOCacheEntry.21_name = private unnamed_addr constant [45 x i8] c"libaot-Xamarin.AndroidX.CursorAdapter.dll.so\00", align 16
@.DSOCacheEntry.22_name = private unnamed_addr constant [44 x i8] c"libaot-Xamarin.AndroidX.DrawerLayout.dll.so\00", align 16
@.DSOCacheEntry.23_name = private unnamed_addr constant [40 x i8] c"libaot-Xamarin.AndroidX.Fragment.dll.so\00", align 16
@.DSOCacheEntry.24_name = private unnamed_addr constant [54 x i8] c"libaot-Xamarin.AndroidX.Legacy.Support.Core.UI.dll.so\00", align 16
@.DSOCacheEntry.25_name = private unnamed_addr constant [48 x i8] c"libaot-Xamarin.AndroidX.Lifecycle.Common.dll.so\00", align 16
@.DSOCacheEntry.26_name = private unnamed_addr constant [55 x i8] c"libaot-Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so\00", align 16
@.DSOCacheEntry.27_name = private unnamed_addr constant [51 x i8] c"libaot-Xamarin.AndroidX.Lifecycle.ViewModel.dll.so\00", align 16
@.DSOCacheEntry.28_name = private unnamed_addr constant [38 x i8] c"libaot-Xamarin.AndroidX.Loader.dll.so\00", align 16
@.DSOCacheEntry.29_name = private unnamed_addr constant [44 x i8] c"libaot-Xamarin.AndroidX.RecyclerView.dll.so\00", align 16
@.DSOCacheEntry.30_name = private unnamed_addr constant [42 x i8] c"libaot-Xamarin.AndroidX.SavedState.dll.so\00", align 16
@.DSOCacheEntry.31_name = private unnamed_addr constant [50 x i8] c"libaot-Xamarin.AndroidX.SwipeRefreshLayout.dll.so\00", align 16
@.DSOCacheEntry.32_name = private unnamed_addr constant [41 x i8] c"libaot-Xamarin.AndroidX.ViewPager.dll.so\00", align 16
@.DSOCacheEntry.33_name = private unnamed_addr constant [33 x i8] c"libaot-Xamarin.Essentials.dll.so\00", align 16
@.DSOCacheEntry.34_name = private unnamed_addr constant [29 x i8] c"libaot-FormsViewGroup.dll.so\00", align 16
@.DSOCacheEntry.35_name = private unnamed_addr constant [33 x i8] c"libaot-Xamarin.Forms.Core.dll.so\00", align 16
@.DSOCacheEntry.36_name = private unnamed_addr constant [45 x i8] c"libaot-Xamarin.Forms.Platform.Android.dll.so\00", align 16
@.DSOCacheEntry.37_name = private unnamed_addr constant [37 x i8] c"libaot-Xamarin.Forms.Platform.dll.so\00", align 16
@.DSOCacheEntry.38_name = private unnamed_addr constant [33 x i8] c"libaot-Xamarin.Forms.Xaml.dll.so\00", align 16
@.DSOCacheEntry.39_name = private unnamed_addr constant [46 x i8] c"libaot-Xamarin.Google.Android.Material.dll.so\00", align 16
@.DSOCacheEntry.40_name = private unnamed_addr constant [36 x i8] c"libaot-Xamarin.Kotlin.StdLib.dll.so\00", align 16
@.DSOCacheEntry.41_name = private unnamed_addr constant [50 x i8] c"libaot-Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so\00", align 16
@.DSOCacheEntry.42_name = private unnamed_addr constant [44 x i8] c"libaot-System.Collections.Concurrent.dll.so\00", align 16
@.DSOCacheEntry.43_name = private unnamed_addr constant [44 x i8] c"libaot-System.Collections.NonGeneric.dll.so\00", align 16
@.DSOCacheEntry.44_name = private unnamed_addr constant [45 x i8] c"libaot-System.Collections.Specialized.dll.so\00", align 16
@.DSOCacheEntry.45_name = private unnamed_addr constant [33 x i8] c"libaot-System.Collections.dll.so\00", align 16
@.DSOCacheEntry.46_name = private unnamed_addr constant [47 x i8] c"libaot-System.ComponentModel.Primitives.dll.so\00", align 16
@.DSOCacheEntry.47_name = private unnamed_addr constant [50 x i8] c"libaot-System.ComponentModel.TypeConverter.dll.so\00", align 16
@.DSOCacheEntry.48_name = private unnamed_addr constant [36 x i8] c"libaot-System.ComponentModel.dll.so\00", align 16
@.DSOCacheEntry.49_name = private unnamed_addr constant [29 x i8] c"libaot-System.Console.dll.so\00", align 16
@.DSOCacheEntry.50_name = private unnamed_addr constant [26 x i8] c"libaot-System.Core.dll.so\00", align 16
@.DSOCacheEntry.51_name = private unnamed_addr constant [50 x i8] c"libaot-System.Diagnostics.DiagnosticSource.dll.so\00", align 16
@.DSOCacheEntry.52_name = private unnamed_addr constant [44 x i8] c"libaot-System.Diagnostics.StackTrace.dll.so\00", align 16
@.DSOCacheEntry.53_name = private unnamed_addr constant [45 x i8] c"libaot-System.Diagnostics.TraceSource.dll.so\00", align 16
@.DSOCacheEntry.54_name = private unnamed_addr constant [40 x i8] c"libaot-System.Drawing.Primitives.dll.so\00", align 16
@.DSOCacheEntry.55_name = private unnamed_addr constant [29 x i8] c"libaot-System.Drawing.dll.so\00", align 16
@.DSOCacheEntry.56_name = private unnamed_addr constant [34 x i8] c"libaot-System.Formats.Asn1.dll.so\00", align 16
@.DSOCacheEntry.57_name = private unnamed_addr constant [43 x i8] c"libaot-System.IO.Compression.Brotli.dll.so\00", align 16
@.DSOCacheEntry.58_name = private unnamed_addr constant [36 x i8] c"libaot-System.IO.Compression.dll.so\00", align 16
@.DSOCacheEntry.59_name = private unnamed_addr constant [40 x i8] c"libaot-System.IO.IsolatedStorage.dll.so\00", align 16
@.DSOCacheEntry.60_name = private unnamed_addr constant [38 x i8] c"libaot-System.Linq.Expressions.dll.so\00", align 16
@.DSOCacheEntry.61_name = private unnamed_addr constant [26 x i8] c"libaot-System.Linq.dll.so\00", align 16
@.DSOCacheEntry.62_name = private unnamed_addr constant [28 x i8] c"libaot-System.Memory.dll.so\00", align 16
@.DSOCacheEntry.63_name = private unnamed_addr constant [30 x i8] c"libaot-System.Net.Http.dll.so\00", align 16
@.DSOCacheEntry.64_name = private unnamed_addr constant [40 x i8] c"libaot-System.Net.NameResolution.dll.so\00", align 16
@.DSOCacheEntry.65_name = private unnamed_addr constant [44 x i8] c"libaot-System.Net.NetworkInformation.dll.so\00", align 16
@.DSOCacheEntry.66_name = private unnamed_addr constant [36 x i8] c"libaot-System.Net.Primitives.dll.so\00", align 16
@.DSOCacheEntry.67_name = private unnamed_addr constant [34 x i8] c"libaot-System.Net.Requests.dll.so\00", align 16
@.DSOCacheEntry.68_name = private unnamed_addr constant [34 x i8] c"libaot-System.Net.Security.dll.so\00", align 16
@.DSOCacheEntry.69_name = private unnamed_addr constant [38 x i8] c"libaot-System.Net.ServicePoint.dll.so\00", align 16
@.DSOCacheEntry.70_name = private unnamed_addr constant [33 x i8] c"libaot-System.Net.Sockets.dll.so\00", align 16
@.DSOCacheEntry.71_name = private unnamed_addr constant [35 x i8] c"libaot-System.Net.WebClient.dll.so\00", align 16
@.DSOCacheEntry.72_name = private unnamed_addr constant [45 x i8] c"libaot-System.Net.WebHeaderCollection.dll.so\00", align 16
@.DSOCacheEntry.73_name = private unnamed_addr constant [30 x i8] c"libaot-System.Numerics.dll.so\00", align 16
@.DSOCacheEntry.74_name = private unnamed_addr constant [33 x i8] c"libaot-System.ObjectModel.dll.so\00", align 16
@.DSOCacheEntry.75_name = private unnamed_addr constant [55 x i8] c"libaot-System.Private.DataContractSerialization.dll.so\00", align 16
@.DSOCacheEntry.76_name = private unnamed_addr constant [33 x i8] c"libaot-System.Private.Uri.dll.so\00", align 16
@.DSOCacheEntry.77_name = private unnamed_addr constant [38 x i8] c"libaot-System.Private.Xml.Linq.dll.so\00", align 16
@.DSOCacheEntry.78_name = private unnamed_addr constant [33 x i8] c"libaot-System.Private.Xml.dll.so\00", align 16
@.DSOCacheEntry.79_name = private unnamed_addr constant [64 x i8] c"libaot-System.Runtime.InteropServices.RuntimeInformation.dll.so\00", align 16
@.DSOCacheEntry.80_name = private unnamed_addr constant [45 x i8] c"libaot-System.Runtime.InteropServices.dll.so\00", align 16
@.DSOCacheEntry.81_name = private unnamed_addr constant [38 x i8] c"libaot-System.Runtime.Numerics.dll.so\00", align 16
@.DSOCacheEntry.82_name = private unnamed_addr constant [54 x i8] c"libaot-System.Runtime.Serialization.Formatters.dll.so\00", align 16
@.DSOCacheEntry.83_name = private unnamed_addr constant [54 x i8] c"libaot-System.Runtime.Serialization.Primitives.dll.so\00", align 16
@.DSOCacheEntry.84_name = private unnamed_addr constant [43 x i8] c"libaot-System.Runtime.Serialization.dll.so\00", align 16
@.DSOCacheEntry.85_name = private unnamed_addr constant [29 x i8] c"libaot-System.Runtime.dll.so\00", align 16
@.DSOCacheEntry.86_name = private unnamed_addr constant [43 x i8] c"libaot-System.Security.Cryptography.dll.so\00", align 16
@.DSOCacheEntry.87_name = private unnamed_addr constant [45 x i8] c"libaot-System.Text.RegularExpressions.dll.so\00", align 16
@.DSOCacheEntry.88_name = private unnamed_addr constant [40 x i8] c"libaot-System.Threading.Channels.dll.so\00", align 16
@.DSOCacheEntry.89_name = private unnamed_addr constant [38 x i8] c"libaot-System.Threading.Thread.dll.so\00", align 16
@.DSOCacheEntry.90_name = private unnamed_addr constant [31 x i8] c"libaot-System.Threading.dll.so\00", align 16
@.DSOCacheEntry.91_name = private unnamed_addr constant [30 x i8] c"libaot-System.Xml.Linq.dll.so\00", align 16
@.DSOCacheEntry.92_name = private unnamed_addr constant [25 x i8] c"libaot-System.Xml.dll.so\00", align 16
@.DSOCacheEntry.93_name = private unnamed_addr constant [21 x i8] c"libaot-System.dll.so\00", align 16
@.DSOCacheEntry.94_name = private unnamed_addr constant [23 x i8] c"libaot-mscorlib.dll.so\00", align 16
@.DSOCacheEntry.95_name = private unnamed_addr constant [26 x i8] c"libaot-netstandard.dll.so\00", align 16
@.DSOCacheEntry.96_name = private unnamed_addr constant [27 x i8] c"libaot-Java.Interop.dll.so\00", align 16
@.DSOCacheEntry.97_name = private unnamed_addr constant [35 x i8] c"libaot-Mono.Android.Runtime.dll.so\00", align 16
@.DSOCacheEntry.98_name = private unnamed_addr constant [27 x i8] c"libaot-Mono.Android.dll.so\00", align 16
@.DSOCacheEntry.99_name = private unnamed_addr constant [37 x i8] c"libaot-System.Private.CoreLib.dll.so\00", align 16

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}

; ModuleID = 'compressed_assemblies.x86.ll'
source_filename = "compressed_assemblies.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.CompressedAssemblies = type {
	i32, ; uint32_t count
	ptr ; CompressedAssemblyDescriptor descriptors
}

%struct.CompressedAssemblyDescriptor = type {
	i32, ; uint32_t uncompressed_file_size
	i8, ; bool loaded
	ptr ; uint8_t data
}

@compressed_assemblies = dso_local local_unnamed_addr global %struct.CompressedAssemblies {
	i32 114, ; uint32_t count (0x72)
	ptr @compressed_assembly_descriptors; CompressedAssemblyDescriptor* descriptors
}, align 4

@compressed_assembly_descriptors = internal dso_local global [114 x %struct.CompressedAssemblyDescriptor] [
	%struct.CompressedAssemblyDescriptor {
		i32 15872, ; uint32_t uncompressed_file_size (0x3e00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_0; uint8_t* data (0x0)
	}, ; 0
	%struct.CompressedAssemblyDescriptor {
		i32 151552, ; uint32_t uncompressed_file_size (0x25000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_1; uint8_t* data (0x0)
	}, ; 1
	%struct.CompressedAssemblyDescriptor {
		i32 18976, ; uint32_t uncompressed_file_size (0x4a20)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_2; uint8_t* data (0x0)
	}, ; 2
	%struct.CompressedAssemblyDescriptor {
		i32 1899520, ; uint32_t uncompressed_file_size (0x1cfc00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_3; uint8_t* data (0x0)
	}, ; 3
	%struct.CompressedAssemblyDescriptor {
		i32 101376, ; uint32_t uncompressed_file_size (0x18c00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_4; uint8_t* data (0x0)
	}, ; 4
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uint32_t uncompressed_file_size (0x1800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_5; uint8_t* data (0x0)
	}, ; 5
	%struct.CompressedAssemblyDescriptor {
		i32 46592, ; uint32_t uncompressed_file_size (0xb600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_6; uint8_t* data (0x0)
	}, ; 6
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size (0x1400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_7; uint8_t* data (0x0)
	}, ; 7
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size (0x1600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_8; uint8_t* data (0x0)
	}, ; 8
	%struct.CompressedAssemblyDescriptor {
		i32 35840, ; uint32_t uncompressed_file_size (0x8c00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_9; uint8_t* data (0x0)
	}, ; 9
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uint32_t uncompressed_file_size (0x3800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_10; uint8_t* data (0x0)
	}, ; 10
	%struct.CompressedAssemblyDescriptor {
		i32 9216, ; uint32_t uncompressed_file_size (0x2400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_11; uint8_t* data (0x0)
	}, ; 11
	%struct.CompressedAssemblyDescriptor {
		i32 8704, ; uint32_t uncompressed_file_size (0x2200)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_12; uint8_t* data (0x0)
	}, ; 12
	%struct.CompressedAssemblyDescriptor {
		i32 10752, ; uint32_t uncompressed_file_size (0x2a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_13; uint8_t* data (0x0)
	}, ; 13
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_14; uint8_t* data (0x0)
	}, ; 14
	%struct.CompressedAssemblyDescriptor {
		i32 10752, ; uint32_t uncompressed_file_size (0x2a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_15; uint8_t* data (0x0)
	}, ; 15
	%struct.CompressedAssemblyDescriptor {
		i32 4608, ; uint32_t uncompressed_file_size (0x1200)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_16; uint8_t* data (0x0)
	}, ; 16
	%struct.CompressedAssemblyDescriptor {
		i32 15360, ; uint32_t uncompressed_file_size (0x3c00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_17; uint8_t* data (0x0)
	}, ; 17
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_18; uint8_t* data (0x0)
	}, ; 18
	%struct.CompressedAssemblyDescriptor {
		i32 10752, ; uint32_t uncompressed_file_size (0x2a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_19; uint8_t* data (0x0)
	}, ; 19
	%struct.CompressedAssemblyDescriptor {
		i32 25600, ; uint32_t uncompressed_file_size (0x6400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_20; uint8_t* data (0x0)
	}, ; 20
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_21; uint8_t* data (0x0)
	}, ; 21
	%struct.CompressedAssemblyDescriptor {
		i32 59392, ; uint32_t uncompressed_file_size (0xe800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_22; uint8_t* data (0x0)
	}, ; 22
	%struct.CompressedAssemblyDescriptor {
		i32 19968, ; uint32_t uncompressed_file_size (0x4e00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_23; uint8_t* data (0x0)
	}, ; 23
	%struct.CompressedAssemblyDescriptor {
		i32 31232, ; uint32_t uncompressed_file_size (0x7a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_24; uint8_t* data (0x0)
	}, ; 24
	%struct.CompressedAssemblyDescriptor {
		i32 15872, ; uint32_t uncompressed_file_size (0x3e00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_25; uint8_t* data (0x0)
	}, ; 25
	%struct.CompressedAssemblyDescriptor {
		i32 346112, ; uint32_t uncompressed_file_size (0x54800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_26; uint8_t* data (0x0)
	}, ; 26
	%struct.CompressedAssemblyDescriptor {
		i32 39424, ; uint32_t uncompressed_file_size (0x9a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_27; uint8_t* data (0x0)
	}, ; 27
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uint32_t uncompressed_file_size (0x1800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_28; uint8_t* data (0x0)
	}, ; 28
	%struct.CompressedAssemblyDescriptor {
		i32 357376, ; uint32_t uncompressed_file_size (0x57400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_29; uint8_t* data (0x0)
	}, ; 29
	%struct.CompressedAssemblyDescriptor {
		i32 19456, ; uint32_t uncompressed_file_size (0x4c00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_30; uint8_t* data (0x0)
	}, ; 30
	%struct.CompressedAssemblyDescriptor {
		i32 23552, ; uint32_t uncompressed_file_size (0x5c00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_31; uint8_t* data (0x0)
	}, ; 31
	%struct.CompressedAssemblyDescriptor {
		i32 67072, ; uint32_t uncompressed_file_size (0x10600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_32; uint8_t* data (0x0)
	}, ; 32
	%struct.CompressedAssemblyDescriptor {
		i32 81408, ; uint32_t uncompressed_file_size (0x13e00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_33; uint8_t* data (0x0)
	}, ; 33
	%struct.CompressedAssemblyDescriptor {
		i32 136192, ; uint32_t uncompressed_file_size (0x21400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_34; uint8_t* data (0x0)
	}, ; 34
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size (0x1600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_35; uint8_t* data (0x0)
	}, ; 35
	%struct.CompressedAssemblyDescriptor {
		i32 10240, ; uint32_t uncompressed_file_size (0x2800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_36; uint8_t* data (0x0)
	}, ; 36
	%struct.CompressedAssemblyDescriptor {
		i32 9216, ; uint32_t uncompressed_file_size (0x2400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_37; uint8_t* data (0x0)
	}, ; 37
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_38; uint8_t* data (0x0)
	}, ; 38
	%struct.CompressedAssemblyDescriptor {
		i32 15872, ; uint32_t uncompressed_file_size (0x3e00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_39; uint8_t* data (0x0)
	}, ; 39
	%struct.CompressedAssemblyDescriptor {
		i32 390144, ; uint32_t uncompressed_file_size (0x5f400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_40; uint8_t* data (0x0)
	}, ; 40
	%struct.CompressedAssemblyDescriptor {
		i32 75776, ; uint32_t uncompressed_file_size (0x12800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_41; uint8_t* data (0x0)
	}, ; 41
	%struct.CompressedAssemblyDescriptor {
		i32 28672, ; uint32_t uncompressed_file_size (0x7000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_42; uint8_t* data (0x0)
	}, ; 42
	%struct.CompressedAssemblyDescriptor {
		i32 627200, ; uint32_t uncompressed_file_size (0x99200)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_43; uint8_t* data (0x0)
	}, ; 43
	%struct.CompressedAssemblyDescriptor {
		i32 8192, ; uint32_t uncompressed_file_size (0x2000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_44; uint8_t* data (0x0)
	}, ; 44
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size (0x1400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_45; uint8_t* data (0x0)
	}, ; 45
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uint32_t uncompressed_file_size (0x1c00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_46; uint8_t* data (0x0)
	}, ; 46
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_47; uint8_t* data (0x0)
	}, ; 47
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uint32_t uncompressed_file_size (0x1c00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_48; uint8_t* data (0x0)
	}, ; 48
	%struct.CompressedAssemblyDescriptor {
		i32 162304, ; uint32_t uncompressed_file_size (0x27a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_49; uint8_t* data (0x0)
	}, ; 49
	%struct.CompressedAssemblyDescriptor {
		i32 19968, ; uint32_t uncompressed_file_size (0x4e00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_50; uint8_t* data (0x0)
	}, ; 50
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_51; uint8_t* data (0x0)
	}, ; 51
	%struct.CompressedAssemblyDescriptor {
		i32 10752, ; uint32_t uncompressed_file_size (0x2a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_52; uint8_t* data (0x0)
	}, ; 52
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_53; uint8_t* data (0x0)
	}, ; 53
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_54; uint8_t* data (0x0)
	}, ; 54
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size (0x1600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_55; uint8_t* data (0x0)
	}, ; 55
	%struct.CompressedAssemblyDescriptor {
		i32 102912, ; uint32_t uncompressed_file_size (0x19200)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_56; uint8_t* data (0x0)
	}, ; 56
	%struct.CompressedAssemblyDescriptor {
		i32 46592, ; uint32_t uncompressed_file_size (0xb600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_57; uint8_t* data (0x0)
	}, ; 57
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uint32_t uncompressed_file_size (0x3800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_58; uint8_t* data (0x0)
	}, ; 58
	%struct.CompressedAssemblyDescriptor {
		i32 491008, ; uint32_t uncompressed_file_size (0x77e00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_59; uint8_t* data (0x0)
	}, ; 59
	%struct.CompressedAssemblyDescriptor {
		i32 73216, ; uint32_t uncompressed_file_size (0x11e00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_60; uint8_t* data (0x0)
	}, ; 60
	%struct.CompressedAssemblyDescriptor {
		i32 15360, ; uint32_t uncompressed_file_size (0x3c00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_61; uint8_t* data (0x0)
	}, ; 61
	%struct.CompressedAssemblyDescriptor {
		i32 69120, ; uint32_t uncompressed_file_size (0x10e00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_62; uint8_t* data (0x0)
	}, ; 62
	%struct.CompressedAssemblyDescriptor {
		i32 522752, ; uint32_t uncompressed_file_size (0x7fa00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_63; uint8_t* data (0x0)
	}, ; 63
	%struct.CompressedAssemblyDescriptor {
		i32 22016, ; uint32_t uncompressed_file_size (0x5600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_64; uint8_t* data (0x0)
	}, ; 64
	%struct.CompressedAssemblyDescriptor {
		i32 39424, ; uint32_t uncompressed_file_size (0x9a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_65; uint8_t* data (0x0)
	}, ; 65
	%struct.CompressedAssemblyDescriptor {
		i32 186368, ; uint32_t uncompressed_file_size (0x2d800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_66; uint8_t* data (0x0)
	}, ; 66
	%struct.CompressedAssemblyDescriptor {
		i32 13824, ; uint32_t uncompressed_file_size (0x3600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_67; uint8_t* data (0x0)
	}, ; 67
	%struct.CompressedAssemblyDescriptor {
		i32 14848, ; uint32_t uncompressed_file_size (0x3a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_68; uint8_t* data (0x0)
	}, ; 68
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uint32_t uncompressed_file_size (0x3800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_69; uint8_t* data (0x0)
	}, ; 69
	%struct.CompressedAssemblyDescriptor {
		i32 15872, ; uint32_t uncompressed_file_size (0x3e00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_70; uint8_t* data (0x0)
	}, ; 70
	%struct.CompressedAssemblyDescriptor {
		i32 33792, ; uint32_t uncompressed_file_size (0x8400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_71; uint8_t* data (0x0)
	}, ; 71
	%struct.CompressedAssemblyDescriptor {
		i32 355328, ; uint32_t uncompressed_file_size (0x56c00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_72; uint8_t* data (0x0)
	}, ; 72
	%struct.CompressedAssemblyDescriptor {
		i32 10240, ; uint32_t uncompressed_file_size (0x2800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_73; uint8_t* data (0x0)
	}, ; 73
	%struct.CompressedAssemblyDescriptor {
		i32 35328, ; uint32_t uncompressed_file_size (0x8a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_74; uint8_t* data (0x0)
	}, ; 74
	%struct.CompressedAssemblyDescriptor {
		i32 52736, ; uint32_t uncompressed_file_size (0xce00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_75; uint8_t* data (0x0)
	}, ; 75
	%struct.CompressedAssemblyDescriptor {
		i32 199168, ; uint32_t uncompressed_file_size (0x30a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_76; uint8_t* data (0x0)
	}, ; 76
	%struct.CompressedAssemblyDescriptor {
		i32 1237440, ; uint32_t uncompressed_file_size (0x12e1c0)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_77; uint8_t* data (0x0)
	}, ; 77
	%struct.CompressedAssemblyDescriptor {
		i32 745472, ; uint32_t uncompressed_file_size (0xb6000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_78; uint8_t* data (0x0)
	}, ; 78
	%struct.CompressedAssemblyDescriptor {
		i32 32256, ; uint32_t uncompressed_file_size (0x7e00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_79; uint8_t* data (0x0)
	}, ; 79
	%struct.CompressedAssemblyDescriptor {
		i32 114720, ; uint32_t uncompressed_file_size (0x1c020)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_80; uint8_t* data (0x0)
	}, ; 80
	%struct.CompressedAssemblyDescriptor {
		i32 223232, ; uint32_t uncompressed_file_size (0x36800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_81; uint8_t* data (0x0)
	}, ; 81
	%struct.CompressedAssemblyDescriptor {
		i32 18432, ; uint32_t uncompressed_file_size (0x4800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_82; uint8_t* data (0x0)
	}, ; 82
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uint32_t uncompressed_file_size (0x3800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_83; uint8_t* data (0x0)
	}, ; 83
	%struct.CompressedAssemblyDescriptor {
		i32 20480, ; uint32_t uncompressed_file_size (0x5000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_84; uint8_t* data (0x0)
	}, ; 84
	%struct.CompressedAssemblyDescriptor {
		i32 34816, ; uint32_t uncompressed_file_size (0x8800)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_85; uint8_t* data (0x0)
	}, ; 85
	%struct.CompressedAssemblyDescriptor {
		i32 102400, ; uint32_t uncompressed_file_size (0x19000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_86; uint8_t* data (0x0)
	}, ; 86
	%struct.CompressedAssemblyDescriptor {
		i32 1870336, ; uint32_t uncompressed_file_size (0x1c8a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_87; uint8_t* data (0x0)
	}, ; 87
	%struct.CompressedAssemblyDescriptor {
		i32 62464, ; uint32_t uncompressed_file_size (0xf400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_88; uint8_t* data (0x0)
	}, ; 88
	%struct.CompressedAssemblyDescriptor {
		i32 300032, ; uint32_t uncompressed_file_size (0x49400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_89; uint8_t* data (0x0)
	}, ; 89
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_90; uint8_t* data (0x0)
	}, ; 90
	%struct.CompressedAssemblyDescriptor {
		i32 20480, ; uint32_t uncompressed_file_size (0x5000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_91; uint8_t* data (0x0)
	}, ; 91
	%struct.CompressedAssemblyDescriptor {
		i32 34304, ; uint32_t uncompressed_file_size (0x8600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_92; uint8_t* data (0x0)
	}, ; 92
	%struct.CompressedAssemblyDescriptor {
		i32 102400, ; uint32_t uncompressed_file_size (0x19000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_93; uint8_t* data (0x0)
	}, ; 93
	%struct.CompressedAssemblyDescriptor {
		i32 1856512, ; uint32_t uncompressed_file_size (0x1c5400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_94; uint8_t* data (0x0)
	}, ; 94
	%struct.CompressedAssemblyDescriptor {
		i32 62464, ; uint32_t uncompressed_file_size (0xf400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_95; uint8_t* data (0x0)
	}, ; 95
	%struct.CompressedAssemblyDescriptor {
		i32 300032, ; uint32_t uncompressed_file_size (0x49400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_96; uint8_t* data (0x0)
	}, ; 96
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_97; uint8_t* data (0x0)
	}, ; 97
	%struct.CompressedAssemblyDescriptor {
		i32 9728, ; uint32_t uncompressed_file_size (0x2600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_98; uint8_t* data (0x0)
	}, ; 98
	%struct.CompressedAssemblyDescriptor {
		i32 13312, ; uint32_t uncompressed_file_size (0x3400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_99; uint8_t* data (0x0)
	}, ; 99
	%struct.CompressedAssemblyDescriptor {
		i32 20480, ; uint32_t uncompressed_file_size (0x5000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_100; uint8_t* data (0x0)
	}, ; 100
	%struct.CompressedAssemblyDescriptor {
		i32 34304, ; uint32_t uncompressed_file_size (0x8600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_101; uint8_t* data (0x0)
	}, ; 101
	%struct.CompressedAssemblyDescriptor {
		i32 102400, ; uint32_t uncompressed_file_size (0x19000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_102; uint8_t* data (0x0)
	}, ; 102
	%struct.CompressedAssemblyDescriptor {
		i32 1856512, ; uint32_t uncompressed_file_size (0x1c5400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_103; uint8_t* data (0x0)
	}, ; 103
	%struct.CompressedAssemblyDescriptor {
		i32 62464, ; uint32_t uncompressed_file_size (0xf400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_104; uint8_t* data (0x0)
	}, ; 104
	%struct.CompressedAssemblyDescriptor {
		i32 300032, ; uint32_t uncompressed_file_size (0x49400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_105; uint8_t* data (0x0)
	}, ; 105
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_106; uint8_t* data (0x0)
	}, ; 106
	%struct.CompressedAssemblyDescriptor {
		i32 20480, ; uint32_t uncompressed_file_size (0x5000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_107; uint8_t* data (0x0)
	}, ; 107
	%struct.CompressedAssemblyDescriptor {
		i32 35328, ; uint32_t uncompressed_file_size (0x8a00)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_108; uint8_t* data (0x0)
	}, ; 108
	%struct.CompressedAssemblyDescriptor {
		i32 102400, ; uint32_t uncompressed_file_size (0x19000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_109; uint8_t* data (0x0)
	}, ; 109
	%struct.CompressedAssemblyDescriptor {
		i32 1918464, ; uint32_t uncompressed_file_size (0x1d4600)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_110; uint8_t* data (0x0)
	}, ; 110
	%struct.CompressedAssemblyDescriptor {
		i32 62464, ; uint32_t uncompressed_file_size (0xf400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_111; uint8_t* data (0x0)
	}, ; 111
	%struct.CompressedAssemblyDescriptor {
		i32 300032, ; uint32_t uncompressed_file_size (0x49400)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_112; uint8_t* data (0x0)
	}, ; 112
	%struct.CompressedAssemblyDescriptor {
		i32 4096, ; uint32_t uncompressed_file_size (0x1000)
		i8 0, ; bool loaded
		ptr @__compressedAssemblyData_113; uint8_t* data (0x0)
	} ; 113
], align 4

@__compressedAssemblyData_0 = internal dso_local global [15872 x i8] zeroinitializer, align 1
@__compressedAssemblyData_1 = internal dso_local global [151552 x i8] zeroinitializer, align 1
@__compressedAssemblyData_2 = internal dso_local global [18976 x i8] zeroinitializer, align 1
@__compressedAssemblyData_3 = internal dso_local global [1899520 x i8] zeroinitializer, align 1
@__compressedAssemblyData_4 = internal dso_local global [101376 x i8] zeroinitializer, align 1
@__compressedAssemblyData_5 = internal dso_local global [6144 x i8] zeroinitializer, align 1
@__compressedAssemblyData_6 = internal dso_local global [46592 x i8] zeroinitializer, align 1
@__compressedAssemblyData_7 = internal dso_local global [5120 x i8] zeroinitializer, align 1
@__compressedAssemblyData_8 = internal dso_local global [5632 x i8] zeroinitializer, align 1
@__compressedAssemblyData_9 = internal dso_local global [35840 x i8] zeroinitializer, align 1
@__compressedAssemblyData_10 = internal dso_local global [14336 x i8] zeroinitializer, align 1
@__compressedAssemblyData_11 = internal dso_local global [9216 x i8] zeroinitializer, align 1
@__compressedAssemblyData_12 = internal dso_local global [8704 x i8] zeroinitializer, align 1
@__compressedAssemblyData_13 = internal dso_local global [10752 x i8] zeroinitializer, align 1
@__compressedAssemblyData_14 = internal dso_local global [4096 x i8] zeroinitializer, align 1
@__compressedAssemblyData_15 = internal dso_local global [10752 x i8] zeroinitializer, align 1
@__compressedAssemblyData_16 = internal dso_local global [4608 x i8] zeroinitializer, align 1
@__compressedAssemblyData_17 = internal dso_local global [15360 x i8] zeroinitializer, align 1
@__compressedAssemblyData_18 = internal dso_local global [4096 x i8] zeroinitializer, align 1
@__compressedAssemblyData_19 = internal dso_local global [10752 x i8] zeroinitializer, align 1
@__compressedAssemblyData_20 = internal dso_local global [25600 x i8] zeroinitializer, align 1
@__compressedAssemblyData_21 = internal dso_local global [4096 x i8] zeroinitializer, align 1
@__compressedAssemblyData_22 = internal dso_local global [59392 x i8] zeroinitializer, align 1
@__compressedAssemblyData_23 = internal dso_local global [19968 x i8] zeroinitializer, align 1
@__compressedAssemblyData_24 = internal dso_local global [31232 x i8] zeroinitializer, align 1
@__compressedAssemblyData_25 = internal dso_local global [15872 x i8] zeroinitializer, align 1
@__compressedAssemblyData_26 = internal dso_local global [346112 x i8] zeroinitializer, align 1
@__compressedAssemblyData_27 = internal dso_local global [39424 x i8] zeroinitializer, align 1
@__compressedAssemblyData_28 = internal dso_local global [6144 x i8] zeroinitializer, align 1
@__compressedAssemblyData_29 = internal dso_local global [357376 x i8] zeroinitializer, align 1
@__compressedAssemblyData_30 = internal dso_local global [19456 x i8] zeroinitializer, align 1
@__compressedAssemblyData_31 = internal dso_local global [23552 x i8] zeroinitializer, align 1
@__compressedAssemblyData_32 = internal dso_local global [67072 x i8] zeroinitializer, align 1
@__compressedAssemblyData_33 = internal dso_local global [81408 x i8] zeroinitializer, align 1
@__compressedAssemblyData_34 = internal dso_local global [136192 x i8] zeroinitializer, align 1
@__compressedAssemblyData_35 = internal dso_local global [5632 x i8] zeroinitializer, align 1
@__compressedAssemblyData_36 = internal dso_local global [10240 x i8] zeroinitializer, align 1
@__compressedAssemblyData_37 = internal dso_local global [9216 x i8] zeroinitializer, align 1
@__compressedAssemblyData_38 = internal dso_local global [4096 x i8] zeroinitializer, align 1
@__compressedAssemblyData_39 = internal dso_local global [15872 x i8] zeroinitializer, align 1
@__compressedAssemblyData_40 = internal dso_local global [390144 x i8] zeroinitializer, align 1
@__compressedAssemblyData_41 = internal dso_local global [75776 x i8] zeroinitializer, align 1
@__compressedAssemblyData_42 = internal dso_local global [28672 x i8] zeroinitializer, align 1
@__compressedAssemblyData_43 = internal dso_local global [627200 x i8] zeroinitializer, align 1
@__compressedAssemblyData_44 = internal dso_local global [8192 x i8] zeroinitializer, align 1
@__compressedAssemblyData_45 = internal dso_local global [5120 x i8] zeroinitializer, align 1
@__compressedAssemblyData_46 = internal dso_local global [7168 x i8] zeroinitializer, align 1
@__compressedAssemblyData_47 = internal dso_local global [4096 x i8] zeroinitializer, align 1
@__compressedAssemblyData_48 = internal dso_local global [7168 x i8] zeroinitializer, align 1
@__compressedAssemblyData_49 = internal dso_local global [162304 x i8] zeroinitializer, align 1
@__compressedAssemblyData_50 = internal dso_local global [19968 x i8] zeroinitializer, align 1
@__compressedAssemblyData_51 = internal dso_local global [4096 x i8] zeroinitializer, align 1
@__compressedAssemblyData_52 = internal dso_local global [10752 x i8] zeroinitializer, align 1
@__compressedAssemblyData_53 = internal dso_local global [4096 x i8] zeroinitializer, align 1
@__compressedAssemblyData_54 = internal dso_local global [4096 x i8] zeroinitializer, align 1
@__compressedAssemblyData_55 = internal dso_local global [5632 x i8] zeroinitializer, align 1
@__compressedAssemblyData_56 = internal dso_local global [102912 x i8] zeroinitializer, align 1
@__compressedAssemblyData_57 = internal dso_local global [46592 x i8] zeroinitializer, align 1
@__compressedAssemblyData_58 = internal dso_local global [14336 x i8] zeroinitializer, align 1
@__compressedAssemblyData_59 = internal dso_local global [491008 x i8] zeroinitializer, align 1
@__compressedAssemblyData_60 = internal dso_local global [73216 x i8] zeroinitializer, align 1
@__compressedAssemblyData_61 = internal dso_local global [15360 x i8] zeroinitializer, align 1
@__compressedAssemblyData_62 = internal dso_local global [69120 x i8] zeroinitializer, align 1
@__compressedAssemblyData_63 = internal dso_local global [522752 x i8] zeroinitializer, align 1
@__compressedAssemblyData_64 = internal dso_local global [22016 x i8] zeroinitializer, align 1
@__compressedAssemblyData_65 = internal dso_local global [39424 x i8] zeroinitializer, align 1
@__compressedAssemblyData_66 = internal dso_local global [186368 x i8] zeroinitializer, align 1
@__compressedAssemblyData_67 = internal dso_local global [13824 x i8] zeroinitializer, align 1
@__compressedAssemblyData_68 = internal dso_local global [14848 x i8] zeroinitializer, align 1
@__compressedAssemblyData_69 = internal dso_local global [14336 x i8] zeroinitializer, align 1
@__compressedAssemblyData_70 = internal dso_local global [15872 x i8] zeroinitializer, align 1
@__compressedAssemblyData_71 = internal dso_local global [33792 x i8] zeroinitializer, align 1
@__compressedAssemblyData_72 = internal dso_local global [355328 x i8] zeroinitializer, align 1
@__compressedAssemblyData_73 = internal dso_local global [10240 x i8] zeroinitializer, align 1
@__compressedAssemblyData_74 = internal dso_local global [35328 x i8] zeroinitializer, align 1
@__compressedAssemblyData_75 = internal dso_local global [52736 x i8] zeroinitializer, align 1
@__compressedAssemblyData_76 = internal dso_local global [199168 x i8] zeroinitializer, align 1
@__compressedAssemblyData_77 = internal dso_local global [1237440 x i8] zeroinitializer, align 1
@__compressedAssemblyData_78 = internal dso_local global [745472 x i8] zeroinitializer, align 1
@__compressedAssemblyData_79 = internal dso_local global [32256 x i8] zeroinitializer, align 1
@__compressedAssemblyData_80 = internal dso_local global [114720 x i8] zeroinitializer, align 1
@__compressedAssemblyData_81 = internal dso_local global [223232 x i8] zeroinitializer, align 1
@__compressedAssemblyData_82 = internal dso_local global [18432 x i8] zeroinitializer, align 1
@__compressedAssemblyData_83 = internal dso_local global [14336 x i8] zeroinitializer, align 1
@__compressedAssemblyData_84 = internal dso_local global [20480 x i8] zeroinitializer, align 1
@__compressedAssemblyData_85 = internal dso_local global [34816 x i8] zeroinitializer, align 1
@__compressedAssemblyData_86 = internal dso_local global [102400 x i8] zeroinitializer, align 1
@__compressedAssemblyData_87 = internal dso_local global [1870336 x i8] zeroinitializer, align 1
@__compressedAssemblyData_88 = internal dso_local global [62464 x i8] zeroinitializer, align 1
@__compressedAssemblyData_89 = internal dso_local global [300032 x i8] zeroinitializer, align 1
@__compressedAssemblyData_90 = internal dso_local global [4096 x i8] zeroinitializer, align 1
@__compressedAssemblyData_91 = internal dso_local global [20480 x i8] zeroinitializer, align 1
@__compressedAssemblyData_92 = internal dso_local global [34304 x i8] zeroinitializer, align 1
@__compressedAssemblyData_93 = internal dso_local global [102400 x i8] zeroinitializer, align 1
@__compressedAssemblyData_94 = internal dso_local global [1856512 x i8] zeroinitializer, align 1
@__compressedAssemblyData_95 = internal dso_local global [62464 x i8] zeroinitializer, align 1
@__compressedAssemblyData_96 = internal dso_local global [300032 x i8] zeroinitializer, align 1
@__compressedAssemblyData_97 = internal dso_local global [4096 x i8] zeroinitializer, align 1
@__compressedAssemblyData_98 = internal dso_local global [9728 x i8] zeroinitializer, align 1
@__compressedAssemblyData_99 = internal dso_local global [13312 x i8] zeroinitializer, align 1
@__compressedAssemblyData_100 = internal dso_local global [20480 x i8] zeroinitializer, align 1
@__compressedAssemblyData_101 = internal dso_local global [34304 x i8] zeroinitializer, align 1
@__compressedAssemblyData_102 = internal dso_local global [102400 x i8] zeroinitializer, align 1
@__compressedAssemblyData_103 = internal dso_local global [1856512 x i8] zeroinitializer, align 1
@__compressedAssemblyData_104 = internal dso_local global [62464 x i8] zeroinitializer, align 1
@__compressedAssemblyData_105 = internal dso_local global [300032 x i8] zeroinitializer, align 1
@__compressedAssemblyData_106 = internal dso_local global [4096 x i8] zeroinitializer, align 1
@__compressedAssemblyData_107 = internal dso_local global [20480 x i8] zeroinitializer, align 1
@__compressedAssemblyData_108 = internal dso_local global [35328 x i8] zeroinitializer, align 1
@__compressedAssemblyData_109 = internal dso_local global [102400 x i8] zeroinitializer, align 1
@__compressedAssemblyData_110 = internal dso_local global [1918464 x i8] zeroinitializer, align 1
@__compressedAssemblyData_111 = internal dso_local global [62464 x i8] zeroinitializer, align 1
@__compressedAssemblyData_112 = internal dso_local global [300032 x i8] zeroinitializer, align 1
@__compressedAssemblyData_113 = internal dso_local global [4096 x i8] zeroinitializer, align 1

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

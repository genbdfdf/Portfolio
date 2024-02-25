using System.Runtime.CompilerServices;
namespace 函式庫.資料表
{
    class Grid
    {
        public ushort col { get; set; }
        public ushort row { get; set; }
        public ushort background { get; set; }
        public bool walk { get; set; }
        public ushort mId { get; set; }
        public ushort pId { get; set; }
        public byte[] binData { get; set; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort Getcol()
        {
            return col;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort Getrow()
        {
            return row;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort Getbackground()
        {
            return background;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Getwalk()
        {
            return walk;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort GetmId()
        {
            return mId;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort GetpId()
        {
            return pId;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] GetbinData()
        {
            return binData;
        }
    }
}

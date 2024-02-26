using System.Runtime.CompilerServices;
namespace 函式庫.資料表
{
    class MapToGrid
    {
        public ushort mId { get; set; }
        public ushort gId { get; set; }
        public ushort maxgId { get; set; }
        public uint sum { get; set; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort GetmId()
        {
            return mId;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort GetgId()
        {
            return gId;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort GetmaxgId()
        {
            return maxgId;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint Getsum()
        {
            return sum;
        }
    }
}

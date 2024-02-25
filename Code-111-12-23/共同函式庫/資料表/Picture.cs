using System.Runtime.CompilerServices;
namespace 函式庫.資料表
{
    class Picture
    {
        public ushort pId { get; set; }
        public string name { get; set; }
        public byte[] binData { get; set; }

        public ushort count { get; set; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort GetpId()
        {
            return pId;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Getname()
        {
            return name;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] GetbinData()
        {
            return binData;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort Getcount()
        {
            return count;
        }
    }
}

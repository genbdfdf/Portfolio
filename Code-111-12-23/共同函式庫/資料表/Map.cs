using System;
using System.Runtime.CompilerServices;
namespace 函式庫.資料表
{
    class Map : IComparable<Map>
    {
        public ushort mId { get; set; }

        public float Latitude1 { get; set; }

        public float Latitude2 { get; set; }

        public float Longitude1 { get; set; }

        public float Longitude2 { get; set; }

        public float Elevation { get; set; }

        public string title { get; set; }

        public ushort background { get; set; }

        public byte[] binData { get; set; }

        public int CompareTo(Map compareScore)
        {
            return mId.CompareTo(compareScore.mId);
        }
    }
}

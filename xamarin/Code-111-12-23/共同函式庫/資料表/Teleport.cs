using System;
using System.Runtime.CompilerServices;
namespace 函式庫.資料表
{
    public class Teleport : IComparable<Teleport>
    {
        public ushort col { get; set; }
        public ushort row { get; set; }
        public ushort background { get; set; }
        public ushort mId { get; set; }
        public ushort gId { get; set; }
        public ushort tId { get; set; }
        public ushort teleport { get; set; }

        public Teleport()
        {

        }

        public Teleport(ushort col, ushort row, ushort tId, ushort mId, ushort gId)
        {
            set(col, row, tId, mId, gId);
        }

        public Teleport(ushort col, ushort row, ushort tId, ushort mId, ushort gId, ushort teleport)
        {
            set(col, row, tId, mId, gId);
            this.teleport = teleport;
        }

        private void set(ushort col, ushort row, ushort tId, ushort mId, ushort gId)
        {
            this.col = col;
            this.row = row;
            this.tId = tId;
            this.mId = mId;
            this.gId = gId;
            background = 1;
        }
        public int CompareTo(Teleport compareScore)
        {
            return tId.CompareTo(compareScore.tId);
        }

        public bool Equals(Teleport teleport)
        {
            if (tId == teleport.tId)
                return true;
            return false;
        }
    }
}

using System;

namespace PenghuSpace.lib
{
    public class Node : IComparable<Node>
    {

        #region 屬性

        public ushort x { get; private set; }

        public ushort y { get; private set; }

        private float _gScore; // 從起點走到該點的代價距離

        private float _hScore; // 從該點走到終點的直線距離

        private float _fScore; // f(n) = g(n) + h(n)

        public byte direction { get; private set; } //x+ or x- or y+ or y-

        public Node fromLoc { get; private set; } // 從哪一點過來的

        public Node toLoc { get; private set; } // 從哪一點過來的

        #endregion 屬性

        #region Setter

        private void SetSameProperty(ref ushort x, ref ushort y, ref byte direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
            _fScore = _gScore + _hScore;
        }

        public void SettoLoc(Node node)
        {
            toLoc = node;
        }

        #endregion Setter

        #region 建構式

        public Node()
        {

        }
        public Node(ref ushort startx, ref ushort starty, ref int endx, ref int endy, float gScore, byte direction)
        {
            _gScore = gScore;
            _hScore = (float)Math.Sqrt((endx - startx) * (endx - startx) + (endy - starty) * (endy - starty));
            SetSameProperty(ref startx, ref starty, ref direction);
        }

        public Node(ref ushort startx, ref ushort starty, ref int endx, ref int endy, byte direction, Node fromLoc)
        {
            this.fromLoc = fromLoc;
            _gScore = fromLoc._gScore + (direction % 2 == 0 ? 1.414f : 1);
            _hScore = (float)Math.Sqrt((endx - startx) * (endx - startx) + (endy - starty) * (endy - starty));
            SetSameProperty(ref startx, ref starty, ref direction);
        }

        #endregion 建構式

        //  6  7  8
        //  5  0  1
        //  4  3  2

        public bool Equals(Node inputrecord)
        {
            if(x == inputrecord.x && y == inputrecord.y)
                return true;

            else 
                return false;
        }

        public bool theNodeNotGood()
        {
            if (_fScore > fromLoc._fScore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CompareTo(Node compareScore)
        {
            return _fScore.CompareTo(compareScore._fScore);
        }
    }
}
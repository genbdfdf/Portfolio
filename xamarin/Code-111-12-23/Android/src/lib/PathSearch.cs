using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PenghuSpace.lib
{
    public class PathSearch
    {

        #region 屬性

        private Node[] _resultPath { get; set; }
        private Task _searchSk { get; set; }

        #endregion 屬性

        public PathSearch(ushort startX, ushort startY,int endX, int endY, bool[,] canWalk)
        {
            _searchSk = Task.Run(() => StartSearch(startX, startY, endX, endY, canWalk));
        }

        public Node[] GetResultPath()
        {
            _searchSk.Wait();
            return _resultPath;
        }

        private void StartSearch(ushort startX, ushort startY, int endX, int endY, bool[,] canWalk)
        {
            // 已經尋完路的結點
            var closeNodes = new List<Node>();

            // 要尋路的結點
            var openNodes = new List<Node>();

            var betterNodes = new List<Node>();
            bool isBest = true;
            ushort nowX = startX;
            ushort nowY = startY;

            Node nowNode = new Node(ref nowX, ref nowY, ref endX, ref endY, 0, 0);
            closeNodes.Add(nowNode);

            FindNewNodes();

            while (openNodes.Count != 0)
            {
                //在要尋路的結點中找到f(x)最小的節點
                openNodes.Sort();
                nowNode = openNodes[0];

                // 找到終點的話
                if (nowNode.x == endX && nowNode.y == endY)
                {
                    betterNodes.Add(nowNode);
                    getResultPath(betterNodes, ref endX, ref endY);
                    break;
                }

                nowX = nowNode.x;
                nowY = nowNode.y;

                FindNewNodes();

                foreach (Node item in closeNodes)
                    foreach (Node item2 in new List<Node>(openNodes))
                        if (item.Equals(item2))
                            openNodes.Remove(item2);

                closeNodes.Add(nowNode);

                isBest = true;
                foreach (Node openitem in openNodes)
                {
                    if (nowNode.Equals(openitem))
                    {
                        isBest = false;
                        break;
                    }
                }
                if (nowNode.theNodeNotGood())
                {
                    isBest = false;                              
                }
                if (isBest)
                {
                    betterNodes.Add(nowNode);
                }
            }

            #region 走訪四周並加入到 openNodes


            void FindNewNodes()
            {
                ushort x = 0, y = 0;/*, px = 0, py = 0;
                float avg = 4.5f;
                for (int i = 1; i != 9; i++)
                {
                    x = nowx + px;
                    y = nowy + py;

                }
                
                ++----++
                    x+ y+ x- x- y- y- x+ x+
                    1  2  3  4  5  6  7  8
                    1 3 4 7 8
                    2 5 6
                */
                x = (ushort)(nowX + 1);
                y = nowY;
                try
                {
                    if (canWalk[x, y])
                        openNodes.Add(new Node(ref x, ref y, ref endX, ref endY, 1, nowNode)); //中右
                }
                catch { }



                x = (ushort)(nowX + 1);
                y = (ushort)(nowY + 1);
                try
                {
                    if (canWalk[x, y])
                        openNodes.Add(new Node(ref x, ref y, ref endX, ref endY, 2, nowNode)); //下右
                }
                catch { }

                x = nowX;
                y = (ushort)(nowY + 1);
                try
                {
                    if (canWalk[x, y])
                        openNodes.Add(new Node(ref x, ref y, ref endX, ref endY, 3, nowNode)); //中下
                }
                catch { }

                x = (ushort)(nowX - 1);
                y = (ushort)(nowY + 1);
                try
                {
                    if (canWalk[x, y])
                        openNodes.Add(new Node(ref x, ref y, ref endX, ref endY, 4, nowNode)); //左下
                }
                catch { }

                x = (ushort)(nowX - 1);
                y = nowY;
                try
                {
                    if (canWalk[x, y])
                        openNodes.Add(new Node(ref x, ref y, ref endX, ref endY, 5, nowNode)); //中左
                }
                catch { }

                x = (ushort)(nowX - 1);
                y = (ushort)(nowY - 1);
                try
                {
                    if (canWalk[x, y])
                        openNodes.Add(new Node(ref x, ref y, ref endX, ref endY, 6, nowNode)); //左上
                }
                catch { }

                x = nowX;
                y = (ushort)(nowY - 1);
                try
                {
                    if (canWalk[x, y])
                        openNodes.Add(new Node(ref x, ref y, ref endX, ref endY, 7, nowNode)); //中上
                }
                catch { }

                x = (ushort)(nowX + 1);
                y = (ushort)(nowY - 1);
                try
                {
                    if (canWalk[x, y])
                        openNodes.Add(new Node(ref x, ref y, ref endX, ref endY, 8, nowNode)); //右上
                }
                catch { }
            }

            #endregion 走訪四周並加入到 OpenNodes
        }

        private void getResultPath(List<Node> nodes, ref int endX, ref int endY)
        {
            int index = nodes.Count - 1;
            Node loc = null;
            List<Node> list = new List<Node>();
            if (nodes[index].x == endX && nodes[index].y == endY)
            {
                loc = nodes[index];
            }
            else
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i].x == endX && nodes[i].y == endY)
                    {
                        loc = nodes[i];
                    }
                }
            }
            while (loc.fromLoc != null)
            {
                loc.fromLoc.SettoLoc(loc);
                list.Add(loc);
                loc = loc.fromLoc;
            }
            _resultPath = list.ToArray();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PenghuSpace.Activity;
using SQLite;
using 函式庫.資料表;

namespace PenghuSpace.lib
{
    public class Maps
    {
        #region 屬性

        private string _mapDB { get; set; }

        private ushort _gId { get; set; }

        public ushort totalCol { get; private set; }

        public ushort totalRow { get; private set; }

        public string title { get; private set; }

        public int[,] mapBackPic { get; set; }

        public int[,] mapForePic { get; set; }

        public bool[,] mapWalk { get; set; }

        public ushort[,] teleport { get; set; }

        public ushort mId { get; private set; }

        #endregion 屬性

        public Maps()
        {

        }
        public Maps(ushort mId)
        {
            this.mId = mId;
            var core = TitleActivity.activityCore;
            _mapDB = core.mapDB;
            using (var cn = new SQLiteConnection(_mapDB))
            {
                string mapQuery = $"SELECT [title] FROM [Map] WHERE mId = {mId}";
                var result = cn.Query<Map>(mapQuery);
                foreach (var item in result)
                {
                    title = item.title;
                }

                string maptogridQuery = $"SELECT [gId] FROM [MapToGrid] WHERE mId = {mId}";
                var maptogridresult = cn.Query<MapToGrid>(maptogridQuery);
                foreach (var item in maptogridresult)
                {
                    _gId = item.gId;
                }

                string gridCountQuery = $"SELECT MAX([col]) AS col, MAX([row]) AS row FROM [Grid] WHERE gId = {_gId}";
                var gridCountResult = cn.Query<Grid>(gridCountQuery);
                foreach (var item in gridCountResult)
                {
                    totalCol = (ushort)(item.col + 1);
                    totalRow = (ushort)(item.row + 1);
                    mapWalk = new bool[totalCol, totalRow];
                    mapBackPic = new int[totalCol, totalRow];
                    mapForePic = new int[totalCol, totalRow];
                    teleport = new ushort[totalCol, totalRow];
                }

                string gridBackQuery = $"SELECT * FROM [Grid] WHERE gId = {_gId} AND [background] = 1";
                var gridBackresult = cn.Query<Grid>(gridBackQuery);
                foreach (var item in gridBackresult)
                {
                    mapBackPic[item.col, item.row] = item.pId;
                    mapWalk[item.col, item.row] = item.walk;
                }

                /*
                string gridForeQuery = $"SELECT * FROM [Grid] WHERE gId = {_gId} AND [background] = 0";
                var gridForeresult = cn.Query<Grid>(gridForeQuery);
                foreach (var item in gridForeresult)
                {
                    mapForePic[item.col, item.row] = item.pId;
                }
                */

                string teleportQuery = $"SELECT * FROM [Teleport] WHERE mId = {mId} AND teleport > 0";
                var teleports = cn.Query<Teleport>(teleportQuery);
                foreach (var item in teleports)
                {
                    teleport[item.col, item.row] = item.teleport;
                }
            }
        }
        public Maps(ushort mId, bool a)
        {
            this.mId = mId;
            var core = TitleActivity.activityCore;
            _mapDB = core.mapDB;
            using (var cn = new SQLiteConnection(_mapDB))
            {
                string mapQuery = $"SELECT [title] FROM [Map] WHERE mId = {mId}";
                var map = cn.Query<Map>(mapQuery).ToList();
                foreach (var item in map)
                {
                    title = item.title;
                }
            }
        }
    }
}
#region using
using Dapper;
using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;

namespace 地圖編輯器.方法.地圖.儲存.地圖
{
    internal class Map
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        /// <summary>
        /// 儲存地圖元資料。
        /// </summary>
        /// <param name="cn">資料庫連線</param>
        /// <param name="map">SQL指令</param>
        /// <param name="mId">地圖編號</param>
        /// <param name="angle">地圖視角</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void SaveMapMetaData(SqliteConnection cn, string map, ushort mId)
        {
            cn.Query(map, new
            {
                mId = mId,
                title = tb_map.Text
            });
        }
    }
}
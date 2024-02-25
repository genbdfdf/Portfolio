#region using
using Dapper;
using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;

namespace 地圖編輯器.方法.地圖.儲存.中繼資料
{
    internal class Meta
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
        /// <param name="mapToGrid">資料庫連線</param>
        /// <param name="mId">地圖編號</param>
        /// <param name="gId">格子資料編號</param>
        /// <param name="sum">格子資料總和</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void SaveMapToGridMetaData(SqliteConnection cn, string mapToGrid, ushort mId, ushort gId, uint sum)
        {
            cn.Query(mapToGrid, new
            {
                mId = mId,
                gId = gId,
                sum = sum
            });
        }
    }
}
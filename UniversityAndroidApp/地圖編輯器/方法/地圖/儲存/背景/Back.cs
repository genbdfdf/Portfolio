#region using
using Dapper;
using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;

namespace 地圖編輯器.方法.地圖.儲存.背景
{
    internal class Back
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        /// <summary>
        /// 儲存地圖背景資料。
        /// </summary>
        /// <param name="cn">資料庫連線</param>
        /// <param name="grid">SQL指令</param>
        /// <param name="gId">格子資料編號</param>
        /// <param name="walk">是否可行走</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void SaveMapBackData(SqliteConnection cn, string grid, ushort gId, ushort walk)
        {
            for (short x = 0; x < col; x++)
            {
                for (short y = 0; y < row; y++)
                {
                    // 確定該格是否能行走。
                    walk = 0;
                    if (mapBackWalk[x, y])
                    {
                        walk = 1;
                    }

                    cn.Query(grid, new
                    {
                        col = x,
                        row = y,
                        background = 1,
                        walk = walk,
                        gId = gId,
                        pId = mapBackPic[x, y] + 1
                    });
                }
            }
        }
    }
}
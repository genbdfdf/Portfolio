#region using
using Dapper;
using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;

namespace 地圖編輯器.方法.地圖.儲存.前景
{
    internal class Fore
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        /// <summary>
        /// 儲存地圖前景資料。
        /// </summary>
        /// <param name="cn">資料庫連線</param>
        /// <param name="grid">SQL指令</param>
        /// <param name="gId">格子資料編號</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void SaveMapForeData(SqliteConnection cn, string grid, ushort gId)
        {
            for (short x = 0; x < col; x++)
            {
                for (short y = 0; y < row; y++)
                {
                    
                    cn.Query(grid, new
                    {
                        col = x,
                        row = y,
                        background = 0,
                        gId = gId,
                        pId = mapForePic[x, y] + 1
                    });
                }
            }
        }
    }
}
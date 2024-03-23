#region using
using System.Collections.Generic;
using 函式庫.資料表;
namespace 地圖編輯器.變數
{
    internal class List
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        private List<Teleport> teleports = new List<Teleport>();
        private List<Teleport> dataBaseTeleports = new List<Teleport>();
    }
}
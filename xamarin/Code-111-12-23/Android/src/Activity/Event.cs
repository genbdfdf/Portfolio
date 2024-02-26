using Android.App;
using System.Runtime.CompilerServices;
namespace PenghuSpace.Activity
{
    public class Event
    {
        //EventId
        //1:取得物品 2:傳送 3:開啟文字描述 4:等待擴充
        //100:獲勝 101:死亡
        //textID
        //0:劇情 1:故事 2:對話
        #region 通用
        public ushort col { get; set; }//觸發地點x
        public ushort row { get; set; }//觸發地點y
        public ushort mId { get; set; }//觸發地圖id
        public ushort EventID { get; set; }//觸發類別
        public string EventDescribe { get; set; }//觸發描述
        #endregion

        #region 觸發類別--1--取得
        public ushort ItemID { get; set; }//物品id
        public string ItemName { get; set; }//物品名稱
        public ushort ItemCount { get; set; }//物品數量
        #endregion

        #region 觸發類別--2--傳送
        public ushort nextmId { get; set; }//傳送下一張地圖的id
        public ushort nextcol { get; set; }//傳送下一張地圖的x
        public ushort nextrow { get; set; }//傳送下一張地圖的y
        #endregion

        #region 觸發類別--3--文字描述
        public ushort textID { get; set; }//文字類別
        public ushort dialogueParagraph { get; set; }//文字段落
        #endregion
        #region 額外
        public ushort group { get; set; }//事件群組
        public ushort Commandid { get; set; }//指令id
        public ushort reward { get; set; }//任務報酬
        public bool IsMissionRun { get; set; }//任務報酬
        public ushort MissionId { get; set; }//任務報酬

        #endregion
    }
}

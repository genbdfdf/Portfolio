using System;
using System.Collections.Generic;

namespace PenghuSpace.Activity
{
    public class story
    {
        public List<Event> AddEvent(List<Event> eventList)
        {
            Array EnumValues = Enum.GetValues(typeof(story.itemEnum));
            //EventId
            //1:取得物品 2:傳送 3:開啟文字描述 4:開啟布告欄
            //100:任務 101:死亡
            //102:指令(無須觸發地點)
            //textID
            //0:劇情 1:故事 2:對話
            //Commandid必須大於0
            eventList.Clear();
            //eventList.Add(new Event() { row = 6, col = 59, mId = 3, EventID = 1, EventDescribe = "取得" + EnumValues.GetValue(0).ToString(), ItemID = (ushort)(int)EnumValues.GetValue(0), ItemName = EnumValues.GetValue(0).ToString(), ItemCount = 1 });

            //eventList.Add(new Event() { row = 6, col = 59, mId = 3, EventID = 3, EventDescribe = "開啟第一段劇情", textID = 0, dialogueParagraph = 0 });
            //eventList.Add(new Event() { row = 6, col = 59, mId = 3, EventID = 3, EventDescribe = "開啟第一段故事", textID = 1, dialogueParagraph = 0 });
            //eventList.Add(new Event() { row = 6, col = 59, mId = 3, EventID = 3, EventDescribe = "開啟第一段對話", textID = 2, dialogueParagraph = 0 });
            //eventList.Add(new Event() { row = 6, col = 59, mId = 3, EventID = 100, EventDescribe = "獲勝" });
            //eventList.Add(new Event() { row = 6, col = 59, mId = 3, EventID = 101, EventDescribe = "死亡" });
            /*eventList.Add(new Event() { row = 6, col = 59, mId = 3, EventID = 2, EventDescribe = "傳送至id=12的6-59", nextmId = 12, nextrow = 6, nextcol = 59 });
            eventList.Add(new Event() { row = 7, col = 59, mId = 3, EventID = 2, EventDescribe = "傳送至id=5的6-59", nextmId = 5, nextrow = 6, nextcol = 59 });
            eventList.Add(new Event() { row = 8, col = 59, mId = 3, EventID = 2, EventDescribe = "傳送至id=6的6-59", nextmId = 6, nextrow = 6, nextcol = 59 });
            eventList.Add(new Event() { row = 9, col = 59, mId = 3, EventID = 2, EventDescribe = "傳送至id=7的6-59", nextmId = 7, nextrow = 6, nextcol = 59 });
            eventList.Add(new Event() { row = 10, col = 59, mId = 3, EventID = 2, EventDescribe = "傳送至id=8的6-59", nextmId = 8, nextrow = 6, nextcol = 59 });
            eventList.Add(new Event() { row = 11, col = 59, mId = 3, EventID = 2, EventDescribe = "傳送至id=9的6-59", nextmId = 9, nextrow = 6, nextcol = 59 });*/
            for (int i = 0; i < 7; i++)
            {
                eventList.Add(new Event() { row = 42, col = (ushort)(4 + i), mId = 119, EventID = 4, EventDescribe = "開啟布告欄" });
            }
            for (int i = 0; i < 3; i++)
            {
                eventList.Add(new Event() { row = 39, col = (ushort)(17 + i), mId = 119, EventID = 4, EventDescribe = "開啟布告欄" });
            }
            eventList.Add(new Event() { mId = 26, EventID = 100, EventDescribe = "完成任務", reward = 1, MissionId = 1, IsMissionRun = false });
            //eventList.Add(new Event() { mId = 5, EventID = 100, EventDescribe = "完成任務2", reward = 102,  MissionId = 2, IsMissionRun = false });
            //eventList.Add(new Event() { mId = 6, EventID = 100, EventDescribe = "完成任務3", reward = 103,  MissionId = 3, IsMissionRun = false });
            //eventList.Add(new Event() { mId = 7, EventID = 100, EventDescribe = "完成任務4", reward = 104,  MissionId = 4, IsMissionRun = false });
            //eventList.Add(new Event() { mId = 8, EventID = 100, EventDescribe = "完成任務5", reward = 2 , MissionId = 5, IsMissionRun = false });
            //eventList.Add(new Event() { mId = 9, EventID = 100, EventDescribe = "完成最終任務", reward = 1, MissionId = 6, IsMissionRun = false });
            eventList.Add(new Event() { EventID = 102, nextmId = 1, nextrow = 124, nextcol = 55, Commandid = 1, EventDescribe = "傳送至id=12的124-55" });
            eventList.Add(new Event() { EventID = 102, nextmId = 26, nextrow = 5, nextcol = 1, Commandid = 2, EventDescribe = "傳送至id=12的59-6" });
            for (int i = 0; i < EnumValues.Length; i++)
            {
                eventList.Add(new Event() { EventID = 102, EventDescribe = "取得" + EnumValues.GetValue(i).ToString(), ItemID = (ushort)(int)EnumValues.GetValue(i), ItemName = EnumValues.GetValue(i).ToString(), ItemCount = 10 });
            }
            return eventList;
        }
        public enum itemEnum
        {
            澎科之魂碎片 = 1,
            澎科之魂,
            以下不可使用 = 100,
            澎科的精神1,
            澎科的精神2,
            澎科的精神3,
            澎科的精神4,
            澎科之魂B,
        }
    }
}

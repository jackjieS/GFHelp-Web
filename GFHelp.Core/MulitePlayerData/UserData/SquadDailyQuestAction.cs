using GFHelp.Core.CatchData.Base;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class SquadDailyQuestAction
    {
        public SquadDailyQuestAction(UserData userData)
        {
            this.userData = userData;
        }


        public void Read(JsonData jsonData)
        {
            this.listSquadDailyQuestAction.Clear();
            if (jsonData.Contains("squad_data_daily"))
            {
                JsonData jsonData16 = jsonData["squad_data_daily"];
                for (int num8 = 0; num8 < jsonData16.Count; num8++)
                {
                    Data data2 = new Data(jsonData16[num8]);
                    this.listSquadDailyQuestAction.Add(data2);
                }
            }
        }
        public List<Data> listSquadDailyQuestAction = new List<Data>();
        private UserData userData;
        public class Data
        {
            public Data(JsonData jsonData)
            {
                this.questId = jsonData["squad_id"].Int;
                this.count = jsonData["count"].Int;
                this.received = (jsonData["receive"].Int != 0);
            }
            // Token: 0x0400442D RID: 17453
            public int questId;

            // Token: 0x0400442E RID: 17454
            public int count;

            // Token: 0x0400442F RID: 17455
            public bool received;

            // Token: 0x04004430 RID: 17456
            //public Mail mail;

            //public int primaryDataCell
            //{
            //    get
            //    {
            //        if (this.questInfo != null)
            //        {
            //            return Mathf.CeilToInt((float)this.questInfo.dataNum[0] * Data.GetDataCellDailyRatio());
            //        }
            //        return 0;
            //    }
            //}
            //public int advancedDataCell
            //{
            //    get
            //    {
            //        if (this.questInfo != null)
            //        {
            //            return Mathf.CeilToInt((float)this.questInfo.dataNum[1] * Data.GetDataCellDailyRatio());
            //        }
            //        return 0;
            //    }
            //}
            public SquadDailyQuestInfo questInfo
            {
                get
                {
                    return GameData.listSquadDailyQuestInfo.GetDataById((long)this.questId);
                }
            }

        }
    }
}

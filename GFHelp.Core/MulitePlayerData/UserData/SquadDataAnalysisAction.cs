using GFHelp.Core.CatchData.Base.CMD;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class SquadDataAnalysisAction 
    {
        public SquadDataAnalysisAction(UserData userData)
        {
            this.userData = userData;
        }
        public void Read(JsonData jsonData)
        {
            this.listSquadDataAnalysisAction.Clear();
            if (jsonData.Contains("data_analysis_act_info"))
            {
                JsonData jsonData16 = jsonData["data_analysis_act_info"];
                for (int num8 = 0; num8 < jsonData16.Count; num8++)
                {
                    Data data2 = new Data(jsonData16[num8]);
                    this.listSquadDataAnalysisAction.Add(data2);
                }
            }
        }
        //public SquadDataAnalysisAction(JsonData jsonData = null)
        //{
        //    if (jsonData != null)
        //    {
        //        Data data = new Data();
        //        data.id = (long)jsonData["id"].Int;
        //        data.slot = jsonData["build_slot"].Int;
        //        data.endTime = jsonData["end_time"].Int;
        //    }
        //}

        // Token: 0x060023F6 RID: 9206 RVA: 0x000ECE24 File Offset: 0x000EB024


        tBaseDatas<Data> listSquadDataAnalysisAction = new tBaseDatas<Data>();
        private UserData userData;
        class Data : tBaseData
        {
            public Data(JsonData jsonData = null)
            {
                if (jsonData != null)
                {
                    this.id = (long)jsonData["id"].Int;
                    this.slot = jsonData["build_slot"].Int;
                    this.endTime = jsonData["end_time"].Int;
                }
            }
            public long GetID()
            {
                return this.id;
            }
            // Token: 0x04004414 RID: 17428
            public long id;

            // Token: 0x04004415 RID: 17429
            public int slot;

            // Token: 0x04004416 RID: 17430
            public int endTime;
        }

    }
}

using GFHelp.Core.CatchData.Base.CMD;
using GFHelp.Core.Helper;
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
            AutoRunning = true;
        }
        public void Read(int id,int datatime)
        {
            Data data2 = new Data(id, datatime);
            this.listSquadDataAnalysisAction.Add(data2);
        }

        public void AutoRun()
        {
            DataAnalysisFinishHandel();
            DataAnalysisStartHandel();
        }
        private bool isAllDataAnalysisFinish()
        {
            if(listSquadDataAnalysisAction.Count==0) return false;
            foreach (var item in listSquadDataAnalysisAction)
            {
                if(item.endTime > Decrypt.ConvertDateTime_China_Int(DateTime.Now))
                {
                    return false;
                }
            }
            return true;
        }
        private void DataAnalysisFinishHandel()
        {
            if (AutoRunning == false) return;
            if (!isAllDataAnalysisFinish()) return;
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "情报解析 准备 完成");
            DataAnalysisFinish();
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "情报解析 完成");




        }
        private bool DataAnalysisFinish()
        {

            int count = 0;
            while (true)
            {
                string result = API.Dorm.DataAnalysisFinishAll(userData.GameAccount);

                switch (Response.Check(userData.GameAccount, ref result, "DataAnalysisFinishAll", true))
                {
                    case 1:
                        {
                            DataAnalysisFinishRead(result);
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "DataAnalysisFinishAll ERROR", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }






        }
        private void DataAnalysisFinishRead(string result)
        {
            JsonData jsonData = JsonMapper.ToObject(result);
            if (result.Contains("data"))
            {
                jsonData = jsonData["data"];
                for (int num8 = 0; num8 < jsonData.Count; num8++)
                {
                    if (jsonData["piece"].Int == 1) continue;
                    Chip_With_User_Info.Data data = null;
                    try
                    {
                        JsonData temp = jsonData[num8]["chip"];
                        data = new Chip_With_User_Info.Data(temp, this.userData);
                    }
                    catch (Exception e)
                    {
                        new Log().systemInit("chip_with_user_info Error ", e.ToString()).coreInfo();
                    }
                    if (data.chipInfo.rank == 5)
                    {
                        this.userData.chip_With_User_Info.listSquadChipRank5.Add(data);
                    }
                    this.userData.chip_With_User_Info.listSquadChip.Add(data);
                }
                this.listSquadDataAnalysisAction.Clear();
            }
        }


        private void DataAnalysisStartHandel()
        {
            //检查是否足够资源
            if (AutoRunning == false) return;
            int inputLevel = isReadyDataAnalysisStart();
            if (inputLevel == -1) return;
            if (userData.chip_With_User_Info.listSquadChip.Count + userData.outhouse_Establish_Info.DataAnalysisMaxSolt >= userData.outhouse_Establish_Info.ChipsWhareHouse) return;
            DataAnalysisStart(inputLevel);
        }
        private void DataAnalysisStart(int inputLevel)
        {
            int num = this.userData.outhouse_Establish_Info.DataAnalysisMaxSolt;
            if (num <= 0)
            {
                AutoRunning = false;
                return;
            }
            string result = "";
            string data = "";
            while (true)
            {

                if (resultCheck(result) == -1)
                {
                    num--;
                    data = dataBuild(inputLevel, num);
                }
                if (resultCheck(result) == 0)
                {
                  data=  dataBuild(inputLevel, num);
                }

                int cost = num * 20;
                result = API.Dorm.DataAnalysis(userData.GameAccount,data);
                new Log().userInit(userData.GameAccount.Base.GameAccountID, result).userInfo();
                if (resultCheck(result) == 1)
                {
                    Response.Check(userData.GameAccount, ref result, "DataAnalysisStart", true);
                    if (inputLevel == 0) userData.item_With_User_Info.originalData -= cost;
                    if (inputLevel == 1) userData.item_With_User_Info.originalData -= cost;
                    DataAnalysisStartRead(result);
                    return;
                }
                if (num == 0)
                {
                    AutoRunning = false;
                    return;
                }
            }

        }

        private int resultCheck(string result)
        {
            if (result.Contains("max build_slot error")) return -1;
            if (result.StartsWith('#')) return 1;
            return 0;
        }
        private string dataBuild(int inputLevel,int num)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);

            jsonWriter.WriteObjectStart();

            jsonWriter.WritePropertyName("build_slot");
            jsonWriter.Write(0);

            jsonWriter.WritePropertyName("input_level");
            jsonWriter.Write(inputLevel);

            jsonWriter.WritePropertyName("number");
            jsonWriter.Write(num);

            jsonWriter.WritePropertyName("quick");
            jsonWriter.Write(0);

            jsonWriter.WriteObjectEnd();

            return sb.ToString();
        }
        private int isReadyDataAnalysisStart()
        {
            //300
            if (this.listSquadDataAnalysisAction.Count != 0) return -1;
            if (userData.item_With_User_Info.originalData > userData.outhouse_Establish_Info.DataAnalysisMaxSolt * 20) return 0;
            if (userData.item_With_User_Info.PureData > userData.outhouse_Establish_Info.DataAnalysisMaxSolt * 20) return 1;
            return -1;
        }
        private void DataAnalysisStartRead(string result)
        {
            this.listSquadDataAnalysisAction.Clear();
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["data"];
            int id = 1000;
            for(int i = 0; i < jsonData.Count; i++)
            {
                Read(id++,jsonData[i].Int);
            }
        }
        tBaseDatas<Data> listSquadDataAnalysisAction = new tBaseDatas<Data>();
        private UserData userData;
        private bool AutoRunning = true;
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
            public Data(int id,int time)
            {
                this.id = id;
                this.endTime = time;
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

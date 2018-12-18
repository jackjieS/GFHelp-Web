using GFHelp.Core.Action;
using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using Battle = GFHelp.Core.Action.BattleBase.Battle;

namespace GFHelp.Core.MulitePlayerData
{
    public class Task_Daily
    {
        public Task_Daily(UserData userData)
        {
            this.userData = userData;
        }
        public void Read(JsonData jsonData)
        {
            JsonData jsonData16 = jsonData["squad_data_daily"];
            if (listSquadData.Count == 0)
            {
                for (int num8 = 0; num8 < jsonData16.Count; num8++)
                {
                    SquadData data2 = new SquadData(jsonData16[num8]);
                    this.listSquadData.Add(data2);
                }

            }
            else
            {
                if (jsonData16[0]["last_finish_time"].String != listSquadData[0].last_finish_time)
                {
                    listSquadData.Clear();
                    Read(jsonData);
                }
            }

        }
        public void AutoRun()
        {
            //return;
            if (!userData.config.AutoSquadTaskDaily) return;
            if (listSquadData.Count == 0) return;
            for (int i = 0; i < listSquadData.Count; i++)
            {
                if (listSquadData[i].Added) continue;
                if (listSquadData[i].isFinish) continue;
                FinishTask(listSquadData[i]);
                listSquadData[i].Added = true;
            }

        }
        private void FinishTask(SquadData data)
        {
            //Battle bs = new Battle();
            //bs.accountID = userData.GameAccount.GameAccountID;
            //bs.Map = "-mapsimulationtrial";
            //bs.Parm = "-t1 -c -ns -qf -a -e";
            //if (userData.others.getAvailableTeamID().Count == 0) return;

            //bs.Teams = new List<Team>();
            //MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            //userData.MissionInfo.listTask.Add(data);


            if (data.isFinish) return;
            switch (data.squad_id)
            {
                case 1:
                    {
                        //1-1
                        addBattle1_1();
                        break;
                    }
                case 2:
                    {
                        //1-2 3次
                        addBattle1_2();
                        break;
                    }
                case 3:
                    {
                        //4-6 ×2次
                        addBattle4_6();
                        break;
                    }
                case 4:
                    {
                        //5-6 ×2次
                        addBattle5_6();
                        break;
                    }
                case 5:
                    {
                        //6-6 ×1次
                        addBattle6_6();
                        break;
                    }
                case 6:
                    {
                        //7-6 ×1次
                        addBattle7_6();
                        break;
                    }
                case 7:
                    {
                        //4-6 ×2次
                        addBattle4_6();
                        break;
                    }
                case 8:
                    {
                        //消灭装甲人形单位×3
                        addBattle3_4n();
                        break;
                    }
                case 9:
                    {
                        //消灭装甲机械单位×3
                        addBattle3_4n();
                        break;
                    }
                case 10:
                    {
                        //消灭无甲人形单位×3
                        addBattle2_4();
                        break;
                    }
                case 11:
                    {
                        //消灭无甲机械单位×3
                        addBattle1_2();
                        break;
                    }
                case 12:
                    {
                        //1-1
                        addBattle1_1();
                        break;
                    }
                case 13:
                    {
                        //紧急战役1次
                        addBattle2_2e();
                        break;
                    }
                case 14:
                    {
                        //夜战战役关卡1次

                        break;
                    }



                default:
                    break;
            }



        }


        private void addBattle1_1()
        {
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-map1_1";
            bs.Parm = "-t1 -c -ns -qf -a -e";
            bs.CreatTeamList(userData.others.getAvailableTeamID());
            if (userData.others.getAvailableTeamID().Count == 0) return;
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.listTask.Add(data);
        }
        private void addBattle1_2()
        {
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-map1_2";
            bs.Parm = "-t4 -c -ns -qf -a -e";
            bs.CreatTeamList(userData.others.getAvailableTeamID());
            if (userData.others.getAvailableTeamID().Count == 0) return;
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.listTask.Add(data);
        }
        private void addBattle2_4()
        {
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-map2_4";
            bs.Parm = "-t4 -c -ns -qf -a -e";
            bs.CreatTeamList(userData.others.getAvailableTeamID());
            if (userData.others.getAvailableTeamID().Count == 0) return;
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.listTask.Add(data);
        }
        private void addBattle2_2e()
        {
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-map2_2e";
            bs.Parm = "-t1 -c -ns -qf -a -e";
            bs.CreatTeamList(userData.others.getAvailableTeamID());
            if (userData.others.getAvailableTeamID().Count == 0) return;
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.listTask.Add(data);
        }

        private void addBattle4_6()
        {
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-map4_6";
            bs.Parm = "-t2 -c -ns -qf -a -e";
            bs.CreatTeamList(userData.others.getAvailableTeamID());
            if (userData.others.getAvailableTeamID().Count <2) return;
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.listTask.Add(data);
        }
        private void addBattle5_6()
        {
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-map5_6";
            bs.Parm = "-t2 -c -ns -qf -a -e";
            bs.CreatTeamList(userData.others.getAvailableTeamID());
            if (userData.others.getAvailableTeamID().Count < 2) return;
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.listTask.Add(data);
        }
        private void addBattle6_6()
        {
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-map6_6";
            bs.Parm = "-t1 -c -ns -qf -a -e";
            bs.CreatTeamList(userData.others.getAvailableTeamID());
            if (userData.others.getAvailableTeamID().Count < 2) return;
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.listTask.Add(data);
        }
        private void addBattle7_6()
        {
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-map7_6";
            bs.Parm = "-t1 -c -ns -qf -a -e";
            bs.CreatTeamList(userData.others.getAvailableTeamID());
            if (userData.others.getAvailableTeamID().Count < 2) return;
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.listTask.Add(data);
        }
        private void addBattle3_4n()
        {
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-map3_4n";
            bs.Parm = "-t5 -c -ns -qf -a -e";
            bs.CreatTeamList(userData.others.getAvailableTeamID());
            if (userData.others.getAvailableTeamID().Count < 2) return;
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.listTask.Add(data);
        }










        public class SquadData
        {
            public SquadData()
            {

            }
            public SquadData(JsonData jsonData=null)
            {
                if (jsonData != null)
                {
                    this.user_id = jsonData["user_id"].Int;
                    this.squad_id = jsonData["squad_id"].Int;
                    this.type = jsonData["type"].String;
                    this.last_finish_time = jsonData["last_finish_time"].String;
                    this.count = jsonData["count"].Int;
                    this.receive = jsonData["receive"].Int;
                    if (this.receive == 1) this.isFinish = true;
                }
            }
            public int user_id;
            public int squad_id;
            public string type;
            public string last_finish_time;
            public int count;
            public int receive;
            public bool isFinish = false;
            public bool Added = false;
        }




        UserData userData;
        public List<SquadData> listSquadData = new List<SquadData>();




    }
}

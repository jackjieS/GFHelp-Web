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
        public void ReadTask_Daily(JsonData jsonData)
        {
            dailyTaskData = new DailyTaskData(jsonData);
            DailyTaskHandle();

            //

        }




        public void AutoRun()
        {
            //return;
            if (!userData.config.AutoTaskDaily) return;
            if (listSquadData.Count == 0) return;
            for (int i = 0; i < listSquadData.Count; i++)
            {
                if (listSquadData[i].Added) continue;
                if (listSquadData[i].isFinish) continue;
                FinishTask(listSquadData[i]);
                listSquadData[i].Added = true;
            }

        }


        private void DailyTaskHandle()
        {
            if (Convert.ToInt16(dailyTaskData.mission) < 10)
            {
                if (userData.config.M == true)
                {
                    ;
                }
                else
                {
                    if (!CheckBattleList("map1_1"))
                    {
                        addBattle1_1(10);
                    }

                }

            }
            if (Convert.ToInt16(dailyTaskData.develop_gun) < 4)
            {
                 userData.doll_Build.startDevelopDailyTaskHandel();
            }
            if (Convert.ToInt16(dailyTaskData.develop_equip) < 4)
            {
                if (userData.config.M == true)
                {
                    ;
                }
                else
                {
                    userData.equip_Built.startDevelopDailyTaskHandel();
                }

            }

            if (Convert.ToInt16(dailyTaskData.eat) < 5)
            {
                if (userData.gun_With_User_Info.dicGun.Count >30)
                {
                    userData.Factory.EatGunHandle(1);
                }
                else
                {

                }

            }
            if (Convert.ToInt16(dailyTaskData.eat_equip) < 5)
            {
                userData.Factory.Eat_EquipHandle(FoodNum:1);
            }
            userData.webData.StatusBarText = "空闲";
        }
        private void FinishTask(SquadData data)
        {
            if (userData.config.M == true) return;



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

        private bool CheckBattleList(string map)
        {
            foreach (var item in userData.MissionInfo.listTask)
            {
                if (item.MissionMap.Contains(map)) return true;
            }
            return false;
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
            userData.MissionInfo.Add(data);
        }
        private void addBattle1_1(int i)
        {

            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-map1_1";
            string parm = string.Format("-t{0} -c -ns -qf -a -e", i);
            bs.Parm = parm;
            bs.CreatTeamList(userData.others.getAvailableTeamID());
            if (userData.others.getAvailableTeamID().Count == 0) return;
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.Add(data);
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
            userData.MissionInfo.Add(data);
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
            userData.MissionInfo.Add(data);
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
            userData.MissionInfo.Add(data);
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
            userData.MissionInfo.Add(data);
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
            userData.MissionInfo.Add(data);
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
            userData.MissionInfo.Add(data);
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
            userData.MissionInfo.Add(data);
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
            userData.MissionInfo.Add(data);
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
        public class DailyTaskData
        {
            public DailyTaskData()
            {

            }
            public DailyTaskData(JsonData jsonData = null)
            {

                if (jsonData != null)
                {
                    jsonData = jsonData["daily"];
                    this.mission = jsonData["mission"].String;
                    this.operation = jsonData["operation"].String;
                    this.coin_mission = jsonData["coin_mission"].String;
                    this.squad_data_analyse = jsonData["squad_data_analyse"].String;
                    this.from_friend_build_coin = jsonData["from_friend_build_coin"].String;
                    this.eat = jsonData["eat"].String;
                    this.id = jsonData["id"].String;
                    this.end_time = jsonData["end_time"].String;
                    this.develop_gun = jsonData["develop_gun"].String;
                    this.fix = jsonData["fix"].String;
                    this.develop_equip = jsonData["develop_equip"].String;
                    this.win_robot = jsonData["win_robot"].String;
                    this.win_person = jsonData["win_person"].String;
                    this.win_boss = jsonData["win_boss"].String;
                    this.win_armorrobot = jsonData["win_armorrobot"].String;
                    this.win_armorperson = jsonData["win_armorperson"].String;
                    this.eat_equip = jsonData["eat_equip"].String;
                    this.borrow_friend_team = jsonData["borrow_friend_team"].String;

                }
            }
            public string mission;
            public string operation;
            public string coin_mission;
            public string squad_data_analyse;
            public string from_friend_build_coin;
            public string eat;
            public string id;
            public string user_id;
            public string end_time;
            public string develop_gun;
            public string fix;
            public string upgrade;
            public string develop_equip;
            public string win_robot;
            public string win_person;
            public string win_boss;
            public string win_armorrobot;
            public string win_armorperson;
            public string eat_equip;
            public string borrow_friend_team;
        }
        UserData userData;
        public List<SquadData> listSquadData = new List<SquadData>();
        DailyTaskData dailyTaskData = new DailyTaskData();



    }
}

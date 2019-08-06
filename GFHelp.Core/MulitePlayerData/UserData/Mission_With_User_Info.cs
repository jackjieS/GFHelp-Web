
using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core.MulitePlayerData
{
    public class Mission_With_User_Info
    {
        public Mission_With_User_Info(UserData UserData)
        {
            this.UserData = UserData;
        }
        public List<Data> listInfo = new List<Data>();
        public UserData UserData;

        public bool Added=false;
        public void Read(JsonData jsonData)
        {
            this.listInfo.Clear();
            if (jsonData.Contains("mission_with_user_info"))
            {
                JsonData jsonData16 = jsonData["mission_with_user_info"];
                for (int num8 = 0; num8 < jsonData16.Count; num8++)
                {
                    Data data2;
                    try
                    {
                        data2 = new Data(jsonData16[num8]);
                    }
                    catch (Exception e)
                    {
                        new Log().systemInit("mission_with_user_info Error ", e.ToString()).coreInfo();
                        throw;
                    }

                    this.listInfo.Add(data2);
                }
            }
        }
        public bool CheckMissionisOpen(int missionID)
        {
            foreach (var item in listInfo)
            {
                if (item.mission_id == "missionID") return true;

            }
            return false;
        }
        public bool CheckMissionisOpen()
        {
            bool mission02 = false;
            bool mission71 = false;

            foreach (var item in listInfo)
            {
                if (item.mission_id == "2") mission02 = true;
                if (item.mission_id == "65") mission71 = true;
            }

            if (mission02 && mission71) return true;

            return false;
        }
        private bool CheckBattleList(string map)
        {
            foreach (var item in UserData.MissionInfo.listTask)
            {
                if (item.MissionMap.Contains(map)) return true;
            }
            return false;
        }
        public void MHandel()
        {
            if (UserData.config.M == false) return;
            if (Added == true) return;
            if (CheckMissionisOpen()==false)
            {
                UserData.others.initTeam();
                if (!CheckBattleList("mapnormal"))
                {
                    addBattleMapnormal();
                }

                if (!CheckBattleList("mapemergency"))
                {
                    addBattlemapemergency();
                }
                Added = true;
            }
        }

        public void Add0_2Level50()
        {
            Battle bs = new Battle();
            bs.accountID = UserData.GameAccount.GameAccountID;
            bs.Map = "-map0_2";
            bs.Parm = string.Format("-t300 -a -e -ns -qf -lv50 -d0.1");
            bs.CreatTeamList(UserData.others.getAvailableTeamID());
            if (UserData.others.getAvailableTeamID().Count == 0) return;
            MissionInfo.Data data = new MissionInfo.Data(UserData, bs);
            UserData.MissionInfo.Add(data);
        }

      










        private void addBattleMapnormal()
        {

            Battle bs = new Battle();
            bs.accountID = UserData.GameAccount.GameAccountID;
            bs.Map = "-mapnormal";
            bs.Parm = string.Format("-t1 -c -ns -qf -a -e -d0.05");
            bs.CreatTeamList(UserData.others.getAvailableTeamID());
            if (UserData.others.getAvailableTeamID().Count == 0) return;
            MissionInfo.Data data = new MissionInfo.Data(UserData, bs);
            UserData.MissionInfo.Add(data);
        }
        private void addBattlemapemergency()
        {

            Battle bs = new Battle();
            bs.accountID = UserData.GameAccount.GameAccountID;
            bs.Map = "-mapemergency";
            bs.Parm = string.Format("-t1 -c -ns -qf -a -e -d0.05");
            bs.CreatTeamList(UserData.others.getAvailableTeamID());
            if (UserData.others.getAvailableTeamID().Count == 0) return;
            MissionInfo.Data data = new MissionInfo.Data(UserData, bs);
            UserData.MissionInfo.Add(data);
        }

        public class Data
        {

            public Data(JsonData jsonData = null)
            {
                if (jsonData != null)
                {
                    this.id = jsonData["id"].String;
                    this.user_id = jsonData["user_id"].String;
                    this.mission_id = jsonData["mission_id"].String;
                    this.medal2 = jsonData["medal2"].String;
                    this.bestrank = jsonData["bestrank"].String;
                    this.medal4 = jsonData["medal4"].String;
                    this.counter = jsonData["counter"].String;
                    this.win_counter = jsonData["win_counter"].String;
                    this.shortest_in_coinmission = jsonData["shortest_in_coinmission"].String;
                    this.type5_score = jsonData["type5_score"].String;
                    this.is_open = jsonData["is_open"].String;
                    this.is_drop_draw_event = jsonData["is_drop_draw_event"].String;
                    this.is_close = jsonData["is_close"].String;
                    this.cycle_win_count = jsonData["cycle_win_count"].String;
                    this.mapped_win_counter = jsonData["mapped_win_counter"].String;

                }
            }

            public string id;
            public string user_id;
            public string mission_id;
            public string medal1;
            public string medal2;
            public string bestrank;
            public string medal4;
            public string counter;
            public string win_counter;
            public string shortest_in_coinmission;
            public string type5_score;
            public string is_open;
            public string is_drop_draw_event;
            public string is_close;
            public string cycle_win_count;
            public string mapped_win_counter;

        }



    }
}

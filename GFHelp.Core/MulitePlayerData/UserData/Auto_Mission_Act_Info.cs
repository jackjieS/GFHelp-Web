using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public  class Auto_Mission_Act_Info
    {
        public Auto_Mission_Act_Info(UserData userData)
        {
            this.userData = userData;
        }

        public  void Read(LitJson.JsonData jsonData)
        {

                if (jsonData["auto_mission_act_info"]== null) return;
                jsonData = jsonData["auto_mission_act_info"];
                listData = new List<Data>();
                try
                {
                for (int i = 0; i < jsonData.Count; i++)
                {
                    Data data = new Data(jsonData[i]);
                    this.listData.Add(data);
                }

                }
                catch (Exception e)
                {

                   new Helper.Log().userInit(userData.GameAccount.GameAccountID, "读取自律作战出错", e.ToString());

                }
        }
        public bool CheckGunStatus(Gun_With_User_Info gwui)
        {
            foreach (var item in listData)
            {
                foreach (var k in item.listTeamID)
                {
                    if (k == gwui.teamId) return true;
                }
            }

            return false;
        }
        public bool CheckTeamStatus(int id)
        {
            foreach (var item in listData)
            {
                if (item.listTeamID.Contains(id)) return true;
            }


            return false;
        }


        private UserData userData;
        public List<Data> listData = new List<Data>();
        public class Data
        {
            public Data(LitJson.JsonData jsonData)
            {
                this.id = jsonData["id"].Int;
                this.user_id = jsonData["user_id"].Int;
                this.auto_mission_id = jsonData["auto_mission_id"].Int;
                this.end_time = jsonData["end_time"].Int;
                this.number = jsonData["number"].Int;
                var temp = jsonData["team_ids"].String.Split(",");
                foreach (var item in temp)
                {
                    listTeamID.Add(Convert.ToInt32(item));
                }

            }
            public int auto_mission_id;
            public int user_id;
            public List<int> listTeamID = new List<int>();
            public long end_time;
            public int id;
            public int number;
        }




    }
}

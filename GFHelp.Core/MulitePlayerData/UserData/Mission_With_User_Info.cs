using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Mission_With_User_Info
    {
        public Mission_With_User_Info(UserData userData)
        {
            this.userData = userData;
        }
        public void Read(JsonData jsonData)
        {
            this.listData.Clear();
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
                    this.listData.Add(data2);
                }
            }
            userData.others.isWaveTechOpen = isMissionOpen(84) ? true : false;
        }

        public bool isMissionOpen(int missionID)
        {
            foreach (var item in listData)
            {
                if (item.mission_id == missionID.ToString())
                {
                    if (item.is_open=="1")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private UserData userData;
        public List<Data> listData = new List<Data>();
        public class Data
        {
            public Data(JsonData jsonData)
            {
                this.id = jsonData["id"].String;
                this.user_id = jsonData["user_id"].String;
                this.mission_id = jsonData["mission_id"].String;
                this.medal1 = jsonData["medal1"].String;
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

        }




    }
}

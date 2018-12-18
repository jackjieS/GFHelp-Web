using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Upgrade_Act_Info
    {
        public Upgrade_Act_Info(UserData userdata)
        {
            this.userdata = userdata;
        }
        public Dictionary<int, Data> dic_Upgrade = new Dictionary<int, Data>();
        public UserData userdata;
        public void Read(JsonData jsonData)
        {

            dic_Upgrade.Clear();
            if (jsonData.Contains("upgrade_act_info"))
            {
                JsonData jsonData16 = jsonData["upgrade_act_info"];
                for (int num8 = 0; num8 < jsonData16.Count; num8++)
                {
                    Data data2 = new Data(jsonData16[num8]);
                    this.dic_Upgrade.Add(dic_Upgrade.Count,data2);
                }
            }
        }
        public bool isUpgradING(int GunID)
        {
            foreach (var item in dic_Upgrade)
            {
                if (item.Value.gun_with_user_id == GunID) return true;
            }
            return false;
        }


        public class Data
        {
            public Data(JsonData jsonData)
            {
                this.user_id = jsonData["user_id"].Int;
                this.gun_with_user_id = jsonData["gun_with_user_id"].Int;
                this.skill = jsonData["skill"].Int;
                this.upgrade_slot = jsonData["upgrade_slot"].Int;
                this.fairy_with_user_id = jsonData["fairy_with_user_id"].Int;
                this.end_time = jsonData["end_time"].Int;
            }

            public int user_id;
            public int gun_with_user_id;
            public int skill;
            public int upgrade_slot;
            public int fairy_with_user_id;
            public int end_time;







        }




    }
}



using GFHelp.Core.Helper;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Fairy_With_User_info
    {
        public Dictionary<int, Data> dicFairy = new Dictionary<int, Data>();
        public int id;
        public int user_id;
        public int fairy_id;
        public int team_id;
        public int fairy_lv;
        public int fairy_exp;
        public int quality_lv;
        public int quality_exp;
        public int skill_lv;
        public int passive_skill;
        public int is_locked;
        public int equip_id;
        public int adjust_count;
        public int last_adjust;
        public string passive_skill_collect;
        public bool Read(JsonData jsonData)
        {
            dicFairy.Clear();
            jsonData = jsonData["fairy_with_user_info"];
            for (int x = 0; x < jsonData.Count; x++)
            {
                Data data;
                try
                {
                    data = new Data(jsonData[x]);

                }
                catch (Exception e)
                {
                    new Log().systemInit("读取UserData_equip_with_user_info", e.ToString()).coreError();
                    continue;
                }
                dicFairy.Add(dicFairy.Count, data);
            }
            return true;
        }

        public class Data
        {
            public Data(int with_userID)
            {
                this.id = with_userID;
            }
            public Data(JsonData jsonData)
            {
                this.id = jsonData["id"].Int;
                this.user_id = jsonData["user_id"].Int;
                this.fairy_id = jsonData["fairy_id"].Int;
                this.team_id = jsonData["team_id"].Int;
                this.fairy_lv = jsonData["fairy_lv"].Int;
                this.fairy_exp = jsonData["fairy_exp"].Int;
                this.quality_lv = jsonData["quality_lv"].Int;
                this.quality_exp = jsonData["quality_exp"].Int;
                this.skill_lv = jsonData["skill_lv"].Int;
                this.passive_skill = jsonData["passive_skill"].Int;
                this.is_locked = jsonData["is_locked"].Int;
                this.equip_id = jsonData["equip_id"].Int;
                this.adjust_count = jsonData["adjust_count"].Int;
                this.last_adjust = jsonData["last_adjust"].Int;
                this.passive_skill_collect = jsonData["passive_skill_collect"].String;
            }

            public int id;
            public int user_id;
            public int fairy_id;
            public int team_id;
            public int fairy_lv;
            public int fairy_exp;
            public int quality_lv;
            public int quality_exp;
            public int skill_lv;
            public int passive_skill;
            public int is_locked;
            public int equip_id;
            public int adjust_count;
            public int last_adjust;
            public string passive_skill_collect;



        }


    }
}

using GFHelp.Core.Helper;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Fairy_With_User_info
    {
        public static Dictionary<int, Fairy_With_User_info> dicFairy = new Dictionary<int, Fairy_With_User_info>();
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
        public bool Read(dynamic jsonobj)
        {
            dicFairy.Clear();
            string result = jsonobj.ToString();
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["fairy_with_user_info"];
            for (int x = 0; x < jsonData.Count; x++)
            {
                Fairy_With_User_info fwui = new Fairy_With_User_info();
                try
                {
                    JsonData temp = jsonData[x];
                    fwui.id = temp["id"].Int;
                    fwui.user_id = temp["user_id"].Int;
                    fwui.fairy_id = temp["fairy_id"].Int;
                    fwui.team_id = temp["team_id"].Int;
                    fwui.fairy_lv = temp["fairy_lv"].Int;
                    fwui.fairy_exp = temp["fairy_exp"].Int;
                    fwui.quality_lv = temp["quality_lv"].Int;
                    fwui.quality_exp = temp["quality_exp"].Int;
                    fwui.skill_lv = temp["skill_lv"].Int;
                    fwui.passive_skill = temp["passive_skill"].Int;
                    fwui.is_locked = temp["is_locked"].Int;
                    fwui.equip_id = temp["equip_id"].Int;
                    fwui.adjust_count = temp["adjust_count"].Int;
                    fwui.last_adjust = temp["last_adjust"].Int;
                    fwui.passive_skill_collect = temp["passive_skill_collect"].String;
                }
                catch (Exception e)
                {
                    new Log().systemInit("读取UserData_equip_with_user_info", e.ToString()).coreError();

                    continue;
                }
                dicFairy.Add(dicFairy.Count, fwui);
            }
            return true;
        }
    }
}

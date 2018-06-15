using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Upgrade_Act_Info
    {
        public Dictionary<int, Upgrade_Act_Info> dic_Upgrade = new Dictionary<int, Upgrade_Act_Info>();
        public int user_id;
        public int gun_with_user_id;
        public int skill;
        public int upgrade_slot;
        public int fairy_with_user_id;
        public int end_time;
        public void Read(dynamic jsonobj)
        {
            dic_Upgrade.Clear();

            foreach (var item in jsonobj.upgrade_act_info)
            {
                Upgrade_Act_Info uai = new Upgrade_Act_Info();
                try
                {
                    uai.user_id = Convert.ToInt32(item.user_id);
                    uai.gun_with_user_id = Convert.ToInt32(item.gun_with_user_id);
                    uai.skill = Convert.ToInt32(item.skill);
                    uai.upgrade_slot = Convert.ToInt32(item.upgrade_slot);
                    uai.fairy_with_user_id = Convert.ToInt32(item.fairy_with_user_id);
                    uai.end_time = Convert.ToInt32(item.end_time);
                }
                catch (Exception e)
                {
                    SysteOthers.Log log = new SysteOthers.Log(1, "读取UserData_upgrade_act_info遇到错误", e.ToString());
                    SysteOthers.Viewer.Logs.Add(log);
                    continue;
                }
                dic_Upgrade.Add(dic_Upgrade.Count, uai);
            }
            return;
        }
    }
}



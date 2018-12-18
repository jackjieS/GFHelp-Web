using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public  class Auto_Mission_Act_Info
    {
        public int auto_mission_id;
        public int user_id;
        public List<int> listTeamID = new List<int>();
        public long end_time;

        public  void Read(dynamic jsonobj)
        {
            //amai
            try
            {
                if (jsonobj.auto_mission_act_info == null) return;
                auto_mission_id = Convert.ToInt32(jsonobj.auto_mission_act_info.auto_mission_id);
                user_id = Convert.ToInt32(jsonobj.auto_mission_act_info.user_id);
                listTeamID.Clear();
                foreach (var item in jsonobj.auto_mission_act_info.team_ids.Split(','))
                {
                    if (String.IsNullOrEmpty(item)) continue;
                    listTeamID.Add(Convert.ToInt32(item));
                }
                end_time = Convert.ToInt32(jsonobj.auto_mission_act_info.end_time);
            }
            catch (Exception)
            {
            }


        }






    }
}

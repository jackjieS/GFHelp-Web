using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class Auto_Mission_Info
    {
        public int mission_id;
        public int team_effect;
        public int team_count;
        public int mp;
        public int ammo;
        public int mre;
        public int part;
        public int duration;
        public int experience;
        public int expect_gun_level;
        public int get_gun_num;
        public List<int> gun_n_pool = new List<int>();
        public List<int> gun_1_pool = new List<int>();
        public int limit_guns;
        public int get_equip_num;
        public List<int> equip_n_pool = new List<int>();
        public List<int> equip_1_pool = new List<int>();

        public int draw_event_id;
        public int limit_equips;
    }
}

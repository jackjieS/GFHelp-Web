using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class Operation_Info
    {
        public int id;
        public int campaign;
        public string name;
        public string description;
        public int duration;
        public int mp;
        public int ammo;
        public int mre;
        public int part;
        public List<int> item_pool = new List<int>();
        public int team_leader_min_level;
        public int gun_min;
        public int guntype1_min;
        public int guntype2_min;
        public int guntype3_min;
        public int guntype4_min;
        public int guntype5_min;
        public int guntype6_min;
        public int guntype7_min;

    }
}

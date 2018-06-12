using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class Gun_Info : StcGun, tBaseData, IComparer<Gun_Info>
    {
        //public int id;
        //public string name;
        //public string en_name;
        //public string introduce;
        //public string en_introduce;
        //public string code;

        //public int rank;
        //public int max_equip;
        //public float ratio_life;
        public float ratioLife;
        //public int ratio_armor;
        //public int baseammo;
        //public int basemre;
        //public int ammo_add_withnumber;
        //public int mre_add_withnumber;
        //public int ratio_pow;
        public int ratioPow;
        //public int ratio_hit;
        //public int ratio_dodge;
        //public int ratio_range;
        //public int ratio_speed;
        //public int ratio_rate;
        //public int armor_piercing;
        //public int crit;
        //public int retiremp;
        //public int retireammo;
        //public int retiremre;
        //public int retirepart;
        //public float eat_ratio;
        public float eatRatio;
        //public int develop_duration;
        //public string dialogue;
        //public int effect_grid_center;
        //public int effect_guntype;

        //public List<int> effect_grid_pos = new List<int>();
        //public Dictionary<int, List<int>> effect_grid_effect = new Dictionary<int, List<int>>();//
        ////public int[] effect_grid_effect = new int[8];
        //public int skill1;
        //public int skill2;
        //public int repel_probability;
        //public double repel_distance;
        //public int special;
        //public string extra;

        //public Dictionary<int, List<int>> type_equip1 = new Dictionary<int, List<int>>();
        //public Dictionary<int, List<int>> type_equip2 = new Dictionary<int, List<int>>();
        //public Dictionary<int, List<int>> type_equip3 = new Dictionary<int, List<int>>();
        //public Dictionary<int, List<int>> type_equip4 = new Dictionary<int, List<int>>();

        //public int ai;
        //public int normal_attack;
        //public string passive_skill;
        //public int is_additional;
        //public int launch_time;

        public int ratioRate;
        public int maxAddRate;

        public int ratioHit;

        public int armorPiercing;
        // Token: 0x040017DE RID: 6110
        public int ratioArmor;

        public int ratioCrit;
        // Token: 0x040017E0 RID: 6112
        public int ratioDodge;

        // Token: 0x040017E2 RID: 6114
        public int ratioSpeed;


        // Token: 0x040017F1 RID: 6129
        public List<int> skills = new List<int>();

        public int Compare(Gun_Info x, Gun_Info y)
        {
            return x.id - y.id;
        }

        // Token: 0x06001FE0 RID: 8160 RVA: 0x000B0450 File Offset: 0x000AE650
        public long GetID()
        {
            return (long)this.id;
        }
        //public int Compare(GunInfo x, GunInfo y)
        //{
        //    return (x.id - y.id);
        //}

    }
}

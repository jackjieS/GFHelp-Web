using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class Fairy_Info
    {


        public int id;
        public string name;
        public string code;
        public string description;
        public string introduce;
        public int type;
        public int pow;
        public int hit;
        public int dodge;
        public int armor;
        public int critical_harm_rate;
        public int grow;
        public Dictionary<int, float> proportion = new Dictionary<int, float>();
        public string skill_id;
        public int quality_exp;
        public Dictionary<int, int> quality_need_number = new Dictionary<int, int>();
        public int develop_duration;
        public int retiremp;
        public int retireammo;
        public int retiremre;
        public int retirepart;
        public int powerup_mp;
        public int powerup_ammo;
        public int powerup_mre;
        public int powerup_part;
        public int armor_piercing;
        public int category;
        public int ai;

        //也许要另外赋值
        public int basePow;
        public int growthValue;
        public Dictionary<int, float> dictProportion = new Dictionary<int, float>();
        public int baseHit;
        public int baseDodge;
        public int baseCritDamage;
        // Token: 0x04001234 RID: 4660
        public int baseArmor;
    }
}

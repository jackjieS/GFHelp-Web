using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class Equip_Info
    {
        public int id;
        public int user_id;
        public string name;
        public string description;
        public int rank;
        public int category;//具体类型
        public int type;//3大类
        public string pow;
        public string hit;
        public string dodge;
        public string speed;
        public string rate;
        public string critical_harm_rate;
        public List<int> critical_percent = new List<int>();
        public string armor_piercing;
        public string armor;
        public string shield;
        public string damage_amplify;
        public string damage_reduction;
        public string night_view_percent;
        public string bullet_number_up;
        public string slow_down_percent;
        public int slow_down_rate;
        public int slow_down_time;
        public string dot_percent;
        public int dot_damage;
        public int dot_time;
        public int retire_mp;
        public int retire_ammo;
        public int retire_mre;
        public int retire_part;
        public string code;
        public int develop_duration;
        public string company;
        public int skill_level_up;
        public string fit_guns;
        public string equip_introduction;
        public double powerup_mp;
        public double powerup_ammo;
        public double powerup_mre;
        public double powerup_part;
        public float exclusive_rate;

        public string bonus_type;

        public int skill;
        public int max_level;
        // Token: 0x04001415 RID: 5141
        public string strBounsType;
    }
}

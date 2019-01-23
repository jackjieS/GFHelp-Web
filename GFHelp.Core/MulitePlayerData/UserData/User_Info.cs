using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class User_Info
    {
        public bool Read(dynamic jsonobj)
        {
            try
            {
                id = Convert.ToInt32(jsonobj.user_info.id);
                user_id = Convert.ToInt32(jsonobj.user_info.user_id);
                open_id = jsonobj.user_info.open_id.ToString();
                channel_id = jsonobj.user_info.channel_id.ToString();
                sign = jsonobj.user_info.sign.ToString();
                name = jsonobj.user_info.name.ToString();
                gem = Convert.ToInt32(jsonobj.user_info.gem);
                pause_turn_chance = Convert.ToInt32(jsonobj.user_info.pause_turn_chance);
                lv = Convert.ToInt32(jsonobj.user_info.lv);
                maxequip = Convert.ToInt32(jsonobj.user_info.maxequip);
                experience = Convert.ToInt32(jsonobj.user_info.experience);


                maxgun = Convert.ToInt32(jsonobj.user_info.maxgun);
                maxteam = Convert.ToInt32(jsonobj.user_info.maxteam);
                max_build_slot = Convert.ToInt32(jsonobj.user_info.max_build_slot);
                max_equip_build_slot = Convert.ToInt32(jsonobj.user_info.max_equip_build_slot);
                max_fix_slot = Convert.ToInt32(jsonobj.user_info.max_fix_slot);
                max_upgrade_slot = Convert.ToInt32(jsonobj.user_info.max_upgrade_slot);
                max_gun_preset = Convert.ToInt32(jsonobj.user_info.max_gun_preset);
                max_fairy = Convert.ToInt32(jsonobj.user_info.max_fairy);
                maxdorm = Convert.ToInt32(jsonobj.user_info.maxdorm);
                bp = Convert.ToInt32(jsonobj.user_info.bp);

                bp_pay = Convert.ToInt32(jsonobj.user_info.bp_pay);
                mp = Convert.ToInt32(jsonobj.user_info.mp);
                ammo = Convert.ToInt32(jsonobj.user_info.ammo);
                mre = Convert.ToInt32(jsonobj.user_info.mre);
                part = Convert.ToInt32(jsonobj.user_info.part);
                core = Convert.ToInt32(jsonobj.user_info.core);
                coin1 = Convert.ToInt32(jsonobj.user_info.coin1);
                coin2 = Convert.ToInt32(jsonobj.user_info.coin2);
                coin3 = Convert.ToInt32(jsonobj.user_info.coin3);


                growthfond = Convert.ToInt32(jsonobj.user_info.growthfond);
                last_recover_time = Convert.ToInt32(jsonobj.user_info.last_recover_time);
                last_bp_recover_time = Convert.ToInt32(jsonobj.user_info.last_bp_recover_time);
                last_favor_recover_time = Convert.ToInt32(jsonobj.user_info.last_favor_recover_time);



                last_login_time = Convert.ToInt32(jsonobj.user_info.last_login_time);
                reg_time = Convert.ToInt32(jsonobj.user_info.reg_time);


                foreach (var item in jsonobj.user_info.gun_collect.Split(','))
                {
                    if (String.IsNullOrEmpty(item)) continue;
                    gun_collect.Add(Convert.ToInt32(item));
                }
                last_dorm_material_change_time1 = Convert.ToInt32(jsonobj.user_info.last_dorm_material_change_time1);
                last_dorm_material_change_time2 = Convert.ToInt32(jsonobj.user_info.last_dorm_material_change_time2);
                material_available_num1 = Convert.ToInt32(jsonobj.user_info.material_available_num1);
                material_available_num2 = Convert.ToInt32(jsonobj.user_info.material_available_num2);
                dorm_max_score = Convert.ToInt32(jsonobj.user_info.dorm_max_score);

            }
            catch (Exception e)
            {
                new Log().systemInit("读取UserData_user_info遇到错误", e.ToString()).coreError();
                return false;
            }
            return true;
        }

        public int GetSimulationType()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(1, coin1);
            dict.Add(2, coin2);
            dict.Add(3, coin3);
            return dict.Keys.Select(x => new { x, y = dict[x] }).OrderBy(x => x.y).First().x;
        }

        public int id;
        public int user_id;
        public string open_id;
        public string channel_id;
        public string sign;
        public string name;
        public int gem;
        public int pause_turn_chance;
        public int lv;
        public int maxequip;

        public int experience;

        public int maxgun;
        public int maxteam;
        public int max_build_slot;
        public int max_equip_build_slot;
        public int max_fix_slot;
        public int max_upgrade_slot;
        public int max_gun_preset;
        public int max_fairy;
        public int maxdorm;
        public int bp;

        public int bp_pay;
        public int mp;
        public int ammo;
        public int mre;
        public int part;
        public int core;
        public int coin1;
        public int coin2;
        public int coin3;
        public int monthlycard1_end_time;
        public int monthlycard2_end_time;

        public int growthfond;
        public int last_recover_time;
        public int last_bp_recover_time;
        public int last_favor_recover_time;
        public int last_monthlycard1_recover_time;
        public int last_monthlycard2_recover_time;
        public int last_login_time;
        public int reg_time;

        public List<int> gun_collect = new List<int>();

        public int last_dorm_material_change_time1;
        public int last_dorm_material_change_time2;
        public int material_available_num1;//这是电池
        public int material_available_num2;
        public int dorm_max_score;
    }
}

using GFHelp.Core.CatchData.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GFHelp.Core.MulitePlayerData
{
    public class Equip_With_User_Info
    {
        public bool Read(dynamic jsonobj)
        {
            dicEquip.Clear();
            foreach (var item in jsonobj.equip_with_user_info)
            {
                Equip_With_User_Info ewui = new Equip_With_User_Info();
                try
                {
                    ewui.id = Convert.ToInt32(item.Value.id);
                    ewui.user_id = Convert.ToInt32(item.Value.user_id);
                    ewui.gun_with_user_id = Convert.ToInt32(item.Value.gun_with_user_id);
                    ewui.equip_id = Convert.ToInt32(item.Value.equip_id);
                    ewui.equip_exp = Convert.ToInt32(item.Value.equip_exp);
                    ewui.equip_level = Convert.ToInt32(item.Value.equip_level);
                    ewui.pow = Convert.ToInt32(item.Value.pow);
                    ewui.hit = Convert.ToInt32(item.Value.hit);
                    ewui.dodge = Convert.ToInt32(item.Value.dodge);
                    ewui.speed = Convert.ToInt32(item.Value.speed);
                    ewui.rate = Convert.ToInt32(item.Value.rate);
                    ewui.critical_harm_rate = Convert.ToInt32(item.Value.critical_harm_rate);
                    ewui.critical_percent = Convert.ToInt32(item.Value.critical_percent);
                    ewui.armor_piercing = Convert.ToInt32(item.Value.armor_piercing);
                    ewui.armor = Convert.ToInt32(item.Value.armor);
                    ewui.shield = Convert.ToInt32(item.Value.shield);
                    ewui.damage_amplify = Convert.ToInt32(item.Value.damage_amplify);
                    ewui.damage_reduction = Convert.ToInt32(item.Value.damage_reduction);
                    ewui.night_view_percent = Convert.ToInt32(item.Value.night_view_percent);

                    ewui.bullet_number_up = Convert.ToInt32(item.Value.bullet_number_up);
                    ewui.adjust_count = Convert.ToInt32(item.Value.adjust_count);
                    ewui.is_locked = Convert.ToInt32(item.Value.is_locked);
                    ewui.last_adjust = item.Value.last_adjust.ToString();
                    foreach (var x in CatachData.equip_info)
                    {
                        if (x.Value.id == Convert.ToInt32(item.Value.equip_id)) ewui.info = x.Value;
                    }
                }
                catch (Exception e)
                {
                    SysteOthers.Log log = new SysteOthers.Log(1, "读取UserData_equip_with_user_info", e.ToString());
                    SysteOthers.Viewer.Logs.Add(log);
                    continue;
                }
                dicEquip.Add(dicEquip.Count, ewui);
            }
            return true;
        }

        public void Read_Equipment_Rank()
        {
            Rank2.Clear();
            Rank3.Clear();
            Rank4.Clear();
            Rank5.Clear();
            foreach (var item in dicEquip)
            {
                //item.Value.equip_id用id 索引 catchdata的id 得到 5级
                if (CatachData.equip_info[item.Value.equip_id - 1].rank == 5)
                {
                    Equip_With_User_Info ewui_rank5 = new Equip_With_User_Info();
                    ewui_rank5 = item.Value;
                    Rank5.Add(Rank5.Count, ewui_rank5);
                }

                //item.Value.equip_id用id 索引 catchdata的id 得到 4级
                if (CatachData.equip_info[item.Value.equip_id - 1].rank == 4)
                {
                    Equip_With_User_Info ewui_rank4 = new Equip_With_User_Info();
                    ewui_rank4 = item.Value;
                    Rank4.Add(Rank4.Count, ewui_rank4);
                }

                //item.Value.equip_id用id 索引 catchdata的id 得到 3级
                if (CatachData.equip_info[item.Value.equip_id - 1].rank == 3)
                {
                    Equip_With_User_Info ewui_rank3 = new Equip_With_User_Info();
                    ewui_rank3 = item.Value;
                    Rank3.Add(Rank3.Count, ewui_rank3);
                }

                //item.Value.equip_id用id 索引 catchdata的id 得到 2级
                if (CatachData.equip_info[item.Value.equip_id - 1].rank == 2)
                {
                    Equip_With_User_Info ewui_rank2 = new Equip_With_User_Info();
                    ewui_rank2 = item.Value;
                    Rank2.Add(Rank2.Count, ewui_rank2);
                }
            }
        }

        /// <summary>
        /// 获取需要升级的装备
        /// </summary>
        public void Read_Equipment_Upgrade()
        {
            dicUpgrade.Clear();

            foreach (var item in Rank5)
            {
                //5级装备等级小于10 没有被人形装备
                if (item.Value.equip_id == 16) continue;
                if (item.Value.equip_id == 59) continue;
                if (item.Value.equip_level < 10 && item.Value.gun_with_user_id == 0)
                {
                    Equip_With_User_Info ewui_upgrade = new Equip_With_User_Info();
                    ewui_upgrade = item.Value;
                    dicUpgrade.Add(dicUpgrade.Count, ewui_upgrade);
                }
            }
        }

        public List<int> Get_Equipment_Food()
        {
            //string[] strFood =new string[24];
            List<int> list = new List<int>();

            foreach (var item in Rank2)
            {
                if (list.Count >= 24) return list;
                if (item.Value.gun_with_user_id == 0)
                {
                    list.Add(int.Parse(item.Value.id.ToString()));
                }
            }

            foreach (var item in Rank3)
            {
                if (list.Count >= 24) return list;
                if (item.Value.gun_with_user_id == 0)
                {
                    list.Add(int.Parse(item.Value.id.ToString()));
                }
            }

            foreach (var item in Rank4)
            {
                if (list.Count >= 24) return list;
                if (item.Value.gun_with_user_id == 0)
                {
                    list.Add(int.Parse(item.Value.id.ToString()));
                }
            }
            return list;

        }

        /// <summary>
        /// 升级装备后删除对应的表
        /// </summary>
        /// <param name="res"></param>
        public void Del_Equip_IN_Dict(List<int> res)
        {
            foreach (var item0 in res)
            {

                for (int i = 0; i < dicEquip.Last().Key; i++)
                {
                    if (dicEquip.ContainsKey(i))
                    {
                        if (Convert.ToInt32(item0) == dicEquip[i].id)
                        {
                            dicEquip.Remove(i);
                        }
                    }
                }
            }
        }

        public void Check_Equipment_Update(int id, int exp)
        {

            int key = -1;

            //当前装备的经验值
            foreach (var item in dicEquip)
            {
                if (item.Value.id == id)
                {
                    key = item.Key;
                    break;
                }
            }

            //开始比较 分别是需要升级或者不需要升级
            dicEquip[key].equip_level += dicEquip[key].GetLevelToBeAdded(exp);
            dicEquip[key].equip_exp += exp;

            //10级处理
            if (dicEquip[key].equip_level == 10)
            {
                //10级处理
            }


        }



        public Dictionary<int, Equip_With_User_Info> dicEquip = new Dictionary<int, Equip_With_User_Info>();
        public Dictionary<int, Equip_With_User_Info> Rank2 = new Dictionary<int, Equip_With_User_Info>();
        public Dictionary<int, Equip_With_User_Info> Rank3 = new Dictionary<int, Equip_With_User_Info>();
        public Dictionary<int, Equip_With_User_Info> Rank4 = new Dictionary<int, Equip_With_User_Info>();
        public Dictionary<int, Equip_With_User_Info> Rank5 = new Dictionary<int, Equip_With_User_Info>();
        public Dictionary<int, Equip_With_User_Info> dicUpgrade = new Dictionary<int, Equip_With_User_Info>();
        public int id;
        public int user_id;
        public int gun_with_user_id;
        public int equip_id;
        public int equip_exp;
        public int equip_level;
        public int pow;
        public int hit;
        public int dodge;
        public int speed;
        public int rate;
        public int critical_harm_rate;
        public int critical_percent;
        public int armor_piercing;
        public int armor;
        public int shield;
        public int damage_amplify;
        public int damage_reduction;

        public int bullet_number_up;
        public int adjust_count;
        public int is_locked;
        public string last_adjust;
        // Token: 0x0400161A RID: 5658
        private int _nightResistance;
        // Token: 0x04001607 RID: 5639
        public Equip_Info info = new Equip_Info();
        // Token: 0x170005CC RID: 1484
        // (get) Token: 0x060017B2 RID: 6066 RVA: 0x0007B6B0 File Offset: 0x000798B0
        // (set) Token: 0x060017B1 RID: 6065 RVA: 0x0007B6A4 File Offset: 0x000798A4
        public int nightResistance
        {
            get
            {
                return this.GetBounsProperty("night_view_percent", this._nightResistance);
            }
            set
            {
                this._nightResistance = value;
            }
        }
        // Token: 0x060017BA RID: 6074 RVA: 0x0007B71C File Offset: 0x0007991C
        private int GetBounsProperty(string type, int value)
        {
            if (this.equip_level == 0)
            {
                return value;
            }
            string[] array = this.info.strBounsType.Split(new char[]
            {
            ','
            });
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string text = array2[i];
                string[] array3 = text.Split(new char[]
                {
                ':'
                });
                if (array3[0].Equals(type))
                {
                    float num = (float)int.Parse(array3[1]) / 100f;
                    float num2 = 1f + (float)this.equip_level * num;
                    return Mathf.FloorToInt((float)value * num2);
                }
            }
            return value;
        }
        public int night_view_percent;




        /// <summary>
        /// 传入一个exp,返回升了多少级
        /// </summary>
        /// <param name="expAdded"></param>
        /// <returns></returns>
        public int GetLevelToBeAdded(int expAdded)
        {
            int i = expAdded + GetCurrentLevelExp();
            int num = equip_level + 1;
            int num2 = 0;
            while (i >= 0)
            {
                i -= CalculateExpToNextLevel(num);
                num++;
                if (i >= 0)
                {
                    num2++;
                }
            }
            return num2;
        }
        public int GetCurrentLevelExp()
        {
            return this.equip_exp - this.GetTotalExpToLevel(this.equip_level);
        }

        public int CalculateExpToNextLevel(int nextLevel)
        {
            int num;
            if (nextLevel > 1)
            {
                if (nextLevel - 1 < CatachData.equip_exp_info.Count)
                {
                    num = CatachData.equip_exp_info[nextLevel] - CatachData.equip_exp_info[nextLevel - 1];
                }
                else
                {
                    num = 99999;
                }
            }
            else if (nextLevel == 1)
            {
                num = CatachData.equip_exp_info[nextLevel];
            }
            else
            {
                num = 0;
            }
            float equipLevelUpRate = Game_Config_Info_Func.GetEquipLevelUpRate((int)this.info.rank);
            float exclusiveRate = this.info.exclusive_rate;
            return Mathf.CeilToInt((float)num * equipLevelUpRate * exclusiveRate);
        }

        // Token: 0x060017C1 RID: 6081 RVA: 0x0007BC30 File Offset: 0x00079E30
        public int GetTotalExpToLevel(int level)
        {
            int num;
            if (level >= 1)
            {
                num = CatachData.equip_exp_info[level];
            }
            else
            {
                num = 0;
            }
            float equipLevelUpRate = Game_Config_Info_Func.GetEquipLevelUpRate(this.info.rank);
            return Mathf.CeilToInt((float)num * equipLevelUpRate * this.info.exclusive_rate);
        }


    }
}

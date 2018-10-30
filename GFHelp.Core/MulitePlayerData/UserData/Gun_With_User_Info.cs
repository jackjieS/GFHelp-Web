using GFHelp.Core.CatchData.Base;
using GFHelp.Core.Helper;
using GFHelp.Core.MulitePlayerData;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GFHelp.Core.MulitePlayerData
{
    public class Gun_With_User_Info
    {
        public void Read(JsonData jsonobj)
        {
            JsonData jsonData17 = jsonobj["gun_with_user_info"];
            dicGun.Clear();
            for (int num9 = 0; num9 < jsonData17.Count; num9++)
            {
                JsonData jsonGun = jsonData17[num9];
                Gun_With_User_Info gwui = new Gun_With_User_Info();
                try
                {
                    gwui.id = jsonGun["id"].Int;
                    if (jsonGun.Contains("user_id"))
                    {
                        gwui.user_id = jsonGun["user_id"].Int;
                    }

                    gwui.gun_id = jsonGun["gun_id"].Int;

                    if (jsonGun.Contains("if_modification"))
                    {
                        gwui.mod = jsonGun["if_modification"].Int;
                        //if (this.info.maxMod < this.mod)
                        //{
                        //    this.info.maxMod = this.mod;
                        //}
                    }

                    if (jsonGun.Contains("gun_exp"))
                    {
                        gwui.experience = jsonGun["gun_exp"].Int;
                    }
                    gwui._level = jsonGun["gun_level"].Int;
                    gwui.level = gwui._level;
                    if (jsonGun.Contains("team_id"))
                    {
                        gwui.teamId = jsonGun["team_id"].Int;
                    }


                    gwui.location = jsonGun["location"].Int;
                    gwui.position = jsonGun["position"].Int;
                    if (jsonGun.Contains("life"))
                    {
                        gwui.life = jsonGun["life"].Int;
                    }
                    if (jsonGun.Contains("ammo"))
                    {
                        gwui.ammo = jsonGun["ammo"].Int;
                    }
                    if (jsonGun.Contains("mre"))
                    {
                        gwui.mre = jsonGun["mre"].Int;
                    }
                    gwui.pow = Convert.ToInt32((string)jsonGun["pow"]);
                    gwui.hit = Convert.ToInt32((string)jsonGun["hit"]);
                    //gwui.additionHit = gwui.hit;
                    gwui.dodge = Convert.ToInt32((string)jsonGun["dodge"]);
                    //gwui.additionDodge = gwui.dodge;
                    gwui.rate = Convert.ToInt32((string)jsonGun["rate"]);
                    gwui.additionPow = Convert.ToInt32((string)jsonGun["pow"]);
                    gwui.additionHit = Convert.ToInt32((string)jsonGun["hit"]);
                    gwui.additionDodge = Convert.ToInt32((string)jsonGun["dodge"]);
                    gwui.additionRate = Convert.ToInt32((string)jsonGun["rate"]);
                    //gwui.info.maxAddRate = gwui.rate;
                    //gwui.skill1 = Convert.ToInt32(item.skill1);
                    //gwui.skill2 = Convert.ToInt32(item.skill2);
                    //gwui.fix_end_time = Convert.ToInt32(item.fix_end_time);
                    if (jsonGun.Contains("is_locked"))
                    {
                        gwui.isLocked = jsonGun["is_locked"].Bool;
                    }
                    gwui.number = Convert.ToInt32((string)jsonGun["number"]);
                    //gwui.equip1 = Convert.ToInt32(item.equip1);
                    //gwui.equip2 = Convert.ToInt32(item.equip2);
                    //gwui.equip3 = Convert.ToInt32(item.equip3);
                    //gwui.equip4 = Convert.ToInt32(item.equip4);
                    if (jsonGun.Contains("favor"))
                    {
                        gwui.favor = jsonGun["favor"].Int;
                    }
                    //gwui.max_favor = Convert.ToInt32(item.max_favor);
                    //gwui.favor_toplimit = Convert.ToInt32(item.favor_toplimit);
                    gwui.soul_bond = jsonGun["soul_bond"].Bool;
                    gwui.soulBondTime = jsonGun["soul_bond_time"].Int;
                    gwui.skin = jsonGun["skin"].Int;
                    if (jsonGun.Contains("can_click"))
                    {
                        gwui.canClick = jsonGun["can_click"].Int;
                    }
                    gwui.info = GameData.listGunInfo.GetDataById((long)jsonGun["gun_id"].Int);
                    gwui.UpdateData();
                    //gwui.crit = Convert.ToInt32(item.crit);
                    //gwui.piercing = Convert.ToInt32(item.piercing);
                    //gwui.maxLife = Convert.ToInt32(item.maxLife);
                    //gwui.bulletNumber = Convert.ToInt32(item.bulletNumber);
                    //float.TryParse(item.nightResistance, out gwui.nightResistance);
                    //gwui.fairyPow = Convert.ToInt32(item.fairyPow);
                    //gwui.fairyHit = Convert.ToInt32(item.fairyHit);
                    //gwui.fairyDodge = Convert.ToInt32(item.fairyDodge);
                    //gwui.fairyArmor = Convert.ToInt32(item.fairyArmor);
                    //gwui.criHarmRate = Convert.ToInt32(item.criHarmRate);

                }
                catch (Exception e)
                {
                    new Log().systemInit("读取UserData_gun_with_user_info遇到错误", e.ToString()).coreError();
                    gwui.gun_id = 1;
                    gwui.info = GameData.listGunInfo.GetDataById((long)jsonGun["gun_id"].Int);
                    gwui.UpdateData();
                    continue;

                }
                finally
                {
                    int i = 0;
                    while (true)
                    {
                        if (!dicGun.ContainsKey(i))
                        {
                            dicGun.Add(i, gwui);
                            break;
                        }
                        i++;
                    }
                }

            }
        }

        /// <summary>
        /// 获取要扩编的人形字典
        /// </summary>
        public void Get_dicGun_Combine(int teamID=-1)
        {
            dicGun_Combine.Clear();
            foreach (var item in dicGun)
            {
                if (item.Value.teamId != teamID) continue;
                //2扩
                if (item.Value.level >= 10 && item.Value.level < 30)
                {
                    if (item.Value.number < 2)
                    {
                        dicGun_Combine.Add(item.Value);
                    }

                }
                //3扩
                if (item.Value.level >= 30 && item.Value.level < 70)
                {
                    if (item.Value.number < 3)
                    {
                        dicGun_Combine.Add(item.Value);
                    }

                }
                //4扩
                if (item.Value.level >= 70 && item.Value.level < 90)
                {
                    if (item.Value.number < 4)
                    {
                        dicGun_Combine.Add(item.Value);
                    }

                }
                //5扩
                if (item.Value.level >= 90 && item.Value.level <= 100)
                {
                    if (item.Value.number < 5)
                    {
                        dicGun_Combine.Add(item.Value);
                    }

                }
            }

            dicGun_Combine = dicGun_Combine.OrderBy(o => o.number).ToList();

        }



        /// <summary>
        /// 返回false 表示没有2级枪了
        /// </summary>
        /// <returns></returns>
        public bool Get_Gun_Retire()
        {
            Rank2.Clear();
            Rank3.Clear();
            foreach (var item in dicGun)
            {

                if (item.Value.info.rank == 2 && item.Value.isLocked == false && item.Value.teamId == 0 && item.Value.level<=10)
                {
                    Rank2.Add(item.Value.id);
                    if (Rank2.Count >= 24) break;
                }
            }
            foreach (var item in dicGun)
            {
                if (item.Value.gun_id == 120) continue;
                if (item.Value.info.rank == 3 && item.Value.isLocked == false && item.Value.teamId == 0 && item.Value.level <= 10)
                {
                    Rank3.Add(item.Value.id);
                    if (Rank3.Count >= 24) break;
                }
            }


            if (Rank2.Count > 0 || Rank3.Count > 0) return true;
            return false;
        }

        /// <summary>
        /// 删除退休人形gun_with_user_info
        /// </summary>
        public void Del_Gun_IN_Dict(int type)
        {
            for (int i = 0; i <= dicGun.Last().Key; i++)
            {
                if (dicGun.ContainsKey(i))
                {
                    switch (type)
                    {
                        case 2:
                            {
                                foreach (var x in Rank2)
                                {
                                    if (dicGun[i].id == x)
                                    {
                                        dicGun.Remove(i);
                                        break;
                                    }
                                }

                                break;
                            }

                        case 3:
                            {
                                foreach (var y in Rank3)
                                {
                                    if (dicGun[i].id == y)
                                    {
                                        dicGun.Remove(i);
                                        break;
                                    }
                                }

                                break;
                            }
                        default:
                            break;
                    }
                }
            }
            switch (type)
            {
                case 2:
                    {
                        Rank2.Clear();
                        break;
                    }
                case 3:
                    {
                        Rank3.Clear();
                        break;
                    }
                default:
                    break;
            }


        }

        public bool UpdateGun_Exp(dynamic jsonobj, ref int numE)
        {
            try
            {
                foreach (var item in jsonobj.gun_exp)
                {

                    int exp = Convert.ToInt32(item.exp);
                    int id = Convert.ToInt32(item.gun_with_user_id);

                    for (int i = 0; i <= dicGun.Last().Key + 1; i++)
                    {
                        if (dicGun.ContainsKey(i) == false) continue;
                        if (dicGun[i].id == id)
                        {
                            dicGun[i].experience += exp;
                            dicGun[i].level = GameData.ExpToLevel(dicGun[i].experience, false);
                        }
                    }
                }


                return true;

            }
            catch (Exception e)
            {
                new Log().systemInit("读取UserData_gun_with_user_info遇到错误", e.ToString()).coreError();
                return false;
            }
        }

        public int getCoreNumber()
        {
            if (info.rank == 3) return 1;
            if (info.rank == 4) return 3;
            if (info.rank == 5) return 5;
            return 0;
        }


        public void dicGunAdd(Gun_With_User_Info gwui)
        {
            int i = 0;
            while (true)
            {
                if (!dicGun.ContainsKey(i))
                {
                    dicGun.Add(i, gwui);
                    break;
                }
                i++;
            }
        }

        public Dictionary<int, Gun_With_User_Info> dicGun = new Dictionary<int, Gun_With_User_Info>();//所有的枪
        public List<Gun_With_User_Info> dicGun_Combine = new List<Gun_With_User_Info>();
        public List<Gun_With_User_Info> dicGun_PowerUP = new List<Gun_With_User_Info>();
        public List<int> Rank2 = new List<int>();
        public List<int> Rank3 = new List<int>();
        public int id;//这个是与user有关的id 通常是6位数
        public int user_id;
        public int gun_id;//这是是2位数
        public int experience
        {
            get
            {
                return this._exp;
            }
            set
            {
                this._exp = global::Mathf.Min(new int[]
                {
                    GameData.LevelToSumExp(this.levelUpperLimit - 1, false),
                    value
                });
                this.level = GameData.ExpToLevel(this._exp, false);
            }
        }
        public int levelUpperLimit
        {
            get
            {
                return CatchData.Base.Data.GunLevelUpperLimit(this.mod);
            }
        }
        private int _exp;
        public int mod;
        public int gun_level;

        public int teamId;
        public int if_modification;
        public int location;
        public int position;
        public int life;
        public int ammo;
        public int mre;
        public int pow;
        public int hit;
        public int dodge;
        public int rate;
        public int skill1;
        public int skill2;
        public int fix_end_time;
        public bool isLocked;
        public int number;
        public int equip1;
        public int equip2;
        public int equip3;
        public int equip4;
        public int favor;
        public int max_favor;
        public int favor_toplimit;
        public bool soul_bond;
        public int soulBondTime;
        public int skin;
        public int canClick;
        public int level;
        public int crit;
        public int piercing;
        public int maxLife;
        public int bulletNumber;
        public int armor;
        public float nightResistance;

        public int fairyPow;
        public int fairyHit;
        public int fairyDodge;
        public int fairyArmor;

        public int criHarmRate;

        public Gun_Info info = new Gun_Info();

        public int gunEffect = 0;

        public float powbuffTemp = 1f;

        // Token: 0x040017BE RID: 6078
        public float hitbuffTemp = 1f;

        // Token: 0x040017BF RID: 6079
        public float dodgebuffTemp = 1f;

        // Token: 0x040017C0 RID: 6080
        public float armorbuffTemp = 1f;

        // Token: 0x040017C1 RID: 6081
        public float critbuffTemp = 1f;

        // Token: 0x040017C2 RID: 6082
        public float harmratebuffTemp = 1f;

        public int _level;
        public int basePow;
        // Token: 0x04001788 RID: 6024
        public int maxAddPow;
        // Token: 0x0400178B RID: 6027
        public int favorPow;
        public int additionPow;
        public int current_Maxlife;
        // Token: 0x04001782 RID: 6018
        public List<Equip> equipList = new List<Equip>();
        // Token: 0x170005F2 RID: 1522
        // (get) Token: 0x06001880 RID: 6272 RVA: 0x0008551C File Offset: 0x0008371C
        //Fairy fairy
        //{
        //    get
        //    {
        //        if (this.teamId != 0 && im.userdatasummery.dictTeamFairy != null && im.userdatasummery.dictTeamFairy.ContainsKey(this.teamId))
        //        {
        //            return im.userdatasummery.dictTeamFairy[this.teamId];
        //        }
        //        return null;
        //    }
        //}
        public int baseRate;
        public int maxAddRate;
        public int additionRate;
        public int baseHit;
        // Token: 0x0400178F RID: 6031
        public int maxAddHit;
        // Token: 0x04001797 RID: 6039
        public int baseDodge;
        public int maxAddDodge;
        // Token: 0x04001798 RID: 6040
        public int favorDodge;
        public int favorHit;
        // Token: 0x0400179D RID: 6045
        public int fairyCriHarmRate;
        public int speed;
        public int additionHit;
        public int additionDodge;
        public int equipAp;
        public int[] arrEffectGridBuff = new int[8];


        public int Core_COMbineNeed
        {
            get
            {
                switch (info.rank)
                {
                    case 2:
                        {
                            if (number == 1) return 1;
                            if (number == 2) return 1;
                            if (number == 3) return 2;
                            if (number == 4) return 3;
                            return 0;
                        }
                    case 3:
                        {
                            if (number == 1) return 3;
                            if (number == 2) return 3;
                            if (number == 3) return 6;
                            if (number == 4) return 9;
                            return 0;
                        }
                    case 4:
                        {
                            if (number == 1) return 9;
                            if (number == 2) return 9;
                            if (number == 3) return 18;
                            if (number == 4) return 27;
                            return 0;
                        }
                    case 5:
                        {
                            if (number == 1) return 15;
                            if (number == 2) return 15;
                            if (number == 3) return 30;
                            if (number == 4) return 45;
                            return 0;
                        }
                    default:
                        return 0;
                }
            }
        }

        //public virtual int GetPoint(bool fullLife = false, bool basePoint = false, bool isNight = false, SubGunType subGunType = SubGunType.None)
        //{
        //    return this.GetAtkPoint(isNight, fullLife, basePoint, subGunType) + this.GetSurPoint(fullLife, basePoint, subGunType) + this.GetSkill1Point(fullLife, basePoint, subGunType);
        //}

        //public int GetAtkPoint(bool isNight, bool isFullLife, bool basePoint, SubGunType subGunType = SubGunType.None, bool countFairy = true)
        //{
        //    int num = this.pow;
        //    int num2 = this.rate;
        //    int num3 = this.hit;
        //    int num4 = this.dodge;
        //    int num5 = this.crit;
        //    int num6 = this.armor;
        //    int num7 = this.piercing;//穿甲
        //    if (!countFairy)//妖精
        //    {
        //        num -= this.fairyPow;
        //        num3 -= this.fairyHit;
        //        num4 -= this.fairyDodge;
        //        num6 -= this.fairyArmor;
        //    }
        //    if (!basePoint)
        //    {
        //        num = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("pow"), (float)num * this.GetEffectGridValue(EffectGridType.pow, subGunType) * this.powbuffTemp));
        //        num2 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("rate"), (float)num2 * this.GetEffectGridValue(EffectGridType.rate, subGunType)));
        //        num3 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("hit"), (float)num3 * this.GetEffectGridValue(EffectGridType.hit, subGunType) * this.hitbuffTemp));
        //        num4 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("dodge"), (float)num4 * this.GetEffectGridValue(EffectGridType.dodge, subGunType) * this.dodgebuffTemp));
        //        num5 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("critical_percent"), (float)num5 * this.GetEffectGridValue(EffectGridType.crit, subGunType) * this.critbuffTemp));
        //        num6 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("armor"), (float)num6 * this.GetEffectGridValue(EffectGridType.armor, subGunType) * this.armorbuffTemp));
        //        num7 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("armor_piercing"), (float)num7 * this.GetEffectGridValue(EffectGridType.ap, subGunType)));
        //        float effectGridValue = this.GetEffectGridValue(EffectGridType.skill, subGunType);
        //    }
        //    int num8 = this.life;
        //    if (isFullLife)
        //    {
        //        num8 = this.maxLife;
        //    }
        //    int num9 = this.info.special + this.bulletNumber;
        //    int num10 = num3;
        //    if (isNight)
        //    {
        //        num10 = Mathf.CeilToInt((float)num3 * (1f + (float)im.catchdatasummery.Game_Config_info_Func.GetDouble("night_hit_debuff") * (1f - this.nightResistance)));
        //    }
        //    GunType type = this.info.type;
        //    int result;
        //    if (type != GunType.machinegun)
        //    {
        //        if (type != GunType.shotgun)
        //        {
        //            float floatFromStringArray = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 0, ',');
        //            float floatFromStringArray2 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 1, ',');
        //            float floatFromStringArray3 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 2, ',');
        //            float floatFromStringArray4 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 3, ',');
        //            float floatFromStringArray5 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 4, ',');
        //            float floatFromStringArray6 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 5, ',');
        //            result = Mathf.CeilToInt(floatFromStringArray * Mathf.Ceil((float)num8 / (float)this.maxLife * (float)this.number) * (((float)num + (float)num7 / floatFromStringArray6) * ((float)this.criHarmRate / 100f * (float)num5 / 100f + 1f) * (float)num2 / floatFromStringArray5 * (float)num10 / ((float)num10 + floatFromStringArray3) + floatFromStringArray4));
        //        }
        //        else
        //        {
        //            float floatFromStringArray = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 0, ',');
        //            float floatFromStringArray2 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 1, ',');
        //            float floatFromStringArray3 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 2, ',');
        //            float floatFromStringArray4 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 3, ',');
        //            float floatFromStringArray5 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 4, ',');
        //            float floatFromStringArray6 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 5, ',');
        //            float floatFromStringArray7 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 6, ',');
        //            float floatFromStringArray8 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 7, ',');
        //            float floatFromStringArray9 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 8, ',');
        //            result = Mathf.CeilToInt(floatFromStringArray * Mathf.Ceil((float)num8 / (float)this.maxLife * (float)this.number) * (floatFromStringArray7 * (float)num9 * ((float)num + (float)num7 / floatFromStringArray6) * ((float)this.criHarmRate / 100f * (float)num5 / 100f + 1f) / ((float)num9 * floatFromStringArray5 / (float)num2 + floatFromStringArray8 + floatFromStringArray9 * (float)num9) * (float)num10 / ((float)num10 + floatFromStringArray3) + floatFromStringArray4));
        //        }
        //    }
        //    else
        //    {
        //        float floatFromStringArray = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 0, ',');
        //        float floatFromStringArray2 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 1, ',');
        //        float floatFromStringArray3 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 2, ',');
        //        float floatFromStringArray4 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 3, ',');
        //        float floatFromStringArray5 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 4, ',');
        //        float floatFromStringArray6 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 5, ',');
        //        float floatFromStringArray7 = Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 6, ',');
        //        result = Mathf.CeilToInt(floatFromStringArray * Mathf.Ceil((float)num8 / (float)this.maxLife * (float)this.number) * ((float)num9 * ((float)num + (float)num7 / floatFromStringArray7) * ((float)this.criHarmRate / 100f * (float)num5 / 100f + 1f) / ((float)num9 / 3f + floatFromStringArray3 + floatFromStringArray4 / (float)num2) * (float)num10 / ((float)num10 + floatFromStringArray5) + floatFromStringArray6));
        //    }
        //    return result;
        //}




        // Token: 0x06001638 RID: 5688 RVA: 0x00072A9C File Offset: 0x00070C9C
        //public int GetSurPoint(bool isFullLife, bool basePoint, SubGunType subGunType = SubGunType.None)
        //{
        //    int num4;
        //    int num6;
        //    if (basePoint)
        //    {
        //        int num = this.pow;
        //        int num2 = this.rate;
        //        int num3 = this.hit;
        //        num4 = this.dodge;
        //        int num5 = this.crit;
        //        num6 = this.armor;
        //        int num7 = this.piercing;
        //    }
        //    else
        //    {
        //        int num = Mathf.CeilToInt((float)this.pow * this.GetEffectGridValue(EffectGridType.pow, subGunType));
        //        int num2 = Mathf.CeilToInt((float)this.rate * this.GetEffectGridValue(EffectGridType.rate, subGunType));
        //        int num3 = Mathf.CeilToInt((float)this.hit * this.GetEffectGridValue(EffectGridType.hit, subGunType));
        //        num4 = Mathf.CeilToInt((float)this.dodge * this.GetEffectGridValue(EffectGridType.dodge, subGunType));
        //        int num5 = Mathf.CeilToInt((float)this.crit * this.GetEffectGridValue(EffectGridType.crit, subGunType));
        //        num6 = Mathf.CeilToInt((float)this.armor * this.GetEffectGridValue(EffectGridType.armor, subGunType));
        //        int num7 = Mathf.CeilToInt((float)this.piercing * this.GetEffectGridValue(EffectGridType.ap, subGunType));
        //        float effectGridValue = this.GetEffectGridValue(EffectGridType.skill, subGunType);
        //    }
        //    int num8 = this.life;
        //    if (isFullLife)
        //    {
        //        num8 = this.maxLife;
        //    }

        //    float floatFromStringArray = Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 0, ',');
        //    float floatFromStringArray2 = Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 1, ',');
        //    float floatFromStringArray3 = Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 2, ',');
        //    float floatFromStringArray4 = Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 3, ',');
        //    float floatFromStringArray5 = Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 4, ',');
        //    float floatFromStringArray6 = Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 5, ',');
        //    return (int)(floatFromStringArray * (float)Mathf.CeilToInt((float)num8 * ((floatFromStringArray2 + (float)num4) / floatFromStringArray2) * (floatFromStringArray3 * floatFromStringArray4 / Mathf.Max(floatFromStringArray4 - (float)num6 / floatFromStringArray6, 1f) - floatFromStringArray5)));
        //}

        //public int GetSkill1Point(bool isFullLife, bool basePoint, SubGunType subGunType = SubGunType.None)
        //{
        //    float num;
        //    if (basePoint)
        //    {
        //        num = 1f;
        //    }
        //    else
        //    {
        //        num = this.GetEffectGridValue(EffectGridType.skill, subGunType);
        //    }
        //    int num2 = this.life;
        //    if (isFullLife)
        //    {
        //        num2 = this.maxLife;
        //    }


        //    float floatFromStringArray = Game_Config_Info_Func.GetFloatFromStringArray("skill_effect", 0, ',');
        //    float floatFromStringArray2 = Game_Config_Info_Func.GetFloatFromStringArray("skill_effect", 1, ',');
        //    int level = this.GetSkill(enumSkill.eSkill1).level;
        //    return Mathf.CeilToInt(Mathf.Ceil((float)num2 / (float)this.maxLife * (float)this.number) * (0.8f + (float)this.info.rank / 10f) * (floatFromStringArray + floatFromStringArray2 * (float)(level - 1)) * (float)Mathf.CeilToInt((float)level / 10f) * num);
        //}

        //public float GetEffectGridValue(EffectGridType type, SubGunType subGunType = SubGunType.None)
        //{
        //    if (subGunType != SubGunType.None)
        //    {
        //        //猜测是特典枪
        //        //if (subGunType == SubGunType.Simultor)
        //        //{
        //        //    return 1f + (float)((ExGun)this).GetArrEffcetGridBuff(subGunType)[type - EffectGridType.pow] / 100f;
        //        //}
        //    }
        //    return 1f + (float)this.arrEffectGridBuff[type - EffectGridType.pow] / 100f;
        //}

        //public Skill GetSkill(enumSkill e)
        //{
        //    return (this.mVecSkill.Count <= (int)e) ? this.mVecSkill[0] : this.mVecSkill[(int)e];
        //}



        public void UpdateData()
        {
            foreach (var item in GameData.listGunInfo)
            {
                if (gun_id == item.id)
                {
                    this.info = item;
                    break;
                }
            }

            float num = (this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("life_basic", 0, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("life_basic_after100", 0, ',');
            float num2 = (this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("life_basic", 1, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("life_basic_after100", 1, ',');
            float num3 = (this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("life_basic", 2, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("life_basic_after100", 2, ',');
            this.maxLife = global::Mathf.CeilToInt((num + ((float)this.level - 1f) * num2) * CatchData.Base.Data.GetGunBasicAttribute(this.info.type, "basic_attribute_life") * (float)this.info.ratio_life / num3) * this.number;
            num = CatchData.Base.Data.GetDataFromStringArray<float>("power_basic", 0, ',');
            num2 = CatchData.Base.Data.GetDataFromStringArray<float>("power_basic", 1, ',');
            this.basePow = global::Mathf.CeilToInt(num * CatchData.Base.Data.GetGunBasicAttribute(this.info.type, "basic_attribute_pow") * (float)this.info.ratio_pow / num2);
            num = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("power_grow", 0, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("power_grow_after100", 0, ','));
            num2 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("power_grow", 1, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("power_grow_after100", 1, ','));
            num3 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("power_grow", 2, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("power_grow_after100", 2, ','));
            float num4 = (this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("power_grow", 3, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("power_grow_after100", 3, ',');
            this.maxAddPow = global::Mathf.CeilToInt((num4 + (float)(this.level - 1) * num) * CatchData.Base.Data.GetGunBasicAttribute(this.info.type, "basic_attribute_pow") * (float)this.info.ratio_pow * (float)this.info.eat_ratio / num2 / num3);
            this.pow = this.basePow + this.additionPow;
            this.favorPow = Math.Sign(this.favorRatio) * Mathf.CeilToInt(global::Mathf.Abs((float)this.pow * this.favorRatio));
            this.pow += this.favorPow;



            num = CatchData.Base.Data.GetDataFromStringArray<float>("rate_basic", 0, ',');
            num2 = CatchData.Base.Data.GetDataFromStringArray<float>("rate_basic", 1, ',');
            this.baseRate = global::Mathf.CeilToInt(num * CatchData.Base.Data.GetGunBasicAttribute(this.info.type, "basic_attribute_rate") * (float)this.info.ratio_rate / num2);
            num = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("rate_grow", 0, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("rate_grow_after100", 0, ','));
            num2 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("rate_grow", 1, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("rate_grow_after100", 1, ','));
            num3 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("rate_grow", 2, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("rate_grow_after100", 2, ','));
            num4 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("rate_grow", 3, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("rate_grow_after100", 3, ','));
            this.maxAddRate = global::Mathf.CeilToInt((num4 + (float)(this.level - 1) * num) * CatchData.Base.Data.GetGunBasicAttribute(this.info.type, "basic_attribute_rate") * (float)this.info.ratio_rate * (float)this.info.eat_ratio / num2 / num3);
            this.rate = this.baseRate + this.additionRate;

            num = CatchData.Base.Data.GetDataFromStringArray<float>("hit_basic", 0, ',');
            num2 = CatchData.Base.Data.GetDataFromStringArray<float>("hit_basic", 1, ',');
            this.baseHit = global::Mathf.CeilToInt(num * CatchData.Base.Data.GetGunBasicAttribute(this.info.type, "basic_attribute_hit") * (float)this.info.ratio_hit / num2);
            num = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("hit_grow", 0, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("hit_grow_after100", 0, ','));
            num2 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("hit_grow", 1, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("hit_grow_after100", 1, ','));
            num3 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("hit_grow", 2, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("hit_grow_after100", 2, ','));
            num4 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("hit_grow", 3, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("hit_grow_after100", 3, ','));
            this.maxAddHit = global::Mathf.CeilToInt((num4 + (float)(this.level - 1) * num) * CatchData.Base.Data.GetGunBasicAttribute(this.info.type, "basic_attribute_hit") * (float)this.info.ratio_hit * (float)this.info.eat_ratio / num2 / num3);
            this.hit = this.baseHit + this.additionHit;
            this.favorHit = Math.Sign(this.favorRatio) * global::Mathf.CeilToInt(global::Mathf.Abs((float)this.hit * this.favorRatio));
            this.hit += this.favorHit;


            num = CatchData.Base.Data.GetDataFromStringArray<float>("dodge_basic", 0, ',');
            num2 = CatchData.Base.Data.GetDataFromStringArray<float>("dodge_basic", 1, ',');
            this.baseDodge = global::Mathf.CeilToInt(num * CatchData.Base.Data.GetGunBasicAttribute(this.info.type, "basic_attribute_dodge") * (float)this.info.ratio_dodge / num2);
            num = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("dodge_grow", 0, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("dodge_grow_after100", 0, ','));
            num2 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("dodge_grow", 1, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("dodge_grow_after100", 1, ','));
            num3 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("dodge_grow", 2, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("dodge_grow_after100", 2, ','));
            num4 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("dodge_grow", 3, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("dodge_grow_after100", 3, ','));
            this.maxAddDodge = global::Mathf.CeilToInt((num4 + (float)(this.level - 1) * num) * CatchData.Base.Data.GetGunBasicAttribute(this.info.type, "basic_attribute_dodge") * (float)this.info.ratio_dodge * (float)this.info.eat_ratio / num2 / num3);
            this.dodge = this.baseDodge + this.additionDodge;
            this.favorDodge = Math.Sign(this.favorRatio) * global::Mathf.CeilToInt(global::Mathf.Abs((float)this.dodge * this.favorRatio));
            this.dodge += this.favorDodge;
            int l = 0;


            num = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("armor_basic", 0, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("armor_basic_after100", 0, ','));
            num2 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("armor_basic", 1, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("armor_basic_after100", 1, ','));
            num3 = ((this.level <= 100) ? CatchData.Base.Data.GetDataFromStringArray<float>("armor_basic", 2, ',') : CatchData.Base.Data.GetDataFromStringArray<float>("armor_basic_after100", 2, ','));
            this.armor = global::Mathf.CeilToInt((num + (float)(this.level - 1) * num2) * CatchData.Base.Data.GetGunBasicAttribute(this.info.type, "basic_attribute_armor") * (float)this.info.ratio_armor / num3);
            this.crit = this.info.ratioCrit;




        }


        public float favorRatio
        {
            get
            {
                if (this.favor < 100000)
                {
                    return -0.05f;
                }
                if (this.favor < 900000)
                {
                    return 0f;
                }
                if (this.favor < 1400000)
                {
                    return 0.05f;
                }
                return 0.1f;
            }
        }

        //private List<Skill> mVecSkill = new List<Skill>();

        private bool mHasDodgeSkill;
        private bool mHasHurtSkill;



    }
}

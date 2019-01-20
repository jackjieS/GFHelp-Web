using GFHelp.Core.CatchData.Base.CMD;
using GFHelp.Core.Helper;
using GFHelp.Core.MulitePlayerData;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    class Data
    {
        public static double GetDouble(string str)
        {
            double result = 0;
            foreach (var item in CatachData.game_config_info)
            {
                if (item.Value.parameter_name == str)
                {
                    string[] a = item.Value.parameter_value[0];
                    Double.TryParse(a[0], out result);
                    return result;
                }
            }
            return result;
        }

        public static float GetEquipLevelUpRate(int rarity)
        {
            if (rarity < 1)
            {
                return 0f;
            }
            if (CatachData.equip_exp_Rate_info.Count == 0)
            {
                string[] array = GetString("equip_exp_rate").Split(new char[]
                {
                ','
                });
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string text = array2[i];
                    string text2 = text.Split(new char[]
                    {
                    ':'
                    })[0];
                    string text3 = text.Split(new char[]
                    {
                    ':'
                    })[1];
                    CatachData.equip_exp_Rate_info.Add(int.Parse(text2), float.Parse(text3));
                }
            }
            if (CatachData.equip_exp_Rate_info.ContainsKey(rarity))
            {
                return CatachData.equip_exp_Rate_info[rarity];
            }
            return 0f;
        }
        public static float GetFloatFromStringArray(string key, int id, char splitChar = ',')
        {
            float result = 0;
            foreach (var item in CatachData.game_config_info)
            {
                if (item.Value.parameter_name == key)
                {
                    result = float.Parse(item.Value.parameter_value[id][0]);
                    return result;
                }
            }
            return result;

        }

        // Token: 0x0600157C RID: 5500 RVA: 0x0009E06C File Offset: 0x0009C26C
        public static float GetGunBasicAttribute(GunType type, string key)
        {
            if (!Data.dictGunBaseAttri.ContainsKey(type))
            {
                Data.dictGunBaseAttri.Add(type, new Dictionary<string, float>());
            }
            if (!Data.dictGunBaseAttri[type].ContainsKey(key))
            {
                Data.dictGunBaseAttri[type].Add(key, (float)GameData.jsonGunType[type - GunType.handgun][key].Double);
            }
            return Data.dictGunBaseAttri[type][key];
        }


        public static void ReadInfo(JsonData jsonData)
        {
            if (!jsonData.Contains("game_config_info")) return;
            jsonData = jsonData["game_config_info"];
            Data.dictionaryIntParamter = new Dictionary<string, int>();
            Data.dictionaryStringParamter = new Dictionary<string, string>();
            Data.dictionaryFloatParamter = new Dictionary<string, float>();
            Data.dictConfigDataArray = new Dictionary<string, Dictionary<int, object>>();
            for (int i = 0; i < jsonData.Count; i++)
            {
                string @string = jsonData[i]["parameter_type"].String;
                if (@string != null)
                {
                    if (!(@string == "int"))
                    {
                        if (!(@string == "string"))
                        {
                            if (@string == "float")
                            {
                                string rawdata = jsonData[i]["parameter_value"].String;
                                Data.dictionaryFloatParamter.Add(jsonData[i]["parameter_name"].String, float.Parse(rawdata));
                            }
                        }
                        else
                        {
                            string string2 = jsonData[i]["parameter_value"].String;
                            Data.dictionaryStringParamter.Add(jsonData[i]["parameter_name"].String, string2);
                        }
                    }
                    else
                    {
                        int @int = jsonData[i]["parameter_value"].Int;
                        Data.dictionaryIntParamter.Add(jsonData[i]["parameter_name"].String, @int);
                    }
                }
            }
            if (Data.GetInt("messagelist_refresh_rate") == 0)
            {
                Data.dictionaryIntParamter.Add("messagelist_refresh_rate", 10);
            }
            if (Data.GetInt("chat_refresh_rate") == 0)
            {
                Data.dictionaryIntParamter.Add("chat_refresh_rate", 10);
            }
            if (Data.GetInt("not_certified_user") == 0)
            {
                Data.dictionaryIntParamter.Add("not_certified_user", 10800);
            }
            if (Data.GetFloat("additional_range") == 0f)
            {
                Data.dictionaryFloatParamter.Add("additional_range", 0f);
            }
        }

        public static bool GetBool(string key)
        {
            if (!Data.dictionaryIntParamter.ContainsKey(key))
            {
                new Helper.Log().systemInit("GameConfig表中缺少" + key, string.Empty).coreError();
                return false;
            }
            return Data.dictionaryIntParamter[key] == 1;
        }
        public static int GetInt(string key)
        {
            if (!Data.dictionaryIntParamter.ContainsKey(key))
            {
                new Helper.Log().systemInit("GameConfig表中缺少" + key, string.Empty).coreError();
                return 0;
            }
            return Data.dictionaryIntParamter[key];
        }
        public static float GetFloat(string key)
        {
            if (!Data.dictionaryFloatParamter.ContainsKey(key))
            {
                new Helper.Log().systemInit("GameConfig表中缺少" + key, string.Empty).coreError();
                return 0f;
            }
            return Data.dictionaryFloatParamter[key];
        }
        public static string GetString(string key)
        {
            if (!Data.dictionaryStringParamter.ContainsKey(key))
            {
                new Helper.Log().systemInit("GameConfig表中缺少" + key, string.Empty).coreError();
                return string.Empty;
            }
            return Data.dictionaryStringParamter[key];
        }
        public static float GetMinAttribute(Data.Attri attri)
        {
            if (!Data.dictMinAttribute.ContainsKey((int)attri))
            {
                Data.dictMinAttribute.Add((int)attri, (float)Convert.ToDouble(Data.GetString("min_attribute").Split(new char[]
                {
                ','
                })[(int)attri].Split(new char[]
                {
                ':'
                })[1]));
            }
            return Data.dictMinAttribute[(int)attri];
        }


        public static T GetDataFromStringArray<T>(string key, int id, char splitChar = ',')
        {
            if (!Data.dictConfigDataArray.ContainsKey(key))
            {
                Data.dictConfigDataArray.Add(key, new Dictionary<int, object>());
            }
            if (!Data.dictConfigDataArray[key].ContainsKey(id))
            {
                if (typeof(T) == typeof(int))
                {
                    Data.dictConfigDataArray[key].Add(id, Convert.ToInt32(Data.dictionaryStringParamter[key].Split(new char[]
                    {
                    splitChar
                    })[id]));
                }
                else if (typeof(T) == typeof(float))
                {
                    Data.dictConfigDataArray[key].Add(id, Convert.ToSingle(Data.dictionaryStringParamter[key].Split(new char[]
                    {
                    splitChar
                    })[id]));
                }
                else if (typeof(T) == typeof(string))
                {
                    Data.dictConfigDataArray[key].Add(id, Data.dictionaryStringParamter[key].Split(new char[]
                    {
                    splitChar
                    })[id]);
                }
                else
                {
                    Data.dictConfigDataArray[key].Add(id, Data.dictionaryStringParamter[key].Split(new char[]
                    {
                    splitChar
                    })[id]);
                }
            }
            return (T)((object)Data.dictConfigDataArray[key][id]);
        }

        // Token: 0x06001C62 RID: 7266 RVA: 0x00092EB0 File Offset: 0x000910B0
        public static int GunLevelUpperLimit(int stageNum)
        {
            return Data.GetDataFromStringArray<int>("gun_max_level", stageNum, ',');
        }

        public static int SquadCategory(int type)
        {

            int result = 0;
            if (GameData.dictSquadCategoryToType.Count == 0)
            {
                string[] array = Data.GetString("squad_type_classify").Split(new char[]
                {
                '|'
                });
                for (int i = 0; i < array.Length; i++)
                {
                    List<int> list = new List<int>();
                    string[] array2 = array[i].Split(new char[]
                    {
                    ':'
                    });
                    if (array2.Length > 1)
                    {
                        string[] array3 = array2[1].Split(new char[]
                        {
                        ','
                        });
                        for (int j = 0; j < array3.Length; j++)
                        {
                            try
                            {
                                list.Add(Convert.ToInt32(array3[j]));
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    GameData.dictSquadCategoryToType[Convert.ToInt32(array2[0])] = list;
                }

            }
            return result;
        }

        //public static float GetDataCellDailyRatio()
        //{

        //    Establish establishWithType = Data.GetEstablishWithType(EstablishType.SquadBaseScanner_502);
        //    if (establishWithType != null)
        //    {
        //        return Convert.ToSingle(establishWithType.info.parameter[0]);
        //    }
        //    return 1f;
        //}

        public static int CurrentSquadLevelExp(int level, int exp)
        {
            return exp - GameData.listSquadExp.GetDataById((long)level).exp;
        }

        public static int SquadExpToLevel(int _exp)
        {
            int num = 1;
            while (GameData.listSquadExp.ContainsKey((long)num) && _exp >= GameData.listSquadExp.GetDataById((long)num).exp)
            {
                num++;
            }
            return num - 1;
        }
        public static int GetSquadPoint(Squad_With_User_Info.Data squad, bool isAssist = true)
        {
            float num = 0f;
            float num2 = (float)squad.dictPanelAttrByAttrType[SquadAttriType.assist_def_break] * (float)squad.info.display_assist_area_coef / 100f * (float)squad.dictPanelAttrByAttrType[SquadAttriType.assist_hit] / ((float)squad.dictPanelAttrByAttrType[SquadAttriType.assist_hit] + (float)Data.GetInt("squad_dodge_coef") * Data.GetFloat("precise_coef")) * ((float)Data.GetInt("reload_coef2") + (float)squad.dictPanelAttrByAttrType[SquadAttriType.assist_reload]) / (float)Data.GetInt("reload_coef1") * (float)Data.GetInt("def_break_efficien");
            float num3 = ((float)squad.dictPanelAttrByAttrType[SquadAttriType.assist_damage] + (float)squad.info.armor_piercing / (float)Data.GetInt("assist_armor_piercing_coef")) * (float)squad.dictPanelAttrByAttrType[SquadAttriType.assist_hit] / ((float)squad.dictPanelAttrByAttrType[SquadAttriType.assist_hit] + (float)Data.GetInt("squad_dodge_coef") * Data.GetFloat("precise_coef")) * ((float)Data.GetInt("reload_coef2") + (float)squad.dictPanelAttrByAttrType[SquadAttriType.assist_reload]) / (float)Data.GetInt("reload_coef1") * (float)squad.info.display_assist_area_coef / 100f * (((float)squad.info.crit_damage / 100f - 1f) * (float)squad.info.crit_rate / 100f + 1f) * (float)Data.GetInt("assist_damage_efficien");
            float num4 = 0f;
            float num5 = (float)Data.GetInt("skill_efficien1") + (float)Data.GetInt("skill_lv_efficien1") * (float)(squad.skill1 - 1) + (float)Data.GetInt("skill_efficien1") + (float)Data.GetInt("skill_lv_efficien1") * (float)(squad.skill2 - 1) + (float)Data.GetInt("skill_efficien1") + (float)Data.GetInt("skill_lv_efficien1") * (float)(squad.skill3 - 1);
            if (isAssist)
            {
                return global::Mathf.CeilToInt(num2 + num3 + num5);
            }
            return global::Mathf.CeilToInt(num + num4 + num5);
        }

        public static int CurrentSquadLevelUpNeedExp(int level)
        {
            int count = GameData.listSquadExp.Count;
            if (level < count)
            {
                return GameData.listSquadExp.GetDataById((long)(level + 1)).exp - GameData.listSquadExp.GetDataById((long)level).exp;
            }
            return GameData.listSquadExp.GetDataById((long)level).exp;
        }

        // Token: 0x06001D93 RID: 7571 RVA: 0x000B133C File Offset: 0x000AF53C
        public static int SquadChipLevelWithExp(int exp, int rank)
        {
            if (exp <= 0)
            {
                return 0;
            }
            float num = Data.SquadChipExpCoefWithRank(rank);
            int i = 1;
            int count = GameData.listSquadChipExp.Count;
            while (i <= count)
            {
                int num2 = global::Mathf.CeilToInt((float)GameData.listSquadChipExp.GetDataById((long)i).exp * num);
                if (exp < num2)
                {
                    return i - 1;
                }
                i++;
            }
            return GameData.listSquadChipExp.Count;
        }
        // Token: 0x06001D91 RID: 7569 RVA: 0x000B121C File Offset: 0x000AF41C
        public static float SquadChipExpCoefWithRank(int rank)
        {
            string[] array = Data.GetString("squad_chip_exp_indeed_ratio").Split(new char[]
            {
            ','
            });
            for (int i = 0; i < array.Length; i++)
            {
                string[] array2 = array[i].Split(new char[]
                {
                ':'
                });
                int num;
                float result;
                if (array2.Length >= 2 && int.TryParse(array2[0], out num) && float.TryParse(array2[1], out result) && num == rank)
                {
                    return result;
                }
            }
            new Log().systemInit("squad_chip_exp_indeed_ratio格式错误").coreInfo();
            return 1f;
        }  
        // Token: 0x06001D96 RID: 7574 RVA: 0x000B1484 File Offset: 0x000AF684
        public static float SquadChipStrengthenLevelCoef(int level)
        {
            if (!GameData.listSquadChipExp.ContainsKey((long)level))
            {
                return 1f;
            }
            return (float)GameData.listSquadChipExp.GetDataById((long)level).strength_coef / 100f;
        }
        // Token: 0x06001D8F RID: 7567 RVA: 0x000B1104 File Offset: 0x000AF304
        public static SquadBaseAttribution GetSquadBasicAttribute(SquadAttriType attriType)
        {
            return GameData.listSquadBaseAttriInfo.GetDataById((long)attriType);
        }





























        public static Dictionary<string, int> dictionaryIntParamter;

        // Token: 0x04001769 RID: 5993
        private static Dictionary<string, string> dictionaryStringParamter;

        // Token: 0x0400176A RID: 5994
        private static Dictionary<string, float> dictionaryFloatParamter;

        // Token: 0x0400176B RID: 5995
        public static int night_radar_range = 0;

        // Token: 0x0400176C RID: 5996
        public static int night_hand_gun_range = 0;

        // Token: 0x0400176D RID: 5997
        private static Dictionary<int, float> dictMinAttribute = new Dictionary<int, float>();

        // Token: 0x0400176E RID: 5998
        private static Dictionary<string, Dictionary<int, object>> dictConfigDataArray = new Dictionary<string, Dictionary<int, object>>();

        // Token: 0x0400176F RID: 5999
        private static Dictionary<GunType, Dictionary<string, float>> dictGunBaseAttri = new Dictionary<GunType, Dictionary<string, float>>();

        // Token: 0x04001770 RID: 6000
        public static int lastRecoverTime = 0;

        // Token: 0x04001771 RID: 6001
        public static int lastRecoverSupportTime = 0;

        // Token: 0x04001772 RID: 6002
        private static Dictionary<int, string> _dictAchievementTypeName;


        // Token: 0x04001775 RID: 6005
        private static List<int> listCheckPointTrialId;

        // Token: 0x04001776 RID: 6006
        public static bool printLanguageId = false;

        // Token: 0x04001777 RID: 6007
        private static List<int> _listHideType;

        // Token: 0x02000341 RID: 833
        public enum Attri
        {
            // Token: 0x0400178E RID: 6030
            pow,
            // Token: 0x0400178F RID: 6031
            hit,
            // Token: 0x04001790 RID: 6032
            dodge,
            // Token: 0x04001791 RID: 6033
            speed,
            // Token: 0x04001792 RID: 6034
            rate,
            // Token: 0x04001793 RID: 6035
            critical_harm_rate,
            // Token: 0x04001794 RID: 6036
            critical_percent,
            // Token: 0x04001795 RID: 6037
            armor_piercing,
            // Token: 0x04001796 RID: 6038
            armor
        }

    }

    public class GameData
    {
        public static int LevelToSumExp(int level, bool isUser = false)
        {
            int num = 0;
            if (!isUser)
            {
                return GameData.dictLevelToSumExp[level];
            }
            while (level != 0)
            {
                num += GameData.CurrentLeveMaxExp(level--, isUser);
            }
            return num;
        }
        public static int CurrentLeveMaxExp(int level, bool isUser = false)
        {
            if (isUser)
            {
                if (level <= 25)
                {
                    return level * 100;
                }
                if (level <= 99)
                {
                    return 100 * global::Mathf.FloorToInt(global::Mathf.Pow((float)level * 0.2f, 2f));
                }
                if (level <= 199)
                {
                    return 100 * global::Mathf.FloorToInt(global::Mathf.Pow((float)level * 0.11f, 2.5f));
                }
                return 100 * global::Mathf.FloorToInt(global::Mathf.Pow((float)level * 0.0118f, 9f));
            }
            else
            {
                if (level > Data.GunLevelUpperLimit(3))
                {
                    return -1;
                }
                return GameData.dictGunUpLevelExp[level];
            }
        }

        public static Dictionary<int, List<int>> dictSquadCategoryToType = new Dictionary<int, List<int>>();
        public static Dictionary<int, int> dictGunUpLevelExp;
        public static Dictionary<int, int> dictLevelToSumExp = new Dictionary<int, int>();
        public static tBaseDatas<EquipInfo> listEquipInfo;
        public static tBaseDatas<GunInfo> listGunInfo = new tBaseDatas<GunInfo>();
        public static tBaseDatas<ItemInfo> listItemInfo = new tBaseDatas<ItemInfo>();
        public static tBaseDatas<SquadChipInfo> listSquadChipInfo = new tBaseDatas<SquadChipInfo>();
        public static tBaseDatas<SquadInfo> listSquadInfo = new tBaseDatas<SquadInfo>();
        public static tBaseDatas<SquadTypeInfo> listSquadTypeInfo = new tBaseDatas<SquadTypeInfo>();
        public static tBaseDatas<SquadRankInfo> listSquadRankInfo = new tBaseDatas<SquadRankInfo>();
        public static tBaseDatas<SquadExp> listSquadExp = new tBaseDatas<SquadExp>();
        public static tBaseDatas<SquadChipExp> listSquadChipExp = new tBaseDatas<SquadChipExp>();
        public static tBaseDatas<SquadDailyQuestInfo> listSquadDailyQuestInfo = new tBaseDatas<SquadDailyQuestInfo>();
        public static tBaseDatas<BattleSkillCfg> listBTSkillCfg = new tBaseDatas<BattleSkillCfg>();
        public static tBaseDatas<SquadBaseAttribution> listSquadBaseAttriInfo = new tBaseDatas<SquadBaseAttribution>();
        public static tBaseDatas<SquadAdvancedBonus> listSquadAdvancedBonus = new tBaseDatas<SquadAdvancedBonus>();
        public static tBaseDatas<SquadCPUInfo> listSquadCPUInfo = new tBaseDatas<SquadCPUInfo>();
        public static tBaseDatas<SquadCPUColor> listSquadCPUColor = new tBaseDatas<SquadCPUColor>();
        public static tBaseDatas<SquadCPUGrid> listSquadCPUGrid = new tBaseDatas<SquadCPUGrid>();
        public static tBaseDatas<SquadCPUCompletion> listSquadCPUCompletion = new tBaseDatas<SquadCPUCompletion>();
        public static JsonData jsonGunType;






        public static Dictionary<int, int> dictEquipmentExpInfo;
        public static int ExpToLevel(int exp, bool isUser = false)
        {
            if (isUser)
            {
                int num = 0;
                while ((exp -= GameData.CurrentLeveMaxExp(++num, isUser)) >= 0)
                {
                }
                return num;
            }
            int i = 0;
            int count = GameData.dictLevelToSumExp.Count;
            while (i < count)
            {
                if (GameData.dictLevelToSumExp[i] > exp)
                {
                    return i;
                }
                i++;
            }
            return Data.GunLevelUpperLimit(3);
        }
    }



}

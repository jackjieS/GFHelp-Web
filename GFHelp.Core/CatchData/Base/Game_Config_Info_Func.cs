using GFHelp.Core.CatchData.Base.CMD;
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
        public static float GetGunBasicAttribute(int type, string key)
        {

            if (!CatachData.dictGunBaseAttri.ContainsKey(type))
            {
                CatachData.dictGunBaseAttri.Add(type, new Dictionary<string, float>());
            }
            if (!CatachData.dictGunBaseAttri[type].ContainsKey(key))
            {
                float result = CatachData.gun_type_info[type].data[key];
                CatachData.dictGunBaseAttri[type].Add(key, result);
            }
            return CatachData.dictGunBaseAttri[type][key];
        }


        public static void ReadInfo(JsonData jsonData)
        {
            Data.dictionaryIntParamter = new Dictionary<string, int>();
            Data.dictionaryStringParamter = new Dictionary<string, string>();
            Data.dictionaryFloatParamter = new Dictionary<string, float>();
            Data.dictConfigDataArray = new Dictionary<string, Dictionary<int, object>>();
            for (int i = 0; i < jsonData.Count; i++)
            {
                string @string = jsonData[i]["parameter_type"].String;
                switch (@string)
                {
                    case "int":
                        {
                            int @int = jsonData[i]["parameter_value"].Int;
                            Data.dictionaryIntParamter.Add(jsonData[i]["parameter_name"].String, @int);
                            break;
                        }
                    case "string":
                        {
                            string string2 = jsonData[i]["parameter_value"].String;
                            Data.dictionaryStringParamter.Add(jsonData[i]["parameter_name"].String, string2);
                            break;
                        }
                    case "float":
                        {
                            double @float = jsonData[i]["parameter_value"].Double;
                            Data.dictionaryFloatParamter.Add(jsonData[i]["parameter_name"].String,float.Parse(@float.ToString()));
                            break;
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


        public static Dictionary<int, int> dictGunUpLevelExp;
        public static Dictionary<int, int> dictLevelToSumExp = new Dictionary<int, int>();
        public static tBaseDatas<EquipInfo> listEquipInfo;
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

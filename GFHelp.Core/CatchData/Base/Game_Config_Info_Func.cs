using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    class Game_Config_Info_Func
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
        public static int GetInt(string key)
        {
            int result = 0;
            foreach (var item in CatachData.game_config_info)
            {
                if (item.Value.parameter_name == key)
                {
                    string[] a = item.Value.parameter_value[0];
                    int.TryParse(a[0], out result);
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
        public static string GetString(string key)
        {
            string result = "";
            foreach (var item in CatachData.game_config_info)
            {
                if (item.Value.parameter_name == key)
                {
                    result = item.Value.parameter_value_String;
                    break;
                }
            }
            return result;
        }

    }
}

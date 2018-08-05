using Codeplex.Data;
using GFHelp.Core.CatchData.Base;
using GFHelp.Core.CatchData.Base.CMD;
using GFHelp.Core.Helper;
using LitJson;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFHelp.Core
{

    public class CatachData
    {
        public static Dictionary<int, int> gun_exp_info = new Dictionary<int, int>();
        public static Dictionary<int, int> equip_exp_info = new Dictionary<int, int>();
        public static Dictionary<int, Auto_Mission_Info> auto_mission_info = new Dictionary<int, Auto_Mission_Info>();
        public static Dictionary<int, Fairy_Type_Info> fairy_type_info = new Dictionary<int, Fairy_Type_Info>();
        public static Dictionary<int, Fairy_Info> fairy_info = new Dictionary<int, Fairy_Info>();
        public static Dictionary<int, float> equip_exp_Rate_info = new Dictionary<int, float>();

        public static Dictionary<int, Gun_Type_Info> gun_type_info = new Dictionary<int, Gun_Type_Info>();
        public static Dictionary<int, Kalina_Favor_Info> kalina_favor_info = new Dictionary<int, Kalina_Favor_Info>();
        public static Dictionary<int, Operation_Info> operation_info = new Dictionary<int, Operation_Info>();

        public static Dictionary<int, Game_Config_Info> game_config_info = new Dictionary<int, Game_Config_Info>();
        public static Dictionary<int, Dictionary<string, float>> dictGunBaseAttri = new Dictionary<int, Dictionary<string, float>>();
        public static Dictionary<Attri, float> dictMinAttribute = new Dictionary<Attri, float>();
        public static Dictionary<int, int> Furniture_database = new Dictionary<int, int>();
        public static Dictionary<int, int> Furniture_server = new Dictionary<int, int>();
        public static Dictionary<int, int> Furniture_printer = new Dictionary<int, int>();

        public static tBaseDatas<ItemInfo> listItemInfo = new tBaseDatas<ItemInfo>();
        public static void Seed()
        {
            ClearCatchData();
            ReadCatchData();
        }


        private static void ClearCatchData()
        {
            Furniture_printer.Clear();
            Furniture_server.Clear();
            Furniture_database.Clear();
            dictMinAttribute.Clear();
            dictGunBaseAttri.Clear();
            equip_exp_Rate_info.Clear();
            auto_mission_info.Clear();
            fairy_type_info.Clear();
            fairy_info.Clear();
            equip_exp_info.Clear();
            gun_exp_info.Clear();
            GameData.listGunInfo.Clear();
            gun_type_info.Clear();
            kalina_favor_info.Clear();
            operation_info.Clear();
            game_config_info.Clear();
        }

        private static void ReadCatchData()
        {

            var catchdatafile = SystemOthers.ConfigData.currentDirectory + @"\stc\catchdata.json";
            string jsondata = File.ReadAllText(catchdatafile);
            var jsonobj = DynamicJson.Parse(jsondata); //讲道理，我真不想写了
            JsonData jsonData = JsonMapper.ToObject(jsonobj.game_config_info.ToString());
            CatchData.Base.Data.ReadInfo(jsonData);
            ReadCatchData_operation_info(jsonobj);
            ReadCatchData_gun_exp_info(jsonobj);
            ReadCatchData_kalina_favor_info(jsonobj);
            ReadCatchData_auto_mission_info(jsonobj);
            ReadCatchData_equip_exp_info(jsonobj);
            ReadCatchData_equip_info(jsonobj);
            ReadCatchData_fairy_type_info(jsonobj);
            ReadCatchData_Fairy_Info(jsonobj);
            ReadCatchData_gun_info();
            ReadCatchDATA_Item_Info();
            ReadCatchData_gun_type_info(jsonobj);
            ReadCatchData_game_config_info(jsonobj);
            GetFurniture_database(jsonobj);
            GetFurniture_server(jsonobj);
            GetFurniture_printer(jsonobj);
        }

        private static bool ReadCatchData_operation_info(dynamic jsonobj)
        {

            foreach (var item in jsonobj.operation_info)
            {
                try
                {
                    Operation_Info oi = new Operation_Info();

                    oi.id = Convert.ToInt32(item.id);
                    oi.campaign = Convert.ToInt32(item.campaign);

                    //这个name需要解析
                    oi.name = Asset_Textes.ChangeCodeFromeCSV(item.name.ToString());

                    oi.description = item.description.ToString();
                    oi.duration = Convert.ToInt32(item.duration);
                    oi.mp = Convert.ToInt32(item.mp);
                    oi.ammo = Convert.ToInt32(item.ammo);
                    oi.mre = Convert.ToInt32(item.mre);
                    oi.part = Convert.ToInt32(item.part);

                    foreach (var x in item.item_pool.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        oi.item_pool.Add(Convert.ToInt32(x));
                    }
                    //public List<int> itemPool = new List<int>();
                    oi.team_leader_min_level = Convert.ToInt32(item.team_leader_min_level);
                    oi.gun_min = Convert.ToInt32(item.gun_min);
                    oi.guntype1_min = Convert.ToInt32(item.guntype1_min);
                    oi.guntype2_min = Convert.ToInt32(item.guntype2_min);
                    oi.guntype3_min = Convert.ToInt32(item.guntype3_min);
                    oi.guntype4_min = Convert.ToInt32(item.guntype4_min);
                    oi.guntype5_min = Convert.ToInt32(item.guntype5_min);
                    oi.guntype6_min = Convert.ToInt32(item.guntype6_min);
                    oi.guntype7_min = Convert.ToInt32(item.guntype7_min);

                    operation_info.Add(oi.id - 1, oi);
                }

                catch (Exception e)
                {
                    new Log().systemInit("读取CatchData_operation_info遇到错误", e.ToString()).coreError();

                    continue;
                }
            }
            return true;
        }
        private static bool ReadCatchData_gun_exp_info(dynamic jsonobj)
        {
            try
            {
                JsonData jsonData = JsonMapper.ToObject(jsonobj.ToString());
                JsonData jsonData23 = jsonData["gun_exp_info"];
                GameData.dictGunUpLevelExp = new Dictionary<int, int>();
                GameData.dictLevelToSumExp = new Dictionary<int, int>();
                GameData.dictLevelToSumExp[0] = 0;
                for (int num16 = 0; num16 < jsonData23.Count; num16++)
                {
                    int @int = jsonData23[num16]["lv"].Int;
                    int int2 = jsonData23[num16]["exp"].Int;
                    GameData.dictGunUpLevelExp.Add(@int, int2);
                    GameData.dictLevelToSumExp.Add(@int, int2 + ((@int <= 1) ? 0 : GameData.dictLevelToSumExp[@int - 1]));
                }
            }
            catch (Exception e)
            {
                new Log().systemInit("读取CatchData_gun_exp_info遇到错误", e.ToString()).coreError();
                return false;
            }
            return true;
        }
        private static bool ReadCatchData_kalina_favor_info(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.kalina_favor_info)
                {
                    Kalina_Favor_Info kfi = new Kalina_Favor_Info();
                    kfi.level = Convert.ToInt32(item.level);
                    kfi.min_favor = Convert.ToInt32(item.min_favor);
                    kfi.skin_id = Convert.ToInt32(item.skin_id);

                    kalina_favor_info.Add(kfi.level - 1, kfi);
                }
            }
            catch (Exception e)
            {
                new Log().systemInit("读取CatchData_gun_type_info遇到错误", e.ToString()).coreError();
                return false;
            }
            return true;
        }
        private static void ReadCatchData_auto_mission_info(dynamic jsonobj)
        {

            foreach (var item in jsonobj.auto_mission_info)
            {
                try
                {
                    Auto_Mission_Info ami = new Auto_Mission_Info();
                    ami.mission_id = Convert.ToInt32(item.mission_id);
                    ami.team_effect = Convert.ToInt32(item.team_effect);
                    ami.team_count = Convert.ToInt32(item.team_count);
                    ami.mp = Convert.ToInt32(item.mp);
                    ami.ammo = Convert.ToInt32(item.ammo);
                    ami.mre = Convert.ToInt32(item.mre);
                    ami.part = Convert.ToInt32(item.part);
                    ami.duration = Convert.ToInt32(item.duration);
                    ami.experience = Convert.ToInt32(item.experience);
                    ami.expect_gun_level = Convert.ToInt32(item.expect_gun_level);
                    ami.get_gun_num = Convert.ToInt32(item.get_gun_num);

                    foreach (var x in item.gun_n_pool.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        ami.gun_n_pool.Add(Convert.ToInt32(x));
                    }
                    foreach (var x in item.gun_1_pool.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        ami.gun_1_pool.Add(Convert.ToInt32(x));
                    }

                    //public List<int> gun_n_pool = new List<int>();
                    //public List<int> gun_1_pool = new List<int>();
                    int.TryParse(item.limit_guns, out ami.limit_guns);
                    ami.get_equip_num = Convert.ToInt32(item.get_equip_num);

                    foreach (var x in item.equip_n_pool.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        ami.equip_n_pool.Add(Convert.ToInt32(x));
                    }
                    foreach (var x in item.equip_1_pool.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        ami.equip_1_pool.Add(Convert.ToInt32(x));
                    }

                    ami.draw_event_id = Convert.ToInt32(item.draw_event_id);
                    int.TryParse(item.limit_equips, out ami.limit_equips);
                    auto_mission_info.Add(ami.mission_id, ami);
                }


                catch (Exception e)
                {
                    new Log().systemInit("读取CatchData_Auto_Mission遇到错误", e.ToString()).coreError();
                }
            }
        }
        private static bool ReadCatchData_equip_exp_info(dynamic jsonobj)
        {
            GameData.listEquipInfo = new tBaseDatas<EquipInfo>();
            JsonData jsonData = JsonMapper.ToObject(jsonobj.ToString());
            if (jsonData.Contains("equip_exp_info"))
            {
                GameData.dictEquipmentExpInfo = new Dictionary<int, int>();
                JsonData jsonData33 = jsonData["equip_exp_info"];
                if (jsonData33 != null)
                {
                    for (int num26 = 1; num26 <= jsonData33.Count; num26++)
                    {
                        int value = int.Parse(jsonData33[num26 - 1]["exp"].ToString());
                        GameData.dictEquipmentExpInfo.Add(num26, value);
                    }
                }
            }
            return true;
        }
        private static bool ReadCatchData_equip_info(dynamic jsonobj)
        {
            GameData.listEquipInfo = new tBaseDatas<EquipInfo>();
            JsonData jsonData = JsonMapper.ToObject(jsonobj.ToString());
            JsonData jsonData32 = jsonData["equip_info"];
            if (jsonData32 != null)
            {
                for (int num25 = 0; num25 < jsonData32.Count; num25++)
                {
                    try
                    {
                        EquipInfo data13 = new EquipInfo(jsonData32[num25]);
                        GameData.listEquipInfo.Add(data13);
                    }
                    catch(Exception e)
                    {
                        new Log().systemInit("读取CatchData_equip_info遇到错误", e.ToString()).coreError();
                    }
                }
            }

            return true;
        }
        private static bool ReadCatchData_fairy_type_info(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.fairy_type_info)
                {
                    Fairy_Type_Info fti = new Fairy_Type_Info();
                    fti.id = Convert.ToInt32(item.id);
                    fti.name = item.name.ToString();
                    fairy_type_info.Add(fairy_type_info.Count, fti);
                }
            }
            catch (Exception e)
            {
                new Log().systemInit("读取CatchData_fairy_type_info遇到错误", e.ToString()).coreError();
                return false;
            }
            return true;
        }
        private static bool ReadCatchData_Fairy_Info(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.fairy_info)
                {
                    Fairy_Info fi = new Fairy_Info();

                    fi.id = Convert.ToInt32(item.id);
                    fi.name = item.name.ToString();
                    fi.code = item.code.ToString();
                    fi.description = item.description.ToString();
                    fi.introduce = item.introduce.ToString();
                    fi.type = Convert.ToInt32(item.type);
                    fi.pow = Convert.ToInt32(item.pow);
                    fi.hit = Convert.ToInt32(item.hit);
                    fi.baseHit = fi.hit;
                    fi.dodge = Convert.ToInt32(item.dodge);
                    fi.baseDodge = fi.dodge;
                    fi.armor = Convert.ToInt32(item.armor);
                    fi.baseArmor = fi.armor;
                    fi.critical_harm_rate = Convert.ToInt32(item.critical_harm_rate);
                    fi.baseCritDamage = fi.critical_harm_rate;
                    fi.grow = Convert.ToInt32(item.grow);
                    //public Dictionary<int, float> proportion = new Dictionary<int, float>();
                    //1:0.4,2:0.5,3:0.6,4:0.8,5:1
                    foreach (var x in item.proportion.Split(','))
                    {
                        //1:0.4
                        string[] data = new string[2];
                        data = x.Split(':');
                        fi.proportion.Add(Convert.ToInt32(data[0]), float.Parse(data[1]));
                    }
                    fi.skill_id = item.skill_id;
                    fi.quality_exp = Convert.ToInt32(item.quality_exp);
                    //public Dictionary<int, float> quality_need_number = new Dictionary<int, float>();
                    //1:0,2:100,3:500,4:1500,5:3000
                    foreach (var x in item.quality_need_number.Split(','))
                    {
                        string[] data = new string[2];
                        data = x.Split(':');
                        fi.quality_need_number.Add(Convert.ToInt32(data[0]), Int32.Parse(data[1]));
                    }

                    fi.develop_duration = Convert.ToInt32(item.develop_duration);
                    fi.retiremp = Convert.ToInt32(item.retiremp);
                    fi.retireammo = Convert.ToInt32(item.retireammo);
                    fi.retiremre = Convert.ToInt32(item.retiremre);
                    fi.retirepart = Convert.ToInt32(item.retirepart);
                    fi.powerup_mp = Convert.ToInt32(item.powerup_mp);
                    fi.powerup_ammo = Convert.ToInt32(item.powerup_ammo);
                    fi.powerup_mre = Convert.ToInt32(item.powerup_mre);
                    fi.powerup_part = Convert.ToInt32(item.powerup_part);
                    fi.armor_piercing = Convert.ToInt32(item.armor_piercing);
                    fi.category = Convert.ToInt32(item.category);
                    fi.ai = Convert.ToInt32(item.ai);


                }
            }
            catch (Exception e)
            {
                new Log().systemInit("读取CatchDdat_Fairy_Info遇到错误", e.ToString()).coreError();
                return false;
            }
            return true;
        }
        private static void ReadCatchData_gun_info()
        {
            TableHelper.LoadTable<Gun_Info>(ref GameData.listGunInfo, CmdDef.stcGunList, true);
        }

        private static void ReadCatchDATA_Item_Info()
        {
            TableHelper.LoadTable<ItemInfo>(ref listItemInfo, CmdDef.stcItemList, true);
        }
        private static bool ReadCatchData_gun_type_info(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.gun_type_info)
                {
                    Gun_Type_Info gti = new Gun_Type_Info();

                    gti.id = Convert.ToInt32(item.id);
                    gti.name = item.name.ToString();
                    gti.data.Add("basic_attribute_life", float.Parse(item.basic_attribute_life));
                    gti.data.Add("basic_attribute_pow", float.Parse(item.basic_attribute_pow));
                    gti.data.Add("basic_attribute_rate", float.Parse(item.basic_attribute_rate));
                    gti.data.Add("basic_attribute_speed", float.Parse(item.basic_attribute_speed));
                    gti.data.Add("basic_attribute_hit", float.Parse(item.basic_attribute_hit));
                    gti.data.Add("basic_attribute_dodge", float.Parse(item.basic_attribute_dodge));
                    gti.data.Add("basic_attribute_armor", float.Parse(item.basic_attribute_armor));
                    gti.data.Add("mp_fix_ratio", float.Parse(item.mp_fix_ratio));
                    gti.data.Add("part_fix_ratio", float.Parse(item.part_fix_ratio));
                    gti.data.Add("fix_time_ratio", float.Parse(item.fix_time_ratio));

                    gun_type_info.Add(gti.id, gti);
                }
            }
            catch (Exception e)
            {
                new Log().systemInit("CatchData_gun_type_info遇到错误", e.ToString()).coreError();
                return false;
            }
            return true;
        }
        private static bool ReadCatchData_game_config_info(dynamic jsonobj)
        {
            var datetime = new DateTime();
            foreach (var item in jsonobj.game_config_info)
            {
                try
                {
                    Game_Config_Info gci = new Game_Config_Info();

                    gci.parameter_name = item.parameter_name.ToString();
                    gci.parameter_type = item.parameter_type.ToString();
                    gci.client_require = item.client_require.ToString();

                    string temp_parameter_value = item.parameter_value.ToString();
                    gci.parameter_value_String = temp_parameter_value;
                    if (temp_parameter_value.Contains(","))
                    {


                        //有逗号
                        if (temp_parameter_value.Contains(":"))
                        {
                            //有逗号也有名字 string[0]名字 string[1]值
                            foreach (var x in temp_parameter_value.Split(','))
                            {
                                if (String.IsNullOrEmpty(x)) continue;
                                if (DateTime.TryParse(x, out datetime))
                                {
                                    string[] temp = new string[1];
                                    temp[0] = datetime.ToString();
                                    gci.parameter_value.Add(gci.parameter_value.Count, temp);
                                    continue;
                                }
                                string[] value = new string[2];
                                int i = 0;
                                foreach (var y in x.Split(':'))
                                {
                                    value[i] = y.ToString();
                                    i++;
                                }
                                gci.parameter_value.Add(gci.parameter_value.Count, value);
                            }
                        }
                        else
                        {
                            //只有逗号没有冒号
                            foreach (var x in temp_parameter_value.Split(','))
                            {
                                if (String.IsNullOrEmpty(x)) continue;
                                string[] value = new string[1];
                                value[0] = x.ToString();
                                gci.parameter_value.Add(gci.parameter_value.Count, value);
                            }
                        }


                    }
                    else
                    {
                        //没有逗号 只有一个值
                        string[] value = new string[1];
                        value[0] = temp_parameter_value;
                        gci.parameter_value.Add(gci.parameter_value.Count, value);
                    }
                    game_config_info.Add(game_config_info.Count, gci);
                }
                catch (Exception e)
                {
                    new Log().systemInit("读取CatchData_game_config_info遇到错误", e.ToString()).coreError();
                    return false;
                }

            }


            return true;



        }
        private static bool GetFurniture_database(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.furniture_establish_info)
                {
                    if (Convert.ToInt32(item.establish_type) == 204)
                    {
                        Furniture_database.Add(Convert.ToInt32(item.establish_lv), Convert.ToInt32(item.parameter_1));
                    }
                }
            }
            catch (Exception e)
            {
                new Log().systemInit("读取CatchData_Furniture_database遇到错误", e.ToString()).coreError();
                return false;
            }
            return true;
        }
        private static bool GetFurniture_server(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.furniture_establish_info)
                {
                    if (Convert.ToInt32(item.establish_type) == 205)
                    {
                        Furniture_server.Add(Convert.ToInt32(item.establish_lv), Convert.ToInt32(item.parameter_1));
                    }
                }
            }
            catch (Exception e)
            {
                new Log().systemInit("读取CatchData_Furniture_server遇到错误", e.ToString()).coreError();
                return false;
            }
            return true;
        }
        private static bool GetFurniture_printer(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.furniture_establish_info)
                {
                    if (Convert.ToInt32(item.establish_type) == 206)
                    {
                        Furniture_printer.Add(Convert.ToInt32(item.establish_lv), Convert.ToInt32(item.parameter_1));
                    }
                }
            }
            catch (Exception e)
            {
                new Log().systemInit("读取CatchData_Furniture_printer遇到错误", e.ToString()).coreError();
                return false;
            }
            return true;
        }


        public static int getFairyDevTimeFromID(int id)
        {
            foreach (var item in fairy_info)
            {
                if (item.Value.id == id)
                {
                    return item.Value.develop_duration;
                }
            }
            return 999999999;
        }
        public class OperationInfo
        {
            public int id;
            public string name;
        }
        public static List<OperationInfo> GetOperationInfo()
        {
            List<OperationInfo> OperationtInfo = new List<OperationInfo>();
            foreach (var item in operation_info)
            {
                OperationInfo oi = new OperationInfo();
                oi.id = item.Value.id;
                oi.name = String.Format("{0}({1}-{2})", item.Value.name, (int)((item.Value.id - 1) / 4), (int)((item.Value.id - 1) % 4)+1);
                OperationtInfo.Add(oi);
            }
            return OperationtInfo;
        }
    }
}

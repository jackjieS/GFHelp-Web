using Codeplex.Data;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core.MulitePlayerData
{
    /// <summary>
    /// 这里的建造槽很操蛋 是1开头的
    /// </summary>
    public class Equip_Built
    {

        public Equip_Built(UserData userData)
        {
            this.userData = userData;
        }


        public void Read(JsonData jsonData)
        {
            this.Built_Slot.Clear();

            for (int i = 1; i <= userData.user_Info.max_equip_build_slot; i++)
            {
                Data data2 = new Data();
                data2.build_slot = i;
                this.Built_Slot.Add(i, data2);
            }



            if (jsonData.Contains("develop_equip_act_info"))
            {
                JsonData jsonData16 = jsonData["develop_equip_act_info"];
                for (int num8 = 0; num8 < jsonData16.Count; num8++)
                {
                    Data data2 = new Data(jsonData16[num8]);
                    if (Built_Slot.ContainsKey(data2.build_slot))
                    {
                        Built_Slot[data2.build_slot] = data2;
                    }
                    else
                    {
                        this.Built_Slot.Add(data2.build_slot, data2);
                    }
                }
            }



        }

        public void AutoRun()
        {

            //资源检测
            //创库检测

            finishDevelopHandel();
            startDevelopHandel();

        }


        private bool ResourecsCheck()
        {
            if (userData.user_Info.ammo < 10000 && userData.user_Info.part < 10000 && userData.user_Info.mre < 10000 && userData.user_Info.mp < 10000)
                return false;
            if (userData.equip_With_User_Info.listEquip.Count + 5 > userData.user_Info.maxequip)
                return false;
            if (userData.fairy_With_User_Info.dicFairy.Count > userData.user_Info.max_fairy)
                return false;
            return true;


        }


        public void finishDevelopHandel()
        {
            for (int i = 1; i <= userData.user_Info.max_equip_build_slot; i++)
            {
                if (!Built_Slot.ContainsKey(i)) continue;
                if (Built_Slot[i].isEmpty) continue;
                if (Built_Slot[i].endTime < Decrypt.ConvertDateTime_China_Int(DateTime.Now))
                {
                    Task<bool> taskFinish = new Task<bool>(() => finishDevelop(Built_Slot[i]));
                    taskFinish.Start();
                    Task.WaitAll(taskFinish);
                }
            }
        }
        public void startDevelopHandel()
        {
            if (!Heavy_Auto) return;
            if (!ResourecsCheck()) return;
            for (int i = 1; i <= userData.user_Info.max_equip_build_slot; i++)
            {
                if (i % 2 != 0) continue;
                if (Built_Slot.ContainsKey(i))
                {
                    if (!Built_Slot[i].isEmpty)
                    {
                        continue;
                    }

                }
                else
                {
                    Data data = new Data(i);
                    this.Built_Slot.Add(i, data);
                }
                Task<bool> taskStart = new Task<bool>(() => startDevelop(Built_Slot[i]));
                taskStart.Start();
                Task.WaitAll(taskStart);
            }
        }









        public bool startDevelop(Data data)
        {
            dynamic newjson = new DynamicJson();
            newjson.mp = data.mp;/* 这是值*/
            newjson.ammo = data.ammo;/* 这是值*/
            newjson.mre = data.mre;/* 这是值*/
            newjson.part = data.part;/* 这是值*/
            newjson.build_slot = data.build_slot;/* 这是值*/
            newjson.input_level = data.input_level;/* 这是值*/
            int count = 0;
            while (true)
            {
                string result = API.Factory.startDevelop(userData.GameAccount, newjson.ToString());

                switch (Response.Check(userData.GameAccount, ref result, "startDevelop", true))
                {
                    case 1:
                        {
                            JsonData jsonData = JsonMapper.ToObject(result.ToString());
                            data.start_time = Decrypt.ConvertDateTime_China_Int(DateTime.Now);
                            data.isEmpty = false;
                            if (result.Contains("equip"))
                            {
                                data.equip_id = jsonData["equip_id"].Int;
                                data.develop_duration = CatachData.getEquipDevTimeByID(data.equip_id);
                                if (Built_Slot.ContainsKey(data.build_slot))
                                {
                                    Built_Slot[data.build_slot] = data;
                                }
                                else
                                {
                                    Built_Slot.Add(data.build_slot, data);
                                }
                            }
                            if (result.Contains("fairy_id"))
                            {
                                data.fairy_id = jsonData["fairy_id"].Int;
                                data.develop_duration = CatachData.getFairyDevTimeByID(data.fairy_id);
                                if (Built_Slot.ContainsKey(data.build_slot))
                                {
                                    Built_Slot[data.build_slot] = data;
                                }
                                else
                                {
                                    Built_Slot.Add(data.build_slot, data);
                                }
                            }
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }









        }

        public bool finishDevelop(Data data)
        {
            int count = 0;
            while (true)
            {
                dynamic newjson = new DynamicJson();
                newjson.build_slot  = data.build_slot;/* 这是值*/

                string result = API.Factory.finishDevelop(userData.GameAccount,newjson.ToString());

                switch (Response.Check(userData.GameAccount, ref result, "finishDevelop", true))
                {
                    case 1:
                        {
                            JsonData jsonData = JsonMapper.ToObject(result.ToString());
                            if (result.Contains("fairy_with_user"))
                            {
                                //fairy_with_user
                                int fairy_with_userID = jsonData["fairy_with_user"].Int;
                                Fairy_With_User_info.Data data1 = new Fairy_With_User_info.Data(fairy_with_userID);
                                userData.fairy_With_User_Info.dicFairy.Add(userData.fairy_With_User_Info.dicFairy.Count, data1);
                            }

                            if (result.Contains("equip_with_user"))
                            {

                                jsonData = jsonData["equip_with_user"];
                                Equip.Data data2 = new Equip.Data(jsonData);
                                userData.equip_With_User_Info.listEquip.Add(data2);
                            }
                            data.isEmpty = true;
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }



        }


        //max_equip_build_slot
        public class Data
        {
            public Data()
            {
                this.isEmpty = true;
            }
            public Data(int build_slot)
            {

                this.mp = 500;/* 这是值*/
                this.ammo = 500;/* 这是值*/
                this.mre = 500;/* 这是值*/
                this.part = 500;/* 这是值*/
                this.build_slot = build_slot;/* 这是值*/
                this.input_level = 1;/* 这是值*/


            }
            public Data(JsonData jsonData = null)
            {
                if (jsonData != null)
                {
                    this.type = jsonData["type"].Int;
                    if(jsonData.Contains("equip_id"))
                    {
                        this.equip_id = jsonData["equip_id"].Int;
                        this.develop_duration = CatachData.getEquipDevTimeByID(this.equip_id);
                    }
                    if (jsonData.Contains("fairy_id"))
                    {
                        this.fairy_id = jsonData["fairy_id"].Int;
                        this.develop_duration = CatachData.getFairyDevTimeByID(this.fairy_id);
                    }

                    this.build_slot = jsonData["build_slot"].Int;
                    this.user_id = jsonData["user_id"].Int;
                    this.start_time = jsonData["start_time"].Int;
                    this.mp = jsonData["mp"].Int;
                    this.ammo = jsonData["ammo"].Int;
                    this.mre = jsonData["mre"].Int;
                    this.part = jsonData["part"].Int;
                    this.input_level = jsonData["input_level"].Int;
                    this.core = jsonData["core"].Int;
                    this.item_num = jsonData["item_num"].Int;
                    this.isEmpty = false;
                }
            }
            public bool isEmpty;
            public int type;//表示当前字段在字典里的键位
            public int equip_id;
            public int fairy_id;
            public int build_slot;
            public int user_id;
            public int start_time;
            public int mp;
            public int ammo;
            public int mre;
            public int part;
            public int input_level;
            public int core;
            public int item_num;
            public int develop_duration;
            public int endTime
            {
                get
                {
                    return this.start_time + this.develop_duration+10;
                }
            }
            public int durationTime
            {
                get
                {
                    return this.start_time + this.develop_duration + 10 - Decrypt.ConvertDateTime_China_Int(DateTime.Now);
                }


            }
        }

        public UserData userData;
        //总开关
        public bool Heavy_Auto= false;
        public bool Normal_Auto=false;

        //建造槽
        public Dictionary<int, Data> Built_Slot = new Dictionary<int, Data>();






    }

}

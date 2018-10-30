using Codeplex.Data;
using GFHelp.Core.CatchData.Base;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core.MulitePlayerData
{
    public class Doll_Build
    {
        public Doll_Build(UserData userData)
        {
            this.userData = userData;
        }
        public void Read(JsonData jsonData)
        {
            this.Built_Slot.Clear();

            for (int i = 1; i <= userData.user_Info.max_build_slot; i++)
            {
                Data data2 = new Data();
                data2.build_slot = i;
                this.Built_Slot.Add(i, data2);
            }
            if (jsonData.Contains("develop_act_info"))
            {
                JsonData jsonData16 = jsonData["develop_act_info"];
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




        private void DataBuild(ref Data data)
        {
            if (data.build_slot % 2 == 0)
            {
                //偶数大建
                data.ammo = 500;
                data.part = 500;
                data.mp = 500;
                data.mre = 500;
                data.input_level = 1;
            }
            if (data.build_slot % 2 != 0)
            {
                //奇数普建
                data.ammo = 130;
                data.part = 130;
                data.mp = 130;
                data.mre = 130;
                data.input_level = 0;
            }
        }

        private bool ResourecsCheck()
        {
            if (userData.user_Info.ammo < 10000 && userData.user_Info.part < 10000 && userData.user_Info.mre < 10000 && userData.user_Info.mp < 10000)
                return false;
            if (userData.gun_With_User_Info.dicGun.Count + 5 > userData.user_Info.maxgun)
                return false;
            return true;
        }

        public void finishDevelopHandel()
        {
            for (int i = 1; i <= userData.user_Info.max_build_slot; i++)
            {
                if (!Built_Slot.ContainsKey(i)) continue;
                if (Built_Slot[i].isEmpty) continue;
                if (Built_Slot[i].endTime < Decrypt.ConvertDateTime_China_Int(DateTime.Now))
                {
                    Task<bool> taskFinish = new Task<bool>(() => finishDevelop(Built_Slot[i]));
                    taskFinish.Start();
                    Task.WaitAll(taskFinish);
                    if (taskFinish.Result == false)
                    {
                        Built_Slot[i].isEmpty = true;
                    }
                }
            }
        }

        public void startDevelopHandel()
        {

            if (!ResourecsCheck()) return;
            for (int i = 1; i <= userData.user_Info.max_build_slot; i++)
            {
                if (i % 2 != 0)
                {
                    if (!Normal_Auto) continue;
                    //奇数普建
                    if (Built_Slot[i].isEmpty)
                    {
                        Task<bool> taskStart = new Task<bool>(() => startDevelop(Built_Slot[i]));
                        taskStart.Start();
                        Task.WaitAll(taskStart);
                    }

                }
                else
                {
                    if (!Heavy_Auto) continue;
                    //偶数大建
                    if (Built_Slot[i].isEmpty)
                    {
                        Task<bool> taskStart = new Task<bool>(() => startDevelop(Built_Slot[i]));
                        taskStart.Start();
                        Task.WaitAll(taskStart);

                    }

                }

            }
        }










        /// <summary>
        /// {"build_slot":1}
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool finishDevelop(Data data)
        {
            int count = 0;
            while (true)
            {
                dynamic newjson = new DynamicJson();
                newjson.build_slot = data.build_slot;/* 这是值*/

                string result = API.Factory.finishDollDevelop(userData.GameAccount, newjson.ToString());

                switch (Response.Check(userData.GameAccount, ref result, "finishDevelop", true))
                {
                    case 1:
                        {

                            if (result.Contains("gun_with_user_add"))
                            {
                                JsonData jsonData = JsonMapper.ToObject(result.ToString());
                                jsonData = jsonData["gun_with_user_add"];
                                Gun_With_User_Info gwui = new Gun_With_User_Info();
                                gwui = userData.battle.initGun(jsonData["gun_with_user_id"].Int, jsonData["gun_id"].Int);
                                userData.gun_With_User_Info.dicGunAdd(gwui);
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "finishDevelop Error", result.ToString()).userInfo();
                                userData.home.Login();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }



        }

        public bool startDevelop(Data data)
        {
            DataBuild(ref data);
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
                string result = API.Factory.startDollDevelop(userData.GameAccount, newjson.ToString());

                switch (Response.Check(userData.GameAccount, ref result, "startDevelop", true))
                {
                    case 1:
                        {
                            JsonData jsonData = JsonMapper.ToObject(result.ToString());
                            if (result.Contains("gun_id"))
                            {
                                data.gun_id = jsonData["gun_id"].Int;
                                data.develop_duration = CatachData.getDollDevTimeByID(data.equip_id);
                                if (Built_Slot.ContainsKey(data.build_slot))
                                {
                                    Built_Slot[data.build_slot] = data;
                                }
                                else
                                {
                                    Built_Slot.Add(data.build_slot, data);
                                }
                            }
                            data.start_time = Decrypt.ConvertDateTime_China_Int(DateTime.Now);
                            data.isEmpty = false;
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "startDevelop Error", result.ToString()).userInfo();
                                userData.home.Login();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }









        }













        public class Data
        {
            public Data()
            {
                this.isEmpty = true;
            }
            public Data(int build_slot)
            {
                this.build_slot = build_slot;/* 这是值*/
            }
            public Data(JsonData jsonData = null)
            {
                if (jsonData != null)
                {
                    this.user_id = jsonData["user_id"].Int;
                    this.id = jsonData["id"].Int;
                    this.gun_id = jsonData["gun_id"].Int;
                    this.equip_id = jsonData["equip_id"].Int;
                    this.start_time = jsonData["start_time"].Int;
                    this.mp = jsonData["mp"].Int;
                    this.ammo = jsonData["ammo"].Int;
                    this.mre = jsonData["mre"].Int;
                    this.part = jsonData["part"].Int;
                    this.input_level = jsonData["input_level"].Int;
                    this.core = jsonData["core"].Int;
                    this.item_num = jsonData["item1_num"].Int;
                    this.build_slot = jsonData["build_slot"].Int;
                    this.isEmpty = false;
                    this.develop_duration = GameData.listGunInfo.GetDataById(gun_id).develop_duration;
                }
            }
            public int id;
            public int user_id;
            public int gun_id;
            public int equip_id;
            public int start_time;
            public int mp;
            public int ammo;
            public int mre;
            public int part;
            public int input_level;
            public int core;
            public int item_num;
            public int build_slot;
            public bool isEmpty;
            public int develop_duration;
            public int endTime
            {
                get
                {
                    return this.start_time + this.develop_duration + 10;
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
        public bool Heavy_Auto = false;
        public bool Normal_Auto = false;
        //建造槽
        public Dictionary<int, Data> Built_Slot = new Dictionary<int, Data>();
    }
}

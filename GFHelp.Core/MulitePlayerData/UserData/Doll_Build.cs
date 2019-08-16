using Codeplex.Data;
using GFHelp.Core.CatchData.Base;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            SetNextTime();
        }

        public void TaskDaily()
        {
            Task.Run(() =>
            {
                Interlocked.Increment(ref AutoLoop.ThreadInfo.DollBuildThreadNum);
                this.Locker = true;
                if (ResourecsCheck())
                {
                    for (int i = 1; i <= userData.user_Info.max_build_slot; i++)
                    {
                        if (!Built_Slot.ContainsKey(i)) continue;
                        if (Built_Slot[i].build_slot % 2 == 0) continue;
                        if (Built_Slot[i].endTime < Decrypt.getDateTime_China_Int(DateTime.Now))
                        {
                            Run(Built_Slot[i]);
                        }
                    }
                }

                this.Locker = false;
                Interlocked.Decrement(ref AutoLoop.ThreadInfo.DollBuildThreadNum);


            });


        }
        private void DollBuild_Loop()
        {
            Task.Run(() =>
            {
                Interlocked.Increment(ref AutoLoop.ThreadInfo.DollBuildThreadNum);
                if (ResourecsCheck())
                {
                    for (int i = 1; i <= userData.user_Info.max_build_slot; i++)
                    {
                        if (!Built_Slot.ContainsKey(i)) continue;
                        if (Built_Slot[i].endTime < Decrypt.getDateTime_China_Int(DateTime.Now))
                        {
                            if (Normal_Auto && Built_Slot[i].build_slot % 2 == 1)
                            {
                                Run(Built_Slot[i]);
                            }
                            if (Heavy_Auto && Built_Slot[i].build_slot % 2 == 0)
                            {
                                Run(Built_Slot[i]);
                            }
                        }
                    }
                }
                this.Locker = false;
                Interlocked.Decrement(ref AutoLoop.ThreadInfo.DollBuildThreadNum);


            });


        }

        public void SetNextTime()
        {
            var dic = Built_Slot.Keys.Select(x => new { x, y = Built_Slot[x] }).OrderBy(x => x.y.endTime).ToList();
            foreach (var item in dic)
            {
                if (item.y.start_time > 0)
                {
                    NextTime = item.y.endTime;
                    return;
                }
            }
            NextTime = Decrypt.getDateTime_China_Int(DateTime.Now.AddMinutes(30));
        }
        private int _NextTime;
        public int NextTime
        {
            get
            {
                return _NextTime;
            }
            set
            {
                _NextTime = value;
                AutoLoop.dic[userData.GameAccount.GameAccountID].DollBuildNextTime = value;
            }
        }



        public bool isAutoRunning()
        {
            foreach (var item in Built_Slot)
            {
                if (item.Value.endTime < Decrypt.getDateTime_China_Int(DateTime.Now))
                {
                    if (item.Value.build_slot % 2 == 0) continue;
                    return false;
                }

            }
            return true;
        }







        public void Run(Data data)
        {
            bool result;
            try
            {
                if (data.isEmpty == false)
                {
                    result = finishDevelop(data);
                    if (result == true)
                    {
                        data.isEmpty = true;
                    }
                    else
                    {
                        Built_Slot[data.build_slot] = new Data(data.build_slot);
                        SetNextTime();
                        return;
                    }
                }

                if (data.isEmpty == true)
                {
                    result = startDevelop(data);
                    if (result == true)
                    {
                        data.isEmpty = false;
                    }
                    else
                    {
                        Built_Slot[data.build_slot] = new Data(data.build_slot);
                        SetNextTime();
                        return;
                    }
                }



                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("DollBuild Error");
                throw;
            }
        }



        public async void AutoRun()
        {
            //资源检测
            //创库检测
            if (Heavy_Auto == false && Normal_Auto == false) return;
            if (Locker) return;
            Locker = true;
            DollBuild_Loop();
        }


        public bool ResourecsCheck()
        {
            if (userData.user_Info.ammo < 10000 && userData.user_Info.part < 10000 && userData.user_Info.mre < 10000 && userData.user_Info.mp < 10000)
                return false;
            if (userData.item_With_User_Info.IOPcontract == 0) return false;
            if (userData.gun_With_User_Info.dicGun.Count + 5 > userData.user_Info.maxgun)
                userData.battle.Check_Equip_Gun_FULL();
            return true;
        }














        /// <summary>
        /// {"build_slot":1}
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool finishDevelop(Data data)
        {
            if (data.isEmpty) return true;
            int count = 0;
            string result = "";
            dynamic newjson = new DynamicJson();
            newjson.build_slot = data.build_slot;/* 这是值*/
            while (count++ < userData.config.ErrorCount)
            {
                try
                {
                    result = userData.Net.Factory.finishDollDevelop(userData.GameAccount, newjson.ToString());
                }
                catch (Exception)
                {
                    return false;
                }
                if (result.ToLower().Contains("error"))
                {
                    return false;
                }
                if (userData.Response.Check(ref result, "finishDevelop", true) == 1)
                {
                    if (result.Contains("gun_with_user_add"))
                    {
                        JsonData jsonData = JsonMapper.ToObject(result.ToString());
                        jsonData = jsonData["gun_with_user_add"];
                        Gun_With_User_Info.Data gwui = new Gun_With_User_Info.Data();
                        gwui = userData.battle.initGun(jsonData["gun_with_user_id"].Int, jsonData["gun_id"].Int);
                        userData.gun_With_User_Info.dicGunAdd(gwui);
                    }
                    Built_Slot[data.build_slot].isEmpty = true;
                    return true;
                }
            }
            new Log().userInit(userData.GameAccount.GameAccountID, "Finish DollBuild Error", result.ToString()).userInfo();
            return false;


        }

        public bool startDevelop(Data data)
        {
            data.DefaulltDataBuild();
            dynamic newjson = new DynamicJson();
            newjson.mp = data.mp;/* 这是值*/
            newjson.ammo = data.ammo;/* 这是值*/
            newjson.mre = data.mre;/* 这是值*/
            newjson.part = data.part;/* 这是值*/
            newjson.build_slot = data.build_slot;/* 这是值*/
            newjson.input_level = data.input_level;/* 这是值*/
            int count = 0;
            string result = "";
            while (count <= userData.config.ErrorCount)
            {
                try
                {
                    result = userData.Net.Factory.startDollDevelop(userData.GameAccount, newjson.ToString());
                }
                catch (Exception)
                {
                    return false;
                }
                if (result.ToLower().Contains("error"))
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "startDevelop Error", result.ToString()).userInfo();
                    return false;
                }

                if (userData.Response.Check(ref result, "startDevelop", true) == 1)
                {
                    JsonData jsonData = JsonMapper.ToObject(result.ToString());
                    if (result.Contains("gun_id"))
                    {
                        Built_Slot[data.build_slot].gun_id = jsonData["gun_id"].Int;
                        Built_Slot[data.build_slot].develop_duration = CatachData.getDollDevTimeByID(data.gun_id);

                    }
                    Built_Slot[data.build_slot].start_time = Decrypt.getDateTime_China_Int(DateTime.Now);
                    Built_Slot[data.build_slot].isEmpty = false;
                    return true;
                }

            }
            new Log().userInit(userData.GameAccount.GameAccountID, "Start DollBuild Error", result.ToString()).userInfo();
            return false;








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
                    this.isEmpty = false;
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
                set
                {
                    endTime = value;
                }
            }
            public int durationTime
            {
                get
                {
                    return this.start_time + this.develop_duration + 10 - Decrypt.getDateTime_China_Int(DateTime.Now);
                }
            }

            public void DefaulltDataBuild()
            {
                if (mp == 0 || ammo == 0 || mre == 0 || part == 0)
                {
                    if (build_slot % 2 == 0)
                    {
                        //偶数大建
                        ammo = 4000;
                        part = 4000;
                        mp = 6000;
                        mre = 4000;
                        input_level = 1;
                    }
                    if (build_slot % 2 != 0)
                    {
                        //奇数普建
                        ammo = 400;
                        part = 400;
                        mp = 400;
                        mre = 400;
                        input_level = 0;
                    }
                }
            }
            public void DataBuild(string fomula)
            {
                if (string.IsNullOrEmpty(fomula)) return;
                var array = fomula.Split(':');
                if (array.Length < 4) return;
                try
                {
                    mp = int.Parse(array[0]);
                    ammo = int.Parse(array[1]);
                    mre = int.Parse(array[2]);
                    part = int.Parse(array[3]);
                }
                catch (Exception e)
                {
                    throw;
                }
            }

        }


        public UserData userData;
        //总开关
        public bool Locker = false;
        public bool Heavy_Auto = false;
        public bool Normal_Auto = false;
        //建造槽
        public Dictionary<int, Data> Built_Slot = new Dictionary<int, Data>();

    }
}

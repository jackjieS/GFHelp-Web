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

        public bool isCompleted()
        {
            if (userData.config.M)
            {
                foreach (var item in Built_Slot)
                {
                    if (item.Value.endTime < Decrypt.getDateTime_China_Int(DateTime.Now))
                    {
                        if (item.Value.build_slot % 2 == 0) continue;
                        return true;
                    }

                }
            }
            return false;
        }
        private object ObjectLocker = new object();
        private void DollBuild_Loop()
        {
            Task.Run(() =>
            {
                Interlocked.Increment(ref AutoLoop.ThreadInfo.DollBuildThreadNum);
                if (ResourecsCheck())
                {
                    if (userData.config.M)
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
            try
            {
                if (finishDevelop(data) == false)
                {
                    Built_Slot[data.build_slot] = new Data(data.build_slot);
                    SetNextTime();
                    return;
                }
                Thread.Sleep(1000);
                if (startDevelop(data) == false)
                {
                    Built_Slot[data.build_slot] = new Data(data.build_slot);
                    SetNextTime();
                    return;
                }
                //userData.home.GetUserInfo();
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
            if (Locker) return;
            Locker = true;
            DollBuild_Loop();
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
                data.ammo = 400;
                data.part = 400;
                data.mp = 400;
                data.mre = 200;
                data.input_level = 0;
            }
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






        public void finishDevelopHandel()
        {
            for (int i = 1; i <= userData.user_Info.max_build_slot; i++)
            {
                if (!Built_Slot.ContainsKey(i)) continue;
                if (Built_Slot[i].isEmpty) continue;
                if (Built_Slot[i].endTime < Decrypt.getDateTime_China_Int(DateTime.Now))
                {
                    Task task = new Task(() => finishDevelop(Built_Slot[i]));
                    task.Start();
                }
            }
        }




        public void startDevelopHandel()
        {

            if (!ResourecsCheck()) return;


            if (userData.config.M)
            {
                if (userData.gun_With_User_Info.Rank5Count < 50)
                {
                    for (int i = 1; i <= userData.user_Info.max_build_slot; i++)
                    {
                        if (i % 2 != 0)
                        {
                            if (!Built_Slot[i].isEmpty) continue;

                            startDevelop(Built_Slot[i]);
                        }
                        else
                        {
                            //if (!Heavy_Auto) continue;
                            ////偶数大建
                            //if (Built_Slot[i].isEmpty)
                            //{
                            //    Task<bool> taskStart = new Task<bool>(() => startDevelop(Built_Slot[i]));
                            //    taskStart.Start();
                            //    Task.WaitAll(taskStart);
                            //}
                        }
                    }
                }
                return;
            }



            for (int i = 1; i <= userData.user_Info.max_build_slot; i++)
            {
                if (i % 2 != 0)
                {
                    if (!Normal_Auto) continue;
                    if (!Built_Slot[i].isEmpty) continue;
                    startDevelop(Built_Slot[i]);
                }
                else
                {
                    if (!Heavy_Auto) continue;
                    if (!Built_Slot[i].isEmpty) continue;
                    startDevelop(Built_Slot[i]);
                }

            }
        }

        public void startDevelopDailyTaskHandel()
        {

            if (!ResourecsCheck()) return;
            for (int i = 1; i <= userData.user_Info.max_build_slot; i++)
            {
                if (i % 2 != 0)
                {
                    //奇数普建
                    if (Built_Slot[i].isEmpty)
                    {
                        bool result =  startDevelop(Built_Slot[i]);

                        if (result == false)
                        {
                            Built_Slot[i].isEmpty = false;
                        }


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
            if (data.isEmpty) return true;
            int count = 0;
            dynamic newjson = new DynamicJson();
            newjson.build_slot = data.build_slot;/* 这是值*/
            while (true)
            {

                string result;
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
                switch (userData.Response.Check( ref result, "finishDevelop", true))
                {
                    case 1:
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
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "finishDevelop Error", result.ToString()).userInfo();
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
                string result;
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
                    return false;
                }

                switch (userData.Response.Check( ref result, "startDevelop", true))
                {
                    case 1:
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
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "startDevelop Error", result.ToString()).userInfo();
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
            public Task DollBuild_Task;
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
        }

        public bool Locker = false;
        public UserData userData;
        //总开关
        public bool Heavy_Auto = false;
        public bool Normal_Auto = false;
        //建造槽
        public Dictionary<int, Data> Built_Slot = new Dictionary<int, Data>();

    }
}

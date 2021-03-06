﻿using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GFHelp.Core.MulitePlayerData
{
    public class Outhouse_BattleReport
    {
        public Outhouse_BattleReport(UserData userData)
        {
            this.userData = userData;
        }
        private UserData userData;

        class Data
        {
            public int id;
            public int user_id;
            public int room_id;
            public int establish_id;
            public int establish_type;
            public int furniture_id;
            public int upgrade_establish_id;
            public int upgrade_starttime;
            public int build_starttime;
            public int build_num;
            public string build_tmp_data;
            public int build_get_time;
            public int update_furniture_id;
            public int furniture_postion;
            public int establish_lv;
            public int upgrade_coin;
            public int upgrade_time;
            public int upgrade_condition;
            public int parameter_1;
            public int parameter_2;
            public int parameter_3;
        }
        public bool Read(dynamic jsonobj)
        {
            dicEstablish.Clear();
            if (userData.config.M) return false;
            foreach (var item in jsonobj.outhouse_establish_info)
            {
                Data oei = new Data();
                try
                {
                    oei.id = Convert.ToInt32(item.id);
                    oei.user_id = Convert.ToInt32(item.user_id);
                    oei.room_id = Convert.ToInt32(item.room_id);
                    oei.establish_id = Convert.ToInt32(item.establish_id);
                    oei.establish_type = Convert.ToInt32(item.establish_type);
                    oei.furniture_id = Convert.ToInt32(item.furniture_id);
                    oei.upgrade_establish_id = Convert.ToInt32(item.upgrade_establish_id);
                    oei.upgrade_starttime = Convert.ToInt32(item.upgrade_starttime);
                    oei.build_starttime = Convert.ToInt32(item.build_starttime);
                    oei.build_num = Convert.ToInt32(item.build_num);
                    if (item.build_tmp_data != null)
                    {
                        oei.build_tmp_data = item.build_tmp_data.ToString();
                    }

                    oei.build_get_time = Convert.ToInt32(item.build_get_time);
                    oei.update_furniture_id = Convert.ToInt32(item.update_furniture_id);
                    //oei.furniture_postion = Convert.ToInt32(item.furniture_postion);
                    oei.establish_lv = Convert.ToInt32(item.establish_lv);
                    oei.upgrade_coin = Convert.ToInt32(item.upgrade_coin);
                    oei.upgrade_time = Convert.ToInt32(item.upgrade_time);
                    //oei.upgrade_condition = Convert.ToInt32(item.upgrade_condition);
                    int.TryParse(item.parameter_1.ToString(), out oei.parameter_1);
                    int.TryParse(item.parameter_2.ToString(), out oei.parameter_2);
                    int.TryParse(item.parameter_3.ToString(), out oei.parameter_3);
                    dicEstablish.Add(oei.establish_type, oei);
                }
                catch (Exception e)
                {
                    new Log().systemInit("读取UserData_Establish", e.ToString()).coreError();
                }
                finally
                {

                }

            }
            setWriteReport();
            return true;
        }
        private void setWriteReport()
        {
            this.continuedTime = Furniture_server;
            if (string.IsNullOrEmpty(dicEstablish[201].build_tmp_data))
            {
                Using = false;
            }
            if (!string.IsNullOrEmpty(dicEstablish[201].build_tmp_data))
            {
                StartTime = dicEstablish[201].build_starttime;
                Using = true;
            }
            this.AutoRunning = true;
        }

        public void AutoRun()
        {
            if (AutoRunning == false) return;
            BattleReportStart();
            BattleReportFinish();
        }
        private void BattleReportStart()
        {
            if (userData.item_With_User_Info.Battery < 1000) return;
            if (userData.item_With_User_Info.globalFreeExp < Furniture_database) return;
            if (time>0) return;
            if (Using) return;
            if (Establish_Build_Start())
            {
                userData.item_With_User_Info.Battery -= Furniture_printer * 3;
                userData.item_With_User_Info.globalFreeExp -= Furniture_printer * 3000;
                this.StartTime =Helper.Decrypt.getDateTime_China_Int(DateTime.Now);
                Using = true;
            }



        }
        private void BattleReportFinish()
        {
            if (time > 0) return;
            if (Using== false) return;

            Establish_Build_Finish();
            Using = false;
        }




        private bool Establish_Build_Start()
        {

            Thread.Sleep(10000);

            //Gun_Retire
            int count = 0;

            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);

            jsonWriter.WriteObjectStart();

            jsonWriter.WritePropertyName("establish_type");
            jsonWriter.Write(201);
            jsonWriter.WritePropertyName("num");
            jsonWriter.Write(userData.outhouse_Establish_Info.Furniture_printer);
            jsonWriter.WritePropertyName("payway");
            jsonWriter.Write("build_coin");
            jsonWriter.WritePropertyName("special_report");
            jsonWriter.Write(getReportType());//1是普通的
            jsonWriter.WriteObjectEnd();

            while (true)
            {
                string result = userData.Net.Dorm.Establish_Build(userData.GameAccount, sb.ToString());

                switch (userData.Response.Check( ref result, "Establish_Build", true))
                {
                    case 1:
                        {
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
                                new Log().userInit(userData.GameAccount.GameAccountID, "Establish_Build_Start ERROR", result).userInfo();
                                AutoRunning = false;
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }
        }
        private bool Establish_Build_Finish()
        {

            Thread.Sleep(5000);

            //Gun_Retire
            int count = 0;

            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);

            jsonWriter.WriteObjectStart();

            jsonWriter.WritePropertyName("establish_type");
            jsonWriter.Write(201);
            jsonWriter.WritePropertyName("payway");
            jsonWriter.Write("build_coin");

            jsonWriter.WriteObjectEnd();

            while (true)
            {
                string result = userData.Net.Dorm.Establish_Build_Finish(userData.GameAccount, sb.ToString());

                switch (userData.Response.Check( ref result, "Establish_Build_Finish", true))
                {
                    case 1:
                        {
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
                                new Log().userInit(userData.GameAccount.GameAccountID, "Establish_Build_Finish ERROR", result).userInfo();
                                AutoRunning = false;
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }
        }


        private int getReportType()
        {
            if (userData.config.HeavyReport == false && userData.config.NormalReport == false)
            {
                Random random = new Random();
                return random.Next(0, 1);
            }
            if (userData.config.HeavyReport == true)
            {
                return 1;
            }
            if (userData.config.NormalReport == true)
            {
                return 0;
            }
            return 0;
        }






        private static Dictionary<int, Data> dicEstablish = new Dictionary<int, Data>();
        public int Furniture_database
        {
            get
            {
                if (!dicEstablish.ContainsKey(204)) return 99999;
                return dicEstablish[204].parameter_1;
            }
        }
        public int Furniture_printer
        {
            get
            {
                if (!dicEstablish.ContainsKey(206)) return 99999;
                return dicEstablish[206].parameter_1;
            }
        }
        public int Furniture_server
        {
            get
            {
                if (!dicEstablish.ContainsKey(205)) return 99999;
                return dicEstablish[205].parameter_1;
            }
        }
        public int ChipsWhareHouse
        {
            get
            {
                if (dicEstablish.ContainsKey(601))
                {
                    return dicEstablish[601].parameter_1;
                }
                return 0;
            }
        }
        public int DataAnalysisMaxSolt
        {
            get
            {
                if (dicEstablish.ContainsKey(504))
                {
                    return dicEstablish[504].parameter_1;
                }
                return 0;
            }
        }
        public bool AutoRunning = true;

        public bool Using=true;
        public int StartTime;//utx
        public int continuedTime;
        public int time
        {
            get
            {
                DateTime t = new DateTime(1970, 1, 1);
                double second = (DateTime.UtcNow - t).TotalSeconds;
                return StartTime + continuedTime - (int)second;
            }
        }
    }
}

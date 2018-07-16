using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GFHelp.Core.Management
{
    public class Loop
    {
        public static void CountDown()//倒计时
        {
            while (true)
            {
                foreach (var user_data in Data.data)
                {
                    user_data.Value.operation_Act_Info.TimeReduce();
                }


                //需要改 在auto那里新建auto_summery 里写入此方法
                //一些自动循环任务 后勤
                Auto_Summery.Auto_Act_Summery();
                //im.uihelp.setUI_User_info();
                Thread.Sleep(1000);
            }
        }


        public static void CompleteMisson(UserData userData)
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (userData.Task.Count == 0) { userData.webData.StatusBarText = "空闲"; continue; }
                switch (userData.Task.ElementAt(0).TaskNumber)
                {
                    case 1:
                        {
                            //登陆
                            Action.Home.Login(userData);

                            userData.Task.RemoveAt(0);
                            break;

                        }


                    case 2:
                        {
                            userData.webData.StatusBarText = "开始游戏登陆";
                            //Get_user_info 读取用户信息刷新数据
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }



                    case 7:
                        {
                            Action.Operation.Start_Operation_Act(userData, userData.operation_Act_Info.dicOperation[0]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 8:
                        {
                            Action.Operation.Start_Operation_Act(userData, userData.operation_Act_Info.dicOperation[1]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 9:
                        {
                            Action.Operation.Start_Operation_Act(userData, userData.operation_Act_Info.dicOperation[2]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 10:
                        {
                            Action.Operation.Start_Operation_Act(userData, userData.operation_Act_Info.dicOperation[3]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 61:
                        {
                            Action.Operation.Start_Loop_Operation_Act(userData, userData.operation_Act_Info.dicOperation[0]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 11:
                        {
                            Action.Operation.Start_Loop_Operation_Act(userData, userData.operation_Act_Info.dicOperation[0]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 12:
                        {
                            Action.Operation.Start_Loop_Operation_Act(userData, userData.operation_Act_Info.dicOperation[1]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 13:
                        {
                            Action.Operation.Start_Loop_Operation_Act(userData, userData.operation_Act_Info.dicOperation[2]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 14:
                        {
                            Action.Operation.Start_Loop_Operation_Act(userData, userData.operation_Act_Info.dicOperation[3]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }

                    case 15:
                        {
                            Action.Operation.Abort_Operation_Act(userData, userData.operation_Act_Info.dicOperation[0]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 16:
                        {
                            Action.Operation.Abort_Operation_Act(userData, userData.operation_Act_Info.dicOperation[1]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 17:
                        {
                            Action.Operation.Abort_Operation_Act(userData, userData.operation_Act_Info.dicOperation[2]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 18:
                        {
                            Action.Operation.Abort_Operation_Act(userData, userData.operation_Act_Info.dicOperation[3]);
                            Action.Home.GetUserInfo(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 21:
                        {
                            Action.Kalina.Click_Kalina(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 22:
                        {
                            Action.Dorm.ClickGirlsFavor(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 23:
                        {
                            Action.Dorm.VisitFriendDorm(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 24:
                        {
                            Action.Dorm.Get_Build_Coin(userData);

                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 25:
                        {
                            Action.Dorm.Get_Dorm_Info(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 26:
                        {
                            //im.friend.Friend_Praise();
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 32:
                        {
                            Action.Battle.GetRecoverBP(userData);
                            userData.Task.RemoveAt(0);
                            //处理结尾 BP的回复时间
                            //getuserinfo 不能用太卡了只能手动处理
                            break;
                        }
                    case 41:
                        {
                            //练级任务1
                            userData.Loop.Test(userData);
                            userData.Task.RemoveAt(0);
                            userData.Loop.End_At_Battle(userData.normal_MissionInfo);
                            break;
                        }
                    case 51:
                        {
                            Action.Dorm.WriteReport(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    case 52:
                        {
                            Action.Dorm.WriteReportFinish(userData);
                            userData.Task.RemoveAt(0);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }




    class Auto_Summery
    {
        //总的循环
        public static void Auto_Act_Summery()
        {
            foreach (var userdata in Data.data)
            {
                if (userdata.Value.config.LoginSuccessful)
                {
                    //Auto_Operation(userdata.Value);
                    ClickKalina(userdata.Value);
                    ClickGirlsFavor(userdata.Value);
                    DailyReFlash(userdata.Value);
                    Auto_Get_Battary(userdata.Value);
                    BP_Recover(userdata.Value);
                    WriteReport_Start(userdata.Value);
                    WriteReport_Finish(userdata.Value);
                    Auto_Simulation_Battle(userdata.Value);
                }
            }
        }





        //public static void Auto_Operation(UserData user_data)
        //{

        //    //检查UI上的总开关
        //    if (user_data.config.NeedAuto_Loop_Operation_Act == false) return;
        //    for (int i = 0; i < user_data.operation_Act_Info.dicOperation.Count; i++)
        //    {
        //        if (string.IsNullOrEmpty(user_data.operation_Act_Info.dicOperation[i].id.ToString())) continue;
        //        if (user_data.operation_Act_Info.dicOperation[i].remaining_time < 0)
        //        {
        //            user_data.operation_Act_Info.Finish(user_data.operation_Act_Info.dicOperation[i].operation_id);
        //            Data.data[user_data.GameAccount.Base.Accountid].Task.Add(Helper.TaskList.Auto_Loop_Operation_Act); 
        //            //switch (i)
        //            //{
        //            //    case 0:
        //            //        {
        //            //            Data.data[user_data.GameAccount.Base.Accountid].Task.Add(Helper.TaskList.Auto_Loop_Operation_Act1);
        //            //            break;
        //            //        }
        //            //    case 1:
        //            //        {
        //            //            Data.data[user_data.GameAccount.Base.Accountid].Task.Add(Helper.TaskList.Auto_Loop_Operation_Act2);
        //            //            break;
        //            //        }
        //            //    case 2:
        //            //        {
        //            //            Data.data[user_data.GameAccount.Base.Accountid].Task.Add(Helper.TaskList.Auto_Loop_Operation_Act3);
        //            //            break;
        //            //        }
        //            //    case 3:
        //            //        {
        //            //            Data.data[user_data.GameAccount.Base.Accountid].Task.Add(Helper.TaskList.Auto_Loop_Operation_Act4);
        //            //            break;
        //            //        }
        //            //    default:
        //            //        break;
        //            //}

        //        }

        //    }
        //}

        public static void ClickKalina(UserData userData)
        {
            if (userData.kalina_with_user_info.click_num < 5)
            {
                userData.Task.Add(Helper.TaskList.Click_Kalina);

                userData.kalina_with_user_info.click_num++;
            }
        }

        public static void ClickGirlsFavor(UserData userData)
        {
            if (!userData.others.ClickGrilsFavor) return;
            foreach (var k in userData.Teams)
            {
                foreach (var x in k.Value)
                {
                    if (x.Value.can_click == 1)
                    {
                        userData.Task.Add(Helper.TaskList.Click_Girls_In_Dorm);
                        userData.others.ClickGrilsFavor = false;
                        return;
                    }
                }
            }
            userData.others.ClickGrilsFavor = false;

        }


        /// <summary>
        /// 每隔一小时登陆一次
        /// </summary>
        public static void DailyReFlash(UserData userData)
        {
            if (userData.GameAccount.tomorrow_zero == 0) return;

            if (userData.config.AutoRelogin && DateTime.Now.Minute == 35 && DateTime.Now.Second == 1)
            {
                userData.GameAccount.tomorrow_zero = 2101948800;
                userData.config.AutoRelogin = false;
                userData.Task.Add(Helper.TaskList.Login);
            }
            return;
        }

        public static void Auto_Get_Battary(UserData userData)
        {
            DateTime BeijingTimeNow = Helper.Decrypt.LocalDateTimeConvertToChina(DateTime.Now);


            //3点
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 3 + 1) && userData.config.Time3AddGetFriendBattery == true)
            {
                userData.Task.Add(Helper.TaskList.Get_Battary_Friend);
                userData.config.Time3AddGetFriendBattery = false;
            }
            else
            {
                if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 3 + 1)
                    userData.config.Time3AddGetFriendBattery = true;
            }

            //11点
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 15 + 1) && userData.config.Time15AddGetFriendBattery == true)
            {
                userData.Task.Add(Helper.TaskList.Get_Battary_Friend);

                userData.config.Time15AddGetFriendBattery = false;
            }
            else
            {
                if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 15 + 1)
                    userData.config.Time3AddGetFriendBattery = true;
            }

            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 11 + 1) && userData.config.Time11AddGetMineBattery == true)
            {
                userData.Task.Add(Helper.TaskList.Get_Dorm_Info);
                userData.Task.Add(Helper.TaskList.Get_Battary_Mine);
                userData.config.Time11AddGetMineBattery = false;
            }
            else
            {
                if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 11 + 1)
                    userData.config.Time11AddGetMineBattery = true;
            }

            //17点
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 17 + 1) && userData.config.Time17AddGetFriendBattery == true)
            {

                userData.Task.Add(Helper.TaskList.Get_Dorm_Info);
                userData.Task.Add(Helper.TaskList.Get_Battary_Mine);
                userData.config.Time17AddGetFriendBattery = false;
            }
            else
            {
                if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 17 + 1)
                    userData.config.Time17AddGetFriendBattery = true;
            }
        }

        public static void BP_Recover(UserData userData)
        {
            if (userData.user_Info.bp >= 6)
            {
                return;
            }


            if ((userData.user_Info.last_bp_recover_time + 7200 + 600) < (Helper.Decrypt.ConvertDateTime_China_Int(DateTime.Now)))//600是延迟10分钟
            {
                //如果上次恢复时间到现在当前时间差距大于两个小时 则 发送请求 
                userData.Task.Add(Helper.TaskList.GetRecoverBp);
                userData.user_Info.last_bp_recover_time = Helper.Decrypt.ConvertDateTime_China_Int(DateTime.Now);
            }

        }

        private static void WriteReport_Start(UserData userData)
        {
            if (userData.others.Battery() < 1000) return;
            if (userData.others.GlobalFreeExp < userData.outhouse_Establish_Info.Furniture_database) return;
            if (userData.BattleReport.Start_add == true) return;
            if (userData.BattleReport.time > 0) return;
            userData.Task.Add(Helper.TaskList.BattleReport_Write);
            userData.BattleReport.Start_add = true;
            userData.BattleReport.Finish_add = false;
            userData.BattleReport.StartTime = Helper.Decrypt.ConvertDateTime_China_Int(DateTime.Now);
        }
        private static void WriteReport_Finish(UserData userData)
        {
            if (userData.BattleReport.Finish_add == true) return;
            if (userData.BattleReport.time > 0) return;
            userData.Task.Add(Helper.TaskList.BattleReport_Finish);
            userData.BattleReport.Finish_add = true;
            userData.BattleReport.Start_add = false;

        }

        public static void Auto_Simulation_Battle(UserData userData)
        {
            if (userData.config.AutoSimulationBattleF == false) return;
            //决定哪种模式
            int day = (int)Helper.Decrypt.LocalDateTimeConvertToChina(DateTime.Now).DayOfWeek;
            if (day == 3 || day == 4)
            {
                if (userData.user_Info.bp >= 5)
                {
                    userData.Task.Add(Helper.TaskList.Start_Trial);
                    userData.user_Info.bp -= 5;
                }
            }

            if (day == 1 || day == 6)
            {
                if (userData.user_Info.bp >= 3)
                {
                    userData.Task.Add(Helper.TaskList.Simulation_Corridor);
                    userData.user_Info.bp -= 3;
                }
            }


            if (day == 2 || day == 5 || day == 0)
            {
                switch (userData.user_Info.GetSimulationType())
                {
                    case 1:
                        {
                            if (userData.user_Info.bp >= 1)
                            {
                                userData.Task.Add(Helper.TaskList.Simulation_DATA);
                                userData.user_Info.bp -= 1;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (userData.user_Info.bp >= 2)
                            {
                                userData.Task.Add(Helper.TaskList.Simulation_DATA);
                                userData.user_Info.bp -= 2;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (userData.user_Info.bp >= 3)
                            {
                                userData.Task.Add(Helper.TaskList.Simulation_DATA);
                                userData.user_Info.bp -= 3;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }


        }













    }






























}

using Codeplex.Data;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GFHelp.Core.Action
{
    public class Dorm
    {
        public static void ClickGirlsFavor(UserData userData)
        {
            //编列梯队列表
            //梯队内人形can_click ==1 则发送post
            //根据result can_click +1;

            for (int x = 1; x <=userData.Teams.Count; x++)
            {
                if (userData.Teams[x].Count == 0) continue;
                for (int y = 1; y <= userData.Teams[x].Count; y++)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(userData.Teams[x][y].location.ToString())) continue;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (userData.Teams[x][y].can_click == 1)
                    {
                        bool Loop = true;
                        int count = 0;
                        while (Loop)
                        {
                            string result = API.Dorm.ClickGirlsFavor(userData.GameAccount, x, userData.Teams[x][y].id);
                            switch (Helper.Response.Check(userData.GameAccount, ref result, "ClickGirlsFavor", true))
                            {
                                case 1:
                                    {
                                        var jsonobj = DynamicJson.Parse(result);
                                        result = jsonobj.favor_click.ToString();
                                        userData.webData.StatusBarText = String.Format(" 第 {0} 宿舍 少女 {1} 好感度提升 result = {2}", x, userData.Teams[x][y].gun_id.ToString(), result);
                                        userData.Teams[x][y].can_click++;
                                        Loop = false;
                                        break;
                                    }
                                case 0:
                                    {
                                        if (count++ >= userData.config.ErrorCount) break;
                                        break;
                                    }
                                case -1:
                                    {
                                        if (count++ >= userData.config.ErrorCount) break;
                                        break;
                                    }
                                default:break;
                            }
                        }
                    }
                }
            }

        }

        private static int GetFriendBatteryNum(UserData userData,int id)
        {
            int count = 0;
            while (true)
            {
                var result = API.Dorm.Get_Friend_BattaryNum(userData.GameAccount, id);
                switch (Helper.Response.Check(userData.GameAccount, ref result, "Get_Friend_BattaryNum", true))
                {
                    case 1:
                        {
                            var jsonobj = DynamicJson.Parse(result);
                            return Convert.ToInt32(jsonobj.build_coin_flag.ToString());

                        }
                    case 0:
                        {
                            if (count++ >= userData.config.ErrorCount) return 0;
                            continue;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount) return 0;
                            continue;
                        }
                    default: break;
                }
            }
        }
        private static bool GetFriendBattery(UserData userData, int id)
        {
            int count = 0;
            while (true)
            {
                var result = API.Dorm.Get_Friend_Battary(userData.GameAccount, id, 0);
                switch (Helper.Response.Check(userData.GameAccount, ref result, "Get_Friend_Battary", true))
                {
                    case 1:
                        {
                            userData.Dorm_Rest_Friend_Build_Coin_Count--;
                            return true;
                        }
                    case 0:
                        {
                            if (count++ >= userData.config.ErrorCount) return false;
                            continue;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount) return false;
                            continue;
                        }
                    default: break;
                }
            }
        }

        public static void VisitFriendDorm(UserData userData)
        {
            int BattaryNum = 10;
            foreach (var item in userData.friend_with_user_info.dicFriend)
            {
                int Friend_BattaryNum = GetFriendBatteryNum(userData, item.Value.f_userid);
                new Helper.Log().userInit(userData.GameAccount.Base.GameAccountID, String.Format(" 好友 {0} 宿舍  拥有电池数 {1} 意不意外 惊不惊喜", item.Value.name.ToString(), Friend_BattaryNum)).userInfo();
                if (Friend_BattaryNum == BattaryNum)
                {
                    GetFriendBattery(userData,item.Value.f_userid);
                    userData.Dorm_Rest_Friend_Build_Coin_Count--;
                    new Helper.Log().userInit(userData.GameAccount.Base.GameAccountID, String.Format(" 获取好友 {0} 宿舍的电池 数目: {1} ", item.Value.name.ToString(), Friend_BattaryNum)).userInfo();
                }
                if (userData.Dorm_Rest_Friend_Build_Coin_Count == 0) return;
            }
        }

        public static void Get_Build_Coin(UserData userData)
        {
            try
            {
                if (userData.dorm_with_user_info.current_build_coin <= 0) return;
                //开始获得
                userData.dorm_with_user_info.current_build_coin = 0;
                int count = 0;
                while (true)
                {
                    string result = API.Dorm.Get_Build_Coin(userData.GameAccount,userData.dorm_with_user_info.info.user_id, userData.dorm_with_user_info.info.dorm_id);

                    switch (Helper.Response.Check(userData.GameAccount,ref result, "Get_Friend_Build_Coin_Pro", true))
                    {
                        case 1:
                            {
                                return;
                            }
                        case 0:
                            {
                                if (count++ >= userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "获取电池出错", result.ToString()).userInfo();
                                    return;
                                }
                                break;
                            }
                        case -1:
                            {
                                if (count++ >= userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.Base.GameAccountID, " 获取电池出错", result.ToString()).userInfo();
                                    return;
                                }
                                break;
                            }
                        default:
                            break;
                    }

                }

            }
            catch (Exception)
            {
                return;
            }
        }

        public static void Get_Dorm_Info(UserData userData)
        {
            try
            {
                int count = 0;
                while (true)
                {
                    string result = API.Dorm.GetFriend_DormInfo(userData.GameAccount);

                    switch (Helper.Response.Check(userData.GameAccount,ref result, "GetFriend_DormInfo_Pro", true))
                    {
                        case 1:
                            {
                                var jsonobj = DynamicJson.Parse(result);
                                userData.dorm_with_user_info.Read(jsonobj);
                                return;
                            }
                        case 0:
                            {
                                if (count++ >= userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "获取电池出错", result).userInfo();
                                    return;
                                }
                                break;
                            }
                        case -1:
                            {
                                if (count++ >= userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "获取宿舍信息出错", result).userInfo();
                                    return;
                                }
                                break;
                            }
                        default:
                            break;
                    }

                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void WriteReport(UserData userData)
        {
            //userData.battle.Establish_Build();


            userData.webData.StatusBarText = "开始作战报告书";
            Thread.Sleep(1000);

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

            jsonWriter.WriteObjectEnd();
            bool Loop = true;
            while (Loop)
            {
                string result = API.Dorm.Establish_Build(userData.GameAccount,sb.ToString());

                switch (Helper.Response.Check(userData.GameAccount,ref result, "Establish_Build", true))
                {
                    case 1:
                        {
                            Loop = false;
                            break;
                        }
                    case 0:
                        {
                            if (count++ >= userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "编写作战报告书 ERROR", result).userInfo();
                                Loop = false;
                            }
                            break;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "编写作战报告书 ERROR", result).userInfo();
                                Loop = false;
                            }
                            break;
                        }
                    default:
                        break;
                }

            }
            userData.others.DeBattery(userData.outhouse_Establish_Info.Furniture_printer * 3);
            userData.others.GlobalFreeExp = userData.others.GlobalFreeExp - userData.outhouse_Establish_Info.Furniture_printer * 3000;
            userData.BattleReport.StartTime = Helper.Decrypt.ConvertDateTime_China_Int(DateTime.Now);
        }


        public static void WriteReportFinish(UserData userData)
        {
            userData.webData.StatusBarText = "完成作战报告书";
            Thread.Sleep(5000);
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
                string result = API.Dorm.Establish_Build_Finish(userData.GameAccount,sb.ToString());

                switch (Helper.Response.Check(userData.GameAccount, ref result, "Establish_Build_Finish", true))
                {
                    case 1:
                        {
                            return;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "完成作战报告书 ERROR", result).userInfo();
                            }
                            break;
                        }
                    default:
                        break;
                }

            }
        }


        public static void Friend_Praise(UserData userData)
        {

            int f_userid=27755;
            
            for (int i = 0; i < 50; i++)
            {
                bool Loop = true;
                while (Loop)
                {
                    int count = 0;
                    StringBuilder sb = new StringBuilder();
                    JsonWriter jsonWriter = new JsonWriter(sb);
                    jsonWriter.WriteObjectStart();
                    jsonWriter.WritePropertyName("f_userid");
                    jsonWriter.Write(0);
                    jsonWriter.WriteObjectEnd();
                    Thread.Sleep(1500);

                    string result =API.Dorm.Friend_visit(userData.GameAccount,sb.ToString());

                    switch (Helper.Response.Check(userData.GameAccount, ref result, "Friend_visit", true))
                    {
                        case 1:
                            {
                                var jsonobj = DynamicJson.Parse(result);
                                f_userid = Convert.ToInt32(jsonobj.info.f_userid);
                                userData.webData.StatusBarText = String.Format(" 访问 f_userid = {0} 当前次数 {1}", f_userid, i + 1);
                                Loop = false;
                                break;

                            }
                        case 0:
                            {
                                continue;

                            }
                        case -1:
                            {
                                if(count++ > userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "FriendPraise ERROR", result).userInfo();
                                    Loop = false;
                                }
                                break;
                            }
                        default:
                            break;
                    }

                }
                Loop = true;
                
                while (Loop)
                {
                    int count = 0;
                    StringBuilder sb = new StringBuilder();
                    JsonWriter jsonWriter = new JsonWriter(sb);
                    jsonWriter.WriteObjectStart();
                    jsonWriter.WritePropertyName("f_userid");
                    jsonWriter.Write(f_userid);
                    jsonWriter.WriteObjectEnd();
                    Thread.Sleep(1500);
                    userData.webData.StatusBarText = String.Format(" 点赞 f_userid = {0},当前次数 {1}", f_userid, i + 1);




                    string result = API.Dorm.Friend_praise(userData.GameAccount,sb.ToString());

                    switch (Helper.Response.Check(userData.GameAccount, ref result, "Friend_praise", true))
                    {
                        case 1:
                            {
                                Loop = false;
                                break;
                            }
                        case 0:
                            {
                                Loop = false;
                                break;
                            }
                        case -1:
                            {
                                if (count++ > userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "FriendPraise ERROR", result).userInfo();

                                    Loop = false;
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
}

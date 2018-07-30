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

                    if (userData.Teams[x][y].canClick == 1)
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
                                        userData.Teams[x][y].canClick++;
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

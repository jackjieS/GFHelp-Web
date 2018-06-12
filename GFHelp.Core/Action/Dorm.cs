using Codeplex.Data;
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
                                        if (count >= userData.config.ErrorCount) break;
                                        break;
                                    }
                                case -1:
                                    {
                                        if (count >= userData.config.ErrorCount) break;
                                        break;
                                    }
                                default:break;
                            }
                        }
                    }
                }
            }

        }

        public static void VisitFriendDorm(UserData userData)
        {
            int BattaryNum = 10;

            int LoopTime = 1;
            foreach (var item in userData.friend_with_user_info.dicFriend)
            {
                int count = 0;
                int Friend_BattaryNum = 0;
                bool Loop = true;
                while (Loop)
                {
                    var result = API.Dorm.Get_Friend_BattaryNum(userData.GameAccount, item.Value.f_userid);
                    switch (Helper.Response.Check(userData.GameAccount,ref result, "Get_Friend_BattaryNum", true))
                    {
                        case 1:
                            {
                                var jsonobj = DynamicJson.Parse(result);
                                Friend_BattaryNum= Convert.ToInt32(jsonobj.build_coin_flag.ToString());
                                Loop = false;
                                break;
                            }
                        case 0:
                            {
                                if (count >= userData.config.ErrorCount) break;
                                Loop = false; break;
                            }
                        case -1:
                            {
                                if (count >= userData.config.ErrorCount) break;
                                Loop = false; break;
                            }
                        default:break;
                    }

                }

                userData.webData.StatusBarText = String.Format(" 好友 {0} 宿舍  拥有电池数 {1} 意不意外 惊不惊喜", item.Value.name.ToString(), Friend_BattaryNum);
                if (Friend_BattaryNum == BattaryNum)
                {
                    count = 0;
                    Loop = true;
                    while (Loop)
                    {
                        var result = API.Dorm.Get_Friend_Battary(userData.GameAccount,item.Value.f_userid,0);
                        switch (Helper.Response.Check(userData.GameAccount, ref result, "Get_Friend_Battary", true))
                        {
                            case 1:
                                {
                                    userData.Dorm_Rest_Friend_Build_Coin_Count--;
                                    Loop = false;
                                    break;
                                }
                            case 0:
                                {
                                    if (count >= userData.config.ErrorCount) Loop = false;
                                    break;
                                }
                            case -1:
                                {
                                    if (count >= userData.config.ErrorCount) Loop = false;
                                    break;
                                }
                            default: break;
                        }
                    }
                    WarningNote note = new WarningNote(1, String.Format(" 获取好友 {0} 宿舍的电池 数目: {1} ", item.Value.name.ToString(), Friend_BattaryNum));
                    userData.warningNotes.Add(note);
                }
                LoopTime++;
                if (userData.Dorm_Rest_Friend_Build_Coin_Count == 0) return;
                if (LoopTime == userData.friend_with_user_info.dicFriend.Count) return;


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
                                if (count >= userData.config.ErrorCount)
                                {
                                    WarningNote note = new WarningNote(1, String.Format(" 获取电池出错"));
                                    userData.warningNotes.Add(note);
                                    return;
                                }
                                break;
                            }
                        case -1:
                            {
                                if (count >= userData.config.ErrorCount)
                                {
                                    WarningNote note = new WarningNote(1, String.Format(" 获取电池出错"));
                                    userData.warningNotes.Add(note);
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
                                if (count >= userData.config.ErrorCount)
                                {
                                    WarningNote note = new WarningNote(1, String.Format(" 获取电池出错"));
                                    userData.warningNotes.Add(note);
                                    return;
                                }
                                break;
                            }
                        case -1:
                            {
                                if (count >= userData.config.ErrorCount)
                                {
                                    WarningNote note = new WarningNote(1, String.Format(" 获取宿舍信息出错"));
                                    userData.warningNotes.Add(note);
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
            //im.action.Establish_Build();


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
                            if (count >= userData.config.ErrorCount)
                            {
                                WarningNote note = new WarningNote(1, String.Format(" 编写作战报告书"));
                                userData.warningNotes.Add(note);
                                Loop = false;
                            }
                            break;
                        }
                    case -1:
                        {
                            if (count >= userData.config.ErrorCount)
                            {
                                WarningNote note = new WarningNote(1, String.Format(" 编写作战报告书"));
                                userData.warningNotes.Add(note);
                                Loop = false;
                            }
                            break;
                        }
                    default:
                        break;
                }

            }
            userData.others.DeBattery(userData.item_With_User_Info, userData.outhouse_Establish_Info.Furniture_printer * 3);
            userData.others.DeGolbalFreeExp(userData.item_With_User_Info, userData.outhouse_Establish_Info.Furniture_printer * 3000);
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
                            if (count >= userData.config.ErrorCount)
                            {
                                WarningNote note = new WarningNote(1, String.Format(" 完成作战报告书"));
                                userData.warningNotes.Add(note);
                                return;
                            }
                            break;
                        }
                    case -1:
                        {
                            if (count >= userData.config.ErrorCount)
                            {
                                WarningNote note = new WarningNote(1, String.Format(" 完成作战报告书"));
                                userData.warningNotes.Add(note);
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

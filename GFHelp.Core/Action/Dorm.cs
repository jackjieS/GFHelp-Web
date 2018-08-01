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
        private UserData userData;
        public Dorm(UserData userData)
        {
            this.userData = userData;
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

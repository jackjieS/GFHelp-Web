using Codeplex.Data;

using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//向網頁傳輸數據一個錯誤窗口之類的
namespace GFHelp.Core.Action
{
    public class Home
    {
        public static bool Login(UserData userData)
        {
            if (string.IsNullOrEmpty(userData.GameAccount.Base.YunDouDou))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "数字天空登陆", "").userInfo();
                userData.webData.StatusBarText = "数字天空登陆";
                if (!LoginDigitalSKY(userData)) return false;
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "获取时间信息", "").userInfo();
                userData.webData.StatusBarText = "获取时间信息";
                if (!Index_version(userData)) return false;
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "获取Sign", "").userInfo();
                userData.webData.StatusBarText = "获取Sign";
                if (!GetDigitalUid(userData)) return false;
            }
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "获取UserInfo", "").userInfo();
            userData.webData.StatusBarText = "获取UserInfo";
            if (!GetUserInfo(userData)) return false;
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "签到", "").userInfo();
            userData.webData.StatusBarText = "签到";

            if (!Attendance(userData)) return false;
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "查询新邮件", "").userInfo();
            userData.webData.StatusBarText = "查询新邮件";
            Mail(userData);
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "终止作战", "").userInfo();
            userData.webData.StatusBarText = "终止作战";
            userData.battle.Abort_Mission_login();
            userData.config.AutoRelogin = true;
            userData.config.LoginSuccessful = true;//开始自动任务循环
            return true;
        }






        public static bool GetUserInfo(UserData userData)
        {

            string result = _GetUserInfo(userData);
            if (result.Contains("error")) return false;
            var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了
            userData.Read(jsonobj);
            return true;
        }


        private static string _GetUserInfo(UserData userData)
        {

            int count = 0;
            while (true)
            {
                string result = API.Home.GetUserInfo(userData.GameAccount);

                switch (Response.Check(userData.GameAccount, ref result, "GetUserInfo", false))
                {
                    case 1:
                        {
                            userData.webData.StatusBarText = "登陆成功";
                            return result;
                        }
                    case 0:
                        {
                            //result_error_PRO(result, count++); continue;
                            continue;
                        }
                    case -1:
                        {
                            count++;
                            if (count >= userData.config.ErrorCount) return "error";
                            continue;
                        }
                    default:
                        break;
                }
            }

        }


        private static String StringBuilder_(IDictionary<string, string> parameters)
        {
            StringBuilder buffer = new StringBuilder();
            if (!(parameters == null || parameters.Count == 0))
            {
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
            }
            return buffer.ToString();
        }

        private static bool LoginDigitalSKY(UserData userdata)
        {
            int count = 0;
            while (true)
            {
                string result = API.Login.Digitalsky(userdata.GameAccount);
                if (Response.Check(userdata.GameAccount, ref result, "LoginFirstUrl", false) == 1)
                {
                    var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了
                    userdata.GameAccount.access_token = jsonobj.access_token.ToString();
                    userdata.GameAccount.openid = jsonobj.openid.ToString();
                    return true;
                }
                if (Response.Check(userdata.GameAccount, ref result, "LoginFirstUrl", false) == 0)
                {
                    new Log().systemInit(result.ToString(), "").coreError();
                    continue;
                }
                if (Response.Check(userdata.GameAccount, ref result, "LoginFirstUrl", false) == -1)
                {
                    count++;
                    if (count >= userdata.config.ErrorCount)
                    {
                        new Log().systemInit("LoginDigitalSKY", result.ToString()).coreError();
                        new Log().userInit(userdata.GameAccount.Base.GameAccountID, "LoginDigitalSKY", result.ToString()).userInfo();
                        return false;
                    } 
                    continue;
                }

            }




            //Data.data[gameAccount.Base.Accountid].User_info = result;
            //return result;
        }


        public static string Index_version()
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("", "");
            try
            {
                var req_id = Decrypt.ConvertDateTime_China_Int(DateTime.Now);
                parameters.Add("req_id", req_id.ToString());
            }
            catch (Exception e)
            {
                new Log().systemInit("Index_version", e.ToString()).coreError();
            }


            string data = StringBuilder_(parameters);
            string result = "";

            while (true)
            {
                result = API.BaseRequset.DoPost("http://gf-adrgw-cn-zs-game-0001.ppgame.com/index.php/1000/" + URL.Index_version, data.ToString());//明码不需要解密
                if (result.Contains("data_version"))
                {
                    var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了
                    SystemOthers.ConfigData.tomorrow_zero = Convert.ToInt32(jsonobj.tomorrow_zero);
                    SystemOthers.ConfigData.weekday = Convert.ToInt32(jsonobj.weekday);
                    return jsonobj.data_version.ToString(); ;
                }
            }
        }

        private static bool Index_version(UserData userData)//这个API发的是当前时间戳？
        {

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("", "");
            try
            {
                userData.GameAccount.req_id = Decrypt.ConvertDateTime_China_Int(DateTime.Now);
                parameters.Add("req_id", userData.GameAccount.req_id.ToString());
            }
            catch (Exception e)
            {
                new Log().systemInit("Index_version", e.ToString()).coreError();

            }


            string data = StringBuilder_(parameters);
            string result = "";
            int count = 0;
            while (true)
            {
                result = API.BaseRequset.DoPost(userData.GameAccount.GameHost + URL.Index_version, data.ToString());//明码不需要解密
                if (Response.Check(userData.GameAccount, ref result, "Index_version", false) == 1)
                {
                    var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了
                    userData.GameAccount.loginTime = Convert.ToInt32(jsonobj.now);
                    userData.GameAccount.CatchDataVersion = jsonobj.data_version.ToString();
                    SystemOthers.ConfigData.DataVersion = userData.GameAccount.CatchDataVersion;
                    userData.GameAccount.tomorrow_zero = Convert.ToInt32(jsonobj.tomorrow_zero);
                    userData.GameAccount.weekday = Convert.ToInt32(jsonobj.weekday);
                    return true;
                }
                if (Response.Check(userData.GameAccount, ref result, "Index_version", false) == 0) { continue; }
                if (Response.Check(userData.GameAccount, ref result, "Index_version", false) == -1)
                {
                    count++;
                    if (count >= userData.config.ErrorCount) return false;
                    continue; /*特殊处理我还没想好*/;
                }
            }
        }

        private static bool GetDigitalUid(UserData userData)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("openid", userData.GameAccount.openid);
            parameters.Add("access_token", userData.GameAccount.access_token);
            parameters.Add("app_id", "0002000100021001");
            parameters.Add("channelid", userData.GameAccount.Base.ChannelID);
            parameters.Add("idfa", "");
            parameters.Add("androidid", userData.GameAccount.Base.AndroidID);
            parameters.Add("mac", userData.GameAccount.Base.MAC);
            parameters.Add("req_id", userData.GameAccount.req_id++.ToString());

            string data = StringBuilder_(parameters);

            string result = "";
            int count = 0;
            while (true)
            {
                result = API.BaseRequset.GetDigitalUid(userData.GameAccount, data);

                switch (Response.Check(userData.GameAccount, ref result, "GetDigitalUid_Pro", false))
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
                            count++;
                            if (count >= userData.config.ErrorCount) return false;
                            continue;
                        }
                    default:
                        break;
                }
            }
        }

        private static bool Attendance(UserData userData)
        {
            if (Decrypt.ConvertDateTime_China_Int(DateTime.Now) >userData.user_Record.attendance_type1_time)
            {
                API.Home.Attendance(userData.GameAccount);
            }
            return true;
        }

        /// <summary>
        /// Mail只处理签到信息
        /// 可能会处理友情点 资源
        /// </summary>
        public static void Mail(UserData userData)
        {
            var jsonobj = DynamicJson.Parse("");
            bool Loop = true;
            int count = 0;
            string result = "";
            while (Loop)
            {
                result = API.Home.ifNewMail(userData.GameAccount);
                switch (Response.Check(userData.GameAccount, ref result, "ifNewMail", true))
                {
                    case 1:
                        {
                            jsonobj = DynamicJson.Parse(result);
                            Loop = false;
                            break;
                        }
                    case 0:
                        {

                            break;
                        }
                    case -1:
                        {
                            if(count++ > userData.config.ErrorCount)
                            {
                                new Log().systemInit("Mail", result.ToString()).coreError();
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "Mail", result.ToString()).userInfo();
                                return;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            Loop = true;
            if (jsonobj.if_new_mail == true)
            {
                //如果有 就发送


                while (Loop)
                {
                    //titleGetMailList
                    result = API.Home.GetMailList(userData.GameAccount);
                    switch (Response.Check(userData.GameAccount, ref result, "GetMailList", true))
                    {
                        case 1:
                            {
                                jsonobj = DynamicJson.Parse(result);
                                Loop = false;
                                break;
                            }
                        case 0:
                            {
                                break;
                            }
                        case -1:
                            {
                                if (count++ > userData.config.ErrorCount)
                                {
                                    new Log().systemInit("GetMail", result.ToString()).coreError();
                                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "GetMail", result.ToString()).userInfo();
                                    return;
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }


                userData.mailList.Read(jsonobj);

                //根据是否有邮件签到
                //type 5 可能是签到
                int x = 0; string gun_id = "";

                while (userData.mailList.dicMail.Count>0)
                {

                    int mailwith_user_id = userData.mailList.dicMail[x].id;
                    userData.webData.StatusBarText = String.Format(" 开始接收邮件 邮件ID: {0} ,邮件剩余数量 : {1} ", userData.mailList.dicMail[x].id,userData.mailList.dicMail.Count);

                    result = API.Home.GetOneMail_Type1(userData.GameAccount,mailwith_user_id);
                    if(Response.Check(userData.GameAccount, ref result, "GetMail_Content_Pro", true)==1)
                    {
                        jsonobj = DynamicJson.Parse(result);
                        string title =CatchData.Base.Asset_Textes.ChangeCodeFromeCSV(Response.UnicodeToString(jsonobj.title.ToString()));
                        string content = CatchData.Base.Asset_Textes.ChangeCodeFromeCSV(Response.UnicodeToString(jsonobj.content.ToString()));
                        //输出日志
                    }


                    //这里检查新枪
                    jsonobj = DynamicJson.Parse(result);
                    if (result.Contains("gun_id") || result.Contains("equip_ids"))
                    {
                        gun_id = jsonobj.gun_id.ToString();
                    }
                    result = API.Home.GetMailResource_Type1(userData.GameAccount, mailwith_user_id);
                    if (result.Contains("gun_with_user_id") || result.Contains("equip_with_user_id"))
                    {
                        userData.battle.Add_Get_Gun_Equip_Battle(int.Parse(gun_id), result);
                    }

                    userData.mailList.dicMail.Remove(x++);
                }





            }


        }

        public static void changeLock(UserData userData, List<int> listlockid, List<int> listUnlockid)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("lock");
            jsonWriter.WriteArrayStart();
            foreach (long current2 in listlockid)
            {
                jsonWriter.Write(current2);
            }
            jsonWriter.WriteArrayEnd();
            jsonWriter.WritePropertyName("unlock");
            jsonWriter.WriteArrayStart();
            foreach (long current3 in listUnlockid)
            {
                jsonWriter.Write(current3);
            }
            jsonWriter.WriteArrayEnd();
            jsonWriter.WriteObjectEnd();




            int count = 0;
            while (true)
            {
                string result =API.Home.ChangeLockStatus(userData.GameAccount,sb.ToString());

                switch (Response.Check(userData.GameAccount, ref result, "GUN_OUTandIN_Team_PRO", false))
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
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "锁 失败", result.ToString()).userInfo();
                                return;
                            }
                            continue;
                        }
                    default:
                        break;
                }


            }
        }



    }
}

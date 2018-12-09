using Codeplex.Data;

using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//向網頁傳輸數據一個錯誤窗口之類的
namespace GFHelp.Core.Action
{
    public class Home
    {
        private UserData userData;
        public Home(UserData userData)
        {
            this.userData = userData;
        }
        public bool Login()
        {

            if (string.IsNullOrEmpty(userData.GameAccount.YunDouDou))
            {
                userData.webData.StatusBarText = "获取时间信息";
                if (!Index_version())
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "获取时间信息失败", "").userInfo();
                    return false;
                }

                userData.webData.StatusBarText = "游戏登陆";
                GFLogin.LoginManager login = new GFLogin.LoginManager().setAccountID(userData.GameAccount.GameAccountID).setPWD(userData.GameAccount.GamePassword).setChannelID(userData.GameAccount.ChannelID);
                login.Login();
                if (login.isSuccessLogin)
                {
                    userData.GameAccount.YunDouDou = login.EncryptResult;
                }
                else
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "数字天空登陆失败", "").userInfo();
                    return false;
                }


            }

            //userData.GameAccount.req_id = Decrypt.ConvertDateTime_China_Int(DateTime.Now);
            if (Response.Check(userData.GameAccount, ref userData.GameAccount.YunDouDou, "GetDigitalUid_Pro", false) != 1) return false;

            userData.webData.StatusBarText = "获取UserInfo";
            if (!GetUserInfo())
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "获取UserInfo失败", "").userInfo();
                return false;
            }

            userData.webData.StatusBarText = "签到";

            if (!Attendance())
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "签到失败", "").userInfo();
                return false;
            } 

            userData.webData.StatusBarText = "查询新邮件";
            Mail();
            userData.battle.Abort_Mission_login();
            userData.config.LoginSuccessful = true;//开始自动任务循环
            return true;
        }

        public bool GetUserInfo()
        {
            userData.webData.StatusBarText = "开始游戏登陆";
            string result = _GetUserInfo();
            if (result.Contains("error")) return false;
            var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了
            JsonData jsonData = JsonMapper.ToObject(result);
            userData.Read(jsonobj, jsonData);

            userData.webData.StatusBarText = "查询新邮件";
            Mail();



            return true;
        }


        private string _GetUserInfo()
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

                            if (count++ >= userData.config.ErrorCount)
                            {
                                userData.webData.StatusBarText = "登陆失败";
                                return "error";
                            }
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



        public  bool Index_version()//这个API发的是当前时间戳？
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
                    if (count++ >= userData.config.ErrorCount) return false;
                    continue; /*特殊处理我还没想好*/;
                }
            }
        }
        public static string Index_version(bool a)//这个API发的是当前时间戳？
        {

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("", "");
            try
            {
                parameters.Add("req_id", Decrypt.ConvertDateTime_China_Int(DateTime.Now).ToString());
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
                result = API.BaseRequset.DoPost("http://gf-adrgw-cn-zs-game-0001.ppgame.com/index.php/1000/" + URL.Index_version, data.ToString());
                if (Response.Check(ref result, "Index_version") == 1)
                {
                    var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了
                    return jsonobj.data_version.ToString(); 
                }
                if (Response.Check(ref result, "Index_version") == 0) { continue; }
                if (Response.Check(ref result, "Index_version") == -1)
                {
                    if (count++ >= 2) return "";
                    continue; /*特殊处理我还没想好*/;
                }
            }
        }






        private bool Attendance()
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
        public void Mail()
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
                                new Log().userInit(userData.GameAccount.GameAccountID, "Mail", result.ToString()).userInfo();
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
                                    new Log().userInit(userData.GameAccount.GameAccountID, "GetMail", result.ToString()).userInfo();
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
                        new Log().userInit(userData.GameAccount.GameAccountID, string.Format("获取邮件 标题 {0} 内容 {1}", title, content)).userInfo();
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

        public void changeLock(List<int> listlockid, List<int> listUnlockid)
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
                                new Log().userInit(userData.GameAccount.GameAccountID, "锁 失败", result.ToString()).userInfo();
                                return;
                            }
                            continue;
                        }
                    default:
                        break;
                }


            }
        }

        public void Click_Kalina()
        {
            if (userData.kalina_with_user_info.click_num < 5)
            {
                string result = API.Kalina.Click_kalinaFavor(userData.GameAccount);
                if (result.Contains("1"))
                {
                    userData.webData.StatusBarText = String.Format(" Kalina好感度 + 1 ");
                    userData.kalina_with_user_info.click_num++;
                }
            }
        }
        public void ClickGirlsFavor()
        {
            if (!userData.others.ClickGrilsFavor) return;
            foreach (var k in userData.Teams)
            {
                foreach (var x in k.Value)
                {
                    if (x.Value.canClick == 1)
                    {
                        userData.dorm_with_user_info.ClickGirlsFavor();
                        userData.others.ClickGrilsFavor = false;
                        return;
                    }
                }
            }
            userData.others.ClickGrilsFavor = false;
        }
        public void DailyReFlash()
        {
            if (userData.GameAccount.tomorrow_zero == 0) return;

            if (DateTime.Now.Minute == 35 && DateTime.Now.Second == 1)
            {
                userData.GameAccount.tomorrow_zero = 2101948800;
                Thread.Sleep(1000);
                userData.eventAction.Login();
            }
            return;
        }





    }
}

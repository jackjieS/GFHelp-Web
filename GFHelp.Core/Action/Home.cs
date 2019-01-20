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
                try
                {
                    login.Login();
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, e.ToString(), e.ToString()).userInfo();
                    return false;
                }


                if (login.isSuccessLogin)
                {
                    Response.Check(userData.GameAccount, ref login.EncryptResult, "GetDigitalUid_Pro", false);
                }
                else
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "数字天空登陆失败", "").userInfo();
                    return false;
                }
            }
            else
            {
                Response.Check(userData.GameAccount, ref userData.GameAccount.YunDouDou, "GetDigitalUid_Pro", false);
            }




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

            userData.mailList.MailHandle();
            userData.battle.Abort_Mission_login();

            DailyTask();

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
                    userData.GameAccount.data_version = jsonobj.data_version.ToString();
                    userData.GameAccount.ab_version = jsonobj.ab_version.ToString();



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


        private void DailyTask()
        {
            if (!userData.config.AutoTaskDaily) return;
            userData.webData.StatusBarText = "获取每日任务";
            string result = API.Home.GetDailyTask(userData.GameAccount);
            if (Response.Check(userData.GameAccount, ref result, "GetDailyTask", true) != 1) return;
            userData.task_Daily.ReadTask_Daily(JsonMapper.ToObject(result));
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
                Thread.Sleep(userData.random.Next(3,9)*100);
                new Log().userInit(userData.GameAccount.GameAccountID,string.Format("{0} 登陆",DateTime.Now.ToString())).userInfo();
                userData.home.Login();
            }
            return;
        }



    }
}

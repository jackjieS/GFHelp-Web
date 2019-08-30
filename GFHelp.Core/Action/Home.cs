using Codeplex.Data;
using GFHelp.Core.API;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using LitJson;
using GFHelp.NetBase;
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
        BaseRequset BaseRequset;
        private UserData userData;
        private Response Response;
        private Random random = new Random();
        private int LoginTime = 20;
        private object Locker = new object();
        public Home(UserData userData)
        {
            this.userData = userData;
            this.LoginTime = random.Next(10, 50);
            this.Response = userData.Response;
            this.BaseRequset = userData.baseRequset;
        }


        public int LoginTest()
        {

            if (string.IsNullOrEmpty(userData.GameAccount.YunDouDou))
            {
                userData.webData.StatusBarText = "获取时间信息";
                if (!Index_version())
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "获取时间信息失败", "").userInfo();
                    return -1;
                }

                userData.webData.StatusBarText = "游戏登陆";
                GFLogin.LoginManager login = new GFLogin.LoginManager().setAccountID(userData.GameAccount.GameAccountID).setPWD(userData.GameAccount.GamePassword).setChannelID(userData.GameAccount.ChannelID);
                try
                {
                    login.Login();
                }
                catch (Exception e)
                {

                    return -1;
                }


                if (login.isSuccessLogin)
                {
                    Response.Check(ref login.EncryptResult, "GetDigitalUid_Pro", false);
                }
                else
                {

                    return -1;
                }
            }
            else
            {

            }





            string result = _GetUserInfo();
            if (result.Contains("error")) return 0;
            var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了
            userData.user_Info.Read(jsonobj);

            //写账号 删用户

            return userData.user_Info.gem;


        }

        public bool SecondLogin()
        {
            if (!GetUserInfo())
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "获取UserInfo失败", "").userInfo();
                return false;
            }
            if (!Attendance())
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "签到失败", "").userInfo();
                return false;
            }
            userData.doll_Build.ResourecsCheck();
            userData.others.Minit();

            userData.dailyReFlash.dateTime = DateTime.Now;
            userData.webData.StatusBarText = "空闲";
            return true;
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

                userData.webData.StatusBarText = "散爆登陆";
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
                    Response.Check(ref login.EncryptResult, "GetDigitalUid_Pro", false);
                }
                else
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "数字天空登陆失败", "").userInfo();
                    return false;
                }
            }
            else
            {
                Response.Check(ref userData.GameAccount.YunDouDou, "GetDigitalUid_Pro", false);
            }
            userData.config.FirstTimeLoginSuccess = true;



            if (!GetUserInfo())
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "获取UserInfo失败", "").userInfo();
                return false;
            }
            if (!Attendance())
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "签到失败", "").userInfo();
                return false;
            }

            userData.doll_Build.ResourecsCheck();
            userData.others.Minit();
            userData.dailyReFlash.dateTime = DateTime.Now;
            userData.webData.StatusBarText = "空闲";
            userData.dailyReFlash.Auto_Act_Summery();
            return true;
        }

        public bool GetUserInfo()
        {

            string result = _GetUserInfo();
            if (result.Contains("error"))
            {
                return false;
            }
            try
            {
                var jsonobj =  DynamicJson.Parse(result); //讲道理，我真不想写了
                JsonData jsonData = JsonMapper.ToObject(result);
                userData.Read(jsonobj, jsonData);
            }
            catch (Exception)
            {
                return false;
            }

            if (userData.config.FinalLoginSuccess)
            {
                userData.mailList.MailHandle();
            }


            return true;
        }


        private string _GetUserInfo()
        {
            userData.webData.StatusBarText = "云母登陆";
            int count = 0;
            while (count++ <= userData.config.ErrorCount)
            {
                string result;
                try
                {
                    dynamic newjson = new DynamicJson();
                    newjson.time = Helper.Decrypt.getDateTime_China_Int(DateTime.Now).ToString();/* 这是值*/
                    newjson.furniture_data = "false";/* 这是值*/

                    result = userData.Net.Home.GetUserInfo(userData.GameAccount, newjson.ToString());
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "GetUserInfo Failed ", e.ToString()).userInfo();
                    return "error";
                }

                if (Response.Check(ref result, "GetUserInfo", true) == 1) return result;

            }
            return "error";
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



        public bool Index_version()//这个API发的是当前时间戳？
        {

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("", "");
            try
            {
                userData.GameAccount.req_id = Decrypt.getDateTime_China_Int(DateTime.Now);
                parameters.Add("req_id", userData.GameAccount.req_id.ToString());
            }
            catch (Exception e)
            {
                new Log().systemInit("Index_version", e.ToString()).coreError();

            }


            string data = StringBuilder_(parameters);
            string result;
            int count = 0;
            while (count++ <= userData.config.ErrorCount)
            {
                var post = BaseRequset.DoPost(userData.GameAccount.GameHost + URL.Index_version, data.ToString());
                result = post;//明码不需要解密
                if (Response.Check(ref result, "Index_version", false) == 1)
                {
                    var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了
                    userData.GameAccount.loginTime = Convert.ToInt32(jsonobj.now);
                    userData.GameAccount.CatchDataVersion = jsonobj.data_version.ToString();
                    userData.GameAccount.data_version = jsonobj.data_version.ToString();
                    userData.GameAccount.ab_version = jsonobj.ab_version.ToString();

                    SystemManager.ConfigData.DataVersion = userData.GameAccount.CatchDataVersion;
                    userData.GameAccount.tomorrow_zero = Convert.ToInt32(jsonobj.tomorrow_zero);
                    userData.GameAccount.weekday = Convert.ToInt32(jsonobj.weekday);
                    return true;
                }
            }
            return false;
        }
        public static string Index_version(bool a)//这个API发的是当前时间戳？
        {

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("", "");
            try
            {
                parameters.Add("req_id", Decrypt.getDateTime_China_Int(DateTime.Now).ToString());
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
                result = BaseRequset.DoPoststatic("http://gf-adrgw-cn-zs-game-0001.ppgame.com/index.php/1000/" + URL.Index_version, data.ToString());
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

            if (Decrypt.getDateTime_China_Int(DateTime.Now) > userData.user_Record.attendance_type1_time)
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "签到", "").userInfo();
                userData.Net.Home.Attendance(userData.GameAccount);
            }
            return true;
        }



        public void changeLock(List<int> listlockid, List<int> listUnlockid)
        {
            Thread.Sleep(2000);
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



            string result;
            int count = 0;
            while (count++ <= userData.config.ErrorCount)
            {
                try
                {
                    result = userData.Net.Home.ChangeLockStatus(userData.GameAccount, sb.ToString());
                }
                catch (Exception)
                {
                    return;
                }
                if (Response.Check(ref result, "GUN_OUTandIN_Team_PRO", false) == 1) { return; }
            }
        }


        public void DailyTask()
        {
            if (!userData.config.AutoTaskDaily) return;
            userData.webData.StatusBarText = "获取每日任务";
            string result = userData.Net.Home.GetDailyTask(userData.GameAccount);
            if (Response.Check(ref result, "GetDailyTask", true) != 1) return;
            userData.task_Daily.ReadTask_Daily(JsonMapper.ToObject(result));
        }

        public void Click_Kalina()
        {
            if (userData.config.M) return;
            while (userData.kalina_with_user_info.click_num++ < 5)
            {
                string result = userData.Net.Kalina.Click_kalinaFavor(userData.GameAccount);
                if (result.Contains("1"))
                {
                    userData.webData.StatusBarText = String.Format(" Kalina好感度 + 1 ");
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










    }
}

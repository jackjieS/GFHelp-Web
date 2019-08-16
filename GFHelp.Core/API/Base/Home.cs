using AC;
using Codeplex.Data;
using GFHelp.Core.Management;
using GFHelp.NetBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.API
{
    public class Home
    {
        BaseRequset BaseRequset;
        MulitePlayerData.AuthCode AuthCode;
        public Home(MulitePlayerData.AuthCode AuthCode, BaseRequset BaseRequset)
        {
            this.AuthCode = AuthCode;
            this.BaseRequset = BaseRequset;
        }
        public string HeartBeatPacket(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.GetQuest;
            while (string.IsNullOrEmpty(result) == true)
            {
                result = BaseRequset.DoPost(url, requeststring);//不需要解密 返回的是签到当月信息奖励
            }
            return result;



        }

        public  string GetDailyTask(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.GetQuest;
            while (string.IsNullOrEmpty(result) == true)
            {
                result =  BaseRequset.DoPost(url, requeststring);//不需要解密 返回的是签到当月信息奖励
            }
            return result;
        }



        public  string GetUserInfo(GameAccount gameAccount,string outdatacode)//api = index/index
        {

            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());

            string result = "";
            var url = gameAccount.GameHost + Helper.URL.GetUserInfo;
            while (string.IsNullOrEmpty(result) == true)
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
        public string Attendance(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.GetAttendance;
            while (string.IsNullOrEmpty(result) == true)
            {
                result =  BaseRequset.DoPost(url, requeststring);//不需要解密 返回的是签到当月信息奖励
            }
            return result;
        }
        public  string ifNewMail(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.CheckNewMail;
            while (string.IsNullOrEmpty(result) == true)
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
        public  string GetMailList(GameAccount gameAccount)
        {
            var obj = new
            {
                startid = 0,
                ignore_time = 1,
            };

            string outdatacode = DynamicJson.Serialize(obj);


            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);//

            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.GetMailList;
            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
        public  string GetOneMail_Type1(GameAccount gameAccount,int mailwith_user_id)
        {
            System.Threading.Thread.Sleep(2500);
            string outdatacode = "{\"mail_with_user_id\":" + mailwith_user_id.ToString() + "}";
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.GetOneMail;
            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }


        public  string GetMailResource(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.GetMailResource;
            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }

        public  string ChangeLockStatus(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.ChangeLockStatus;
            while (string.IsNullOrEmpty(result))
            { result =  BaseRequset.DoPost(url, requeststring); }
            return result;
        }

        public  string getMailList(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.Home;
            while (string.IsNullOrEmpty(result))
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
    }
}

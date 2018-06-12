using AC;
using Codeplex.Data;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.API
{
    public class Dorm
    {
        public static string ClickGirlsFavor(GameAccount gameAccount, int dorm_id, int gun_with_user_id)
        {
            string outdatacode = "{\"dorm_id\":" + dorm_id.ToString() + "," + "\"gun_with_user_id\":" + gun_with_user_id.ToString() + "}";
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string url = gameAccount.GameHost + Helper.URL.Dorm_Receive_Favor;
            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
        public static string Get_Friend_BattaryNum(GameAccount gameAccount,int f_userid)
        {
            System.Threading.Thread.Sleep(2000);
            string outdatacode = "{\"f_userid\":" + f_userid.ToString() + "}";
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string url = gameAccount.GameHost + Helper.URL.Visit_Friend_Build;
            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
        public static string Get_Friend_Battary(GameAccount gameAccount,int v_user_id, int dorm_id)
        {
            System.Threading.Thread.Sleep(2000);
            string outdatacode = "{\"v_user_id\":" + v_user_id.ToString() + "," + "\"dorm_id\":" + dorm_id.ToString() + "}";
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string url = gameAccount.GameHost + Helper.URL.Get_Friend_Build_Coin;
            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }

        public static string Get_Build_Coin(GameAccount gameAccount,string v_user_id, string dorm_id)
        {
            //{"v_user_id":"54634","dorm_id":1}
            string outdatacode = "{\"v_user_id\":" + "\"" + v_user_id + "\"" + "," + "\"dorm_id\":" + dorm_id + "}";
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string url = gameAccount.GameHost + Helper.URL.Get_Friend_Build_Coin;
            string result = BaseRequset.DoPost(url, requeststring);
            return result;
        }
        public static string GetFriend_DormInfo(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string url = gameAccount.GameHost + Helper.URL.Dorm_Info;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }

        public static string Establish_Build(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string url = gameAccount.GameHost + Helper.URL.Establish_Build;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
        public static string Establish_Build_Finish(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string url = gameAccount.GameHost + Helper.URL.Establish_Build_Finish;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }

    }
}

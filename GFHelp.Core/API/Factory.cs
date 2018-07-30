using AC;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.API
{
    class Factory
    {

        public static string Eat_Equip(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.Eat_Equip;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;

        }

        public static string Equip_retire(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.Equip_retire;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }


        public static string combineGun(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.CombineGun;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }

        public static string EatGun(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.EatGun;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }

        public static string Retire_Gun(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.RetireGun;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
    }
}

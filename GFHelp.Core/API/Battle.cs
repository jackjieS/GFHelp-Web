using AC;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.API
{
    class Battle
    {
        public static string abortMission(GameAccount gameAccount)
        {
            string result = "";
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.AbortMission;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string GetRecoverBP(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.RecoverBp;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;

        }

    }
}

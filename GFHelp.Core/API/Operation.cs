using AC;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.API
{
    class Operation
    {
        public static string FinishOperation(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.FinishOperation;
            while (string.IsNullOrEmpty(result) == true)
            {
                result = BaseRequset.DoPost(url, requeststring);//不需要解密
            }
            return result;
        }

        public static string StartOperation(GameAccount gameAccount, string outdatacode)
        {

            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.StartOperation;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }


        public static string AbortOperation(GameAccount gameAccount, string outdatacode)
        {
            //{\"operation_id\":5}
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.AbortOperation;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;

        }


    }
}

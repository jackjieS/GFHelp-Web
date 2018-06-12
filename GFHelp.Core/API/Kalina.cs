﻿using AC;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.API
{
    class Kalina
    {
        public static string Click_kalinaFavor(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            string url = gameAccount.GameHost + Helper.URL.ClickKalina;
            while (string.IsNullOrEmpty(result) == true)
            {
                result = BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
    }
}

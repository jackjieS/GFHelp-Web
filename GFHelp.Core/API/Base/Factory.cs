using AC;
using GFHelp.Core.Management;
using GFHelp.NetBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.API
{
    public class Factory
    {
        BaseRequset BaseRequset;
        MulitePlayerData.AuthCode AuthCode;
        public Factory(MulitePlayerData.AuthCode AuthCode, BaseRequset BaseRequset)
        {
            this.AuthCode = AuthCode;
            this.BaseRequset = BaseRequset;
        }
        public  string Eat_Equip(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.Eat_Equip;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;

        }

        public  string Equip_retire(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.Equip_retire;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }


        public  string combineGun(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.CombineGun;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }

        public  string EatGun(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.EatGun;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }

        public  string Retire_Gun(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.RetireGun;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
        public  string finishEquipDevelop(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.FinishDeveloEquip;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
        public  string finishDollDevelop(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.FinishDevelopGun;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
        public  string startEquipDevelop(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.DevelopEquip;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }
        public  string startDollDevelop(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.DevelopGun;
            string result = "";
            while (string.IsNullOrEmpty(result))
            {
                result =  BaseRequset.DoPost(url, requeststring);
            }
            return result;
        }








    }
}

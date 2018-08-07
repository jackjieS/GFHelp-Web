using AC;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.API
{
    class Battle
    {
        public static string StartTrial(GameAccount gameAccount,string teamids)
        {
            string outdatacode = "{\"team_ids\":" + "\"" + teamids.ToString() + "\"" + "," + "\"battle_team\":" + teamids.ToString() + "}";
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.StartTrial;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string EndTrial(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.EndTrial;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
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
        public static string startMission(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.StartMission;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }

        public static string reinforceTeam(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.ReinforceTeam;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string teamMove(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.MoveTeam;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;

        }
        public static string battleFinish(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.battleFinish;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string withdrawTeam(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.Withdraw;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;

        }

        public static string endTurn(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.EndTurn;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string startTurn(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.StartTurn;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;

        }
        public static string GUN_OUTandIN_Team(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.BuildTeam;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }

        public static string SupplyTeam(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.SupplyTeam;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string setPosition(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.SetPosition;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;

        }

        public static string simulation_DATA(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.coinBattleFinish;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string endEnemyTurn(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.endEnemyTurn;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }

        public static string ChangeLockStatus(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.ChangeLockStatus;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string FairyMissionSkill(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.FairyMissionSkill;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string allyMySideMove(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.allyMySideMove;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string startOtherSideTurn(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.startOtherSideTurn;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string endOtherSideTurn(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.endOtherSideTurn;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string missionGroupReset(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.missionGroupReset;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }

        public static string allyTeamAi(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.allyTeamAi;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public static string saveHostage(GameAccount gameAccount,string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.saveHostage;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }

        public static string Girl_Fix(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.FixGun;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }























    }
}

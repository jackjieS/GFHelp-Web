using AC;
using GFHelp.Core.Management;
using GFHelp.NetBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.API
{
    public class Battle
    {
        BaseRequset BaseRequset;
        MulitePlayerData.AuthCode AuthCode;
        public Battle(MulitePlayerData.AuthCode AuthCode,BaseRequset BaseRequset)
        {
            this.AuthCode = AuthCode;
            this.BaseRequset = BaseRequset;
        }
        public string StartTrial(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.StartTrial;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string EndTrial(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.EndTrial;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string abortMission(GameAccount gameAccount)
        {
            string result = "";
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            var url = gameAccount.GameHost + Helper.URL.AbortMission;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string GetRecoverBP(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.RecoverBp;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string startMission(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.StartMission;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }

        public string reinforceTeam(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.ReinforceTeam;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string teamMove(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.MoveTeam;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;

        }
        public string buildingSkillPerform(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.buildingSkillPerform;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;

        }



        public string intelligencePoint(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.intelligencePoint;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;

        }


        public string battleFinish(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.battleFinish;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string withdrawTeam(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.Withdraw;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;

        }

        public string endTurn(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.EndTurn;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string startTurn(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.StartTurn;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;

        }
        public string BuildTeam(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.BuildTeam;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }

        public string SupplyTeam(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.SupplyTeam;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string setPosition(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.SetPosition;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;

        }

        public string simulation_DATA(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.coinBattleFinish;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string endEnemyTurn(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.endEnemyTurn;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }

        public string ChangeLockStatus(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.ChangeLockStatus;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string FairyMissionSkill(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.FairyMissionSkill;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string allyMySideMove(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.allyMySideMove;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string startOtherSideTurn(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.startOtherSideTurn;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string endOtherSideTurn(GameAccount gameAccount)
        {
            string outdatacode = AuthCode.Encode(gameAccount.sign, gameAccount.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.endOtherSideTurn;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string missionGroupReset(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.missionGroupReset;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }

        public string allyTeamAi(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.allyTeamAi;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }
        public string saveHostage(GameAccount gameAccount, string outdatacode)
        {
            outdatacode = AuthCode.Encode(outdatacode, gameAccount.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", gameAccount.uid, System.Web.HttpUtility.UrlEncode(outdatacode), gameAccount.req_id++.ToString());
            string result = "";
            var url = gameAccount.GameHost + Helper.URL.saveHostage;
            while (string.IsNullOrEmpty(result))
            { result = BaseRequset.DoPost(url, requeststring); }
            return result;
        }

        public string Girl_Fix(GameAccount gameAccount, string outdatacode)
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

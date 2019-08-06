using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.Helper
{
    class URL
    {
        public const string LoginFirstUrl = "http://gf.ppgame.com/interfaces";
        public const string GetDigitalUid = "Index/getDigitalSkyNbUid";
        public const string Index_version = "Index/version";//获取当前时间戳，获取换日时间戳，数据版本 客户端版本 星期几
        public const string AbortAutoMission = "Automission/abortAutomission";
        public const string AbortMission = "Mission/abortMission";
        public const string AbortOperation = "Operation/abortOperation";
        public const string AutoBattle = "Mission/autoBattle";
        public const string battleFinish = "Mission/battleFinish";
        public const string BuildTeam = "Gun/teamGun";
        public const string CDKey = "Index/sendGift";
        public const string ChangeLockStatus = "Gun/changeLock";
        public const string CheckNewMail = "Index/ifNewMail";
        public const string CombineGun = "Gun/combineGun";
        public const string CompleteImmdiately = "Factory/complete";
        public const string DevelopEquip = "Equip/develop";
        public const string DevelopGun = "Gun/developGun";
        public const string EatGun = "Gun/eatGun";
        public const string EndTurn = "Mission/endTurn";
        public const string FinishAutoMission = "Automission/finishAutomission";
        public const string FinishDevelopGun = "Gun/finishDevelop";
        public const string FinishDeveloEquip = "Equip/finishDevelop";
        public const string FinishOperation = "Operation/finishOperation";
        public const string FixFinish = "Gun/fixFinish";
        public const string FixGun = "Gun/fixGuns";
        public const string FormationSupplyGun = "Gun/supplyGun";
        public const string GemBuyConstruction = "Mall/gemToMax";
        public const string GemBuyGiftbag = "Mall/gemToGiftbag";
        public const string GemBuyItem = "Mall/gemToItem";
        public const string MallStaticTables = "Mall/staticTables";
        public const string GemBuyRes = "Mall/gemToResource";
        public const string GetAttendance = "Index/attendance";
        public const string GetIllustratedList = "Index/getGunCollect";
        public const string GetMailList = "Index/getMailList";
        public const string GetMailResource = "Index/getResourceInMail";
        public const string GetMallList = "Mall/constTables";
        public const string GetOneMail = "Index/getOneMail";
        public const string GetQuest = "Index/Quest";
        public const string GetServerTime = "Index/getTime";
        public const string GetUserInfo = "Index/index";
        public const string GetVersion = "Index/getVersion";
        public const string Login = "Index/login";
        public const string MoveTeam = "Mission/teamMove";
        public const string PauseTurn = "Mission/pauseTurnTime";
        public const string QuickDevelopGun = "Gun/quickDevelop";
        public const string QuickFix = "Gun/quickFix";
        public const string ReceiveProduct = "Factory/receive";
        public const string RecoverBp = "Index/recoverBp";
        public const string RecoverResource = "Index/recoverResource";
        public const string ReinforceTeam = "Mission/reinforceTeam";
        public const string RetireGun = "Gun/retireGun";
        public const string RMBBuyConfirm = "Mall/ifAble";
        public const string SetGuideInfo = "Index/guide";
        public const string SetPosition = "Gun/setPosition";
        public const string SetUserName = "Index/setUserName";
        public const string SkillBeginTraining = "Gun/skillUpgrade";
        public const string SkillQuicklyFinish = "Gun/quickUpgrade";
        public const string SkillTrainingFinish = "Gun/finishUpgrade";
        public const string StartAutoMission = "Automission/startAutomission";
        public const string StartMission = "Mission/startMission";
        public const string StartOperation = "Operation/startOperation";
        public const string StartTurn = "Mission/startTurn";
        public const string SupplyTeam = "Mission/supplyTeam";
        public const string UnlockBuildSlot = "Factory/unlockBuildSlot";
        public const string Update = "Index/update";
        public const string UploadUserLog = "Index/logCheatContent";
        public const string Withdraw = "Mission/withdrawTeam";
        public const string StartTrial = "Mission/startTrial";
        public const string EndTrial = "Mission/endTrialExercise";
        public const string coinBattleFinish = "Mission/coinBattleFinish";
        public const string DevelopLog = "Gun/developLog";
        public const string EquipDevelopLog = "Equip/developLog";
        public const string ClickKalina = "Dorm/kalinaFavor";
        public const string Dorm_Receive_Favor = "Dorm/receive_favor";

        public const string Dorm_Info = "Friend/dormInfo";
        public const string Visit_Friend_Build = "Friend/visit";
        public const string Friend_praise = "Friend/praise";
        public const string Get_Friend_Build_Coin = "Dorm/get_build_coin";

        public const string Get_Battaries = "Dorm/get_build_coin";
        public const string Equip_retire = "Equip/retire";
        public const string Eat_Equip = "Equip/eatEquip";

        public const string endEnemyTurn = "Mission/endEnemyTurn";
        public const string eventDraw = "Mission/eventDraw";

        public const string FairyMissionSkill = "Mission/fairySkillPerform";
        public const string Establish_Build = "Outhouse/establish_build";
        public const string Establish_Build_Finish = "Outhouse/establish_build_finish";

        public const string StartEquipDevelop = "Equip/develop";

        public const string allyMySideMove = "Mission/allyMySideMove";
        public const string startOtherSideTurn = "Mission/startOtherSideTurn";
        public const string endOtherSideTurn = "Mission/endOtherSideTurn";
        public const string missionGroupReset = "Mission/missionGroupReset";
        public const string allyTeamAi = "Mission/allyTeamAi";
        public const string saveHostage = "Mission/saveHostage";
        public const string getDataCell = "Dorm/get_data_cell";
        public const string DataAnalysisFinishAll = "Dorm/data_analysis_finish_all";
        public const string DataAnalysis = "Dorm/data_analysis";
        public const string WeeklyShare = "Dorm/share";
        public const string Home = "Index/home";
        public const string intelligencePoint = "Mission/intelligencePoint";
        public const string buildingSkillPerform = "Mission/buildingSkillPerform";


    }

    //    class GameHost
    //    {
    //        public static string Get(string platform,string channelID,string worldID)
    //        {
    //            string GameHost="";

    //            switch (platform.ToLower())
    //            {
    //                case "android":
    //                    {
    //                        if (worldID == "0")
    //                        {
    //                            GameHost = "http://gf-adrgw-cn-zs-game-0001.ppgame.com/index.php/1000/";
    //                        }
    //                        else
    //                        {
    //                            GameHost = "http://s" + worldID + ".gw.gf.ppgame.com/index.php/100" + worldID + "/";

    //                        }
    //                        break;
    //                    }
    //                case "ios":
    //                    {
    //                        GameHost = "http://gf-ios-cn-zs-game-0001.ppgame.com/index.php/3000/";
    //                        break;
    //                    }
    //                default:
    //                    break;
    //            }

    //tx,http://gf-adrtx-cn-zs-game-0001.ppgame.com/index.php/2000/";
    //vivo,http://58.87.102.150/index.php/4000/";
    //bili,http://gf-adrbili-cn-zs-game-0001.ppgame.com/index.php/5000/";
    //360,http://58.87.102.150/index.php/4000/";
    //huawei,http://58.87.102.150/index.php/4000/";
    //sunborn,http://gf-game.sunborngame.com/index.php/1001/";
    //sunbornjp,http://gfjp-game.sunborngame.com/index.php/1001/";
    //oppo,http://58.87.102.150/index.php/4000/";
    //            return GameHost;
    //        }
    //    }
}

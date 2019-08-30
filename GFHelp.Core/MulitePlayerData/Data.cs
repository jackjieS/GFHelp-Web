using GFHelp.Core.Action;
using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.MulitePlayerData;
using GFHelp.Core.MulitePlayerData.WebData;
using GFHelp.NetBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GFHelp.Core.Management
{
    public class gameDatas

    {
        public static object mDataslocker = new object();
        public bool Add(UserData userData)
        {
            lock (mDataslocker)
            {
                if (!mDatas.ContainsKey(userData.GameAccount.GameAccountID))
                {
                    mDatas.Add(userData.GameAccount.GameAccountID, userData);
                    return true;
                }
            }
            return false;

        }
        public int Count
        {
            get
            {


                return mDatas.Count;
            }
        }
        public UserData getDataByID(string ID)
        {

            if (mDatas.ContainsKey(ID))
            {
                return mDatas[ID];
            }
            return null;
        }

        public List<UserData> getDatasByWebID(string WebID)
        {
           return  mDatas.Where(m => m.Value.GameAccount.WebUsername == WebID).Select(k => k.Value).ToList();
        }

        public void PauseById(string ID)
        {
            if (mDatas.ContainsKey(ID))
            {
                mDatas[ID].config.isOffline = true;
            }

        }
        public void RestartById(string ID)
        {
            if (mDatas.ContainsKey(ID))
            {
                mDatas[ID].config.isOffline = false;
            }

        }

        public void RemoveByID(string ID)
        {
            if (mDatas.ContainsKey(ID))
            {
                mDatas.Remove(ID);
            }
            lock (AutoLoop.dicDataLocker)
            {
                AutoLoop.RemoveDic(ID);
            }

        }

        public void RemoveByData(UserData userData)
        {
            var item = mDatas.First(kvp => kvp.Value == userData);
            mDatas.Remove(item.Key);
        }
        public bool ContainsKey(string id)
        {
            return mDatas.ContainsKey(id);
        }

        public List<GameAccount> getGameAccountByName(string name)
        {
            var list =  getDatasByWebID(name);
            return list.Select(o => o.GameAccount).ToList();

        }

        public int getNumOfLoginFalse(string name)
        {
            var list = getDatasByWebID(name);
            return list.Select(o => o.config.FirstTimeLoginSuccess == false).ToList().Count;
        }



        //public IEnumerator<string,UserData> GetEnumerator()
        //{
        //    return this.mDatas.GetEnumerator();
        //}
        public Dictionary<string,UserData> mDatas = new Dictionary<string,UserData>();

    }
    public static class Data
    {

        /// <summary>
        /// 每个网站用户的游戏实例 key是游戏账户id
        /// </summary>
        /// 
        public static gameDatas data = new gameDatas();
        private static void delDataBaseGameAccount()
        {

        }
        public static void Seed(UserData userData)
        {
            if (data.ContainsKey(userData.GameAccount.GameAccountID))
            {
                return;
            }
            else
            {
                data.Add(userData);
            }
            lock (AutoLoop.dicDataLocker)
            {
                AutoLoop.AddDic(new AutoLoop.LoopData(userData));
            }


            

        }





    }
    public class UserData
    {
        public UserData()
        {
            this.ThreadLocker = new object();
            this.authCode = new AuthCode(this);
            this.Response = new Response(this);
            this.config = new Config(this);
            this.battle = new Action.Battle(this);
            this.others = new Others(this);
            this.mission = new Mission(this);
            this.operation_Act_Info = new Operation_Act_Info(this);
            this.dorm_with_user_info = new Dorm_With_User_Info(this);
            this.home = new Home(this);

            this.simulation = new Simulation(this);

            this.outhouse_Establish_Info = new Outhouse_BattleReport(this);
            this.item_With_User_Info = new Item_With_User_Info(this);
            this.kalina_with_user_info = new Kalina_With_User_Info(this);
            this.equip_With_User_Info = new Equip(this);
            this.squadDataAnalysisAction = new SquadDataAnalysisAction(this);
            this.task_Daily = new Task_Daily(this);
            this.squad_With_User_Info = new Squad_With_User_Info(this);
            this.chip_With_User_Info = new Chip_With_User_Info(this);
            this.equip_Built = new Equip_Build(this);
            this.doll_Build = new Doll_Build(this);
            //this.threadLoop = new ThreadLoop(this);
            this.share_With_User_Info = new Share_With_User_Info(this);
            this.MissionInfo = new MissionInfo(this);
            this.upgrade_Act_Info = new Upgrade_Act_Info(this);
            this.webData = new WebData(this);
            this.mailList = new Mail(this);
            this.Factory = new Factory(this);
            this.mission_With_User_Info = new Mission_With_User_Info(this);
            this.auto_Mission_Act_Info = new Auto_Mission_Act_Info(this);
            this.Net = new API.Net(this);
            this.dailyReFlash = new DailyReFlash(this);

        }
        public void CreatGameAccount(DataBase.GameAccount gameAccount)
        {
            GameAccount.setData(gameAccount);
            GameAccount.GameHost = Helper.Configer.HostAddress.GetAddressByName(GameAccount.ChannelID);
            config.ParmConfiuge(this);
        }

        private void Clear()
        {
            user_Info = new User_Info();
            user_Record = new User_Record();
        }

        public void Read(dynamic jsonobj, LitJson.JsonData jsonData)
        {
            Clear();

            Dorm_Rest_Friend_Build_Coin_Count = -1;
            user_Info.Read(jsonobj);

            user_Record.Read(jsonobj);

            equip_With_User_Info.Read(jsonData);

            operation_Act_Info.Read(jsonobj);

            kalina_with_user_info.Read(jsonobj);

            friend_with_user_info.Read(jsonobj);

            Dorm_Rest_Friend_Build_Coin_Count = Convert.ToInt32(jsonobj.dorm_rest_friend_build_coin_count);

            auto_Mission_Act_Info.Read(jsonData);


            upgrade_Act_Info.Read(jsonData);

            outhouse_Establish_Info.Read(jsonobj);

            fairy_With_User_Info.Read(jsonData);

            item_With_User_Info.Read(jsonobj);

            gun_With_User_Info.Read(jsonData);

            others.Read(jsonobj);



            squadDataAnalysisAction.Read(jsonData);
            task_Daily.Read(jsonData);
            squad_With_User_Info.Read(jsonData);
            mission_With_User_Info.Read(jsonData);
            chip_With_User_Info.Read(jsonData);
            equip_Built.Read(jsonData);
            doll_Build.Read(jsonData);

            share_With_User_Info.Read(jsonobj);
            others.SetTeamInfo();

        }


        public AuthCode authCode;
        public Home home;
        public Action.Battle battle;
        public object ThreadLocker;

        public int Dorm_Rest_Friend_Build_Coin_Count;


        public Config config;

        public GameAccount GameAccount = new GameAccount();

        public User_Info user_Info = new User_Info();

        public User_Record user_Record = new User_Record();

        public Operation_Act_Info operation_Act_Info;

        public Equip equip_With_User_Info;

        public Kalina_With_User_Info kalina_with_user_info;
        public Dorm_With_User_Info dorm_with_user_info;
        public Friend_With_User_Info friend_with_user_info = new Friend_With_User_Info();

        public Mail mailList;

        public Auto_Mission_Act_Info auto_Mission_Act_Info;

        public Upgrade_Act_Info upgrade_Act_Info;

        public Outhouse_BattleReport outhouse_Establish_Info;

        public Fairy_With_User_info fairy_With_User_Info = new Fairy_With_User_info();

        public Item_With_User_Info item_With_User_Info;

        public Gun_With_User_Info gun_With_User_Info = new Gun_With_User_Info();

        public Others others;

        public Mission_With_User_Info mission_With_User_Info;

        public Mission mission;
        public Simulation simulation;
        public MissionInfo MissionInfo;
        public Dictionary<int, Dictionary<int, Gun_With_User_Info.Data>> Teams = new Dictionary<int, Dictionary<int, Gun_With_User_Info.Data>>();//没读一次user_info都需要刷新



        //任务列表
        public List<TaskListInfo> Task = new List<TaskListInfo>();

        //这个要时刻刷新交给前端 是一个类 包含user_info，BattleTask,Logistal
        //还有一个进度信息StatusBarText
        //以Json形式扔出去
        public WebData webData;

        public logWriter log = new logWriter();


        public API.Net Net;
        public DailyReFlash dailyReFlash;
        public SquadDataAnalysisAction squadDataAnalysisAction;
        public Squad_With_User_Info squad_With_User_Info;
        public Chip_With_User_Info chip_With_User_Info;
        public Equip_Build equip_Built;
        public Doll_Build doll_Build;
        public Task_Daily task_Daily;
        public Share_With_User_Info share_With_User_Info;
        public Factory Factory;
        public Response Response;
        public Random random = new Random();
        public BaseRequset baseRequset = new BaseRequset();
    }

    public class Config
    {
        public Config(UserData userData)
        {
            ParmConfiuge(userData);
        }
        public int ErrorCount = 2;
        public bool FirstTimeLoginSuccess = false;
        private bool _FinalLoginSuccess = false;
        public bool FinalLoginSuccess
        {
            get
            {
                return _FinalLoginSuccess;
            }
            set
            {
                _FinalLoginSuccess = value;
                AutoLoop.dic[UserID].FinalLoginSuccess = value;
            }


        }
        public string UserID;
        public bool NeedAuto_Loop_Operation_Act = true;
        public bool NeedAuto_Click_Girls_In_Dorm = true;//这些都需要 read userinfo 重置
        public bool NewGun_Report_Stop = true;
        public bool AutoStrengthen = true;


        public bool AutoSimulation = false;
        public bool DataAnalysis = false;
        public bool AutoTaskDaily = false;
        public bool NormalReport = false;
        public bool HeavyReport = false;

        public bool M = false;
        public double TimeDelay = 1;

        public bool isOffline = false;

        public void ParmConfiuge(UserData userData)
        {
            UserID = userData.GameAccount.GameAccountID;
            if (string.IsNullOrEmpty(userData.GameAccount.Parm)) return;
            List<string> Parm = userData.GameAccount.Parm.ToLower().Split(' ').ToList();
            foreach (var item in Parm)
            {
                if (item.Contains("-d"))
                {
                    this.DataAnalysis = true;
                }
                if (item.Contains("-s"))
                {
                    this.AutoSimulation = true;
                }
                if (item.Contains("-nr"))
                {
                    this.NormalReport = true;
                }
                if (item.Contains("-hr"))
                {
                    this.HeavyReport = true;
                }
                if (item.Contains("-s"))
                {
                    this.AutoSimulation = true;
                }
                if (item.Contains("-m"))
                {
                    this.M = true;
                    this.AutoStrengthen = true;
                    this.AutoTaskDaily = true;
                    this.TimeDelay = 0.1;
                }


                if (item.Contains("-all"))
                {
                    this.AutoSimulation = true;
                    this.AutoStrengthen = true;
                    this.DataAnalysis = true;
                    this.AutoTaskDaily = true;
                }


            }
        }

    }


    public class UserAccountInfo
    {

        //public int Id { get; set; }
        public string Accountid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Policy { get; set; }
    }





    public class GameAccount : DataBase.GameAccount
    {
        public void setData(DataBase.GameAccount data)
        {
            WebUsername = data.WebUsername;
            GameAccountID = data.GameAccountID;
            GamePassword = data.GamePassword;
            ChannelID = data.ChannelID;
            WorldID = data.WorldID;
            YunDouDou = data.YunDouDou;
            Parm = data.Parm;

        }
        public int GetCurrentTimeStamp()
        {
            return Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds - realtimeSinceLogin + loginTime);
        }
        public int realtimeSinceLogin = 0;
        public int loginTime = 0;
        public string access_token;
        public string openid;

        public string uid;
        public string sign;


        public int timeoffset;
        public long req_id;

        public string CatchDataVersion;
        public int tomorrow_zero;
        public int weekday;
        public string GameHost = "http://gf-adrgw-cn-zs-game-0001.ppgame.com/index.php/1000/";


        public string data_version;
        public string ab_version;

    }








}

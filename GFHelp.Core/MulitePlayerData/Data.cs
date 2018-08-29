using GFHelp.Core.Action;
using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.MulitePlayerData;
using GFHelp.Core.MulitePlayerData.WebData;
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
        public bool Add(UserData userData)
        {
            foreach (UserData item in mDatas)
            {
                if(item.GameAccount.Base.GameAccountID == userData.GameAccount.Base.GameAccountID && item.taskDispose == false)
                {
                    return false;
                }
            }
            mDatas.Add(userData);
            return true;
        }
        public int Count
        {
            get
            {
                int count=0;
                foreach (var item in mDatas)
                {
                    if (item.taskDispose == false) count++;
                }
                return count;
            }
        }
        public UserData getDataByID(string ID)
        {
            foreach (var item in mDatas)
            {
                if(item.GameAccount.Base.GameAccountID == ID && item.taskDispose == false)
                {
                    return item;
                }
            }
            return null;
        }
        public void RemoveByID(string ID)
        {
            for (int i = 0; i < mDatas.Count; i++)
            {
                if (mDatas[i].GameAccount.Base.GameAccountID == ID)
                {
                    mDatas.RemoveAt(i);
                }
            }
        }
        public bool ContainsKey(string id)
        {
            foreach (var item in mDatas)
            {
                if(item.GameAccount.Base.GameAccountID == id && item.taskDispose == false)
                {
                    return true;
                }
            }
            return false;
        }
        public IEnumerator<UserData> GetEnumerator()
        {
            return this.mDatas.GetEnumerator();
        }
        private List<UserData> mDatas = new List<UserData>();

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
            if (data.ContainsKey(userData.GameAccount.Base.GameAccountID))
            {
                return;
            }
            else
            {
                data.Add(userData);
            }
            userData.config.ParmConfiuge();




            userData.cd = new Task(() => userData.cdloop.CountDown());
            userData.cd.Start();
            userData.cd.ContinueWith(t =>
            {
                DataBase.DataBase.DelGameAccount(userData.GameAccount.Base);
                string id = userData.GameAccount.Base.GameAccountID;
                new Log().userInit(id, "程序已注销 请重新创建实例").userInfo();
                userData = null;
                data.RemoveByID(id);
            });
        }

        public static void SetUserConfig(UserData userData,string parm)
        {
            List<string> Parm = parm.ToLower().Split(' ').ToList();
            foreach (var item in Parm)
            {
                if (item.Contains("-s"))
                {
                    userData.config.AutoSimulation = false;
                }
            }

        }

        public static WebData GetWebData(string AccountId)
        {
            WebData webData = new WebData();
            foreach (var item in data)
            {
                if (item.GameAccount.Base.GameAccountID == AccountId)
                {
                    item.webData.Get(item);
                    webData = item.webData;
                }

            }
            return webData;
        }

        public static WebStatus GetWebStatus(string AccountId)
        {
            WebData webData = new WebData();
            WebStatus WebStatus = new WebStatus();
            foreach (var item in data)
            {
                if (item.GameAccount.Base.GameAccountID == AccountId)
                {
                    item.webData.Get(item);
                    webData = item.webData;
                }

            }
            WebStatus.AccountId = AccountId;
            WebStatus.statusBarText = webData.StatusBarText;
            return WebStatus;
        }





    }
    public class UserData
    {
        public UserData()
        {

            eventAction = new EventAction(this);
            this.battle = new Action.Battle(this);
            this.others = new Others(this);
            this.mission = new Mission(this);
            this.operation_Act_Info = new Operation_Act_Info(this);
            this.dorm_with_user_info = new Dorm_With_User_Info(this);
            this.home = new Home(this);
            this.auto_Summery = new Auto_Summery(this);
            this.simulation = new Simulation(this);
            this.BattleReport = new BattleReport(this);
            this.outhouse_Establish_Info = new Outhouse_BattleReport(this);
            this.item_With_User_Info = new Item_With_User_Info(this);
            this.config = new Config(this);
            this.equip_With_User_Info = new Equip(this);
            this.squadDataAnalysisAction = new SquadDataAnalysisAction(this);
            this.squadDailyQuestAction = new SquadDailyQuestAction(this);
            this.squad_With_User_Info = new Squad_With_User_Info(this);
            this.chip_With_User_Info = new Chip_With_User_Info(this);
            this.cdloop = new cdLoop(this);
        }
        public void CreatGameAccount(DataBase.GameAccount gameAccount)
        {
            GameAccount.Base = gameAccount;
            GameAccount.AndroidID = Guid.NewGuid().ToString("N");
            GameAccount.MAC = M.GetNewMac();
            GameAccount.GameHost = Helper.Configer.HostAddress.GetAddressByName(GameAccount.Base.ChannelID);

            //userData.config.AutoSimulation



        }



        private void Clear()
        {
            user_Info = new User_Info();
            user_Record = new User_Record();
            kalina_with_user_info = new Kalina_With_User_Info();
            auto_Mission_Act_Info = new Auto_Mission_Act_Info();

        }

        public void Read(dynamic jsonobj,LitJson.JsonData jsonData)
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

            auto_Mission_Act_Info.Read(jsonobj);

            ReadUserData_mission_act_info(jsonobj);
            upgrade_Act_Info.Read(jsonobj);

            outhouse_Establish_Info.Read(jsonobj);

            fairy_With_User_Info.Read(jsonobj);
            //装备开发暂时不写
            item_With_User_Info.Read(jsonobj);

            gun_With_User_Info.Read(jsonData);

            others.Read(jsonobj);



            squadDataAnalysisAction.Read(jsonData);
            squadDailyQuestAction.Read(jsonData);
            squad_With_User_Info.Read(jsonData);
            chip_With_User_Info.Read(jsonData);




            Function.SetTeamInfo(this);

        }
        private void ReadUserData_mission_act_info(dynamic jsonobj)
        {
            Mission_S = false;
            try
            {
                string data = jsonobj.mission_act_info.ToString();
                if (data.Length > 10)
                {
                    Mission_S = true;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public Task cd;
        public cdLoop cdloop;
        public bool taskDispose = false;

        public Auto_Summery auto_Summery;
        public Home home;
        public Action.Battle battle;

        public int Dorm_Rest_Friend_Build_Coin_Count;
        public bool Mission_S;

        public Config config; 

        public GameAccount GameAccount = new GameAccount();

        public User_Info user_Info = new User_Info();

        public User_Record user_Record = new User_Record();

        public Operation_Act_Info operation_Act_Info;

        public Equip equip_With_User_Info;

        public Kalina_With_User_Info kalina_with_user_info = new Kalina_With_User_Info();
        public Dorm_With_User_Info dorm_with_user_info;
        public Friend_With_User_Info friend_with_user_info = new Friend_With_User_Info();

        public MailList mailList = new MailList();

        public Auto_Mission_Act_Info auto_Mission_Act_Info = new Auto_Mission_Act_Info();

        public Upgrade_Act_Info upgrade_Act_Info = new Upgrade_Act_Info();

        public Outhouse_BattleReport outhouse_Establish_Info; 

        public Fairy_With_User_info fairy_With_User_Info = new Fairy_With_User_info();

        public Item_With_User_Info item_With_User_Info;

        public Gun_With_User_Info gun_With_User_Info = new Gun_With_User_Info();

        public Others others;

        public Mission mission;
        public Simulation simulation;
        public Normal_MissionInfo normal_MissionInfo = new Normal_MissionInfo();
        public Dictionary<int, Dictionary<int, Gun_With_User_Info>> Teams = new Dictionary<int, Dictionary<int, Gun_With_User_Info>>();//没读一次user_info都需要刷新

        public BattleReport BattleReport;

        //任务列表
        public List<TaskListInfo> Task = new List<TaskListInfo>();

        //这个要时刻刷新交给前端 是一个类 包含user_info，BattleTask,Logistal
        //还有一个进度信息StatusBarText
        //以Json形式扔出去
        public WebData webData = new WebData();

        public logWriter log = new logWriter();
        public EventAction eventAction;




        public SquadDataAnalysisAction squadDataAnalysisAction;
        public SquadDailyQuestAction squadDailyQuestAction;
        public Squad_With_User_Info squad_With_User_Info;
        public Chip_With_User_Info chip_With_User_Info;







    }

    public class Config
    {
        public Config(UserData userData)
        {
            this.userData = userData;
        }
        private UserData userData;
        public int ErrorCount = 1;
        public bool LoginSuccessful = false;

        public bool NeedAuto_Loop_Operation_Act = true;
        public bool NeedAuto_Click_Girls_In_Dorm = true;//这些都需要 read userinfo 重置
        public bool AutoSimulation = false;
        public bool NewGun_Report_Stop = true;
        public bool AutoStrengthen = true;
        public void ParmConfiuge()
        {
            if (string.IsNullOrEmpty(userData.GameAccount.Base.Parm)) return;
            List<string> Parm = userData.GameAccount.Base.Parm.ToLower().Split(' ').ToList();
            foreach (var item in Parm)
            {
                if (item.Contains("-s"))
                {
                    this.AutoSimulation = true;
                }
                if (item.Contains("-st"))
                {
                    this.AutoStrengthen = false;
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





    public class GameAccount
    {
        public DataBase.GameAccount Base = new DataBase.GameAccount();
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
        public string AndroidID;
        public string MAC;
        public string CatchDataVersion;
        public int tomorrow_zero;
        public int weekday;
        public string GameHost = "http://gf-adrgw-cn-zs-game-0001.ppgame.com/index.php/1000/";
    }



    public class EventAction
    {
        private UserData userData;
        public EventAction(UserData userData)
        {
            this.userData = userData;
            this.waiter = new Waiter();
            Action += this.waiter.ActionEvent;
            Task run = new Task(Run);
            run.Start();
        }
        public Waiter waiter;
        private event ActionEventHandler Action;
        private List<ActionEventArgs> list = new List<ActionEventArgs>();
        private void Run()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (userData.taskDispose) return;
                if (list.Count == 0) continue;
                this.Action.Invoke(userData, list[0]);
                list.RemoveAt(0);
            }
        }

        private void invoke(ActionEventArgs e)
        {
            if (this.Action != null)
            {
                list.Add(e);
            }
        }

        public void Login()
        {
            invoke(new ActionEventArgs(TaskList.Login));
        }


        public void ReloadMissionDll()
        {
            invoke(new ActionEventArgs(TaskList.ReloadMissionDll));
        }
        public void Test()
        {
            invoke(new ActionEventArgs(TaskList.Test));
        }
        public void GetUserInfo()
        {
            invoke(new ActionEventArgs(TaskList.GetuserInfo));
        }
        public void Click_Kalina()
        {
            invoke(new ActionEventArgs(TaskList.Click_Kalina));
        }

        public void GetRecoverBp()
        {
            invoke(new ActionEventArgs(TaskList.GetRecoverBp));
        }

        public void Simulation_DATA()
        {
            invoke(new ActionEventArgs(TaskList.Simulation_DATA));
        }
        public void Simulation_Corridor()
        {
            invoke(new ActionEventArgs(TaskList.Simulation_Corridor));
        }

        public void TaskBattle_1()
        {
            invoke(new ActionEventArgs(TaskList.TaskBattle_1));
        }

        public void BattleReport_Write()
        {
            invoke(new ActionEventArgs(TaskList.BattleReport_Write));
        }
        public void BattleReport_Finish()
        {
            invoke(new ActionEventArgs(TaskList.BattleReport_Finish));
        }
        public void Start_Trial()
        {
            invoke(new ActionEventArgs(TaskList.Start_Trial));
        }
        public void Click_Girls_In_Dorm()
        {
            invoke(new ActionEventArgs(TaskList.Click_Girls_In_Dorm));
        }

    }





}

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
    public static class Data
    {

        /// <summary>
        /// 每个网站用户的游戏实例 key是游戏账户id
        /// </summary>
        public static Dictionary<string, UserData> data = new Dictionary<string, UserData>();

        public static void seed(UserData userData)
        {


            if (data.ContainsKey(userData.GameAccount.Base.GameAccountID))
            {
                data[userData.GameAccount.Base.GameAccountID] = userData;
            }
            else
            {
                data.Add(userData.GameAccount.Base.GameAccountID, userData);
            }

            userData.cd = new Task(() => Loop.CountDown(userData));
            userData.cd.Start();
            userData.cd.ContinueWith(t =>
            {
                Task.WaitAll(userData.cd);
                string id = userData.GameAccount.Base.GameAccountID;
                userData = null;
                data.Remove(id);
            });
        }

        public static WebData GetWebData(string AccountId)
        {
            WebData webData = new WebData();
            foreach (var item in data)
            {
                if (item.Value.GameAccount.Base.GameAccountID == AccountId)
                {
                    item.Value.webData.Get(item.Value);
                    webData = item.Value.webData;
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
                if (item.Value.GameAccount.Base.GameAccountID == AccountId)
                {
                    item.Value.webData.Get(item.Value);
                    webData = item.Value.webData;
                }

            }
            WebStatus.AccountId = AccountId;
            WebStatus.statusBarText = webData.StatusBarText;
            return WebStatus;
        }

        public static void AddAccountBaseInDictionary(GameAccountBase accountBase)
        {
            UserData userdata = new UserData();
            userdata.CreatGameAccount(accountBase);
            seed(userdata);
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
        }
        public void CreatGameAccount(GameAccountBase gameAccountBase)
        {
            GameAccount.Base = gameAccountBase;
            GameAccount.Base.AndroidID = Guid.NewGuid().ToString("N");
            GameAccount.Base.MAC = M.GetNewMac();
            GameAccount.GameHost = GameHost.Get(GameAccount.Base.Platform, GameAccount.Base.ChannelID, GameAccount.Base.WorldID);
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
        public bool taskDispose = false;

        public Auto_Summery auto_Summery;
        public Home home;
        public Action.Battle battle;

        public int Dorm_Rest_Friend_Build_Coin_Count;
        public bool Mission_S;

        public Config config = new Config();

        public GameAccount GameAccount = new GameAccount();

        public User_Info user_Info = new User_Info();

        public User_Record user_Record = new User_Record();

        public Operation_Act_Info operation_Act_Info;

        public Equip equip_With_User_Info = new Equip();

        public Kalina_With_User_Info kalina_with_user_info = new Kalina_With_User_Info();
        public Dorm_With_User_Info dorm_with_user_info;
        public Friend_With_User_Info friend_with_user_info = new Friend_With_User_Info();

        public MailList mailList = new MailList();

        public Auto_Mission_Act_Info auto_Mission_Act_Info = new Auto_Mission_Act_Info();

        public Upgrade_Act_Info upgrade_Act_Info = new Upgrade_Act_Info();

        public Outhouse_Establish_Info outhouse_Establish_Info = new Outhouse_Establish_Info();

        public Fairy_With_User_info fairy_With_User_Info = new Fairy_With_User_info();

        public Item_With_User_Info item_With_User_Info = new Item_With_User_Info();

        public Gun_With_User_Info gun_With_User_Info = new Gun_With_User_Info();

        public Others others;

        public Mission mission;
        public Normal_MissionInfo normal_MissionInfo = new Normal_MissionInfo();
        public Dictionary<int, Dictionary<int, Gun_With_User_Info>> Teams = new Dictionary<int, Dictionary<int, Gun_With_User_Info>>();//没读一次user_info都需要刷新

        public BattleReport BattleReport = new BattleReport();

        //任务列表
        public List<TaskListInfo> Task = new List<TaskListInfo>();

        //这个要时刻刷新交给前端 是一个类 包含user_info，BattleTask,Logistal
        //还有一个进度信息StatusBarText
        //以Json形式扔出去
        public WebData webData = new WebData();

        public logWriter log = new logWriter();
        public EventAction eventAction;
    }

    public class Config
    {
        public int ErrorCount = 1;
        public bool LoginSuccessful = false;
        public bool AutoRelogin = false;
        public bool NeedAuto_Loop_Operation_Act = true;
        public bool NeedAuto_Click_Girls_In_Dorm = true;//这些都需要 read userinfo 重置
        public bool AutoSimulationBattleF = false;
        public bool NewGun_Report_Stop = true;
        public bool AutoStrengthen = true;


    }


    public class UserAccountInfo
    {

        //public int Id { get; set; }
        public string Accountid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Policy { get; set; }
    }




    public class GameAccountBase
    {
        /// <summary>
        /// 网站用户名字
        /// </summary>
        //[Required(ErrorMessage = "Username is required.")]
        public string WebUsername { get; set; }
        /// <summary>
        /// 游戏账号
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        [Key]
        public string GameAccountID { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string GamePassword { get; set; }

        ///AndroidID
        public string AndroidID { get; set; }
        public string MAC { get; set; }
        /// <summary>
        /// 平台 安卓苹果
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        /// 渠道 官服B服腾讯服
        /// </summary>
        public string ChannelID { get; set; }
        /// <summary>
        /// 服
        /// </summary>
        public string WorldID { get; set; }

        /// <summary>
        /// 不必要 后端自动生成
        /// </summary>


        /// <summary>
        /// 
        /// </summary>
        public string YunDouDou;
        /// <summary>
        /// 
        /// </summary>
        public string Parm { get; set; }
    }
    public class GameAccount
    {
        public GameAccountBase Base = new GameAccountBase();
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
    }



    public class EventAction
    {
        private UserData userData;
        public EventAction(UserData userData)
        {
            this.userData = userData;
            this.waiter = new Waiter();
            Action += this.waiter.ActionEvent;
        }
        public Waiter waiter;
        private event ActionEventHandler Action;
        private void invoke(ActionEventArgs e)
        {
            if (this.Action != null)
            {
                this.Action.Invoke(userData, e);
            }
        }

        public void Login()
        {
            invoke(new ActionEventArgs(TaskList.Login));
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

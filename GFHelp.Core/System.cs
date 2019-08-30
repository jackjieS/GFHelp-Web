using GFHelp.Core.Helper;
using GFHelp.Core.Helper.Configer;
using GFHelp.Core.Management;
using GFHelp.NetBase;
using LitJson;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace GFHelp.Core.SystemManager
{

    public class GameServerStatus
    {

        public GameServerStatus()
        {
            baseRequset = new BaseRequset();
            urldata = new URLData();
            Loop();
        }
        public class Data
        {
            public static bool isSystemMainTean = false;

        }
        public class URLData
        {
            public URLData()
            {
                init();
            }
            public string URL;
            public string URLParm;
            void init()
            {
                StringBuilder stringBuilder = new StringBuilder();
                JsonWriter jsonWriter = new JsonWriter(stringBuilder);
                jsonWriter.WriteObjectStart();
                jsonWriter.WritePropertyName("c");
                jsonWriter.Write("game");
                jsonWriter.WritePropertyName("a");
                jsonWriter.Write("newserverList");
                jsonWriter.WritePropertyName("channel");
                jsonWriter.Write("cn_mica");
                jsonWriter.WritePropertyName("platformChannelId");
                jsonWriter.Write("GWPZ");
                jsonWriter.WritePropertyName("check_version");
                jsonWriter.Write("20400");
                jsonWriter.WritePropertyName("rnd");
                jsonWriter.Write("274413");
                jsonWriter.WriteObjectEnd();
                this.URLParm = stringBuilder.ToString();
                this.URL = "http://adr.transit.gf.ppgame.com/index.php";
            }


        }
        BaseRequset baseRequset;
        URLData urldata;
        private AutoResetEvent exitEvent = new AutoResetEvent(false);
        public void Stop()
        {
            exitEvent.Set();
        }
        public void Check()
        {
            while (true)
            {

                string result = baseRequset.DoPost(urldata.URL, urldata.URLParm);
                if (string.IsNullOrEmpty(result)) return;
                result = result.Substring(result.IndexOf("<open_time>"));
                result = result.Remove(result.IndexOf("</open_time>"));
                int opentime = Convert.ToInt32(Regex.Replace(result, "[^0-9]", ""));
                if (Decrypt.getDateTime_China_Int(DateTime.Now) < opentime)
                {
                    Data.isSystemMainTean = true;
                }


                if (exitEvent.WaitOne(60000))
                {
                    return;
                }
            }


        }
        public void Loop()
        {
            Task autoLoop = new Task(() => Check());
            autoLoop.Start();
        }










    }





    public class ConfigData
    {
        static dynamic type = (new Program()).GetType();
        public static string currentDirectory = Path.GetDirectoryName(type.Assembly.Location);
        public static string DataVersion;
        public static int tomorrow_zero;
        public static int weekday;

        public static List<string> BattleMap = new List<string>()
        {
            "-map0_2",
            "-map5_2n",
            "-map10_4e"
        };
        public static int Error_num = 3;
        public static int UpdateCache = 5;
        public static int BL_ReLogin_num = 20;
        public static int ListStoreNum = 500;
        public static List<DataBase.AccountInfo> WebUserData = new List<DataBase.AccountInfo>();
        public static int LogID;
        public static void Initialize()
        {
            logWriter.initLogWriter();
            ConfigManager.getConfig();
            HostAddress.Load();
            new Log().systemInit("读取config配置").coreInfo();
            new Log().systemInit("读取文字解析").coreInfo();
            CatchData.Base.Asset_Textes.Read_ALL_CSV();

            CatachData.Seed();

            new Log().systemInit("引用作战dll").coreInfo();
        }


    }

    public class SystemHelper
    {
        public class OperationStatus
        {
            public int TotalNum = 0;

            public int TotalFinalTimeLogin = 0;

            public int OperationRunning = 0;
            public int OperationProblem = 0;
            public List<string> ListOperationProblem = new List<string>();

            public int DollBuildRunning = 0;
            public int DollBuildProblem = 0;
            public List<string> ListDollBuildProblem = new List<string>();


            public int BattleNum = 0;
            public List<string> ListBattleNum = new List<string>();

            public int MissionClosed = 0;
            public List<string> ListMissionClosed = new List<string>();

            public int LoginFalse = 0;
            public List<string> ListLoginFalse = new List<string>();



        }
        public static OperationStatus GetRunningNumberOfM()
        {
            OperationStatus operationStatus = new OperationStatus();
            var list = Management.Data.data.getDatasByWebID("m");
            operationStatus.TotalNum = list.Count;
            foreach (var item in list)
            {
                if (item.config.FinalLoginSuccess)
                {
                    operationStatus.TotalFinalTimeLogin++;
                }


                if (item.operation_Act_Info.isRunning())
                {
                    operationStatus.OperationRunning++;
                }
                else
                {
                    if (item.config.FinalLoginSuccess)
                    {
                        operationStatus.OperationProblem++;
                        operationStatus.ListOperationProblem.Add(item.GameAccount.GameAccountID);
                    }

                }
                if (item.doll_Build.isAutoRunning())
                {
                    operationStatus.DollBuildRunning++;
                }
                else
                {
                    if (item.config.FinalLoginSuccess)
                    {
                        operationStatus.DollBuildProblem++;
                        operationStatus.ListDollBuildProblem.Add(item.GameAccount.GameAccountID);
                    }

                }





                if (item.MissionInfo.listTask.Count != 0)
                {
                    operationStatus.BattleNum++;
                    operationStatus.ListBattleNum.Add(item.GameAccount.GameAccountID);
                }

                if (item.mission_With_User_Info.CheckMissionisOpen() == false && item.config.FirstTimeLoginSuccess)
                {
                    operationStatus.MissionClosed++;
                    operationStatus.ListMissionClosed.Add(item.GameAccount.GameAccountID);
                }
                if (!item.config.FirstTimeLoginSuccess)
                {
                    operationStatus.LoginFalse++;
                    operationStatus.ListLoginFalse.Add(item.GameAccount.GameAccountID);

                }

            }





            return operationStatus;

        }







    }


}

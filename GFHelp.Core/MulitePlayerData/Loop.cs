using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GFHelp.Core.Management
{
    public class ThreadLoop
    {
        public Task dailyLoop;

        public ThreadLoop(UserData userData)
        {
            this.userData = userData;
        }

        private AutoResetEvent exitEvent = new AutoResetEvent(false);


        public void init()
        {

        }

        public void Stop()
        {
            exitEvent.Set();
        }

        private UserData userData;




    }

    public class AutoLoop
    {
        public AutoLoop()
        {
            autoLoop = new Task(() => Start());
            autoLoop.Start();
        }
        Task autoLoop;

        public class LoopData
        {
            public LoopData(UserData userData)
            {
                this.UserName = userData.GameAccount.GameAccountID;
            }
            public string UserName;
            public bool FinalLoginSuccess = false;
            public int OperationNextTime;
            public int DollBuildNextTime;
            public int EquipBuildNextTime;
            public void DataCheck()
            {
                if (FinalLoginSuccess == false) return;

                if (Data.data.mDatas[UserName].dailyReFlash.reLoginDateTime.Minute == DateTime.Now.Minute)
                {
                    Data.data.mDatas[UserName].dailyReFlash.AutoRun();
                }

                if (OperationNextTime < Decrypt.getDateTime_China_Int(DateTime.Now))
                {
                    Data.data.mDatas[UserName].operation_Act_Info.AutoRun();
                }

                if (DollBuildNextTime < Decrypt.getDateTime_China_Int(DateTime.Now))
                {
                    Data.data.mDatas[UserName].doll_Build.AutoRun();
                }
                if (EquipBuildNextTime < Decrypt.getDateTime_China_Int(DateTime.Now))
                {
                    Data.data.mDatas[UserName].equip_Built.AutoRun();
                }
            }
        }
        public static Dictionary<string, LoopData> dic = new Dictionary<string, LoopData>();
        public static object dicDataLocker = new object();

        public static class ThreadInfo
        {
            public static void init()
            {
                ThreadPool.GetMaxThreads(out MaxWorkerThreads, out miot);
            }
            static int MaxWorkerThreads, miot, AvailableWorkerThreads = 0, aiot = 0;



            public static int LoginThreadNum = 0;
            public static int OperationThreadNum = 0;
            public static int DollBuildThreadNum = 0;
            public static int MaxThreadCount = 300;

            public static int getThreadCount
            {
                get
                {
                    return LoginThreadNum + OperationThreadNum + DollBuildThreadNum;
                }
            }
            public static bool isMaxThreadCount
            {
                get
                {
                    return getThreadCount > MaxThreadCount;
                }
            }
            public static string ThreadStatus
            {
                get
                {
                    string result = "";
                    result += string.Format(" 线程池数目 = {0} ", getThreadCount.ToString());
                    result += string.Format(" 登陆 = {0} ", (LoginThreadNum).ToString());
                    result += string.Format(" 后勤 = {0} ", (OperationThreadNum).ToString());
                    result += string.Format(" 建造 = {0} ", (DollBuildThreadNum).ToString());
                    return result;
                }



            }



        }



        public static void AddDic(LoopData data)
        {
            if (!dic.ContainsKey(data.UserName))
            {
                dic.Add(data.UserName, data);
            }
        }
        public static void RemoveDic(string ID)
        {
            if (dic.ContainsKey(ID))
            {
                dic.Remove(ID);
            }
        }




        private AutoResetEvent exitEvent = new AutoResetEvent(false);
        public void Stop()
        {
            exitEvent.Set();
        }

        public void Start()
        {
            ThreadInfo.init();
            List<string> list;

            while (true)
            {
                if (exitEvent.WaitOne(1000))
                {
                    return;
                }
                if (ThreadInfo.isMaxThreadCount) continue;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                try
                {

                    lock (dicDataLocker)
                    {
                        list = new List<string>(dic.Keys);
                    }
                    foreach (var key in list)
                    {

                        dic[key].DataCheck();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                stopwatch.Stop(); // 停止监视
                TimeSpan timespan = stopwatch.Elapsed; // 获取当前实例测量得出的总时间

                //获得可用的线程数量

                //Console.WriteLine(string.Format("TotalSeconds = {0} {1}", timespan.TotalSeconds, ThreadInfo.ThreadStatus));






















































            }























        }














































    }

}


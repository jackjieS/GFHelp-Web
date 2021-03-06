﻿using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GFHelp.Core.MulitePlayerData
{
    public class DailyReFlash
    {

        private UserData userData;

        public int defaultLoginTime { get; set; }
        public DateTime dateTime { get; set; }
        public DateTime reLoginDateTime
        {
            get
            {
                var t = dateTime;
                return t.AddMinutes(59);

            }
        }

        private object ObjectLocker = new object();

        private bool Locker = false;
        public DailyReFlash(UserData userData)
        {
            this.userData = userData;
            SetdefaultLoginTime();
        }
        public void SetdefaultLoginTime()
        {
            Random random = new Random();
            defaultLoginTime = random.Next(1, 59);
            if (defaultLoginTime == DateTime.Now.Minute)
            {
                SetdefaultLoginTime();
            }

        }
        public void Auto_Act_Summery()
        {
            userData.home.Click_Kalina();
            userData.dorm_with_user_info.ClickGirlsFavor();
            userData.home.DailyTask();//十次关卡 建造 强化
            //重装任务
            userData.battle.BP_Recover();
            userData.simulation.Run();
            userData.outhouse_Establish_Info.AutoRun();
            //userData.squadDataAnalysisAction.AutoRun();
            userData.dorm_with_user_info.TimeReduce();
        }
        public async void AutoRun()
        {
            if (Locker) return;
            Locker = true;
            Run();
        }
        private void Run()
        {
            new Log().userInit(userData.GameAccount.GameAccountID, string.Format("{0} 登陆", DateTime.Now.ToString())).userInfo();

            Task task = new Task(() =>
            {
                Interlocked.Increment(ref AutoLoop.ThreadInfo.LoginThreadNum);
                Random random = new Random();
                Thread.Sleep(random.Next(1000, 59000));


                userData.config.FinalLoginSuccess = false;

                userData.home.Login();
                SetdefaultLoginTime();








            });

            task.ContinueWith(p =>
            {

                userData.config.FinalLoginSuccess = true;
                Interlocked.Decrement(ref AutoLoop.ThreadInfo.LoginThreadNum);
                this.Locker = false;

            });

            task.Start();

        }
    }
}

using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GFHelp.Core.Management
{
    public class ThreadLoop
    {
        public ThreadLoop(UserData userData)
        {
            this.userData = userData;
        }
        private UserData userData;
        public void DailyLoop()//倒计时
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (userData.taskDispose == true)
                {
                    return;
                }
                try
                {
                    userData.operation_Act_Info.TimeReduce();
                    userData.dorm_with_user_info.TimeReduce();
                    Auto_Act_Summery();
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "循环倒计时 出现错误 ", e.ToString()).userInfo();
                    return;
                }

            }
        }
        public void BattleLoop()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (userData.taskDispose == true)
                {
                    return;
                }
                try
                {
                    Auto_Battle();
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "战斗Battle线程出现错误 ", e.ToString()).userInfo();
                    return;
                }

            }
        }




        private void Auto_Act_Summery()
        {

            if (userData.config.LoginSuccessful)
            {
                userData.home.Click_Kalina();
                userData.dorm_with_user_info.ClickGirlsFavor();
                userData.home.DailyReFlash();
                userData.battle.BP_Recover();
                userData.simulation.Run();
                userData.outhouse_Establish_Info.AutoRun();
                userData.squadDataAnalysisAction.AutoRun();
                userData.equip_Built.AutoRun();
                userData.doll_Build.AutoRun();
                userData.task_Daily.AutoRun();
            }

        }
        private void Auto_Battle()
        {
            if (userData.config.LoginSuccessful && userData.taskDispose != true)
            {
                if (userData.MissionInfo.listTask.Count == 0) return;
                userData.mission.Test();
            }
        }
    }




}

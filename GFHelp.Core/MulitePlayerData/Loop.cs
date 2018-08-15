using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GFHelp.Core.Management
{
    public class cdLoop
    {
        public cdLoop(UserData userData)
        {
            this.userData = userData;
        }
        private UserData userData;
        public void CountDown()//倒计时
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (userData.taskDispose == true)
                {
                    return;
                }
                userData.operation_Act_Info.TimeReduce();
                userData.dorm_with_user_info.TimeReduce();
                userData.auto_Summery.Auto_Act_Summery();
            }
        }
    }




    public class Auto_Summery
    {
        private UserData userData;
        public Auto_Summery(UserData userData)
        {
            this.userData = userData;
        }
        //总的循环
        public void Auto_Act_Summery()
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
                //WriteReport_Start(userData);
                //WriteReport_Finish(userData);

            }

        }

    }






























}

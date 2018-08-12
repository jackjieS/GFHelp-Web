using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class ActionEventArgs : EventArgs
    {
        public ActionEventArgs(TaskListInfo EventTask)
        {
            this.EventTask = EventTask;
        }
        public TaskListInfo EventTask;
    }

    public delegate void ActionEventHandler(UserData userData, ActionEventArgs e);
    public delegate void ActionEventHandler<T>(UserData userData, T e);
    public class Waiter
    {
        //这里是根据具体的方法
        public void ActionEvent(UserData userData, ActionEventArgs e)
        {
            switch (e.EventTask.TaskNumber)
            {
                case 1:
                    {
                        userData.home.Login();
                        break;
                    }
                case 2:
                    {
                        userData.home.GetUserInfo();
                        break;
                    }
                case 3:
                    {
                        Action.MissionData.Reload();
                        break;
                    }
                case 4:
                    {
                        userData.mission.Test();
                        userData.mission.Test();
                        userData.mission.Test();
                        break;
                    }
                case 21:
                    {
                        userData.home.Click_Kalina();
                        break;
                    }
                case 22:
                    {
                        userData.dorm_with_user_info.ClickGirlsFavor();
                        break;
                    }
                case 31:
                    {
                        new SimulationTrialHandle(userData).Start();
                        break;
                    }
                case 32:
                    {
                        userData.battle.GetRecoverBP();
                        break;
                    }
                case 33:
                    {
                        new SimulationDataHandle(userData).Start();
                        break;
                    }
                case 34:
                    {
                        userData.mission.corridor(userData);
                        //Simulation_map
                        break;
                    }
                case 41:
                    {
                        userData.mission.Test();
                        userData.mission.End_At_Battle(userData.normal_MissionInfo);
                        break;
                    }
                case 51:
                    {
                        break;
                    }
                default:
                    break;
            }
            userData.webData.StatusBarText = "空闲";

        }
    }
}

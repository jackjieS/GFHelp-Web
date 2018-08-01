using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GFHelp.Core.Action
{
    public class Mission
    {
        private UserData userData;
        public Mission(UserData userData)
        {
            this.userData = userData;
        }
        class Data
        {
            public Data()
            {
                assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "GFHelp.Mission.dll");
                typeMap_Controller = assembly.GetType("GFHelp.Mission.Map_Controller");
            }
            public Assembly assembly;
            public Type typeMap_Controller;
            public Type type = null;
            public Type neededType;
            public object missionType;
            public object instance;
            public Data init(string taskMap)
            {

                neededType = typeMap_Controller.GetNestedType(taskMap);
                missionType = neededType.GetField("missionType").GetValue(null);
                instance = assembly.CreateInstance("GFHelp.Mission." + missionType.ToString());
                type = assembly.GetType("GFHelp.Mission." + missionType.ToString());
                return this;
            }
        }


        public void Test(UserData userData)
        {
            userData.battle.Check_Equip_Gun_FULL();
            Data data=null;
            try
            {
                data = new Data().init(userData.normal_MissionInfo.TaskMap);

            }
            catch (Exception e)
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "初始化战斗任务 ERROR", e.ToString());
                userData.normal_MissionInfo.Loop = false;
                return;
            }

            try
            {
                //Invoke()
                MethodInfo methodInfo = data.type.GetMethod(userData.normal_MissionInfo.TaskMap);
                Task methodTask = new Task(() => methodInfo.Invoke(data.instance, new Object[] { userData, userData.normal_MissionInfo }));
                methodTask.Start();
                Task.WaitAll(methodTask);
            }
            catch (Exception e)
            {
                new Log().systemInit("调用作战dll文件出错", e.ToString()).coreError();
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "调用作战dll文件出错", e.ToString()).coreError();
                userData.normal_MissionInfo.Loop = false;
            }
        }

        public void End_At_Battle(Normal_MissionInfo ubti)
        {
            //                    if(this.BattleLoopTime % this.BattleSupportRound == 0)
            ubti.LoopTime++;

            //检查是否需要扩编
            Factory.CombineGun(userData);
            //检查是否需要拆解核心
            Gun_Retire_Core();
            //检查是否需要修复
            //im.userdatasummery.Check_Gun_need_FIX(ubti.Teams, 0.2);
            //检查是否需要重新登陆
            if (ubti.LoopTime % SystemOthers.ConfigData.BL_ReLogin_num == 0)
            {
                userData.eventAction.GetUserInfo();
            }

            //是否达到客服要求 多用于练级
            if (ubti.requestLv != 0 && userData.others.CheckTeamLeval(ubti.Teams[0].TeamID, ubti.requestLv))
            {
                ubti.Loop = false;
            }


            if (ubti.Loop == false)
            {
                return;
            }
            if (ubti.LoopTime < ubti.MaxLoopTime || ubti.MaxLoopTime == 0)
            {
                //继续循环
                ContinueLoopBattle();
            }

        }
        public void Gun_Retire_Core()
        {
            userData.gun_With_User_Info.Get_Gun_Retire();

            if (userData.gun_With_User_Info.Rank3.Count >= 24)
            {
                Thread.Sleep(2000);
                Factory.Gun_retire(userData,3);
                userData.user_Info.core += 24;

            }
        }

        public void ContinueLoopBattle()
        {
            userData.eventAction.TaskBattle_1();
        }
    }
}

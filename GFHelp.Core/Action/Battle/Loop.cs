using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GFHelp.Core.Action
{
    public class MissionData
    {
        public static Assembly assembly = null;
        public static void Reload()
        {
            byte[] by = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "GFHelp.Mission.dll");
            Action.MissionData.assembly = Assembly.Load(by);
        }
    }
    public class Mission
    {

        private UserData userData;
        public Mission(UserData userData)
        {
            this.data = new Data(userData);
            init();
            this.userData = userData;
        }
        public void init()
        {
            if (Action.MissionData.assembly == null)
            {
                byte[] by = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "GFHelp.Mission.dll");
                Action.MissionData.assembly = Assembly.Load(by);
            }
        }


        public void Test()
        {
            userData.battle.Check_Equip_Gun_FULL();

            Data data=null;
            try
            {
                data = new Data(userData).init(userData.MissionInfo.GetFirstData().MissionMap);
            }
            catch (Exception e)
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "初始化战斗任务 ERROR", e.ToString()).userInfo();
                userData.MissionInfo.setFirstDataLoopFalse();
                goto End_At_Battle;
            }

            try
            {
                MethodInfo methodInfo = data.type.GetMethod(userData.MissionInfo.GetFirstData().MissionMap);
                methodInfo.Invoke(data.instance, null);
            }
            catch (Exception e)
            {
                new Log().systemInit("调用作战dll文件出错", e.ToString()).coreError();
                new Log().userInit(userData.GameAccount.GameAccountID, "调用作战dll文件出错", e.ToString()).coreError();
                userData.MissionInfo.setFirstDataLoopFalse();
                goto End_At_Battle;
            }




            End_At_Battle: userData.mission.End_At_Battle();




        }
        public void End_At_Battle()
        {
            //修复
            userData.battle.Check_Gun_need_FIX();


            userData.MissionInfo.GetFirstData().CycleTime++;
            userData.MissionInfo.GetFirstData().DataHandle();
            //检查是否需要扩编
            if (userData.MissionInfo.GetFirstData().AutoCombine)
            {
                userData.Factory.CombineGun();
            }

            //检查是否需要拆解核心
            Gun_Retire_Core();

            //检查是否需要重新登陆
            if (userData.MissionInfo.GetFirstData().CycleTime % SystemOthers.ConfigData.BL_ReLogin_num == 0)
            {
                userData.home.GetUserInfo();
            }

            //是否达到客服要求 多用于练级
            if (userData.MissionInfo.GetFirstData().requestLv != 0 && userData.others.CheckTeamLeval(userData.MissionInfo.GetFirstData().Teams[0].TeamID, userData.MissionInfo.GetFirstData().requestLv))
            {
                userData.MissionInfo.GetFirstData().Loop = false;
            }

            //循环次数要求
            if(userData.MissionInfo.GetFirstData().CycleTime> userData.MissionInfo.GetFirstData().MaxCycleNumber && userData.MissionInfo.GetFirstData().MaxCycleNumber!=0)
            {
                userData.MissionInfo.GetFirstData().Loop = false;
            }
            if (userData.MissionInfo.GetFirstData().CommanderLv < userData.user_Info.lv && userData.MissionInfo.GetFirstData().CommanderLv != 0)
            {
                userData.MissionInfo.GetFirstData().Loop = false;
            }



            //核心要求
            if (userData.MissionInfo.GetFirstData().StopLoopByNumberCoreR && (userData.MissionInfo.GetFirstData().NumberCore > userData.MissionInfo.GetFirstData().NumberCoreRequire))
            {
                userData.MissionInfo.GetFirstData().Loop = false;
            }

            if (userData.MissionInfo.GetFirstData().MissionMap == "mapcorridor")
            {
                userData.MissionInfo.GetFirstData().Loop = false;
            }

            if (userData.MissionInfo.GetFirstData().Loop == false)
            {
                PrintRecycleLog();
                userData.battle.Check_Gun_need_FIX(true);
                userData.MissionInfo.listTask.RemoveAt(0);
            }




            userData.webData.StatusBarText = "空闲";
            if (userData.MissionInfo.listTask.Count == 0)
            {
                return;
            }

        }
        private void PrintRecycleLog()
        {
            int cycleTimes = userData.MissionInfo.GetFirstData().CycleTime;

            int MP = userData.MissionInfo.GetFirstData().recycleLog.Mp;
            int AMMO = userData.MissionInfo.GetFirstData().recycleLog.Ammo;
            int MRE = userData.MissionInfo.GetFirstData().recycleLog.Mre;
            int PART = userData.MissionInfo.GetFirstData().recycleLog.Part;

            int COIN1 = userData.MissionInfo.GetFirstData().recycleLog.Coin1;
            int COIN2 = userData.MissionInfo.GetFirstData().recycleLog.Coin2;
            int COIN3 = userData.MissionInfo.GetFirstData().recycleLog.Coin3;
            int NumGun = userData.MissionInfo.GetFirstData().recycleLog.Gun;

            string SummaryStatement = string.Format("战斗任务结束,获得 人力 {0} 子弹 {1} 口粮 {2} 零件 {3} 初级资料 {4} 中级资料 {5} 高级资料 {6} 人形 {7}", MP, AMMO, MRE, PART, COIN1, COIN2, COIN3, NumGun);

            new Log().userInit(userData.GameAccount.GameAccountID, SummaryStatement).userInfo();



        }


        public void Gun_Retire_Core()
        {
            userData.gun_With_User_Info.Get_Gun_Retire();

            if (userData.gun_With_User_Info.Rank3.Count >= 24)
            {
                Thread.Sleep(2000);
                userData.Factory.Gun_retire(3);
                userData.user_Info.core += 24;

            }
        }

        Data data;
        class Data
        {
            public Data(UserData userData)
            {
                this.userData = userData;
            }
            public UserData userData;
            public Type typeMap_Controller;
            public Type type = null;
            public Type neededType;
            public object missionType;
            public object instance;
            public Data init(string taskMap)
            {
                typeMap_Controller = Action.MissionData.assembly.GetType("GFHelp.Mission.Map_Controller");
                neededType = typeMap_Controller.GetNestedType(taskMap);
                missionType = neededType.GetField("missionType").GetValue(null);

                
                instance = Action.MissionData.assembly.CreateInstance("GFHelp.Mission." + missionType.ToString(), 
                    false,
                    BindingFlags.CreateInstance,
                    null,
                    new Object[] { userData },
                    null,
                    null
                    );
                type = Action.MissionData.assembly.GetType("GFHelp.Mission." + missionType.ToString());
                return this;
            }
        }
    }
}

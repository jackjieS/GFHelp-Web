using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace GFHelp.Core.Action
{
    public class Mission
    {
        private UserData userData;
        static Assembly assembly;

        static Type typeNormal;
        static Type typeActivity;
        static Type typeSimulation;
        static Type typeMap_Sent;
        //static object instanceNormal;
        //static object instanceActivity;
        //static object instanceSimulation;
        //static object instanceMap_Sent;
        public void SetUserdata(UserData ud)
        {
            userData = ud;
        }

        public static void initialize()
        {
            //加载程序集(dll文件地址)，使用Assembly类   
            assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "GFHelp.Mission.dll");
            //获取类型，参数（名称空间+类）   
            typeNormal = assembly.GetType("GFHelp.Mission.Normal");
            typeActivity = assembly.GetType("GFHelp.Mission.Activity");
            typeSimulation = assembly.GetType("GFHelp.Mission.Simulation");
            typeMap_Sent = assembly.GetType("GFHelp.Mission.Map_Sent");
            //创建该对象的实例，object类型，参数（名称空间+类）   
            //instanceNormal = assembly.CreateInstance("GFHelp.Mission.Normal");
            //instanceActivity = assembly.CreateInstance("GFHelp.Mission.Activity");
            //instanceSimulation = assembly.CreateInstance("GFHelp.Mission.Simulation");
            //instanceMap_Sent = assembly.CreateInstance("GFHelp.Mission.Map_Sent");



        }

        public void Test(UserData userData)
        {


            userData.others.Check_Equip_GUN_FULL();

            //userData.normal_MissionInfo.TaskMap;
            Type neededType = typeMap_Sent.GetNestedType(userData.normal_MissionInfo.TaskMap);
            var missionType = neededType.GetField("missionType").GetValue(null);
            var instance = assembly.CreateInstance("GFHelp.Mission."+ missionType.ToString());
            Type type = assembly.GetType("GFHelp.Mission." + missionType.ToString());
            try
            {
                object value = type.GetMethod(userData.normal_MissionInfo.TaskMap).Invoke(instance, new Object[] { userData, userData.normal_MissionInfo });
            }
            catch (Exception e)
            {
                new Log().systemInit("调用作战dll文件出错", e.ToString()).coreError();
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "调用作战dll文件出错", e.ToString()).coreError();
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
                userData.Task.Add(TaskList.GetuserInfo);

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
            userData.Task.Add(TaskList.TaskBattle_1);
        }
    }
}

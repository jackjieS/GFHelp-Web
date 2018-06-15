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
        static object instanceNormal;
        public void SetUserdata(UserData ud)
        {
            userData = ud;
        }

        public static void Seed()
        {
            assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "Mission.dll");//加载程序集(dll文件地址)，使用Assembly类   
            typeNormal = assembly.GetType("Mission.Normal");            //获取类型，参数（名称空间+类） 
            instanceNormal = assembly.CreateInstance("Mission.Normal");//创建该对象的实例，object类型，参数（名称空间+类）   
        }

        public void Loop(Normal_MissionInfo normal_MissionInfo)
        {

            //加载dll后,需要使用dll中某类.

            //设置Show_Str方法中的参数类型，Type[]类型；如有多个参数可以追加多个   
            Type[] params_type = new Type[1];
            params_type[0] = Type.GetType("Normal_MissionInfo");
            //设置Show_Str方法中的参数值；如有多个参数可以追加多个   
            Object[] params_obj = new Object[1];
            params_obj[0] = normal_MissionInfo;
            //执行Show_Str方法   
            object value = typeNormal.GetMethod("Show_Str", params_type).Invoke(instanceNormal, params_obj);



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
            if (ubti.LoopTime % SysteOthers.ConfigData.BL_ReLogin_num == 0)
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

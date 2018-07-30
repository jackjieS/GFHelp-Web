using GFHelp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GFHelp.Core.MulitePlayerData
{
    public class Function
    {
        public static string FindGunName_GunId(int gun_id)
        {

            //在catchdata里找对应的枪
            try
            {
                foreach (var k in CatachData.listGunInfo)
                {
                    if (gun_id == k.id)
                    {
                        return k.name;
                    }
                }
            }
            catch (Exception e)
            {
                new Log().systemInit("读取UserData_equip_with_user_info", e.ToString()).coreError();

            }

            return "";
        }

        /// <summary>
        /// 返回将会升级的数目
        /// </summary>
        /// <param name="addexp"></param>
        /// <param name="current_exp"></param>
        /// <param name="current_level"></param>
        /// <returns></returns>
        public static int Update_GUN_exp_level(int addexp, int current_exp, int current_level)
        {
            int num = 0;//将会升级的数目
            if (current_level == 120)
            {
                return 0;
            }
            else
            {
                if (ExpToLevel(addexp + current_exp) == current_level)
                {
                    ;
                }
                else
                {
                    return ExpToLevel(addexp + current_exp) - current_level;
                }
            }

            return num;//返回升了多少次级和ref addexp 所剩下的
        }

        /// <summary>
        /// 返回的是所有经验对应的等级
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="isUser"></param>
        /// <returns></returns>
        public static int ExpToLevel(int exp, bool isUser = false)
        {
            int num = 0;
            while ((exp -= CurrentLeveMaxExp(++num, isUser)) >= 0)
            {
            }
            return num;
        }

        /// <summary>
        /// 获取等级的最大经验
        /// </summary>
        /// <param name="level"></param>
        /// <param name="isUser"></param>
        /// <returns></returns>
        public static int CurrentLeveMaxExp(int level, bool isUser = false)
        {
            if (isUser)
            {
                if (level <= 25)
                {
                    return level * 100;
                }
                if (level <= 99)
                {
                    return 100 * Mathf.FloorToInt(Mathf.Pow((float)level * 0.2f, 2f));
                }
                if (level <= 199)
                {
                    return 100 * Mathf.FloorToInt(Mathf.Pow((float)level * 0.11f, 2.5f));
                }
                return 100 * Mathf.FloorToInt(Mathf.Pow((float)level * 0.0118f, 9f));
            }
            else
            {
                foreach (var item in CatachData.gun_exp_info)
                {
                    if (level == item.Key)
                        return item.Value;
                }
                return 0;
            }
        }

        public static void SetTeamInfo(Management.UserData userData )
        {
            userData.Teams.Clear();
            try
            {
                for (int i = 1; i <= userData.user_Info.maxteam; i++)
                {
                    //一个小队一个小队寻找
                    Dictionary<int, Gun_With_User_Info> Dic_gwui = new Dictionary<int, Gun_With_User_Info>();
                    foreach (var item in userData.gun_With_User_Info.dicGun)
                    {
                        if (item.Value.teamId == i)
                        {
                            Dic_gwui.Add(item.Value.location, item.Value);
                        }
                    }
                    userData.Teams.Add(i, Dic_gwui);
                }
            }
            catch (Exception e)
            {
                new Log().systemInit("建立梯队字典出现错误", e.ToString()).coreError();
            }
        }




    }
}

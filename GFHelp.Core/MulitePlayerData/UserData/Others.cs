using Codeplex.Data;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GFHelp.Core.MulitePlayerData
{
    public class Others
    {
        private UserData userData;
        public Others(UserData userData)
        {
            this.userData = userData;
        }
        public bool Mission_S;
        public bool ClickGrilsFavor;

        public void Read(dynamic jsonobj)
        {
            ClickGrilsFavor = true;
            Mission_S = false;
            try
            {
                string data = jsonobj.mission_act_info.ToString();
                if (data.Length > 10)
                {
                    Mission_S = true;
                }
            }
            catch (Exception)
            {
                return;
            }
        }









        public bool CheckGunStatus(Gun_With_User_Info gwui)
        {
            //是否在后勤 自律 训练
            foreach (var x in userData.operation_Act_Info.dicOperation)
            {
                if (x.Value.team_id == gwui.teamId)
                {
                    return true;
                }

            }
            if (userData.auto_Mission_Act_Info.team_ids.Contains(gwui.teamId)) return true;
            foreach (var y in userData.upgrade_Act_Info.dic_Upgrade)
            {
                if (y.Value.gun_with_user_id == gwui.id) return true;
            }
            return false;
        }

        /// <summary>
        /// 获取当前需要强化的人形
        /// </summary>
        /// <returns></returns>
        public void Get_dicGun_PowerUP()
        {
            userData.gun_With_User_Info.dicGun_PowerUP.Clear();
            foreach (var item in userData.gun_With_User_Info.dicGun)
            {
                if (item.Value.level < 10) continue;
                if (CheckGunStatus(item.Value)) continue;
                if (item.Value.maxAddDodge > item.Value.additionDodge || item.Value.maxAddHit > item.Value.additionHit || item.Value.maxAddPow > item.Value.additionPow || item.Value.maxAddRate > item.Value.additionRate)
                {
                    userData.gun_With_User_Info.dicGun_PowerUP.Add(item.Value);
                }
            }
        }

        public bool CheckTeamLeval(int teamid, int lv)
        {
            foreach (var item in userData.Teams[teamid])
            {
                if (item.Value.level < lv)
                {
                    return false;
                }
            }
            return true;
        }

        public void BattleFinish_ammo_mrc(int teamid)
        {
            for (int i = 1; i <= 5; i++)
            {
                if (!userData.Teams.ContainsKey(teamid)) return;
                if (userData.Teams[teamid].ContainsKey(i))
                {
                    //存在这个队员
                    if (userData.Teams[teamid][i].ammo > 0)
                    {
                        userData.Teams[teamid][i].ammo--;
                    }
                    if (userData.Teams[teamid][i].mre > 0)
                    {
                        userData.Teams[teamid][i].mre--;
                    }
                }
            }
        }

        public bool Check_Equip_GUN_FULL()
        {
            if (userData.gun_With_User_Info.dicGun.Count + SystemOthers.ConfigData.UpdateCache >= userData.user_Info.maxgun)
            {
                return true;
            }
            if (userData.equip_With_User_Info.listEquip.Count + SystemOthers.ConfigData.UpdateCache >= userData.user_Info.maxequip)
            {
                return true;
            }
            return false;

        }

        public int GetSimulatieDataType()
        {
            int coin1 = userData.user_Info.coin1;
            int coin2 = userData.user_Info.coin2;
            int coin3 = userData.user_Info.coin3;
            int min = Math.Min(Math.Min(coin1, coin2), coin3);
            if (coin1 == min)
            {
                return 1;
            }
            if (coin2 == min)
            {
                return 2;
            }
            return 3;
        }



    }

}

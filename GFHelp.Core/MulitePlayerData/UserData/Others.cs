using Codeplex.Data;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GFHelp.Core.MulitePlayerData
{
    public class Others
    {
        private UserData userData;
        public Others(UserData userData)
        {
            this.userData = userData;
        }
        public bool ClickGrilsFavor;
        static object locker = new object();
        public void Read(dynamic jsonobj)
        {
            ClickGrilsFavor = true;

        }

        public void Minit()
        {
            if (userData.config.M == false)
            {
                userData.config.FinalLoginSuccess = true;//开始自动任务循环
                return;
            }


            if (userData.mission_With_User_Info.CheckMissionisOpen() == false)
            {
                userData.operation_Act_Info.StopAllOperation();
                userData.mission_With_User_Info.MHandel();
                TeamBuildAndStartOperation();
                return;
            }
            if (userData.mission_With_User_Info.CheckMissionisOpen() == true)
            {
                //检查人形等级
                if (CheckGunsLeval(48) == false)
                {
                    userData.operation_Act_Info.StopAllOperation();
                    userData.mission_With_User_Info.Add0_2Level50();
                    TeamBuildAndStartOperation();
                    return;
                }
                //这里没问题
                userData.operation_Act_Info.StartMissing();
                userData.config.FinalLoginSuccess = true;//开始自动任务循环
                return;
            }
        }

        public void SetTeamInfo()
        {
            lock (locker)
            {
                userData.Teams.Clear();
                try
                {
                    for (int i = 1; i <= userData.user_Info.maxteam; i++)
                    {
                        //一个小队一个小队寻找
                        Dictionary<int, Gun_With_User_Info.Data> Dic_gwui = new Dictionary<int, Gun_With_User_Info.Data>();
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
        public void TeamBuildAndStartOperation()
        {

            while (userData.MissionInfo.listTask.Count!=0)
            {
                Thread.Sleep(5000);
            }

            if(CheckGunsLeval(48) == false)
            {
                userData.mission_With_User_Info.Add0_2Level50();
            }
            while (userData.MissionInfo.listTask.Count != 0)
            {
                Thread.Sleep(5000);
            }

            EmptyTeams();

            TeamsBuildLeaderLevel50();

            initTeam();
            userData.home.GetUserInfo();
            //login检测
            userData.operation_Act_Info.StartAllOperationM();
            userData.config.FinalLoginSuccess = true;//开始自动任务循环


        }





        public bool CheckTeamM()
        {

            if (CheckTeamLeaderLevel(50) == false) return false;
            for (int i = 1; i <= userData.user_Info.maxteam; i++)
            {
                if (userData.Teams[i].Count != 5) return false;
            }
            return true;
        }

        public bool CheckTeamLeaderLevel(int level)
        {
            if (userData.Teams[1].Count == 0) return false;
            for (int i = 1; i <= userData.user_Info.maxteam; i++)
            {
                foreach (var Gun in userData.Teams[i])
                {
                    if (Gun.Value.location == 1)
                    {
                        if (Gun.Value.level < level) return false;
                    }
                }
            }
            return true;

        }

        public void EmptyTeams()
        {
            for (int i = 1; i <= userData.user_Info.maxteam; i++)
            {
                if (userData.Teams.ContainsKey(i))
                {
                    for (int y = 1; y <= 5; y++)
                    {
                        if (userData.Teams[i].ContainsKey(y))
                        {
                            userData.battle.BuildTeam(i, 0, userData.Teams[i][y].location);
                            userData.Teams[i][y].teamId = 0;
                            userData.Teams[i].Remove(y);
                        }
                    }
                }

            }


        }

        public void TeamBuildLeaderLevel50(int teamID)
        {
            if (userData.Teams[teamID].ContainsKey(1))
            {
                if (userData.Teams[teamID][1].level > 50) return;
            }
                          

            Dictionary<int, Gun_With_User_Info.Data> dicGun = userData.gun_With_User_Info.dicGun;
            var listGun = dicGun.OrderByDescending(o => o.Value.level).ToList();
            listGun.RemoveAll(o => o.Value.teamId != 0);
            if (userData.Teams[teamID].ContainsKey(1))
            {
                userData.Teams[teamID][1].teamId = 0;
            }




            userData.battle.BuildTeam(teamID, listGun[0].Value.id, 1);
            listGun[0].Value.teamId = teamID;
            userData.Teams[teamID][1] = listGun[0].Value;
        }

        public void EmptyTeam(int teamID)
        {
            for (int i = 2; i <= 5; i++)
            {
                if (userData.Teams[teamID].ContainsKey(i))
                {
                    userData.battle.BuildTeam(teamID, 0, userData.Teams[teamID][i].location);
                    userData.Teams[teamID][i].teamId = 0;
                    userData.Teams[teamID].Remove(i);
                }
            }
        }
        public void TeamMemberRefill(int teamID)
        {
            Dictionary<int, Gun_With_User_Info.Data> dicGun = userData.gun_With_User_Info.dicGun;
            var listGun = dicGun.OrderByDescending(o => o.Value.info.rank).ToList();
            listGun.RemoveAll(o => o.Value.teamId != 0);
            List<int> IDteammates = new List<int>();
            int Index = 0;
            foreach (var gun in userData.Teams[teamID])
            {
                IDteammates.Add(gun.Value.info.id);
            }
            for (int i = userData.Teams[teamID].Count + 1; i <= 5; i++)
            {


                while (true)
                {
                    if (IDteammates.Contains(listGun[Index].Value.info.id))
                    {
                        Index++;
                        continue;
                    }
                    userData.battle.BuildTeam(teamID, listGun[Index].Value.id, i);
                    IDteammates.Add(listGun[Index].Value.info.id);
                    Index++;
                    break;

                }
            }

        }

        public bool CheckTeamLeaderLvTeamMember()
        {
            for (int i = 1; i <= 4; i++)
            {
                if (userData.Teams[i].Count != 5) return false;
                if (userData.Teams[i][1].level < 46) return false;
            }

            return true;



        }


        public void TeamsBuildLeaderLevel50()
        {
            if (CheckTeamLeaderLevel(50)) return;
            Dictionary<int, Gun_With_User_Info.Data> dicGun = userData.gun_With_User_Info.dicGun;
            var listGun = dicGun.OrderByDescending(o => o.Value.level).ToList();
            int Index = 0;

            for (int i = 1; i <= userData.user_Info.maxteam; i++)
            {
                userData.battle.BuildTeam(i, listGun[Index].Value.id, 1);
                listGun[Index].Value.teamId = i;
                if (userData.Teams[i].ContainsKey(1))
                {
                    userData.Teams[i][1] = listGun[Index].Value;
                }
                else
                {
                    userData.Teams[i].Add(1, listGun[Index].Value);
                }

                Index++;
            }





        }

        public List<Gun_With_User_Info.Data> getListGun()
        {

            List<Gun_With_User_Info.Data> datas = new List<Gun_With_User_Info.Data>();
            foreach (var item in userData.gun_With_User_Info.dicGun)
            {
                if (item.Value.teamId == 0)
                    datas.Add(item.Value);
            }
            return datas.OrderByDescending(o => o.info.rank).ToList();
        }

        public void initTeam()
        {
            if (userData.config.M == false) return;


            var listGun = getListGun();

            //全部从1开始
            int Index = 0;

            try
            {
                for (int i = 1; i <= userData.user_Info.maxteam; i++)
                {
                    if (userData.Teams[i].Values.Count == 5) continue;
                    List<int> IDteammates = new List<int>();
                    foreach (var gun in userData.Teams[i])
                    {
                        IDteammates.Add(gun.Value.info.id);
                    }
                    for (int L = 1; L <= 5; L++)
                    {
                        if (userData.Teams[i].ContainsKey(L)) continue;

                        while (true)
                        {
                            if (IDteammates.Contains(listGun[Index].info.id))
                            {
                                Index++;
                                continue;
                            }
                            userData.battle.BuildTeam(i, listGun[Index].id, L);
                            userData.Teams[i].Add(L, listGun[Index]);
                            IDteammates.Add(listGun[Index].info.id);
                            listGun[Index].teamId = i;
                            Index++;
                            break;

                        }

                    }
                }
            }
            catch (Exception e)
            {
                new Log().systemInit("{0} 初始化编队错误", userData.GameAccount.GameAccountID).coreError();
            }

        }


        public bool CheckTeamStatus(int ID)
        {
            //是否在后勤 自律 训练 0血

            if (!userData.Teams.ContainsKey(ID)) return false;
            if (userData.Teams[ID].Count == 0) return false;

            foreach (var x in userData.operation_Act_Info.dicOperation)
            {
                if (x.Value.team_id == ID)
                {
                    return false;
                }

            }

            if (userData.auto_Mission_Act_Info.CheckTeamStatus(ID)) return false;

            foreach (var item in userData.Teams[ID])
            {
                if (userData.upgrade_Act_Info.isUpgradING(item.Value.id)) return false;
            }
            foreach (var item in userData.Teams[ID])
            {
                if (item.Value.life == 0) return false;
            }
            return true;
        }
        public List<int> getAvailableTeamID()
        {
            List<int> teamID = new List<int>();
            for (int i = 1; i <= userData.user_Info.maxteam; i++)
            {
                if (CheckTeamStatus(i)) teamID.Add(i);
            }
            return teamID;
        }
        public List<int> getAvailableTeamIDAndLeaderLevel(int level)
        {
            List<int> teamID = new List<int>();
            for (int i = 1; i <= userData.user_Info.maxteam; i++)
            {
                if (CheckTeamStatus(i) && userData.Teams[i][1].level>=level) teamID.Add(i);
            }
            return teamID;
        }


        public bool CheckGunStatus(Gun_With_User_Info.Data gwui)
        {
            //是否在后勤 自律 训练 0血
            foreach (var x in userData.operation_Act_Info.dicOperation)
            {
                if (x.Value.team_id == gwui.teamId)
                {
                    return true;
                }

            }
            if (userData.auto_Mission_Act_Info.CheckGunStatus(gwui)) return true;
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
                if (item.Value.info.id == 196) continue;
                if (item.Value.maxAddDodge > item.Value.additionDodge || item.Value.maxAddHit > item.Value.additionHit || item.Value.maxAddPow > item.Value.additionPow || item.Value.maxAddRate > item.Value.additionRate)
                {
                    userData.gun_With_User_Info.dicGun_PowerUP.Add(item.Value);
                }
            }
        }

        public bool CheckTeamMemberLevel(int teamID,int lv)
        {
            foreach (var gun in userData.Teams[teamID])
            {
                if (gun.Value.level < lv) return false;
            }
            return true;


        }
        public bool CheckGunsLeval(int lv)
        {
            int count = 0;
            foreach (var Gun in userData.gun_With_User_Info.dicGun)
            {
                if (Gun.Value.level >= lv) count++;
            }


            if (count < 4) return false;
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
            if (userData.gun_With_User_Info.dicGun.Count + SystemManager.ConfigData.UpdateCache >= userData.user_Info.maxgun)
            {
                return true;
            }
            if (userData.equip_With_User_Info.listEquip.Count + SystemManager.ConfigData.UpdateCache >= userData.user_Info.maxequip)
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

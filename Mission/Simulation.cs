using System;
using System.Collections.Generic;
using System.Text;
using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Management;

namespace GFHelp.Mission
{
    class Simulation
    {
        public static string Test()
        {
            return "Hello world";
        }

        private Normal_MissionInfo seedmap(UserData userData,int teamID)
        {

            Team team = new Team();
            Battle battle = new Battle();
            team.Key = 0;
            team.Skt = 26643;
            team.Teamid = teamID;
            battle.Teams[0] = team;
            Normal_MissionInfo normal_MissionInfo = new Normal_MissionInfo(userData, battle);
            return normal_MissionInfo;
        }
        private bool Startmap(UserData userData,ref Map_Controller.mapcorridor map,ref Normal_MissionInfo normal_MissionInfo)
        {
            foreach (var item in userData.Teams)
            {

                normal_MissionInfo = seedmap(userData, item.Key);
                map = new Map_Controller.mapcorridor(normal_MissionInfo);
                if (userData.battle.startMission(map.mission_id, map.Mission_Start_spots) == 1)
                {
                    return true;
                }
            }

            return false;
        }



        public void mapcorridor(UserData userData)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Normal_MissionInfo ubti= new Normal_MissionInfo();
            Map_Controller.mapcorridor map = new Map_Controller.mapcorridor();
            if (Startmap(userData, ref map,ref ubti) == false) return;

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove_Random(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove_Random(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove_Random(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove_Random(map.dic_TeamMove[stepNum++]);

            battledata = new BattleData(ubti.Teams).setData(5520, 0, 0, random.Next(8, 10), 26483, 28819, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
        }
    }
}

using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Text.RegularExpressions;
namespace GFHelp.Mission
{
    class Activity
    {
        public static void mapcubee1_4(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.mapcubee1_4.spots1.team_id = ubti.Teams[0].TeamID;//主力
            Map_Sent.mapcubee1_4.spots2.team_id = ubti.Teams[1].TeamID;//辅助
            Map_Sent.mapcubee1_4.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.mapcubee1_4.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.mapcubee1_4.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.mapcubee1_4.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.mapcubee1_4.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.mapcubee1_4.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.mapcubee1_4.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.mapcubee1_4.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            if (userData.battle.startMission(Map_Sent.mapcubee1_4.mission_id, Map_Sent.mapcubee1_4.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(Map_Sent.mapcubee1_4.dic_TeamMove[stepNum++]);
            userData.battle.reinforceTeam(Map_Sent.mapcubee1_4.spots2,true);
            result =  userData.battle.endTurn();
            //Check point 3244
            if(Map_Sent.Function.Night_PosCheck_type1(result, 3244) == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3244, 0, 0, random.Next(8, 10), 10380, 24608, 900026, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.mapcubee1_4.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.mapcubee1_4.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(3246, 0, 0, random.Next(8, 10), 10380, 24608, 900026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.mapcubee1_4.dic_TeamMove[stepNum++]);
            string Endresult = userData.battle.endTurn();
            //Check point 3244
            if (Map_Sent.Function.Night_PosCheck_type1(Endresult, 3243) == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3243, 1, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (Map_Sent.Function.Night_PosCheck_type1(Endresult, 3247) == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3247, 0, 0, random.Next(8, 10), 4136, 7392, 10016, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.mapcubee1_4.dic_TeamMove[stepNum++]);
            if (Map_Sent.Function.Night_PosCheck_type1(Endresult, 3240) == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3240, 0, 0, random.Next(8, 10), 4136, 7392, 10016, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            userData.battle.teamMove(Map_Sent.mapcubee1_4.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(3233, 0, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.mapcubee1_4.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(3234, 0, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.mapcubee1_4.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(3235, 0, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.abortMission();












        }

        public static void maparctic1_4(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.maparctic1_4.spots1.team_id = ubti.Teams[0].TeamID;//主力
            Map_Sent.maparctic1_4.spots2.team_id = ubti.Teams[1].TeamID;//辅助
            Map_Sent.maparctic1_4.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.maparctic1_4.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.maparctic1_4.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.maparctic1_4.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.maparctic1_4.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.maparctic1_4.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.maparctic1_4.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.maparctic1_4.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;

            Map_Sent.maparctic1_4.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.maparctic1_4.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            Map_Sent.maparctic1_4.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;
            Map_Sent.maparctic1_4.dic_TeamMove[11].team_id = ubti.Teams[0].TeamID;
            if (userData.battle.startMission(Map_Sent.maparctic1_4.mission_id, Map_Sent.maparctic1_4.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]);
            userData.battle.reinforceTeam(Map_Sent.maparctic1_4.spots2);//
            result = userData.battle.endTurn();
            //Map_Sent.Function.Night_PosCheck_type1(result, 3244) == 1
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            if (userData.battle.teamMove_Random(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]) == 1)
            {
                battledata = new BattleData(ubti.Teams).setData(2057, 0, 0, random.Next(8, 10), 3344, 5716, 10004, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.teamMove(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]);
            battledata = new BattleData(ubti.Teams).setData(2210, 0, 0, random.Next(8, 10), 3344, 5716, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]);
            string battleResult = userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]);
            battledata = new BattleData(ubti.Teams).setData(2260, 0, 0, random.Next(8, 10), 18513, 16404, 900051, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]);
            if (Map_Sent.Function.Normal_PosCheck_type2(battleResult, 2262) == 1)
            {
                battledata = new BattleData(ubti.Teams).setData(2262, 0, 0, random.Next(8, 10), 3744, 5720, 10001, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }

            }
            battleResult = userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]);
            battledata = new BattleData(ubti.Teams).setData(2263, 0, 0, random.Next(8, 10), 18513, 16404, 900051, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]);

            // 
            if(Map_Sent.Function.Normal_PosCheck_type2(battleResult, 2253) == 1)
            {
                battledata = new BattleData(ubti.Teams).setData(2253, 0, 0, random.Next(8, 10), 3044, 3812, 10008, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            result = userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]);
            battledata = new BattleData(ubti.Teams).setData(2252, 0, 0, random.Next(8, 10), 3534, 9597, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.maparctic1_4.dic_TeamMove[stepNum++]);
            battledata = new BattleData(ubti.Teams).setData(2060, 0, 0, random.Next(8, 10), 10641, 18808, 900052, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
        }
    }
}

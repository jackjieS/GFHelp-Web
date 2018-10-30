using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Text.RegularExpressions;
using static GFHelp.Mission.Map_Controller;

namespace GFHelp.Mission
{
    class Activity
    {
        public static void mapcubee1_4(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcubee1_4 mapcubee1_4 = new Map_Controller.mapcubee1_4(data);
            if (userData.battle.startMission(mapcubee1_4, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(mapcubee1_4.dic_TeamMove[stepNum++]);
            userData.battle.reinforceTeam(mapcubee1_4.spots2,true);
            result =  userData.battle.endTurn(data);
            //Check point 3244
            if(Function.Night_PosCheck_type1(result, 3244) == 1)
            {
                
                battledata = new BattleData(data.Teams).setData(3244, 0, 0, random.Next(8, 10), 10380, 24608, 900026, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(mapcubee1_4.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(mapcubee1_4.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(data.Teams).setData(3246, 0, 0, random.Next(8, 10), 10380, 24608, 900026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(mapcubee1_4.dic_TeamMove[stepNum++]);
            string Endresult = userData.battle.endTurn(data);
            //Check point 3244
            if (Function.Night_PosCheck_type1(Endresult, 3243) == 1)
            {
                
                battledata = new BattleData(data.Teams).setData(3243, 1, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Night_PosCheck_type1(Endresult, 3247) == 1)
            {
                
                battledata = new BattleData(data.Teams).setData(3247, 0, 0, random.Next(8, 10), 4136, 7392, 10016, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(mapcubee1_4.dic_TeamMove[stepNum++]);
            if (Function.Night_PosCheck_type1(Endresult, 3240) == 1)
            {
                
                battledata = new BattleData(data.Teams).setData(3240, 0, 0, random.Next(8, 10), 4136, 7392, 10016, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(mapcubee1_4.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(data.Teams).setData(3233, 0, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(mapcubee1_4.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(data.Teams).setData(3234, 0, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(mapcubee1_4.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(data.Teams).setData(3235, 0, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.abortMission();












        }

        public static void maparctic1_4(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            maparctic1_4 maparctic1_4 = new maparctic1_4(data);
            if (userData.battle.startMission(maparctic1_4, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(maparctic1_4.dic_TeamMove[stepNum++]);
            userData.battle.reinforceTeam(maparctic1_4.spots2);//
            result = userData.battle.endTurn(data);
            //Function.Night_PosCheck_type1(result, 3244) == 1
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            if (userData.battle.teamMove_Random(maparctic1_4.dic_TeamMove[stepNum++]) == 1)
            {
                battledata = new BattleData(data.Teams).setData(2057, 0, 0, random.Next(8, 10), 3344, 5716, 10004, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(maparctic1_4.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(2210, 0, 0, random.Next(8, 10), 3344, 5716, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(maparctic1_4.dic_TeamMove[stepNum++]);
            string battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(maparctic1_4.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(2260, 0, 0, random.Next(8, 10), 18513, 16404, 900051, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(maparctic1_4.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(maparctic1_4.dic_TeamMove[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 2262) == 1)
            {
                battledata = new BattleData(data.Teams).setData(2262, 0, 0, random.Next(8, 10), 3744, 5720, 10001, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }

            }
            battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(maparctic1_4.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(2263, 0, 0, random.Next(8, 10), 18513, 16404, 900051, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(maparctic1_4.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(maparctic1_4.dic_TeamMove[stepNum++]);

            // 
            if(Function.Normal_PosCheck_type2(battleResult, 2253) == 1)
            {
                battledata = new BattleData(data.Teams).setData(2253, 0, 0, random.Next(8, 10), 3044, 3812, 10008, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            result = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(maparctic1_4.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(2252, 0, 0, random.Next(8, 10), 3534, 9597, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(maparctic1_4.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(2060, 0, 0, random.Next(8, 10), 10641, 18808, 900052, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
        }


        public void mapcte1_1(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_1 map = new Map_Controller.mapcte1_1(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);

            battledata = new BattleData(data.Teams).setData(7245, 0, 0, random.Next(8, 10), 920, 1128, 10001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.endTurn(data);
        }

        public void mapcte1_2(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_2 map = new Map_Controller.mapcte1_2(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);

            battledata = new BattleData(data.Teams).setData(7256, 0, 0, random.Next(8, 10), 1220, 1512, 10001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.spots2);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7257, 0, 0, random.Next(8, 10), 724, 1208, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7262, 0, 0, random.Next(8, 10), 1340, 2420, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7264, 0, 0, random.Next(8, 10), 1220, 1512, 10001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7259, 0, 0, random.Next(8, 10), 724, 1208, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7258, 0, 0, random.Next(8, 10), 1220, 1512, 10001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



        }

        public void mapcte1_3(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_3 map = new Map_Controller.mapcte1_3(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7276, 0, 0, random.Next(8, 10), 1432, 2592, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7274, 0, 0, random.Next(8, 10), 1432, 2592, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7273, 0, 0, random.Next(8, 10), 2108, 4004, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7281, 0, 0, random.Next(8, 10), 2208, 2592, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
        }

        public void mapcte1_4type1(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_4type1 map = new Map_Controller.mapcte1_4type1(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.reinforceTeam(map.spots2);


            userData.battle.endTurn(data);
            battledata = new BattleData(data.Teams).setData(7282, 1, 0, random.Next(8, 10), 2040, 3620, 10002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7287, 0, 0, random.Next(8, 10), 2780, 2776, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);

            userData.battle.endTurn(data);
        }

        public void mapcte1_5(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_5 map = new Map_Controller.mapcte1_5(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7305, 0, 0, random.Next(8, 10), 2504, 4628, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.spots2);


            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7307, 0, 0, random.Next(8, 10), 3086, 2702, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7312, 0, 0, random.Next(8, 10), 9872, 17200, 900118, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

        }

        public void mapcte1_6(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_6 map = new Map_Controller.mapcte1_6(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.reinforceTeam(map.spots2);

            string battleResult =  userData.battle.endTurn(data);

            if(Function.Normal_PosCheck_type2(battleResult, 7282) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7282, 1, 0, random.Next(8, 10), 2040, 3620, 10002, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }



            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7287, 0, 0, random.Next(8, 10), 2780, 2776, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);



            userData.battle.endTurn(data);


        }



        public void mapcte1_7(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_7 map = new Map_Controller.mapcte1_7(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7335, 0, 0, random.Next(8, 10), 2744, 9628, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.spots2);


            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7333, 0, 0, random.Next(8, 10), 3444, 6304, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            string endturnResult = userData.battle.endTurn(data);
            if(Function.Normal_PosCheck_type2(endturnResult, 7326)==1)
            {
                battledata = new BattleData(data.Teams).setData(7326, 1, 0, random.Next(8, 10), 2744, 4628, 10004, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.saveHostage("7328");

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.saveHostage("7328");


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7330, 0, 0, random.Next(8, 10), 3652, 4628, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.saveHostage("7328");

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7338, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);

            userData.battle.endTurn(data);

            battledata = new BattleData(data.Teams).setData(7341, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.endTurn(data);

            battledata = new BattleData(data.Teams).setData(7341, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7338, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.saveHostage("7328");


        }


        public void mapcte1_8(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_8 map = new Map_Controller.mapcte1_8(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);


            userData.battle.reinforceTeam(map.spots2);

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            battledata = new BattleData(data.Teams).setData(7351, 0, 0, random.Next(8, 10), 4906, 3508, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            battledata = new BattleData(data.Teams).setData(7377, 1, 0, random.Next(8, 10), 3950, 11994, 10028, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }







            userData.battle.endOtherSideTurn();

            userData.battle.startTurn(data);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7402, 0, 0, random.Next(8, 10), 4906, 3508, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            battledata = new BattleData(data.Teams).setData(7397, 0, 0, random.Next(8, 10), 4906, 3508, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();

            userData.battle.startTurn(data);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7378, 0, 0, random.Next(8, 10), 4395, 13600, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7354, 0, 0, random.Next(8, 10), 3950, 11994, 10028, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);

        }

        public void mapcte1_11(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_11 map = new Map_Controller.mapcte1_11(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            battledata = new BattleData(data.Teams).setData(7403, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);



            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            battledata = new BattleData(data.Teams).setData(7403, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7416, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);


            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            battledata = new BattleData(data.Teams).setData(7403, 0, 0, random.Next(8, 10), 2464, 4164, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);


            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);



        }



        public void mapcte1_11mp7(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_11mp7 map = new Map_Controller.mapcte1_11mp7(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7414, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.reinforceTeam(map.spots2);

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            battledata = new BattleData(data.Teams).setData(7414, 0, 0, random.Next(8, 10), 2464, 4164, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7411, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7412, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7424, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            
            userData.battle.abortMission();
        }


        public void mapcte1_12(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_12 map = new Map_Controller.mapcte1_12(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);


            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            battledata = new BattleData(data.Teams).setData(7436, 0, 0, random.Next(8, 10), 3744, 6248, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7448, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            battledata = new BattleData(data.Teams).setData(7448, 0, 0, random.Next(8, 10), 5066, 15257, 10028, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7444, 0, 0, random.Next(8, 10), 4286, 3346, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);




        }

        public void mapcte1_13(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_13 map = new Map_Controller.mapcte1_13(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);


            battledata = new BattleData(data.Teams).setData(7457, 0, 0, random.Next(8, 10), 2169, 6654, 10029, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            string battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            //7461
            if (Function.Normal_PosCheck_type2(battleResult, 7461) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7461, 0, 0, random.Next(8, 10), 2169, 6654, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }


            battleResult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(battleResult,7461) ==1)
            {
                battledata = new BattleData(data.Teams).setData(7461, 0, 0, random.Next(8, 10), 2169, 6654, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7463) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7463, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7462) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7462, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7439) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7439, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7434) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7434, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            battleResult= userData.battle.endTurn(data);

            if (Function.Normal_PosCheck_type2(battleResult, 7434) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7434, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7439) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7439, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.reinforceTeam(map.spots2);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.withdrawTeam(map.withdrawTeam);
            userData.battle.abortMission();
            




        }

        public void mapcte1_14(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte1_14 map = new Map_Controller.mapcte1_14(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);


            battledata = new BattleData(data.Teams).setData(7477, 0, 0, random.Next(8, 10), 5778, 13546, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7475, 0, 0, random.Next(8, 10), 5778, 18546, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);




            userData.battle.allyMySideMove();
            string battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            battledata = new BattleData(data.Teams).setData(7492, 0, 0, random.Next(8, 10), 6255, 14407, 10033, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7491) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7491, 0, 0, random.Next(8, 10), 6255, 14407, 10033, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7479, 0, 0, random.Next(8, 10), 6255, 14407, 10033, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7494, 0, 0, random.Next(8, 10), 10580, 16560, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.abortMission();
            

        }


        /// <summary>
        /// 物资箱
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="data"></param>
        public void mapcte2_4(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            mapcte2_4 map = new mapcte2_4(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.allyTeamAi(1, 0);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);

            userData.battle.allyMySideMove();
            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            

            battledata = new BattleData(data.Teams).setData(7526, 0, 0, random.Next(8, 10), 19269, 50900, 900122, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.abortMission();
        }



        public void mapcte2_9(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte2_9 map = new Map_Controller.mapcte2_9(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8552, 0, 0, random.Next(8, 10), 12033, 33600, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8554, 0, 0, random.Next(8, 10), 12033, 33600, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);


            battledata = new BattleData(data.Teams).setData(7718, 0, 0, random.Next(8, 10), 11160, 29150, 10036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8531, 0, 0, random.Next(8, 10), 11160, 29150, 10036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8551, 0, 0, random.Next(8, 10), 9390, 26250, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7733, 0, 0, random.Next(8, 10), 67097, 150000, 900127, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }






        }



        public void mapcte3_3(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            mapcte3_3 map = new mapcte3_3(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);

            battledata = new BattleData(data.Teams).setData(7838, 0, 0, random.Next(8, 10), 79920, 285052, 900117, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.abortMission();

        }

        public void mapcte3_14(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            mapcte3_14 map = new mapcte3_14(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8594, 0, 0, random.Next(8, 10), 26284, 62860, 10035, userData.user_Info.experience);
            if(userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8596, 0, 0, random.Next(8, 10), 29979, 92241, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8608, 0, 0, random.Next(8, 10), 29979, 92241, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            string battleResult =  userData.battle.endTurn(data);
            battledata = new BattleData(data.Teams).setData(8603, 0, 0, random.Next(8, 10), 22953, 52611, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);//
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8032, 1, 0, random.Next(8, 10), 26284, 62860, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8035, 1, 0, random.Next(8, 10), 26284, 62860, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }





            battleResult =  userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            if(Function.Normal_PosCheck_type2(battleResult, 8614) == 1)
            {
                battledata = new BattleData(data.Teams).setData(8614, 1, 0, random.Next(8, 10), 29979, 92241, 10034, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 8617) == 1)
            {
                battledata = new BattleData(data.Teams).setData(8617, 1, 0, random.Next(8, 10), 22953, 52611, 10035, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.withdrawTeam(map.withdrawSpot);
            userData.battle.reinforceTeam(map.spots5);


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8637, 0, 0, random.Next(8, 10), 27179, 58956, 10036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8636, 0, 0, random.Next(8, 10), 19804, 51928, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8628, 0, 0, random.Next(8, 10), 67097, 155000, 900127, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            if(Function.Normal_PosCheck_type2(battleResult, 8645) == 1)
            {
                battledata = new BattleData(data.Teams).setData(8645, 0, 0, random.Next(8, 10), 144984, 350000, 900124, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.endTurn(data);













































































































        }


        public void mapcte2_15(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Controller.mapcte2_15 map = new Map_Controller.mapcte2_15(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7698, 0, 0, random.Next(8, 10), 11268, 31500, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7696, 0, 0, random.Next(8, 10), 11268, 31500, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7708, 0, 0, random.Next(8, 10), 12319, 31850, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7688, 0, 0, random.Next(8, 10), 12319, 31850, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.allyMySideMove();
            string battleRessult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(battleRessult, 7688) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7688, 0, 0, random.Next(8, 10), 11268, 31500, 10034, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8519, 0, 0, random.Next(8, 10), 11268, 31500, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7693, 0, 0, random.Next(8, 10), 67097, 150000, 900127, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

        }


        public void mapcte1start(UserData userData, MissionInfo.Data data)
        {

            mapcte1_1(userData,data);
            mapcte1_2(userData, data);
            mapcte1_3(userData, data);
            mapcte1_4type1(userData, data);
        }


        public void mapctbox(UserData userData, MissionInfo.Data data)
        {
            userData.battle.Check_Equip_Gun_FULL();
            mapcte1_5(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            mapcte1_5(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            mapcte1_5(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            mapcte1_5(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            mapcte2_4(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            mapcte2_4(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            mapcte2_4(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            mapcte2_4(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            mapcte3_3(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            mapcte3_3(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            mapcte3_3(userData, data);
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "mapctbox 完成").userInfo();
            data.Loop = false;
        }

        public void mapequip_ump(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            mapequip_ump map = new mapequip_ump(data);
            string battledata;

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);//右移一步
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);//右移一步
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);//右移一步




            
            battledata = new BattleData(data.Teams).setData(4573, 0, 0, random.Next(5, 7), 14993, 21581, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
               userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);//右移一步

            
            battledata = new BattleData(data.Teams).setData(4583, 0, 0, random.Next(5, 7), 14993, 21581, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
               userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);//右移一步
            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);//右移一步
            userData.battle.withdrawTeam(map.withdrawSpot1);//撤离
            string EndTurnresult = userData.battle.endTurn(data);

            userData.battle.endEnemyTurn();

            userData.battle.startTurn(data);

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);//右移一步

            //战斗结算 经验，装备，指挥官经验
            
            battledata = new BattleData(data.Teams).setData(4603, 0, 0, random.Next(5, 7), 14993, 21581, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
               userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.dic_TeamMove[stepNum++]);//右移一步

            userData.battle.withdrawTeam(map.withdrawSpot2);//撤离

            userData.battle.abortMission();//终止作战
        }
















    }
}

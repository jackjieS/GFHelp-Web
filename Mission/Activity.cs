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
            userData.battle.teamMove(mapcubee1_4.teamMove.dic[stepNum++]);
            userData.battle.reinforceTeam(mapcubee1_4.Spots.dic[1],true);
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
            userData.battle.teamMove(mapcubee1_4.teamMove.dic[stepNum++]);
            userData.battle.teamMove(mapcubee1_4.teamMove.dic[stepNum++]);
            
            battledata = new BattleData(data.Teams).setData(3246, 0, 0, random.Next(8, 10), 10380, 24608, 900026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(mapcubee1_4.teamMove.dic[stepNum++]);
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
            userData.battle.teamMove(mapcubee1_4.teamMove.dic[stepNum++]);
            if (Function.Night_PosCheck_type1(Endresult, 3240) == 1)
            {
                
                battledata = new BattleData(data.Teams).setData(3240, 0, 0, random.Next(8, 10), 4136, 7392, 10016, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(mapcubee1_4.teamMove.dic[stepNum++]);
            
            battledata = new BattleData(data.Teams).setData(3233, 0, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(mapcubee1_4.teamMove.dic[stepNum++]);
            
            battledata = new BattleData(data.Teams).setData(3234, 0, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(mapcubee1_4.teamMove.dic[stepNum++]);
            
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
            userData.battle.teamMove(maparctic1_4.teamMove.dic[stepNum++]);
            userData.battle.reinforceTeam(maparctic1_4.Spots.dic[1]);//
            result = userData.battle.endTurn(data);
            //Function.Night_PosCheck_type1(result, 3244) == 1
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            if (userData.battle.teamMove_Random(maparctic1_4.teamMove.dic[stepNum++],data) == 1)
            {
                battledata = new BattleData(data.Teams).setData(2057, 0, 0, random.Next(8, 10), 3344, 5716, 10004, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(maparctic1_4.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(2210, 0, 0, random.Next(8, 10), 3344, 5716, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(maparctic1_4.teamMove.dic[stepNum++]);
            string battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(maparctic1_4.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(2260, 0, 0, random.Next(8, 10), 18513, 16404, 900051, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(maparctic1_4.teamMove.dic[stepNum++]);
            userData.battle.teamMove(maparctic1_4.teamMove.dic[stepNum++]);
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
            userData.battle.teamMove(maparctic1_4.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(2263, 0, 0, random.Next(8, 10), 18513, 16404, 900051, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(maparctic1_4.teamMove.dic[stepNum++]);
            userData.battle.teamMove(maparctic1_4.teamMove.dic[stepNum++]);

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
            userData.battle.teamMove(maparctic1_4.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(2252, 0, 0, random.Next(8, 10), 3534, 9597, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(maparctic1_4.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);

            battledata = new BattleData(data.Teams).setData(7245, 0, 0, random.Next(8, 10), 920, 1128, 10001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);

            battledata = new BattleData(data.Teams).setData(7256, 0, 0, random.Next(8, 10), 1220, 1512, 10001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.Spots.dic[1]);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7257, 0, 0, random.Next(8, 10), 724, 1208, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7262, 0, 0, random.Next(8, 10), 1340, 2420, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7264, 0, 0, random.Next(8, 10), 1220, 1512, 10001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7259, 0, 0, random.Next(8, 10), 724, 1208, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7276, 0, 0, random.Next(8, 10), 1432, 2592, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7274, 0, 0, random.Next(8, 10), 1432, 2592, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7273, 0, 0, random.Next(8, 10), 2108, 4004, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.reinforceTeam(map.Spots.dic[1]);


            userData.battle.endTurn(data);
            battledata = new BattleData(data.Teams).setData(7282, 1, 0, random.Next(8, 10), 2040, 3620, 10002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7287, 0, 0, random.Next(8, 10), 2780, 2776, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);

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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7305, 0, 0, random.Next(8, 10), 2504, 4628, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.Spots.dic[1]);


            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7307, 0, 0, random.Next(8, 10), 3086, 2702, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.reinforceTeam(map.Spots.dic[1]);

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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7287, 0, 0, random.Next(8, 10), 2780, 2776, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);



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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7335, 0, 0, random.Next(8, 10), 2744, 9628, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.Spots.dic[1]);


            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.saveHostage("7328");

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.saveHostage("7328");


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7330, 0, 0, random.Next(8, 10), 3652, 4628, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.saveHostage("7328");

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7338, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);

            userData.battle.endTurn(data);

            battledata = new BattleData(data.Teams).setData(7341, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.endTurn(data);

            battledata = new BattleData(data.Teams).setData(7341, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7338, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);


            userData.battle.reinforceTeam(map.Spots.dic[1]);

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
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7402, 0, 0, random.Next(8, 10), 4906, 3508, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);

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
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7378, 0, 0, random.Next(8, 10), 4395, 13600, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);


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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7414, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.reinforceTeam(map.Spots.dic[1]);

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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7411, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7412, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);


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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);


            battledata = new BattleData(data.Teams).setData(7457, 0, 0, random.Next(8, 10), 2169, 6654, 10029, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            string battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7463) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7463, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7462) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7462, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7439) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7439, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7439) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7439, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.reinforceTeam(map.Spots.dic[1]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);


            battledata = new BattleData(data.Teams).setData(7477, 0, 0, random.Next(8, 10), 5778, 13546, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7475, 0, 0, random.Next(8, 10), 5778, 18546, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);




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
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7491) == 1)
            {
                battledata = new BattleData(data.Teams).setData(7491, 0, 0, random.Next(8, 10), 6255, 14407, 10033, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7479, 0, 0, random.Next(8, 10), 6255, 14407, 10033, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);

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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8552, 0, 0, random.Next(8, 10), 12033, 33600, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8554, 0, 0, random.Next(8, 10), 12033, 33600, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);


            battledata = new BattleData(data.Teams).setData(7718, 0, 0, random.Next(8, 10), 11160, 29150, 10036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8531, 0, 0, random.Next(8, 10), 11160, 29150, 10036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8551, 0, 0, random.Next(8, 10), 9390, 26250, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);

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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8594, 0, 0, random.Next(8, 10), 26284, 62860, 10035, userData.user_Info.experience);
            if(userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8596, 0, 0, random.Next(8, 10), 29979, 92241, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8608, 0, 0, random.Next(8, 10), 29979, 92241, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            string battleResult =  userData.battle.endTurn(data);
            battledata = new BattleData(data.Teams).setData(8603, 0, 0, random.Next(8, 10), 22953, 52611, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8032, 1, 0, random.Next(8, 10), 26284, 62860, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8035, 1, 0, random.Next(8, 10), 26284, 62860, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }





            battleResult =  userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            if(Function.Normal_PosCheck_type2(battleResult, 8614) == 1)
            {
                battledata = new BattleData(data.Teams).setData(8614, 1, 0, random.Next(8, 10), 29979, 92241, 10034, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 8617) == 1)
            {
                battledata = new BattleData(data.Teams).setData(8617, 1, 0, random.Next(8, 10), 22953, 52611, 10035, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.withdrawTeam(map.withdrawSpot);
            userData.battle.reinforceTeam(map.Spots.dic[4]);


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8637, 0, 0, random.Next(8, 10), 27179, 58956, 10036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8636, 0, 0, random.Next(8, 10), 19804, 51928, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8628, 0, 0, random.Next(8, 10), 67097, 155000, 900127, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            if(Function.Normal_PosCheck_type2(battleResult, 8645) == 1)
            {
                battledata = new BattleData(data.Teams).setData(8645, 0, 0, random.Next(8, 10), 144984, 350000, 900124, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7698, 0, 0, random.Next(8, 10), 11268, 31500, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7696, 0, 0, random.Next(8, 10), 11268, 31500, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(7708, 0, 0, random.Next(8, 10), 12319, 31850, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            battledata = new BattleData(data.Teams).setData(8519, 0, 0, random.Next(8, 10), 11268, 31500, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
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
            new Log().userInit(userData.GameAccount.GameAccountID, "mapctbox 完成").userInfo();
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



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步




            
            battledata = new BattleData(data.Teams).setData(4573, 0, 0, random.Next(5, 7), 14993, 21581, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
               userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步

            
            battledata = new BattleData(data.Teams).setData(4583, 0, 0, random.Next(5, 7), 14993, 21581, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
               userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.withdrawTeam(map.withdrawSpot1);//撤离
            string EndTurnresult = userData.battle.endTurn(data);

            userData.battle.endEnemyTurn();

            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步

            //战斗结算 经验，装备，指挥官经验
            
            battledata = new BattleData(data.Teams).setData(4603, 0, 0, random.Next(5, 7), 14993, 21581, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
               userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步

            userData.battle.withdrawTeam(map.withdrawSpot2);//撤离

            userData.battle.abortMission();//终止作战
        }


        public void maprabbit(UserData userData, MissionInfo.Data data)
        {
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite1(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite1(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite1(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite2(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite2(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite2(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite3(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite3(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite4(userData, data);
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite4(userData, data);

            data.Loop = false;

        }

        public void maprabbite1(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            maprabbite1 map = new maprabbite1(data);
            string battledata;

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4142, 0, 0, random.Next(5, 7), 843, 1349, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4139, 0, 0, random.Next(5, 7), 805, 1466, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4139) == 1)
            {
                battledata = new BattleData(data.Teams).setData(4139, 0, 0, random.Next(5, 7), 805, 1466, 10003, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            



            userData.battle.endEnemyTurn();

            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4147, 0, 0, random.Next(5, 7), 805, 1466, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4140, 0, 0, random.Next(5, 7), 100, 1634, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "Rabbit E1 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.maprabbite1(userData, data);
            }

        }

        public void maprabbite2(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            maprabbite2 map = new maprabbite2(data);
            string battledata;

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4121, 0, 0, random.Next(5, 7), 1492, 2948, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.Spots.dic[1]);
            string EndTurnresult = userData.battle.endTurn(data);
            if(Function.Normal_PosCheck_type2(EndTurnresult, 4121)==1)
            {
                battledata = new BattleData(data.Teams).setData(4121, 0, 0, random.Next(5, 7), 1303, 1874, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            if (Function.Normal_PosCheck_type2(EndTurnresult, 4124) == 1)
            {
                battledata = new BattleData(data.Teams).setData(4124, 1, 0, random.Next(5, 7), 1734, 2080, 10003, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();

            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4120, 0, 0, random.Next(5, 7), 1303, 1874, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4119, 0, 0, random.Next(5, 7), 3204, 8000, 900075, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "Rabbit E2 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.maprabbite2(userData, data);
            }

        }

        public void maprabbite3(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            maprabbite3 map = new maprabbite3(data);
            string battledata;

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4155, 0, 0, random.Next(5, 7), 4994, 4129, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.Spots.dic[2]);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4158, 1, 0, random.Next(5, 7), 3510, 3176, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4156) == 1)
            {
                battledata = new BattleData(data.Teams).setData(4156, 2, 0, random.Next(5, 7), 3510, 3176, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4165) == 1)
            {
                battledata = new BattleData(data.Teams).setData(4165, 0, 0, random.Next(5, 7), 3317, 2896, 10003, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4164, 0, 0, random.Next(5, 7), 4994, 4129, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4172, 0, 0, random.Next(5, 7), 3317, 2896, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4167, 0, 0, random.Next(5, 7), 3312, 6039, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4158) == 1)
            {
                battledata = new BattleData(data.Teams).setData(4158, 1, 0, random.Next(5, 7), 3510, 3176, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4167) == 1)
            {
                battledata = new BattleData(data.Teams).setData(4167, 0, 0, random.Next(5, 7), 3312, 6039, 10004, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4169) == 1)
            {
                battledata = new BattleData(data.Teams).setData(4169, 0, 0, random.Next(5, 7), 3510, 3176, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4159, 0, 0, random.Next(5, 7), 3195, 8467, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4160, 0, 0, random.Next(5, 7), 3195, 8467, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4170, 0, 0, random.Next(5, 7), 4587, 5362, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "Rabbit E3 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.maprabbite3(userData, data);
            }

        }

        public void maprabbite4(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            maprabbite4 map = new maprabbite4(data);
            string battledata;

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4188, 0, 0, random.Next(5, 7), 4572, 6351, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.Spots.dic[2]);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4187, 1, 0, random.Next(5, 7), 4485, 15291, 10012, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.Spots.dic[3]);

            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4187) == 1)
            {
                battledata = new BattleData(data.Teams).setData(4187, 1, 0, random.Next(5, 7), 4511, 8755, 10006, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4190, 0, 0, random.Next(5, 7), 6740, 3812, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4196, 0, 0, random.Next(5, 7), 6740, 3812, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4179, 0, 0, random.Next(5, 7), 4572, 6351, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4189, 3, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }




            EndTurnresult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4179, 0, 0, random.Next(5, 7), 6740, 3812, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4183, 0, 0, random.Next(5, 7), 6740, 3812, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4185, 0, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4186, 1, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4185) == 1)
            {
                battledata = new BattleData(data.Teams).setData(4185, 0, 0, random.Next(5, 7), 4485, 15291, 10012, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4186) == 1)
            {
                battledata = new BattleData(data.Teams).setData(4186, 1, 0, random.Next(5, 7), 4485, 15291, 10012, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4174, 0, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4195, 0, 0, random.Next(5, 7), 4572, 6351, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4181, 0, 0, random.Next(5, 7), 4572, 6351, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(4194, 0, 0, random.Next(5, 7), 8358, 16408, 900076, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            if (result.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "Rabbit E4 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.maprabbite4(userData, data);
            }

        }

        public void maprabbite5(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            maprabbite5 map = new maprabbite5(data);
            string battledata;

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9481, 0, 0, random.Next(5, 7), 6118, 11936, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.Spots.dic[1]);


            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9482) == 1)
            {
                battledata = new BattleData(data.Teams).setData(9482, 1, 0, random.Next(5, 7), 805, 1466, 10003, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9472, 0, 0, random.Next(5, 7), 174966, 406356, 900032, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9478, 0, 0, random.Next(5, 7), 24152, 34603, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            EndTurnresult = userData.battle.endTurn(data);
            if (EndTurnresult.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "Rabbit E5 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.maprabbite5(userData, data);
            }

        }

        public void maprabbite6(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            maprabbite6 map = new maprabbite6(data);
            string battledata;

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9460, 0, 0, random.Next(5, 7), 16544, 16119, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.Spots.dic[1]);


            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9460) == 1)
            {
                battledata = new BattleData(data.Teams).setData(9460, 0, 0, random.Next(5, 7), 805, 1466, 10003, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9469, 0, 0, random.Next(5, 7), 45354, 94070, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9459, 0, 0, random.Next(5, 7), 17814, 21647, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9458, 0, 0, random.Next(19, 40), 89200, 185155, 900138, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            EndTurnresult = userData.battle.endTurn(data);
            if (EndTurnresult.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "Rabbit E6 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.maprabbite6(userData, data);
            }

        }


        public void maprabbite7(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            maprabbite7 map = new maprabbite7(data);
            string battledata;

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9491, 0, 0, random.Next(5, 7), 27741, 113442, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.Spots.dic[2]);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9494, 1, 0, random.Next(5, 7), 28875, 77553, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.Spots.dic[3]);


            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9491) == 1)
            {
                battledata = new BattleData(data.Teams).setData(9491, 0, 0, random.Next(5, 7), 58682, 139416, 900032, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9493) == 1)
            {
                battledata = new BattleData(data.Teams).setData(9493, 2, 0, random.Next(5, 7), 24582, 38094, 10008, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9507, 0, 0, random.Next(5, 7), 40066, 62978, 10021, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9498, 0, 0, random.Next(5, 7), 33837, 69872, 10014, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9508, 0, 0, random.Next(5, 7), 20796, 42947, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9503, 0, 0, random.Next(5, 7), 34911, 94652, 900025, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9503) == 1)
            {
                battledata = new BattleData(data.Teams).setData(9503, 0, 0, random.Next(5, 7), 97064, 554548, 10022, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9495, 0, 0, random.Next(5, 7), 24582, 58094, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9496, 0, 0, random.Next(5, 7), 25277, 46418, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }




            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9506, 0, 0, random.Next(5, 7), 58682, 139416, 900032, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            EndTurnresult = userData.battle.endTurn(data);
            if (EndTurnresult.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "Rabbit E7 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.maprabbite7(userData, data);
            }

        }

        public void maprabbite8(UserData userData, MissionInfo.Data data)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            maprabbite8 map = new maprabbite8(data);
            string battledata;

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9524, 0, 0, random.Next(5, 7), 28577, 85839, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.Spots.dic[2]);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9523, 1, 0, random.Next(5, 7), 51750, 67776, 10014, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.Spots.dic[3]);


            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9523) == 1)
            {
                battledata = new BattleData(data.Teams).setData(9523, 1, 0, random.Next(5, 7), 46040, 104528, 10018, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9527, 0, 0, random.Next(5, 7), 25740, 42522, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9526, 0, 0, random.Next(5, 7), 25740, 42522, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9515, 0, 0, random.Next(5, 7), 25740, 65533, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9520, 0, 0, random.Next(5, 7), 28577, 100839, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9519, 0, 0, random.Next(5, 7), 28577, 100839, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9512) == 1)
            {
                battledata = new BattleData(data.Teams).setData(9512, 3, 0, random.Next(5, 7), 9000, 12492, 10003, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9519) == 1)
            {
                battledata = new BattleData(data.Teams).setData(9519, 0, 0, random.Next(5, 7), 28577, 100839, 10008, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9533, 0, 0, random.Next(5, 7), 41068, 79028, 10021, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9510, 0, 0, random.Next(5, 7), 9000, 12492, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9531, 0, 0, random.Next(5, 7), 55964, 361584, 10022, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            EndTurnresult = userData.battle.endTurn(data);
            battledata = new BattleData(data.Teams).setData(9523, 1, 0, random.Next(5, 7), 41068, 64028, 10021, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            battledata = new BattleData(data.Teams).setData(9511, 2, 0, random.Next(5, 7), 46040, 104528, 10018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[stepNum++]);//右移一步
            battledata = new BattleData(data.Teams).setData(9530, 0, 0, random.Next(5, 7), 167775, 171300, 900139, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }








            if (result.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "Rabbit E8 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.maprabbite8(userData, data);
            }

        }
    }
}

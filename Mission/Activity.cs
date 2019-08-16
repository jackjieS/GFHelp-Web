using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Text.RegularExpressions;
using static GFHelp.Mission.Map_Controller;

namespace GFHelp.Mission
{
    class Activity : MapManager
    {
        public Activity(UserData userData) : base(userData)
        {

        }

        public void mapcubee1_4()
        {



            Map_Controller.mapcubee1_4 map = new Map_Controller.mapcubee1_4(data);
            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.reinforceTeam(map,map.Spots.dic[1], true);
            result = userData.battle.endTurn(data);
            //Check point 3244
            if (Function.Night_PosCheck_type1(result, 3244) == 1)
            {

                strbattledata = battleData.setData(3244, 0, 0, random.Next(8, 10), 10380, 24608, 900026, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(3246, 0, 0, random.Next(8, 10), 10380, 24608, 900026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            string Endresult = userData.battle.endTurn(data);
            //Check point 3244
            if (Function.Night_PosCheck_type1(Endresult, 3243) == 1)
            {

                strbattledata = battleData.setData(3243, 1, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Night_PosCheck_type1(Endresult, 3247) == 1)
            {

                strbattledata = battleData.setData(3247, 0, 0, random.Next(8, 10), 4136, 7392, 10016, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Night_PosCheck_type1(Endresult, 3240) == 1)
            {

                strbattledata = battleData.setData(3240, 0, 0, random.Next(8, 10), 4136, 7392, 10016, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(3233, 0, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(3234, 0, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(3235, 0, 0, random.Next(8, 10), 5448, 13524, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.abortMission();












        }

        public void maparctic1_4()
        {



            maparctic1_4 map = new maparctic1_4(data);
            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.reinforceTeam(map,map.Spots.dic[1]);//
            result = userData.battle.endTurn(data);
            //Function.Night_PosCheck_type1(result, 3244) == 1
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            if (userData.battle.teamMove_Random(map.teamMove.dic[map.stepNum++], data) == 1)
            {
                strbattledata = battleData.setData(2057, 0, 0, random.Next(8, 10), 3344, 5716, 10004, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(2210, 0, 0, random.Next(8, 10), 3344, 5716, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            string battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(2260, 0, 0, random.Next(8, 10), 18513, 16404, 900051, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 2262) == 1)
            {
                strbattledata = battleData.setData(2262, 0, 0, random.Next(8, 10), 3744, 5720, 10001, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }

            }
            battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(2263, 0, 0, random.Next(8, 10), 18513, 16404, 900051, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            // 
            if (Function.Normal_PosCheck_type2(battleResult, 2253) == 1)
            {
                strbattledata = battleData.setData(2253, 0, 0, random.Next(8, 10), 3044, 3812, 10008, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            result = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(2252, 0, 0, random.Next(8, 10), 3534, 9597, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(2060, 0, 0, random.Next(8, 10), 10641, 18808, 900052, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
        }


        public void mapcte1_1()
        {



            Map_Controller.mapcte1_1 map = new Map_Controller.mapcte1_1(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(7245, 0, 0, random.Next(8, 10), 920, 1128, 10001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.endTurn(data);
        }

        public void mapcte1_2()
        {



            Map_Controller.mapcte1_2 map = new Map_Controller.mapcte1_2(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(7256, 0, 0, random.Next(8, 10), 1220, 1512, 10001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map,map.Spots.dic[1]);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7257, 0, 0, random.Next(8, 10), 724, 1208, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7262, 0, 0, random.Next(8, 10), 1340, 2420, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7264, 0, 0, random.Next(8, 10), 1220, 1512, 10001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7259, 0, 0, random.Next(8, 10), 724, 1208, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7258, 0, 0, random.Next(8, 10), 1220, 1512, 10001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



        }

        public void mapcte1_3()
        {



            Map_Controller.mapcte1_3 map = new Map_Controller.mapcte1_3(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7276, 0, 0, random.Next(8, 10), 1432, 2592, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7274, 0, 0, random.Next(8, 10), 1432, 2592, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7273, 0, 0, random.Next(8, 10), 2108, 4004, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7281, 0, 0, random.Next(8, 10), 2208, 2592, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
        }

        public void mapcte1_4type1()
        {



            Map_Controller.mapcte1_4type1 map = new Map_Controller.mapcte1_4type1(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.reinforceTeam(map,map.Spots.dic[1]);


            userData.battle.endTurn(data);
            strbattledata = battleData.setData(7282, 1, 0, random.Next(8, 10), 2040, 3620, 10002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7287, 0, 0, random.Next(8, 10), 2780, 2776, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.endTurn(data);
        }

        public void mapcte1_5()
        {



            Map_Controller.mapcte1_5 map = new Map_Controller.mapcte1_5(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7305, 0, 0, random.Next(8, 10), 2504, 4628, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map,map.Spots.dic[1]);


            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7307, 0, 0, random.Next(8, 10), 3086, 2702, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7312, 0, 0, random.Next(8, 10), 9872, 17200, 900118, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

        }

        public void mapcte1_6()
        {



            Map_Controller.mapcte1_6 map = new Map_Controller.mapcte1_6(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.reinforceTeam(map,map.Spots.dic[1]);

            string battleResult = userData.battle.endTurn(data);

            if (Function.Normal_PosCheck_type2(battleResult, 7282) == 1)
            {
                strbattledata = battleData.setData(7282, 1, 0, random.Next(8, 10), 2040, 3620, 10002, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }



            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7287, 0, 0, random.Next(8, 10), 2780, 2776, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);



            userData.battle.endTurn(data);


        }



        public void mapcte1_7()
        {



            Map_Controller.mapcte1_7 map = new Map_Controller.mapcte1_7(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7335, 0, 0, random.Next(8, 10), 2744, 9628, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map,map.Spots.dic[1]);


            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7333, 0, 0, random.Next(8, 10), 3444, 6304, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            string endturnResult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(endturnResult, 7326) == 1)
            {
                strbattledata = battleData.setData(7326, 1, 0, random.Next(8, 10), 2744, 4628, 10004, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.saveHostage("7328");

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.saveHostage("7328");


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7330, 0, 0, random.Next(8, 10), 3652, 4628, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.saveHostage("7328");

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7338, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.endTurn(data);

            strbattledata = battleData.setData(7341, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(7341, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7338, 0, 0, random.Next(8, 10), 3738, 5988, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.saveHostage("7328");


        }


        public void mapcte1_8()
        {



            Map_Controller.mapcte1_8 map = new Map_Controller.mapcte1_8(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            userData.battle.reinforceTeam(map,map.Spots.dic[1]);

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            strbattledata = battleData.setData(7351, 0, 0, random.Next(8, 10), 4906, 3508, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            strbattledata = battleData.setData(7377, 1, 0, random.Next(8, 10), 3950, 11994, 10028, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }







            userData.battle.endOtherSideTurn();

            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7402, 0, 0, random.Next(8, 10), 4906, 3508, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            strbattledata = battleData.setData(7397, 0, 0, random.Next(8, 10), 4906, 3508, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();

            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7378, 0, 0, random.Next(8, 10), 4395, 13600, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7354, 0, 0, random.Next(8, 10), 3950, 11994, 10028, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);

        }

        public void mapcte1_11()
        {



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
            strbattledata = battleData.setData(7403, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);



            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            strbattledata = battleData.setData(7403, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7416, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            strbattledata = battleData.setData(7403, 0, 0, random.Next(8, 10), 2464, 4164, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);


            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);



        }



        public void mapcte1_11mp7()
        {



            Map_Controller.mapcte1_11mp7 map = new Map_Controller.mapcte1_11mp7(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7414, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.reinforceTeam(map,map.Spots.dic[1]);

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            strbattledata = battleData.setData(7414, 0, 0, random.Next(8, 10), 2464, 4164, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7411, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7412, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7424, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.abortMission();
        }


        public void mapcte1_12()
        {



            Map_Controller.mapcte1_12 map = new Map_Controller.mapcte1_12(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            strbattledata = battleData.setData(7436, 0, 0, random.Next(8, 10), 3744, 6248, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7448, 0, 0, random.Next(8, 10), 4340, 2976, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            strbattledata = battleData.setData(7448, 0, 0, random.Next(8, 10), 5066, 15257, 10028, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7444, 0, 0, random.Next(8, 10), 4286, 3346, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
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

        public void mapcte1_13()
        {



            Map_Controller.mapcte1_13 map = new Map_Controller.mapcte1_13(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(7457, 0, 0, random.Next(8, 10), 2169, 6654, 10029, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            string battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            //7461
            if (Function.Normal_PosCheck_type2(battleResult, 7461) == 1)
            {
                strbattledata = battleData.setData(7461, 0, 0, random.Next(8, 10), 2169, 6654, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }


            battleResult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(battleResult, 7461) == 1)
            {
                strbattledata = battleData.setData(7461, 0, 0, random.Next(8, 10), 2169, 6654, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7463) == 1)
            {
                strbattledata = battleData.setData(7463, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7462) == 1)
            {
                strbattledata = battleData.setData(7462, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7439) == 1)
            {
                strbattledata = battleData.setData(7439, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7434) == 1)
            {
                strbattledata = battleData.setData(7434, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            battleResult = userData.battle.endTurn(data);

            if (Function.Normal_PosCheck_type2(battleResult, 7434) == 1)
            {
                strbattledata = battleData.setData(7434, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7439) == 1)
            {
                strbattledata = battleData.setData(7439, 0, 0, random.Next(8, 10), 4368, 13304, 10029, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.reinforceTeam(map,map.Spots.dic[1]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.withdrawTeam(map.withdrawTeam);
            userData.battle.abortMission();





        }

        public void mapcte1_14()
        {



            Map_Controller.mapcte1_14 map = new Map_Controller.mapcte1_14(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(7477, 0, 0, random.Next(8, 10), 5778, 13546, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7475, 0, 0, random.Next(8, 10), 5778, 18546, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);




            userData.battle.allyMySideMove();
            string battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            strbattledata = battleData.setData(7492, 0, 0, random.Next(8, 10), 6255, 14407, 10033, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 7491) == 1)
            {
                strbattledata = battleData.setData(7491, 0, 0, random.Next(8, 10), 6255, 14407, 10033, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7479, 0, 0, random.Next(8, 10), 6255, 14407, 10033, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7494, 0, 0, random.Next(8, 10), 10580, 16560, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
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
        public void mapcte2_4()
        {



            mapcte2_4 map = new mapcte2_4(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.allyTeamAi(1, 0);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.allyMySideMove();
            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);


            strbattledata = battleData.setData(7526, 0, 0, random.Next(8, 10), 19269, 50900, 900122, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.abortMission();
        }



        public void mapcte2_9()
        {



            Map_Controller.mapcte2_9 map = new Map_Controller.mapcte2_9(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8552, 0, 0, random.Next(8, 10), 12033, 33600, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8554, 0, 0, random.Next(8, 10), 12033, 33600, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(7718, 0, 0, random.Next(8, 10), 11160, 29150, 10036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8531, 0, 0, random.Next(8, 10), 11160, 29150, 10036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8551, 0, 0, random.Next(8, 10), 9390, 26250, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7733, 0, 0, random.Next(8, 10), 67097, 150000, 900127, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }






        }



        public void mapcte3_3()
        {



            mapcte3_3 map = new mapcte3_3(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(7838, 0, 0, random.Next(8, 10), 79920, 285052, 900117, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.abortMission();

        }

        public void mapcte3_14()
        {



            mapcte3_14 map = new mapcte3_14(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8594, 0, 0, random.Next(8, 10), 26284, 62860, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8596, 0, 0, random.Next(8, 10), 29979, 92241, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8608, 0, 0, random.Next(8, 10), 29979, 92241, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            string battleResult = userData.battle.endTurn(data);
            strbattledata = battleData.setData(8603, 0, 0, random.Next(8, 10), 22953, 52611, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8032, 1, 0, random.Next(8, 10), 26284, 62860, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8035, 1, 0, random.Next(8, 10), 26284, 62860, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }





            battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 8614) == 1)
            {
                strbattledata = battleData.setData(8614, 1, 0, random.Next(8, 10), 29979, 92241, 10034, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 8617) == 1)
            {
                strbattledata = battleData.setData(8617, 1, 0, random.Next(8, 10), 22953, 52611, 10035, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.withdrawTeam(map.withdrawSpot);
            userData.battle.reinforceTeam(map,map.Spots.dic[4]);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8637, 0, 0, random.Next(8, 10), 27179, 58956, 10036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8636, 0, 0, random.Next(8, 10), 19804, 51928, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8628, 0, 0, random.Next(8, 10), 67097, 155000, 900127, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            battleResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(battleResult, 8645) == 1)
            {
                strbattledata = battleData.setData(8645, 0, 0, random.Next(8, 10), 144984, 350000, 900124, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.endTurn(data);













































































































        }


        public void mapcte2_15()
        {



            Map_Controller.mapcte2_15 map = new Map_Controller.mapcte2_15(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7698, 0, 0, random.Next(8, 10), 11268, 31500, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7696, 0, 0, random.Next(8, 10), 11268, 31500, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7708, 0, 0, random.Next(8, 10), 12319, 31850, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7688, 0, 0, random.Next(8, 10), 12319, 31850, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.allyMySideMove();
            string battleRessult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(battleRessult, 7688) == 1)
            {
                strbattledata = battleData.setData(7688, 0, 0, random.Next(8, 10), 11268, 31500, 10034, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(8519, 0, 0, random.Next(8, 10), 11268, 31500, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7693, 0, 0, random.Next(8, 10), 67097, 150000, 900127, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

        }


        public void mapcte1start()
        {

            mapcte1_1();
            mapcte1_2();
            mapcte1_3();
            mapcte1_4type1();
        }


        public void mapctbox()
        {
            userData.battle.Check_Equip_Gun_FULL();
            mapcte1_5();
            userData.battle.Check_Equip_Gun_FULL();
            mapcte1_5();
            userData.battle.Check_Equip_Gun_FULL();
            mapcte1_5();
            userData.battle.Check_Equip_Gun_FULL();
            mapcte1_5();
            userData.battle.Check_Equip_Gun_FULL();
            mapcte2_4();
            userData.battle.Check_Equip_Gun_FULL();
            mapcte2_4();
            userData.battle.Check_Equip_Gun_FULL();
            mapcte2_4();
            userData.battle.Check_Equip_Gun_FULL();
            mapcte2_4();
            userData.battle.Check_Equip_Gun_FULL();
            mapcte3_3();
            userData.battle.Check_Equip_Gun_FULL();
            mapcte3_3();
            userData.battle.Check_Equip_Gun_FULL();
            mapcte3_3();
            new Log().userInit(userData.GameAccount.GameAccountID, "mapctbox 完成").userInfo();
            data.Loop = false;
        }

        public void mapequip_ump()
        {


            mapequip_ump map = new mapequip_ump(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步





            strbattledata = battleData.setData(4573, 0, 0, random.Next(5, 7), 14993, 21581, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步


            strbattledata = battleData.setData(4583, 0, 0, random.Next(5, 7), 14993, 21581, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.withdrawTeam(map.withdrawSpot1);//撤离
            string EndTurnresult = userData.battle.endTurn(data);

            userData.battle.endEnemyTurn();

            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            //战斗结算 经验，装备，指挥官经验

            strbattledata = battleData.setData(4603, 0, 0, random.Next(5, 7), 14993, 21581, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            userData.battle.withdrawTeam(map.withdrawSpot2);//撤离

            userData.battle.abortMission();//终止作战
        }

        /// <summary>
        /// 地线升变4
        /// </summary>
        public void mapequip_hk416()
        {


            mapequip_hk416 map = new mapequip_hk416(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            strbattledata = battleData.setData(6042, 0, 0, random.Next(5, 7), 12190, 37920, 10012, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.allyMySideMove();
            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            strbattledata = battleData.setData(6045, 0, 0, random.Next(5, 7), 11223, 12249, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(6055, 0, 0, random.Next(5, 7), 11223, 12249, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(6033, 0, 0, random.Next(5, 7), 12190, 37920, 10012, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.abortMission();//终止作战
        }


        public void maprabbit()
        {
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite1();
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite1();
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite1();
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite2();
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite2();
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite2();
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite3();
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite3();
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite4();
            userData.battle.Check_Equip_Gun_FULL();
            maprabbite4();

            data.Loop = false;

        }

        public void maprabbite1()
        {


            maprabbite1 map = new maprabbite1(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4142, 0, 0, random.Next(5, 7), 843, 1349, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4139, 0, 0, random.Next(5, 7), 805, 1466, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4139) == 1)
            {
                strbattledata = battleData.setData(4139, 0, 0, random.Next(5, 7), 805, 1466, 10003, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }




            userData.battle.endEnemyTurn();

            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4147, 0, 0, random.Next(5, 7), 805, 1466, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4140, 0, 0, random.Next(5, 7), 100, 1634, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
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
                this.maprabbite1();
            }

        }

        public void maprabbite2()
        {


            maprabbite2 map = new maprabbite2(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4121, 0, 0, random.Next(5, 7), 1492, 2948, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map,map.Spots.dic[1]);
            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4121) == 1)
            {
                strbattledata = battleData.setData(4121, 0, 0, random.Next(5, 7), 1303, 1874, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            if (Function.Normal_PosCheck_type2(EndTurnresult, 4124) == 1)
            {
                strbattledata = battleData.setData(4124, 1, 0, random.Next(5, 7), 1734, 2080, 10003, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();

            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4120, 0, 0, random.Next(5, 7), 1303, 1874, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4119, 0, 0, random.Next(5, 7), 3204, 8000, 900075, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
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
                this.maprabbite2();
            }

        }

        public void maprabbite3()
        {


            int count = 0;
            maprabbite3 map = new maprabbite3(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4155, 0, 0, random.Next(5, 7), 4994, 14129, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map,map.Spots.dic[2]);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4158, 1, 0, random.Next(5, 7), 3510, 3176, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map,map.Spots.dic[3]);

            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4155) == 1)
            {

                strbattledata = battleData.setData(4155, 0, 0, random.Next(5, 7), 4511, 8755, 10006, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    count++;
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4156) == 1)
            {
                strbattledata = battleData.setData(4156, 2, 0, random.Next(5, 7), 4511, 8755, 10006, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    count++;
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4158) == 1)
            {

                strbattledata = battleData.setData(4158, 1, 0, random.Next(5, 7), 4511, 8755, 10006, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    count++;
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4155, 0, 0, random.Next(5, 7), 4994, 14129, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4165, 0, 0, random.Next(5, 7), 4994, 14129, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4164, 0, 0, random.Next(5, 7), 4994, 14129, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4166, 0, 0, random.Next(5, 7), 4994, 14129, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4169, 0, 0, random.Next(5, 7), 4994, 14129, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4169) == 1)
            {
                strbattledata = battleData.setData(4169, 0, 0, random.Next(5, 7), 3510, 18176, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    count++;
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4156) == 1)
            {
                strbattledata = battleData.setData(4156, 3, 0, random.Next(5, 7), 4511, 8755, 10006, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    count++;
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4158) == 1)
            {
                strbattledata = battleData.setData(4158, 1, 0, random.Next(5, 7), 4511, 8755, 10006, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    count++;
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4154) == 1)
            {
                strbattledata = battleData.setData(4154, 2, 0, random.Next(5, 7), 4511, 8755, 10006, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    count++;
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4159, 0, 0, random.Next(5, 7), 3195, 14520, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4160, 0, 0, random.Next(5, 7), 3195, 14520, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4170, 0, 0, random.Next(5, 7), 3195, 14520, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4171, 2, 0, random.Next(5, 7), 3510, 3176, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4162, 2, 0, random.Next(5, 7), 3510, 3176, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4163, 2, 0, random.Next(5, 7), 3317, 2896, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                count++;
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


































            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, string.Format("Rabbit E3 成功 击杀 {0} 次", count)).userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.maprabbite3();
            }

        }

        public void maprabbite4()
        {


            maprabbite4 map = new maprabbite4(data);



            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4188, 0, 0, random.Next(5, 7), 4572, 6351, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map,map.Spots.dic[2]);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4187, 1, 0, random.Next(5, 7), 4485, 15291, 10012, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map,map.Spots.dic[3]);

            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4187) == 1)
            {
                strbattledata = battleData.setData(4187, 1, 0, random.Next(5, 7), 4511, 8755, 10006, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4191, 0, 0, random.Next(5, 7), 6740, 13812, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4190, 0, 0, random.Next(5, 7), 6740, 13812, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4196, 0, 0, random.Next(5, 7), 4483, 16724, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4179, 0, 0, random.Next(5, 7), 4572, 21351, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4184, 0, 0, random.Next(5, 7), 6740, 13812, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4183, 0, 0, random.Next(5, 7), 6740, 13812, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }





            EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4183) == 1)
            {
                strbattledata = battleData.setData(4183, 0, 0, random.Next(5, 7), 6740, 13812, 10009, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4187) == 1)
            {
                strbattledata = battleData.setData(4187, 1, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4176) == 1)
            {
                strbattledata = battleData.setData(4176, 3, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4185, 0, 0, random.Next(5, 7), 4483, 16724, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4197, 0, 0, random.Next(5, 7), 6740, 13812, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4174, 0, 0, random.Next(5, 7), 4485, 30291, 10012, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4178, 0, 0, random.Next(5, 7), 4483, 21724, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4198, 0, 0, random.Next(5, 7), 4572, 21351, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4195, 0, 0, random.Next(5, 7), 4572, 21351, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4195) == 1)
            {
                strbattledata = battleData.setData(4195, 0, 0, random.Next(5, 7), 6740, 13812, 10009, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4187) == 1)
            {
                strbattledata = battleData.setData(4187, 1, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4176) == 1)
            {
                strbattledata = battleData.setData(4176, 3, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 4175) == 1)
            {
                strbattledata = battleData.setData(4175, 2, 0, random.Next(5, 7), 4511, 8755, 10006, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(4194, 0, 0, random.Next(5, 7), 8358, 26408, 900076, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }










            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4190, 0, 0, random.Next(5, 7), 6740, 3812, 10009, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}

            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4196, 0, 0, random.Next(5, 7), 6740, 3812, 10009, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}

            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4179, 0, 0, random.Next(5, 7), 4572, 6351, 10005, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}
            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4189, 3, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}




            //EndTurnresult = userData.battle.endTurn(data);
            //userData.battle.endEnemyTurn();
            //userData.battle.startTurn(data);

            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4179, 0, 0, random.Next(5, 7), 6740, 3812, 10009, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}

            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4183, 0, 0, random.Next(5, 7), 6740, 3812, 10009, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}
            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4185, 0, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}

            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4186, 1, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}

            //EndTurnresult = userData.battle.endTurn(data);
            //if (Function.Normal_PosCheck_type2(EndTurnresult, 4185) == 1)
            //{
            //    strbattledata = battleData.setData(4185, 0, 0, random.Next(5, 7), 4485, 15291, 10012, userData.user_Info.experience);
            //    if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //    {
            //        userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //    }
            //}
            //if (Function.Normal_PosCheck_type2(EndTurnresult, 4186) == 1)
            //{
            //    strbattledata = battleData.setData(4186, 1, 0, random.Next(5, 7), 4485, 15291, 10012, userData.user_Info.experience);
            //    if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //    {
            //        userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //    }
            //}
            //userData.battle.endEnemyTurn();
            //userData.battle.startTurn(data);

            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4174, 0, 0, random.Next(5, 7), 4483, 6724, 10008, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}

            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4195, 0, 0, random.Next(5, 7), 4572, 6351, 10005, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}
            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4181, 0, 0, random.Next(5, 7), 4572, 6351, 10005, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}
            //userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            //strbattledata = battleData.setData(4194, 0, 0, random.Next(5, 7), 8358, 16408, 900076, userData.user_Info.experience);
            //if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            //{
            //    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            //}

            if (result.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "Rabbit E4 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.maprabbite4();
            }

        }

        public void maprabbite5()
        {


            maprabbite5 map = new maprabbite5(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9481, 0, 0, random.Next(5, 7), 6118, 11936, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map,map.Spots.dic[1]);


            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9482) == 1)
            {
                strbattledata = battleData.setData(9482, 1, 0, random.Next(5, 7), 805, 1466, 10003, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9472, 0, 0, random.Next(5, 7), 174966, 406356, 900032, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9478, 0, 0, random.Next(5, 7), 24152, 34603, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
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
                this.maprabbite5();
            }

        }

        public void maprabbite6()
        {


            maprabbite6 map = new maprabbite6(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9460, 0, 0, random.Next(5, 7), 16544, 16119, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map,map.Spots.dic[1]);


            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9460) == 1)
            {
                strbattledata = battleData.setData(9460, 0, 0, random.Next(5, 7), 805, 1466, 10003, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9469, 0, 0, random.Next(5, 7), 45354, 94070, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9459, 0, 0, random.Next(5, 7), 17814, 21647, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9458, 0, 0, random.Next(19, 40), 89200, 185155, 900138, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
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
                this.maprabbite6();
            }

        }


        public void maprabbite7()
        {


            maprabbite7 map = new maprabbite7(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9491, 0, 0, random.Next(5, 7), 27741, 113442, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map,map.Spots.dic[2]);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9494, 1, 0, random.Next(5, 7), 28875, 77553, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map,map.Spots.dic[3]);


            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9491) == 1)
            {
                strbattledata = battleData.setData(9491, 0, 0, random.Next(5, 7), 58682, 139416, 900032, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9493) == 1)
            {
                strbattledata = battleData.setData(9493, 2, 0, random.Next(5, 7), 24582, 38094, 10008, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9507, 0, 0, random.Next(5, 7), 40066, 62978, 10021, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9498, 0, 0, random.Next(5, 7), 33837, 69872, 10014, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9508, 0, 0, random.Next(5, 7), 20796, 42947, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9503, 0, 0, random.Next(5, 7), 34911, 94652, 900025, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9503) == 1)
            {
                strbattledata = battleData.setData(9503, 0, 0, random.Next(5, 7), 97064, 554548, 10022, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9495, 0, 0, random.Next(5, 7), 24582, 58094, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9496, 0, 0, random.Next(5, 7), 25277, 46418, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }




            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9506, 0, 0, random.Next(5, 7), 58682, 139416, 900032, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
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
                this.maprabbite7();
            }

        }

        public void maprabbite8()
        {


            maprabbite8 map = new maprabbite8(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9524, 0, 0, random.Next(5, 7), 28577, 85839, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map,map.Spots.dic[2]);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9523, 1, 0, random.Next(5, 7), 51750, 67776, 10014, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map,map.Spots.dic[3]);


            string EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9523) == 1)
            {
                strbattledata = battleData.setData(9523, 1, 0, random.Next(5, 7), 46040, 104528, 10018, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9527, 0, 0, random.Next(5, 7), 25740, 42522, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9526, 0, 0, random.Next(5, 7), 25740, 42522, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9515, 0, 0, random.Next(5, 7), 25740, 65533, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9520, 0, 0, random.Next(5, 7), 28577, 100839, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9519, 0, 0, random.Next(5, 7), 28577, 100839, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            EndTurnresult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9512) == 1)
            {
                strbattledata = battleData.setData(9512, 3, 0, random.Next(5, 7), 9000, 12492, 10003, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(EndTurnresult, 9519) == 1)
            {
                strbattledata = battleData.setData(9519, 0, 0, random.Next(5, 7), 28577, 100839, 10008, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9533, 0, 0, random.Next(5, 7), 41068, 79028, 10021, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9510, 0, 0, random.Next(5, 7), 9000, 12492, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9531, 0, 0, random.Next(5, 7), 55964, 361584, 10022, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            EndTurnresult = userData.battle.endTurn(data);
            strbattledata = battleData.setData(9523, 1, 0, random.Next(5, 7), 41068, 64028, 10021, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            strbattledata = battleData.setData(9511, 2, 0, random.Next(5, 7), 46040, 104528, 10018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(9530, 0, 0, random.Next(5, 7), 167775, 171300, 900139, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
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
                this.maprabbite8();
            }

        }

        public void mapisomer()
        {
            mapisomer01();
            userData.battle.intelligencePoint(10195);
            mapisomer02();




        }

        public void mapsc2_1()
        {


            mapsc2_1 map = new mapsc2_1(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.reinforceTeam(map,map.Spots.dic[1]);

            userData.battle.allyMySideMove();
            string endturnResult =  userData.battle.endTurn(data);

            strbattledata = battleData.setData(80046, 0, 0, random.Next(5, 7), 3510, 2970, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            if(Function.Normal_PosCheck_type2(endturnResult,80045)==1)
            {
                strbattledata = battleData.setData(80045, 1, 0, random.Next(5, 7), 2140, 454, 10018, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            if (Function.Normal_PosCheck_type2(endturnResult, 80048) == 1)
            {
                strbattledata = battleData.setData(80048, 1, 0, random.Next(5, 7), 3510, 2970, 10016, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
                userData.battle.withdrawTeam(80045);
                userData.battle.abortMission();
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            strbattledata = battleData.setData(80049, 0, 0, random.Next(5, 7), 3510, 2970, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.withdrawTeam(80045);
            userData.battle.abortMission();

        }

        public void mapsc2_2()
        {


            mapsc2_2 map = new mapsc2_2(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步


            strbattledata = battleData.setData(80074, 0, 0, random.Next(5, 7), 4729, 13948, 900166, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步


            userData.battle.withdrawTeam(80072);
            userData.battle.abortMission();

        }

        public void mapsc2_3()
        {


            mapsc2_3 map = new mapsc2_3(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(80080, 0, 0, random.Next(5, 7), 3017, 6685, 10037, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map, map.Spots.dic[1]);

            string endResult = userData.battle.endTurn(data);
            if(Function.Normal_PosCheck_type2(endResult, 80079) == 1)
            {
                strbattledata = battleData.setData(80079, 1, 0, random.Next(5, 7), 3136, 11700, 10038, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            endResult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(endResult, 80079) == 1)
            {
                strbattledata = battleData.setData(80079, 1, 0, random.Next(5, 7), 3136, 11700, 10038, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            strbattledata = battleData.setData(80084, 0, 0, random.Next(5, 7), 5097, 15400, 900166, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            endResult = userData.battle.endTurn(data);
            strbattledata = battleData.setData(80082, 1, 0, random.Next(5, 7), 4385, 12242, 900166, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            if (Function.Normal_PosCheck_type2(endResult, 80079) == 1)
            {
                strbattledata = battleData.setData(80079, 0, 0, random.Next(5, 7), 3136, 11700, 10038, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.withdrawTeam(80079);
            userData.battle.reinforceTeam(map, map.Spots.dic[2],false , false);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.withdrawTeam(80079);

            userData.battle.abortMission();

        }

        public void mapsc2_4ex()
        {


            mapsc2_4ex map = new mapsc2_4ex(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(13236, 0, 0, random.Next(10, 12), 17928, 38772, 10037, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步



            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.reinforceTeam(map, map.Spots.dic[1], false, false);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            userData.battle.withdrawTeam(13233);


            userData.battle.abortMission();

        }
        public void mapsc2_4()
        {


            mapsc2_4 map = new mapsc2_4(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(80115, 0, 0, random.Next(5, 7), 3891, 11811, 10037, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map, map.Spots.dic[1],false,false);

            string endResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            if(Function.Normal_PosCheck_type2(endResult, 80116) == 1)
            {
                strbattledata = battleData.setData(80116, 0, 0, random.Next(5, 7), 3891, 11811, 10037, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            if (Function.Normal_PosCheck_type2(endResult, 80111) == 1)
            {
                strbattledata = battleData.setData(80111, 0, 0, random.Next(5, 7), 3891, 11811, 10037, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            endResult =  userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(endResult, 80111) == 1)
            {
                strbattledata = battleData.setData(80111, 0, 0, random.Next(5, 7), 3891, 11811, 10037, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            if (Function.Normal_PosCheck_type2(endResult, 80109) == 1)
            {
                strbattledata = battleData.setData(80109, 0, 0, random.Next(5, 7), 4176, 13976, 10037, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(80108, 0, 0, random.Next(5, 7), 4745, 13074, 900166, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.abortMission();

        }

        public void mapsc2_1ex()
        {
            mapsc2_1ex map = new mapsc2_1ex(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(13158, 0, 0, random.Next(40, 60), 25398, 66993, 12066, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
        }
        public void mapscbox()
        {
            userData.battle.Check_Equip_Gun_FULL();
            mapsc2_1ex();
            userData.battle.Check_Equip_Gun_FULL();
            mapsc2_1ex();
            userData.battle.Check_Equip_Gun_FULL();
            mapsc2_1ex();
            userData.battle.Check_Equip_Gun_FULL();
            mapsc2_1ex();
            userData.battle.Check_Equip_Gun_FULL();
            mapsc2_1ex();

        }

        public void mapisomer01()
        {


            mapisomer01 map = new mapisomer01(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            strbattledata = battleData.setData(12302, 0, 0, random.Next(5, 7), 5302, 276, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(12303, 0, 0, random.Next(5, 7), 5302, 1305, 10002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(12300, 0, 0, random.Next(5, 7), 5302, 2835, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(12299, 0, 0, random.Next(5, 7), 852, 1125, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            string EndTurnresult = userData.battle.endTurn(data);

        }

        public void mapisomer02()
        {


            mapisomer02 map = new mapisomer02(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
        }

        public void mapisomerbox()
        {
            mapisomer09();



        }
        public void mapisomer09()
        {


            mapisomer09 map = new mapisomer09(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            strbattledata = battleData.setData(11038, 0, 0, random.Next(5, 7), 85938, 157845, 10027, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            string EndTurnresult = userData.battle.endTurn(data);
            strbattledata = battleData.setData(11056, 0, 0, random.Next(5, 7), 3876, 22278, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            strbattledata = battleData.setData(11057, 0, 0, random.Next(5, 7), 91008, 166250, 10027, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.buildingSkillPerform(map.listBuilding[0]);
            userData.battle.buildingSkillPerform(map.listBuilding[1]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11045, 0, 0, random.Next(5, 7), 1512, 12334, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11043, 0, 0, random.Next(5, 7), 1512, 12334, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11028, 0, 0, random.Next(5, 7), 3324, 13339, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);




        }

        /// <summary>
        /// X95
        /// </summary>
        public void mapisomer23()
        {


            mapisomer23 map = new mapisomer23(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11173, 0, 0, random.Next(5, 7), 3894, 20566, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            string EndTurnresult = userData.battle.endTurn(data);

            strbattledata = battleData.setData(11156, 0, 0, random.Next(5, 7), 8461, 30131, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11157, 0, 0, random.Next(5, 7), 3931, 17805, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11158, 0, 0, random.Next(5, 7), 3894, 15340, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11172, 0, 0, random.Next(5, 7), 8461, 37890, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.abortMission();


            
        }

        /// <summary>
        /// P22
        /// </summary>
        public void mapisomer17()
        {


            mapisomer17 map = new mapisomer17(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(10918, 0, 0, random.Next(5, 7), 3984, 15027, 10037, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(10924, 0, 0, random.Next(5, 7), 3510, 15315, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(10929, 0, 0, random.Next(5, 7), 3510, 15315, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(10916, 0, 0, random.Next(5, 7), 4914, 24441, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(10940, 0, 0, random.Next(5, 7), 3510, 20315, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }





            
            userData.battle.abortMission();



        }

        /// <summary>
        /// UKM-2000
        /// </summary>
        public void mapisomer10()
        {


            mapisomer10 map = new mapisomer10(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11338, 0, 0, random.Next(5, 7), 2202, 10533, 10024, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            strbattledata = battleData.setData(11338, 0, 0, random.Next(5, 7), 3064, 9404, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11347, 0, 0, random.Next(5, 7), 2668, 28554, 18580, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11348, 0, 0, random.Next(5, 7), 4992, 28554, 10028, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11349, 0, 0, random.Next(5, 7), 1021, 22721, 10030, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.abortMission();



        }

        /// <summary>
        /// HK21
        /// </summary>
        public void mapisomer11()
        {


            mapisomer11 map = new mapisomer11(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11385, 0, 0, random.Next(5, 7), 6039, 13672, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11399, 0, 0, random.Next(5, 7), 3820, 12256, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11400, 0, 0, random.Next(5, 7), 3820, 12256, 10026, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.abortMission();



        }


        /// <summary>
        /// CZ75
        /// </summary>
        public void mapisomer12()
        {


            mapisomer12 map = new mapisomer12(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11070, 0, 0, random.Next(5, 7), 2535, 17650, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.buildingSkillPerform(map.listBuilding[0]);
            userData.battle.buildingSkillPerform(map.listBuilding[1]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11096, 0, 0, random.Next(5, 7), 2879, 13122, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11103, 0, 0, random.Next(5, 7), 1449, 13888, 10040, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            

            userData.battle.abortMission();



        }

        /// <summary>
        /// AK74U
        /// </summary>
        public void mapisomer13()
        {


            mapisomer13 map = new mapisomer13(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.reinforceTeam(map,map.Spots.dic[1]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11112, 0, 0, random.Next(5, 7), 2907, 14619, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11117, 0, 0, random.Next(5, 7), 2901, 18613, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11114, 0, 0, random.Next(5, 7), 2901, 2325, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11116, 0, 0, random.Next(5, 7), 4239, 26866, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.endTurn(data);
            strbattledata = battleData.setData(11116, 0, 0, random.Next(5, 7), 3868, 21484, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11140, 0, 0, random.Next(5, 7), 4239, 21866, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11141, 0, 0, random.Next(5, 7), 3868, 26484, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11113, 0, 0, random.Next(5, 7), 4046, 26677, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);







        }


        /// <summary>
        /// OTS44
        /// </summary>
        public void mapisomer14()
        {


            mapisomer14 map = new mapisomer14(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步


            strbattledata = battleData.setData(10876, 0, 0, random.Next(5, 7), 2319, 17268, 10038, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.abortMission();





        }



        /// <summary>
        /// 失温症3-4
        /// </summary>
        public void mapisomer25()
        {


            mapisomer25 map = new mapisomer25(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            userData.battle.allyMySideMove();
            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            strbattledata = battleData.setData(11201, 0, 0, random.Next(5, 7), 39098, 27428, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(11207, 0, 0, random.Next(5, 7), 4494, 20693, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.abortMission();



        }

        /// <summary>
        /// 蜜罐
        /// </summary>
        public void mapg28()
        {


            mapg28 map = new mapg28(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2940, 0, 0, random.Next(5, 7), 16740, 27840, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2944, 0, 0, random.Next(5, 7), 11967, 31395, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            strbattledata = battleData.setData(2944, 0, 0, random.Next(5, 7), 15388, 13000, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.abortMission();



        }

        /// <summary>
        /// 蜜罐
        /// </summary>
        public void mapaw1_2()
        {


            mapaw1_2 map = new mapaw1_2(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2201, 0, 0, random.Next(5, 7), 7386, 8439, 900051, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2198, 0, 0, random.Next(5, 7), 1212, 3489, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2196, 0, 0, random.Next(5, 7), 1808, 2592, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            
            userData.battle.endTurn(data);



        }

        /// <summary>
        /// 蜜罐
        /// </summary>
        public void mapaw2_4()
        {


            mapaw2_4 map = new mapaw2_4(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2502, 0, 0, random.Next(5, 7), 6517, 7539, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map,map.Spots.dic[1], true);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2450, 0, 0, random.Next(5, 7), 5636, 9648, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2452, 0, 0, random.Next(5, 7), 31311, 34050, 900051, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            strbattledata = battleData.setData(2452, 0, 0, random.Next(5, 7), 7560, 19130, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            strbattledata = battleData.setData(2503, 1, 0, random.Next(5, 7), 5636, 9648, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2453, 0, 0, random.Next(5, 7), 7560, 19130, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2447, 0, 0, random.Next(5, 7), 14052, 34200, 900053, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2445, 0, 0, random.Next(5, 7), 14052, 34200, 900053, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            if(result.Contains("rank"))
            {
                return;
            }
            else
            {
                mapaw2_4();
            }

            



        }

        public void mapaw3_4()
        {


            mapaw3_4 map = new mapaw3_4(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2994, 0, 0, random.Next(5, 7), 16740, 27840, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2977, 0, 0, random.Next(5, 7), 52629, 75000, 900051, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

           string endTurnResult =   userData.battle.endTurn(data);
            if(Function.Normal_PosCheck_type2(endTurnResult, 2924) == 1)
            {
                strbattledata = battleData.setData(2924, 1, 0, random.Next(5, 7), 16740, 27840, 10004, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            if (Function.Normal_PosCheck_type2(endTurnResult, 2976) == 1)
            {
                strbattledata = battleData.setData(2976, 0, 0, random.Next(5, 7), 16252, 18340, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            if (Function.Normal_PosCheck_type2(endTurnResult, 2986) == 1)
            {
                strbattledata = battleData.setData(2986, 0, 0, random.Next(5, 7), 16252, 18340, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }

            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2987, 0, 0, random.Next(5, 7), 19662, 32425, 900054, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            endTurnResult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(endTurnResult, 2924) == 1)
            {
                strbattledata = battleData.setData(2924, 1, 0, random.Next(5, 7), 16740, 27840, 10004, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(endTurnResult, 2987) == 1)
            {
                strbattledata = battleData.setData(2987, 0, 0, random.Next(5, 7), 16252, 18340, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2989, 0, 0, random.Next(5, 7), 16252, 18340, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2990, 0, 0, random.Next(5, 7), 13500, 17816, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(2991, 0, 0, random.Next(5, 7), 36612, 45940, 900055, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }













            if (result.Contains("rank"))
            {
                return;
            }
            else
            {
                mapaw3_4();
            }





        }

        public void mapawbox()
        {

            mapaw1_2(); userData.battle.Check_Equip_Gun_FULL();
            mapaw1_2(); userData.battle.Check_Equip_Gun_FULL();
            mapaw1_2(); userData.battle.Check_Equip_Gun_FULL();
            mapaw1_2(); userData.battle.Check_Equip_Gun_FULL();
            mapaw1_2(); userData.battle.Check_Equip_Gun_FULL();
            mapaw2_4(); userData.battle.Check_Equip_Gun_FULL();
            mapaw2_4(); userData.battle.Check_Equip_Gun_FULL();
            mapaw2_4(); userData.battle.Check_Equip_Gun_FULL();
            mapaw2_4(); userData.battle.Check_Equip_Gun_FULL();
            mapaw2_4(); userData.battle.Check_Equip_Gun_FULL();
            mapaw3_4(); userData.battle.Check_Equip_Gun_FULL();
            mapaw3_4(); userData.battle.Check_Equip_Gun_FULL();
            mapaw3_4(); userData.battle.Check_Equip_Gun_FULL();
            mapaw3_4(); userData.battle.Check_Equip_Gun_FULL();
            mapaw3_4(); userData.battle.Check_Equip_Gun_FULL();

        }



    }
}

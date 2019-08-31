using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Text.RegularExpressions;
using static GFHelp.Mission.Map_Controller;

namespace GFHelp.Mission
{
    class Summer2019 : MapManager
    {
        public Summer2019(UserData userData) : base(userData)
        {

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
            userData.battle.reinforceTeam(map, map.Spots.dic[1]);

            userData.battle.allyMySideMove();
            string endturnResult = userData.battle.endTurn(data);

            strbattledata = battleData.setData(80046, 0, 0, random.Next(5, 7), 3510, 2970, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            if (Function.Normal_PosCheck_type2(endturnResult, 80045) == 1)
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

        public void mapsc2_2ex()
        {


            mapsc2_2ex map = new mapsc2_2ex(data);
            data.needSupply = false;

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.SupplyTeam(map, data, 0, 0);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            strbattledata = battleData.setData(13186, 0, 0, random.Next(10, 15), 12635, 27314, 10037, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            strbattledata = battleData.setData(13189, 0, 0, random.Next(10, 15), 72836, 251891, 900117, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            userData.battle.withdrawTeam(13190);
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
            if (Function.Normal_PosCheck_type2(endResult, 80079) == 1)
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
            userData.battle.reinforceTeam(map, map.Spots.dic[2], false, false);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.withdrawTeam(80079);

            userData.battle.abortMission();

        }

        public void mapsc2_3ex()
        {


            mapsc2_3ex map = new mapsc2_3ex(data);
            data.needSupply = false;

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.SupplyTeam(map, data, 0, 0);
            string endResult = userData.battle.endTurn(data);

            strbattledata = battleData.setData(13197, 0, 0, random.Next(5, 7), 12593, 53361, 0, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            strbattledata = battleData.setData(13198, 0, 0, random.Next(5, 7), 16281, 52373, 0, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map, map.Spots.dic[1]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.withdrawTeam(13197);//右移一步
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
            userData.battle.reinforceTeam(map, map.Spots.dic[1], false, false);

            string endResult = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);//右移一步

            if (Function.Normal_PosCheck_type2(endResult, 80116) == 1)
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

            endResult = userData.battle.endTurn(data);
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

        public void mapsc2_1exbox()
        {
            mapsc2_1exbox map = new mapsc2_1exbox(data);


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
            mapsc2_1exbox();
            userData.battle.Check_Equip_Gun_FULL();
            mapsc2_1exbox();
            userData.battle.Check_Equip_Gun_FULL();
            mapsc2_1exbox();
            userData.battle.Check_Equip_Gun_FULL();
            mapsc2_1exbox();
            userData.battle.Check_Equip_Gun_FULL();
            mapsc2_1exbox();

        }






    }
}
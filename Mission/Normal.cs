using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Text.RegularExpressions;

namespace GFHelp.Mission
{
    public class Normal
    {
        public static string Test()
        {
            return "Hello world";
        }

        public void map0_2(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map0_2.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map0_2.spots2.team_id = ubti.Teams[1].TeamID;//李白
            Map_Sent.map0_2.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map0_2.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map0_2.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map0_2.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map0_2.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map0_2.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;

            if(userData.battle.startMission(Map_Sent.map0_2.mission_id, Map_Sent.map0_2.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(Map_Sent.map0_2.dic_TeamMove[stepNum++]);

            battledata =  new BattleData(ubti.Teams).setData(17, 0, 0, random.Next(8, 10), 9544, 28800, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map0_2.dic_TeamMove[stepNum++]);


            battledata = new BattleData(ubti.Teams).setData(18, 0, 0, random.Next(8, 10), 8449, 23684, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.map0_2.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map0_2.dic_TeamMove[stepNum++]);
            battledata = new BattleData(ubti.Teams).setData(16, 0, 0, random.Next(8, 10), 4795, 11079, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();



            userData.battle.teamMove(Map_Sent.map0_2.dic_TeamMove[stepNum++]);


            battledata = new BattleData(ubti.Teams).setData(23, 0, 0, random.Next(8, 10), 6270, 18000, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.map0_2.dic_TeamMove[stepNum++]);


            battledata = new BattleData(ubti.Teams).setData(25, 0, 0, random.Next(8, 10), 6540, 18184, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }




            userData.battle.endTurn();
        }

        public void map1_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map1_6.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map1_6.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map1_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_6.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_6.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_6.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_6.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_6.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;




            if(userData.battle.startMission(Map_Sent.map1_6.mission_id, Map_Sent.map1_6.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);


            userData.battle.teamMove(Map_Sent.map1_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map1_6.dic_TeamMove[stepNum++]);


            battledata = new BattleData(ubti.Teams).setData(135, 0, 0, random.Next(8, 10), 279, 512, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove_Random(Map_Sent.map1_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map1_6.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(136, 0, 0, random.Next(8, 10), 435, 519, 20002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.map1_6.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(144, 0, 0, random.Next(8, 10), 480, 415, 20002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map1_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove_Random(Map_Sent.map1_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(149, 0, 0, random.Next(8, 10), 519, 764, 90002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            result = userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.map1_6.dic_TeamMove[stepNum++]);
            if (Map_Sent.map1_6.HomePos2(result) == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(146, 0, 0, random.Next(8, 10), 380, 800, 20004, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }



            userData.battle.teamMove(Map_Sent.map1_6.dic_TeamMove[stepNum++]);

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                //new Log().userInit(userData.GameAccount.Base.GameAccountID, "1_6BOSS 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map1_6(userData,ubti);
            }
        }


        public void map2_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map2_6.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map2_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;



            if(userData.battle.startMission(Map_Sent.map2_6.mission_id, Map_Sent.map2_6.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.map2_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map2_6.dic_TeamMove[stepNum++]);



            
            battledata = new BattleData(ubti.Teams).setData(263, 0, 0, random.Next(8, 10), 736, 1820, 20005, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();

            
            battledata = new BattleData(ubti.Teams).setData(263, 0, 0, random.Next(8, 10), 1008, 7860, 20005, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.map2_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map2_6.dic_TeamMove[stepNum++]);



            
            battledata = new BattleData(ubti.Teams).setData(271, 0, 0, random.Next(8, 10), 2804, 6356, 90004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "2_6BOSS 成功", "").userInfo();
        }

        public void map3_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map3_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map3_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;




            if(userData.battle.startMission(Map_Sent.map3_6.mission_id, Map_Sent.map3_6.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.map3_6.dic_TeamMove[stepNum++]);

            userData.battle.teamMove_Random(Map_Sent.map3_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(423, 0, 0, random.Next(8, 10), 1534, 4461, 20005, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.map3_6.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(424, 0, 0, random.Next(8, 10), 1866, 5070, 20006, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            
            userData.battle.teamMove(Map_Sent.map3_6.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(425, 0, 0, random.Next(8, 10), 6626, 13700, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "3_6BOSS 成功", "").userInfo();
        }

        public void map4_1(UserData userData, Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map4_1.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_1.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map4_1.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_1.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_1.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_1.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_1.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;

            
            if(userData.battle.startMission(Map_Sent.map4_1.mission_id, Map_Sent.map4_1.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.teamMove(Map_Sent.map4_1.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(512, 0, 0, random.Next(10, 12), 1680, 4341, 20006, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            int i = userData.battle.teamMove_Random(Map_Sent.map4_1.dic_TeamMove[stepNum++]);
            if (i == 1)
            {
                battledata = new BattleData(ubti.Teams).setData(511, 0, 0, random.Next(10, 12), 2704, 8436, 20005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }


            userData.battle.teamMove(Map_Sent.map4_1.dic_TeamMove[stepNum++]);
            battledata = new BattleData(ubti.Teams).setData(509, 0, 0, random.Next(10, 12), 2704, 8436, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_1.dic_TeamMove[stepNum++]);
            battledata = new BattleData(ubti.Teams).setData(508, 0, 0, random.Next(10, 12), 1409, 4563, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_1.dic_TeamMove[stepNum++]);
            userData.battle.endTurn();

        }



        public void map4_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map4_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map4_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;



            if (userData.battle.startMission(Map_Sent.map4_6.mission_id, Map_Sent.map4_6.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.map4_6.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(588, 0, 0, random.Next(8, 10), 1790, 4415, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            
            userData.battle.teamMove(Map_Sent.map4_6.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(594, 0, 0, random.Next(8, 10), 2336, 6732, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            //右移一步
            
            userData.battle.teamMove(Map_Sent.map4_6.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(598, 0, 0, random.Next(8, 10), 2403, 5742, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            
            userData.battle.teamMove(Map_Sent.map4_6.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(604, 0, 0, random.Next(8, 10), 8876, 16656, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "4_6BOSS 成功", "").userInfo();
        }

        public void map5_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map5_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map5_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            

            if(userData.battle.startMission(Map_Sent.map5_6.mission_id, Map_Sent.map5_6.Mission_Start_spots)== -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);


            //右移一步
            
            userData.battle.teamMove(Map_Sent.map5_6.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(808, 0, 0, random.Next(8, 10), 3960, 11922, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            
            userData.battle.teamMove(Map_Sent.map5_6.dic_TeamMove[stepNum++]);


            //右移一步
            
            userData.battle.teamMove(Map_Sent.map5_6.dic_TeamMove[stepNum++]);



            //右移一步
            
            userData.battle.teamMove(Map_Sent.map5_6.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(826, 0, 0, random.Next(8, 10), 11633, 19416, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "5_6BOSS 成功", "").userInfo();
        }

        public void map6_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map6_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map6_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_6.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_6.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_6.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;

            

            if(userData.battle.startMission(Map_Sent.map6_6.mission_id, Map_Sent.map6_6.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.map6_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(1634, 0, 0, random.Next(8, 10), 5980, 15210, 10004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.map6_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map6_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(1620, 0, 0, random.Next(8, 10), 7988, 19644, 10006, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map6_6.dic_TeamMove[stepNum++]);
            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(1621, 0, 0, random.Next(8, 10), 7988, 19644, 10006, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.map6_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map6_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(1632, 0, 0, random.Next(8, 10), 8578, 17114, 10005, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map6_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(1633, 0, 0, random.Next(8, 10), 18986, 42505, 900033, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "6_6BOSS 成功", "").userInfo();
        }

        public void map7_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.map7_6.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map7_6.spots2.team_id = ubti.Teams[1].TeamID;//李白
            Map_Sent.map7_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map7_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map7_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map7_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            string battledata;

            if (userData.battle.startMission(Map_Sent.map7_6.mission_id, Map_Sent.map7_6.Mission_Start_spots)== -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.teamMove(Map_Sent.map7_6.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(1947, 0, 0, random.Next(4, 6), 6756, 11380, 10004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map7_6.dic_TeamMove[stepNum++]);


            
            battledata = new BattleData(ubti.Teams).setData(1949, 0, 0, random.Next(8, 10), 5475, 8890, 10001, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.endTurn();


            
            battledata = new BattleData(ubti.Teams).setData(1949, 0, 0, random.Next(8, 10), 5475, 8890, 10001, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.map7_6.dic_TeamMove[stepNum++]);


            
            battledata = new BattleData(ubti.Teams).setData(1947, 0, 0, random.Next(8, 10), 6752, 5688, 10005, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.reinforceTeam(Map_Sent.map7_6.spots2);

            userData.battle.teamMove(Map_Sent.map7_6.dic_TeamMove[stepNum++]);

            userData.battle.withdrawTeam(Map_Sent.map7_6.withdrawSpot);

            userData.battle.abortMission();




        }


        public void map7_6boss(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map7_6boss.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map7_6boss.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map7_6boss.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map7_6boss.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map7_6boss.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map7_6boss.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map7_6boss.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map7_6boss.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map7_6boss.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;


            

            if(userData.battle.startMission(Map_Sent.map7_6boss.mission_id, Map_Sent.map7_6boss.Mission_Start_spots)== -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.map7_6boss.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(1947, 0, 0, random.Next(8, 10), 6756, 11380, 10004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.reinforceTeam(Map_Sent.map7_6boss.spots2);
            userData.battle.SupplyTeam(ubti.Teams[1].TeamID, ubti.needSupply);

            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(1947, 0, 0, random.Next(8, 10), 6752, 5688, 10005, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            
            battledata = new BattleData(ubti.Teams).setData(1948, 1, 0, random.Next(8, 10), 5475, 8890, 10001, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.map7_6boss.dic_TeamMove[stepNum++]);
            userData.battle.SupplyTeam(ubti.Teams[1].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.map7_6boss.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map7_6boss.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(1946, 0, 0, random.Next(8, 10), 10875, 16022, 10002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.map7_6boss.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(2152, 0, 0, random.Next(8, 10), 10415, 23979, 10006, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.map7_6boss.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(1941, 0, 0, random.Next(8, 10), 12904, 17068, 10008, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(1941, 0, 0, random.Next(8, 10), 24604, 53992, 900039, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map7_6boss.dic_TeamMove[stepNum++]);
            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.GameAccountID, "7_6BOSS 成功", "").userInfo();
        }
        public void map8_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map8_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map8_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;

            Map_Sent.map8_6.dic_TeamMove[11].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[12].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[13].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_6.dic_TeamMove[14].team_id = ubti.Teams[0].TeamID;

            

            if(userData.battle.startMission(Map_Sent.map8_6.mission_id, Map_Sent.map8_6.Mission_Start_spots)== -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);
            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            userData.battle.reinforceTeam(Map_Sent.map8_6.spots2);
            userData.battle.SupplyTeam(ubti.Teams[1].TeamID, ubti.needSupply);

            string endTurn = userData.battle.endTurn();
            int pos1 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3789);
            int pos2 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3662);
            int pos3 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3679);

            userData.battle.endEnemyTurn();
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            if (pos1 == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3789, 0, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            if (pos2 == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3662, 0, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            if (pos3 == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3679, 0, 0, random.Next(8, 10), 14216, 15880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }




            endTurn = userData.battle.endTurn();

            int airport = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3679);
            int home = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3788);
            pos1 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3681);
            pos2 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3682);
            if (home == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3788, 1, 0, random.Next(8, 10), 14184, 17816, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (airport == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3679, 0, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);

            if (pos1 == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3681, 0, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            if (pos2 == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3682, 0, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }


            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(3667, 0, 0, random.Next(8, 10), 13305, 44774, 10012, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(3673, 0, 0, random.Next(8, 10), 13305, 44774, 10012, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            endTurn = userData.battle.endTurn();
            home = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3788);
            if (home == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3788, 1, 0, random.Next(8, 10), 14184, 17816, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(3664, 0, 0, random.Next(8, 10), 18023, 31636, 10004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(3670, 0, 0, random.Next(8, 10), 18023, 31636, 10004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(3669, 0, 0, random.Next(8, 10), 23382, 38970, 900070, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);

            endTurn = userData.battle.endTurn();
            home = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3788);
            if (home == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(3788, 1, 0, random.Next(8, 10), 14184, 17816, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map8_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(3668, 0, 0, random.Next(8, 10), 27549, 38000, 900071, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            if (result.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "8_6BOSS 成功", "").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map8_6(userData,ubti);
            }
        }

        public void map10_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map10_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map10_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map10_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map10_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map10_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;

            

            if(userData.battle.startMission(Map_Sent.map10_6.mission_id, Map_Sent.map10_6.Mission_Start_spots)== -1)
            {
                ubti.Loop = false;
                return;
            }
            userData.battle.SupplyTeam(ubti.Teams[0].TeamID);
            userData.battle.teamMove(Map_Sent.map10_6.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(5360, 0, 0, random.Next(8, 10), 22672, 21562, 10017, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.reinforceTeam(Map_Sent.map10_6.spots2);

            userData.battle.allyMySideMove();
            string endTurn = userData.battle.endTurn();
            int home = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 5363);
            int pos1 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 5360);
            int pos2 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 5357);
            int pos3 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 5346);
            if (home == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(5363, 1, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (pos1 == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(5360, 0, 0, random.Next(8, 10), 22672, 21562, 10017, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.map10_6.dic_TeamMove[stepNum++]);
            if (pos2 == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(5357, 0, 0, random.Next(8, 10), 22672, 21562, 10017, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.teamMove(Map_Sent.map10_6.dic_TeamMove[stepNum++]);
            if (pos3 == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(5346, 0, 0, random.Next(100, 160), 37053, 107083, 900087, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            if (result.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "10_6BOSS 成功", "").userInfo();
            }
            userData.battle.abortMission();
        }




        public void map10_4e(UserData userData, Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map10_4e.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map10_4e.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map10_4e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map10_4e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map10_4e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map10_4e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map10_4e.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map10_4e.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;



            

            
            if(userData.battle.startMission(Map_Sent.map10_4e.mission_id, Map_Sent.map10_4e.Mission_Start_spots)== -1)
            {
                ubti.Loop = false;
                return;
            }

            //右移一步

            userData.battle.teamMove(Map_Sent.map10_4e.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(5495, 0, 0, random.Next(10, 12), 26702, 43140, 10027, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            
            userData.battle.teamMove(Map_Sent.map10_4e.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验

            battledata = new BattleData(ubti.Teams).setData(5492, 0, 0, random.Next(10, 12), 39015, 63520, 10027, userData.user_Info.experience);
            

            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map10_4e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map10_4e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map10_4e.dic_TeamMove[stepNum++]);

            battledata = new BattleData(ubti.Teams).setData(5497, 0, 0, random.Next(10, 12), 26702, 43140, 10027, userData.user_Info.experience);
            

            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            userData.battle.allyMySideMove();
            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();

            battledata = new BattleData(ubti.Teams).setData(5497, 0, 0, random.Next(10, 12), 39015, 63520, 10027, userData.user_Info.experience);
            

            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endOtherSideTurn();
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.map10_4e.dic_TeamMove[stepNum++]);


            //撤离
            
            userData.battle.withdrawTeam(Map_Sent.map10_4e.withdrawSpot);

            //战役结束

            userData.battle.abortMission();
        }


        public void map5_2n(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map5_2n.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map5_2n.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map5_2n.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_2n.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_2n.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_2n.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_2n.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_2n.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_2n.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;




            

            if(userData.battle.startMission(Map_Sent.map5_2n.mission_id, Map_Sent.map5_2n.Mission_Start_spots)== -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.teamMove(Map_Sent.map5_2n.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(3037, 0, 0, random.Next(8, 10), 13376, 19401, 10016,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map5_2n.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(3038, 0, 0, random.Next(8, 10), 11830, 2430, 10018,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.map5_2n.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(3047, 0, 0, random.Next(8, 10), 14196, 2916, 10018,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map5_2n.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(3052, 0, 0, random.Next(8, 10), 11370, 17811, 10016,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            userData.battle.teamMove(Map_Sent.map5_2n.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_2n.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(3056, 0, 0, random.Next(8, 10), 13376, 19401, 10016,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map5_2n.dic_TeamMove[stepNum++]);
            userData.battle.withdrawTeam(Map_Sent.map5_2n.withdrawSpot);
            userData.battle.abortMission();









        }

        public void map2_4n(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map2_4n.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map2_4n.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_4n.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_4n.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_4n.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_4n.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;



            
            if(userData.battle.startMission(Map_Sent.map2_4n.mission_id, Map_Sent.map2_4n.Mission_Start_spots)== -1)
            {
                ubti.Loop = false;
                return;
            }

            userData.battle.teamMove(Map_Sent.map2_4n.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map2_4n.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(1453, 0, 0, random.Next(8, 10), 7012, 5568, 10005,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTurn1 = userData.battle.endTurn();//能否靠这个猜测第二个光头 如果记得被占则终止作战
            if (Map_Sent.map2_4n.PosCheck1(endTurn1) == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(1453, 0, 0, random.Next(8, 10), 6707, 10016, 10016,  userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                     userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.map2_4n.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map2_4n.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map2_4n.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(1461, 0, 0, random.Next(8, 10), 5988, 7624, 10008,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.abortMission();

        }

        public void map3_4n(UserData userData, Normal_MissionInfo ubti)
        {
            string battledata;
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.map3_4n.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[11].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[12].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4n.dic_TeamMove[13].team_id = ubti.Teams[0].TeamID;



            


            //是否需要单独补给
            
            

            //部署梯队
            //回合开始
            
            if(userData.battle.startMission(Map_Sent.map3_4n.mission_id, Map_Sent.map3_4n.Mission_Start_spots)== -1)
            {
                ubti.Loop = false;
                return;
            }





            userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(1347, 0, 0, random.Next(8, 10), 6020, 10112, 20008,  userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }






            string endTurn1 = userData.battle.endTurn();//能否靠这个猜测第二个光头 如果记得被占则终止作战
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            var regex = new Regex("1485");
            var matches = regex.Matches(endTurn1);
            if (matches.Count == 2)
            {
                userData.battle.abortMission();
                return;
            }

            
            userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[stepNum++]);

            
            battledata = new BattleData(ubti.Teams).setData(1503, 0, 0, random.Next(8, 10), 6044, 5056, 20008,  userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            
            userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[stepNum++]);

            //第二个光头在还不在?

            
            battledata = new BattleData(ubti.Teams).setData(1504, 0, 0, random.Next(8, 10), 7775, 6505, 20008,  userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            //else
            //{
            //    userData.battle.abortMission();
            //    return;
            //}

            
            userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[stepNum++]);


            string endTurn2 = userData.battle.endTurn();//分支开始推测强无敌位置  站在机场 回合结束
            int Bosscase = Map_Sent.map3_4n.BossPos(endTurn2);
            int rCase = Map_Sent.map3_4n.rPos(endTurn2);

            switch (rCase)
            {
                case 1:
                    {
                        
                        battledata = new BattleData(ubti.Teams).setData(1505, 0, 0, random.Next(8, 10), 7775, 6505, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(battledata, ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }
                        break;
                    }
                default:
                    break;
            }


            switch (Bosscase)
            {
                case 0:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        //机场上方
                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[4]);

                        
                        battledata = new BattleData(ubti.Teams).setData(1489, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(battledata, ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }



                        break;
                    }
                case 1:
                    {
                        
                        battledata = new BattleData(ubti.Teams).setData(1505, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(battledata, ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }

                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        break;

                    }
                case 2:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[7]);

                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[8]);

                        
                        battledata = new BattleData(ubti.Teams).setData(1506, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(battledata, ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }


                        break;

                    }

                case 3:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[7]);

                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[9]);

                        
                        battledata = new BattleData(ubti.Teams).setData(1507, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(battledata, ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }



                        break;

                    }

                case 4:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[7]);

                        
                        battledata = new BattleData(ubti.Teams).setData(1509, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(battledata, ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }
                        break;

                    }

                case 5:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[4]);

                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[10]);

                        
                        battledata = new BattleData(ubti.Teams).setData(1506, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(battledata, ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }
                        break;
                    }

                case 6:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[4]);

                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[11]);


                        
                        battledata = new BattleData(ubti.Teams).setData(1490, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(battledata, ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }



                        break;
                    }

                case 7:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[4]);

                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[12]);

                        
                        battledata = new BattleData(ubti.Teams).setData(1501, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(battledata, ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }
                        break;
                    }

                case 8:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[4]);

                        
                        userData.battle.teamMove(Map_Sent.map3_4n.dic_TeamMove[13]);

                        
                        battledata = new BattleData(ubti.Teams).setData(1476, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(battledata, ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }



                        break;
                    }

                default:
                    break;
            }








            userData.battle.abortMission();

        }

        public void map6_4n(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map6_4n.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_4n.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map6_4n.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_4n.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_4n.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_4n.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_4n.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_4n.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_4n.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map6_4n.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;


            
            if(userData.battle.startMission(Map_Sent.map6_4n.mission_id, Map_Sent.map6_4n.Mission_Start_spots)== -1)
            {
                ubti.Loop = false;
                return;
            }


            userData.battle.teamMove(Map_Sent.map6_4n.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map6_4n.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map6_4n.dic_TeamMove[stepNum++]);


            
            battledata = new BattleData(ubti.Teams).setData(4078, 0, 0, random.Next(8, 10), 15024, 27914, 10016,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map6_4n.dic_TeamMove[stepNum++]);


            
            battledata = new BattleData(ubti.Teams).setData(4082, 0, 0, random.Next(8, 10), 9934, 20116, 10009,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTurn1 = userData.battle.endTurn();//能否靠这个猜测第二个光头 如果记得被占则终止作战


            if (Map_Sent.Function.Night_PosCheck_type1(endTurn1, 4082) == 1)
            {
                
                battledata = new BattleData(ubti.Teams).setData(4082, 0, 0, random.Next(10, 18), 16354, 52503, 10012,  userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(battledata, ref result))
                {
                     userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.map6_4n.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map6_4n.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(4068, 0, 0, random.Next(10, 18), 28741, 61209, 900060,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map6_4n.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map6_4n.dic_TeamMove[stepNum++]);
            userData.battle.withdrawTeam(Map_Sent.map6_4n.withdrawSpot);
            userData.battle.abortMission();







        }

        public void map8_1n(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.map8_1n.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_1n.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.map8_1n.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_1n.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_1n.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_1n.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_1n.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map8_1n.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;




            if (userData.battle.startMission(Map_Sent.map8_1n.mission_id, Map_Sent.map8_1n.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                return;
            }


            userData.battle.teamMove(Map_Sent.map8_1n.dic_TeamMove[stepNum++]);
            battledata = new BattleData(ubti.Teams).setData(7076, 0, 0, random.Next(8, 10), 22542, 5018, 10018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map8_1n.dic_TeamMove[stepNum++]);

            battledata = new BattleData(ubti.Teams).setData(7068, 0, 0, random.Next(8, 10), 22542, 5018, 10018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map8_1n.dic_TeamMove[stepNum++]);

            battledata = new BattleData(ubti.Teams).setData(7067, 0, 0, random.Next(8, 10), 7410, 11135, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map8_1n.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(7075, 0, 0, random.Next(8, 10), 22542, 5018, 10018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map8_1n.dic_TeamMove[stepNum++]);
            battledata = new BattleData(ubti.Teams).setData(7074, 0, 0, random.Next(8, 10), 7410, 11135, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map8_1n.dic_TeamMove[stepNum++]);
            userData.battle.withdrawTeam(Map_Sent.map8_1n.withdrawSpot);
            userData.battle.abortMission();
        }

        public void map0_1(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            Map_Sent.Map0_1.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_1.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map0_1.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_1.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_1.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_1.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_1.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;

            if (userData.battle.startMission(Map_Sent.Map0_1.mission_id, Map_Sent.Map0_1.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(Map_Sent.Map0_1.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map0_1.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(3, 0, 0, random.Next(8, 10), 6062, 16773, 20006, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.Map0_1.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map0_1.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map0_1.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(6, 0, 0, random.Next(8, 10), 3120, 5376, 20006, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
        }




        public void map1_1e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map1_1e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map1_1e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map1_1e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_1e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_1e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_1e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;




            if (userData.battle.startMission(Map_Sent.map1_1e.mission_id, Map_Sent.map1_1e.Mission_Start_spots) == -1)
            {
                ubti.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(Map_Sent.map1_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map1_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(153, 0, 0, random.Next(8, 10), 260, 550, 20001,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map1_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(158, 0, 0, random.Next(8, 10), 520, 1160, 20004,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map1_1e.dic_TeamMove[stepNum++]);





            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "1-1e成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map1_1e(userData,ubti);
            }
        }
        public void map1_2e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map2_1e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map2_1e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map2_1e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_1e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_1e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_1e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_1e.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;


            if (userData.battle.startMission(Map_Sent.map1_1e.mission_id, Map_Sent.map1_1e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map2_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map2_1e.dic_TeamMove[stepNum++]);
            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map2_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(166, 0, 0, random.Next(8, 10), 300, 666, 20004,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map2_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(168, 0, 0, random.Next(8, 10), 535, 142, 20004,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map2_1e.dic_TeamMove[stepNum++]);

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "1_2E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map1_2e(userData,ubti);
            }
        }
        public void map1_3e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map1_3e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map1_3e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map1_3e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_3e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_3e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_3e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_3e.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;

            

           if (userData.battle.startMission(Map_Sent.map1_3e.mission_id, Map_Sent.map1_3e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map1_3e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map1_3e.dic_TeamMove[stepNum++]);
            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(176, 0, 0, random.Next(8, 10), 545, 1240, 20004,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map1_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(180, 0, 0, random.Next(8, 10), 366, 930, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map1_3e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map1_3e.dic_TeamMove[stepNum++]);



            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "1_3E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map1_3e(userData,ubti);
            }
        }
        public void map1_4e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map1_4e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map1_4e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map1_4e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_4e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_4e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_4e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_4e.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_4e.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_4e.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_4e.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map1_4e.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;


            

           if (userData.battle.startMission(Map_Sent.map1_4e.mission_id, Map_Sent.map1_4e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map1_4e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map1_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(187, 0, 0, random.Next(8, 10), 425, 1158, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map1_4e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map1_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(188, 0, 0, random.Next(8, 10), 735, 2040, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.map1_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(196, 0, 0, random.Next(8, 10), 611, 1531, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map1_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(200, 0, 0, random.Next(8, 10), 611, 1531, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map1_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(201, 0, 0, random.Next(8, 10), 611, 1531, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map1_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(198, 0, 0, random.Next(8, 10), 611, 1531, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map1_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(199, 0, 0, random.Next(8, 10), 611, 1531, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "1_4E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map1_4e(userData,ubti);
            }
        }
        public void map2_1e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map2_1e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map2_1e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map2_1e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_1e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_1e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;


            

           if (userData.battle.startMission(Map_Sent.map2_1e.mission_id, Map_Sent.map2_1e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map2_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(286, 0, 0, random.Next(8, 10), 1296, 3368, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map2_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(285, 0, 0, random.Next(8, 10), 1074, 2478, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map2_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(281, 0, 0, random.Next(8, 10), 775, 2100, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "2_1E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map2_1e(userData,ubti);
            }
        }
        public void map2_2e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map2_2e.spots1.team_id = ubti.Teams[0].TeamID;//机霰

            Map_Sent.map2_2e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_2e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_2e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_2e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_2e.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_2e.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;

            

           if (userData.battle.startMission(Map_Sent.map2_2e.mission_id, Map_Sent.map2_2e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map2_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(292, 0, 0, random.Next(8, 10), 1845, 3475, 20002,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map2_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(295, 0, 0, random.Next(8, 10), 975, 2860, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(295, 0, 0, random.Next(8, 10), 975, 2860, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map2_2e.dic_TeamMove[stepNum++]);
            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.map2_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(297, 0, 0, random.Next(8, 10), 876, 2552, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map2_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(298, 0, 0, random.Next(8, 10), 1053, 2962, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map2_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(300, 0, 0, random.Next(8, 10), 1019, 2486, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "2_2E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map2_2e(userData,ubti);
            }
        }
        public void map2_3e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map2_3e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map2_3e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map2_3e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_3e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_3e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_3e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            

           if (userData.battle.startMission(Map_Sent.map2_3e.mission_id, Map_Sent.map2_3e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map2_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(304, 0, 0, random.Next(8, 10), 1021, 2324, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.reinforceTeam(Map_Sent.map2_3e.spots2);
            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(302, 1, 0, random.Next(8, 10), 1460, 1030, 20003,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            
            battledata = new BattleData(ubti.Teams).setData(304, 0, 0, random.Next(8, 10), 882, 2044, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.map2_3e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map2_3e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map2_3e.dic_TeamMove[stepNum++]);

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "2_3E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map2_3e(userData,ubti);
            }
        }
        public void map2_4e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map2_4e.spots1.team_id = ubti.Teams[0].TeamID;//机霰

            Map_Sent.map2_4e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_4e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_4e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map2_4e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            

           if (userData.battle.startMission(Map_Sent.map2_4e.mission_id, Map_Sent.map2_4e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map2_4e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map2_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(320, 0, 0, random.Next(8, 10), 1353, 3195, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(320, 0, 0, random.Next(8, 10), 1840, 4544, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map2_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(324, 0, 0, random.Next(8, 10), 3887, 8029, 90005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map2_4e.dic_TeamMove[stepNum++]);


            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "2_4E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map2_4e(userData,ubti);
            }
        }
        public void map3_1e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map3_1e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map3_1e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map3_1e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_1e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_1e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_1e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_1e.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;

            

           if (userData.battle.startMission(Map_Sent.map3_1e.mission_id, Map_Sent.map3_1e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map3_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(446, 0, 0, random.Next(8, 10), 2480, 5637, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.reinforceTeam(Map_Sent.map3_1e.spots2);
            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(446, 0, 0, random.Next(8, 10), 1534, 4461, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            
            battledata = new BattleData(ubti.Teams).setData(449, 1, 0, random.Next(8, 10), 1534, 4461, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map3_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(442, 0, 0, random.Next(8, 10), 1534, 4461, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map3_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map3_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map3_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(438, 0, 0, random.Next(8, 10), 2204, 6680, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "3_1E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map3_1e(userData,ubti);
            }
        }
        public void map3_2e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map3_2e.spots1.team_id = ubti.Teams[0].TeamID;//机霰

            Map_Sent.map3_2e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_2e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_2e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;


            

           if (userData.battle.startMission(Map_Sent.map3_2e.mission_id, Map_Sent.map3_2e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map3_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(455, 0, 0, random.Next(8, 10), 1910, 3190, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.map3_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(459, 0, 0, random.Next(8, 10), 1910, 3190, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(459, 0, 0, random.Next(8, 10), 1795, 5105, 20004,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map3_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(462, 0, 0, random.Next(8, 10), 2703, 7920, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "3_2E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map3_2e(userData,ubti);
            }
        }
        public void map3_3e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map3_3e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map3_3e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map3_3e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_3e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_3e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;


            

           if (userData.battle.startMission(Map_Sent.map3_3e.mission_id, Map_Sent.map3_3e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map3_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(478, 0, 0, random.Next(8, 10), 2564, 7504, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map3_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(481, 0, 0, random.Next(8, 10), 2564, 7504, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map3_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(480, 0, 0, random.Next(8, 10), 2248, 5734, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "3_3E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map3_3e(userData,ubti);
            }
        }
        public void map3_4e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map3_4e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map3_4e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map3_4e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map3_4e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            

           if (userData.battle.startMission(Map_Sent.map3_4e.mission_id, Map_Sent.map3_4e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map3_4e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map3_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(490, 0, 0, random.Next(8, 10), 2203, 6152, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map3_4e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map3_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(492, 0, 0, random.Next(8, 10), 6710, 11422, 90007,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "3_4E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map3_4e(userData,ubti);
            }
        }
        public void map4_1e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map4_1e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map4_1e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map4_1e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_1e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_1e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_1e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_1e.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_1e.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;

            

           if (userData.battle.startMission(Map_Sent.map4_1e.mission_id, Map_Sent.map4_1e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map4_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(613, 0, 0, random.Next(8, 10), 3015, 9465, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map4_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(620, 0, 0, random.Next(8, 10), 3030, 9000, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(621, 0, 0, random.Next(8, 10), 3276, 10378, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(621, 0, 0, random.Next(8, 10), 1790, 4415, 20008,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            
            battledata = new BattleData(ubti.Teams).setData(609, 1, 0, random.Next(8, 10), 1790, 4415, 20008,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map4_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map4_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(625, 0, 0, random.Next(8, 10), 3414, 9814, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "4_1E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map4_1e(userData,ubti);
            }
        }
        public void map4_2e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map4_2e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map4_2e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map4_2e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_2e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_2e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_2e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            

           if (userData.battle.startMission(Map_Sent.map4_2e.mission_id, Map_Sent.map4_2e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map4_2e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map4_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(637, 0, 0, random.Next(8, 10), 2570, 6865, 20008,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(640, 0, 0, random.Next(8, 10), 2570, 6865, 20008,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(639, 0, 0, random.Next(8, 10), 2915, 7918, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "4_2E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map4_2e(userData,ubti);
            }
        }
        public void map4_3e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map4_3e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map4_3e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map4_3e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_3e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_3e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_3e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            

           if (userData.battle.startMission(Map_Sent.map4_3e.mission_id, Map_Sent.map4_3e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map4_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(659, 0, 0, random.Next(8, 10), 1597, 3567, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(660, 0, 0, random.Next(8, 10), 1597, 3567, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(661, 0, 0, random.Next(8, 10), 1597, 3567, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(662, 0, 0, random.Next(8, 10), 2568, 7209, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "4_3E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map4_3e(userData,ubti);
            }
        }
        public void map4_4e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map4_4e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map4_4e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map4_4e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_4e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_4e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map4_4e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            

           if (userData.battle.startMission(Map_Sent.map4_4e.mission_id, Map_Sent.map4_4e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map4_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(670, 0, 0, random.Next(8, 10), 2790, 8050, 20004,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(676, 0, 0, random.Next(8, 10), 2303, 3881, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(680, 0, 0, random.Next(8, 10), 2303, 3881, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map4_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(686, 0, 0, random.Next(8, 10), 10289, 19176, 900012,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "4_4E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map4_4e(userData,ubti);
            }
        }

        public void map5_1e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map5_1e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map5_1e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map5_1e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_1e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_1e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_1e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;

            Map_Sent.map5_1e.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_1e.dic_TeamMove[5].team_id = ubti.Teams[1].TeamID;//
            Map_Sent.map5_1e.dic_TeamMove[6].team_id = ubti.Teams[1].TeamID;//
            Map_Sent.map5_1e.dic_TeamMove[7].team_id = ubti.Teams[1].TeamID;//

            Map_Sent.map5_1e.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_1e.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_1e.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_1e.dic_TeamMove[11].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_1e.dic_TeamMove[12].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_1e.dic_TeamMove[13].team_id = ubti.Teams[0].TeamID;

            

           if (userData.battle.startMission(Map_Sent.map5_1e.mission_id, Map_Sent.map5_1e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(837, 0, 0, random.Next(8, 10), 3579, 10815, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(843, 0, 0, random.Next(8, 10), 3933, 16781, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(844, 0, 0, random.Next(8, 10), 3810, 12753, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(846, 1, 0, random.Next(8, 10), 4896, 7064, 20002,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(851, 1, 0, random.Next(8, 10), 3972, 11960, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(844, 0, 0, random.Next(8, 10), 4100, 10304, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            
            battledata = new BattleData(ubti.Teams).setData(851, 1, 0, random.Next(8, 10), 4100, 10304, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(842, 0, 0, random.Next(8, 10), 4100, 10304, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(839, 0, 0, random.Next(8, 10), 4117, 10615, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_1e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(838, 0, 0, random.Next(8, 10), 4181, 16918, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "5_1E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map5_1e(userData,ubti);
            }
        }
        public void map5_2e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map5_2e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map5_2e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map5_2e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_2e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_2e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_2e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;



            

           if (userData.battle.startMission(Map_Sent.map5_2e.mission_id, Map_Sent.map5_2e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map5_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(861, 0, 0, random.Next(8, 10), 4108, 10008, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_2e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(870, 0, 0, random.Next(8, 10), 2748, 8048, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_2e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(869, 0, 0, random.Next(8, 10), 5856, 13296, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "5_2E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map5_2e(userData,ubti);
            }
        }
        public void map5_3e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map5_3e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map5_3e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map5_3e.spots3.team_id = ubti.Teams[2].TeamID;//机霰
            Map_Sent.map5_3e.dic_TeamMove[0].team_id = ubti.Teams[1].TeamID;
            Map_Sent.map5_3e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_3e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_3e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;

            Map_Sent.map5_3e.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_3e.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_3e.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_3e.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;

            Map_Sent.map5_3e.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_3e.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;


            

           if (userData.battle.startMission(Map_Sent.map5_3e.mission_id, Map_Sent.map5_3e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map5_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(903, 1, 0, random.Next(8, 10), 4575, 13360, 20004,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_3e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(904, 0, 0, random.Next(8, 10), 4383, 11160, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.reinforceTeam(Map_Sent.map5_3e.spots3);
            userData.battle.endTurn();
            
            battledata = new BattleData(ubti.Teams).setData(907, 2, 0, random.Next(8, 10), 4575, 13360, 20004,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.map5_3e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_3e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(895, 0, 0, random.Next(8, 10), 5552, 15972, 20008,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_3e.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.map5_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(886, 0, 0, random.Next(8, 10), 3393, 11356, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(884, 0, 0, random.Next(8, 10), 4560, 10456, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.map5_3e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(883, 0, 0, random.Next(8, 10), 4867, 16918, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "5_3E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map5_3e(userData,ubti);
            }
        }
        public void map5_4e(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";string battledata;
            Map_Sent.map5_4e.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.map5_4e.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.map5_4e.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_4e.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_4e.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.map5_4e.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;




            

           if (userData.battle.startMission(Map_Sent.map5_4e.mission_id, Map_Sent.map5_4e.Mission_Start_spots) == -1){ubti.Loop = false;return;}
            userData.battle.teamMove(Map_Sent.map5_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(914, 0, 0, random.Next(8, 10), 4090, 12760, 20005,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(919, 0, 0, random.Next(8, 10), 4132, 10100, 20006,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(926, 0, 0, random.Next(8, 10), 3997, 13015, 20009,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.map5_4e.dic_TeamMove[stepNum++]);
            
            battledata = new BattleData(ubti.Teams).setData(932, 0, 0, random.Next(8, 10), 15124, 23990, 900018,userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, "5_4E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map5_4e(userData,ubti);
            }
        }



















































































    }
}

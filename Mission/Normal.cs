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

        public void Battle0_2(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.Map0_2.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map0_2.spots2.team_id = ubti.Teams[1].TeamID;//李白
            Map_Sent.Map0_2.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_2.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_2.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_2.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_2.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_2.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;




            userData.others.Check_Equip_GUN_FULL();

            userData.battle.startMission(Map_Sent.Map0_2.mission_id, Map_Sent.Map0_2.Mission_Start_spots);

            userData.battle.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(17, 0, 0, random.Next(8, 10), 9544, 28800, 20005, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);


            BattleData.Teams = ubti.Teams;
            BattleData.setData(18, 0, 0, random.Next(8, 10), 8449, 23684, 20008, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(16, 0, 0, random.Next(8, 10), 4795, 11079, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();



            userData.battle.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(23, 0, 0, random.Next(8, 10), 6270, 18000, 20004, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(25, 0, 0, random.Next(8, 10), 6540, 18184, 20008, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }




            userData.battle.endTurn();
        }

        public void Battle1_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map1_6.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map1_6.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.Map1_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;

            userData.others.Check_Equip_GUN_FULL();


            userData.battle.startMission(Map_Sent.Map1_6.mission_id, Map_Sent.Map1_6.Mission_Start_spots);

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);


            userData.battle.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(135, 0, 0, random.Next(8, 10), 279, 512, 20004, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove_Random(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(136, 0, 0, random.Next(8, 10), 435, 519, 20002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(144, 0, 0, random.Next(8, 10), 480, 415, 20002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove_Random(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(149, 0, 0, random.Next(8, 10), 519, 764, 90002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            result = userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);
            if (Map_Sent.Map1_6.HomePos2(result) == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(146, 0, 0, random.Next(8, 10), 380, 800, 20004, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }



            userData.battle.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

            string endTrun = userData.battle.endTurn();
            if (endTrun.Contains("rank"))
            {
                //WriteLog.Log("1_6BOSS 成功", "log");
            }
            else
            {
                userData.battle.abortMission();
                Battle1_6(userData,ubti);
            }
        }


        public void Battle2_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.Map2_6.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map2_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;



            userData.battle.startMission(Map_Sent.Map2_6.mission_id, Map_Sent.Map2_6.Mission_Start_spots);

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.Map2_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map2_6.dic_TeamMove[stepNum++]);



            BattleData.Teams = ubti.Teams;
            BattleData.setData(263, 0, 0, random.Next(8, 10), 736, 1820, 20005, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();

            BattleData.Teams = ubti.Teams;
            BattleData.setData(263, 0, 0, random.Next(8, 10), 1008, 7860, 20005, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.Map2_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map2_6.dic_TeamMove[stepNum++]);



            BattleData.Teams = ubti.Teams;
            BattleData.setData(271, 0, 0, random.Next(8, 10), 2804, 6356, 90004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.Accountid, "2_6BOSS 成功", "").userInfo();
        }

        public void Battle3_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map3_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map3_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;




            userData.battle.startMission(Map_Sent.Map3_6.mission_id, Map_Sent.Map3_6.Mission_Start_spots);

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);

            userData.battle.teamMove_Random(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(423, 0, 0, random.Next(8, 10), 1534, 4461, 20005, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(424, 0, 0, random.Next(8, 10), 1866, 5070, 20006, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            
            userData.battle.teamMove(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(425, 0, 0, random.Next(8, 10), 6626, 13700, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.Accountid, "3_6BOSS 成功", "").userInfo();
        }

        public void Battle4_1(UserData userData, Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map4_1.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_1.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map4_1.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_1.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_1.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_1.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_1.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;

            
            userData.battle.startMission(Map_Sent.Map4_1.mission_id, Map_Sent.Map4_1.Mission_Start_spots);

            userData.battle.teamMove(Map_Sent.Map4_1.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(512, 0, 0, random.Next(10, 12), 1680, 4341, 20006, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            int i = userData.battle.teamMove_Random(Map_Sent.Map4_1.dic_TeamMove[stepNum++]);
            if (i == 1)
            {
                BattleData.setData(511, 0, 0, random.Next(10, 12), 2704, 8436, 20005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }


            userData.battle.teamMove(Map_Sent.Map4_1.dic_TeamMove[stepNum++]);
            BattleData.setData(509, 0, 0, random.Next(10, 12), 2704, 8436, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.Map4_1.dic_TeamMove[stepNum++]);
            BattleData.setData(508, 0, 0, random.Next(10, 12), 1409, 4563, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.teamMove(Map_Sent.Map4_1.dic_TeamMove[stepNum++]);
            userData.battle.endTurn();

        }



        public void Battle4_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map4_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map4_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;

            

            userData.battle.startMission(Map_Sent.Map4_6.mission_id, Map_Sent.Map4_6.Mission_Start_spots);

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(588, 0, 0, random.Next(8, 10), 1790, 4415, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            
            userData.battle.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(594, 0, 0, random.Next(8, 10), 2336, 6732, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            //右移一步
            
            userData.battle.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(598, 0, 0, random.Next(8, 10), 2403, 5742, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            
            userData.battle.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(604, 0, 0, random.Next(8, 10), 8876, 16656, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.Accountid, "4_6BOSS 成功", "").userInfo();
        }

        public void Battle5_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map5_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map5_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            

            userData.battle.startMission(Map_Sent.Map5_6.mission_id, Map_Sent.Map5_6.Mission_Start_spots);

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);


            //右移一步
            
            userData.battle.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(808, 0, 0, random.Next(8, 10), 3960, 11922, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            
            userData.battle.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);


            //右移一步
            
            userData.battle.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);



            //右移一步
            
            userData.battle.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(826, 0, 0, random.Next(8, 10), 11633, 19416, 90002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.Accountid, "5_6BOSS 成功", "").userInfo();
        }

        public void Battle6_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map6_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;

            

            userData.battle.startMission(Map_Sent.Map6_6.mission_id, Map_Sent.Map6_6.Mission_Start_spots);

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(1634, 0, 0, random.Next(8, 10), 5980, 15210, 10004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(1620, 0, 0, random.Next(8, 10), 7988, 19644, 10006, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            userData.battle.endTurn();
            BattleData.Teams = ubti.Teams;
            BattleData.setData(1621, 0, 0, random.Next(8, 10), 7988, 19644, 10006, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(1632, 0, 0, random.Next(8, 10), 8578, 17114, 10005, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(1633, 0, 0, random.Next(8, 10), 18986, 42505, 900033, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.Accountid, "6_6BOSS 成功", "").userInfo();
        }

        public void Battle7_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.Map7_6.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map7_6.spots2.team_id = ubti.Teams[1].TeamID;//李白
            Map_Sent.Map7_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            userData.battle.startMission(Map_Sent.Map7_6.mission_id, Map_Sent.Map7_6.Mission_Start_spots);

            userData.battle.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(1947, 0, 0, random.Next(4, 6), 6756, 11380, 10004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);


            BattleData.Teams = ubti.Teams;
            BattleData.setData(1949, 0, 0, random.Next(8, 10), 5475, 8890, 10001, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.endTurn();


            BattleData.Teams = ubti.Teams;
            BattleData.setData(1949, 0, 0, random.Next(8, 10), 5475, 8890, 10001, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);


            BattleData.Teams = ubti.Teams;
            BattleData.setData(1947, 0, 0, random.Next(8, 10), 6752, 5688, 10005, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.reinforceTeam(Map_Sent.Map7_6.spots2);

            userData.battle.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);

            userData.battle.withdrawTeam(Map_Sent.Map7_6.withdrawSpot);

            userData.battle.abortMission();




        }


        public void Battle7_6BOSS(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map7_6BOSS.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;


            

            userData.battle.startMission(Map_Sent.Map7_6BOSS.mission_id, Map_Sent.Map7_6BOSS.Mission_Start_spots);

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(1947, 0, 0, random.Next(8, 10), 6756, 11380, 10004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.reinforceTeam(Map_Sent.Map7_6BOSS.spots2);
            userData.battle.SupplyTeam(ubti.Teams[1].TeamID, ubti.needSupply);

            userData.battle.endTurn();
            BattleData.Teams = ubti.Teams;
            BattleData.setData(1947, 0, 0, random.Next(8, 10), 6752, 5688, 10005, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            BattleData.Teams = ubti.Teams;
            BattleData.setData(1948, 1, 0, random.Next(8, 10), 5475, 8890, 10001, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            userData.battle.SupplyTeam(ubti.Teams[1].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(1946, 0, 0, random.Next(8, 10), 10875, 16022, 10002, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(2152, 0, 0, random.Next(8, 10), 10415, 23979, 10006, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(1941, 0, 0, random.Next(8, 10), 12904, 17068, 10008, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            userData.battle.endTurn();
            BattleData.Teams = ubti.Teams;
            BattleData.setData(1941, 0, 0, random.Next(8, 10), 24604, 53992, 900039, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            userData.battle.endTurn();
            new Log().userInit(userData.GameAccount.Base.Accountid, "7_6BOSS 成功", "").userInfo();
        }
        public void Battle8_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map8_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;

            Map_Sent.Map8_6.dic_TeamMove[11].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[12].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[13].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[14].team_id = ubti.Teams[0].TeamID;

            

            userData.battle.startMission(Map_Sent.Map8_6.mission_id, Map_Sent.Map8_6.Mission_Start_spots);

            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);
            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            userData.battle.reinforceTeam(Map_Sent.Map8_6.spots2);
            userData.battle.SupplyTeam(ubti.Teams[1].TeamID, ubti.needSupply);

            string endTurn = userData.battle.endTurn();
            int pos1 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3789);
            int pos2 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3662);
            int pos3 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3679);

            userData.battle.endEnemyTurn();
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            if (pos1 == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(3789, 0, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            if (pos2 == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(3662, 0, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            if (pos3 == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(3679, 0, 0, random.Next(8, 10), 14216, 15880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
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
                BattleData.Teams = ubti.Teams;
                BattleData.setData(3788, 1, 0, random.Next(8, 10), 14184, 17816, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (airport == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(3679, 0, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn();
            userData.battle.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);

            if (pos1 == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(3681, 0, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            if (pos2 == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(3682, 0, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }


            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(3667, 0, 0, random.Next(8, 10), 13305, 44774, 10012, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(3673, 0, 0, random.Next(8, 10), 13305, 44774, 10012, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            endTurn = userData.battle.endTurn();
            home = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3788);
            if (home == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(3788, 1, 0, random.Next(8, 10), 14184, 17816, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(3664, 0, 0, random.Next(8, 10), 18023, 31636, 10004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(3670, 0, 0, random.Next(8, 10), 18023, 31636, 10004, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(3669, 0, 0, random.Next(8, 10), 23382, 38970, 900070, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);

            endTurn = userData.battle.endTurn();
            home = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 3788);
            if (home == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(3788, 1, 0, random.Next(8, 10), 14184, 17816, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(3668, 0, 0, random.Next(8, 10), 27549, 38000, 900071, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            if (result.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.Accountid, "8_6BOSS 成功", "").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                Battle8_6(userData,ubti);
            }
        }

        public void Battle10_6(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map10_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map10_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;

            

            userData.battle.startMission(Map_Sent.Map10_6.mission_id, Map_Sent.Map10_6.Mission_Start_spots);
            userData.battle.SupplyTeam(ubti.Teams[0].TeamID);
            userData.battle.teamMove(Map_Sent.Map10_6.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(5360, 0, 0, random.Next(8, 10), 22672, 21562, 10017, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.reinforceTeam(Map_Sent.Map10_6.spots2);

            userData.battle.allyMySideMove();
            string endTurn = userData.battle.endTurn();
            int home = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 5363);
            int pos1 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 5360);
            int pos2 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 5357);
            int pos3 = Map_Sent.Function.Normal_PosCheck_type2(endTurn, 5346);
            if (home == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(5363, 1, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (pos1 == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(5360, 0, 0, random.Next(8, 10), 22672, 21562, 10017, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.Map10_6.dic_TeamMove[stepNum++]);
            if (pos2 == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(5357, 0, 0, random.Next(8, 10), 22672, 21562, 10017, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.teamMove(Map_Sent.Map10_6.dic_TeamMove[stepNum++]);
            if (pos3 == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(5346, 0, 0, random.Next(100, 160), 37053, 107083, 900087, userData.user_Info.experience);
                
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                    userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            if (result.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.Base.Accountid, "10_6BOSS 成功", "").userInfo();
            }
            userData.battle.abortMission();
        }




        public void Battle10_4E(UserData userData, Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map10_4E.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;



            

            
            userData.battle.startMission(Map_Sent.Map10_4E.mission_id, Map_Sent.Map10_4E.Mission_Start_spots);

            //右移一步
            
            userData.battle.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(5495, 0, 0, random.Next(10, 12), 26702, 43140, 10027, userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            
            userData.battle.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验

            BattleData.setData(5492, 0, 0, random.Next(10, 12), 39015, 63520, 10027, userData.user_Info.experience);
            

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);

            BattleData.setData(5497, 0, 0, random.Next(10, 12), 26702, 43140, 10027, userData.user_Info.experience);
            

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            userData.battle.allyMySideMove();
            userData.battle.endTurn();
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();

            BattleData.setData(5497, 0, 0, random.Next(10, 12), 39015, 63520, 10027, userData.user_Info.experience);
            

            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.endOtherSideTurn();
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);


            //撤离
            
            userData.battle.withdrawTeam(Map_Sent.Map10_4E.withdrawSpot);

            //战役结束

            userData.battle.abortMission();
        }


        public void Battle5_2N(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.Map5_2N.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map5_2N.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;




            

            userData.battle.startMission(Map_Sent.Map5_2N.mission_id, Map_Sent.Map5_2N.Mission_Start_spots);

            userData.battle.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(3037, 0, 0, random.Next(8, 10), 13376, 19401, 10016,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(3038, 0, 0, random.Next(8, 10), 11830, 2430, 10018,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            userData.battle.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(3047, 0, 0, random.Next(8, 10), 14196, 2916, 10018,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(3052, 0, 0, random.Next(8, 10), 11370, 17811, 10016,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            userData.battle.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(3056, 0, 0, random.Next(8, 10), 13376, 19401, 10016,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);
            userData.battle.withdrawTeam(Map_Sent.Map5_2N.withdrawSpot);
            userData.battle.abortMission();









        }
        public void Battle2_4N(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.Map2_4N.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map2_4N.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_4N.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_4N.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_4N.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_4N.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;



            
            userData.battle.startMission(Map_Sent.Map2_4N.mission_id, Map_Sent.Map2_4N.Mission_Start_spots);

            userData.battle.teamMove(Map_Sent.Map2_4N.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map2_4N.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(1453, 0, 0, random.Next(8, 10), 7012, 5568, 10005,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTurn1 = userData.battle.endTurn();//能否靠这个猜测第二个光头 如果记得被占则终止作战
            if (Map_Sent.Map2_4N.PosCheck1(endTurn1) == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(1453, 0, 0, random.Next(8, 10), 6707, 10016, 10016,  userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                     userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn();

            userData.battle.teamMove(Map_Sent.Map2_4N.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map2_4N.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map2_4N.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(1461, 0, 0, random.Next(8, 10), 5988, 7624, 10008,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            userData.battle.abortMission();

        }


        public void Battle3_4N(UserData userData, Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map3_4N.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[11].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[12].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[13].team_id = ubti.Teams[0].TeamID;



            


            //是否需要单独补给
            
            

            //部署梯队
            //回合开始
            
            userData.battle.startMission(Map_Sent.Map3_4N.mission_id, Map_Sent.Map3_4N.Mission_Start_spots);




            
            userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(1347, 0, 0, random.Next(8, 10), 6020, 10112, 20008,  userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
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

            
            userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);

            BattleData.Teams = ubti.Teams;
            BattleData.setData(1503, 0, 0, random.Next(8, 10), 6044, 5056, 20008,  userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            
            userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);

            //第二个光头在还不在?

            BattleData.Teams = ubti.Teams;
            BattleData.setData(1504, 0, 0, random.Next(8, 10), 7775, 6505, 20008,  userData.user_Info.experience);
            
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            //else
            //{
            //    userData.battle.abortMission();
            //    return;
            //}

            
            userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);


            string endTurn2 = userData.battle.endTurn();//分支开始推测强无敌位置  站在机场 回合结束
            int Bosscase = Map_Sent.Map3_4N.BossPos(endTurn2);
            int rCase = Map_Sent.Map3_4N.rPos(endTurn2);

            switch (rCase)
            {
                case 1:
                    {
                        BattleData.Teams = ubti.Teams;
                        BattleData.setData(1505, 0, 0, random.Next(8, 10), 7775, 6505, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
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
                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

                        BattleData.Teams = ubti.Teams;
                        BattleData.setData(1489, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }



                        break;
                    }
                case 1:
                    {
                        BattleData.Teams = ubti.Teams;
                        BattleData.setData(1505, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
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
                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[7]);

                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[8]);

                        BattleData.Teams = ubti.Teams;
                        BattleData.setData(1506, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }


                        break;

                    }

                case 3:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[7]);

                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[9]);

                        BattleData.Teams = ubti.Teams;
                        BattleData.setData(1507, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }



                        break;

                    }

                case 4:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[7]);

                        BattleData.Teams = ubti.Teams;
                        BattleData.setData(1509, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }
                        break;

                    }

                case 5:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[10]);

                        BattleData.Teams = ubti.Teams;
                        BattleData.setData(1506, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }
                        break;
                    }

                case 6:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[11]);


                        BattleData.Teams = ubti.Teams;
                        BattleData.setData(1490, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }



                        break;
                    }

                case 7:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[12]);

                        BattleData.Teams = ubti.Teams;
                        BattleData.setData(1501, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                        {
                             userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                        }
                        break;
                    }

                case 8:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn();
                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

                        
                        userData.battle.teamMove(Map_Sent.Map3_4N.dic_TeamMove[13]);

                        BattleData.Teams = ubti.Teams;
                        BattleData.setData(1476, 0, 0, random.Next(8, 10), 9685, 21662, 20008,  userData.user_Info.experience);
                        
                        if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
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

        public void Battle6_4N(UserData userData, Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map6_4N.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_4N.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map6_4N.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_4N.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_4N.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_4N.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_4N.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_4N.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_4N.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_4N.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;


            
            userData.battle.startMission(Map_Sent.Map6_4N.mission_id, Map_Sent.Map6_4N.Mission_Start_spots);


            userData.battle.teamMove(Map_Sent.Map6_4N.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map6_4N.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map6_4N.dic_TeamMove[stepNum++]);


            BattleData.Teams = ubti.Teams;
            BattleData.setData(4078, 0, 0, random.Next(8, 10), 15024, 27914, 10016,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map6_4N.dic_TeamMove[stepNum++]);


            BattleData.Teams = ubti.Teams;
            BattleData.setData(4082, 0, 0, random.Next(8, 10), 9934, 20116, 10009,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTurn1 = userData.battle.endTurn();//能否靠这个猜测第二个光头 如果记得被占则终止作战


            if (Map_Sent.Function.Night_PosCheck_type1(endTurn1, 4082) == 1)
            {
                BattleData.Teams = ubti.Teams;
                BattleData.setData(4082, 0, 0, random.Next(10, 18), 16354, 52503, 10012,  userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
                {
                     userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn();


            userData.battle.teamMove(Map_Sent.Map6_4N.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map6_4N.dic_TeamMove[stepNum++]);
            BattleData.Teams = ubti.Teams;
            BattleData.setData(4068, 0, 0, random.Next(10, 18), 28741, 61209, 900060,  userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(BattleData.stringBuilder.ToString(), ref result))
            {
                 userData.battle.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            userData.battle.teamMove(Map_Sent.Map6_4N.dic_TeamMove[stepNum++]);
            userData.battle.teamMove(Map_Sent.Map6_4N.dic_TeamMove[stepNum++]);
            userData.battle.withdrawTeam(Map_Sent.Map6_4N.withdrawSpot);
            userData.battle.abortMission();







        }







    }
}

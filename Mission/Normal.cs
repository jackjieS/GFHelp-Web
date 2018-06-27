using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Management;
using System;

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













    }
}

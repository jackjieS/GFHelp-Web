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





        public void mapcorridor(UserData userData,MissionInfo.Data ignore)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            string battledata;
            MissionInfo.Data data= new MissionInfo.Data();
            Map_Controller.mapcorridor map = new Map_Controller.mapcorridor();
            if (Map_Controller.Function.Startmap(userData, ref map,ref data) == false) return;

            userData.battle.teamMove(map.teamMove.dic[stepNum++]);
            userData.battle.teamMove_Random(map.teamMove.dic[stepNum++],data);
            userData.battle.teamMove_Random(map.teamMove.dic[stepNum++],data);
            userData.battle.teamMove_Random(map.teamMove.dic[stepNum++],data);
            userData.battle.teamMove_Random(map.teamMove.dic[stepNum++],data);

            battledata = new BattleData(data.Teams).setData(5520, 0, 0, random.Next(8, 10), 26483, 28819, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(battledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
        }
    }
}

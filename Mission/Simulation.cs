using System;
using System.Collections.Generic;
using System.Text;
using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Management;

namespace GFHelp.Mission
{
    class Simulation : MapManager
    {
        public Simulation(UserData userData) : base(userData)
        {

        }





        public void mapsimulationdata()
        {

            Map_Controller.mapsimulationdata map = new Map_Controller.mapsimulationdata(userData);
            map.Start();
        }

        public void mapsimulationtrial()
        {
            Map_Controller.mapsimulationtrial map = new Map_Controller.mapsimulationtrial(userData);

            map.Start();


        }

        public void mapcorridor()
        {

            Map_Controller.mapcorridor map = new Map_Controller.mapcorridor(data);
            if (userData.battle.startMission(map, data) == -1) return;

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove_Random(map.teamMove.dic[map.stepNum++],data);
            userData.battle.teamMove_Random(map.teamMove.dic[map.stepNum++],data);
            userData.battle.teamMove_Random(map.teamMove.dic[map.stepNum++],data);
            userData.battle.teamMove_Random(map.teamMove.dic[map.stepNum++],data);

            strbattledata = battleData.setData(5520, 0, 0, random.Next(8, 10), 26483, 28819, 10009, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
        }
    }
}

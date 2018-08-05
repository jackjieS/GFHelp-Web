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
        public void Simulation_DATA(UserData userData,Simulation_MissionInfo usbt)
        {
            string result = "";
            Simulation_Battle_Sent sbs = new Simulation_Battle_Sent(usbt);
            if (userData.battle.Simulation_battleFinish(sbs.BattleResult, ref result) == true)
            {
                var jsonobj = Codeplex.Data.DynamicJson.Parse(result);

                int coin_num = Convert.ToInt32(jsonobj.coin_num);
                switch (usbt.Type)
                {
                    case 1:
                        {
                            userData.user_Info.coin1 += coin_num;
                            break;
                        }
                    case 2:
                        {
                            userData.user_Info.coin2 += coin_num;
                            break;
                        }
                    case 3:
                        {
                            userData.user_Info.coin3 += coin_num;
                            break;
                        }
                    default:
                        break;
                }
            }




        }
    }
}

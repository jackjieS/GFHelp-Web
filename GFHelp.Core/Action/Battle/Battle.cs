using Codeplex.Data;
using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace GFHelp.Core.Action
{
    public class Battle
    {
        public Battle(UserData userData)
        {
            this.userData = userData;
        }
        private UserData userData;

        private Random random = new Random();
        private void ThreadDelay(int Second)
        {
            double randome = random.NextDouble() + 1;
            Thread.Sleep((int)(Second * 1000 * userData.MissionInfo.GetFirstData().Delay * randome));
        }


        public void Abort_Mission_login()
        {
            abortMission();

        }
        public bool StartTrial(List<int> teamID)
        {
            userData.webData.StatusBarText = "开始防御演习";
            ThreadDelay(5);
            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("team_ids");
            jsonWriter.Write(teamID[0].ToString());
            jsonWriter.WritePropertyName("battle_team");
            jsonWriter.Write(teamID[0]);
            jsonWriter.WriteObjectEnd();

            int count = 0;

            while (true)
            {
                string result = userData.Net.Battle.StartTrial(userData.GameAccount, stringBuilder.ToString());

                switch (userData.Response.Check( ref result, "StartTrial_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, String.Format("{0} 无法开始作战任务，请登陆游戏检查", userData.user_Info.name)).userInfo();
                                return false;
                            }
                            userData.home.GetUserInfo();
                            userData.others.Check_Equip_GUN_FULL();
                            continue;
                        }
                    default:
                        break;
                }
            }

        }
        public bool EndTrial(string outdatacode)
        {
            int count = 0;
            while (true)
            {
                ThreadDelay(5);
                string result = userData.Net.Battle.EndTrial(userData.GameAccount, outdatacode);
                switch (userData.Response.Check( ref result, "EndTrial_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            break;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "终止无限防御 ").userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }



        }

        public bool abortMission()
        {
            userData.webData.StatusBarText = (" 终止作战");

            int count = 0;
            while (true)
            {
                string result = userData.Net.Battle.abortMission(userData.GameAccount);
                ThreadDelay(3);

                switch (userData.Response.Check( ref result, "Abort_Mission_Pro", true))
                {
                    case 1:
                        {
                            userData.battle.Check_Equip_Gun_FULL();
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {

                            if (count++ >= userData.config.ErrorCount) { return false; }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }

        public int startMission(mapbase map, MissionInfo.Data data)
        {

            if (data.Loop == false) return -1;
            userData.webData.StatusBarText = "回合开始";


            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();

            jsonWriter.WritePropertyName("mission_id");
            jsonWriter.Write(map.mission_id);

            jsonWriter.WritePropertyName("spots");
            jsonWriter.WriteArrayStart();
            foreach (var item in map.Mission_Start_spots)
            {
                jsonWriter.WriteObjectStart();
                jsonWriter.WritePropertyName("spot_id");
                jsonWriter.Write(item.spot_id);
                jsonWriter.WritePropertyName("team_id");
                jsonWriter.Write(item.team_id);
                jsonWriter.WriteObjectEnd();
            }
            jsonWriter.WriteArrayEnd();

            jsonWriter.WritePropertyName("squad_spots");
            jsonWriter.WriteArrayStart();
            jsonWriter.WriteArrayEnd();


            jsonWriter.WritePropertyName("ally_id");
            jsonWriter.Write(Decrypt.getDateTime_China_Int(DateTime.Now));



            jsonWriter.WriteObjectEnd();

            int count = 0;

            while (true)
            {
                ThreadDelay(15);
                string result = userData.Net.Battle.startMission(userData.GameAccount, stringBuilder.ToString());

                switch (userData.Response.Check( ref result, "Start_Mission_Pro", true))
                {
                    case 1:
                        {
                            SupplyTeam(map, data);
                            return 1;
                        }
                    case 0:
                        {
                            userData.home.GetUserInfo();
                            userData.others.Check_Equip_GUN_FULL();
                            continue;
                        }
                    case -1:
                        {
                            userData.home.GetUserInfo();
                            userData.battle.Check_Equip_Gun_FULL();
                            if (count++ > userData.config.ErrorCount)
                            {
                                if (data.Story == true)
                                {
                                    continue;
                                }
                                new Log().userInit(userData.GameAccount.GameAccountID, String.Format("{0} 无法开始作战任务，请登陆游戏检查", userData.user_Info.name)).userInfo();
                                userData.MissionInfo.listTask[0].Using = false;
                                userData.MissionInfo.listTask[0].Loop = false;
                                return -1;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }

        public bool reinforceTeam(Spot.Data spot, bool night = false)
        {
            userData.webData.StatusBarText = "部署梯队";


            int count = 0;

            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("spot_id");
            jsonWriter.Write(spot.spot_id);
            jsonWriter.WritePropertyName("team_id");
            jsonWriter.Write(spot.team_id);
            jsonWriter.WriteObjectEnd();

            int k = 0;
            while (true)
            {
                ThreadDelay(5);
                string result = userData.Net.Battle.reinforceTeam(userData.GameAccount, stringBuilder.ToString());

                if (night == false) k = userData.Response.Check( ref result, "reinforceTeam", true);
                if (night == true) k = userData.Response.Check( ref result, "night_reinforceTeam", true);

                switch (k)
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, String.Format("{0} 无法部署梯队，请登陆游戏检查", userData.user_Info.name), result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }


        public void allyTeamAi(int ally_instance_id, int ai_type)
        {
            userData.webData.StatusBarText = String.Format(" allyTeamAi = {0}", ally_instance_id.ToString());

            int count = 0;
            dynamic newjson = new DynamicJson();
            newjson.ally_instance_id /*这是节点*/ = ally_instance_id;/* 这是值*/
            newjson.ai_type = ai_type;

            while (true)
            {
                ThreadDelay(2);
                string result = userData.Net.Battle.allyTeamAi(userData.GameAccount, newjson.ToString());

                switch (userData.Response.Check( ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            return;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "allyTeamAi Error", result).userInfo();

                                return;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }
        public void allyMySideMove()
        {
            userData.webData.StatusBarText = "allyMySideMove";
            ThreadDelay(2);
            userData.Net.Battle.allyMySideMove(userData.GameAccount);
        }
        public void startOtherSideTurn()
        {
            userData.webData.StatusBarText = "startOtherSideTurn";
            ThreadDelay(2);
            userData.Net.Battle.startOtherSideTurn(userData.GameAccount);
        }

        public void endOtherSideTurn()
        {
            userData.webData.StatusBarText = "endOtherSideTurn";
            ThreadDelay(2);
            userData.Net.Battle.endOtherSideTurn(userData.GameAccount);
        }
        public bool teamMove(TeamMove.Data teammove)
        {
            userData.webData.StatusBarText = "移动";
            //{"team_id":6,"from_spot_id":3033,"to_spot_id":3038,"move_type":1}

            dynamic newjson = new DynamicJson();
            newjson.team_id /*这是节点*/ = teammove.team_id;/* 这是值*/
            newjson.from_spot_id /*这是节点*/ = teammove.from_spot_id;/* 这是值*/
            newjson.to_spot_id /*这是节点*/ = teammove.to_spot_id;/* 这是值*/
            newjson.move_type /*这是节点*/ = teammove.move_type;/* 这是值*/

            int count = 0;
            //发送请求
            while (true)
            {
                ThreadDelay(4);
                string result = userData.Net.Battle.teamMove(userData.GameAccount, newjson.ToString());

                switch (userData.Response.Check( ref result, "Team_Move_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "teamMove Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }
        }



        public int teamMove_Random(TeamMove.Data teammove, MissionInfo.Data data)
        {
            userData.webData.StatusBarText = "移动";
            //{"team_id":6,"from_spot_id":3033,"to_spot_id":3038,"move_type":1}
            ThreadDelay(3);
            dynamic newjson = new DynamicJson();
            newjson.team_id /*这是节点*/ = teammove.team_id;/* 这是值*/
            newjson.from_spot_id /*这是节点*/ = teammove.from_spot_id;/* 这是值*/
            newjson.to_spot_id /*这是节点*/ = teammove.to_spot_id;/* 这是值*/
            newjson.move_type /*这是节点*/ = teammove.move_type;/* 这是值*/

            int count = 0;
            //发送请求
            while (true)
            {
                string result = userData.Net.Battle.teamMove(userData.GameAccount, newjson.ToString());

                switch (userData.Response.Check( ref result, "Team_MoveRandom_Pro", true))
                {

                    case 1:
                        {
                            TeamMove_RandomHandle(result, data);



                            if (result.Contains("enemy_team_id")) return 1;
                            return 0;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "teamMove Error", result).userInfo();
                                return -1;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }
        }

        public void TeamMove_RandomHandle(string result, MissionInfo.Data data)
        {
            var jsonobj = Codeplex.Data.DynamicJson.Parse(result);
            if (result.Contains("coin3"))
            {
                data.recycleLog.Coin3 += Convert.ToInt16(jsonobj.coin3);
            }
            if (result.Contains("coin2"))
            {
                data.recycleLog.Coin2 += Convert.ToInt16(jsonobj.coin2);
            }
            if (result.Contains("coin1"))
            {
                data.recycleLog.Coin1 += Convert.ToInt16(jsonobj.coin1);
            }
            //loseammo
            if (result.Contains("loseammo"))
            {
                data.recycleLog.Ammo -= Convert.ToInt16(jsonobj.loseammo);
            }
            if (result.Contains("losemre"))
            {
                data.recycleLog.Mre -= Convert.ToInt16(jsonobj.losemre);
            }
            if (result.Contains("losemp"))
            {
                data.recycleLog.Mp -= Convert.ToInt16(jsonobj.losemp);
            }
            if (result.Contains("losepart"))
            {
                data.recycleLog.Part -= Convert.ToInt16(jsonobj.losepart);
            }
            if (result.Contains("mp") && !result.Contains("losemp"))
            {
                data.recycleLog.Mp += Convert.ToInt16(jsonobj.mp);
            }
            if (result.Contains("ammo") && !result.Contains("loseammo"))
            {
                data.recycleLog.Ammo += Convert.ToInt16(jsonobj.ammo);
            }
            if (result.Contains("mre") && !result.Contains("losemre"))
            {
                data.recycleLog.Mre += Convert.ToInt16(jsonobj.mre);
            }
            if (result.Contains("part") && !result.Contains("losepart"))
            {
                data.recycleLog.Part += Convert.ToInt16(jsonobj.part);
            }
            if (result.Contains("gun_id"))
            {
                Add_Get_Gun_Equip_Battle(jsonobj, data);
            }



        }



        public bool Normal_battleFinish(string data, ref string result, bool errorSkip = false)
        {
            userData.webData.StatusBarText = "战斗结算";
            //new Log().userInit(userData.GameAccount.GameAccountID, String.Format("data = {0}", data));

            int count = 0;

            while (true)
            {
                ThreadDelay(10);
                result = "";
                result = userData.Net.Battle.battleFinish(userData.GameAccount, data);

                switch (userData.Response.Check( ref result, "Battle_Finish_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                //new Log().userInit(userData.GameAccount.GameAccountID, "Normal_battleFinish Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }
        public bool FairyMissionSkill(int team_id, int spot_id, int new_spot_id)
        {
            userData.webData.StatusBarText = "妖精技能";

            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("fairy_team_id");
            jsonWriter.Write(team_id);
            jsonWriter.WritePropertyName("fairy_spot");
            jsonWriter.Write(spot_id);
            jsonWriter.WritePropertyName("spot_id");
            jsonWriter.WriteArrayStart();

            jsonWriter.Write(new_spot_id);

            jsonWriter.WriteArrayEnd();
            jsonWriter.WriteObjectEnd();
            int count = 0;

            while (true)
            {
                ThreadDelay(2);
                string result = userData.Net.Battle.FairyMissionSkill(userData.GameAccount, stringBuilder.ToString());

                switch (userData.Response.Check( ref result, "FairyMissionSkill", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "FairyMissionSkill Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }
        public bool withdrawTeam(int spot_id)
        {
            userData.webData.StatusBarText = "撤离";

            //{"spot_id":3033}
            var obj = new
            {
                spot_id = spot_id,
            };
            int count = 0;
            var jsonStringFromObj = DynamicJson.Serialize(obj);
            while (true)
            {
                ThreadDelay(3);
                string result = userData.Net.Battle.withdrawTeam(userData.GameAccount, jsonStringFromObj.ToString());

                switch (userData.Response.Check( ref result, "WithDraw_Team_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "withdrawTeam Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }
        public string endTurn(MissionInfo.Data data)
        {
            userData.webData.StatusBarText = "endTurn";

            int count = 0;

            while (true)
            {
                string result = userData.Net.Battle.endTurn(userData.GameAccount);
                ThreadDelay(5);
                switch (userData.Response.Check( ref result, "endTurn", true))
                {

                    case 1:
                        {
                            var jsonobj = DynamicJson.Parse(result);
                            userData.battle.Add_Get_Gun_Equip_Battle(jsonobj, data);
                            return result;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "endTurn Error", result).userInfo();
                                return result;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }


        public string startTurn(MissionInfo.Data data)
        {
            userData.webData.StatusBarText = "startTurn";


            int count = 0;

            while (true)
            {
                string result = userData.Net.Battle.startTurn(userData.GameAccount);
                ThreadDelay(5);
                switch (userData.Response.Check( ref result, "startTurn", true))
                {
                    case 1:
                        {
                            var jsonobj = DynamicJson.Parse(result);

                            userData.battle.Add_Get_Gun_Equip_Battle(jsonobj, data);
                            return result;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "startTurn Error", result).userInfo();
                                return result;
                            }
                            continue;
                        }
                    default:
                        break;
                }


            }
        }
        public bool Simulation_battleFinish(string data)
        {

            int count = 0;
            while (true)
            {
                ThreadDelay(10);
                string result = userData.Net.Battle.simulation_DATA(userData.GameAccount, data);

                switch (userData.Response.Check( ref result, "Simulation_DATA_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                return false;
                            }
                            continue;

                        }
                    default:
                        break;
                }

            }
        }
        public void endEnemyTurn()
        {
            userData.webData.StatusBarText = "endEnemyTurn";

            int count = 0;
            while (true)
            {
                string result = userData.Net.Battle.endEnemyTurn(userData.GameAccount);
                Thread.Sleep(3);

                switch (userData.Response.Check( ref result, "endEnemyTurn_PRO", true))
                {
                    case 1:
                        {
                            return;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "endEnemyTurn Error", result).userInfo();
                                return;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }

        }
        private void _SupplyTeam(string text)
        {
            int count = 0;
            while (true)
            {
                string result = userData.Net.Battle.SupplyTeam(userData.GameAccount, text);
                Thread.Sleep(3);
                switch (userData.Response.Check( ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            return;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "SupplyTeam Error", result).userInfo();
                                return;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }

        public bool SupplyTeam(mapbase map, MissionInfo.Data data)
        {
            if (data.needSupply == false) return true;


            foreach (var item in map.Mission_Start_spots)
            {
                dynamic newjson = new DynamicJson();
                newjson.team_id /*这是节点*/ = item.team_id;/* 这是值*/
                newjson.spot_id /*这是节点*/ = item.spot_id;/* 这是值*/
                _SupplyTeam(newjson.ToString());
            }
            return true;
        }

        public bool saveHostage(string spots)
        {
            userData.webData.StatusBarText = "拯救人质";
            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("spot_id");
            jsonWriter.Write(spots);
            jsonWriter.WriteObjectEnd();
            int count = 0;
            while (true)
            {
                string result = userData.Net.Battle.saveHostage(userData.GameAccount, stringBuilder.ToString());
                Thread.Sleep(3);

                switch (userData.Response.Check( ref result, "saveHostage", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "saveHostage Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }


        }
        public void Check_Gun_need_FIX(bool fix = false)
        {
            userData.webData.StatusBarText = "检查人形是否需要修复";

            for (int k = 0; k <= userData.Teams.Count; k++)
            {
                if (!userData.Teams.ContainsKey(k)) continue;
                for (int i = 0; i <= userData.Teams[k].Count; i++)
                {
                    if (!userData.Teams[k].ContainsKey(i)) continue;
                    if (userData.Teams[k][i].life == userData.Teams[k][i].maxLife) continue;
                    double life = (double)userData.Teams[k][i].life / userData.Teams[k][i].maxLife;
                    if (fix == true)
                    {
                        Fix_Gun(userData.Teams[k][i].id, true);

                    }
                    if (fix == false)
                    {
                        if (userData.item_With_User_Info.Quick_Reinforce <= 10) continue;
                        if (userData.Teams[k][i].life == userData.Teams[k][i].maxLife) continue;
                        if (life > 0.25) continue;
                        Fix_Gun(userData.Teams[k][i].id, true);
                        userData.Teams[k][i].life = userData.Teams[k][i].maxLife;
                        userData.item_With_User_Info.Quick_Reinforce -= 1;
                    }


                }
            }
        }

        public bool Fix_Gun(int gun_id, bool quick_fix)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("if_quick");
            if (quick_fix) jsonWriter.Write(1);
            if (!quick_fix) jsonWriter.Write(0);

            jsonWriter.WritePropertyName("fix_guns");

            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName(gun_id.ToString());
            jsonWriter.Write(1);
            jsonWriter.WriteObjectEnd();

            jsonWriter.WriteObjectEnd();

            int count = 0;
            while (true)
            {
                string result = userData.Net.Battle.Girl_Fix(userData.GameAccount, sb.ToString());
                ThreadDelay(5);
                switch (userData.Response.Check( ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "Fix_Gun Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }


            }
        }


        public Gun_With_User_Info.Data initGun(int id, int gun_id, MissionInfo.Data data = null)
        {
            Gun_With_User_Info.Data gwui = new Gun_With_User_Info.Data();
            gwui.id = id;
            gwui.gun_id = gun_id;
            gwui.teamId = 0;
            gwui.isLocked = false;
            gwui.level = 1;
            gwui.UpdateData();
            Check_NewGun(data, gwui);
            if (data != null)
            {
                data.NumberCore += gwui.getCoreNumber();
            }
            return gwui;
        }





        public bool Add_Get_Gun_Equip_Battle(dynamic jsonobj, MissionInfo.Data data)
        {
            JsonData jsonData = JsonMapper.ToObject(jsonobj.ToString());
            if (jsonobj.ToString().Contains("battle_get_prize"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "奖励获取 battle_get_prize ").userInfo();
                if (data.StopLoopByPrize) data.Loop = false;
            }
            if (jsonobj.ToString().Contains("battle_get_equip"))
            {
                try
                {
                    JsonData jsonEquip = jsonData["battle_get_equip"];
                    Equip.Data equip = new Equip.Data(jsonEquip);
                    userData.equip_With_User_Info.listEquip.Add(equip);

                    if ((int)equip.info.rank == 5)
                    {
                        new Log().userInit(userData.GameAccount.GameAccountID, "获得5星装备 意不意外 惊不惊喜").userInfo();
                    }
                    if ((int)equip.info.rank == 5 && data.StopLoopByEquipRank5 == true)
                    {
                        data.Loop = false;
                    }
                }
                catch (Exception)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "添加掉落装备遇到错误").userInfo();
                    return false;
                }
            }
            if (jsonobj.ToString().Contains("battle_get_gun"))
            {
                try
                {
                    Gun_With_User_Info.Data gwui = new Gun_With_User_Info.Data();
                    gwui = initGun(Convert.ToInt32(jsonobj.battle_get_gun.gun_with_user_id), Convert.ToInt32(jsonobj.battle_get_gun.gun_id), data);
                    userData.gun_With_User_Info.dicGunAdd(gwui);
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "添加人形掉落遇到错误 Error", e.ToString()).userInfo();

                    return false;
                }
            }

            if (jsonData["gun_id"].IsString && jsonData["gun_with_user_id"].IsString)
            {
                try
                {
                    Gun_With_User_Info.Data gwui = new Gun_With_User_Info.Data();
                    gwui = initGun(jsonData["gun_with_user_id"].Int, jsonData["gun_id"].Int, data);
                    userData.gun_With_User_Info.dicGunAdd(gwui);
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "添加人形掉落遇到错误 Error", e.ToString()).userInfo();

                    return false;
                }
            }

            if (jsonobj.ToString().Contains("reward_gun"))
            {
                try
                {
                    Gun_With_User_Info.Data gwui = new Gun_With_User_Info.Data();
                    gwui = initGun(Convert.ToInt32(jsonobj.mission_win_result.reward_gun.gun_with_user_id), Convert.ToInt32(jsonobj.mission_win_result.reward_gun.gun_id), data);
                    int i = 0;
                    while (true)
                    {
                        if (!userData.gun_With_User_Info.dicGun.ContainsKey(i))
                        {
                            userData.gun_With_User_Info.dicGun.Add(i, gwui);
                            break;
                        }
                        i++;
                    }
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "添加人形掉落遇到错误 Error", e.ToString()).userInfo();
                    return false;
                }
            }




            return true;
        }

        public bool Add_Get_Gun_Equip_Battle(int gun_equip_id, string result)
        {
            //battle_get_equip
            if (result.Contains("gun"))
            {
                var jsonobj = DynamicJson.Parse(result);
                int gun_with_user_id = int.Parse(jsonobj.gun_with_user_id.ToString());
                try
                {
                    Gun_With_User_Info.Data gwui = new Gun_With_User_Info.Data();
                    gwui = initGun(gun_with_user_id, Convert.ToInt32(jsonobj.gun.gun_id));
                    int i = 0;
                    while (true)
                    {
                        if (!userData.gun_With_User_Info.dicGun.ContainsKey(i))
                        {
                            userData.gun_With_User_Info.dicGun.Add(i, gwui);
                            break;
                        }
                        i++;
                    }
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "添加人形掉落遇到错误 Error", e.ToString()).userInfo();
                    return false;
                }
            }


            return true;
        }

        public void intelligencePoint(int misssionID)
        {

            Thread.Sleep(1000);
            dynamic newjson = new DynamicJson();
            newjson.mission_id /*这是节点*/ = misssionID;

            int count = 0;
            //发送请求
            while (true)
            {
                string result = userData.Net.Battle.intelligencePoint(userData.GameAccount, newjson.ToString());

                switch (int.Parse(result))
                {

                    case 1:
                        {

                            return;
                        }
                    default:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "intelligencePoint Error", result).userInfo();
                                return;
                            }
                            break;
                        }

                }

            }



        }

        public void Check_NewGun(MissionInfo.Data data, Gun_With_User_Info.Data gwui)
        {
            bool Locked = false;
            if (data != null)
            {
                if (!userData.user_Info.gun_collect.Contains(gwui.gun_id))
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, string.Format("获取新人形 : {0} ,意不意外 惊不惊喜", gwui.info.en_name)).userInfo();
                    userData.home.changeLock(new List<int>(gwui.id), new List<int>());
                    Locked = true;
                }

                if (data.StopLoopByStart3 && gwui.info.rank == 3)
                {
                    if (Locked == false)
                    {
                        userData.home.changeLock(new List<int>(gwui.id), new List<int>());
                        Locked = true;
                    }

                    data.Loop = false;
                }

                if (data.StopLoopByStart4 && gwui.info.rank == 4)
                {
                    if (Locked == false)
                    {
                        userData.home.changeLock(new List<int>(gwui.id), new List<int>());
                        Locked = true;
                    }
                    data.Loop = false;

                }
                if (data.StopLoopByStart5 && gwui.info.rank == 5)
                {
                    if (Locked == false)
                    {
                        userData.home.changeLock(new List<int>(gwui.id), new List<int>());
                        Locked = true;
                    }
                    data.Loop = false;
                }
            }
        }

        public void Battle_Result_PRO(ref MissionInfo.Data data, int teamLoc, ref string result, int gun_id = 0)
        {
            if (result.Contains("error")) return;
            if (data.needlog) new Log().systemInit(result).coreInfo();
            data.BattleTimes++;


            var jsonobj = Codeplex.Data.DynamicJson.Parse(result);
            userData.user_Info.experience += Convert.ToInt16(jsonobj.user_exp);
            data.user_exp = userData.user_Info.experience;


            //装备

            if (result.Contains("free_exp"))
            {
                userData.item_With_User_Info.globalFreeExp += Convert.ToInt16(jsonobj.free_exp);
            }


            Add_Get_Gun_Equip_Battle(jsonobj, data);
            //人形经验
            int numE = 0;
            userData.gun_With_User_Info.UpdateGun_Exp(jsonobj, ref numE);



            userData.others.BattleFinish_ammo_mrc(data.Teams[teamLoc].TeamID);
        }

        public void Check_Equip_Gun_FULL()
        {
            userData.webData.StatusBarText = "检查装备仓库人形床位是否满额";


            if (userData.others.Check_Equip_GUN_FULL())
            {
                if (userData.gun_With_User_Info.dicGun.Count + SystemOthers.ConfigData.UpdateCache >= userData.user_Info.maxgun)
                {
                    if (userData.config.M == true)
                    {
                        //解锁
                        userData.Factory.UnlockGun();
                        //全拆
                        userData.Factory.Gun_retire(2);
                        userData.Factory.Gun_retire(3);
                        userData.Factory.Gun_retire(4);
                        return;
                    }



                    if (userData.MissionInfo.GetFirstData().AutoStrengthen)
                    {
                        userData.Factory.EatGunHandle();
                        if (userData.others.Check_Equip_GUN_FULL())
                        {
                            userData.Factory.Gun_retire(2);
                            userData.Factory.Gun_retire(3);

                        }
                        return;
                    }
                    if (!userData.MissionInfo.GetFirstData().AutoStrengthen)
                    {
                        userData.Factory.Gun_retire(2);
                        userData.Factory.Gun_retire(3);
                    }


                }
                if (userData.equip_With_User_Info.listEquip.Count + SystemOthers.ConfigData.UpdateCache >= userData.user_Info.maxequip)
                {
                    if (userData.MissionInfo.GetFirstData().AutoStrengthen)
                    {
                        userData.Factory.Eat_EquipHandle(userData.MissionInfo.GetFirstData());
                        if (userData.others.Check_Equip_GUN_FULL())
                        {
                            userData.Factory.Equip_retire();
                        }
                        return;
                    }
                    if (!userData.MissionInfo.GetFirstData().AutoStrengthen)
                    {
                        userData.Factory.Equip_retire();
                    }
                }


            }
        }

        public bool buildingSkillPerform(mapbase.BuildIng buildIng)
        {
            ThreadDelay(5);

            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();

            jsonWriter.WritePropertyName("trigger_type");
            jsonWriter.Write(buildIng.trigger_type);
            jsonWriter.WritePropertyName("trigger_person_spot");
            jsonWriter.Write(buildIng.trigger_person_spot);
            jsonWriter.WritePropertyName("building_spot_id");
            jsonWriter.Write(buildIng.building_spot_id);

            jsonWriter.WritePropertyName("active_mission_skills");
            jsonWriter.WriteArrayStart();
            foreach (var item in buildIng.active_mission_skills)
            {
                jsonWriter.Write(item);
            }
            jsonWriter.WriteArrayEnd();
            jsonWriter.WriteObjectEnd();


            int count = 0;
            //发送请求
            while (true)
            {
                string result = userData.Net.Battle.buildingSkillPerform(userData.GameAccount, stringBuilder.ToString());

                switch (userData.Response.Check( ref result, "buildingSkillPerform", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "teamMove Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }







        }






        //{"team_id":1,"gun_with_user_id":1303783,"location":1}
        public bool BuildTeam(int TeamID,int GunID,int Loc)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter jsondata = new JsonWriter(sb);
            jsondata.WriteObjectStart();

            jsondata.WritePropertyName("team_id");
            jsondata.Write(TeamID);

            jsondata.WritePropertyName("gun_with_user_id");
            jsondata.Write(GunID);
            jsondata.WritePropertyName("location");
            jsondata.Write(Loc);
            jsondata.WriteObjectEnd();

            int count = 0;

            while (true)
            {
                string result = userData.Net.Battle.BuildTeam(userData.GameAccount,sb.ToString());
                switch (userData.Response.Check( ref result, "BuildTeam", false))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            return false;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "BuildTeam Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }


            }
        }



















        public void BP_Recover()
        {
            if (userData.user_Info.bp >= 6)
            {
                return;
            }
            if ((userData.user_Info.last_bp_recover_time + 7200 + 600) < (Helper.Decrypt.getDateTime_China_Int(DateTime.Now)))//600是延迟10分钟
            {
                //如果上次恢复时间到现在当前时间差距大于两个小时 则 发送请求 
                GetRecoverBP();
                userData.webData.StatusBarText = "空闲";
                userData.user_Info.last_bp_recover_time = Helper.Decrypt.getDateTime_China_Int(DateTime.Now);
            }

        }

        public bool GetRecoverBP()
        {
            userData.webData.StatusBarText = "动能点数恢复";

            int count = 0;
            while (true)
            {
                ThreadDelay(5);
                string result = userData.Net.Battle.GetRecoverBP(userData.GameAccount);

                switch (userData.Response.Check( ref result, "Get_RecoverBP_Pro", true))
                {
                    case 1:
                        {

                            var jsonobj = DynamicJson.Parse(result);
                            userData.user_Info.bp += Convert.ToInt32(jsonobj.recover_bp);
                            userData.user_Info.last_bp_recover_time = Convert.ToInt32(jsonobj.last_bp_recover_time);
                            return true;
                        }
                    case 0:
                        {
                            if (count++ >= userData.config.ErrorCount) { return false; }
                            break;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount) { return false; }
                            break;
                        }
                    default:
                        break;
                }

            }
        }

    }
}

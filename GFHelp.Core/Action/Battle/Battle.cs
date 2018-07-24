using Codeplex.Data;
using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GFHelp.Core.Action
{
    public class Battle
    {
        private UserData userData;
        public void SetUserData(UserData userData)
        {
           this.userData = userData;
        }


        public void Abort_Mission_login()
        {
            if (userData.others.Mission_S)
            {
                abortMission();
            }
            
        }

        public bool abortMission()
        {
            userData.webData.StatusBarText = (" 终止作战");

            int count = 0;
            while (true)
            {
                string result = API.Battle.abortMission(userData.GameAccount);
                Thread.Sleep(1000);

                switch (Response.Check(userData.GameAccount,ref result, "Abort_Mission_Pro", true))
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

                            if (count++ >= userData.config.ErrorCount) { return false; }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }

        public bool startMission(int mission_id, Spots[] spots)
        {
            userData.webData.StatusBarText = "回合开始";

            Thread.Sleep(3000);
            int count = 0;
            dynamic newjson = new DynamicJson();
            newjson.mission_id /*这是节点*/ = mission_id;/* 这是值*/
            newjson.spots = spots;

            newjson.ally_id = Decrypt.ConvertDateTime_China_Int(DateTime.Now);
            while (true)
            {
                string result =API.Battle.startMission(userData.GameAccount,newjson.ToString());

                switch (Response.Check(userData.GameAccount, ref result, "Start_Mission_Pro", true))
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
                            if(count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, String.Format("{0} 无法开始作战任务，请登陆游戏检查", userData.user_Info.name)).userInfo();
                                userData.normal_MissionInfo.Using = false;
                                return false;
                            }
                            Home.Login(userData);
                            userData.others.Check_Equip_GUN_FULL();
                            continue;
                        }
                    default:
                        break;
                }
            }
        }

        public bool reinforceTeam(Spots spots, bool night = false)
        {
            userData.webData.StatusBarText = "部署梯队";

            Thread.Sleep(2000);
            int count = 0;
            dynamic newjson = new DynamicJson();
            newjson.spot_id /*这是节点*/ = spots.spot_id;/* 这是值*/
            newjson.team_id = spots.team_id;

            int k = 0;
            while (true)
            {
                string result =API.Battle.reinforceTeam(userData.GameAccount,newjson.ToString());

                if (night == false) k = Response.Check(userData.GameAccount, ref result, "GUN_OUTandIN_Team_PRO", false);
                if (night == true) k = Response.Check(userData.GameAccount, ref result, "night_reinforceTeam", true);

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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, String.Format("{0} 无法部署梯队，请登陆游戏检查", userData.user_Info.name), result).userInfo();
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
            Thread.Sleep(500);
            int count = 0;
            dynamic newjson = new DynamicJson();
            newjson.ally_instance_id /*这是节点*/ = ally_instance_id;/* 这是值*/
            newjson.ai_type = ai_type;

            while (true)
            {
                string result = API.Battle.allyTeamAi(userData.GameAccount,newjson.ToString());

                switch (Response.Check(userData.GameAccount, ref result, "GUN_OUTandIN_Team_PRO", false))
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "allyTeamAi Error", result).userInfo();

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
            Thread.Sleep(500);
            API.Battle.allyMySideMove(userData.GameAccount);
        }
        public void startOtherSideTurn()
        {
            userData.webData.StatusBarText = "startOtherSideTurn";
            Thread.Sleep(500);
            API.Battle.startOtherSideTurn(userData.GameAccount);
        }

        public void endOtherSideTurn()
        {
            userData.webData.StatusBarText = "endOtherSideTurn";
            Thread.Sleep(500);
            API.Battle.endOtherSideTurn(userData.GameAccount);
        }
        public bool teamMove(TeamMove teammove)
        {
            userData.webData.StatusBarText = "移动";
            //{"team_id":6,"from_spot_id":3033,"to_spot_id":3038,"move_type":1}
            Thread.Sleep(1000);
            dynamic newjson = new DynamicJson();
            newjson.team_id /*这是节点*/ = teammove.team_id;/* 这是值*/
            newjson.from_spot_id /*这是节点*/ = teammove.from_spot_id;/* 这是值*/
            newjson.to_spot_id /*这是节点*/ = teammove.to_spot_id;/* 这是值*/
            newjson.move_type /*这是节点*/ = teammove.move_type;/* 这是值*/

            int count = 0;
            //发送请求
            while (true)
            {
                string result = API.Battle.teamMove(userData.GameAccount,newjson.ToString());

                switch (Response.Check(userData.GameAccount,ref result, "Team_Move_Pro", true))
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "teamMove Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }
        }
        public int teamMove_Random(TeamMove teammove)
        {
            userData.webData.StatusBarText = "移动";
            //{"team_id":6,"from_spot_id":3033,"to_spot_id":3038,"move_type":1}
            Thread.Sleep(1000);
            dynamic newjson = new DynamicJson();
            newjson.team_id /*这是节点*/ = teammove.team_id;/* 这是值*/
            newjson.from_spot_id /*这是节点*/ = teammove.from_spot_id;/* 这是值*/
            newjson.to_spot_id /*这是节点*/ = teammove.to_spot_id;/* 这是值*/
            newjson.move_type /*这是节点*/ = teammove.move_type;/* 这是值*/

            int count = 0;
            //发送请求
            while (true)
            {
                string result = API.Battle.teamMove(userData.GameAccount, newjson.ToString());

                switch (Response.Check(userData.GameAccount, ref result, "Team_MoveRandom_Pro", true))
                {

                    case 1:
                        {
                            if (result.Contains("enemy_team_id")) return 1;
                            return 0;
                        }
                    case 0:
                        {
                            return -1;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "teamMove Error", result).userInfo();

                                return 0;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }
        }
        public bool Normal_battleFinish(string data, ref string result, bool errorSkip = false)
        {
            userData.webData.StatusBarText = "战斗结算";
            //WriteLog.Log(String.Format("data = {0}", data));
            Thread.Sleep(3000);
            int count = 0;

            while (true)
            {
                result = "";
                result =API.Battle.battleFinish(userData.GameAccount,data);

                switch (Response.Check(userData.GameAccount, ref result, "Battle_Finish_Pro", true))
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "Normal_battleFinish Error", result).userInfo();
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
            Thread.Sleep(2000);
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
                string result = API.Battle.FairyMissionSkill(userData.GameAccount,stringBuilder.ToString());

                switch (Response.Check(userData.GameAccount, ref result, "FairyMissionSkill", true))
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "FairyMissionSkill Error", result).userInfo();
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
            Thread.Sleep(2000);
            //{"spot_id":3033}
            var obj = new
            {
                spot_id = spot_id,
            };
            int count = 0;
            var jsonStringFromObj = DynamicJson.Serialize(obj);
            while (true)
            {
                string result = API.Battle.withdrawTeam(userData.GameAccount,jsonStringFromObj.ToString());

                switch (Response.Check(userData.GameAccount, ref result, "WithDraw_Team_Pro", true))
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "withdrawTeam Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }
        public string endTurn()
        {
            userData.webData.StatusBarText = "endTurn";
            Thread.Sleep(1000);
            int count = 0;

            while (true)
            {
                string result =API.Battle.endTurn(userData.GameAccount);

                switch (Response.Check(userData.GameAccount,ref result, "endTurn", true))
                {

                    case 1:
                        {
                            var jsonobj = DynamicJson.Parse(result);
                            userData.battle.Add_Get_Gun_Equip_Battle(jsonobj);
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "endTurn Error", result).userInfo();
                                return result;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }


        public bool startTurn()
        {
            userData.webData.StatusBarText = "startTurn";

            Thread.Sleep(1000);
            int count = 0;

            while (true)
            {
                string result = API.Battle.startTurn(userData.GameAccount);

                switch (Response.Check(userData.GameAccount,ref result, "startTurn", true))
                {
                    case 1:
                        {
                            var jsonobj = DynamicJson.Parse(result);
                            userData.battle.Add_Get_Gun_Equip_Battle(jsonobj);
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "startTurn Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }


            }
        }
        public bool Simulation_battleFinish(string data, ref string result)
        {
            Thread.Sleep(2000);
            int count = 0;
            while (true)
            {
                result = API.Battle.simulation_DATA(userData.GameAccount, data);

                switch (Response.Check(userData.GameAccount,ref result, "Simulation_DATA_Pro", true))
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "Simulation_battleFinish Error", result).userInfo();
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
                string result = API.Battle.endEnemyTurn(userData.GameAccount);
                Thread.Sleep(1000);

                switch (Response.Check(userData.GameAccount,ref result, "endEnemyTurn_PRO", true))
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "Simulation_battleFinish Error",result).userInfo();
                                return;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }

        }
        public bool SupplyTeam(int team_id, bool NoSupply = true)
        {
            if (NoSupply == false) return true;
            dynamic newjson = new DynamicJson();
            newjson.team_id /*这是节点*/ = team_id;/* 这是值*/
            int count = 0;
            while (true)
            {
                string result = API.Battle.SupplyTeam(userData.GameAccount,newjson.ToString());
                Thread.Sleep(1000);

                switch (Response.Check(userData.GameAccount,ref result, "GUN_OUTandIN_Team_PRO", false))
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "SupplyTeam Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }

            }
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
                string result = API.Battle.saveHostage(userData.GameAccount,stringBuilder.ToString());
                Thread.Sleep(1000);

                switch (Response.Check(userData.GameAccount,ref result, "saveHostage", true))
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "saveHostage Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
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
                string result = API.Battle.Girl_Fix(userData.GameAccount,sb.ToString());

                switch (Response.Check(userData.GameAccount, ref result, "GUN_OUTandIN_Team_PRO", false))
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
                                new Log().userInit(userData.GameAccount.Base.GameAccountID, "Fix_Gun Error", result).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }


            }
        }




        public bool Add_Get_Gun_Equip_Battle(dynamic jsonobj, int Want_gun_id = 0)
        {
            //battle_get_equip
            if (jsonobj.ToString().Contains("battle_get_equip") == true)
            {
                try
                {
                    Equip_With_User_Info ewui = new Equip_With_User_Info();
                    ewui.id = Convert.ToInt32(jsonobj.battle_get_equip.id);
                    ewui.user_id = Convert.ToInt32(jsonobj.battle_get_equip.user_id);
                    ewui.gun_with_user_id = Convert.ToInt32(jsonobj.battle_get_equip.gun_with_user_id);
                    ewui.equip_id = Convert.ToInt32(jsonobj.battle_get_equip.equip_id);
                    ewui.equip_exp = Convert.ToInt32(jsonobj.battle_get_equip.equip_exp);
                    ewui.equip_level = Convert.ToInt32(jsonobj.battle_get_equip.equip_level);
                    ewui.pow = Convert.ToInt32(jsonobj.battle_get_equip.pow);
                    ewui.hit = Convert.ToInt32(jsonobj.battle_get_equip.hit);
                    ewui.dodge = Convert.ToInt32(jsonobj.battle_get_equip.dodge);
                    ewui.speed = Convert.ToInt32(jsonobj.battle_get_equip.speed);
                    ewui.rate = Convert.ToInt32(jsonobj.battle_get_equip.rate);
                    ewui.critical_harm_rate = Convert.ToInt32(jsonobj.battle_get_equip.critical_harm_rate);
                    ewui.critical_percent = Convert.ToInt32(jsonobj.battle_get_equip.critical_percent);
                    ewui.armor_piercing = Convert.ToInt32(jsonobj.battle_get_equip.armor_piercing);
                    ewui.armor = Convert.ToInt32(jsonobj.battle_get_equip.armor);
                    ewui.shield = Convert.ToInt32(jsonobj.battle_get_equip.shield);
                    ewui.damage_amplify = Convert.ToInt32(jsonobj.battle_get_equip.damage_amplify);
                    ewui.damage_reduction = Convert.ToInt32(jsonobj.battle_get_equip.damage_reduction);
                    ewui.night_view_percent = Convert.ToInt32(jsonobj.battle_get_equip.night_view_percent);

                    ewui.bullet_number_up = Convert.ToInt32(jsonobj.battle_get_equip.bullet_number_up);
                    ewui.adjust_count = Convert.ToInt32(jsonobj.battle_get_equip.adjust_count);
                    ewui.is_locked = Convert.ToInt32(jsonobj.battle_get_equip.is_locked);
                    ewui.last_adjust = jsonobj.battle_get_equip.last_adjust.ToString();
                    int i = 0;
                    while (true)
                    {
                        if (!userData.equip_With_User_Info.dicEquip.ContainsKey(i))
                        {
                            userData.equip_With_User_Info.dicEquip.Add(i, ewui);
                            break;
                        }
                        i++;
                    }
                    if (CatachData.Check_equipRank5(ewui.equip_id))
                    {
                        new Log().userInit(userData.GameAccount.Base.GameAccountID, "获得5星装备 意不意外 惊不惊喜").userInfo();
                    }
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "添加掉落装备遇到错误").userInfo();
                    return false;
                }
            }

            if (jsonobj.ToString().Contains("battle_get_gun") == true)
            {
                try
                {
                    Gun_With_User_Info gwui = new Gun_With_User_Info();

                    gwui.id = Convert.ToInt32(jsonobj.battle_get_gun.gun_with_user_id);
                    gwui.gun_id = Convert.ToInt32(jsonobj.battle_get_gun.gun_id);
                    Check_NewGun(gwui.id, gwui.gun_id);
                    gwui.UpdateData();
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
                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "添加人形掉落遇到错误 Error", e.ToString()).userInfo();

                    return false;
                }
            }
            if (jsonobj.ToString().Contains("reward_gun") == true)
            {
                try
                {
                    Gun_With_User_Info gwui = new Gun_With_User_Info();

                    gwui.id = Convert.ToInt32(jsonobj.mission_win_result.reward_gun.gun_with_user_id);
                    gwui.gun_id = Convert.ToInt32(jsonobj.mission_win_result.reward_gun.gun_id);
                    Check_NewGun(gwui.id, gwui.gun_id);
                    gwui.UpdateData();
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
                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "添加人形掉落遇到错误 Error", e.ToString()).userInfo();
                    return false;
                }
            }
            return true;
        }

        public bool Add_Get_Gun_Equip_Battle(int gun_equip_id, string with_user_id)
        {
            //battle_get_equip
            if (with_user_id.Contains("gun"))
            {
                var jsonobj = DynamicJson.Parse(with_user_id);
                int gun_with_user_id = int.Parse(jsonobj.gun_with_user_id.ToString());
                try
                {
                    Gun_With_User_Info gwui = new Gun_With_User_Info();

                    gwui.id = gun_with_user_id;
                    gwui.gun_id = gun_equip_id;
                    Check_NewGun(gwui.id, gwui.gun_id);
                    gwui.UpdateData();
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
                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "添加人形掉落遇到错误 Error", e.ToString()).userInfo();
                    return false;
                }
            }
            if (with_user_id.Contains("equip"))
            {
                try
                {
                    var jsonobj = DynamicJson.Parse(with_user_id);
                    int equip_with_user_id = int.Parse(jsonobj.equip_with_user_id.ToString());
                    Equip_With_User_Info ewui = new Equip_With_User_Info();
                    ewui.id = gun_equip_id;
                    ewui.equip_id = equip_with_user_id;
                    int i = 0;
                    while (true)
                    {
                        if (!userData.equip_With_User_Info.dicEquip.ContainsKey(i))
                        {
                            userData.equip_With_User_Info.dicEquip.Add(i, ewui);
                            break;
                        }
                        i++;
                    }
                    if (CatachData.Check_equipRank5(ewui.equip_id))
                    {
                        new Log().userInit(userData.GameAccount.Base.GameAccountID, "获得5星装备 意不意外 惊不惊喜").userInfo();
                        if (userData.normal_MissionInfo.StopLoopinGetNew)
                        {
                            userData.normal_MissionInfo.Using = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "添加掉落装备遇到错误",e.ToString()).userInfo();
                    return false;
                }






            }

            return true;
        }


        public void Check_NewGun(int gun_with_user_id, int gun_id)
        {

            if (!userData.user_Info.gun_collect.Contains(gun_id))
            {
                new Log().userInit(userData.GameAccount.Base.GameAccountID, string.Format("获取新人形 : {0} ,意不意外 惊不惊喜", CatchData.Base.Asset_Textes.ChangeCodeFromeCSV(Function.FindGunName_GunId(gun_id)))).userInfo();
                if (userData.normal_MissionInfo.StopLoopinGetNew)
                {
                    userData.normal_MissionInfo.Using = false;
                }

                List<int> listLockid = new List<int>();
                listLockid.Add(gun_with_user_id);
                List<int> listUnLockid = new List<int>();
                userData.webData.StatusBarText = "LOCK";

                Thread.Sleep(2000);
                Home.changeLock(userData, listLockid, listUnLockid);

            }
            else
            {
                //WriteLog.Log(string.Format("获取人形 : {0}", Programe.TextRes.Asset_Textes.ChangeCodeFromeCSV(im.userdatasummery.FindGunName_GunId(gun_id))), "log");
            }


        }

        public void Battle_Result_PRO(ref Normal_MissionInfo ubti, int teamLoc, ref string result, int gun_id = 0)
        {

            var jsonobj = Codeplex.Data.DynamicJson.Parse(result);
            userData.user_Info.experience += Convert.ToInt16(jsonobj.user_exp);
            ubti.user_exp = userData.user_Info.experience;


            //装备

            if (result.Contains("free_exp"))
            {
                userData.others.GlobalFreeExp += Convert.ToInt16(jsonobj.free_exp);
            }


            Add_Get_Gun_Equip_Battle(jsonobj, gun_id);
            //人形经验
            int numE = 0;
            userData.gun_With_User_Info.UpdateGun_Exp(jsonobj, ref numE);



            userData.others.BattleFinish_ammo_mrc(ubti.Teams[teamLoc].TeamID);
        }

        public void Check_Equip_Gun_FULL()
        {
            userData.webData.StatusBarText= "检查床位是否满额";


            if (userData.others.Check_Equip_GUN_FULL())
            {
                if (userData.gun_With_User_Info.dicGun.Count + 5 >= userData.user_Info.maxgun)
                {
                    if (userData.config.AutoStrengthen)
                    {
                        Factory.EatGunHandle(userData);
                        if (userData.others.Check_Equip_GUN_FULL())
                        {
                            Factory.Gun_retire(userData, 2);
                            Factory.Gun_retire(userData, 3);

                        }
                        return;
                    }
                    if (!userData.config.AutoStrengthen)
                    {
                        Factory.Gun_retire(userData, 2);
                        Factory.Gun_retire(userData, 3);
                    }


                }
                if (userData.equip_With_User_Info.dicEquip.Count + 5 >= userData.user_Info.maxequip)
                {
                    if (userData.config.AutoStrengthen)
                    {
                        
                        Factory.Eat_Equip(userData);

                        if (userData.others.Check_Equip_GUN_FULL())
                        {
                            Factory.Equip_retire(userData);

                        }
                        return;
                    }
                    if (!userData.config.AutoStrengthen)
                    {
                        Factory.Equip_retire(userData);
                    }





                }


            }
        }







































        public static bool GetRecoverBP(UserData userData)
        {
            userData.webData.StatusBarText = "动能点数恢复";

            int count = 0;
            while (true)
            {
                string result =API.Battle.GetRecoverBP(userData.GameAccount);

                switch (Response.Check(userData.GameAccount,ref result, "Get_RecoverBP_Pro", true))
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

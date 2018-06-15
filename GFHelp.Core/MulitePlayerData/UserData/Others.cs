using Codeplex.Data;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GFHelp.Core.MulitePlayerData
{
    public class Others
    {
        private UserData userData;
        public void setUserData(UserData userData)
        {
            this.userData = userData;
        }
        public bool Mission_S;
        public bool ClickGrilsFavor;

        public void Read(dynamic jsonobj)
        {
            ClickGrilsFavor = true;
            Mission_S = false;
            try
            {
                string data = jsonobj.mission_act_info.ToString();
                if (data.Length > 10)
                {
                    Mission_S = true;
                }
            }
            catch (Exception)
            {
                return;
            }
        }


        public int GlobalFreeExp()
        {

            foreach (var item in userData.item_With_User_Info.dicItem)
            {
                if (item.Value.item_id == 507)
                {
                    return item.Value.number;
                }
            }
            return 0;
        }

        public void DeGolbalFreeExp(int count)
        {
            for (int k = 0; k < userData.item_With_User_Info.dicItem.Count; k++)
            {
                if (userData.item_With_User_Info.dicItem[k].item_id == 507)
                {
                    userData.item_With_User_Info.dicItem[k].number = userData.item_With_User_Info.dicItem[k].number - count;
                }
            }
        }

        public int Battery()
        {

            foreach (var item in userData.item_With_User_Info.dicItem)
            {
                if (item.Value.item_id == 506)
                {
                    return item.Value.number;
                }
            }
            return 0;
        }
        public void DeBattery(int count)
        {
            for (int k = 0; k < userData.item_With_User_Info.dicItem.Count; k++)
            {
                if (userData.item_With_User_Info.dicItem[k].item_id == 506)
                {
                    userData.item_With_User_Info.dicItem[k].number = userData.item_With_User_Info.dicItem[k].number - count;
                }
            }
        }

        public bool CheckGunStatus(Gun_With_User_Info gwui)
        {
            //是否在后勤 自律 训练
            foreach (var x in userData.operation_Act_Info.dicOperation)
            {
                if (x.Value.team_id == gwui.team_id)
                {
                    return true;
                }

            }
            if (userData.auto_Mission_Act_Info.team_ids.Contains(gwui.team_id)) return true;
            foreach (var y in userData.upgrade_Act_Info.dic_Upgrade)
            {
                if (y.Value.gun_with_user_id == gwui.id) return true;
            }
            return false;
        }

        public void Check_NewGun(int gun_with_user_id, int gun_id, int want_gun_id = 0)
        {
            WarningNote note;
            if (!userData.user_Info.gun_collect.Contains(gun_id))
            {
                if (want_gun_id != 0)
                {
                    if (gun_id == want_gun_id)
                    {
                        if (userData.config.NewGun_Report_Stop)
                        {
                            note = new WarningNote(1, string.Format("获取新人形 : {0} ,意不意外 惊不惊喜", CatchData.Base.Asset_Textes.ChangeCodeFromeCSV(Function.FindGunName_GunId(gun_id))));
                            userData.warningNotes.Add(note);
                        }
                    }
                }
                note = new WarningNote(1, string.Format("获取新人形 : {0} ,意不意外 惊不惊喜", CatchData.Base.Asset_Textes.ChangeCodeFromeCSV(Function.FindGunName_GunId(gun_id))));
                userData.warningNotes.Add(note);

                List<int> listLockid = new List<int>();
                listLockid.Add(gun_with_user_id);
                List<int> listUnLockid = new List<int>();
                userData.webData.StatusBarText = "LOCK";

                Thread.Sleep(2000);
                Action.Home.changeLock(userData,listLockid, listUnLockid);
                if (userData.config.NewGun_Report_Stop)
                {
                    note = new WarningNote(1, string.Format("获取新人形 : {0} ,意不意外 惊不惊喜", CatchData.Base.Asset_Textes.ChangeCodeFromeCSV(Function.FindGunName_GunId(gun_id))));
                    userData.warningNotes.Add(note);
                }
            }
            else
            {
                //WriteLog.Log(string.Format("获取人形 : {0}", Programe.TextRes.Asset_Textes.ChangeCodeFromeCSV(im.userdatasummery.FindGunName_GunId(gun_id))), "log");
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
                        WarningNote note = new WarningNote(-1, "获得5星装备 意不意外 惊不惊喜");
                        userData.warningNotes.Add(note);
                    }
                }
                catch (Exception e)
                {
                    WarningNote note = new WarningNote(-1, "添加掉落装备遇到错误");
                    userData.warningNotes.Add(note);
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
                    WarningNote note = new WarningNote(-1, "添加人形掉落遇到错误");
                    userData.warningNotes.Add(note);
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
                    WarningNote note = new WarningNote(-1, "添加人形掉落遇到错误");
                    userData.warningNotes.Add(note);
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
                    WarningNote note = new WarningNote(-1, "添加人形掉落遇到错误");
                    userData.warningNotes.Add(note);
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
                        WarningNote note = new WarningNote(-1, "获得5星装备 意不意外 惊不惊喜");
                        userData.warningNotes.Add(note);
                    }
                }
                catch (Exception e)
                {
                    WarningNote note = new WarningNote(-1, "添加掉落装备遇到错误");
                    userData.warningNotes.Add(note);
                    return false;
                }






            }

            return true;
        }

        public bool CheckTeamLeval(int teamid, int lv)
        {
            foreach (var item in userData.Teams[teamid])
            {
                if (item.Value.level < lv)
                {
                    return false;
                }
            }
            return true;
        }












    }

}

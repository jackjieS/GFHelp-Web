﻿using GFHelp.Core.CatchData.Base;
using GFHelp.Core.Management;
using LitJson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFHelp.Core.MulitePlayerData.WebData
{
    public class WebData
    {
        public string StatusBarText;
        public Dictionary<int, Dictionary<int, Gun>> WebTeams = new Dictionary<int, Dictionary<int, Gun>>();
        public WebUser_Info webUser_Info = new WebUser_Info();
        public Dictionary<int, WebOperation> webOperation = new Dictionary<int, WebOperation>();


        public void Get(UserData userData)
        {
            Initialize.GetWebTeam(userData, ref WebTeams);
            Initialize.GetWebUser_Info(userData, ref webUser_Info);
            Initialize.GetWebOperation(userData,ref webOperation);
        }
    }
    public class Initialize
    {
        public static void GetWebTeam(UserData userData, ref Dictionary<int, Dictionary<int, Gun>> Teams)
        {
            Teams.Clear();
            foreach (var team in userData.Teams)
            {
                Dictionary<int, Gun> Team = new Dictionary<int, Gun>();
                foreach (var k in team.Value)
                {
                    Gun gun = new Gun(k.Value);
                    Team.Add(k.Key, gun);
                }
                Teams.Add(team.Key, Team);
            }
        }
        public static void GetWebUser_Info(UserData ud,ref WebUser_Info ui)
        {
            ui.UserName = ud.user_Info.name;
            ui.Level = ud.user_Info.lv.ToString();
            ui.ammo = ud.user_Info.ammo.ToString();
            ui.mre = ud.user_Info.mre.ToString();
            ui.part = ud.user_Info.part.ToString();
            ui.mp = ud.user_Info.mp.ToString();
            ui.IOP_Contract = getItemNumFromID(ud, 0);
            ui.Quick_Develop = getItemNumFromID(ud, 3);
            ui.Quick_Reinforce = getItemNumFromID(ud, 4);
            ui.Quick_Training = getItemNumFromID(ud, 8);
            ui.EQUIP_Contract = getItemNumFromID(ud, 2);
            ui.max_build_slot = ud.user_Info.max_build_slot.ToString();
            ui.max_fix_slot = ud.user_Info.max_fix_slot.ToString();
            ui.GunNum = ud.gun_With_User_Info.dicGun.Count.ToString();
            ui.maxgun = ud.user_Info.maxgun.ToString();
            ui.maxteam = ud.user_Info.maxteam.ToString();
            ui.UnlockRatio = ((int)((double)ud.user_Info.gun_collect.Count / (double)CatachData.listGunInfo.Count * 100)).ToString() + "%";
            ui.KalinaLevel = ud.kalina_with_user_info.level.ToString();
            ui.KalinaFavor = ud.kalina_with_user_info.favor.ToString();

            ui.EquipNum = ud.equip_With_User_Info.dicEquip.Count.ToString();
            ui.FriendNum = ud.friend_with_user_info.dicFriend.Count.ToString();
            ui.Coin1 = ud.user_Info.coin1.ToString();
            ui.Coin2 = ud.user_Info.coin2.ToString();
            ui.Coin3 = ud.user_Info.coin3.ToString();
            ui.GemNum = ud.user_Info.gem.ToString();
            ui.BatteryNum = getItemNumFromID(ud, 506);
            ui.GlobalEXP = getItemNumFromID(ud, 507);
            ui.BPnum = ud.user_Info.bp.ToString();
            ui.BP_PayNUM = ud.user_Info.bp_pay.ToString();
            ui.FurnitureCoinNum = getItemNumFromID(ud, 41);
            ui.ExchangeCoinNum = getItemNumFromID(ud, 42);
            ui.Core = ud.user_Info.core.ToString();
        }
        public static void GetWebOperation(UserData ud, ref Dictionary<int, WebOperation> dic)
        {
            dic.Clear();
            foreach (var item in ud.operation_Act_Info.dicOperation)
            {
                WebOperation webOperation = new WebOperation();
                webOperation.key = item.Value.key.ToString();
                webOperation.id = item.Value.id.ToString();
                webOperation.operation_id = item.Value.operation_id.ToString();
                webOperation.user_id = item.Value.user_id.ToString();
                webOperation.team_id = item.Value.team_id.ToString();
                webOperation.start_time = item.Value.start_time.ToString();
                webOperation.remaining_time = item.Value.remaining_time.ToString();
                dic.Add(item.Key, webOperation);
            }
        }



        private static string getItemNumFromID(UserData userData,int id)
        {
            foreach (var item in userData.item_With_User_Info.dicItem)
            {
                if (item.Value.item_id == id)
                    return item.Value.number.ToString();
            }
            return "Null";
        } 
    }


    public class Gun
    {
        public Gun(Gun_With_User_Info gun_With_User_Info)
        {
            this.TeamID = gun_With_User_Info.teamId;
            this.Name = Asset_Textes.ChangeCodeFromeCSV(Function.FindGunName_GunId(gun_With_User_Info.gun_id)); 
            this.Lv = gun_With_User_Info.level;
            this.Exp = gun_With_User_Info.gun_exp;
            this.Hp = gun_With_User_Info.life;
            this.number = gun_With_User_Info.number;
        }
        public int TeamID;//梯队ID
        public string Name; //人形名字
        public int Lv;//等级
        public int Exp;//经验
        public int Hp;//血
        public int number;//扩编数量
    }

    public class WebUser_Info
    {
        public string UserName;//指挥官名字
        public string Level;//等级

        public string ammo;//弹药
        public string mre;//口粮
        public string mp;//人力
        public string part;//零件
        public string IOP_Contract;//1 人形建造契约
        public string Quick_Develop;//3 快速建造契约
        public string Quick_Reinforce;//4 快速修复契约
        public string Quick_Training;//8 快速训练契约
        public string EQUIP_Contract;//2 装备建造契约
        public string max_build_slot;//最大建造槽数量
        public string max_fix_slot;//最大维修槽数量
        public string GunNum;//拥有人形数量
        public string maxgun;// 床位数
        public string maxteam;//最大梯队数量
        public string UnlockRatio;//图鉴解锁率
        public string KalinaLevel;//kalina 等级
        public string KalinaFavor;//kalina 好感度
        public string EquipNum;//装备数量
        public string FriendNum;//好友数量
        public string Coin1;//初级资料
        public string Coin2;//中级资料
        public string Coin3;//高级资料
        public string GemNum;//钻石
        public string BatteryNum;//电池
        public string GlobalEXP;//全局经验
        public string BPnum;//基础动能
        public string BP_PayNUM;//超导动能
        public string FurnitureCoinNum;//采购币
        public string ExchangeCoinNum;//兑换卷
        public string Core;//核心
    }

    public class WebOperation
    {
        public string key;//后勤Key 不用显示
        public string id;//后期 id 不用显示
        public string operation_id;//后勤任务ID
        public string user_id;//游戏角色ID 不用显示
        public string team_id;//后勤梯队
        public string start_time;//后期开始时间 不用显示
        public string remaining_time;//后期剩余时间
    }

    public class WebStatus
    {
        public string AccountId;//游戏帐户ID
        public string statusBarText;//状态
    }


}

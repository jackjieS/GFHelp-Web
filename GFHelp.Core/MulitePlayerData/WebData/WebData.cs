using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.CatchData.Base;
using GFHelp.Core.Management;
using LitJson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Text;


namespace GFHelp.Core.MulitePlayerData.WebData
{
    public class WebData
    {
        public WebData(UserData UserData)
        {
            this.UserData = UserData;
        }

        private UserData UserData;

        public void GetWebTeams(ref List<Team> Teams)
        {
            Teams.Clear();
            foreach (var team in UserData.Teams)
            {
                int teamID = 0;
                string Leader = "";
                List<Gun> guns = new List<Gun>();
                foreach (var k in team.Value)
                {
                    if (k.Value.location == 1)
                    {
                        Leader = k.Value.info.en_name;
                        teamID = k.Value.teamId;
                    }
                    Gun gun = new Gun(k.Value);
                    guns.Add(gun);
                }
                Team Tteam = new Team(teamID, Leader, guns);
                Tteam.isFree = UserData.others.CheckTeamStatus(teamID);
                Teams.Add(Tteam);
            }
        }
        public void GetWebSquads(ref List<Squad> squads)
        {
            squads.Clear();
            foreach (var squad in UserData.squad_With_User_Info.listSquad)
            {
                Squad s = new Squad(squad);
                squads.Add(s);
            }
        }
        public void GetWebUser_Info(ref WebUser_Info ui)
        {
            ui.UserName = UserData.user_Info.name;
            ui.Level = UserData.user_Info.lv.ToString();
            ui.ammo = UserData.user_Info.ammo.ToString();
            ui.mre = UserData.user_Info.mre.ToString();
            ui.part = UserData.user_Info.part.ToString();
            ui.mp = UserData.user_Info.mp.ToString();
            ui.IOP_Contract = getItemNumFromID(0);
            ui.Quick_Develop = getItemNumFromID(3);
            ui.Quick_Reinforce = getItemNumFromID(4);
            ui.Quick_Training = getItemNumFromID(8);
            ui.EQUIP_Contract = getItemNumFromID(2);
            ui.max_build_slot = UserData.user_Info.max_build_slot.ToString();
            ui.max_fix_slot = UserData.user_Info.max_fix_slot.ToString();
            ui.GunNum = UserData.gun_With_User_Info.dicGun.Count.ToString();
            ui.maxgun = UserData.user_Info.maxgun.ToString();
            ui.maxteam = UserData.user_Info.maxteam.ToString();
            ui.UnlockRatio = ((int)((double)UserData.user_Info.gun_collect.Count / (double)GameData.listGunInfo.Count * 100)).ToString() + "%";
            ui.KalinaLevel = UserData.kalina_with_user_info.level.ToString();
            ui.KalinaFavor = UserData.kalina_with_user_info.favor.ToString();

            ui.EquipNum = UserData.equip_With_User_Info.listEquip.Count.ToString();
            ui.FriendNum = UserData.friend_with_user_info.dicFriend.Count.ToString();
            ui.Coin1 = UserData.user_Info.coin1.ToString();
            ui.Coin2 = UserData.user_Info.coin2.ToString();
            ui.Coin3 = UserData.user_Info.coin3.ToString();
            ui.GemNum = UserData.user_Info.gem.ToString();
            ui.BatteryNum = UserData.item_With_User_Info.Battery.ToString();

            ui.GlobalEXP = UserData.item_With_User_Info.globalFreeExp > 0 ? UserData.item_With_User_Info.globalFreeExp.ToString() : 0.ToString();
            ui.TimeOfReport = UserData.outhouse_Establish_Info.time > 0 ? UserData.outhouse_Establish_Info.time.ToString() : 0.ToString();
            ui.BPnum = UserData.user_Info.bp.ToString();
            ui.BP_PayNUM = UserData.user_Info.bp_pay.ToString();
            ui.FurnitureCoinNum = getItemNumFromID(41);
            ui.ExchangeCoinNum = getItemNumFromID(42);
            ui.Core = UserData.user_Info.core.ToString();


            ui.OrginalDataNum = UserData.item_With_User_Info.originalData > 0 ? UserData.item_With_User_Info.originalData.ToString() : 0.ToString();
            ui.PureDataNum = UserData.item_With_User_Info.PureData > 0 ? UserData.item_With_User_Info.PureData.ToString() : 0.ToString();

            ui.ChipNum = UserData.chip_With_User_Info.listSquadChip.Count.ToString();
            ui.ChipRank5Num = UserData.chip_With_User_Info.listSquadChipRank5.Count.ToString();
            ui.ChipMaxNum = UserData.outhouse_Establish_Info.ChipsWhareHouse.ToString();
        }
        public void GetWebOperation(ref List<WebOperation> dic)
        {
            dic.Clear();
            foreach (var item in UserData.operation_Act_Info.dicOperation)
            {
                WebOperation webOperation = new WebOperation();
                webOperation.Using = item.Value.Using;
                webOperation.key = item.Value.key.ToString();
                webOperation.id = item.Value.id.ToString();
                webOperation.operation_id = item.Value.operation_id.ToString();
                webOperation.user_id = item.Value.user_id.ToString();
                webOperation.team_id = item.Value.team_id.ToString();
                webOperation.start_time = item.Value.start_time.ToString();
                webOperation.remaining_time = item.Value.remaining_time > 0 ? item.Value.remaining_time.ToString() : 0.ToString();
                dic.Add(webOperation);
            }

        }
        public void GetWebStatus(ref WebStatus webStatus)
        {
            webStatus.AccountId = UserData.GameAccount.GameAccountID;
            webStatus.Name = UserData.GameAccount.ChannelID + " - " + UserData.GameAccount.GameAccountID + " - " + UserData.user_Info.name;
            webStatus.statusBarText = UserData.webData.StatusBarText;
        }
        private string getItemNumFromID(int id)
        {
            foreach (var item in UserData.item_With_User_Info.dicItem)
            {
                if (item.Value.item_id == id)
                    return item.Value.number.ToString();
            }
            return "Null";
        }
        public void GetWebMissionInfo(ref List<WebMissionInfo> list)
        {
            list.Clear();
            foreach (var item in UserData.MissionInfo.listTask)
            {
                WebMissionInfo webMissionInfo = new WebMissionInfo(item);
                list.Add(webMissionInfo);
            }
        }
        public void GetWebEquip_Build(ref List<WebEquip_Build> dic)
        {
            dic.Clear();
            foreach (var item in UserData.equip_Built.Built_Slot)
            {
                WebEquip_Build webEquip_Build = new WebEquip_Build(item.Value);
                dic.Add(webEquip_Build);
            }

        }
        public void GetWebDoll_Build(ref List<WebDoll_Build> dic)
        {
            dic.Clear();
            foreach (var item in UserData.doll_Build.Built_Slot)
            {
                WebDoll_Build webEquip_Build = new WebDoll_Build(item.Value);
                dic.Add(webEquip_Build);
            }

        }




        public string StatusBarText;
        public List<Team> WebTeams = new List<Team>();
        public List<Squad> WebSquads = new List<Squad>();
        public WebUser_Info webUser_Info = new WebUser_Info();
        public List<WebOperation> webOperation = new List<WebOperation>();
        public List<WebEquip_Build> webEquip_Build = new List<WebEquip_Build>();
        public List<WebDoll_Build> webDoll_Builds = new List<WebDoll_Build>();
        public WebStatus webStatus = new WebStatus();
        public List<WebMissionInfo>  webMissionInfo = new List<WebMissionInfo>();
        public void Get()
        {
            GetWebTeams(ref WebTeams);
            GetWebUser_Info(ref webUser_Info);
            GetWebOperation(ref webOperation);
            GetWebStatus(ref webStatus);
            GetWebMissionInfo(ref webMissionInfo);
            GetWebSquads(ref WebSquads);
            GetWebEquip_Build(ref webEquip_Build);
            GetWebDoll_Build(ref webDoll_Builds);
        }
    }

    public class Team
    {
        public Team(int teamid,string leader,List<Gun> guns)
        {
            this.TeamID = teamid;
            this.Leader = leader;
            this.Guns = guns;
        }
        public int TeamID;
        public string Leader;
        public List<Gun> Guns;
        public bool isFree;
    }

    public class Gun
    {

        public Gun(Gun_With_User_Info gun_With_User_Info)
        {
            this.TeamID = gun_With_User_Info.teamId;
            //this.Name = Asset_Textes.ChangeCodeFromeCSV(Function.FindGunName_GunId(gun_With_User_Info.gun_id));
            this.Name = gun_With_User_Info.info.en_name;


            //this.Name = padRightEx(this.Name, 20);


            this.Lv = gun_With_User_Info.level;
            this.Exp = gun_With_User_Info.experience;
            this.Hp = gun_With_User_Info.life;
            this.number = gun_With_User_Info.number;
            this.Loc = gun_With_User_Info.location;
            //this.Text = String.Format("{0}  {1,-10}   {2,-8}   {3,-20}   {4,-10}", Name, "Hp:" + Hp, "Lv:" + Lv, "Exp:" + Exp, number + "扩编");


        }
        public int TeamID;//梯队ID
        public string Name; //人形名字
        public int Lv;//等级
        public int Exp;//经验
        public int Hp;//血
        public int number;//扩编数量
        public int Loc;
        //public string Text;
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
        public string TimeOfReport;
        public string ChipNum;
        public string ChipMaxNum;
        public string ChipRank5Num;
        public string OrginalDataNum;
        public string PureDataNum;
    }

    public class WebOperation
    {

        public bool Using;//开关
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
        public string Name;//游戏角色名称
        public string statusBarText;//状态
    }
    public class WebMissionInfo
    {
        public WebMissionInfo(MissionInfo.Data data)
        {

            foreach (var item in data.Teams)
            {
                this.Teams += string.Format("梯队 {0} ", item.TeamID.ToString());
            }



            this.MissionMap = data.MissionMap;
            this.CycleTime = data.CycleTime.ToString();
            this.BattleTimes = data.BattleTimes.ToString();
            this.Parm = data.Parm;
            this.Core = data.NumberCore.ToString();
        }
        public string Teams;
        public string MissionMap;//地图
        public string CycleTime;//已执行次数
        public string BattleTimes;//战斗场次
        public string Parm;//参数
        public string Core;
    }
    public class Squad
    {
        public Squad(Squad_With_User_Info.Data squad)
        {
            this.Name = Asset_Textes.ChangeCodeFromeCSV(squad.info.en_name);
            this.Type = Asset_Textes.ChangeCodeFromeCSV(squad.info.typeInfo.en_name);
            this.Lv = squad.level.ToString();
            this.Exp = squad.exp.ToString();
            this.Rank = squad.rank.ToString();
        }
        public string Name;
        public string Type;
        public string Lv;
        public string Exp;
        public string Rank;
    }
    public class WebEquip_Build
    {
        public WebEquip_Build(Equip_Build.Data data)
        {
            this.Build_Slot = data.build_slot.ToString();
            if (data.durationTime < 0)
            {
                this.remaining_time = "0";
            }
            else
            {
                this.remaining_time = data.durationTime.ToString();
            }

        }
        public string Build_Slot;//后勤Key 不用显示
        public string remaining_time;//后期剩余时间
    }

    public class WebDoll_Build
    {
        public WebDoll_Build(Doll_Build.Data data)
        {
            this.Build_Slot = data.build_slot.ToString();
            if (data.durationTime < 0)
            {
                this.remaining_time = "0";
            }
            else
            {
                this.remaining_time = data.durationTime.ToString();
            }

        }
        public string Build_Slot;//后勤Key 不用显示
        public string remaining_time;//后期剩余时间
    }

}


using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFHelp.Core.Action.BattleBase
{
    public class Spot
    {
        public void Add(int spot_id, int key)
        {
            Data data = new Data();
            data.spot_id = spot_id;
            data.team_loc = key;
            dic.Add(dic.Count,data);
        }


        public Dictionary<int, Data> dic = new Dictionary<int, Data>();
        public class Data
        {
            public int spot_id;
            public int team_id;
            public int team_loc;
        }



    }

    public class user_rec
    {
        public int seed;
        public List<record> listRecord = new List<record>();
    }

    public class record
    {
        public int fixedFrameId { set; get; }
        public int gunId { set; get; }
        public int type { set; get; }
        public int targetPosId { set; get; }
        public bool autoSkillSwitch { set; get; }
        public record(int fixedFrameId, int gunId, int type, int targetPosId, bool autoSkillSwitch)
        {
            this.fixedFrameId = fixedFrameId;
            this.gunId = gunId;
            this.type = type;
            this.targetPosId = targetPosId;
            this.autoSkillSwitch = autoSkillSwitch;

        }
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}", new object[]
            {
            this.fixedFrameId,
            this.gunId,
            (int)this.type,
            this.targetPosId,
            this.autoSkillSwitch
            });
        }
    }


    public class battle_info
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enemy_effect_client">enemy_effect_client</param>
        /// <param name="true_time">true_time</param>
        /// <param name="life_enemy">life_enemy</param>
        /// <param name="client_time">client_time</param>
        public void data_set(int enemy_effect_client, int true_time, int life_enemy, int client_time, int damage_team_no_miss = 0)
        {
            this.enemy_effect_client = enemy_effect_client;
            this.true_time = true_time;
            this.life_enemy = life_enemy;
            this.client_time = client_time;
            this.damage_team_no_miss = damage_team_no_miss;
        }

        public int enemy_effect_client { set; get; }
        public int true_time { set; get; }//帧数
        public int life_enemy { set; get; }//铁血血量 和对铁血造成的伤害 一般相等
        public int client_time { set; get; }//客户端时间 秒数
        public int damage_team_no_miss { set; get; }


    }

    public class battle_time
    {
        public int enemy_effect_client { set; get; }
        public int team_effect_60 { set; get; }
        public int team_effect_30 { set; get; }
        public double true_time { set; get; }
    }


    public class TeamMove
    {
        public Dictionary<int, Data> dic = new Dictionary<int, Data>();
        public void Add(int from_spot_id, int to_spot_id, int move_type, int teamLOC)
        {
            Data data = new Data();
            data.from_spot_id = from_spot_id;
            data.to_spot_id = to_spot_id;
            data.move_type = move_type;
            data.teamLOC = teamLOC;
            dic.Add(dic.Count, data);
        }
        public class Data
        {
            public int team_id { set; get; }
            public int from_spot_id { set; get; }
            public int to_spot_id { set; get; }
            public int move_type { set; get; }
            public int teamLOC { set; get; }
        }

    }



    public class TeamInfo
    {
        public int TeamID;
        public bool isMainTeam;
        public bool isSupportTeam { get { return !isMainTeam; } }
        public int TeamEffect;
        public int MVP
        {
            get
            {
                Dictionary<int, int> mvp = new Dictionary<int, int>();
                foreach (var item in teaminfo)
                {
                    mvp.Add(item.Value.id, item.Value.experience);
                }
                return mvp.Keys.Select(x => new { x, y = mvp[x] }).OrderBy(x => x.y).First().x;
            }
        }

        public int getSeed(int user_exp)
        {
            int seed = 0;
            foreach (var item in teaminfo)
            {
                seed += item.Value.experience;
                seed += item.Value.life;
                seed += item.Value.teamId;
            }
            seed += user_exp;
            return seed;
        }
        public Dictionary<int, Gun_With_User_Info> teaminfo = new Dictionary<int, Gun_With_User_Info>();
    }

    public class MissionInfo
    {
        //一个Data代表一个任务
        public class Data
        {
            public List<TeamInfo> Teams = new List<TeamInfo>();
            public string MissionMap = "";
            public Dictionary<int, int> List_withdrawPOS = new Dictionary<int, int>();
            public Dictionary<int, int> List_lifeReduce = new Dictionary<int, int>();
            public int CycleTime = 0;
            public int BattleTimes = 0;
            public int MaxCycleNumber = 0;
            public bool Loop = true;
            public bool needSupply = true;
            public int requestLv = 0;
            public bool Using = false;

            public int CommanderLv = 0;
            public bool AutoCombine = true;
            public bool AutoStrengthen = true;
            public static bool AutoQuickFix = true;
            public bool StopLoopByEquipRank5=false;
            public bool StopLoopByStart3 = false;
            public bool StopLoopByStart4 = false;
            public bool StopLoopByStart5 = false;
            public bool StopLoopByNumberCoreR = false;
            public bool StopLoopByPrize = false;
            public int NumberCoreRequire =0;
            public int NumberCore = 0;
            public bool needlog = false;
            public int user_exp=0;
            public string Parm="";

            public RecycleLog recycleLog;
            public class RecycleLog
            {
                public int Mp = 0;
                public int Ammo = 0;
                public int Mre = 0;
                public int Part = 0;

                public int Coin1 = 0;
                public int Coin2 = 0;
                public int Coin3 = 0;

                public int Gun = 0;

                public void ResultD(UserData userData,string result)
                {
                    









                }







            }


            public Data(UserData userData, Battle battle)
            {
                this.recycleLog = new RecycleLog();
                this.Using = true;
                this.user_exp = userData.user_Info.experience;
                this.Parm = battle.Parm;
                if (battle.Teams.Count() == 0) { return; }
                foreach (var team in battle.Teams)
                {
                    if (string.IsNullOrEmpty(team.Skt.ToString()))
                    {
                        Random random = new Random();
                        team.Skt = random.Next(20000, 30000);
                    }
                }

                foreach (var team in battle.Teams.OrderBy(s => s.Key).ToList())
                {
                    TeamInfo bti = new TeamInfo();
                    bti.TeamEffect = Convert.ToInt32(team.Skt);
                    bti.isMainTeam = true;
                    bti.TeamID = team.Teamid;
                    bti.teaminfo = userData.Teams[team.Teamid];
                    this.Teams.Add(bti);
                }



                List<string> Parm = battle.Parm.ToLower().Split(' ').ToList();

                if (string.IsNullOrEmpty(battle.Map))
                {
                    battle.Map = "-map0_2";
                }
                else
                {
                    this.MissionMap = battle.Map;
                }

                foreach (var item in Parm)
                {
                    if (item.Contains("-map"))
                    {
                        this.MissionMap = item.ToString();
                    }
                    if (item.Contains("-loginnum"))
                    {
                        Int32.TryParse(item.Remove(0, 9), out SystemOthers.ConfigData.BL_ReLogin_num);
                    }
                    if (item.Contains("-lv"))
                    {
                        Int32.TryParse(item.Remove(0, 3), out this.requestLv);
                    }

                    //循环次数
                    if (item.Contains("-t"))
                    {
                        this.MaxCycleNumber = Convert.ToInt32(item.Remove(0, 2));
                    }
                    //自动扩编
                    if (item.Contains("-c"))
                    {
                        this.AutoCombine = false;
                    }
                    if (item.Contains("-e"))
                    {
                        this.StopLoopByEquipRank5 = true;
                    }
                    if (item.Contains("-a"))
                    {
                        this.AutoStrengthen = false;
                    }
                    if (item.Contains("-s3"))
                    {
                        this.StopLoopByStart3 = true;
                    }
                    if (item.Contains("-s4"))
                    {
                        this.StopLoopByStart4 = true;
                    }
                    if (item.Contains("-s5"))
                    {
                        this.StopLoopByStart5 = true;
                    }
                    if (item.Contains("-n") && !item.Contains("-ns"))
                    {
                        this.AutoCombine = false;
                        this.StopLoopByNumberCoreR = true;
                        Int32.TryParse(item.Remove(0, 2), out this.NumberCoreRequire);
                    }
                    if (item.Contains("-ns"))
                    {
                        this.needSupply = false;
                    }

                    if (item.Contains("-log"))
                    {
                        this.needlog = true;
                    }
                    if (item.Contains("-p"))
                    {
                        this.StopLoopByPrize = true;
                    }
                    if (item.Contains("-qf"))
                    {
                        AutoQuickFix = false;
                    }
                    if (item.Contains("-h"))
                    {
                        this.CommanderLv = Convert.ToInt32(item.Remove(0, 2));
                    }

                }
                this.MissionMap = MissionMap.Remove(0, 1);
            }
            public Data()
            {
                this.recycleLog = new RecycleLog();
            }
        }




        public List<Data> listTask = new List<Data>();
        public Data GetFirstData()
        {
            if (listTask.Count == 0) return new Data();
            return listTask[0];
        }
        public void setFirstDataLoopFalse()
        {
            if (listTask.Count == 0) return;
            listTask[0].Loop=false;
        }

        public MissionInfo()
        {

        }

        public MissionInfo(UserData userData, Battle battle)
        {

        }
        public static void LifeReduce(TeamInfo team)
        {
            if (Data.AutoQuickFix == false) return;
            for (int i = 0; i <= team.teaminfo.Count; i++)
            {
                if (team.teaminfo.ContainsKey(i))
                {
                    if (team.teaminfo[i].life < 27) continue;
                    team.teaminfo[i].life -= 1;
                }
            }
        }

    }

    public class BattleData
    {
        public class Data
        {
            public Random random = new Random();
            public int spot_id;
            public bool if_enemy_die = true;
            public int current_time;
            public int boss_hp = 0;
            public int mvp;
            public string last_battle_info;
            public List<TeamInfo> Teams = new List<TeamInfo>();
            public int teamLoc;
            public string user_rec;
            public int truetime;
            public int life_reduce;
            public int enemy_effect_client;
            public int enemy_character_type_id;
            public int life_enemy;
            public int user_exp;
        }

        Data data = new Data();
        public BattleData(List<TeamInfo> Teams)
        {
            data.Teams = Teams;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="spotid"></param>
        /// <param name="teamLoc"></param>
        /// <param name="lrd">life_reduce</param>
        /// <param name="tt">truetime</param>
        /// <param name="eec">enemy_effect_client</param>
        /// <param name="le">life_enemy</param>
        /// <param name="userexp"></param>
        /// <param name="ecti">enemy_character_type_id</param>
        public string setData(int spotid, int teamLoc, int lrd, int tt, int eec, int le, int ecti, int userexp, bool if_enemy_die = true)
        {
            MissionInfo.LifeReduce(data.Teams[teamLoc]);

            data.if_enemy_die = if_enemy_die;
            data.spot_id = spotid;
            data.teamLoc = teamLoc;
            data.mvp = data.Teams[data.teamLoc].MVP;
            data.enemy_effect_client = eec;
            data.life_enemy = le;
            data.truetime = tt;
            data.life_reduce = lrd;
            data.user_exp = userexp;
            data.enemy_character_type_id = ecti;
            WriteData();
            return stringBuilder.ToString();
        }
        public StringBuilder stringBuilder;
        public JsonWriter writer;



        public void WriteData()
        {
            stringBuilder = new StringBuilder();
            writer = new JsonWriter(stringBuilder);
            writer.WriteObjectStart();

            writer.WritePropertyName("spot_id");
            writer.Write(data.spot_id);
            writer.WritePropertyName("if_enemy_die");
            writer.Write(data.if_enemy_die);
            writer.WritePropertyName("current_time");
            writer.Write(Helper.Decrypt.ConvertDateTime_China_Int(DateTime.Now));
            writer.WritePropertyName("boss_hp");
            writer.Write(data.boss_hp);
            writer.WritePropertyName("mvp");
            writer.Write(data.mvp);
            writer.WritePropertyName("last_battle_info");
            writer.Write("");

            writer.WritePropertyName("guns");
            writer.WriteArrayStart();
            foreach (var item in data.Teams[data.teamLoc].teaminfo)
            {
                writer.WriteObjectStart();
                writer.WritePropertyName("id");
                writer.Write(item.Value.id);
                writer.WritePropertyName("life");
                writer.Write(item.Value.life);
                writer.WriteObjectEnd();
            }
            writer.WriteArrayEnd();

            writer.WritePropertyName("use_skill_squads");
            writer.WriteArrayStart();
            writer.WriteArrayEnd();

            writer.WritePropertyName("user_rec");
            StringBuilder stringBuilder1 = new StringBuilder();
            JsonWriter jsonWriter1 = new JsonWriter(stringBuilder1);
            jsonWriter1.WriteObjectStart();
            jsonWriter1.WritePropertyName("seed");
            jsonWriter1.Write(data.Teams[data.teamLoc].getSeed(data.user_exp));
            jsonWriter1.WritePropertyName("record");
            jsonWriter1.WriteArrayStart();
            //foreach (var current in user_rec.listRecord)
            //{
            //    jsonWriter1.Write(current.ToString());
            //}
            jsonWriter1.WriteArrayEnd();
            jsonWriter1.WriteObjectEnd();
            writer.Write(stringBuilder1.ToString());


            Random random = new Random();
            writer.WritePropertyName("1000");
            writer.WriteObjectStart();
            writer.WritePropertyName("10");
            writer.Write(data.Teams[data.teamLoc].TeamEffect);
            writer.WritePropertyName("11");
            writer.Write(data.Teams[data.teamLoc].TeamEffect - data.life_reduce);
            writer.WritePropertyName("12");
            writer.Write(data.Teams[data.teamLoc].TeamEffect);
            writer.WritePropertyName("13");
            writer.Write(data.Teams[data.teamLoc].TeamEffect);
            writer.WritePropertyName("15");
            writer.Write(data.enemy_effect_client);

            writer.WritePropertyName("16");
            writer.Write(0);

            writer.WritePropertyName("17");
            writer.Write(data.truetime * 29.7);//要 4场战斗 不同的时间 总帧数

            writer.WritePropertyName("33");
            writer.Write(data.enemy_character_type_id);//改

            writer.WritePropertyName("40");
            writer.Write(128);//我也不知道是什么

            writer.WritePropertyName("18");
            writer.Write(data.life_reduce);
            writer.WritePropertyName("19");
            writer.Write((int)(data.life_reduce * (double)random.Next(10, 20) / 10));


            writer.WritePropertyName("20");
            writer.Write(0);
            writer.WritePropertyName("21");
            writer.Write(0);
            writer.WritePropertyName("22");
            writer.Write(0);
            writer.WritePropertyName("23");
            writer.Write(0);
            writer.WritePropertyName("24");
            writer.Write(data.life_enemy);//要 damage_enemy 4场战斗不同的数据
            writer.WritePropertyName("25");
            writer.Write(0);
            writer.WritePropertyName("26");
            writer.Write(data.life_enemy);//要 life_enemy 4场战斗不同的数据
            writer.WritePropertyName("27");
            writer.Write(data.truetime);// 要 实际时间 4场战斗不同的数据

            writer.WritePropertyName("34");//  min_damage_armor = "34";
            writer.Write(0);
            writer.WritePropertyName("35");//  min_damage_no_armor = "35";
            writer.Write(0);
            writer.WritePropertyName("41"); //max_damage;
            writer.Write(0);
            writer.WritePropertyName("42");
            writer.Write(0);
            writer.WritePropertyName("43");
            writer.Write(0);
            writer.WritePropertyName("44");
            writer.Write(0);
            writer.WriteObjectEnd();

            writer.WritePropertyName("1001");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WritePropertyName("1002");
            writer.WriteObjectStart();

            foreach (var item in data.Teams[data.teamLoc].teaminfo)
            {
                writer.WritePropertyName(item.Value.id.ToString());
                writer.WriteObjectStart();
                writer.WritePropertyName("47");
                writer.Write(2);
                writer.WriteObjectEnd();
            }
            writer.WriteObjectEnd();
            writer.WritePropertyName("1003");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WritePropertyName("1005");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WritePropertyName("battle_damage");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WriteObjectEnd();
        }

        //internal const string team_effect = "10";


        //internal const string afterbattle_team_effect = "11";

        //internal const string team_effect_60 = "12";

        //internal const string team_effect_30 = "13";

        //internal const string enemy_effect = "14";//NO

        //internal const string enemy_effect_client = "15";

        //internal const string true_damage = "16";

        //internal const string true_time = "17";

        //// Token: 0x04001608 RID: 5640
        //internal const string damage_team = "18";

        //// Token: 0x04001609 RID: 5641
        //internal const string damage_team_no_miss = "19";

        //// Token: 0x0400160A RID: 5642
        //internal const string damage_drone = "20";

        //// Token: 0x0400160B RID: 5643
        //internal const string damage_shield = "21";

        //// Token: 0x0400160C RID: 5644
        //internal const string max_shield = "22";

        //// Token: 0x0400160D RID: 5645
        //internal const string total_shield = "23";

        //// Token: 0x0400160E RID: 5646
        //internal const string damage_enemy = "24";

        //// Token: 0x0400160F RID: 5647
        //internal const string damage_enemy_own = "25";

        //// Token: 0x04001610 RID: 5648
        //internal const string life_enemy = "26";

        //// Token: 0x04001611 RID: 5649
        //internal const string client_time = "27";

        //// Token: 0x04001612 RID: 5650
        //internal const string enemy_character_type_id = "33";

        //// Token: 0x04001613 RID: 5651
        //internal const string min_damage_armor = "34";

        //// Token: 0x04001614 RID: 5652
        //internal const string min_damage_no_armor = "35";

        //// Token: 0x04001615 RID: 5653
        //internal const string max_damage = "41";

        //// Token: 0x04001616 RID: 5654
        //internal const string max_skill_damage = "42";

        //// Token: 0x04001617 RID: 5655
        //internal const string damage = "43";

        //// Token: 0x04001618 RID: 5656
        //internal const string damage_no_skill = "44";

        //// Token: 0x04001619 RID: 5657
        //internal const string cd_time_client = "45";

        //// Token: 0x0400161A RID: 5658
        //internal const string start_cd_time_client = "46";

        //// Token: 0x0400161B RID: 5659
        //internal const string skill_num = "47";

        //// Token: 0x0400161C RID: 5660
        //internal const string fairy_id = "67";

        //// Token: 0x0400161D RID: 5661
        //internal const string use_fairy_skill = "68";

        //// Token: 0x0400161E RID: 5662
        //internal const string use_fairy_passive_skill = "9";














    }

    public class Simulation
    {
        SimulationDay Sday;
        UserData userData;
        int bp;
        public Simulation(UserData userData)
        {
            this.userData = userData;
            this.bp = userData.user_Info.bp;
            this.Sday = new SimulationDay();
        }
        public void Run()
        {
            if (userData.config.AutoSimulation == false) return;
            //获取梯队
            if (Sday.SimulationType == 1 && userData.user_Info.bp >= 5)
            {
                userData.eventAction.Start_Trial();
                userData.user_Info.bp -= 5;
                //无限防御
            }
            if (Sday.SimulationType == 2)
            {
                if(userData.others.GetSimulatieDataType()==1 && userData.user_Info.bp >= 1)
                {
                    userData.eventAction.Simulation_DATA();
                    userData.user_Info.bp -= 1;
                }
                if (userData.others.GetSimulatieDataType() == 2 && userData.user_Info.bp >= 2)
                {
                    userData.eventAction.Simulation_DATA();
                    userData.user_Info.bp -= 2;
                }
                if (userData.others.GetSimulatieDataType() == 3 && userData.user_Info.bp >= 3)
                {
                    userData.eventAction.Simulation_DATA();
                    userData.user_Info.bp -= 3;
                }
                //资料
            }
            //
            if (Sday.SimulationType == 3 && userData.user_Info.bp >= 3)
            {
                userData.eventAction.Simulation_Corridor();
                userData.user_Info.bp -= 3;
                //云图
            }
        }




    }

    public class SimulationDay
    {
        /// <summary>
        /// Type:1 是无限防御 2是资料 3是云图
        /// </summary>
        public int SimulationType
        {
            get
            {
                if (Day == 3 || Day == 4)
                {
                    return 1;
                }
                if (Day == 2 || Day == 5 || Day == 0)
                {
                    return 2;
                }
                if (Day == 1 || Day == 6)
                {
                    return 3;
                }
                return 1;
            }
        }
        public int Day
        {
            get
            {
                return (int)Helper.Decrypt.LocalDateTimeConvertToChina(DateTime.Now).DayOfWeek;
            }
        }
    }

    public class SimulationDataHandle
    {
        class Info
        {
            public Info(int type)
            {
                this.DataType = type;
                if (type!=1 && type!=2 && type != 3)
                {
                    this.DataType = 1;
                }
            }
            public int DataType;
            public int mission_id
            {
                get
                {
                    if (DataType == 1)
                    {
                        return 1301;
                    }
                    if (DataType == 2)
                    {
                        return 1302;
                    }
                    return 1303;
                }
            }
            public double Max_duration
            {
                get
                {
                    if (DataType == 1)
                    {
                        return 0.7f;
                    }
                    if (DataType == 2)
                    {
                        return 1.4f;
                    }
                    return 2.87f;
                }
            }
            public int enemy_effect_client
            {
                get
                {
                    if (DataType == 1)
                    {
                        return 2569;
                    }
                    if (DataType == 2)
                    {
                        return 5069;
                    }
                    return 10069;
                }
            }
            public int enemy_life
            {
                get
                {
                    if (DataType == 1)
                    {
                        return 10000;
                    }
                    if (DataType == 2)
                    {
                        return 20000;
                    }
                    return 40000;
                }
            }
            public int skill_cd
            {
                get
                {
                    Random random = new Random();
                    return random.Next(20000, 30000);
                }
            }
        }

        public SimulationDataHandle(UserData userData)
        {
            this.userData = userData;
            this.info = new Info(userData.others.GetSimulatieDataType());
            this.mission_id = info.mission_id;
            this.battle_time.enemy_effect_client = info.enemy_effect_client;
            this.life_enemy = info.enemy_life;
            this.duration = Math.Round(info.Max_duration, 2);
            this.skill_cd = info.skill_cd;
            this.battle_time.true_time = info.Max_duration;
        }
        public void Start()
        {
            if (userData.battle.Simulation_battleFinish(BattleResult) == false)
            {
                new Helper.Log().userInit(userData.GameAccount.GameAccountID, "模拟作战 Error");
            }
        }



        private UserData userData;
        private Info info;
        public int mission_id;
        public int boss_hp = 0;
        public double duration;
        public int skill_cd;
        public int life_enemy;
        public battle_time battle_time = new battle_time();
        public string BattleResult
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                JsonWriter jsonWriter = new JsonWriter(sb);
                jsonWriter.WriteObjectStart();
                jsonWriter.WritePropertyName("mission_id");
                jsonWriter.Write(mission_id);
                jsonWriter.WritePropertyName("boss_hp");
                jsonWriter.Write(0);
                jsonWriter.WritePropertyName("duration");
                jsonWriter.Write(battle_time.true_time);
                WriteDamageData(jsonWriter);
                jsonWriter.WritePropertyName("battle_time");
                jsonWriter.WriteObjectStart();
                jsonWriter.WriteObjectEnd();
                jsonWriter.WriteObjectEnd();
                return sb.ToString();
            }
        }
        public void WriteDamageData(JsonWriter writer)
        {
            writer.WritePropertyName("1000");
            writer.WriteObjectStart();
            writer.WritePropertyName("11");
            writer.Write(skill_cd);
            writer.WritePropertyName("12");
            writer.Write(skill_cd);
            writer.WritePropertyName("13");
            writer.Write(skill_cd);
            writer.WritePropertyName("15");
            writer.Write(battle_time.enemy_effect_client);
            writer.WritePropertyName("17");
            writer.Write(GetTotalFPS_(battle_time.true_time));//总帧数
            writer.WritePropertyName("18");
            writer.Write(0);
            writer.WritePropertyName("19");
            writer.Write(0);
            writer.WritePropertyName("20");
            writer.Write(0);
            writer.WritePropertyName("21");
            writer.Write(0);
            writer.WritePropertyName("22");
            writer.Write(0);
            writer.WritePropertyName("23");
            writer.Write(0);
            writer.WritePropertyName("24");
            writer.Write(life_enemy);//血量
            writer.WritePropertyName("25");
            writer.Write(0);
            writer.WritePropertyName("26");
            writer.Write(life_enemy);
            writer.WritePropertyName("27");
            writer.Write((int)Math.Ceiling(battle_time.true_time));//总时间
            writer.WriteObjectEnd();
            writer.WritePropertyName("1001");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WritePropertyName("1002");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WritePropertyName("1003");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
        }
        public static int GetTotalFPS_(double time)
        {
            double result = time * 31;
            return (int)Math.Ceiling(result);
        }
    }

    public class SimulationTrialHandle
    {
        public class TrialExercise_Battle_Sent
        {

            public int if_win = 0;
            internal Dictionary<int, Gun_With_User_Info> teaminfo = new Dictionary<int, Gun_With_User_Info>();

            public TrialExercise_Battle_Sent(Dictionary<int, Gun_With_User_Info> teaminfo)
            {
                this.teaminfo = teaminfo;
            }
            public string BattleResult
            {
                get
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    JsonWriter jsonWriter = new JsonWriter(stringBuilder);
                    jsonWriter.WriteObjectStart();

                    jsonWriter.WritePropertyName("if_win");
                    jsonWriter.Write(0);

                    jsonWriter.WritePropertyName("battle_guns");
                    jsonWriter.WriteObjectStart();
                    foreach (var item in teaminfo)
                    {
                        jsonWriter.WritePropertyName(item.Value.id.ToString());
                        jsonWriter.WriteObjectStart();

                        jsonWriter.WritePropertyName("life");
                        jsonWriter.Write(item.Value.life);

                        jsonWriter.WritePropertyName("dps");
                        jsonWriter.Write(0);
                        jsonWriter.WriteObjectEnd();


                    }
                    jsonWriter.WriteObjectEnd();
                    WriteDamageData(jsonWriter);
                    jsonWriter.WritePropertyName("battle_damage");
                    jsonWriter.WriteObjectStart();
                    jsonWriter.WriteObjectEnd();
                    jsonWriter.WriteObjectEnd();




                    return stringBuilder.ToString();
                }
            }


            public void WriteDamageData(JsonWriter writer)
            {
                writer.WritePropertyName("1000");
                writer.WriteObjectStart();
                writer.WritePropertyName("11");
                writer.Write(149);
                writer.WritePropertyName("12");
                writer.Write(0);
                writer.WritePropertyName("13");
                writer.Write(0);
                writer.WritePropertyName("15");
                writer.Write(22644);
                writer.WritePropertyName("17");
                writer.Write(0);
                writer.WritePropertyName("18");
                writer.Write(0);
                writer.WritePropertyName("19");
                writer.Write(0);
                writer.WritePropertyName("20");
                writer.Write(0);
                writer.WritePropertyName("21");
                writer.Write(0);
                writer.WritePropertyName("22");
                writer.Write(0);
                writer.WritePropertyName("23");
                writer.Write(0);
                writer.WritePropertyName("24");
                writer.Write(0);
                writer.WritePropertyName("25");
                writer.Write(0);
                writer.WritePropertyName("26");
                writer.Write(24520);
                writer.WritePropertyName("27");
                writer.Write(3);
                writer.WriteObjectEnd();
                writer.WritePropertyName("1001");
                writer.WriteObjectStart();
                writer.WriteObjectEnd();
                writer.WritePropertyName("1002");
                writer.WriteObjectStart();
                writer.WriteObjectEnd();
                writer.WritePropertyName("1003");
                writer.WriteObjectStart();
                writer.WriteObjectEnd();
            }




        }
        public SimulationTrialHandle(UserData userData)
        {
            this.userData = userData;

        }

        public bool Start()
        {
            if (StartBattle()==false) return false;
            return EndBattle();
        }

        private bool StartBattle()
        {
            foreach (var team in userData.Teams)
            {
                TeamID = team.Key;
                int count = 0;
                string result = API.Battle.StartTrial(userData.GameAccount, TeamID.ToString());
                switch (Response.Check(userData.GameAccount, ref result, "StartTrial_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                continue;
                            }
                            break;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                continue;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            new Log().userInit(userData.GameAccount.GameAccountID, "开始无限防御 Error TeamID = {0}",TeamID.ToString()).userInfo();
            return false;
        }
        private bool EndBattle()
        {
            TrialExercise_Battle_Sent tbs = new TrialExercise_Battle_Sent(userData.Teams[TeamID]);
            int count = 0;
            while (true)
            {
                string result = API.Battle.EndTrial(userData.GameAccount,tbs.BattleResult);
                switch (Response.Check(userData.GameAccount,ref result, "EndTrial_Pro", true))
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
                                new Log().userInit(userData.GameAccount.GameAccountID, "开始无限防御 Error TeamID = {0}", TeamID.ToString()).userInfo();
                                return false;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }
        public int TeamID;
        private UserData userData;
    }








    /// <summary>
    /// 
    /// </summary>
    public class Battle
    {
        public string accountID;
        public string Map;
        public Team[] Teams;
        public string Parm;
    }
    /// <summary>
    /// 
    /// </summary>
    public class Team
    {
        public int Teamid;
        public int Skt;
        public int Key;
    }



    public class mapbase
    {
        public int mission_id;
        public int withdrawSpot;
        public Spot.Data[] Mission_Start_spots;
        public TeamMove teamMove = new TeamMove();
        public Spot Spots = new Spot();
    }








}

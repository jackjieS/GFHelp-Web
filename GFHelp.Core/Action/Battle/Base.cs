using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace GFHelp.Core.Action.BattleBase
{
    public class Spot
    {
        public void Add(int spot_id, int key)
        {
            Data data = new Data();
            data.spot_id = spot_id;
            data.team_loc = key;

            dic.Add(dic.Count, data);
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
        public TeamInfo(Team team)
        {
            TeamID = team.Teamid;
            isMainTeam = true;
            TeamEffect = Convert.ToInt32(team.Skt);
        }
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
        public Dictionary<int, Gun_With_User_Info.Data> teaminfo = new Dictionary<int, Gun_With_User_Info.Data>();
    }

    public class MissionInfo
    {

        public class Data
        {
            public void DataHandle()
            {
                if (CycleTime > 50)
                {
                    this.needSupply = false;
                }
                //if (AutoQuickFixTimes > 50)
                //{
                //    this.AutoQuickFix = true;
                //}




            }

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
            public bool Story = false;
            public int CommanderLv = 0;
            public bool AutoCombine = true;
            public bool AutoStrengthen = true;
            public bool AutoQuickFix = true;
            public int AutoQuickFixTimes = 0;
            public bool StopLoopByEquipRank5 = false;
            public bool StopLoopByStart3 = false;
            public bool StopLoopByStart4 = false;
            public bool StopLoopByStart5 = false;
            public bool StopLoopByNumberCoreR = false;
            public bool StopLoopByPrize = false;
            public int NumberCoreRequire = 0;
            public int NumberCore = 0;
            public bool needlog = false;
            public int user_exp = 0;
            public string Parm = "";
            public int equipid = 0;
            public double Delay = 1;
            public DateTime dateTimeStart = DateTime.Now;
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

                public void ResultD(UserData userData, string result)
                {










                }







            }


            public Data(UserData userData, Battle battle)
            {

                this.recycleLog = new RecycleLog();
                this.Using = true;
                this.user_exp = userData.user_Info.experience;
                this.Parm = battle.Parm;

                for (int i = 0; i < battle.Teams.Count; i++)
                {
                    if (battle.Teams[i] == null) continue;
                    if (battle.Teams[i].Skt == 0)
                    {
                        battle.Teams[i].Skt = userData.random.Next(20000, 30000);
                    }
                }

                foreach (var team in battle.Teams.OrderBy(s => s.Key).ToList())
                {
                    TeamInfo bti = new TeamInfo(team);
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
                        Int32.TryParse(item.Remove(0, 9), out SystemManager.ConfigData.BL_ReLogin_num);
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
                    if (item.Contains("-equipid"))
                    {
                        this.equipid = Convert.ToInt32(item.Remove(0, 8));
                    }
                    if (item.Contains("-d"))
                    {
                        this.Delay = Convert.ToDouble(item.Remove(0, 2));
                        userData.config.TimeDelay = this.Delay;
                    }
                    else
                    {
                        userData.config.TimeDelay = 1;
                    }

                }
                this.MissionMap = MissionMap.Remove(0, 1);
            }
            public Data()
            {
                this.recycleLog = new RecycleLog();
            }

            public int getTeamId()
            {
                if (Teams.Count != 0)
                    return Teams[0].TeamID;
                return 1;
            }
            public void LifeReduce(int teamLoc)
            {
                //if (AutoQuickFix == false) return;
                //if (Teams.Count == 0) return;
                Random random = new Random();
                for (int i = 0; i <= Teams[teamLoc].teaminfo.Count; i++)
                {
                    if (Teams[teamLoc].teaminfo.ContainsKey(i))
                    {
                        if (Teams[teamLoc].teaminfo[i].info.type == CatchData.Base.GunType.assaultRifle) continue;
                        if (Teams[teamLoc].teaminfo[i].info.type == CatchData.Base.GunType.machinegun) continue;
                        if (Teams[teamLoc].teaminfo[i].info.type == CatchData.Base.GunType.sniperRifle) continue;
                        if (random.Next(0, 2) == 0) continue;
                        if (Teams[teamLoc].teaminfo[i].life < 30) continue;
                        Teams[teamLoc].teaminfo[i].life -= random.Next(1, 5);
                    }
                }

            }



        }

        public Data data = new Data();


        public List<Data> listTask = new List<Data>();
        public Task battleLoop;
        public void Add(Data data)
        {
            if (listTask.Count == 0)
            {
                listTask.Add(data);
                battleLoop = new Task(() => Start());
                battleLoop.Start();
                return;
            }

            if (listTask.Count != 0)
            {
                listTask.Add(data);
                return;
            }

        }
        public void Start()
        {
            while (listTask.Count > 0)
            {
                if (userData.config.isOffline)
                {
                    listTask.Clear();
                    return;
                }
                try
                {
                    //Console.WriteLine("BattleLoop 被调用了");

                    userData.mission.Test();
                }
                catch (Exception e)
                {
                    new Log().systemInit("MissionInfo.Task battleLoop Error ", e.ToString()).coreError();
                }
            }

        }
























        public Data GetFirstData()
        {
            if (listTask.Count == 0) return new Data();
            return listTask[0];
        }
        public int getFirsDataTeamID()
        {
            if (listTask.Count != 0) return listTask[0].getTeamId();
            return 1;


        }
        public void setFirstDataLoopFalse()
        {
            if (listTask.Count == 0) return;
            listTask[0].Loop = false;
        }

        public MissionInfo(UserData userData)
        {
            this.userData = userData;
        }

        public MissionInfo(UserData userData, Battle battle)
        {

        }


        UserData userData;
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

        UserData userData;
        public BattleData(UserData userData)
        {
            this.userData = userData;
            this.data.Teams = userData.MissionInfo.GetFirstData().Teams;
        }

        public BattleData(MissionInfo.Data data)
        {
            this.data.Teams = data.Teams;
        }

        private void ThreadDelay(int Second)
        {
            System.Random random = new System.Random();
            double randome = random.NextDouble() + 1;
            Thread.Sleep((int)(Second * 1000 * userData.MissionInfo.GetFirstData().Delay * randome));
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
            userData.webData.StatusBarText = "计算战斗数据 - 等待";
            ThreadDelay(tt);
            userData.MissionInfo.GetFirstData().LifeReduce(teamLoc);

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
            writer.Write(Helper.Decrypt.getDateTime_China_Int(DateTime.Now));
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
            writer.Write(random.Next(100,500));//我也不知道是什么

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
            writer.WritePropertyName("92");
            writer.Write(0);
            writer.WritePropertyName("100");
            writer.Write(random.Next(500, 1000));
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
            if (CheckBattleListHas()) return;
            if (Sday.SimulationType == 1 && userData.user_Info.bp >= 5)
            {
                Start_Trial();
                userData.user_Info.bp -= 5;
            }
            if (Sday.SimulationType == 2)
            {
                if (userData.others.GetSimulatieDataType() == 1 && userData.user_Info.bp >= 1)
                {
                    Simulation_DATA();
                    userData.user_Info.bp -= 1;
                }
                if (userData.others.GetSimulatieDataType() == 2 && userData.user_Info.bp >= 2)
                {
                    Simulation_DATA();
                    userData.user_Info.bp -= 2;
                }
                if (userData.others.GetSimulatieDataType() == 3 && userData.user_Info.bp >= 3)
                {
                    Simulation_DATA();
                    userData.user_Info.bp -= 3;
                }

            }
            //
            if (Sday.SimulationType == 3 && userData.user_Info.bp >= 3)
            {
                CorridorRun();
                userData.user_Info.bp -= 3;

            }
        }

        private bool CheckBattleListHas()
        {
            foreach (var item in userData.MissionInfo.listTask)
            {
                if (item.MissionMap.Contains("simulationtrial")) return true;
                if (item.MissionMap.Contains("simulationdata")) return true;
                if (item.MissionMap.Contains("corridor")) return true;
            }
            return false;
        }

        private void Start_Trial()
        {
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-mapsimulationtrial";
            bs.Parm = "-t1 -c -ns -qf -a -e";
            if (userData.others.getAvailableTeamID().Count == 0) return;

            bs.Teams = new List<Team>();
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.Add(data);



        }
        private void Simulation_DATA()
        {
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-mapsimulationdata";
            bs.Parm = "-t1 -c -ns -qf -a -e";
            bs.Teams = new List<Team>();
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.Add(data);
        }

        private void CorridorRun()
        {
            if (userData.others.getAvailableTeamID().Count == 0) return;
            Battle bs = new Battle();
            bs.accountID = userData.GameAccount.GameAccountID;
            bs.Map = "-mapcorridor";
            bs.Parm = "-t1 -c -ns -qf -a -e";
            bs.CreatTeamList(userData.others.getAvailableTeamID());
            MissionInfo.Data data = new MissionInfo.Data(userData, bs);
            userData.MissionInfo.Add(data);
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
                        return 3;
                    }
                    if (Day == 2 || Day == 5 || Day == 0)
                    {
                        return 1;
                    }
                    if (Day == 1 || Day == 6)
                    {
                        return 3;
                    }
                    return 3;
                }
            }
            public int Day
            {
                get
                {
                    return (int)Decrypt.ChinaTimeDateTime.DayOfWeek;
                }
            }
        }



    }













    /// <summary>
    /// 
    /// </summary>
    public class Battle
    {
        public string WebUserName;
        public string accountID;
        public string Map;
        public List<Team> Teams;
        public string Parm;

        public bool isErrorVaild()
        {
            if (Teams.Count == 0)
            {
                return true;
            }
            return false;
        }
        public bool isParmError()
        {
            if (!Parm.Contains("-t"))
            {
                return true;
            }
            return false;
        }
        public void CreatTeamList(List<int> teamlist)
        {
            Teams = new List<Team>();
            for (int i = 0; i < teamlist.Count; i++)
            {
                Team t = new Team();
                t.Key = i;
                t.Teamid = teamlist[i];
                Teams.Add(t);
            }
        }
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
        public int stepNum = 0;
        public int mission_id;
        public int withdrawSpot;
        public Spot.Data[] Mission_Start_spots;
        public List<int> listSupplySpot = new List<int>();
        public TeamMove teamMove = new TeamMove();
        public Spot Spots = new Spot();
        public List<BuildIng> listBuilding = new List<BuildIng>();
        public class BuildIng
        {
            public BuildIng(int trigger_type, int trigger_person_spot, int building_spot_id, int[] active_mission_skills)
            {
                this.trigger_type = trigger_type;
                this.trigger_person_spot = trigger_person_spot;
                this.building_spot_id = building_spot_id;
                this.active_mission_skills = active_mission_skills;
            }
            public int trigger_type;
            public int trigger_person_spot;
            public int building_spot_id;
            public int[] active_mission_skills;
        }

        public void SpotInit()
        {
            



        }
    }








}

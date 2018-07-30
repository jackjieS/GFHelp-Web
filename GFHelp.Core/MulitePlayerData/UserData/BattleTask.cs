using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    class BattleTask
    {
        public class Team
        {
            public Team(UserData userData)
            {
                this.userData = userData;
            }

            public UserData userData;
            public int TeamID;
            public bool isMainTeam;
            public bool isSupportTeam { get { return !isMainTeam; } }
            public int TeamEffect;
            public int MVP
            {
                get
                {
                    Dictionary<int, int> mvp = new Dictionary<int, int>();
                    foreach (var item in userData.Teams[TeamID])
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
            internal Dictionary<int, Gun_With_User_Info> teaminfo = new Dictionary<int, Gun_With_User_Info>();
        }
        public class Mission
        {
            public List<Team> Teams = new List<Team>();
            public string TaskMap = "";
            public Dictionary<int, int> List_withdrawPOS = new Dictionary<int, int>();
            public Dictionary<int, int> List_lifeReduce = new Dictionary<int, int>();
            public int user_exp;
            public bool TaskList_ADD = false;
            public int LoopTime = 0;
            public int MaxLoopTime = 0;
            public int reStart_WaitTime = 1;
            public bool Loop = true;
            public bool needSupply = true;
            public int requestLv = 0;
            public Mission(List<Team> Teams, int user_exp)
            {
                this.Teams = Teams;

                this.user_exp = user_exp;
            }
            public int getSupportTeamID
            {
                get
                {
                    foreach (var item in Teams)
                    {
                        if (item.isSupportTeam) return item.TeamID;
                    }
                    return 0;
                }
            }




        }
    }
}

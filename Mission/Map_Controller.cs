using GFHelp.Core.Action.BattleBase;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Mission
{
    public class Map_Controller
    {
        public static class Function
        {
            public static bool needFight;
            public static int Normal_PosCheck_type1(string result, int fromSpot, int toSpot)
            {
                if (result.Contains("error")) return 0;//error 代码
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["enemy_move"];
                foreach (JsonData item in jsonData)
                {
                    if (item["from_spot_id"].Int == fromSpot && item["to_spot_id"].Int == toSpot)
                        return 1;//需要打
                }
                return 2;//不需要打
            }

            /// <summary>
            /// 0 error代码 1需要打 2不需要打
            /// </summary>
            /// <param name="result"></param>
            /// <param name="toSpot"></param>
            /// <returns> 0 error代码 1需要打 2不需要打</returns>
            public static int Normal_PosCheck_type2(string result, int toSpot)
            {
                if (result.Contains("error")) return 0;//error 代码
                try
                {
                    JsonData jsonData = JsonMapper.ToObject(result);
                    jsonData = jsonData["enemy_move"];
                    foreach (JsonData item in jsonData)
                    {
                        if (item["to_spot_id"].Int == toSpot)
                            return 1;//需要打
                    }
                    return 2;//不需要打
                }
                catch (Exception)
                {
                    return 1;
                }

            }

            public static int Night_PosCheck_type1(string result, int toSpot)
            {
                if (result.Contains("error")) return -1;//error 代码
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["night_enemy"];
                foreach (JsonData item in jsonData)
                {
                    if (item["to_spot_id"].Int == toSpot)
                    {

                        return 1;//需要打
                    }
                }
                //needFight = false;
                //return this;
                return 2;//不需要打
            }
            public static void init(Dictionary<int, TeamMove> dic_TeamMove, Dictionary<int, Spot> spots, Normal_MissionInfo ubti)
            {
                for (int i = 0; i < dic_TeamMove.Count; i++)
                {
                    dic_TeamMove[i].team_id = ubti.Teams[dic_TeamMove[i].teamLOC].TeamID;
                }
                for (int i = 0; i < spots.Count; i++)
                {
                    spots[i].team_id = ubti.Teams[spots[i].team_loc].TeamID;
                }
            }


        }
        public enum MissionType
        {
            Normal,
            Emergency,
            Night,
            Activity,
            Simulation
        };
        public class map0_1
        {
            public map0_1(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 1;
            public static MissionType missionType = MissionType.Normal;
            public Spot[] Mission_Start_spots;//部署梯队的信息
            public TeamMove teammove1 = new TeamMove(1, 2, 1, 0);
            public TeamMove teammove2 = new TeamMove(2, 3, 1, 0);
            public TeamMove teammove3 = new TeamMove(3, 4, 1, 0);
            public TeamMove teammove4 = new TeamMove(4, 5, 1, 0);
            public TeamMove teammove5 = new TeamMove(5, 6, 1, 0);
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(1, 0);//主力
            public Spot spots2 = new Spot(1, 1);//辅助
            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 3033;//撤离
        }

        public class maptest
        {
            public static MissionType missionType = MissionType.Normal;
        }
        public class mapnormal
        {
            public static MissionType missionType = MissionType.Normal;
        }
        public class mapemergency
        {
            public static MissionType missionType = MissionType.Normal;
        }
        public class map0_2
        {
            public map0_2(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }

            public static MissionType missionType = MissionType.Normal;
            public int mission_id = 2;
            public Spot[] Mission_Start_spots;//部署梯队的信息
            public TeamMove teammove1 = new TeamMove(9, 17, 1, 0);
            public TeamMove teammove2 = new TeamMove(17, 18, 1, 0);
            public TeamMove teammove3 = new TeamMove(18, 19, 1, 0);
            public TeamMove teammove4 = new TeamMove(19, 16, 1, 0);
            public TeamMove teammove5 = new TeamMove(16, 23, 1, 0);
            public TeamMove teammove6 = new TeamMove(23, 25, 1, 0);
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(9, 0);//主力
            public Spot spots2 = new Spot(12, 1);//辅助
            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 3033;//撤离
        }

        public class map1_6
        {
            public map1_6(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(133, 134, 1, 0);
            public TeamMove teammove2 = new TeamMove(134, 135, 1, 0);
            public TeamMove teammove3 = new TeamMove(135, 139, 1, 0);
            public TeamMove teammove4 = new TeamMove(139, 136, 1, 0);
            public TeamMove teammove5 = new TeamMove(136, 144, 1, 0);
            public TeamMove teammove6 = new TeamMove(144, 148, 1, 0);
            public TeamMove teammove7 = new TeamMove(148, 149, 1, 0);
            public TeamMove teammove8 = new TeamMove(149, 146, 1, 0);
            public TeamMove teammove9 = new TeamMove(146, 147, 1, 0);
            public Dictionary<int, TeamMove> dic_TeamMove;

            public Spot spots1 = new Spot(1330, 0);
            public Spot spots2 = new Spot(133, 1);




            public int HomePos2(string result)
            {
                try
                {
                    JsonData jsonData = JsonMapper.ToObject(result);
                    jsonData = jsonData["enemy_move"];
                    foreach (JsonData item in jsonData)
                    {
                        if (item["from_spot_id"].Int == 145 && item["to_spot_id"].Int == 146)
                            return 1;//需要打

                    }
                    return 0;//不需要打
                }
                catch (Exception)
                {
                    return 0;//不需要打
                }

            }
            public int withdrawSpot = 1948;//撤离
        }

        public class map2_2
        {
            public map2_2(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                Spots.Add(Spots.Count, spots1);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 16;
            public static MissionType missionType = MissionType.Normal;
            public Spot[] Mission_Start_spots;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(210,0);//主力


            public TeamMove teammove1 = new TeamMove(210, 213, 1, 0);
            public TeamMove teammove2 = new TeamMove(213, 212, 1, 0);
            public TeamMove teammove3 = new TeamMove(212, 215, 1, 0);
            public TeamMove teammove4 = new TeamMove(215, 216, 1, 0);
            public TeamMove teammove5 = new TeamMove(216, 218, 1, 0);
            public TeamMove teammove6 = new TeamMove(218, 219, 1, 0);
            public Dictionary<int, TeamMove> dic_TeamMove;

        }
        public class map2_3
        {
            public map2_3(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                Spots.Add(Spots.Count, spots1);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 17;
            public Spot[] Mission_Start_spots;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(227,0);//主力
            public Spot spots2 = new Spot(220,1);//主力

            public  TeamMove teammove1 = new TeamMove(227, 229, 1,0);
            public  TeamMove teammove2 = new TeamMove(229, 228, 1,0);
            public  TeamMove teammove3 = new TeamMove(228, 224, 1,0);


            public  Dictionary<int, TeamMove> dic_TeamMove = new Dictionary<int, TeamMove>();
        }

        public class map2_4
        {
            public map2_4(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                Spots.Add(Spots.Count, spots1);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public  int mission_id = 18;
            public Spot[] Mission_Start_spots;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(233,0);//主力


            public  TeamMove teammove1 = new TeamMove(233, 235, 1,0);
            public  TeamMove teammove2 = new TeamMove(235, 238, 1,0);
            public  TeamMove teammove3 = new TeamMove(238, 240, 1,0);
            public  TeamMove teammove4 = new TeamMove(240, 241, 1,0);
            public  TeamMove teammove5 = new TeamMove(241, 243, 1,0);

            public Dictionary<int, TeamMove> dic_TeamMove;

        }

        public class map2_5
        {
            public map2_5(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public  int mission_id = 19;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(245,0);//主力
            public  TeamMove teammove1 = new TeamMove(245, 247, 1,0);
            public  TeamMove teammove2 = new TeamMove(247, 252, 1,0);
            public  TeamMove teammove3 = new TeamMove(252, 258, 1,0);
            public  TeamMove teammove4 = new TeamMove(258, 259, 1,0);
            public Dictionary<int, TeamMove> dic_TeamMove;
        }
        public class map2_6
        {
            public map2_6(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 20;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(260, 0);//主力


            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(260, 261, 1, 0);
            public TeamMove teammove2 = new TeamMove(261, 263, 1, 0);
            public TeamMove teammove3 = new TeamMove(263, 267, 1, 0);
            public TeamMove teammove4 = new TeamMove(267, 271, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;

        }
        public class map3_1
        {
            public map3_1(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                Spots.Add(Spots.Count, spots1);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 25;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(348,0);//主力



            public TeamMove teammove1 = new TeamMove(348, 350, 1,0);
            public TeamMove teammove2 = new TeamMove(350, 353, 1,0);
            public TeamMove teammove3 = new TeamMove(353, 356, 1,0);



            public Dictionary<int, TeamMove> dic_TeamMove;



        }
        public class map3_2
        {
            public map3_2(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 , spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 26;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(370,0);//主力
            public Spot spots2 = new Spot(358,1);//主力

            public TeamMove teammove1 = new TeamMove(370, 366, 1,0);
            public TeamMove teammove2 = new TeamMove(366, 368, 1,0);
            public TeamMove teammove3 = new TeamMove(368, 369, 1,0);
            public TeamMove teammove4 = new TeamMove(369, 364, 1,0);


            public Dictionary<int, TeamMove> dic_TeamMove;
        }
        public class map3_3
        {
            public map3_3(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 27;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(382,0);//主力
            public Spot spots2 = new Spot(382,1);//主力


            public TeamMove teammove1 = new TeamMove(382, 379, 1,0);
            public TeamMove teammove2 = new TeamMove(379, 375, 1,0);
            public TeamMove teammove3 = new TeamMove(375, 373, 1,0);
            public TeamMove teammove4 = new TeamMove(373, 372, 1,0);
            public TeamMove teammove5 = new TeamMove(372, 371, 1,0);

            public Dictionary<int, TeamMove> dic_TeamMove;

        }
        public class map3_4
        {
            public map3_4(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 28;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(385,0);//主力
            public Spot spots2 = new Spot(385,1);//主力


            public TeamMove teammove1 = new TeamMove(385, 388, 1,0);
            public TeamMove teammove2 = new TeamMove(388, 392, 1,0);
            public TeamMove teammove3 = new TeamMove(392, 395, 1,0);



            public Dictionary<int, TeamMove> dic_TeamMove;
        }
        public class map3_5
        {
            public map3_5(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 29;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(412,0);//主力
            public Spot spots2 = new Spot(398,1);//主力


            public TeamMove teammove1 = new TeamMove(412, 411, 1,0);
            public TeamMove teammove2 = new TeamMove(411, 414, 1,0);
            public TeamMove teammove3 = new TeamMove(414, 413, 1,0);


            public Dictionary<int, TeamMove> dic_TeamMove;
        }
        public class map3_6
        {
            public map3_6(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public static MissionType missionType = MissionType.Normal;
            public int mission_id = 30;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(427, 0);//主力
            public Spot spots2 = new Spot(431, 1);//辅助

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(427, 422, 1, 0);
            public TeamMove teammove2 = new TeamMove(422, 423, 1, 0);
            public TeamMove teammove3 = new TeamMove(423, 424, 1, 0);
            public TeamMove teammove4 = new TeamMove(424, 425, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;

            public int withdrawSpot = 427;//撤离
        }
        public class map4_1
        {
            public map4_1(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 , spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 35;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(513,0);//主力
            public Spot spots2 = new Spot(516,1);//辅助



            public TeamMove teammove1 = new TeamMove(513, 512, 1,0);
            public TeamMove teammove2 = new TeamMove(512, 511, 1,0);
            public TeamMove teammove3 = new TeamMove(511, 509, 1,0);
            public TeamMove teammove4 = new TeamMove(509, 508, 1,0);
            public TeamMove teammove5 = new TeamMove(508, 509, 1,0);

            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map4_2
        {
            public map4_2(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 36;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(522,0);//主力


            public TeamMove teammove1 = new TeamMove(522, 521, 1,0);
            public TeamMove teammove2 = new TeamMove(521, 517, 1,0);
            public TeamMove teammove3 = new TeamMove(517, 518, 1,0);
            public TeamMove teammove4 = new TeamMove(518, 519, 1,0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map4_3
        {
            public map4_3(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 37;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(531,0);//主力
            public Spot spots2 = new Spot(528,1);//主力

            public TeamMove teammove1 = new TeamMove(531, 532, 1,0);
            public TeamMove teammove2 = new TeamMove(532, 536, 1,0);
            public TeamMove teammove3 = new TeamMove(536, 537, 1,0);
            public TeamMove teammove4 = new TeamMove(537, 540, 1,0);
            public TeamMove teammove5 = new TeamMove(540, 542, 1,0);
            public TeamMove teammove6 = new TeamMove(542, 544, 1,0);

            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map4_4
        {
            public map4_4(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 38;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(561,0);//主力
            public Spot spots2 = new Spot(549,1);//主力


            public TeamMove teammove1 = new TeamMove(561, 560, 1,0);
            public TeamMove teammove2 = new TeamMove(560, 556, 1,0);
            public TeamMove teammove3 = new TeamMove(556, 559, 1,0);
            public TeamMove teammove4 = new TeamMove(559, 558, 1,0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map4_5
        {
            public map4_5(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 39;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(577,0);//主力
            public Spot spots2 = new Spot(562,1);//主力

            public TeamMove teammove1 = new TeamMove(577, 578, 1,0);
            public TeamMove teammove2 = new TeamMove(578, 579, 1,0);
            public TeamMove teammove3 = new TeamMove(579, 580, 1,0);
            public TeamMove teammove4 = new TeamMove(580, 581, 1,0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map4_6
        {
            public map4_6(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 40;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(582, 0);
            public Spot spots2 = new Spot(587, 1);

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(582, 588, 1, 0);
            public TeamMove teammove2 = new TeamMove(588, 594, 1, 0);
            public TeamMove teammove3 = new TeamMove(594, 598, 1, 0);
            public TeamMove teammove4 = new TeamMove(598, 604, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;


        }
        public class map5_1
        {
            public map5_1(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove10);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 45;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(690,0);//主力
            public Spot spots2 = new Spot(690,1);//主力
 

            public TeamMove teammove1 = new TeamMove(690, 691, 1,0);
            public TeamMove teammove2 = new TeamMove(691, 692, 1,0);
            public TeamMove teammove3 = new TeamMove(692, 693, 1,0);
            public TeamMove teammove4 = new TeamMove(693, 696, 1,0);

            public TeamMove teammove5 = new TeamMove(690, 691, 1,1);//家里的梯队与战斗
            public TeamMove teammove6 = new TeamMove(696, 698, 1,0);
            public TeamMove teammove7 = new TeamMove(698, 700, 1,0);
            public TeamMove teammove8 = new TeamMove(700, 703, 1,0);

            public TeamMove teammove9 = new TeamMove(703, 702, 1,0);
            public TeamMove teammove10 = new TeamMove(702, 699, 1,0);

            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map5_2
        {
            public map5_2(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 46;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(716,0);//主力
            public Spot spots2 = new Spot(716,1);//主力

            public TeamMove teammove1 = new TeamMove(716, 713, 1,0);
            public TeamMove teammove2 = new TeamMove(713, 709, 1,0);
            public TeamMove teammove3 = new TeamMove(709, 710, 1,0);
            public TeamMove teammove4 = new TeamMove(710, 718, 1,0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map5_3
        {
            public map5_3(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove10);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove11);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove12);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove13);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove14);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 47;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(726,0);//主力
            public Spot spots2 = new Spot(744,1);//主力

            public TeamMove teammove1 = new TeamMove(726, 727, 1,0);
            public TeamMove teammove2 = new TeamMove(727, 731, 1,0);
            public TeamMove teammove3 = new TeamMove(731, 735, 1,0);
            public TeamMove teammove4 = new TeamMove(735, 737, 1,0);

            public TeamMove teammove5 = new TeamMove(737, 738, 1,0);
            public TeamMove teammove6 = new TeamMove(744, 740, 1,1);
            public TeamMove teammove7 = new TeamMove(740, 744, 1,1);
            public TeamMove teammove8 = new TeamMove(744, 745, 1,1);

            public TeamMove teammove9 = new TeamMove(738, 739, 1,0);
            public TeamMove teammove10 = new TeamMove(739, 736, 1,0);
            public TeamMove teammove11 = new TeamMove(736, 733, 1,0);
            public TeamMove teammove12 = new TeamMove(733, 729, 1,0);
            public TeamMove teammove13 = new TeamMove(729, 728, 1,0);
            public TeamMove teammove14 = new TeamMove(728, 732, 1,0);
            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map5_4
        {
            public map5_4(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 , spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 48;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(751,0);//主力
            public Spot spots2 = new Spot(771,1);//主力

            public TeamMove teammove1 = new TeamMove(751, 755, 1,0);
            public TeamMove teammove2 = new TeamMove(755, 760, 1,0);
            public TeamMove teammove3 = new TeamMove(760, 764, 1,0);
            public TeamMove teammove4 = new TeamMove(764, 763, 1,0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map5_5
        {
            public map5_5(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove10);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove11);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 , spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 49;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(801,0);//主力
            public Spot spots2 = new Spot(799,1);//主力

            public TeamMove teammove1 = new TeamMove(799, 797, 1,1);
            public TeamMove teammove2 = new TeamMove(801, 802, 1,0);//
            public TeamMove teammove3 = new TeamMove(802, 798, 1,0);//
            public TeamMove teammove4 = new TeamMove(798, 796, 1,0);

            public TeamMove teammove5 = new TeamMove(796, 792, 1,0);
            public TeamMove teammove6 = new TeamMove(792, 787, 1,0);//
            public TeamMove teammove7 = new TeamMove(787, 789, 1,0);//
            public TeamMove teammove8 = new TeamMove(789, 783, 1,0);

            public TeamMove teammove9 = new TeamMove(783, 780, 1,0);
            public TeamMove teammove10 = new TeamMove(780, 778, 1,0);//
            public TeamMove teammove11 = new TeamMove(778, 777, 1,0);//




            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map5_6
        {
            public static MissionType missionType = MissionType.Normal;
            public map5_6(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 50;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(803, 0);
            public Spot spots2 = new Spot(807, 1);

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(803, 808, 1, 0);
            public TeamMove teammove2 = new TeamMove(808, 813, 1, 0);
            public TeamMove teammove3 = new TeamMove(813, 820, 1, 0);
            public TeamMove teammove4 = new TeamMove(820, 826, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;


        }
        public class map6_1
        {
            public map6_1(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 55;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(1511,0);//主力
            public Spot spots2 = new Spot(1511,1);//主力


            public TeamMove teammove1 = new TeamMove(1511, 1512, 1,0);
            public TeamMove teammove2 = new TeamMove(1512, 1513, 1,0);
            public TeamMove teammove3 = new TeamMove(1513, 1521, 1,0);
            public TeamMove teammove4 = new TeamMove(1521, 1515, 1,0);

            public TeamMove teammove5 = new TeamMove(1515, 1520, 1,0);
            public TeamMove teammove6 = new TeamMove(1520, 1523, 1,0);
            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map6_2
        {
            public map6_2(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 56;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(1524,0);//主力
            public Spot spots2 = new Spot(1524,1);//主力

            public TeamMove teammove1 = new TeamMove(1524, 1529, 1,0);
            public TeamMove teammove2 = new TeamMove(1529, 1531, 1,0);
            public TeamMove teammove3 = new TeamMove(1531, 1533, 1,0);
            public TeamMove teammove4 = new TeamMove(1533, 1535, 1,0);

            public TeamMove teammove5 = new TeamMove(1535, 1537, 1,0);

            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map6_3
        {
            public map6_3(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 57;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(1543,0);//主力
            public Spot spots2 = new Spot(1543,1);//主力


            public TeamMove teammove1 = new TeamMove(1543, 1538, 1,0);
            public TeamMove teammove2 = new TeamMove(1538, 1539, 1,0);
            public TeamMove teammove3 = new TeamMove(1539, 1540, 1,0);
            public TeamMove teammove4 = new TeamMove(1540, 1542, 1,0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map6_4
        {
            public map6_4(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 58;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(1578,0);//主力
            public Spot spots2 = new Spot(1578,1);//主力


            public TeamMove teammove1 = new TeamMove(1578, 1750, 1,0);
            public TeamMove teammove2 = new TeamMove(1750, 1574, 1,0);
            public TeamMove teammove3 = new TeamMove(1574, 1752, 1,0);
            public TeamMove teammove4 = new TeamMove(1752, 1575, 1,0);

            public TeamMove teammove5 = new TeamMove(1575, 1580, 1,0);
            public TeamMove teammove6 = new TeamMove(1580, 1576, 1,0);
            public TeamMove teammove7 = new TeamMove(1576, 1569, 1,0);
            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map6_5
        {
            public map6_5(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 59;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot[] Mission_Start_spots;
            public Spot spots1 = new Spot(1592,0);//主力
            public Spot spots2 = new Spot(1592,1);//主力


            public TeamMove teammove1 = new TeamMove(1592, 1601, 1,0);
            public TeamMove teammove2 = new TeamMove(1601, 1600, 1,0);
            public TeamMove teammove3 = new TeamMove(1600, 1599, 1,0);
            public TeamMove teammove4 = new TeamMove(1599, 1591, 1,0);

            public TeamMove teammove5 = new TeamMove(1591, 1583, 1,0);
            public TeamMove teammove6 = new TeamMove(1583, 1581, 1,0);
            public TeamMove teammove7 = new TeamMove(1581, 1579, 1,0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map6_6
        {
            public static MissionType missionType = MissionType.Normal;
            public map6_6(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 60;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(1616, 0);//主力
            public Spot spots2 = new Spot(1618, 1);//辅助

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(1616, 1634, 1, 0);
            public TeamMove teammove2 = new TeamMove(1634, 1635, 1, 0);
            public TeamMove teammove3 = new TeamMove(1635, 1620, 1, 0);
            public TeamMove teammove4 = new TeamMove(1620, 1621, 1, 0);
            public TeamMove teammove5 = new TeamMove(1621, 1636, 1, 0);
            public TeamMove teammove6 = new TeamMove(1636, 1632, 1, 0);
            public TeamMove teammove7 = new TeamMove(1632, 1633, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;


        }

        public class map8_6
        {
            public static MissionType missionType = MissionType.Normal;
            public map8_6(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 80;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(3788, 0);
            public Spot spots2 = new Spot(3788, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(3788, 3658, 1, 0);
            public TeamMove teammove2 = new TeamMove(3658, 3789, 1, 0);
            public TeamMove teammove3 = new TeamMove(3789, 3662, 1, 0);

            public TeamMove teammove4 = new TeamMove(3662, 3679, 1, 0);
            public TeamMove teammove5 = new TeamMove(3679, 3681, 1, 0);
            public TeamMove teammove6 = new TeamMove(3681, 3682, 1, 0);

            public TeamMove teammove7 = new TeamMove(3682, 3667, 1, 0);
            public TeamMove teammove8 = new TeamMove(3667, 3673, 1, 0);
            public TeamMove teammove9 = new TeamMove(3673, 3664, 1, 0);

            public TeamMove teammove10 = new TeamMove(3664, 3670, 1, 0);
            public TeamMove teammove11 = new TeamMove(3670, 3669, 1, 0);

            public TeamMove teammove12 = new TeamMove(3669, 3678, 1, 0);
            public TeamMove teammove13 = new TeamMove(3678, 3671, 1, 0);
            public TeamMove teammove14 = new TeamMove(3671, 3677, 1, 0);
            public TeamMove teammove15 = new TeamMove(3677, 3668, 1, 0);












            public Dictionary<int, TeamMove> dic_TeamMove;


            public int HomePos1(string result)
            {
                if (result.Contains("error")) return 0;//不需要打
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["enemy_move"];
                foreach (JsonData item in jsonData)
                {
                    if (item["from_spot_id"].Int == 3657 && item["to_spot_id"].Int == 3788)
                        return 1;//需要打

                }
                return 0;//不需要打
            }
            public int HomePos2(string result)
            {
                if (result.Contains("error")) return 0;//不需要打
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["enemy_move"];
                foreach (JsonData item in jsonData)
                {
                    if (item["from_spot_id"].Int == 3681 && item["to_spot_id"].Int == 3679)
                        return 1;//需要打
                    if (item["from_spot_id"].Int == 3681 && item["to_spot_id"].Int == 3682)
                        return 2;//需要打
                }
                return 0;//不需要打
            }
            public int HomePos3(string result)
            {
                if (result.Contains("error")) return 0;//不需要打
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["enemy_move"];
                foreach (JsonData item in jsonData)
                {
                    if (item["from_spot_id"].Int == 3683 && item["to_spot_id"].Int == 3679)
                        return 1;//需要打
                }
                return 0;//不需要打
            }
            public int PosCheck1(string result)
            {
                if (result.Contains("error")) return 0;//不需要打
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["enemy_move"];
                foreach (JsonData item in jsonData)
                {
                    if (item["to_spot_id"].Int == 3682)
                        return 1;//需要打
                }
                return 0;//不需要打
            }
            public int PosCheck2(string result)
            {
                if (result.Contains("error")) return 0;//不需要打
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["enemy_move"];
                foreach (JsonData item in jsonData)
                {
                    if (item["to_spot_id"].Int == 3679)
                        return 1;//需要打
                }
                return 0;//不需要打
            }
        }

        public class map10_6
        {
            public static MissionType missionType = MissionType.Normal;
            public map10_6(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 100;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(5363, 0);
            public Spot spots2 = new Spot(5363, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(5363, 5360, 1, 0);
            public TeamMove teammove2 = new TeamMove(5360, 5357, 1, 0);
            public TeamMove teammove3 = new TeamMove(5357, 5346, 1, 0);


            public Dictionary<int, TeamMove> dic_TeamMove;


        }


        public class map7_6boss
        {
            public static MissionType missionType = MissionType.Normal;
            public map7_6boss(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 70;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(1948, 0);
            public Spot spots2 = new Spot(1948, 1);//辅助

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(1948, 1947, 1, 0);
            public TeamMove teammove2 = new TeamMove(1947, 1948, 2, 0);
            public TeamMove teammove3 = new TeamMove(1948, 1947, 2, 0);

            public TeamMove teammove4 = new TeamMove(1947, 1946, 1, 0);
            public TeamMove teammove5 = new TeamMove(1946, 2152, 1, 0);
            public TeamMove teammove6 = new TeamMove(2152, 1941, 1, 0);
            public TeamMove teammove7 = new TeamMove(1941, 1942, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;

            public int withdrawSpot = 1948;//撤离
        }


        public class map10_4e
        {
            public static MissionType missionType = MissionType.Normal;
            public map10_4e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 104;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(5494, 0);
            public Spot spots2 = new Spot(5480, 1);//辅助

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(5494, 5495, 1, 0);
            public TeamMove teammove2 = new TeamMove(5495, 5492, 1, 0);
            public TeamMove teammove3 = new TeamMove(5492, 5495, 1, 0);
            public TeamMove teammove4 = new TeamMove(5495, 5494, 1, 0);
            public TeamMove teammove5 = new TeamMove(5494, 5497, 1, 0);
            public TeamMove teammove6 = new TeamMove(5497, 5494, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;

            public int withdrawSpot = 5494;//撤离
        }

        public class map7_6
        {
            public static MissionType missionType = MissionType.Normal;
            public map7_6(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 70;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(1948, 0);
            public Spot spots2 = new Spot(1948, 1);//辅助

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(1948, 1947, 1, 0);
            public TeamMove teammove2 = new TeamMove(1947, 1949, 1, 0);
            public TeamMove teammove3 = new TeamMove(1949, 1947, 1, 0);
            public TeamMove teammove4 = new TeamMove(1947, 1948, 2, 0);


            public Dictionary<int, TeamMove> dic_TeamMove;

            public int withdrawSpot = 1948;//撤离
        }


        public class map1_1e
        {
            public map1_1e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 11;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(151, 0);
            public Spot spots2 = new Spot(151, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(151, 152, 1, 0);
            public TeamMove teammove2 = new TeamMove(152, 153, 1, 0);
            public TeamMove teammove3 = new TeamMove(153, 158, 1, 0);
            public TeamMove teammove4 = new TeamMove(158, 159, 1, 0);



            public Dictionary<int, TeamMove> dic_TeamMove;

            public int withdrawSpot = 5494;//撤离
        }
        public class map1_2e
        {
            public map1_2e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 12;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public static MissionType missionType = MissionType.Normal;
            public Spot spots1 = new Spot(160, 0);
            public Spot spots2 = new Spot(160, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(160, 162, 1, 0);
            public TeamMove teammove2 = new TeamMove(162, 163, 1, 0);
            public TeamMove teammove3 = new TeamMove(163, 166, 1, 0);
            public TeamMove teammove4 = new TeamMove(166, 168, 1, 0);
            public TeamMove teammove5 = new TeamMove(168, 170, 1, 0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map1_3e
        {
            public map1_3e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 13;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(171, 0);//主力
            public Spot spots2 = new Spot(171, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(171, 173, 1, 0);
            public TeamMove teammove2 = new TeamMove(173, 176, 1, 0);
            public TeamMove teammove3 = new TeamMove(176, 180, 1, 0);
            public TeamMove teammove4 = new TeamMove(180, 183, 1, 0);
            public TeamMove teammove5 = new TeamMove(183, 184, 1, 0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map1_4e
        {
            public map1_4e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 14;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(185, 0);//主力
            public Spot spots2 = new Spot(185, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(185, 186, 1, 0);
            public TeamMove teammove2 = new TeamMove(186, 187, 1, 0);
            public TeamMove teammove3 = new TeamMove(187, 191, 1, 0);
            public TeamMove teammove4 = new TeamMove(191, 188, 1, 0);

            public TeamMove teammove5 = new TeamMove(188, 196, 1, 0);
            public TeamMove teammove6 = new TeamMove(196, 200, 1, 0);
            public TeamMove teammove7 = new TeamMove(200, 201, 1, 0);
            public TeamMove teammove8 = new TeamMove(201, 198, 1, 0);
            public TeamMove teammove9 = new TeamMove(198, 199, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map2_1e
        {
            public map2_1e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 21;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(284, 0);//主力
            public Spot spots2 = new Spot(277, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(284, 286, 1, 0);
            public TeamMove teammove2 = new TeamMove(286, 285, 1, 0);
            public TeamMove teammove3 = new TeamMove(285, 281, 1, 0);




            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map2_2e
        {
            public map2_2e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                Spots.Add(Spots.Count, spots1);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 22;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(290, 0);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(290, 292, 1, 0);
            public TeamMove teammove2 = new TeamMove(292, 295, 1, 0);
            public TeamMove teammove3 = new TeamMove(295, 294, 1, 0);
            public TeamMove teammove4 = new TeamMove(294, 297, 1, 0);
            public TeamMove teammove5 = new TeamMove(297, 298, 1, 0);
            public TeamMove teammove6 = new TeamMove(298, 300, 1, 0);



            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map2_3e
        {
            public map2_3e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 23;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(302, 0);//主力
            public Spot spots2 = new Spot(302, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(302, 304, 1, 0);
            public TeamMove teammove2 = new TeamMove(304, 309, 1, 0);
            public TeamMove teammove3 = new TeamMove(309, 308, 1, 0);
            public TeamMove teammove4 = new TeamMove(308, 316, 1, 0);




            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map2_4e
        {
            public map2_4e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 24;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(317, 0);//主力
            public Spot spots2 = new Spot(302, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(317, 318, 1, 0);
            public TeamMove teammove2 = new TeamMove(318, 320, 1, 0);
            public TeamMove teammove3 = new TeamMove(320, 324, 1, 0);
            public TeamMove teammove4 = new TeamMove(324, 328, 1, 0);




            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map3_1e
        {
            public map3_1e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 31;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(449, 0);//主力
            public Spot spots2 = new Spot(449, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(449, 446, 1, 0);
            public TeamMove teammove2 = new TeamMove(446, 442, 1, 0);
            public TeamMove teammove3 = new TeamMove(442, 440, 1, 0);
            public TeamMove teammove4 = new TeamMove(440, 439, 1, 0);
            public TeamMove teammove5 = new TeamMove(439, 438, 1, 0);



            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map3_2e
        {
            public map3_2e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 32;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(452, 0);//主力
            public Spot spots2 = new Spot(452, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(452, 455, 1, 0);
            public TeamMove teammove2 = new TeamMove(455, 459, 1, 0);
            public TeamMove teammove3 = new TeamMove(459, 462, 1, 0);
            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map3_3e
        {
            public map3_3e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 33;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(479, 0);//主力
            public Spot spots2 = new Spot(465, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(479, 478, 1, 0);
            public TeamMove teammove2 = new TeamMove(478, 481, 1, 0);
            public TeamMove teammove3 = new TeamMove(481, 480, 1, 0);




            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map3_4e
        {
            public map3_4e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 34;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(494, 0);//主力
            public Spot spots2 = new Spot(498, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(494, 489, 1, 0);
            public TeamMove teammove2 = new TeamMove(489, 490, 1, 0);
            public TeamMove teammove3 = new TeamMove(490, 491, 1, 0);
            public TeamMove teammove4 = new TeamMove(491, 492, 1, 0);



            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }


        public class map4_1e
        {
            public map4_1e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 41;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(612, 0);//主力
            public Spot spots2 = new Spot(609, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(612, 613, 1, 0);
            public TeamMove teammove2 = new TeamMove(613, 617, 1, 0);
            public TeamMove teammove3 = new TeamMove(617, 620, 1, 0);
            public TeamMove teammove4 = new TeamMove(620, 621, 1, 0);
            public TeamMove teammove5 = new TeamMove(621, 623, 1, 0);
            public TeamMove teammove6 = new TeamMove(623, 625, 1, 0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map4_2e
        {
            public map4_2e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 42;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(642, 0);//主力
            public Spot spots2 = new Spot(630, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(642, 641, 1, 0);
            public TeamMove teammove2 = new TeamMove(641, 637, 1, 0);
            public TeamMove teammove3 = new TeamMove(637, 640, 1, 0);
            public TeamMove teammove4 = new TeamMove(640, 639, 1, 0);



            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }

        public class map4_3e
        {
            public map4_3e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 , spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 43;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(658, 0);//主力
            public Spot spots2 = new Spot(643, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(658, 659, 1, 0);
            public TeamMove teammove2 = new TeamMove(659, 660, 1, 0);
            public TeamMove teammove3 = new TeamMove(660, 661, 1, 0);
            public TeamMove teammove4 = new TeamMove(661, 662, 1, 0);



            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map4_4e
        {
            public map4_4e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 44;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(664, 0);//主力
            public Spot spots2 = new Spot(669, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(664, 670, 1, 0);
            public TeamMove teammove2 = new TeamMove(670, 676, 1, 0);
            public TeamMove teammove3 = new TeamMove(676, 680, 1, 0);
            public TeamMove teammove4 = new TeamMove(680, 686, 1, 0);



            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map5_1e
        {
            public map5_1e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove10);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove11);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove12);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove13);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove14);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 ,spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 51;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(832, 0);//主力
            public Spot spots2 = new Spot(850, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(832, 833, 1, 0);
            public TeamMove teammove2 = new TeamMove(833, 837, 1, 0);
            public TeamMove teammove3 = new TeamMove(837, 841, 1, 0);
            public TeamMove teammove4 = new TeamMove(841, 843, 1, 0);

            public TeamMove teammove5 = new TeamMove(843, 844, 1, 0);
            public TeamMove teammove6 = new TeamMove(850, 846, 1, 1);
            public TeamMove teammove7 = new TeamMove(846, 850, 1, 1);
            public TeamMove teammove8 = new TeamMove(850, 851, 1, 1);

            public TeamMove teammove9 = new TeamMove(844, 845, 1, 0);
            public TeamMove teammove10 = new TeamMove(845, 842, 1, 0);
            public TeamMove teammove11 = new TeamMove(842, 839, 1, 0);
            public TeamMove teammove12 = new TeamMove(839, 835, 1, 0);
            public TeamMove teammove13 = new TeamMove(835, 834, 1, 0);
            public TeamMove teammove14 = new TeamMove(834, 838, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map5_2e
        {
            public map5_2e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 52;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(857, 0);//主力
            public Spot spots2 = new Spot(877, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(857, 861, 1, 0);
            public TeamMove teammove2 = new TeamMove(861, 866, 1, 0);
            public TeamMove teammove3 = new TeamMove(866, 870, 1, 0);
            public TeamMove teammove4 = new TeamMove(870, 869, 1, 0);



            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map5_3e
        {
            public map5_3e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove10);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Spots.Add(Spots.Count, spots3);
                Mission_Start_spots = new Spot[] { spots1 , spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 53;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(907, 0);//主力
            public Spot spots2 = new Spot(905, 1);//主力
            public Spot spots3 = new Spot(907, 2);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(905, 903, 1, 0);//
            public TeamMove teammove2 = new TeamMove(907, 908, 1, 0);
            public TeamMove teammove3 = new TeamMove(908, 904, 1, 0);
            public TeamMove teammove4 = new TeamMove(904, 902, 1, 0);

            public TeamMove teammove5 = new TeamMove(902, 898, 1, 0);
            public TeamMove teammove6 = new TeamMove(898, 895, 1, 0);
            public TeamMove teammove7 = new TeamMove(895, 889, 1, 0);
            public TeamMove teammove8 = new TeamMove(889, 886, 1, 0);

            public TeamMove teammove9 = new TeamMove(886, 884, 1, 0);
            public TeamMove teammove10 = new TeamMove(884, 883, 1, 0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }
        public class map5_4e
        {
            public map5_4e(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 54;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(909, 0);//主力
            public Spot spots2 = new Spot(913, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(909, 914, 1, 0);
            public TeamMove teammove2 = new TeamMove(914, 919, 1, 0);
            public TeamMove teammove3 = new TeamMove(919, 926, 1, 0);
            public TeamMove teammove4 = new TeamMove(926, 932, 1, 0);



            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 5494;//撤离
        }


        public class map2_4n
        {
            public static MissionType missionType = MissionType.Normal;
            public map2_4n(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                Spots.Add(Spots.Count, spots1);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 90008;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(1330, 0);//主力


            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(1330, 1332, 1, 0);
            public TeamMove teammove2 = new TeamMove(1332, 1453, 1, 0);
            public TeamMove teammove3 = new TeamMove(1453, 1454, 1, 0);
            public TeamMove teammove4 = new TeamMove(1454, 1457, 1, 0);
            public TeamMove teammove5 = new TeamMove(1457, 1461, 1, 0);


            public Dictionary<int, TeamMove> dic_TeamMove;


            public int PosCheck1(string result)
            {
                if (result.Contains("error")) return 0;//不需要打
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["night_enemy"];
                foreach (JsonData item in jsonData)
                {
                    if (item["to_spot_id"].Int == 1453)
                        return 1;//需要打

                }
                return 0;//不需要打
            }
        }


        public class map3_4n
        {
            public static MissionType missionType = MissionType.Normal;
            public map3_4n(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove10);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove11);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove12);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove13);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove14);
                Spots.Add(Spots.Count, spots1);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 90012;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(1485, 0);//主力


            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(1485, 1347, 1, 0);
            public TeamMove teammove2 = new TeamMove(1347, 1503, 1, 0);
            public TeamMove teammove3 = new TeamMove(1503, 1504, 1, 0);
            public TeamMove teammove4 = new TeamMove(1504, 1505, 1, 0);//分支开始
            public TeamMove teammove5 = new TeamMove(1505, 1489, 1, 0);//分支1向上
            public TeamMove teammove6 = new TeamMove(1947, 1949, 1, 0);//分支2向左1
            public TeamMove teammove7 = new TeamMove(1949, 1947, 1, 0);//分支2向左2
            public TeamMove teammove8 = new TeamMove(1505, 1509, 1, 0);//分支3
            public TeamMove teammove9 = new TeamMove(1509, 1506, 1, 0);//分支3
            public TeamMove teammove10 = new TeamMove(1509, 1507, 1, 0);//分支3
            public TeamMove teammove11 = new TeamMove(1489, 1506, 1, 0);
            public TeamMove teammove12 = new TeamMove(1489, 1490, 1, 0);
            public TeamMove teammove13 = new TeamMove(1489, 1501, 1, 0);
            public TeamMove teammove14 = new TeamMove(1489, 1476, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;



            public int withdrawSpot = 3033;//撤离

            public int BossPos(string result)
            {
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["night_enemy"];
                foreach (JsonData item in jsonData)
                {
                    if (item["enemy_team_id"].Int == 609)
                    {

                        if (item["to_spot_id"].Int == 1489) return 0;//机场上方

                        if (item["to_spot_id"].Int == 1505) return 1;//机场左测 到 机场

                        if (item["from_spot_id"].Int == 1509 && item["to_spot_id"].Int == 1506) return 2;//机场左测 到 上一格 

                        if (item["from_spot_id"].Int == 1509 && item["to_spot_id"].Int == 1507) return 3;//机场左测 到 机场左左侧

                        if (item["to_spot_id"].Int == 1509) return 4;//机场左左侧

                        if (item["from_spot_id"].Int == 1489 && item["to_spot_id"].Int == 1506) return 5;//机场上 到 左上机场

                        if (item["from_spot_id"].Int == 1489 && item["to_spot_id"].Int == 1490) return 6;//机场上 到 左上机场

                        if (item["from_spot_id"].Int == 1489 && item["to_spot_id"].Int == 1501) return 7;//机场上 到 左上机场

                        if (item["from_spot_id"].Int == 1489 && item["to_spot_id"].Int == 1476) return 8;//机场上 到 左上机场
                    }
                }
                return -1;//need abaort
            }
            public int rPos(string result)
            {
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["night_enemy"];
                foreach (JsonData item in jsonData)
                {
                    if (item.Contains("to_spot_id=1505")) return 1;//机场
                    if (item["enemy_team_id"].Int == 606)
                    {
                        switch (item["to_spot_id"].Int)
                        {
                            case 1505:
                                {
                                    return 1;//机场
                                }
                            default:
                                break;
                        }
                    }
                }
                return 0;//need abaort
            }



        }

        public class map5_2n
        {
            public static MissionType missionType = MissionType.Normal;
            public map5_2n(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 90018;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(3033, 0);//主力
            public Spot spots2 = new Spot(3057, 1);//辅助

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(3033, 3037, 1, 0);
            public TeamMove teammove2 = new TeamMove(3037, 3038, 1, 0);
            public TeamMove teammove3 = new TeamMove(3038, 3047, 1, 0);
            public TeamMove teammove4 = new TeamMove(3047, 3052, 1, 0);
            public TeamMove teammove5 = new TeamMove(3052, 3051, 1, 0);
            public TeamMove teammove6 = new TeamMove(3051, 3056, 1, 0);
            public TeamMove teammove7 = new TeamMove(3056, 3057, 2, 0);


            public Dictionary<int, TeamMove> dic_TeamMove;



            public int withdrawSpot = 3057;//撤离
        }

        public class map6_4n
        {
            public static MissionType missionType = MissionType.Normal;
            public map6_4n(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 90024;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(4066, 0);//主力
            public Spot spots2 = new Spot(4070, 1);//主力

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(4066, 4067, 1, 0);
            public TeamMove teammove2 = new TeamMove(4067, 4077, 1, 0);
            public TeamMove teammove3 = new TeamMove(4077, 4078, 1, 0);
            public TeamMove teammove4 = new TeamMove(4078, 4082, 1, 0);//分支开始
            public TeamMove teammove5 = new TeamMove(4082, 4079, 1, 0);//分支1向上
            public TeamMove teammove6 = new TeamMove(4079, 4068, 1, 0);//分支2向左1
            public TeamMove teammove7 = new TeamMove(4068, 4079, 1, 0);//分支2向左2
            public TeamMove teammove8 = new TeamMove(4079, 4082, 1, 0);//分支3


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 4082;//撤离
        }
        public class map8_1n
        {
            public map8_1n(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 90029;
            public static MissionType missionType = MissionType.Normal;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7069, 0);//主力
            public Spot spots2 = new Spot(7066, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7069, 7076, 1, 0);
            public TeamMove teammove2 = new TeamMove(7076, 7068, 1, 0);
            public TeamMove teammove3 = new TeamMove(7068, 7067, 1, 0);

            public TeamMove teammove4 = new TeamMove(7067, 7075, 1, 0);
            public TeamMove teammove5 = new TeamMove(7075, 7074, 1, 0);
            public TeamMove teammove6 = new TeamMove(7074, 7066, 2, 0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 7066;//撤离

        }

        public class mapequip_ump
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public mapequip_ump(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Spots.Add(Spots.Count, spots3);
                Mission_Start_spots = new Spot[] { spots1, spots2, spots3 };
                Function.init(dic_TeamMove, Spots, ubti);
            }


            public static MissionType missionType = MissionType.Activity;

            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public int mission_id = 10040;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public Spot spots1 = new Spot(4574,0);//主力
            public Spot spots2 = new Spot(4559,1);//辅助
            public Spot spots3 = new Spot(4567,2);//辅助


            public TeamMove teammove1 = new TeamMove(4574, 4572, 1,0);
            public TeamMove teammove2 = new TeamMove(4572, 4582, 1,0);
            public TeamMove teammove3 = new TeamMove(4582, 4573, 1,0);
            public TeamMove teammove4 = new TeamMove(4573, 4583, 1,0);
            public TeamMove teammove5 = new TeamMove(4583, 4555, 1,0);

            public TeamMove teammove6 = new TeamMove(4555, 4568, 1,0);
            public TeamMove teammove7 = new TeamMove(4568, 4603, 1,0);
            public TeamMove teammove8 = new TeamMove(4603, 4568, 1,0);
            public Spot[] Mission_Start_spots;
            public Dictionary<int, TeamMove> dic_TeamMove;

            public int withdrawSpot1 = 4559;//撤离
            public int withdrawSpot2 = 4568;//撤离
        }

        public class mapcubee1_4
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcubee1_4(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10021;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(3243, 0);//主力
            public Spot spots2 = new Spot(3243, 1);//主力

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(3243, 3244, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(3244, 3245, 1, 0);
            public TeamMove teammove3 = new TeamMove(3245, 3246, 1, 0);
            public TeamMove teammove4 = new TeamMove(3246, 3247, 1, 0);
            public TeamMove teammove5 = new TeamMove(3247, 3240, 1, 0);
            public TeamMove teammove6 = new TeamMove(3240, 3233, 1, 0);
            public TeamMove teammove7 = new TeamMove(3233, 3234, 1, 0);
            public TeamMove teammove8 = new TeamMove(3234, 3235, 1, 0);


            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawSpot = 4082;//撤离
        }

        public class maparctic1_4
        {
            public maparctic1_4(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove10);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove11);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove12);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public static MissionType missionType = MissionType.Activity;
            public int mission_id = 10008;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(2054, 0);//主力
            public Spot spots2 = new Spot(2054, 1);//主力

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(2054, 2056, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(2056, 2057, 1, 0);
            public TeamMove teammove3 = new TeamMove(2057, 2210, 1, 0);
            public TeamMove teammove4 = new TeamMove(2210, 2259, 1, 0);
            public TeamMove teammove5 = new TeamMove(2259, 2260, 1, 0);
            public TeamMove teammove6 = new TeamMove(2260, 2261, 1, 0);
            public TeamMove teammove7 = new TeamMove(2261, 2262, 1, 0);
            public TeamMove teammove8 = new TeamMove(2262, 2263, 1, 0);

            public TeamMove teammove9 = new TeamMove(2263, 2264, 1, 0);
            public TeamMove teammove10 = new TeamMove(2264, 2253, 1, 0);
            public TeamMove teammove11 = new TeamMove(2253, 2252, 1, 0);

            public TeamMove teammove12 = new TeamMove(2252, 2060, 1, 0);


            public Dictionary<int, TeamMove> dic_TeamMove;

        }

        public class mapcorridor
        {
            public mapcorridor(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                Spots.Add(Spots.Count, spots1);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public mapcorridor() { }
            public int mission_id = 1503;
            public static MissionType missionType = MissionType.Simulation;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(5523, 0);//主力
            public Spot[] Mission_Start_spots;
            public TeamMove teammove1 = new TeamMove(5523, 5521, 1,0);
            public TeamMove teammove2 = new TeamMove(5521, 5522, 1,0);
            public TeamMove teammove3 = new TeamMove(5522, 5519, 1,0);
            public TeamMove teammove4 = new TeamMove(5519, 5524, 1,0);
            public TeamMove teammove5 = new TeamMove(5524, 5520, 1,0);


            public Dictionary<int, TeamMove> dic_TeamMove;
        }

        public class mapcte1_1
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_1(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);

                Spots.Add(Spots.Count, spots1);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10106;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7246, 0);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7246, 7245, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7245, 7239, 1, 0);
            public Dictionary<int, TeamMove> dic_TeamMove;
        }

        public class mapcte1_2
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_2(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);

                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove10);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove11);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove12);

                dic_TeamMove.Add(dic_TeamMove.Count, teammove13);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove14);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10108;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7255, 0);//主力
            public Spot spots2 = new Spot(7255, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7255, 7256, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7256, 7257, 1, 0);

            public TeamMove teammove3 = new TeamMove(7257, 7256, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(7256, 7262, 1, 0);

            public TeamMove teammove5 = new TeamMove(7262, 7256, 1, 0);//注意两个点哦
            public TeamMove teammove6 = new TeamMove(7256, 7260, 1, 0);

            public TeamMove teammove7 = new TeamMove(7260, 7264, 1, 0);//注意两个点哦
            public TeamMove teammove8 = new TeamMove(7264, 7260, 1, 0);

            public TeamMove teammove9 = new TeamMove(7260, 7256, 1, 0);//注意两个点哦
            public TeamMove teammove10 = new TeamMove(7256, 7255, 2, 0);


            public TeamMove teammove11 = new TeamMove(7255, 7259, 1, 0);//注意两个点哦
            public TeamMove teammove12 = new TeamMove(7259, 7255, 1, 0);

            public TeamMove teammove13 = new TeamMove(7255, 7263, 1, 0);//注意两个点哦
            public TeamMove teammove14 = new TeamMove(7263, 7258, 1, 0);



            public Dictionary<int, TeamMove> dic_TeamMove;
        }


        public class mapcte1_3
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_3(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10109;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7277, 0);//主力
            public Spot spots2 = new Spot(7255, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7277, 7265, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7265, 7276, 1, 0);

            public TeamMove teammove3 = new TeamMove(7276, 7274, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(7274, 7273, 1, 0);

            public TeamMove teammove5 = new TeamMove(7273, 7280, 1, 0);//注意两个点哦
            public TeamMove teammove6 = new TeamMove(7280, 7281, 1, 0);
            



            public Dictionary<int, TeamMove> dic_TeamMove;
        }

        public class mapcte1_4type1
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_4type1(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);


                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10110;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7282, 0);//主力
            public Spot spots2 = new Spot(7282, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7282, 7285, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7285, 7286, 1, 0);

            public TeamMove teammove3 = new TeamMove(7286, 7287, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(7287, 7296, 1, 0);






            public Dictionary<int, TeamMove> dic_TeamMove;
        }

        public class mapcte1_4type2//这个乱序不知道怎么写
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_4type2(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);


                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10110;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7282, 0);//主力
            public Spot spots2 = new Spot(7282, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7282, 7285, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7285, 7286, 1, 0);

            public TeamMove teammove3 = new TeamMove(7286, 7287, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(7287, 7296, 1, 0);






            public Dictionary<int, TeamMove> dic_TeamMove;
        }




        /// <summary>
        /// 别了稻草人 物资箱
        /// </summary>
        public class mapcte1_5
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_5(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);


                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10111;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7302, 0);//主力
            public Spot spots2 = new Spot(7302, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7302, 7305, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7305, 7307, 1, 0);

            public TeamMove teammove3 = new TeamMove(7307, 7313, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(7313, 7312, 1, 0);






            public Dictionary<int, TeamMove> dic_TeamMove;
        }

        public class mapcte1_6
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_6(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);


                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10110;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7282, 0);//主力
            public Spot spots2 = new Spot(7282, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7282, 7285, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7285, 7286, 1, 0);

            public TeamMove teammove3 = new TeamMove(7286, 7287, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(7287, 7296, 1, 0);






            public Dictionary<int, TeamMove> dic_TeamMove;
        }

        public class mapcte1_7
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_7(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);

                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove10);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove11);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove12);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove13);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove14);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove15);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove16);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove17);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove18);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove19);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove20);

                dic_TeamMove.Add(dic_TeamMove.Count, teammove21);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove22);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove23);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove24);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove25);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10113;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7326, 0);//主力
            public Spot spots2 = new Spot(7326, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7326, 7335, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7335, 7334, 1, 0);

            public TeamMove teammove3 = new TeamMove(7334, 7336, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(7336, 7333, 1, 0);

            public TeamMove teammove5 = new TeamMove(7333, 7328, 1, 0);//注意两个点哦
            public TeamMove teammove6 = new TeamMove(7328, 7337, 1, 0);

            public TeamMove teammove7 = new TeamMove(7337, 7328, 1, 0);//注意两个点哦
            public TeamMove teammove8 = new TeamMove(7328, 7330, 1, 0);

            public TeamMove teammove9 = new TeamMove(7330, 7343, 1, 0);//注意两个点哦
            public TeamMove teammove10 = new TeamMove(7343, 7342, 1, 0);


            public TeamMove teammove11 = new TeamMove(7342, 7343, 1, 0);//注意两个点哦
            public TeamMove teammove12 = new TeamMove(7343, 7330, 1, 0);
            public TeamMove teammove13 = new TeamMove(7330, 7328, 1, 0);//注意两个点哦
            public TeamMove teammove14 = new TeamMove(7328, 7330, 1, 0);

            public TeamMove teammove15 = new TeamMove(7330, 7332, 1, 0);//注意两个点哦
            public TeamMove teammove16 = new TeamMove(7332, 7338, 1, 0);
            public TeamMove teammove17 = new TeamMove(7338, 7341, 1, 0);//注意两个点哦
            public TeamMove teammove18 = new TeamMove(7341, 7339, 1, 0);

            public TeamMove teammove19 = new TeamMove(7339, 7340, 1, 0);
            public TeamMove teammove20 = new TeamMove(7340, 7339, 1, 0);//注意两个点哦
            public TeamMove teammove21 = new TeamMove(7339, 7341, 1, 0);

            public TeamMove teammove22 = new TeamMove(7341, 7338, 1, 0);
            public TeamMove teammove23 = new TeamMove(7338, 7332, 1, 0);
            public TeamMove teammove24 = new TeamMove(7332, 7330, 1, 0);//注意两个点哦
            public TeamMove teammove25 = new TeamMove(7330, 7328, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;
        }

        /// <summary>
        /// 和平谈判
        /// </summary>
        public class mapcte1_8
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_8(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);

                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10114;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7377, 0);//主力
            public Spot spots2 = new Spot(7377, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7377, 7351, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7351, 7379, 1, 0);

            public TeamMove teammove3 = new TeamMove(7379, 7402, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(7402, 7397, 1, 0);

            public TeamMove teammove5 = new TeamMove(7397, 7378, 1, 0);//注意两个点哦
            public TeamMove teammove6 = new TeamMove(7378, 7398, 1, 0);
            public TeamMove teammove7 = new TeamMove(7398, 7354, 1, 0);//注意两个点哦




            public Dictionary<int, TeamMove> dic_TeamMove;
        }

        /// <summary>
        /// 幸运
        /// </summary>
        public class mapcte1_11
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_11(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);

                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10115;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7403, 0);//主力
            public Spot spots2 = new Spot(7403, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7403, 7416, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7416, 7403, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;
        }


        public class mapcte1_11mp7
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_11mp7(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);

                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10115;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7403, 0);//主力
            public Spot spots2 = new Spot(7403, 1);//主力
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7403, 7414, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7414, 7403, 2, 0);
            public TeamMove teammove3 = new TeamMove(7403, 7411, 1, 0);
            public TeamMove teammove4 = new TeamMove(7411, 7412, 1, 0);

            public TeamMove teammove5 = new TeamMove(7412, 7424, 1, 0);//注意两个点哦
            public TeamMove teammove6 = new TeamMove(7424, 7407, 1, 0);
            public TeamMove teammove7 = new TeamMove(7407, 7411, 1, 0);
            public TeamMove teammove8 = new TeamMove(7411, 7403, 1, 0);
            public Dictionary<int, TeamMove> dic_TeamMove;
            public int withdrawTeam = 7403;
        }


        /// <summary>
        /// 铁血精英
        /// </summary>
        public class mapcte1_12
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_12(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                Spots.Add(Spots.Count, spots1);

                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10116;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7425, 0);//主力

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7425, 7436, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7436, 7447, 1, 0);
            public TeamMove teammove3 = new TeamMove(7447, 7430, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(7430, 7448, 1, 0);

            public TeamMove teammove5 = new TeamMove(7448, 7445, 1, 0);//注意两个点哦
            public TeamMove teammove6 = new TeamMove(7445, 7431, 1, 0);
            public TeamMove teammove7 = new TeamMove(7431, 7442, 1, 0);//注意两个点哦
            public TeamMove teammove8 = new TeamMove(7442, 7444, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;
        }


        /// <summary>
        /// 铁血精英
        /// </summary>
        public class mapcte1_13
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_13(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);

                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove10);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove11);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove12);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove13);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10117;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7455, 0);
            public Spot spots2 = new Spot(7461, 1);//
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7455, 7456, 1, 0);
            public TeamMove teammove2 = new TeamMove(7456, 7457, 1, 0);
            public TeamMove teammove3 = new TeamMove(7457, 7458, 1, 0);
            public TeamMove teammove4 = new TeamMove(7458, 7459, 1, 0);

            public TeamMove teammove5 = new TeamMove(7459, 7461, 1, 0);//注意两个点哦
            public TeamMove teammove6 = new TeamMove(7461, 7463, 1, 0);
            public TeamMove teammove7 = new TeamMove(7463, 7462, 1, 0);//注意两个点哦
            public TeamMove teammove8 = new TeamMove(7462, 7439, 1, 0);

            public TeamMove teammove9 = new TeamMove(7439, 7434, 1, 0);//注意两个点哦
            public TeamMove teammove10 = new TeamMove(7434, 7439, 1, 0);
            public TeamMove teammove11 = new TeamMove(7439, 7462, 1, 0);//注意两个点哦
            public TeamMove teammove12 = new TeamMove(7462, 7463, 1, 0);

            public TeamMove teammove13 = new TeamMove(7463, 7461, 2, 0);
            public Dictionary<int, TeamMove> dic_TeamMove;

            public int withdrawTeam = 7461;
        }

        /// <summary>
        /// 最卑鄙的愿望 打捞
        /// </summary>
        public class mapcte1_14
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_14(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Mission_Start_spots = new Spot[] { spots1, spots2};
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10118;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7904, 0);
            public Spot spots2 = new Spot(7464, 1);//
            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7904, 7476, 1, 0);
            public TeamMove teammove2 = new TeamMove(7476, 7477, 1, 0);
            public TeamMove teammove3 = new TeamMove(7477, 7475, 1, 0);
            public TeamMove teammove4 = new TeamMove(7475, 7492, 1, 0);

            public TeamMove teammove5 = new TeamMove(7492, 7491, 1, 0);
            public TeamMove teammove6 = new TeamMove(7491, 7479, 1, 0);
            public TeamMove teammove7 = new TeamMove(7479, 7494, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;

            public int withdrawTeam = 7461;
        }

        /// <summary>
        /// 格里芬敢死队
        /// </summary>
        public class mapcte2_4
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte2_4(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);


                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10122;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(8337, 0);//主力
            public Spot spots2 = new Spot(7530, 1);//主力


            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(8337, 7528, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7528, 7531, 1, 0);

            public TeamMove teammove3 = new TeamMove(7531, 7536, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(7536, 7526, 1, 0);

            public Dictionary<int, TeamMove> dic_TeamMove;
        }


        public class mapcte2_9
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte2_9(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);

                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);

                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);
                Spots.Add(Spots.Count, spots3);
                Spots.Add(Spots.Count, spots4);

                Mission_Start_spots = new Spot[] { spots1, spots2, spots3, spots4 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10129;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7716, 0);//主力
            public Spot spots2 = new Spot(7713, 1);//主力
            public Spot spots3 = new Spot(7715, 2);//主力
            public Spot spots4 = new Spot(7714, 3);//主力

            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7716, 7732, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7732, 7719, 1, 0);

            public TeamMove teammove3 = new TeamMove(7719, 8532, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(8532, 8552, 1, 0);

            public TeamMove teammove5 = new TeamMove(8552, 8554, 1, 0);//注意两个点哦
            public TeamMove teammove6 = new TeamMove(8554, 7718, 1, 0);
            public TeamMove teammove7 = new TeamMove(7718, 8531, 1, 0);//注意两个点哦

            public TeamMove teammove8 = new TeamMove(8531, 8551, 1, 0);
            public TeamMove teammove9 = new TeamMove(8551, 7733, 1, 0);//注意两个点哦


            public Dictionary<int, TeamMove> dic_TeamMove;
        }

        public class mapcte2_15
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte2_15(Normal_MissionInfo ubti)
            {
                dic_TeamMove = new Dictionary<int, TeamMove>();
                dic_TeamMove.Add(dic_TeamMove.Count, teammove1);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove2);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove3);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove4);

                dic_TeamMove.Add(dic_TeamMove.Count, teammove5);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove6);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove7);

                dic_TeamMove.Add(dic_TeamMove.Count, teammove8);
                dic_TeamMove.Add(dic_TeamMove.Count, teammove9);
                Spots.Add(Spots.Count, spots1);
                Spots.Add(Spots.Count, spots2);


                Mission_Start_spots = new Spot[] { spots1, spots2 };
                Function.init(dic_TeamMove, Spots, ubti);
            }
            public int mission_id = 10128;
            public Dictionary<int, Spot> Spots = new Dictionary<int, Spot>();
            public Spot spots1 = new Spot(7686, 0);//主力
            public Spot spots2 = new Spot(7711, 1);//主力


            public Spot[] Mission_Start_spots;

            public TeamMove teammove1 = new TeamMove(7686, 7698, 1, 0);//注意两个点哦
            public TeamMove teammove2 = new TeamMove(7698, 7687, 1, 0);
            public TeamMove teammove3 = new TeamMove(7687, 7701, 1, 0);//注意两个点哦
            public TeamMove teammove4 = new TeamMove(7701, 7696, 1, 0);

            public TeamMove teammove5 = new TeamMove(7696, 7708, 1, 0);//注意两个点哦
            public TeamMove teammove6 = new TeamMove(7708, 7688, 1, 0);

            public TeamMove teammove7 = new TeamMove(7688, 8504, 1, 0);//注意两个点哦
            public TeamMove teammove8 = new TeamMove(8504, 8519, 1, 0);

            public TeamMove teammove9 = new TeamMove(8519, 7693, 1, 0);//注意两个点哦


            public Dictionary<int, TeamMove> dic_TeamMove;
        }

        public class mapcte1start
        {
            public static MissionType missionType = MissionType.Activity;
        }

        public class mapctbox
        {
            public static MissionType missionType = MissionType.Activity;
        }







    }
}

using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using static GFHelp.Mission.Map_Controller;

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
            public static void init(Dictionary<int, TeamMove.Data> dic_TeamMove, Spot spots, MissionInfo.Data data)
            {
                for (int i = 0; i < dic_TeamMove.Count; i++)
                {
                    dic_TeamMove[i].team_id = data.Teams[dic_TeamMove[i].teamLOC].TeamID;
                }
                for (int i = 0; i < spots.dic.Count; i++)
                {
                    spots.dic[i].team_id = data.Teams[spots.dic[i].team_loc].TeamID;
                }
            }




            public static List<int> getTeamAvailable(UserData userData,int Require)
            {
                List<int> lisID = new List<int>();
                int count = 0;
                foreach (var item in userData.Teams)
                {
                    //if (lisID.Count == Require) return lisID;
                    //if (userData.battle.startMission(map, data) == 1)
                    //{
                    //    return true;
                    //}




                }

                return new List<int>();
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





        public class map0_1 : mapbase
        {
            public map0_1(MissionInfo.Data data)
            {
                mission_id = 1;

                teamMove.Add(1, 2, 1, 0);
                teamMove.Add(2, 3, 1, 0);
                teamMove.Add(3, 4, 1, 0);
                teamMove.Add(4, 5, 1, 0);
                teamMove.Add(5, 6, 1, 0);
                Spots.Add(1, 0);//主力
                Spots.Add(1, 1);//辅助
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 3033;//撤离
            }

            public static MissionType missionType = MissionType.Normal;
            



        }

        public class maptest
        {
            public static MissionType missionType = MissionType.Normal;
        }

        public class mapnormal
        {
            public static MissionType missionType = MissionType.Normal;
        }
        public class mapnormal_boss
        {
            public static MissionType missionType = MissionType.Normal;
        }



        public class mapemergency
        {
            public static MissionType missionType = MissionType.Normal;
        }
        public class map0_2 : mapbase
        {
            public map0_2(MissionInfo.Data data)
            {
                teamMove.Add(9, 17, 1, 0);
                teamMove.Add(17, 18, 1, 0);
                teamMove.Add(18, 19, 1, 0);
                teamMove.Add(19, 16, 1, 0);
                teamMove.Add(16, 23, 1, 0);
                teamMove.Add(23, 25, 1, 0);
                Spots.Add(9, 0);//主力
                Spots.Add(12, 1);//辅助
                mission_id = 2;
                withdrawSpot = 3033;//撤离
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]};
                Function.init(teamMove.dic, Spots, data);
            }

            public static MissionType missionType = MissionType.Normal;

            


        }

        public class map1_1n : mapbase
        {
            public map1_1n(MissionInfo.Data data)
            {
                teamMove.Add(1309, 1348, 1, 0);//0
                teamMove.Add(1309, 1310, 1, 1);//1

                teamMove.Add(1348, 1351, 1, 0);//2
                teamMove.Add(1351, 1352, 1, 0);//3
                teamMove.Add(1348, 1349, 1, 0);//4
                teamMove.Add(1349, 1352, 1, 0);//5



                Spots.Add(1309, 0);//主力
                Spots.Add(1309, 1);//辅助
                mission_id = 90001;
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
            }

            public static MissionType missionType = MissionType.Normal;




        }




        public class map1_1 : mapbase
        {
            //要给Spots.dic[0] 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public map1_1(MissionInfo.Data data)
            {

                teamMove.Add(88, 89, 1, 0);
                teamMove.Add(89, 90, 1, 0);

                Spots.Add(88, 0);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 5;
            }

            public static MissionType missionType = MissionType.Normal;









        }
        public class map1_2 : mapbase
        {
            //要给Spots.dic[0] 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public map1_2(MissionInfo.Data data)
            {

                teamMove.Add(92, 93, 1, 0);
                teamMove.Add(93, 94, 1, 0);
                teamMove.Add(94, 95, 1, 0);
                teamMove.Add(95, 96, 1, 0);
                Spots.Add(92, 0);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 6;
            }

            public static MissionType missionType = MissionType.Normal;









        }



        public class map1_6 : mapbase
        {
            public map1_6(MissionInfo.Data data)
            {
                mission_id = 10;
                teamMove.Add(133, 134, 1, 0);
                teamMove.Add(134, 135, 1, 0);
                teamMove.Add(135, 139, 1, 0);
                teamMove.Add(139, 136, 1, 0);
                teamMove.Add(136, 144, 1, 0);
                teamMove.Add(144, 148, 1, 0);
                teamMove.Add(148, 149, 1, 0);
                teamMove.Add(149, 146, 1, 0);
                teamMove.Add(146, 147, 1, 0);
                Spots.Add(133, 0);
                Spots.Add(133, 1);
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]};
                withdrawSpot = 1948;//撤离
                Function.init(teamMove.dic, Spots, data);
            }

            public static MissionType missionType = MissionType.Normal;



            





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
        }


        public class map2_2 : mapbase
        {
            public map2_2(MissionInfo.Data data)
            {

                teamMove.Add(210, 213, 1, 0);
                teamMove.Add(213, 212, 1, 0);
                teamMove.Add(212, 215, 1, 0);
                teamMove.Add(215, 216, 1, 0);
                teamMove.Add(216, 218, 1, 0);
                teamMove.Add(218, 219, 1, 0);
                Spots.Add(210, 0);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
            };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 16;
            }

            public static MissionType missionType = MissionType.Normal;



            




        }
        public class map2_3 : mapbase
        {
            public map2_3(MissionInfo.Data data)
            {
                mission_id = 17;

                teamMove.Add(227, 229, 1, 0);
                teamMove.Add(229, 228, 1, 0);
                teamMove.Add(228, 224, 1, 0);
            Spots.Add(227, 0);//主力
            Spots.Add(220, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);
            }


            





        }

        public class map2_4 : mapbase
        {
            public map2_4(MissionInfo.Data data)
            {
                mission_id = 18;

                teamMove.Add(233, 235, 1, 0);
                teamMove.Add(235, 238, 1, 0);
                teamMove.Add(238, 240, 1, 0);
                teamMove.Add(240, 241, 1, 0);
                teamMove.Add(241, 243, 1, 0);
                Spots.Add(233, 0);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
            }
        }

        public class map2_5 : mapbase
        {
            public map2_5(MissionInfo.Data data)
            {
                mission_id = 19;
                teamMove.Add(245, 247, 1, 0);
                teamMove.Add(247, 252, 1, 0);
                teamMove.Add(252, 258, 1, 0);
                teamMove.Add(258, 259, 1, 0);
                Spots.Add(245, 0);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
            }


            



        }
        public class map2_6 : mapbase
        {
            public map2_6(MissionInfo.Data data)
            {
                mission_id = 20;
                teamMove.Add(260, 261, 1, 0);
                teamMove.Add(261, 263, 1, 0);
                teamMove.Add(263, 267, 1, 0);
                teamMove.Add(267, 271, 1, 0);
                Spots.Add(260, 0);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
            }

            public static MissionType missionType = MissionType.Normal;







            


        }
        public class map3_1 : mapbase
        {
            public map3_1(MissionInfo.Data data)
            {
                mission_id = 25;
                teamMove.Add(348, 350, 1, 0);
                teamMove.Add(350, 353, 1, 0);
                teamMove.Add(353, 356, 1, 0);
                Spots.Add(348, 0);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]};
                Function.init(teamMove.dic, Spots, data);
            }

            public static MissionType missionType = MissionType.Normal;



            










        }
        public class map3_2 : mapbase
        {
            public map3_2(MissionInfo.Data data)
            {
                mission_id = 26;
                teamMove.Add(370, 366, 1, 0);
                teamMove.Add(366, 368, 1, 0);
                teamMove.Add(368, 369, 1, 0);
                teamMove.Add(369, 364, 1, 0);
                Spots.Add(370, 0);//主力
                Spots.Add(358, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);
            }

            public static MissionType missionType = MissionType.Normal;





            



        }
        public class map3_3 : mapbase
        {
            public map3_3(MissionInfo.Data data)
            {
                mission_id = 27;
                teamMove.Add(382, 379, 1, 0);
                teamMove.Add(379, 375, 1, 0);
                teamMove.Add(375, 373, 1, 0);
                teamMove.Add(373, 372, 1, 0);
                teamMove.Add(372, 371, 1, 0);
                Spots.Add(382, 0);//主力
                Spots.Add(382, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
            }

            public static MissionType missionType = MissionType.Normal;







            

        }
        public class map3_4 : mapbase
        {
            public map3_4(MissionInfo.Data data)
            {
                mission_id = 28;
                teamMove.Add(385, 388, 1, 0);
                teamMove.Add(388, 392, 1, 0);
                teamMove.Add(392, 395, 1, 0);
                Spots.Add(385, 0);//主力
                Spots.Add(385, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
            }

            public static MissionType missionType = MissionType.Normal;




            





        }
        public class map3_5 : mapbase
        {
            public map3_5(MissionInfo.Data data)
            {
                mission_id = 29;
                teamMove.Add(412, 411, 1, 0);
                teamMove.Add(411, 414, 1, 0);
                teamMove.Add(414, 413, 1, 0);
                Spots.Add(412, 0);//主力
                Spots.Add(398, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);
            }

            public static MissionType missionType = MissionType.Normal;



            





        }
        public class map3_6 : mapbase
        {
            public map3_6(MissionInfo.Data data)
            {
                mission_id = 30;
                teamMove.Add(427, 422, 1, 0);
                teamMove.Add(422, 423, 1, 0);
                teamMove.Add(423, 424, 1, 0);
                teamMove.Add(424, 425, 1, 0);
                Spots.Add(427, 0);//主力
                Spots.Add(431, 1);//辅助
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 427;//撤离
            }
            public static MissionType missionType = MissionType.Normal;



            



        }
        public class map4_1 : mapbase
        {
            public map4_1(MissionInfo.Data data)
            {
                mission_id = 35;
                teamMove.Add(513, 512, 1, 0);
                teamMove.Add(512, 511, 1, 0);
                teamMove.Add(511, 509, 1, 0);
                teamMove.Add(509, 508, 1, 0);
                teamMove.Add(508, 509, 1, 0);


                Spots.Add(513, 0);//主力
                Spots.Add(516, 1);//辅助
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 5494;//撤离
            }

            public static MissionType missionType = MissionType.Normal;







        }
        public class map4_2 : mapbase
        {
            public map4_2(MissionInfo.Data data)
            {
                mission_id = 36;
                teamMove.Add(522, 521, 1, 0);
                teamMove.Add(521, 517, 1, 0);
                teamMove.Add(517, 518, 1, 0);
                teamMove.Add(518, 519, 1, 0);
                Spots.Add(522, 0);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 5494;//撤离
            }

            public static MissionType missionType = MissionType.Normal;

            





        }

        public class map4_3 : mapbase
        {
            public map4_3(MissionInfo.Data data)
            {
                mission_id = 37;
                teamMove.Add(531, 532, 1, 0);
                teamMove.Add(532, 536, 1, 0);
                teamMove.Add(536, 537, 1, 0);
                teamMove.Add(537, 540, 1, 0);
                teamMove.Add(540, 542, 1, 0);
                teamMove.Add(542, 544, 1, 0);
                Spots.Add(531, 0);//主力
                Spots.Add(528, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 5494;//撤离
            }

            public static MissionType missionType = MissionType.Normal;

            



        }
        public class map4_4 : mapbase
        {
            public map4_4(MissionInfo.Data data)
            {
                mission_id = 38;
                teamMove.Add(561, 560, 1, 0);
                teamMove.Add(560, 556, 1, 0);
                teamMove.Add(556, 559, 1, 0);
                teamMove.Add(559, 558, 1, 0);
                Spots.Add(561, 0);//主力
                Spots.Add(549, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 5494;//撤离
            }

            public static MissionType missionType = MissionType.Normal;

            




        }

        public class map4_5 : mapbase
        {
            public map4_5(MissionInfo.Data data)
            {
                teamMove.Add(577, 578, 1, 0);
                teamMove.Add(578, 579, 1, 0);
                teamMove.Add(579, 580, 1, 0);
                teamMove.Add(580, 581, 1, 0);

                Spots.Add(577, 0);//主力
                Spots.Add(562, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data);
                mission_id = 39;
                withdrawSpot = 5494;//撤离
            }

            public static MissionType missionType = MissionType.Normal;

            



        }
        public class map4_6 : mapbase
        {
            public map4_6(MissionInfo.Data data)
            {
                teamMove.Add(582, 588, 1, 0);
                teamMove.Add(588, 594, 1, 0);
                teamMove.Add(594, 598, 1, 0);
                teamMove.Add(598, 604, 1, 0);
                Spots.Add(582, 0);
                Spots.Add(587, 1);
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data); mission_id = 40;
            }

            public static MissionType missionType = MissionType.Normal;


            







        }
        public class map5_1 : mapbase
        {
            public map5_1(MissionInfo.Data data)
            {
                teamMove.Add(690, 691, 1, 0);
                teamMove.Add(691, 692, 1, 0);
                teamMove.Add(692, 693, 1, 0);
                teamMove.Add(693, 696, 1, 0);

                teamMove.Add(690, 691, 1, 1);//家里的梯队与战斗
                teamMove.Add(696, 698, 1, 0);
                teamMove.Add(698, 700, 1, 0);
                teamMove.Add(700, 703, 1, 0);

                teamMove.Add(703, 702, 1, 0);
                teamMove.Add(702, 699, 1, 0);
                Spots.Add(690, 0);//主力
                Spots.Add(690, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data); mission_id = 45;
                withdrawSpot = 5494;//撤离
            }

            public static MissionType missionType = MissionType.Normal;

            




        }

        public class map5_2 : mapbase
        {
            public map5_2(MissionInfo.Data data)
            {
                teamMove.Add(716, 713, 1, 0);
                teamMove.Add(713, 709, 1, 0);
                teamMove.Add(709, 710, 1, 0);
                teamMove.Add(710, 718, 1, 0);
                Spots.Add(716, 0);//主力
                Spots.Add(716, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data); mission_id = 46;
                withdrawSpot = 5494;//撤离
            }

            public static MissionType missionType = MissionType.Normal;

            



        }

        public class map5_3 : mapbase
        {
            public map5_3(MissionInfo.Data data)
            {
                teamMove.Add(726, 727, 1, 0);
                teamMove.Add(727, 731, 1, 0);
                teamMove.Add(731, 735, 1, 0);
                teamMove.Add(735, 737, 1, 0);

                teamMove.Add(737, 738, 1, 0);
                teamMove.Add(744, 740, 1, 1);
                teamMove.Add(740, 744, 1, 1);
                teamMove.Add(744, 745, 1, 1);

                teamMove.Add(738, 739, 1, 0);
                teamMove.Add(739, 736, 1, 0);
                teamMove.Add(736, 733, 1, 0);
                teamMove.Add(733, 729, 1, 0);
                teamMove.Add(729, 728, 1, 0);
                teamMove.Add(728, 732, 1, 0);

                Spots.Add(726, 0);//主力
                Spots.Add(744, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data); mission_id = 47;
                withdrawSpot = 5494;//撤离
            }

            public static MissionType missionType = MissionType.Normal;

            


        }

        public class map5_4 : mapbase
        {
            public map5_4(MissionInfo.Data data)
            {
                teamMove.Add(751, 755, 1, 0);
                teamMove.Add(755, 760, 1, 0);
                teamMove.Add(760, 764, 1, 0);
                teamMove.Add(764, 763, 1, 0);
                Spots.Add(751, 0);//主力
                Spots.Add(771, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data); mission_id = 48; withdrawSpot = 5494;//撤离
            }


            public static MissionType missionType = MissionType.Normal;

            



        }

        public class map5_5 : mapbase
        {
            public map5_5(MissionInfo.Data data)
            {
                teamMove.Add(799, 797, 1, 1);
                teamMove.Add(801, 802, 1, 0);//
                teamMove.Add(802, 798, 1, 0);//
                teamMove.Add(798, 796, 1, 0);

                teamMove.Add(796, 792, 1, 0);
                teamMove.Add(792, 787, 1, 0);//
                teamMove.Add(787, 789, 1, 0);//
                teamMove.Add(789, 783, 1, 0);

                teamMove.Add(783, 780, 1, 0);
                teamMove.Add(780, 778, 1, 0);//
                teamMove.Add(778, 777, 1, 0);//
                Spots.Add(801, 0);//主力
                Spots.Add(799, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 5494;//撤离
                mission_id = 49;
            }
            public static MissionType missionType = MissionType.Normal;

            



        }
        public class map5_6 : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map5_6(MissionInfo.Data data)
            {
                teamMove.Add(803, 808, 1, 0);
                teamMove.Add(808, 813, 1, 0);
                teamMove.Add(813, 820, 1, 0);
                teamMove.Add(820, 826, 1, 0);

                Spots.Add(803, 0);
                Spots.Add(807, 1);
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data);

                mission_id = 50;
            }

            







        }
        public class map6_1 : mapbase
        {
            public map6_1(MissionInfo.Data data)
            {

                teamMove.Add(1511, 1512, 1, 0);
                teamMove.Add(1512, 1513, 1, 0);
                teamMove.Add(1513, 1521, 1, 0);
                teamMove.Add(1521, 1515, 1, 0);

                teamMove.Add(1515, 1520, 1, 0);
                teamMove.Add(1520, 1523, 1, 0);
                Spots.Add(1511, 0);//主力
                Spots.Add(1511, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 5494;//撤离
                mission_id = 55;
            }
            public static MissionType missionType = MissionType.Normal;



            

        }
        public class map6_2 : mapbase
        {
            public map6_2(MissionInfo.Data data)
            {
                teamMove.Add(1524, 1529, 1, 0);
                teamMove.Add(1529, 1531, 1, 0);
                teamMove.Add(1531, 1533, 1, 0);
                teamMove.Add(1533, 1535, 1, 0);

                teamMove.Add(1535, 1537, 1, 0);

                Spots.Add(1524, 0);//主力
                Spots.Add(1524, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 5494;//撤离
                mission_id = 56;
            }
            public static MissionType missionType = MissionType.Normal;



            

        }
        public class map6_3 : mapbase
        {
            public map6_3(MissionInfo.Data data)
            {

                teamMove.Add(1543, 1538, 1, 0);
                teamMove.Add(1538, 1539, 1, 0);
                teamMove.Add(1539, 1540, 1, 0);
                teamMove.Add(1540, 1542, 1, 0);

                Spots.Add(1543, 0);//主力
                Spots.Add(1543, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 5494;//撤离
                mission_id = 57;
            }
            public static MissionType missionType = MissionType.Normal;

            




        }
        public class map6_4 : mapbase
        {
            public map6_4(MissionInfo.Data data)
            {
                teamMove.Add(1578, 1750, 1, 0);
                teamMove.Add(1750, 1574, 1, 0);
                teamMove.Add(1574, 1752, 1, 0);
                teamMove.Add(1752, 1575, 1, 0);

                teamMove.Add(1575, 1580, 1, 0);
                teamMove.Add(1580, 1576, 1, 0);
                teamMove.Add(1576, 1569, 1, 0);

                Spots.Add(1578, 0);//主力
                Spots.Add(1578, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 5494;//撤离
                mission_id = 58;
            }
            public static MissionType missionType = MissionType.Normal;

            




        }
        public class map6_5 : mapbase
        {
            public map6_5(MissionInfo.Data data)
            {
                teamMove.Add(1592, 1601, 1, 0);
                teamMove.Add(1601, 1600, 1, 0);
                teamMove.Add(1600, 1599, 1, 0);
                teamMove.Add(1599, 1591, 1, 0);

                teamMove.Add(1591, 1583, 1, 0);
                teamMove.Add(1583, 1581, 1, 0);
                teamMove.Add(1581, 1579, 1, 0);


                Spots.Add(1592, 0);//主力
                Spots.Add(1592, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 5494;//撤离
                mission_id = 59;
            }
            public static MissionType missionType = MissionType.Normal;






        }
        public class map6_6 : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map6_6(MissionInfo.Data data)
            {
                teamMove.Add(1616, 1634, 1, 0);
                teamMove.Add(1634, 1635, 1, 0);
                teamMove.Add(1635, 1620, 1, 0);
                teamMove.Add(1620, 1621, 1, 0);
                teamMove.Add(1621, 1636, 1, 0);
                teamMove.Add(1636, 1632, 1, 0);
                teamMove.Add(1632, 1633, 1, 0);
                Spots.Add(1616, 0);//主力
                Spots.Add(1618, 1);//辅助
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data);

                mission_id = 60;
            }


            







        }

        public class map8_6 : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map8_6(MissionInfo.Data data)
            {
                teamMove.Add(3788, 3658, 1, 0);
                teamMove.Add(3658, 3789, 1, 0);
                teamMove.Add(3789, 3683, 1, 0);

                teamMove.Add(3683, 3679, 1, 0);
                teamMove.Add(3679, 3681, 1, 0);
                teamMove.Add(3681, 3682, 1, 0);

                teamMove.Add(3682, 3667, 1, 0);
                teamMove.Add(3667, 3673, 1, 0);
                teamMove.Add(3673, 3664, 1, 0);

                teamMove.Add(3664, 3670, 1, 0);
                teamMove.Add(3670, 3669, 1, 0);

                teamMove.Add(3669, 3678, 1, 0);
                teamMove.Add(3678, 3671, 1, 0);
                teamMove.Add(3671, 3677, 1, 0);
                teamMove.Add(3677, 3668, 1, 0);
                Spots.Add(3788, 0);
                Spots.Add(3788, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data);

                mission_id = 80;
            }


            
















        }
        public class map9_6 : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map9_6(MissionInfo.Data data)
            {

                teamMove.Add(4789, 4783, 1, 0);
                teamMove.Add(4783, 4790, 1, 0);
                teamMove.Add(4790, 4783, 1, 0);
                teamMove.Add(4783, 4789, 1, 0);

                Spots.Add(4789, 0);
                Spots.Add(4781, 1);
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data);

                mission_id = 90;
            }


            



            public int withdrawTeam = 4789;

        }

        public class map10_6 : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map10_6(MissionInfo.Data data)
            {
                teamMove.Add(5363, 5360, 1, 0);
                teamMove.Add(5360, 5357, 1, 0);
                teamMove.Add(5357, 5346, 1, 0);
                mission_id = 100;
                Spots.Add(5363, 0);
                Spots.Add(5363, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data);
            }










        }
        public class map11_6 : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map11_6(MissionInfo.Data data)
            {
                teamMove.Add(9151, 9190, 1, 0);
                teamMove.Add(9190, 9193, 1, 0);
                teamMove.Add(9193, 9191, 1, 0);

                teamMove.Add(9191, 9192, 1, 0);
                teamMove.Add(9192, 9170, 1, 0);
                teamMove.Add(9170, 9171, 1, 0);

                teamMove.Add(9171, 9172, 1, 0);
                teamMove.Add(9172, 9173, 1, 0);
                teamMove.Add(9173, 9174, 1, 0);
                Spots.Add(9151, 0);
                Spots.Add(9149, 1);
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                mission_id = 110;
                Function.init(teamMove.dic, Spots, data);
            }



            





        }

        public class map7_6boss : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map7_6boss(MissionInfo.Data data)
            {
                teamMove.Add(1948, 1947, 1, 0);
                teamMove.Add(1947, 1948, 2, 0);
                teamMove.Add(1948, 1947, 2, 0);

                teamMove.Add(1947, 1946, 1, 0);
                teamMove.Add(1946, 2152, 1, 0);
                teamMove.Add(2152, 1941, 1, 0);
                teamMove.Add(1941, 1942, 1, 0);
                Spots.Add(1948, 0);
                Spots.Add(1948, 1);//辅助
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 1948;//撤离
                mission_id = 70;
            }


            




        }


        public class map10_4e : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map10_4e(MissionInfo.Data data)
            {
                teamMove.Add(5494, 5495, 1, 0);
                teamMove.Add(5495, 5492, 1, 0);
                teamMove.Add(5492, 5495, 1, 0);
                teamMove.Add(5495, 5494, 1, 0);
                teamMove.Add(5494, 5497, 1, 0);
                teamMove.Add(5497, 5494, 1, 0);

                Spots.Add(5494, 0);
                Spots.Add(5480, 1);//辅助
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 5494;//撤离
                mission_id = 104;
            }


            





        }

        public class map7_6 : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map7_6(MissionInfo.Data data)
            {
                teamMove.Add(1948, 1947, 1, 0);
                teamMove.Add(1947, 1949, 1, 0);
                teamMove.Add(1949, 1947, 1, 0);
                teamMove.Add(1947, 1948, 2, 0);


                Spots.Add(1948, 0);
                Spots.Add(1948, 1);//辅助
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0]
};
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 1948;//撤离
                mission_id = 70;
            }

            





        }


        public class map1_1e : mapbase
        {
            public map1_1e(MissionInfo.Data data)
            {

                teamMove.Add(151, 152, 1, 0);
                teamMove.Add(152, 153, 1, 0);
                teamMove.Add(153, 158, 1, 0);
                teamMove.Add(158, 159, 1, 0);
                Spots.Add(151, 0);
                Spots.Add(151, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 11;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }
        public class map1_2e : mapbase
        {
            public map1_2e(MissionInfo.Data data)
            {

                teamMove.Add(160, 162, 1, 0);
                teamMove.Add(162, 163, 1, 0);
                teamMove.Add(163, 166, 1, 0);
                teamMove.Add(166, 168, 1, 0);
                teamMove.Add(168, 170, 1, 0);
                Spots.Add(160, 0);
                Spots.Add(160, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 12;
            }

            public static MissionType missionType = MissionType.Normal;

            



        }
        public class map1_3e : mapbase
        {
            public map1_3e(MissionInfo.Data data)
            {

                teamMove.Add(171, 173, 1, 0);
                teamMove.Add(173, 176, 1, 0);
                teamMove.Add(176, 180, 1, 0);
                teamMove.Add(180, 183, 1, 0);
                teamMove.Add(183, 184, 1, 0);
                Spots.Add(171, 0);//主力
                Spots.Add(171, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 13;
            }
            public static MissionType missionType = MissionType.Normal;


            




        }
        public class map1_4e : mapbase
        {
            public map1_4e(MissionInfo.Data data)
            {

                teamMove.Add(185, 186, 1, 0);
                teamMove.Add(186, 187, 1, 0);
                teamMove.Add(187, 191, 1, 0);
                teamMove.Add(191, 188, 1, 0);

                teamMove.Add(188, 196, 1, 0);
                teamMove.Add(196, 200, 1, 0);
                teamMove.Add(200, 201, 1, 0);
                teamMove.Add(201, 198, 1, 0);
                teamMove.Add(198, 199, 1, 0);
                Spots.Add(185, 0);//主力
                Spots.Add(185, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 14;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }
        public class map2_1e : mapbase
        {
            public map2_1e(MissionInfo.Data data)
            {


                teamMove.Add(284, 286, 1, 0);
                teamMove.Add(286, 285, 1, 0);
                teamMove.Add(285, 281, 1, 0);

                Spots.Add(284, 0);//主力
                Spots.Add(277, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 21;
            }
            public static MissionType missionType = MissionType.Normal;




        }
        public class map2_2e : mapbase
        {
            public map2_2e(MissionInfo.Data data)
            {

                teamMove.Add(290, 292, 1, 0);
                teamMove.Add(292, 295, 1, 0);
                teamMove.Add(295, 294, 1, 0);
                teamMove.Add(294, 297, 1, 0);
                teamMove.Add(297, 298, 1, 0);
                teamMove.Add(298, 300, 1, 0);
                Spots.Add(290, 0);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 22;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }
        public class map2_3e : mapbase
        {
            public map2_3e(MissionInfo.Data data)
            {

                teamMove.Add(302, 304, 1, 0);
                teamMove.Add(304, 309, 1, 0);
                teamMove.Add(309, 308, 1, 0);
                teamMove.Add(308, 316, 1, 0);
                Spots.Add(302, 0);//主力
                Spots.Add(302, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 23;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }
        public class map2_4e : mapbase
        {
            public map2_4e(MissionInfo.Data data)
            {

                teamMove.Add(317, 318, 1, 0);
                teamMove.Add(318, 320, 1, 0);
                teamMove.Add(320, 324, 1, 0);
                teamMove.Add(324, 328, 1, 0);
                Spots.Add(317, 0);//主力
                Spots.Add(302, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 24;
            }
            public static MissionType missionType = MissionType.Normal;


            


        }

        public class map3_1e : mapbase
        {
            public map3_1e(MissionInfo.Data data)
            {

                teamMove.Add(449, 446, 1, 0);
                teamMove.Add(446, 442, 1, 0);
                teamMove.Add(442, 440, 1, 0);
                teamMove.Add(440, 439, 1, 0);
                teamMove.Add(439, 438, 1, 0);
                Spots.Add(449, 0);//主力
                Spots.Add(449, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 31;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }

        public class map3_2e : mapbase
        {
            public map3_2e(MissionInfo.Data data)
            {

                teamMove.Add(452, 455, 1, 0);
                teamMove.Add(455, 459, 1, 0);
                teamMove.Add(459, 462, 1, 0);
                Spots.Add(452, 0);//主力
                Spots.Add(452, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 32;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }

        public class map3_3e : mapbase
        {
            public map3_3e(MissionInfo.Data data)
            {

                teamMove.Add(479, 478, 1, 0);
                teamMove.Add(478, 481, 1, 0);
                teamMove.Add(481, 480, 1, 0);
                Spots.Add(479, 0);//主力
                Spots.Add(465, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 33;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }

        public class map3_4e : mapbase
        {
            public map3_4e(MissionInfo.Data data)
            {

                teamMove.Add(494, 489, 1, 0);
                teamMove.Add(489, 490, 1, 0);
                teamMove.Add(490, 491, 1, 0);
                teamMove.Add(491, 492, 1, 0);
                Spots.Add(494, 0);//主力
                Spots.Add(498, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 34;
            }
            public static MissionType missionType = MissionType.Normal;


            


        }


        public class map4_1e : mapbase
        {
            public map4_1e(MissionInfo.Data data)
            {


                teamMove.Add(612, 613, 1, 0);
                teamMove.Add(613, 617, 1, 0);
                teamMove.Add(617, 620, 1, 0);
                teamMove.Add(620, 621, 1, 0);
                teamMove.Add(621, 623, 1, 0);
                teamMove.Add(623, 625, 1, 0);

                Spots.Add(612, 0);//主力
                Spots.Add(609, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 41;
            }
            public static MissionType missionType = MissionType.Normal;


            


        }

        public class map4_2e : mapbase
        {
            public map4_2e(MissionInfo.Data data)
            {


                teamMove.Add(642, 641, 1, 0);
                teamMove.Add(641, 637, 1, 0);
                teamMove.Add(637, 640, 1, 0);
                teamMove.Add(640, 639, 1, 0);
                Spots.Add(642, 0);//主力
                Spots.Add(630, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 42;
            }
            public static MissionType missionType = MissionType.Normal;


            

        }

        public class map4_3e : mapbase
        {
            public map4_3e(MissionInfo.Data data)
            {

                teamMove.Add(658, 659, 1, 0);
                teamMove.Add(659, 660, 1, 0);
                teamMove.Add(660, 661, 1, 0);
                teamMove.Add(661, 662, 1, 0);
                Spots.Add(658, 0);//主力
                Spots.Add(643, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 43;
            }
            public static MissionType missionType = MissionType.Normal;


            


        }
        public class map4_4e : mapbase
        {
            public map4_4e(MissionInfo.Data data)
            {

                teamMove.Add(664, 670, 1, 0);
                teamMove.Add(670, 676, 1, 0);
                teamMove.Add(676, 680, 1, 0);
                teamMove.Add(680, 686, 1, 0);
                Spots.Add(664, 0);//主力
                Spots.Add(669, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 44;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }
        public class map5_1e : mapbase
        {
            public map5_1e(MissionInfo.Data data)
            {

                teamMove.Add(832, 833, 1, 0);
                teamMove.Add(833, 837, 1, 0);
                teamMove.Add(837, 841, 1, 0);
                teamMove.Add(841, 843, 1, 0);

                teamMove.Add(843, 844, 1, 0);
                teamMove.Add(850, 846, 1, 1);
                teamMove.Add(846, 850, 1, 1);
                teamMove.Add(850, 851, 1, 1);

                teamMove.Add(844, 845, 1, 0);
                teamMove.Add(845, 842, 1, 0);
                teamMove.Add(842, 839, 1, 0);
                teamMove.Add(839, 835, 1, 0);
                teamMove.Add(835, 834, 1, 0);
                teamMove.Add(834, 838, 1, 0);
                Spots.Add(832, 0);//主力
                Spots.Add(850, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 51;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }
        public class map5_2e : mapbase
        {
            public map5_2e(MissionInfo.Data data)
            {

                teamMove.Add(857, 861, 1, 0);
                teamMove.Add(861, 866, 1, 0);
                teamMove.Add(866, 870, 1, 0);
                teamMove.Add(870, 869, 1, 0);

                Spots.Add(857, 0);//主力
                Spots.Add(877, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 52;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }
        public class map5_3e : mapbase
        {
            public map5_3e(MissionInfo.Data data)
            {

                teamMove.Add(905, 903, 1, 0);//
                teamMove.Add(907, 908, 1, 0);
                teamMove.Add(908, 904, 1, 0);
                teamMove.Add(904, 902, 1, 0);

                teamMove.Add(902, 898, 1, 0);
                teamMove.Add(898, 895, 1, 0);
                teamMove.Add(895, 889, 1, 0);
                teamMove.Add(889, 886, 1, 0);

                teamMove.Add(886, 884, 1, 0);
                teamMove.Add(884, 883, 1, 0);
                Spots.Add(907, 0);//主力
                Spots.Add(905, 1);//主力
                Spots.Add(907, 2);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 53;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }
        public class map5_4e : mapbase
        {
            public map5_4e(MissionInfo.Data data)
            {

                teamMove.Add(909, 914, 1, 0);
                teamMove.Add(914, 919, 1, 0);
                teamMove.Add(919, 926, 1, 0);
                teamMove.Add(926, 932, 1, 0);

                Spots.Add(909, 0);//主力
                Spots.Add(913, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 54;
            }
            public static MissionType missionType = MissionType.Normal;


            




        }
        public class map1_4n : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map1_4n(MissionInfo.Data data)
            {

                teamMove.Add(1318, 1317, 1, 0);
                teamMove.Add(1317, 1408, 1, 0);
                teamMove.Add(1408, 1409, 1, 0);
                teamMove.Add(1409, 1411, 1, 0);
                teamMove.Add(1411, 1410, 1, 0);
                Spots.Add(1318, 0);//主力
                Spots.Add(1318, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 90004;
            }


            







        }

        public class map2_4n : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map2_4n(MissionInfo.Data data)
            {
                teamMove.Add(1330, 1332, 1, 0);
                teamMove.Add(1332, 1453, 1, 0);
                teamMove.Add(1453, 1454, 1, 0);
                teamMove.Add(1454, 1457, 1, 0);
                teamMove.Add(1457, 1461, 1, 0);
                Spots.Add(1330, 0);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 90008;
            }


            









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


        public class map3_4n : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map3_4n(MissionInfo.Data data)
            {

                teamMove.Add(1485, 1347, 1, 0);
                teamMove.Add(1347, 1503, 1, 0);
                teamMove.Add(1503, 1504, 1, 0);
                teamMove.Add(1504, 1505, 1, 0);//分支开始
                teamMove.Add(1505, 1489, 1, 0);//分支1向上
                teamMove.Add(1947, 1949, 1, 0);//分支2向左1
                teamMove.Add(1949, 1947, 1, 0);//分支2向左2
                teamMove.Add(1505, 1509, 1, 0);//分支3
                teamMove.Add(1509, 1506, 1, 0);//分支3
                teamMove.Add(1509, 1507, 1, 0);//分支3
                teamMove.Add(1489, 1506, 1, 0);
                teamMove.Add(1489, 1490, 1, 0);
                teamMove.Add(1489, 1501, 1, 0);
                teamMove.Add(1489, 1476, 1, 0);
                Spots.Add(1485, 0);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 90012;
            }


            







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
        public class map4_4n : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map4_4n(MissionInfo.Data data)
            {

                teamMove.Add(1813, 1819, 1, 0);
                teamMove.Add(1819, 1825, 1, 0);
                teamMove.Add(1825, 1829, 1, 0);
                teamMove.Add(1829, 1835, 1, 0);//分支开始
                Spots.Add(1813, 0);//主力
                Spots.Add(1818, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 90016;
            }


            




        }
        public class map5_2n : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map5_2n(MissionInfo.Data data)
            {

                teamMove.Add(3033, 3037, 1, 0);
                teamMove.Add(3037, 3038, 1, 0);
                teamMove.Add(3038, 3047, 1, 0);
                teamMove.Add(3047, 3052, 1, 0);
                teamMove.Add(3052, 3051, 1, 0);
                teamMove.Add(3051, 3056, 1, 0);
                teamMove.Add(3056, 3057, 2, 0);

                Spots.Add(3033, 0);//主力
                Spots.Add(3057, 1);//辅助

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 3057;//撤离
                mission_id = 90018;
            }





        }
        public class map5_4n : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map5_4n(MissionInfo.Data data)
            {

                teamMove.Add(3085, 3090, 1, 0);
                teamMove.Add(3090, 3095, 1, 0);
                teamMove.Add(3095, 3102, 1, 0);
                teamMove.Add(3102, 3108, 1, 0);//分支开始
                Spots.Add(3085, 0);//主力
                Spots.Add(3089, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 90020;
            }


            



        }
        public class map6_4n : mapbase
        {
            public static MissionType missionType = MissionType.Normal;
            public map6_4n(MissionInfo.Data data)
            {

                teamMove.Add(4066, 4067, 1, 0);
                teamMove.Add(4067, 4077, 1, 0);
                teamMove.Add(4077, 4078, 1, 0);
                teamMove.Add(4078, 4082, 1, 0);//分支开始
                teamMove.Add(4082, 4079, 1, 0);//分支1向上
                teamMove.Add(4079, 4068, 1, 0);//分支2向左1
                teamMove.Add(4068, 4079, 1, 0);//分支2向左2
                teamMove.Add(4079, 4082, 1, 0);//分支3
                Spots.Add(4066, 0);//主力
                Spots.Add(4070, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 4082;//撤离
                mission_id = 90024;
            }


            



        }
        public class map7_4n : mapbase
        {
            public map7_4n(MissionInfo.Data data)
            {


                teamMove.Add(6699, 6675, 1, 0);
                teamMove.Add(6675, 6668, 1, 0);
                teamMove.Add(6668, 6669, 1, 0);
                teamMove.Add(6669, 6658, 1, 0);

                teamMove.Add(6658, 6657, 1, 0);
                teamMove.Add(6657, 6660, 1, 0);
                teamMove.Add(6660, 6662, 1, 0);
                teamMove.Add(6662, 6663, 1, 0);
                Spots.Add(6699, 0);//主力
                Spots.Add(6679, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 90028;
            }
            public static MissionType missionType = MissionType.Normal;


            




        }
        public class map8_1n : mapbase
        {
            public map8_1n(MissionInfo.Data data)
            {

                teamMove.Add(7069, 7076, 1, 0);
                teamMove.Add(7076, 7068, 1, 0);
                teamMove.Add(7068, 7067, 1, 0);

                teamMove.Add(7067, 7075, 1, 0);
                teamMove.Add(7075, 7074, 1, 0);
                teamMove.Add(7074, 7066, 2, 0);
                Spots.Add(7069, 0);//主力
                Spots.Add(7066, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 7066;//撤离
                mission_id = 90029;
            }
            public static MissionType missionType = MissionType.Normal;


            



        }
        public class map8_4n : mapbase
        {
            public map8_4n(MissionInfo.Data data)
            {

                teamMove.Add(7033, 7034, 1, 0);
                teamMove.Add(7034, 7039, 1, 0);
                teamMove.Add(7039, 7050, 1, 0);

                teamMove.Add(7050, 7061, 1, 0);
                teamMove.Add(7061, 7065, 1, 0);
                teamMove.Add(7065, 7056, 2, 0);
                teamMove.Add(7056, 7055, 2, 0);
                Spots.Add(7033, 0);//主力
                Spots.Add(7062, 1);//主力
                Spots.Add(7037, 2);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1], Spots.dic[2] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 90032;
            }
            public static MissionType missionType = MissionType.Normal;


            


        }
        public class map8_2emod2 : mapbase
        {
            public map8_2emod2(MissionInfo.Data data)
            {

                teamMove.Add(3880, 3854, 1, 0);
                teamMove.Add(3854, 3847, 1, 0);
                teamMove.Add(3847, 3859, 1, 0);
                teamMove.Add(3859, 3862, 1, 0);
                Spots.Add(3880, 0);//主力
                Spots.Add(3870, 1);//辅助
                mission_id = 82;
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);
            }
            public static MissionType missionType = MissionType.Normal;


            
        }
        public class map8_3emod2 : mapbase
        {
            public map8_3emod2(MissionInfo.Data data)
            {
                teamMove.Add(3892, 3890, 1, 0);
                teamMove.Add(3890, 3897, 1, 0);
                teamMove.Add(3897, 3894, 1, 0);
                teamMove.Add(3894, 3893, 1, 0);
                Spots.Add(3892, 0);//主力
                Spots.Add(3892, 1);//辅助
                mission_id = 83;
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
            }
            public static MissionType missionType = MissionType.Normal;


            
        }



        public class mapequip_ump : mapbase
        {
            //要给Spots.dic[0] 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public mapequip_ump(MissionInfo.Data data)
            {
                teamMove.Add(4574, 4572, 1, 0);
                teamMove.Add(4572, 4582, 1, 0);
                teamMove.Add(4582, 4573, 1, 0);
                teamMove.Add(4573, 4583, 1, 0);
                teamMove.Add(4583, 4555, 1, 0);

                teamMove.Add(4555, 4568, 1, 0);
                teamMove.Add(4568, 4603, 1, 0);
                teamMove.Add(4603, 4568, 1, 0);
                Spots.Add(4574, 0);//主力
                Spots.Add(4559, 1);//辅助
                Spots.Add(4567, 2);//辅助
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1], Spots.dic[2] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 10040;
            }

            public static MissionType missionType = MissionType.Activity;






            public int withdrawSpot1 = 4559;//撤离
            public int withdrawSpot2 = 4568;//撤离
        }

        public class mapcubee1_4 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcubee1_4(MissionInfo.Data data)
            {
                teamMove.Add(3243, 3244, 1, 0);//注意两个点哦
                teamMove.Add(3244, 3245, 1, 0);
                teamMove.Add(3245, 3246, 1, 0);
                teamMove.Add(3246, 3247, 1, 0);
                teamMove.Add(3247, 3240, 1, 0);
                teamMove.Add(3240, 3233, 1, 0);
                teamMove.Add(3233, 3234, 1, 0);
                teamMove.Add(3234, 3235, 1, 0);
                Spots.Add(3243, 0);//主力
                Spots.Add(3243, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10021;
            }





        }

        public class maparctic1_4 : mapbase
        {
            public maparctic1_4(MissionInfo.Data data)
            {
                teamMove.Add(2054, 2056, 1, 0);//注意两个点哦
                teamMove.Add(2056, 2057, 1, 0);
                teamMove.Add(2057, 2210, 1, 0);
                teamMove.Add(2210, 2259, 1, 0);
                teamMove.Add(2259, 2260, 1, 0);
                teamMove.Add(2260, 2261, 1, 0);
                teamMove.Add(2261, 2262, 1, 0);
                teamMove.Add(2262, 2263, 1, 0);

                teamMove.Add(2263, 2264, 1, 0);
                teamMove.Add(2264, 2253, 1, 0);
                teamMove.Add(2253, 2252, 1, 0);

                teamMove.Add(2252, 2060, 1, 0);
                Spots.Add(2054, 0);//主力
                Spots.Add(2054, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 10008;
            }

            public static MissionType missionType = MissionType.Activity;



            







        }

        public class mapcorridor : mapbase
        {
            public mapcorridor(MissionInfo.Data data)
            {

                teamMove.Add(5523, 5521, 1, 0);
                teamMove.Add(5521, 5522, 1, 0);
                teamMove.Add(5522, 5519, 1, 0);
                teamMove.Add(5519, 5524, 1, 0);
                teamMove.Add(5524, 5520, 1, 0);
                Spots.Add(5523, 0);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 1503;
            }
            public mapcorridor() { }

            public static MissionType missionType = MissionType.Simulation;




        }

        public class mapcte1_1 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_1(MissionInfo.Data data)
            {

                teamMove.Add(7246, 7245, 1, 0);//注意两个点哦
                teamMove.Add(7245, 7239, 1, 0);

                Spots.Add(7246, 0);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10106;
            }


            



        }

        public class mapcte1_2 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_2(MissionInfo.Data data)
            {

                teamMove.Add(7255, 7256, 1, 0);//注意两个点哦
                teamMove.Add(7256, 7257, 1, 0);

                teamMove.Add(7257, 7256, 1, 0);//注意两个点哦
                teamMove.Add(7256, 7262, 1, 0);

                teamMove.Add(7262, 7256, 1, 0);//注意两个点哦
                teamMove.Add(7256, 7260, 1, 0);

                teamMove.Add(7260, 7264, 1, 0);//注意两个点哦
                teamMove.Add(7264, 7260, 1, 0);

                teamMove.Add(7260, 7256, 1, 0);//注意两个点哦
                teamMove.Add(7256, 7255, 2, 0);


                teamMove.Add(7255, 7259, 1, 0);//注意两个点哦
                teamMove.Add(7259, 7255, 1, 0);

                teamMove.Add(7255, 7263, 1, 0);//注意两个点哦
                teamMove.Add(7263, 7258, 1, 0);

                Spots.Add(7255, 0);//主力
                Spots.Add(7255, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10108;
            }


            





        }


        public class mapcte1_3 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_3(MissionInfo.Data data)
            {

                teamMove.Add(7277, 7265, 1, 0);//注意两个点哦
                teamMove.Add(7265, 7276, 1, 0);

                teamMove.Add(7276, 7274, 1, 0);//注意两个点哦
                teamMove.Add(7274, 7273, 1, 0);

                teamMove.Add(7273, 7280, 1, 0);//注意两个点哦
                teamMove.Add(7280, 7281, 1, 0);

                Spots.Add(7277, 0);//主力
                Spots.Add(7255, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10109;
            }


            







        }

        public class mapcte1_4type1 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_4type1(MissionInfo.Data data)
            {

                teamMove.Add(7282, 7285, 1, 0);//注意两个点哦
                teamMove.Add(7285, 7286, 1, 0);

                teamMove.Add(7286, 7287, 1, 0);//注意两个点哦
                teamMove.Add(7287, 7296, 1, 0);


                Spots.Add(7282, 0);//主力
                Spots.Add(7282, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10110;
            }


            









        }

        public class mapcte1_4type2 : mapbase//这个乱序不知道怎么写
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_4type2(MissionInfo.Data data)
            {

                teamMove.Add(7282, 7285, 1, 0);//注意两个点哦
                teamMove.Add(7285, 7286, 1, 0);

                teamMove.Add(7286, 7287, 1, 0);//注意两个点哦
                teamMove.Add(7287, 7296, 1, 0);


                Spots.Add(7282, 0);//主力
                Spots.Add(7282, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10110;
            }


            









        }




        /// <summary>
        /// 别了稻草人 物资箱
        /// </summary>
        public class mapcte1_5 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_5(MissionInfo.Data data)
            {

                teamMove.Add(7302, 7305, 1, 0);//注意两个点哦
                teamMove.Add(7305, 7307, 1, 0);

                teamMove.Add(7307, 7313, 1, 0);//注意两个点哦
                teamMove.Add(7313, 7312, 1, 0);


                Spots.Add(7302, 0);//主力
                Spots.Add(7302, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10111;
            }


            









        }

        public class mapcte1_6 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_6(MissionInfo.Data data)
            {

                teamMove.Add(7282, 7285, 1, 0);//注意两个点哦
                teamMove.Add(7285, 7286, 1, 0);

                teamMove.Add(7286, 7287, 1, 0);//注意两个点哦
                teamMove.Add(7287, 7296, 1, 0);


                Spots.Add(7282, 0);//主力
                Spots.Add(7282, 1);//主力


                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10110;
            }











        }

        public class mapcte1_7 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_7(MissionInfo.Data data)
            {

                teamMove.Add(7326, 7335, 1, 0);//注意两个点哦
                teamMove.Add(7335, 7334, 1, 0);

                teamMove.Add(7334, 7336, 1, 0);//注意两个点哦
                teamMove.Add(7336, 7333, 1, 0);

                teamMove.Add(7333, 7328, 1, 0);//注意两个点哦
                teamMove.Add(7328, 7337, 1, 0);

                teamMove.Add(7337, 7328, 1, 0);//注意两个点哦
                teamMove.Add(7328, 7330, 1, 0);

                teamMove.Add(7330, 7343, 1, 0);//注意两个点哦
                teamMove.Add(7343, 7342, 1, 0);


                teamMove.Add(7342, 7343, 1, 0);//注意两个点哦
                teamMove.Add(7343, 7330, 1, 0);
                teamMove.Add(7330, 7328, 1, 0);//注意两个点哦
                teamMove.Add(7328, 7330, 1, 0);

                teamMove.Add(7330, 7332, 1, 0);//注意两个点哦
                teamMove.Add(7332, 7338, 1, 0);
                teamMove.Add(7338, 7341, 1, 0);//注意两个点哦
                teamMove.Add(7341, 7339, 1, 0);

                teamMove.Add(7339, 7340, 1, 0);
                teamMove.Add(7340, 7339, 1, 0);//注意两个点哦
                teamMove.Add(7339, 7341, 1, 0);

                teamMove.Add(7341, 7338, 1, 0);
                teamMove.Add(7338, 7332, 1, 0);
                teamMove.Add(7332, 7330, 1, 0);//注意两个点哦
                teamMove.Add(7330, 7328, 1, 0);
                Spots.Add(7326, 0);//主力
                Spots.Add(7326, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10113;
            }


            




        }

        /// <summary>
        /// 和平谈判
        /// </summary>
        public class mapcte1_8 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_8(MissionInfo.Data data)
            {

                teamMove.Add(7377, 7351, 1, 0);//注意两个点哦
                teamMove.Add(7351, 7379, 1, 0);

                teamMove.Add(7379, 7402, 1, 0);//注意两个点哦
                teamMove.Add(7402, 7397, 1, 0);

                teamMove.Add(7397, 7378, 1, 0);//注意两个点哦
                teamMove.Add(7378, 7398, 1, 0);
                teamMove.Add(7398, 7354, 1, 0);//注意两个点哦

                Spots.Add(7377, 0);//主力
                Spots.Add(7377, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10114;
            }


            







        }

        /// <summary>
        /// 幸运
        /// </summary>
        public class mapcte1_11 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_11(MissionInfo.Data data)
            {

                teamMove.Add(7403, 7416, 1, 0);//注意两个点哦
                teamMove.Add(7416, 7403, 1, 0);

                Spots.Add(7403, 0);//主力
                Spots.Add(7403, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10115;
            }


            




        }


        public class mapcte1_11mp7 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_11mp7(MissionInfo.Data data)
            {

                teamMove.Add(7403, 7414, 1, 0);//注意两个点哦
                teamMove.Add(7414, 7403, 2, 0);
                teamMove.Add(7403, 7411, 1, 0);
                teamMove.Add(7411, 7412, 1, 0);

                teamMove.Add(7412, 7424, 1, 0);//注意两个点哦
                teamMove.Add(7424, 7407, 1, 0);
                teamMove.Add(7407, 7411, 1, 0);
                teamMove.Add(7411, 7403, 1, 0);

                Spots.Add(7403, 0);//主力
                Spots.Add(7403, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10115;
            }

            



            public int withdrawTeam = 7403;
        }


        /// <summary>
        /// 铁血精英
        /// </summary>
        public class mapcte1_12 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_12(MissionInfo.Data data)
            {

                teamMove.Add(7425, 7436, 1, 0);//注意两个点哦
                teamMove.Add(7436, 7447, 1, 0);
                teamMove.Add(7447, 7430, 1, 0);//注意两个点哦
                teamMove.Add(7430, 7448, 1, 0);

                teamMove.Add(7448, 7445, 1, 0);//注意两个点哦
                teamMove.Add(7445, 7431, 1, 0);
                teamMove.Add(7431, 7442, 1, 0);//注意两个点哦
                teamMove.Add(7442, 7444, 1, 0);

                Spots.Add(7425, 0);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10116;
            }

            





        }


        /// <summary>
        /// 铁血精英
        /// </summary>
        public class mapcte1_13 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_13(MissionInfo.Data data)
            {

                teamMove.Add(7455, 7456, 1, 0);
                teamMove.Add(7456, 7457, 1, 0);
                teamMove.Add(7457, 7458, 1, 0);
                teamMove.Add(7458, 7459, 1, 0);

                teamMove.Add(7459, 7461, 1, 0);//注意两个点哦
                teamMove.Add(7461, 7463, 1, 0);
                teamMove.Add(7463, 7462, 1, 0);//注意两个点哦
                teamMove.Add(7462, 7439, 1, 0);

                teamMove.Add(7439, 7434, 1, 0);//注意两个点哦
                teamMove.Add(7434, 7439, 1, 0);
                teamMove.Add(7439, 7462, 1, 0);//注意两个点哦
                teamMove.Add(7462, 7463, 1, 0);

                teamMove.Add(7463, 7461, 2, 0);
                Spots.Add(7455, 0);
                Spots.Add(7461, 1);//
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10117;
            }


            




            public int withdrawTeam = 7461;
        }

        /// <summary>
        /// 最卑鄙的愿望 打捞
        /// </summary>
        public class mapcte1_14 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte1_14(MissionInfo.Data data)
            {

                teamMove.Add(7904, 7476, 1, 0);
                teamMove.Add(7476, 7477, 1, 0);
                teamMove.Add(7477, 7475, 1, 0);
                teamMove.Add(7475, 7492, 1, 0);

                teamMove.Add(7492, 7491, 1, 0);
                teamMove.Add(7491, 7479, 1, 0);
                teamMove.Add(7479, 7494, 1, 0);
                Spots.Add(7904, 0);
                Spots.Add(7464, 1);//
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10118;
            }


            





            public int withdrawTeam = 7461;
        }

        /// <summary>
        /// 格里芬敢死队
        /// </summary>
        public class mapcte2_4 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte2_4(MissionInfo.Data data)
            {

                teamMove.Add(8337, 7528, 1, 0);//注意两个点哦
                teamMove.Add(7528, 7531, 1, 0);

                teamMove.Add(7531, 7536, 1, 0);//注意两个点哦
                teamMove.Add(7536, 7526, 1, 0);
                Spots.Add(8337, 0);//主力
                Spots.Add(7530, 1);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10122;
            }


            






        }


        public class mapcte2_9 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte2_9(MissionInfo.Data data)
            {

                teamMove.Add(7716, 7732, 1, 0);//注意两个点哦
                teamMove.Add(7732, 7719, 1, 0);

                teamMove.Add(7719, 8532, 1, 0);//注意两个点哦
                teamMove.Add(8532, 8552, 1, 0);

                teamMove.Add(8552, 8554, 1, 0);//注意两个点哦
                teamMove.Add(8554, 7718, 1, 0);
                teamMove.Add(7718, 8531, 1, 0);//注意两个点哦

                teamMove.Add(8531, 8551, 1, 0);
                teamMove.Add(8551, 7733, 1, 0);//注意两个点哦
                Spots.Add(7716, 0);//主力
                Spots.Add(7713, 1);//主力
                Spots.Add(7715, 2);//主力
                Spots.Add(7714, 3);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1], Spots.dic[2], Spots.dic[3] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10129;
            }


            






        }


        public class mapcte2_15 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte2_15(MissionInfo.Data data)
            {

                teamMove.Add(7686, 7698, 1, 0);//注意两个点哦
                teamMove.Add(7698, 7687, 1, 0);
                teamMove.Add(7687, 7701, 1, 0);//注意两个点哦
                teamMove.Add(7701, 7696, 1, 0);

                teamMove.Add(7696, 7708, 1, 0);//注意两个点哦
                teamMove.Add(7708, 7688, 1, 0);

                teamMove.Add(7688, 8504, 1, 0);//注意两个点哦
                teamMove.Add(8504, 8519, 1, 0);

                teamMove.Add(8519, 7693, 1, 0);//注意两个点哦
                Spots.Add(7686, 0);//主力
                Spots.Add(7711, 1);//主力


                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10128;
            }


            







        }



        public class mapcte3_3 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte3_3(MissionInfo.Data data)
            {

                teamMove.Add(7840, 7841, 1, 0);//注意两个点哦
                teamMove.Add(7841, 7842, 1, 0);

                teamMove.Add(7842, 7838, 1, 0);//注意两个点哦

                Spots.Add(7840, 0);//主力
                Spots.Add(7815, 1);//主力


                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);

                mission_id = 10133;
            }









        }







        public class mapcte3_14 : mapbase
        {
            public static MissionType missionType = MissionType.Activity;
            public mapcte3_14(MissionInfo.Data data)
            {
                mission_id = 10144;

                teamMove.Add(8027, 8249, 1, 0);
                teamMove.Add(8249, 8593, 1, 0);
                teamMove.Add(8593, 8594, 1, 0);
                teamMove.Add(8594, 8592, 1, 0);
                teamMove.Add(8592, 8600, 1, 0);
                teamMove.Add(8600, 8597, 1, 0);
                teamMove.Add(8597, 8596, 1, 0);//第一回合结束

                teamMove.Add(8596, 8608, 1, 0);
                teamMove.Add(8608, 8607, 1, 0);
                teamMove.Add(8607, 8606, 1, 0);
                teamMove.Add(8606, 8605, 1, 0);
                teamMove.Add(8605, 8603, 1, 0);
                teamMove.Add(8250, 8028, 1, 1);//第二回合结束 注意这里事第二梯队

                teamMove.Add(8603, 8602, 1, 0);
                teamMove.Add(8602, 8243, 1, 0);//上方任务完成
                teamMove.Add(8028, 8620, 1, 1);
                teamMove.Add(8620, 8040, 1, 1);
                teamMove.Add(8040, 8025, 1, 1);
                teamMove.Add(8025, 8032, 1, 1);
                teamMove.Add(8032, 8247, 1, 1);
                teamMove.Add(8247, 8035, 1, 1);//第三回合结束


                teamMove.Add(8035, 8613, 1, 1);
                teamMove.Add(8613, 8614, 1, 1);
                teamMove.Add(8614, 8617, 1, 1);
                teamMove.Add(8617, 8616, 1, 1);
                teamMove.Add(8616, 8039, 1, 1);//第四回合结束

                teamMove.Add(8253, 8619, 1, 0);
                teamMove.Add(8619, 8649, 1, 0);
                teamMove.Add(8649, 8630, 1, 0);
                teamMove.Add(8630, 8629, 1, 0);
                teamMove.Add(8629, 8631, 1, 0);
                teamMove.Add(8631, 8637, 1, 0);
                teamMove.Add(8637, 8636, 1, 0);
                teamMove.Add(8636, 8628, 1, 0);//第五回合结束

                teamMove.Add(8628, 8640, 1, 0);
                teamMove.Add(8640, 8644, 1, 0);
                teamMove.Add(8644, 8645, 1, 0);//
                teamMove.Add(8645, 8646, 1, 0);
                teamMove.Add(8646, 8647, 1, 0);
                Spots.Add(8027, 0);//开始基地 主力上方
                Spots.Add(8250, 1);//开始基地 主力下方
                Spots.Add(8031, 2);
                Spots.Add(8037, 3);
                Spots.Add(8253, 0);
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1], Spots.dic[2], Spots.dic[3] };
                Function.init(teamMove.dic, Spots, data);
                withdrawSpot = 8243;
            }



            



        }













        public class mapcte1start
        {
            public static MissionType missionType = MissionType.Activity;
        }

        public class mapctbox
        {
            public static MissionType missionType = MissionType.Activity;
        }
        public class maprabbit
        {
            public static MissionType missionType = MissionType.Activity;
        }

        public class maprabbite1 : mapbase
        {
            //要给Spots.dic[0] 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public maprabbite1(MissionInfo.Data data)
            {

                teamMove.Add(4144, 4142, 1, 0);
                teamMove.Add(4142, 4139, 1, 0);
                teamMove.Add(4139, 4145, 1, 0);
                teamMove.Add(4145, 4147, 1, 0);
                teamMove.Add(4147, 4140, 1, 0);

                Spots.Add(4144, 0);//主力

                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 10027;
            }

            public static MissionType missionType = MissionType.Activity;



            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]

            






        }

        public class maprabbite2 : mapbase
        {
            //要给Spots.dic[0] 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public maprabbite2(MissionInfo.Data data)
            {
                teamMove.Add(4124, 4121, 1, 0);
                teamMove.Add(4121, 4130, 1, 0);
                teamMove.Add(4130, 4120, 1, 0);
                teamMove.Add(4120, 4119, 1, 0);

                Spots.Add(4124, 0);//主力
                Spots.Add(4124, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 10026;
            }

            public static MissionType missionType = MissionType.Activity;



            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]

            






        }

        public class maprabbite3 : mapbase
        {
            //要给Spots.dic[0] 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public maprabbite3(MissionInfo.Data data)
            {
                teamMove.Add(4156, 4155, 1, 0);
                teamMove.Add(4151, 4158, 1, 1);

                teamMove.Add(4156, 4154, 1, 2);

                teamMove.Add(4155, 4165, 1, 0);
                teamMove.Add(4165, 4164, 1, 0);
                teamMove.Add(4164, 4166, 1, 0);
                teamMove.Add(4166, 4169, 1, 0);

                teamMove.Add(4169, 4159, 1, 0);
                teamMove.Add(4159, 4160, 1, 0);
                teamMove.Add(4160, 4170, 1, 0);



                teamMove.Add(4154, 4171, 1, 2);
                teamMove.Add(4171, 4162, 1, 2);
                teamMove.Add(4162, 4163, 1, 2);
                Spots.Add(4156, 0);//主力
                Spots.Add(4151, 1);//主力
                Spots.Add(4156, 2);//主力
                Spots.Add(4151, 3);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 10028;
            }

            public static MissionType missionType = MissionType.Activity;

            

        }

        public class maprabbite4 : mapbase
        {
            //要给Spots.dic[0] 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public maprabbite4(MissionInfo.Data data)
            {
                teamMove.Add(4175, 4188, 1, 0);
                teamMove.Add(4176, 4187, 1, 1);

                teamMove.Add(4188, 4191, 1, 0);
                teamMove.Add(4191, 4190, 1, 0);
                teamMove.Add(4190, 4196, 1, 0);
                teamMove.Add(4196, 4179, 1, 0);
                teamMove.Add(4179, 4184, 1, 0);
                teamMove.Add(4184, 4183, 1, 0);

                teamMove.Add(4183, 4185, 1, 0);
                teamMove.Add(4185, 4197, 1, 0);
                teamMove.Add(4197, 4174, 1, 0);
                teamMove.Add(4174, 4178, 1, 0);
                teamMove.Add(4178, 4198, 1, 0);
                teamMove.Add(4198, 4195, 1, 0);

                teamMove.Add(4195, 4181, 1, 0);
                teamMove.Add(4181, 4194, 1, 0);


                //teamMove.Add(4188, 4191, 1, 0);
                //teamMove.Add(4191, 4190, 1, 0);
                //teamMove.Add(4190, 4196, 1, 0);
                //teamMove.Add(4196, 4179, 1, 0);
                //teamMove.Add(4179, 4182, 1, 0);
                //teamMove.Add(4176, 4189, 1, 3);

                //teamMove.Add(4182, 4179, 1, 0);
                //teamMove.Add(4179, 4184, 1, 0);
                //teamMove.Add(4184, 4183, 1, 0);
                //teamMove.Add(4183, 4185, 1, 0);

                //teamMove.Add(4187, 4186, 1, 1);

                //teamMove.Add(4185, 4197, 1, 0);
                //teamMove.Add(4197, 4174, 1, 0);
                //teamMove.Add(4174, 4178, 1, 0);
                //teamMove.Add(4178, 4198, 1, 0);
                //teamMove.Add(4198, 4195, 1, 0);
                //teamMove.Add(4195, 4181, 1, 0);
                //teamMove.Add(4181, 4194, 1, 0);

                Spots.Add(4175, 0);//主力
                Spots.Add(4176, 1);//主力
                Spots.Add(4175, 2);//主力
                Spots.Add(4176, 3);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 10029;
            }

            public static MissionType missionType = MissionType.Activity;


            

        }

        public class maprabbite5 : mapbase
        {
            //要给Spots.dic[0] 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public maprabbite5(MissionInfo.Data data)
            {

                teamMove.Add(9482, 9481, 1, 0);
                teamMove.Add(9481, 9472, 1, 0);
                teamMove.Add(9472, 9483, 1, 0);
                teamMove.Add(9483, 9485, 1, 0);
                teamMove.Add(9485, 9478, 1, 0);

                Spots.Add(9482, 0);//主力
                Spots.Add(9482, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 10160;
            }

            public static MissionType missionType = MissionType.Activity;



            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]








        }

        public class maprabbite6 : mapbase
        {
            //要给Spots.dic[0] 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public maprabbite6(MissionInfo.Data data)
            {

                teamMove.Add(9463, 9460, 1, 0);
                teamMove.Add(9460, 9469, 1, 0);
                teamMove.Add(9469, 9459, 1, 0);
                teamMove.Add(9459, 9458, 1, 0);

                Spots.Add(9463, 0);//主力
                Spots.Add(9463, 1);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 10159;
            }

            public static MissionType missionType = MissionType.Activity;



            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]








        }

        public class maprabbite7 : mapbase
        {
            //要给Spots.dic[0] 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public maprabbite7(MissionInfo.Data data)
            {

                teamMove.Add(9493, 9491, 1, 0);
                teamMove.Add(9489, 9494, 1, 1);

                teamMove.Add(9491, 9507, 1, 0);
                teamMove.Add(9507, 9498, 1, 0);
                teamMove.Add(9498, 9499, 1, 0);
                teamMove.Add(9499, 9508, 1, 0);
                teamMove.Add(9508, 9497, 1, 0);
                teamMove.Add(9497, 9503, 1, 0);


                teamMove.Add(9503, 9505, 1, 0);
                teamMove.Add(9505, 9495, 1, 0);
                teamMove.Add(9495, 9496, 1, 0);
                teamMove.Add(9496, 9506, 1, 0);



                Spots.Add(9493, 0);//主力
                Spots.Add(9489, 1);//主力
                Spots.Add(9493, 2);//主力
                Spots.Add(9489, 3);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 10161;
            }

            public static MissionType missionType = MissionType.Activity;



            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]








        }
        public class maprabbite8 : mapbase
        {
            //要给Spots.dic[0] 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID


            public maprabbite8(MissionInfo.Data data)
            {

                teamMove.Add(9511, 9524, 1, 0);
                teamMove.Add(9512, 9523, 1, 1);

                teamMove.Add(9524, 9527, 1, 0);
                teamMove.Add(9527, 9526, 1, 0);
                teamMove.Add(9526, 9532, 1, 0);
                teamMove.Add(9532, 9515, 1, 0);
                teamMove.Add(9515, 9520, 1, 0);
                teamMove.Add(9520, 9519, 1, 0);


                teamMove.Add(9519, 9521, 1, 0);
                teamMove.Add(9521, 9533, 1, 0);
                teamMove.Add(9533, 9510, 1, 0);
                teamMove.Add(9510, 9514, 1, 0);
                teamMove.Add(9514, 9534, 1, 0);
                teamMove.Add(9534, 9531, 1, 0);

                teamMove.Add(9531, 9517, 1, 0);
                teamMove.Add(9517, 9530, 1, 0);



                Spots.Add(9511, 0);//主力
                Spots.Add(9512, 1);//主力
                Spots.Add(9511, 2);//主力
                Spots.Add(9512, 3);//主力
                Mission_Start_spots = new Spot.Data[] { Spots.dic[0], Spots.dic[1] };
                Function.init(teamMove.dic, Spots, data);
                mission_id = 10162;
            }

            public static MissionType missionType = MissionType.Activity;



            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]








        }




        public class mapsimulationdata : mapbase
        {
            class Info
            {
                public Info(int type)
                {
                    this.DataType = type;
                    if (type != 1 && type != 2 && type != 3)
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
            public mapsimulationdata(UserData userData)
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
            public static MissionType missionType = MissionType.Simulation;
            public void Start()
            {
                if (userData.battle.Simulation_battleFinish(BattleResult) == false)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, "模拟作战 Error");
                }
            }



            private UserData userData;
            private Info info;
            
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

        public class mapsimulationtrial : mapbase
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
            public mapsimulationtrial(UserData userData)
            {
                this.userData = userData;

            }
            public static MissionType missionType = MissionType.Simulation;
            public bool Start()
            {
                if (StartBattle() == false) return false;
                return EndBattle();
            }

            private bool StartBattle()
            {
                return userData.battle.StartTrial(userData.others.getAvailableTeamID());
            }
            private bool EndBattle()
            {
                int id = userData.others.getAvailableTeamID()[0];
                TrialExercise_Battle_Sent tbs = new TrialExercise_Battle_Sent(userData.Teams[id]);
                return userData.battle.EndTrial(tbs.BattleResult);
            }
            private UserData userData;
        }













    }


    public class MapManager
    {
        public MapManager(UserData userData)
        {
            this.userData = userData;
            this.missionInfo = userData.MissionInfo;
            this.data = missionInfo.GetFirstData();
            this.battleData = new BattleData(userData);
            this.random = new Random();
        }
        public UserData userData;
        public MissionInfo missionInfo;
        public MissionInfo.Data data;
        public Random random;
        public BattleData battleData;




        public string result = "";
        public string strbattledata;
    }

}

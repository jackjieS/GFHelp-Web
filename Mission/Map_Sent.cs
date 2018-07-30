using GFHelp.Core.Action.BattleBase;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Mission
{
    public class Map_Sent
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



        }
        public enum MissionType
        {
            Normal,
            Emergency,
            Night,
            Activity
        };
        public static class Map0_1
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 1;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(1);//主力
            public static Spots spots2 = new Spots(1);//辅助

            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(1, 2, 1);
            public static TeamMove teammove2 = new TeamMove(2, 3, 1);
            public static TeamMove teammove3 = new TeamMove(3, 4, 1);
            public static TeamMove teammove4 = new TeamMove(4, 5, 1);
            public static TeamMove teammove5 = new TeamMove(5, 6, 1);


            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 3033;//撤离
        }



        public static class map0_2
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static MissionType missionType = MissionType.Normal;
            public static int mission_id = 2;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(9);//主力
            public static Spots spots2 = new Spots(12);//辅助

            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(9, 17, 1);
            public static TeamMove teammove2 = new TeamMove(17, 18, 1);
            public static TeamMove teammove3 = new TeamMove(18, 19, 1);
            public static TeamMove teammove4 = new TeamMove(19, 16, 1);
            public static TeamMove teammove5 = new TeamMove(16, 23, 1);
            public static TeamMove teammove6 = new TeamMove(23, 25, 1);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 3033;//撤离
        }

        public static class map1_6
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 10;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(133);//主力
            public static Spots spots2 = new Spots(133);//辅助

            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(133, 134, 1);
            public static TeamMove teammove2 = new TeamMove(134, 135, 1);
            public static TeamMove teammove3 = new TeamMove(135, 139, 1);
            public static TeamMove teammove4 = new TeamMove(139, 136, 1);
            public static TeamMove teammove5 = new TeamMove(136, 144, 1);
            public static TeamMove teammove6 = new TeamMove(144, 148, 1);
            public static TeamMove teammove7 = new TeamMove(148, 149, 1);
            public static TeamMove teammove8 = new TeamMove(149, 146, 1);
            public static TeamMove teammove9 = new TeamMove(146, 147, 1);
            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                        _dic_TeamMove[7] = teammove8;
                        _dic_TeamMove[8] = teammove9;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序

            public static int BossPos(string result)
            {
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["enemy_move"];
                foreach (JsonData item in jsonData)
                {
                    if (item["from_spot_id"].Int == 145 && item["to_spot_id"].Int == 146)
                        return 1;//需要打还带草在打boss

                }
                return 0;//直接打boss再占领
            }

            public static int HomePos1(string result)
            {
                try
                {
                    JsonData jsonData = JsonMapper.ToObject(result);
                    jsonData = jsonData["enemy_move"];
                    foreach (JsonData item in jsonData)
                    {
                        if (item["from_spot_id"].Int == 135 && item["to_spot_id"].Int == 134)
                            return 1;//需要打

                    }
                    return 0;//不需要打
                }
                catch (Exception)
                {
                    return 0;//不需要打
                }

            }
            public static int HomePos2(string result)
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
            public static int withdrawSpot = 1948;//撤离
        }


        public static class map2_6
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 20;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(260);//主力


            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(260, 261, 1);
            public static TeamMove teammove2 = new TeamMove(261, 263, 1);
            public static TeamMove teammove3 = new TeamMove(263, 267, 1);
            public static TeamMove teammove4 = new TeamMove(267, 271, 1);
            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序

        }

        public static class map3_6
        {
            public static MissionType missionType = MissionType.Normal;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 30;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(427);//主力
            public static Spots spots2 = new Spots(431);//辅助

            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(427, 422, 1);
            public static TeamMove teammove2 = new TeamMove(422, 423, 1);
            public static TeamMove teammove3 = new TeamMove(423, 424, 1);
            public static TeamMove teammove4 = new TeamMove(424, 425, 1);
            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 427;//撤离
        }

        public static class map4_6
        {
            public static MissionType missionType = MissionType.Normal;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 40;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(582);//主力
            public static Spots spots2 = new Spots(587);//辅助

            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(582, 588, 1);
            public static TeamMove teammove2 = new TeamMove(588, 594, 1);
            public static TeamMove teammove3 = new TeamMove(594, 598, 1);
            public static TeamMove teammove4 = new TeamMove(598, 604, 1);
            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序

        }

        public static class map5_6
        {
            public static MissionType missionType = MissionType.Normal;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 50;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(803);//主力
            public static Spots spots2 = new Spots(807);//辅助

            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(803, 808, 1);
            public static TeamMove teammove2 = new TeamMove(808, 813, 1);
            public static TeamMove teammove3 = new TeamMove(813, 820, 1);
            public static TeamMove teammove4 = new TeamMove(820, 826, 1);
            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序

        }

        public static class map6_6
        {
            public static MissionType missionType = MissionType.Normal;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 60;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(1616);//主力
            public static Spots spots2 = new Spots(1618);//辅助

            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(1616, 1634, 1);
            public static TeamMove teammove2 = new TeamMove(1634, 1635, 1);
            public static TeamMove teammove3 = new TeamMove(1635, 1620, 1);
            public static TeamMove teammove4 = new TeamMove(1620, 1621, 1);
            public static TeamMove teammove5 = new TeamMove(1621, 1636, 1);
            public static TeamMove teammove6 = new TeamMove(1636, 1632, 1);
            public static TeamMove teammove7 = new TeamMove(1632, 1633, 1);
            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序

        }

        public static class map8_6
        {
            public static MissionType missionType = MissionType.Normal;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 80;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(3788);//主力
            public static Spots spots2 = new Spots(3788);//主力
            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(3788, 3658, 1);
            public static TeamMove teammove2 = new TeamMove(3658, 3789, 1);
            public static TeamMove teammove3 = new TeamMove(3789, 3662, 1);

            public static TeamMove teammove4 = new TeamMove(3662, 3679, 1);
            public static TeamMove teammove5 = new TeamMove(3679, 3681, 1);
            public static TeamMove teammove6 = new TeamMove(3681, 3682, 1);

            public static TeamMove teammove7 = new TeamMove(3682, 3667, 1);
            public static TeamMove teammove8 = new TeamMove(3667, 3673, 1);
            public static TeamMove teammove9 = new TeamMove(3673, 3664, 1);

            public static TeamMove teammove10 = new TeamMove(3664, 3670, 1);
            public static TeamMove teammove11 = new TeamMove(3670, 3669, 1);

            public static TeamMove teammove12 = new TeamMove(3669, 3678, 1);
            public static TeamMove teammove13 = new TeamMove(3678, 3671, 1);
            public static TeamMove teammove14 = new TeamMove(3671, 3677, 1);
            public static TeamMove teammove15 = new TeamMove(3677, 3668, 1);











            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                        _dic_TeamMove[7] = teammove8;
                        _dic_TeamMove[8] = teammove9;
                        _dic_TeamMove[9] = teammove10;
                        _dic_TeamMove[10] = teammove11;

                        _dic_TeamMove[11] = teammove12;
                        _dic_TeamMove[12] = teammove13;
                        _dic_TeamMove[13] = teammove14;
                        _dic_TeamMove[14] = teammove15;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序

            public static int HomePos1(string result)
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
            public static int HomePos2(string result)
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
            public static int HomePos3(string result)
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
            public static int PosCheck1(string result)
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
            public static int PosCheck2(string result)
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

        public static class map10_6
        {
            public static MissionType missionType = MissionType.Normal;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 100;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(5363);//主力
            public static Spots spots2 = new Spots(5363);//主力
            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(5363, 5360, 1);
            public static TeamMove teammove2 = new TeamMove(5360, 5357, 1);
            public static TeamMove teammove3 = new TeamMove(5357, 5346, 1);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;


                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序


        }


        public static class map7_6boss
        {
            public static MissionType missionType = MissionType.Normal;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 70;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(1948);//主力
            public static Spots spots2 = new Spots(1948);//辅助

            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(1948, 1947, 1);
            public static TeamMove teammove2 = new TeamMove(1947, 1948, 2);
            public static TeamMove teammove3 = new TeamMove(1948, 1947, 2);

            public static TeamMove teammove4 = new TeamMove(1947, 1946, 1);
            public static TeamMove teammove5 = new TeamMove(1946, 2152, 1);
            public static TeamMove teammove6 = new TeamMove(2152, 1941, 1);
            public static TeamMove teammove7 = new TeamMove(1941, 1942, 1);
            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 1948;//撤离
        }

        public static class map4_1
        {
            public static MissionType missionType = MissionType.Normal;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 35;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(513);//主力
            public static Spots spots2 = new Spots(516);//辅助

            public static Spots[] Mission_Start_spots = { spots2, spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(513, 512, 1);
            public static TeamMove teammove2 = new TeamMove(512, 511, 1);
            public static TeamMove teammove3 = new TeamMove(511, 509, 1);
            public static TeamMove teammove4 = new TeamMove(509, 508, 1);
            public static TeamMove teammove5 = new TeamMove(508, 509, 1);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }

        public static class map10_4e
        {
            public static MissionType missionType = MissionType.Normal;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 104;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(5494);//主力
            public static Spots spots2 = new Spots(5480);//辅助

            public static Spots[] Mission_Start_spots = { spots2, spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(5494, 5495, 1);
            public static TeamMove teammove2 = new TeamMove(5495, 5492, 1);
            public static TeamMove teammove3 = new TeamMove(5492, 5495, 1);
            public static TeamMove teammove4 = new TeamMove(5495, 5494, 1);
            public static TeamMove teammove5 = new TeamMove(5494, 5497, 1);
            public static TeamMove teammove6 = new TeamMove(5497, 5494, 1);
            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }

        public static class map7_6
        {
            public static MissionType missionType = MissionType.Normal;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 70;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(1948);//主力
            public static Spots spots2 = new Spots(1948);//辅助

            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(1948, 1947, 1);
            public static TeamMove teammove2 = new TeamMove(1947, 1949, 1);
            public static TeamMove teammove3 = new TeamMove(1949, 1947, 1);
            public static TeamMove teammove4 = new TeamMove(1947, 1948, 2);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 1948;//撤离
        }


        public static class map1_1e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 11;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(151);//主力
            public static Spots spots2 = new Spots(151);//主力
            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(151, 152, 1);
            public static TeamMove teammove2 = new TeamMove(152, 153, 1);
            public static TeamMove teammove3 = new TeamMove(153, 158, 1);
            public static TeamMove teammove4 = new TeamMove(158, 159, 1);


            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map1_2e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 12;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static MissionType missionType = MissionType.Normal;
            public static Spots spots1 = new Spots(160);//主力
            public static Spots spots2 = new Spots(160);//主力
            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(160, 162, 1);
            public static TeamMove teammove2 = new TeamMove(162, 163, 1);
            public static TeamMove teammove3 = new TeamMove(163, 166, 1);
            public static TeamMove teammove4 = new TeamMove(166, 168, 1);
            public static TeamMove teammove5 = new TeamMove(168, 170, 1);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map1_3e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 13;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(171);//主力
            public static Spots spots2 = new Spots(171);//主力
            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(171, 173, 1);
            public static TeamMove teammove2 = new TeamMove(173, 176, 1);
            public static TeamMove teammove3 = new TeamMove(176, 180, 1);
            public static TeamMove teammove4 = new TeamMove(180, 183, 1);
            public static TeamMove teammove5 = new TeamMove(183, 184, 1);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map1_4e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 14;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(185);//主力
            public static Spots spots2 = new Spots(185);//主力
            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(185, 186, 1);
            public static TeamMove teammove2 = new TeamMove(186, 187, 1);
            public static TeamMove teammove3 = new TeamMove(187, 191, 1);
            public static TeamMove teammove4 = new TeamMove(191, 188, 1);

            public static TeamMove teammove5 = new TeamMove(188, 196, 1);
            public static TeamMove teammove6 = new TeamMove(196, 200, 1);
            public static TeamMove teammove7 = new TeamMove(200, 201, 1);
            public static TeamMove teammove8 = new TeamMove(201, 198, 1);
            public static TeamMove teammove9 = new TeamMove(198, 199, 1);
            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;

                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                        _dic_TeamMove[7] = teammove8;
                        _dic_TeamMove[8] = teammove9;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map2_1e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 21;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(284);//主力
            public static Spots spots2 = new Spots(277);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(284, 286, 1);
            public static TeamMove teammove2 = new TeamMove(286, 285, 1);
            public static TeamMove teammove3 = new TeamMove(285, 281, 1);



            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;


                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map2_2e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 22;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(290);//主力
            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(290, 292, 1);
            public static TeamMove teammove2 = new TeamMove(292, 295, 1);
            public static TeamMove teammove3 = new TeamMove(295, 294, 1);
            public static TeamMove teammove4 = new TeamMove(294, 297, 1);
            public static TeamMove teammove5 = new TeamMove(297, 298, 1);
            public static TeamMove teammove6 = new TeamMove(298, 300, 1);


            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map2_3e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 23;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(302);//主力
            public static Spots spots2 = new Spots(302);//主力
            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(302, 304, 1);
            public static TeamMove teammove2 = new TeamMove(304, 309, 1);
            public static TeamMove teammove3 = new TeamMove(309, 308, 1);
            public static TeamMove teammove4 = new TeamMove(308, 316, 1);



            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;


                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map2_4e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 24;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(317);//主力
            public static Spots spots2 = new Spots(302);//主力
            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(317, 318, 1);
            public static TeamMove teammove2 = new TeamMove(318, 320, 1);
            public static TeamMove teammove3 = new TeamMove(320, 324, 1);
            public static TeamMove teammove4 = new TeamMove(324, 328, 1);



            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;


                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }

        public static class map3_1e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 31;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(449);//主力
            public static Spots spots2 = new Spots(449);//主力
            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(449, 446, 1);
            public static TeamMove teammove2 = new TeamMove(446, 442, 1);
            public static TeamMove teammove3 = new TeamMove(442, 440, 1);
            public static TeamMove teammove4 = new TeamMove(440, 439, 1);
            public static TeamMove teammove5 = new TeamMove(439, 438, 1);


            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }

        public static class map3_2e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 32;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(452);//主力
            public static Spots spots2 = new Spots(452);//主力
            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(452, 455, 1);
            public static TeamMove teammove2 = new TeamMove(455, 459, 1);
            public static TeamMove teammove3 = new TeamMove(459, 462, 1);



            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;


                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }

        public static class map3_3e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 33;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(479);//主力
            public static Spots spots2 = new Spots(465);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(479, 478, 1);
            public static TeamMove teammove2 = new TeamMove(478, 481, 1);
            public static TeamMove teammove3 = new TeamMove(481, 480, 1);



            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;


                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }

        public static class map3_4e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 34;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(494);//主力
            public static Spots spots2 = new Spots(498);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(494, 489, 1);
            public static TeamMove teammove2 = new TeamMove(489, 490, 1);
            public static TeamMove teammove3 = new TeamMove(490, 491, 1);
            public static TeamMove teammove4 = new TeamMove(491, 492, 1);


            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }


        public static class map4_1e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 41;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(612);//主力
            public static Spots spots2 = new Spots(609);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(612, 613, 1);
            public static TeamMove teammove2 = new TeamMove(613, 617, 1);
            public static TeamMove teammove3 = new TeamMove(617, 620, 1);
            public static TeamMove teammove4 = new TeamMove(620, 621, 1);
            public static TeamMove teammove5 = new TeamMove(621, 623, 1);
            public static TeamMove teammove6 = new TeamMove(623, 625, 1);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }

        public static class map4_2e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 42;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(642);//主力
            public static Spots spots2 = new Spots(630);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(642, 641, 1);
            public static TeamMove teammove2 = new TeamMove(641, 637, 1);
            public static TeamMove teammove3 = new TeamMove(637, 640, 1);
            public static TeamMove teammove4 = new TeamMove(640, 639, 1);


            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }

        public static class map4_3e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 43;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(658);//主力
            public static Spots spots2 = new Spots(643);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(658, 659, 1);
            public static TeamMove teammove2 = new TeamMove(659, 660, 1);
            public static TeamMove teammove3 = new TeamMove(660, 661, 1);
            public static TeamMove teammove4 = new TeamMove(661, 662, 1);


            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map4_4e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 44;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(664);//主力
            public static Spots spots2 = new Spots(669);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(664, 670, 1);
            public static TeamMove teammove2 = new TeamMove(670, 676, 1);
            public static TeamMove teammove3 = new TeamMove(676, 680, 1);
            public static TeamMove teammove4 = new TeamMove(680, 686, 1);


            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map5_1e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 51;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(832);//主力
            public static Spots spots2 = new Spots(850);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(832, 833, 1);
            public static TeamMove teammove2 = new TeamMove(833, 837, 1);
            public static TeamMove teammove3 = new TeamMove(837, 841, 1);
            public static TeamMove teammove4 = new TeamMove(841, 843, 1);

            public static TeamMove teammove5 = new TeamMove(843, 844, 1);
            public static TeamMove teammove6 = new TeamMove(850, 846, 1);//
            public static TeamMove teammove7 = new TeamMove(846, 850, 1);//
            public static TeamMove teammove8 = new TeamMove(850, 851, 1);//

            public static TeamMove teammove9 = new TeamMove(844, 845, 1);
            public static TeamMove teammove10 = new TeamMove(845, 842, 1);
            public static TeamMove teammove11 = new TeamMove(842, 839, 1);
            public static TeamMove teammove12 = new TeamMove(839, 835, 1);
            public static TeamMove teammove13 = new TeamMove(835, 834, 1);
            public static TeamMove teammove14 = new TeamMove(834, 838, 1);












            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;

                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                        _dic_TeamMove[7] = teammove8;

                        _dic_TeamMove[8] = teammove9;
                        _dic_TeamMove[9] = teammove10;
                        _dic_TeamMove[10] = teammove11;
                        _dic_TeamMove[11] = teammove12;

                        _dic_TeamMove[12] = teammove13;
                        _dic_TeamMove[13] = teammove14;


                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map5_2e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 52;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(857);//主力
            public static Spots spots2 = new Spots(877);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(857, 861, 1);
            public static TeamMove teammove2 = new TeamMove(861, 866, 1);
            public static TeamMove teammove3 = new TeamMove(866, 870, 1);
            public static TeamMove teammove4 = new TeamMove(870, 869, 1);


            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map5_3e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 53;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(907);//主力
            public static Spots spots2 = new Spots(905);//主力
            public static Spots spots3 = new Spots(907);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(905, 903, 1);//
            public static TeamMove teammove2 = new TeamMove(907, 908, 1);
            public static TeamMove teammove3 = new TeamMove(908, 904, 1);
            public static TeamMove teammove4 = new TeamMove(904, 902, 1);

            public static TeamMove teammove5 = new TeamMove(902, 898, 1);
            public static TeamMove teammove6 = new TeamMove(898, 895, 1);
            public static TeamMove teammove7 = new TeamMove(895, 889, 1);
            public static TeamMove teammove8 = new TeamMove(889, 886, 1);

            public static TeamMove teammove9 = new TeamMove(886, 884, 1);
            public static TeamMove teammove10 = new TeamMove(884, 883, 1);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;

                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                        _dic_TeamMove[7] = teammove8;

                        _dic_TeamMove[8] = teammove9;
                        _dic_TeamMove[9] = teammove10;


                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }
        public static class map5_4e
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 54;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(909);//主力
            public static Spots spots2 = new Spots(913);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(909, 914, 1);
            public static TeamMove teammove2 = new TeamMove(914, 919, 1);
            public static TeamMove teammove3 = new TeamMove(919, 926, 1);
            public static TeamMove teammove4 = new TeamMove(926, 932, 1);


            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;

                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 5494;//撤离
        }


        public static class map2_4n
        {
            public static MissionType missionType = MissionType.Night;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 90008;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(1330);//主力


            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(1330, 1332, 1);
            public static TeamMove teammove2 = new TeamMove(1332, 1453, 1);
            public static TeamMove teammove3 = new TeamMove(1453, 1454, 1);
            public static TeamMove teammove4 = new TeamMove(1454, 1457, 1);
            public static TeamMove teammove5 = new TeamMove(1457, 1461, 1);


            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;


                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序


            public static int PosCheck1(string result)
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


        public static class map3_4n
        {
            public static MissionType missionType = MissionType.Night;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 90012;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(1485);//主力


            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(1485, 1347, 1);
            public static TeamMove teammove2 = new TeamMove(1347, 1503, 1);
            public static TeamMove teammove3 = new TeamMove(1503, 1504, 1);
            public static TeamMove teammove4 = new TeamMove(1504, 1505, 1);//分支开始
            public static TeamMove teammove5 = new TeamMove(1505, 1489, 1);//分支1向上
            public static TeamMove teammove6 = new TeamMove(1947, 1949, 1);//分支2向左1
            public static TeamMove teammove7 = new TeamMove(1949, 1947, 1);//分支2向左2
            public static TeamMove teammove8 = new TeamMove(1505, 1509, 1);//分支3
            public static TeamMove teammove9 = new TeamMove(1509, 1506, 1);//分支3
            public static TeamMove teammove10 = new TeamMove(1509, 1507, 1);//分支3
            public static TeamMove teammove11 = new TeamMove(1489, 1506, 1);
            public static TeamMove teammove12 = new TeamMove(1489, 1490, 1);
            public static TeamMove teammove13 = new TeamMove(1489, 1501, 1);
            public static TeamMove teammove14 = new TeamMove(1489, 1476, 1);
            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                        _dic_TeamMove[7] = teammove8;
                        _dic_TeamMove[8] = teammove9;
                        _dic_TeamMove[9] = teammove10;
                        _dic_TeamMove[10] = teammove11;
                        _dic_TeamMove[11] = teammove12;
                        _dic_TeamMove[12] = teammove13;
                        _dic_TeamMove[13] = teammove14;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序



            public static int withdrawSpot = 3033;//撤离

            public static int BossPos(string result)
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
            public static int rPos(string result)
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

        public static class map5_2n
        {
            public static MissionType missionType = MissionType.Night;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 90018;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(3033);//主力
            public static Spots spots2 = new Spots(3057);//辅助

            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(3033, 3037, 1);
            public static TeamMove teammove2 = new TeamMove(3037, 3038, 1);
            public static TeamMove teammove3 = new TeamMove(3038, 3047, 1);
            public static TeamMove teammove4 = new TeamMove(3047, 3052, 1);
            public static TeamMove teammove5 = new TeamMove(3052, 3051, 1);
            public static TeamMove teammove6 = new TeamMove(3051, 3056, 1);
            public static TeamMove teammove7 = new TeamMove(3056, 3057, 2);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序



            public static int withdrawSpot = 3057;//撤离
        }

        public static class map6_4n
        {
            public static MissionType missionType = MissionType.Night;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 90024;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(4066);//主力
            public static Spots spots2 = new Spots(4070);//主力

            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(4066, 4067, 1);
            public static TeamMove teammove2 = new TeamMove(4067, 4077, 1);
            public static TeamMove teammove3 = new TeamMove(4077, 4078, 1);
            public static TeamMove teammove4 = new TeamMove(4078, 4082, 1);//分支开始
            public static TeamMove teammove5 = new TeamMove(4082, 4079, 1);//分支1向上
            public static TeamMove teammove6 = new TeamMove(4079, 4068, 1);//分支2向左1
            public static TeamMove teammove7 = new TeamMove(4068, 4079, 1);//分支2向左2
            public static TeamMove teammove8 = new TeamMove(4079, 4082, 1);//分支3

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                        _dic_TeamMove[7] = teammove8;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 4082;//撤离
        }
        public static class map8_1n
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 90029;
            public static MissionType missionType = MissionType.Normal;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(7069);//主力
            public static Spots spots2 = new Spots(7066);//主力
            public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(7069, 7076, 1);
            public static TeamMove teammove2 = new TeamMove(7076, 7068, 1);
            public static TeamMove teammove3 = new TeamMove(7068, 7067, 1);

            public static TeamMove teammove4 = new TeamMove(7067, 7075, 1);
            public static TeamMove teammove5 = new TeamMove(7075, 7074, 1);
            public static TeamMove teammove6 = new TeamMove(7074, 7066, 2);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 7066;//撤离

        }



        public static class mapcubee1_4
        {
            public static MissionType missionType = MissionType.Activity;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 10021;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(3243);//主力
            public static Spots spots2 = new Spots(3243);//主力

            public static Spots[] Mission_Start_spots = { spots1};//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(3243, 3244, 1);//注意两个点哦
            public static TeamMove teammove2 = new TeamMove(3244, 3245, 1);
            public static TeamMove teammove3 = new TeamMove(3245, 3246, 1);
            public static TeamMove teammove4 = new TeamMove(3246, 3247, 1);
            public static TeamMove teammove5 = new TeamMove(3247, 3240, 1);
            public static TeamMove teammove6 = new TeamMove(3240, 3233, 1);
            public static TeamMove teammove7 = new TeamMove(3233, 3234, 1);
            public static TeamMove teammove8 = new TeamMove(3234, 3235, 1);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                        _dic_TeamMove[7] = teammove8;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序
            public static int withdrawSpot = 4082;//撤离
        }

        public static class maparctic1_4
        {
            public static MissionType missionType = MissionType.Activity;
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
            public static int mission_id = 10008;
            //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
            public static Spots spots1 = new Spots(2054);//主力
            public static Spots spots2 = new Spots(2054);//主力

            public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

            public static TeamMove teammove1 = new TeamMove(2054, 2056, 1);//注意两个点哦
            public static TeamMove teammove2 = new TeamMove(2056, 2057, 1);
            public static TeamMove teammove3 = new TeamMove(2057, 2210, 1);
            public static TeamMove teammove4 = new TeamMove(2210, 2259, 1);
            public static TeamMove teammove5 = new TeamMove(2259, 2260, 1);
            public static TeamMove teammove6 = new TeamMove(2260, 2261, 1);
            public static TeamMove teammove7 = new TeamMove(2261, 2262, 1);
            public static TeamMove teammove8 = new TeamMove(2262, 2263, 1);

            public static TeamMove teammove9 = new TeamMove(2263, 2264, 1);
            public static TeamMove teammove10 = new TeamMove(2264, 2253, 1);
            public static TeamMove teammove11 = new TeamMove(2253, 2252, 1);

            public static TeamMove teammove12 = new TeamMove(2252, 2060, 1);

            public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
            public static Dictionary<int, TeamMove> dic_TeamMove
            {
                get
                {
                    if (_dic_TeamMove.Count == 0)
                    {
                        _dic_TeamMove[0] = teammove1;
                        _dic_TeamMove[1] = teammove2;
                        _dic_TeamMove[2] = teammove3;
                        _dic_TeamMove[3] = teammove4;
                        _dic_TeamMove[4] = teammove5;
                        _dic_TeamMove[5] = teammove6;
                        _dic_TeamMove[6] = teammove7;
                        _dic_TeamMove[7] = teammove8;

                        _dic_TeamMove[8] = teammove9;
                        _dic_TeamMove[9] = teammove10;
                        _dic_TeamMove[10] = teammove11;

                        _dic_TeamMove[11] = teammove12;
                    }

                    return _dic_TeamMove;
                }
                set
                {
                    _dic_TeamMove = value;
                }
            }//梯队移动的顺序

        }










    }
}

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
                if (result.Contains("error")) return 0;//error 代码
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["night_enemy"];
                foreach (JsonData item in jsonData)
                {
                    if (item["to_spot_id"].Int == toSpot)
                    {
                        return 1;//需要打
                    }
                }
                return 2;//不需要打
            }



        }
        public static class Map0_2
        {
            //要给spots1 2 赋值 梯队ID
            //要给teammove 赋值 梯队ID
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











    }
}

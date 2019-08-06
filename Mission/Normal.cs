using GFHelp.Core.Action.BattleBase;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using static GFHelp.Mission.Map_Controller;

namespace GFHelp.Mission
{
    public class Normal: MapManager
    {

        public Normal(UserData userData) : base(userData)
        {

        }
        public static string Test()
        {
            return "Hello world";
        }




        public void mapnormal()
        {
            data.Story = true;

            map1_1(); userData.battle.Check_Equip_Gun_FULL();
            map1_2(); userData.battle.Check_Equip_Gun_FULL();
            map1_3(); userData.battle.Check_Equip_Gun_FULL();
            map1_4(); userData.battle.Check_Equip_Gun_FULL();
            map1_5(); userData.battle.Check_Equip_Gun_FULL();
            map1_6(); userData.battle.Check_Equip_Gun_FULL();
            map2_1(); userData.battle.Check_Equip_Gun_FULL();
            map2_2(); userData.battle.Check_Equip_Gun_FULL();
            map2_3(); userData.battle.Check_Equip_Gun_FULL();
            map2_4(); userData.battle.Check_Equip_Gun_FULL();
            map2_5(); userData.battle.Check_Equip_Gun_FULL();
            map2_6(); userData.battle.Check_Equip_Gun_FULL();
            map3_1(); userData.battle.Check_Equip_Gun_FULL();
            map3_2(); userData.battle.Check_Equip_Gun_FULL();
            map3_3(); userData.battle.Check_Equip_Gun_FULL();
            map3_4(); userData.battle.Check_Equip_Gun_FULL();
            map3_5(); userData.battle.Check_Equip_Gun_FULL();
            map3_6(); userData.battle.Check_Equip_Gun_FULL();
            map4_1(); userData.battle.Check_Equip_Gun_FULL();
            map4_2(); userData.battle.Check_Equip_Gun_FULL();
            map4_3(); userData.battle.Check_Equip_Gun_FULL();

            map4_4(); userData.battle.Check_Equip_Gun_FULL();
            map4_5(); userData.battle.Check_Equip_Gun_FULL();
            map4_6(); userData.battle.Check_Equip_Gun_FULL();
            map5_1(); userData.battle.Check_Equip_Gun_FULL();
            map5_2(); userData.battle.Check_Equip_Gun_FULL();
            map5_3(); userData.battle.Check_Equip_Gun_FULL();
            map5_4(); userData.battle.Check_Equip_Gun_FULL();
            map5_5(); userData.battle.Check_Equip_Gun_FULL();
            map5_6(); userData.battle.Check_Equip_Gun_FULL();
            map6_1(); userData.battle.Check_Equip_Gun_FULL();
            map6_2(); userData.battle.Check_Equip_Gun_FULL();
            map6_3(); userData.battle.Check_Equip_Gun_FULL();
            map6_4(); userData.battle.Check_Equip_Gun_FULL();
            map6_5(); userData.battle.Check_Equip_Gun_FULL();
            map6_6(); userData.battle.Check_Equip_Gun_FULL();
            data.Loop = false;
        }

        public void mapnormal_boss()
        {

            map1_6(); userData.battle.Check_Equip_Gun_FULL();
            map1_6(); userData.battle.Check_Equip_Gun_FULL();
            map1_6(); userData.battle.Check_Equip_Gun_FULL();

            map2_6(); userData.battle.Check_Equip_Gun_FULL();

            map3_6(); userData.battle.Check_Equip_Gun_FULL();

            map4_6(); userData.battle.Check_Equip_Gun_FULL();

            map5_6(); userData.battle.Check_Equip_Gun_FULL();

            map6_6(); userData.battle.Check_Equip_Gun_FULL();

            data.Loop = false;
        }

        public void mapemergency()
        {
            data.Story = true;
            map1_1e(); userData.battle.Check_Equip_Gun_FULL();
            map1_2e(); userData.battle.Check_Equip_Gun_FULL();
            map1_3e(); userData.battle.Check_Equip_Gun_FULL();
            map1_4e(); userData.battle.Check_Equip_Gun_FULL();

            map2_1e(); userData.battle.Check_Equip_Gun_FULL();
            map2_2e(); userData.battle.Check_Equip_Gun_FULL();
            map2_3e(); userData.battle.Check_Equip_Gun_FULL();
            map2_4e(); userData.battle.Check_Equip_Gun_FULL();

            map3_1e(); userData.battle.Check_Equip_Gun_FULL();
            map3_2e(); userData.battle.Check_Equip_Gun_FULL();
            map3_3e(); userData.battle.Check_Equip_Gun_FULL();
            map3_4e(); userData.battle.Check_Equip_Gun_FULL();

            map4_1e(); userData.battle.Check_Equip_Gun_FULL();
            map4_2e(); userData.battle.Check_Equip_Gun_FULL();
            map4_3e(); userData.battle.Check_Equip_Gun_FULL();
            map4_4e(); userData.battle.Check_Equip_Gun_FULL();

            map0_1(); userData.battle.Check_Equip_Gun_FULL();
            data.Loop = false;
        }


        public void maptest()
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(DateTime.Now.ToString());
                Thread.Sleep(1000);
            }
        }

        public void map0_2()
        {

            
            
            Map_Controller.map0_2 map = new Map_Controller.map0_2(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(17, 0, 0, random.Next(8, 10), 9544, 28800, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(18, 0, 0, random.Next(8, 10), 8449, 23684, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(16, 0, 0, random.Next(8, 10), 4795, 11079, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO (ref data, 0, ref result);
            }



            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(23, 0, 0, random.Next(8, 10), 6270, 18000, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(25, 0, 0, random.Next(8, 10), 6540, 18184, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }




            userData.battle.endTurn(data);
        }

        public void map1_1()
        {
            
            
            
            Map_Controller.map1_1 map = new Map_Controller.map1_1(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(90, 0, 0, random.Next(8, 10), 82, 50, 90001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            string endTrun  =   userData.battle.startTurn(data);


            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "1_2 成功").userInfo();

            }
            else
            {
                userData.battle.abortMission();
                map1_2();
            }

        }
        public void map1_2()
        {
            map1_2 map = new map1_2(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(94, 0, 0, random.Next(8, 10), 132, 5590, 15189, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(95, 0, 0, random.Next(8, 10), 176, 7946, 15252, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(96, 0, 0, random.Next(8, 10), 264, 3804, 10388, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "1_2 成功").userInfo();

            }
            else
            {
                userData.battle.abortMission();
                map1_2();
            }






        }
        public void map1_3()
        {



            map1_3 map = new map1_3(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(101, 0, 0, random.Next(8, 10), 225, 345, 20001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(107, 0, 0, random.Next(8, 10), 480, 415, 20002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "1_3 成功").userInfo();

            }
            else
            {
                userData.battle.abortMission();
                map1_3();
            }






        }

        public void map1_4()
        {



            map1_4 map = new map1_4(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(113, 0, 0, random.Next(8, 10), 330, 388, 20002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(114, 0, 0, random.Next(8, 10), 230, 390, 20001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(116, 0, 0, random.Next(8, 10), 221, 512, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(118, 0, 0, random.Next(8, 10), 221, 512, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "1_4 成功").userInfo();

            }
            else
            {
                userData.battle.abortMission();
                map1_4();
            }






        }

        public void map1_5()
        {



            map1_5 map = new map1_5(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.endTurn(data);
            strbattledata = battleData.setData(124, 0, 0, random.Next(8, 10), 328, 634, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(128, 0, 0, random.Next(8, 10), 235, 430, 20001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(131, 0, 0, random.Next(8, 10), 286, 606, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);



            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "1_5 成功").userInfo();

            }
            else
            {
                userData.battle.abortMission();
                map1_5();
            }






        }
        public void map1_6()
        {
            
            
            
            Map_Controller.map1_6 map = new Map_Controller.map1_6(data);

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(135, 0, 0, random.Next(8, 10), 279, 512, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTurnResult= userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove_Random(map.teamMove.dic[map.stepNum++],data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            if (Function.Normal_PosCheck_type2(endTurnResult, 136) == 1)
            {
                strbattledata = battleData.setData(136, 0, 0, random.Next(8, 10), 435, 519, 20002, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            endTurnResult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(endTurnResult, 136) == 1)
            {
                strbattledata = battleData.setData(136, 0, 0, random.Next(8, 10), 435, 519, 20002, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            if (Function.Normal_PosCheck_type2(endTurnResult, 144) == 1)
            {
                strbattledata = battleData.setData(144, 0, 0, random.Next(8, 10), 480, 415, 20002, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove_Random(map.teamMove.dic[map.stepNum++],data);

            if (Function.Normal_PosCheck_type2(endTurnResult, 148) == 1)
            {
                strbattledata = battleData.setData(148, 0, 0, random.Next(8, 10), 480, 415, 20002, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            if (Function.Normal_PosCheck_type2(endTurnResult, 149) == 1)
            {
                strbattledata = battleData.setData(149, 0, 0, random.Next(8, 10), 480, 415, 20002, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }



            endTurnResult = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(endTurnResult, 149) == 1)
            {
                strbattledata = battleData.setData(149, 0, 0, random.Next(8, 10), 480, 415, 20002, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            if (Function.Normal_PosCheck_type2(endTurnResult, 146) == 1)
            {
                strbattledata = battleData.setData(146, 0, 0, random.Next(8, 10), 480, 415, 20002, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(147, 0, 0, random.Next(8, 10), 480, 415, 20002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "1_6BOSS 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map1_6();
            }
        }

        public void map2_1()
        {
            map2_1 map = new map2_1(data);

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(204, 0, 0, random.Next(8, 10), 560, 565, 20002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            string endTurn = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(206, 0, 0, random.Next(8, 10), 346, 533, 20003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(209, 0, 0, random.Next(8, 10), 385, 185, 20003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            endTurn = userData.battle.endTurn(data);
            if (endTurn.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "2_1 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map2_1();
            }
        }

        public void map2_2()
        {
            
            
            
            Map_Controller.map2_2 map = new Map_Controller.map2_2(data);

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(212, 0, 0, random.Next(8, 10), 26254, 389, 20003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            //212
            string endTurn = userData.battle.endTurn(data);
            int pos1 = Map_Controller.Function.Normal_PosCheck_type2(endTurn, 212);
            if (pos1 == 1)
            {

                strbattledata = battleData.setData(212, 0, 0, random.Next(8, 10), 654, 1488, 20004, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }



            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);



            strbattledata = battleData.setData(216, 0, 0, random.Next(8, 10), 654, 1488, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);//能否靠这个猜测第二个光头 如果记得被占则终止作战
            strbattledata = battleData.setData(216, 0, 0, random.Next(8, 10), 645, 1646, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(219, 0, 0, random.Next(8, 10), 645, 1646, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "2-2 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map2_2();
            }
        }

        public void map2_3()
        {
            
            
            
            Map_Controller.map2_3 map = new Map_Controller.map2_3(data);





            userData.battle.startMission(map, data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(229, 0, 0, random.Next(8, 10), 516, 1368, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(228, 0, 0, random.Next(8, 10), 781, 1178, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(224, 0, 0, random.Next(8, 10), 575, 1370, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "2-3成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map2_3();
            }
        }

        public void map2_4()
        {
            
            
            
            map2_4 map = new map2_4(data);




            userData.battle.startMission(map, data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.endTurn(data);

            strbattledata = battleData.setData(238, 0, 0, random.Next(8, 10), 545, 1240, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(240, 0, 0, random.Next(8, 10), 796, 1247, 20002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(241, 0, 0, random.Next(8, 10), 689, 1831, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);

            strbattledata = battleData.setData(241, 0, 0, random.Next(8, 10), 601, 1616, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(243, 0, 0, random.Next(8, 10), 719, 1974, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "2-4成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map2_4();
            }
        }

        public void map2_5()
        {
            
            
            
            map2_5 map = new map2_5(data);


            userData.battle.startMission(map, data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(247, 0, 0, random.Next(8, 10), 765, 2030, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(252, 0, 0, random.Next(8, 10), 708, 2028, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(258, 0, 0, random.Next(8, 10), 1074, 2504, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "2-4成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                map2_5();
            }
        }
        public void map2_6()
        {
            
            
            

            Map_Controller.map2_6 map = new Map_Controller.map2_6(data);
            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);




            strbattledata = battleData.setData(263, 0, 0, random.Next(8, 10), 736, 1820, 20005, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);


            strbattledata = battleData.setData(263, 0, 0, random.Next(8, 10), 1008, 7860, 20005, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);




            strbattledata = battleData.setData(271, 0, 0, random.Next(8, 10), 2804, 6356, 90004, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "2_6 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map2_6();
            }
        }
        public void map3_1()
        {
            
            
            
            map3_1 map = new map3_1(data);





            userData.battle.startMission(map, data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(353, 0, 0, random.Next(8, 10), 788, 2205, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);

            strbattledata = battleData.setData(353, 0, 0, random.Next(8, 10), 788, 2205, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "3_1 成功").userInfo();

            }
            else
            {
                userData.battle.abortMission();
                this.map3_1();
            }
        }
        public void map3_2()
        {
            
            
            
            map3_2 map = new map3_2(data);





            userData.battle.startMission(map, data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(368, 0, 0, random.Next(8, 10), 1477, 4175, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(369, 0, 0, random.Next(8, 10), 1477, 4175, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(364, 0, 0, random.Next(8, 10), 1559, 4399, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);

            strbattledata = battleData.setData(358, 1, 0, random.Next(8, 10), 1400, 2372, 20002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            strbattledata = battleData.setData(364, 0, 0, random.Next(8, 10), 1350, 3040, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            string endTrun = userData.battle.startTurn(data);


            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "3_2 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map3_2();
            }







        }
        public void map3_3()
        {
            
            
            
            map3_3 map = new map3_3(data);




            userData.battle.startMission(map, data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(379, 0, 0, random.Next(8, 10), 1498, 3488, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.Spots.dic[1]);
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(379, 0, 0, random.Next(8, 10), 1330, 3790, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            strbattledata = battleData.setData(382, 1, 0, random.Next(8, 10), 1310, 850, 20003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(373, 0, 0, random.Next(8, 10), 1498, 3488, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(372, 0, 0, random.Next(8, 10), 1500, 5080, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "3_3 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map3_3();
            }

            //userData,data





        }
        public void map3_4()
        {
            
            
            
            map3_4 map = new map3_4(data);





            userData.battle.startMission(map, data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(388, 0, 0, random.Next(8, 10), 1095, 3190, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.Spots.dic[1]);
            string endTurn = userData.battle.endTurn(data);
            int pos1 = Map_Controller.Function.Normal_PosCheck_type2(endTurn, 385);
            if (pos1 == 1)
            {

                strbattledata = battleData.setData(385, 1, 0, random.Next(8, 10), 1095, 3190, 20005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }




            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(392, 0, 0, random.Next(8, 10), 1556, 5344, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(395, 0, 0, random.Next(8, 10), 1661, 4804, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "3_4 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map3_4();
            }







        }
        public void map3_5()
        {
            
            map3_5 map = new map3_5(data);
            
            





            userData.battle.startMission(map, data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(411, 0, 0, random.Next(8, 10), 1764, 5048, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(414, 0, 0, random.Next(8, 10), 1764, 5048, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(413, 0, 0, random.Next(8, 10), 2495, 8750, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "3_5 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map3_5();
            }







        }
        public void map3_6()
        {
            
            
            
            Map_Controller.map3_6 map = new Map_Controller.map3_6(data);




            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.teamMove_Random(map.teamMove.dic[map.stepNum++],data);

            strbattledata = battleData.setData(423, 0, 0, random.Next(8, 10), 1534, 4461, 20005, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(424, 0, 0, random.Next(8, 10), 1866, 5070, 20006, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            //右移一步

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(425, 0, 0, random.Next(8, 10), 6626, 13700, 90002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "3_6 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map3_6();
            }
        }
        public void map4_1()
        {
            
            
            Map_Controller.map4_1 map = new Map_Controller.map4_1(data);
            

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(512, 0, 0, random.Next(10, 12), 1680, 4341, 20006, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            int i = userData.battle.teamMove_Random(map.teamMove.dic[map.stepNum++],data);
            if (i == 1)
            {
                strbattledata = battleData.setData(511, 0, 0, random.Next(10, 12), 2704, 8436, 20005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(509, 0, 0, random.Next(10, 12), 2704, 8436, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(508, 0, 0, random.Next(10, 12), 1409, 4563, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "4_1 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map4_1();
            }

        }
        public void map4_2()
        {
            
            map4_2 map = new map4_2(data);
            
            



            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(517, 0, 0, random.Next(8, 10), 1855, 5720, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(517, 0, 0, random.Next(8, 10), 2262, 6693, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(518, 0, 0, random.Next(8, 10), 2618, 9196, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "4_2 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map4_2();
            }



        }
        public void map4_3()
        {
            
            map4_3 map = new map4_3(data);
            
            



            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(540, 0, 0, random.Next(8, 10), 1456, 4850, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(540, 0, 0, random.Next(8, 10), 1456, 4850, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(542, 0, 0, random.Next(8, 10), 1456, 4850, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "4_3 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map4_3();
            }



        }
        public void map4_4()
        {
            
            map4_4 map = new map4_4(data);
            
            




            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(556, 0, 0, random.Next(8, 10), 2570, 6865, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(559, 0, 0, random.Next(8, 10), 3141, 9942, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(558, 0, 0, random.Next(8, 10), 3141, 9942, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "4_4 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map4_4();
            }



        }
        public void map4_5()
        {
            
            map4_5 map = new map4_5(data);
            
            




            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(578, 0, 0, random.Next(8, 10), 2048, 4719, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(580, 0, 0, random.Next(8, 10), 2048, 4719, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(581, 0, 0, random.Next(8, 10), 3895, 12347, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "4_5 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map4_5();
            }
        }
        public void map4_6()
        {
            
            
            
            Map_Controller.map4_6 map = new Map_Controller.map4_6(data);



            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(588, 0, 0, random.Next(8, 10), 1790, 4415, 90002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            //右移一步

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(594, 0, 0, random.Next(8, 10), 2336, 6732, 90002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            //右移一步

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(598, 0, 0, random.Next(8, 10), 2403, 5742, 90002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            //右移一步

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(604, 0, 0, random.Next(8, 10), 8876, 16656, 90002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "4_6 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map4_6();
            }
        }
        public void map5_1()
        {
            
            map5_1 map = new map5_1(data);
            
            



            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.reinforceTeam(map.Spots.dic[1]);

            userData.battle.endTurn(data);

            strbattledata = battleData.setData(691, 0, 0, random.Next(8, 10), 2178, 6756, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(692, 0, 0, random.Next(8, 10), 2670, 7905, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(693, 0, 0, random.Next(8, 10), 2670, 7905, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(693, 0, 0, random.Next(8, 10), 2670, 7905, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(691, 1, 0, random.Next(8, 10), 3820, 7551, 20002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 1, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(698, 0, 0, random.Next(8, 10), 2640, 7655, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(700, 0, 0, random.Next(8, 10), 2788, 7728, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(703, 0, 0, random.Next(8, 10), 2324, 6160, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);

            strbattledata = battleData.setData(691, 1, 0, random.Next(8, 10), 2324, 6160, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 1, ref result);
            }

            strbattledata = battleData.setData(703, 0, 0, random.Next(8, 10), 2285, 7030, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(699, 0, 0, random.Next(8, 10), 2606, 9394, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "5_1 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map5_1();
            }
        }
        public void map5_2()
        {
            
            map5_2 map = new map5_2(data);
            
            




            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.reinforceTeam(map.Spots.dic[1]);
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(713, 0, 0, random.Next(8, 10), 2415, 7360, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            strbattledata = battleData.setData(716, 1, 0, random.Next(8, 10), 2233, 6808, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(710, 0, 0, random.Next(8, 10), 3302, 8964, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "5_2 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map5_2();
            }
        }
        public void map5_3()
        {
            
            map5_3 map = new map5_3(data);
            
            




            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(727, 0, 0, random.Next(8, 10), 3549, 9176, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(735, 0, 0, random.Next(8, 10), 3878, 10198, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(737, 0, 0, random.Next(8, 10), 3060, 9020, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(738, 0, 0, random.Next(8, 10), 2863, 3507, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(740, 1, 0, random.Next(8, 10), 3225, 9741, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(745, 1, 0, random.Next(8, 10), 4081, 8578, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(738, 0, 0, random.Next(8, 10), 2019, 5937, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            strbattledata = battleData.setData(745, 1, 0, random.Next(8, 10), 3000, 7656, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(736, 0, 0, random.Next(8, 10), 3286, 10019, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(733, 0, 0, random.Next(8, 10), 2933, 8932, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(729, 0, 0, random.Next(8, 10), 2644, 8619, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "5_3 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map5_3();
            }
        }
        public void map5_4()
        {
            
            map5_4 map = new map5_4(data);
            
            




            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(764, 0, 0, random.Next(8, 10), 4264, 11426, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(763, 0, 0, random.Next(8, 10), 4080, 15116, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "5_4 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map5_4();
            }
        }
        public void map5_5()
        {
            
            map5_5 map = new map5_5(data);
            
            




            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(797, 1, 0, random.Next(8, 10), 3331, 7966, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(798, 0, 0, random.Next(8, 10), 3012, 9800, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(798, 0, 0, random.Next(8, 10), 3879, 11589, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(787, 0, 0, random.Next(8, 10), 2829, 8175, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(787, 0, 0, random.Next(8, 10), 2829, 8175, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(789, 0, 0, random.Next(8, 10), 3506, 9272, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(783, 0, 0, random.Next(8, 10), 4185, 11362, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(780, 0, 0, random.Next(8, 10), 3493, 8464, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(778, 0, 0, random.Next(8, 10), 3493, 8464, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(777, 0, 0, random.Next(8, 10), 2943, 6840, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "5_5 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map5_5();
            }
        }
        public void map5_6()
        {
            
            
            
            Map_Controller.map5_6 map = new Map_Controller.map5_6(data);

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }




            //右移一步

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(808, 0, 0, random.Next(8, 10), 3960, 11922, 90002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            //右移一步

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            //右移一步

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);



            //右移一步

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(826, 0, 0, random.Next(8, 10), 11633, 19416, 90002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "5_6 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map5_6();
            }
        }
        public void map6_1()
        {
            
            map6_1 map = new map6_1(data);
            
            



            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.reinforceTeam(map.Spots.dic[1]);
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(1512, 0, 0, random.Next(8, 10), 4308, 3620, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1513, 0, 0, random.Next(8, 10), 4308, 3620, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1521, 0, 0, random.Next(8, 10), 7260, 17408, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1515, 0, 0, random.Next(8, 10), 6736, 8752, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1523, 0, 0, random.Next(8, 10), 7344, 17516, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "6_1 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map6_1();
            }
        }
        public void map6_2()
        {
            
            map6_2 map = new map6_2(data);
            
            



            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1531, 0, 0, random.Next(8, 10), 5580, 4660, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);

            strbattledata = battleData.setData(1531, 0, 0, random.Next(8, 10), 6750, 14381, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1533, 0, 0, random.Next(8, 10), 6750, 14381, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1535, 0, 0, random.Next(8, 10), 6462, 14381, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1537, 0, 0, random.Next(8, 10), 7420, 9648, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "6_2 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map6_2();
            }
        }
        public void map6_3()
        {
            
            map6_3 map = new map6_3(data);
            
            



            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1538, 0, 0, random.Next(8, 10), 7300, 5180, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1539, 0, 0, random.Next(8, 10), 6930, 14628, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(1539, 0, 0, random.Next(8, 10), 6930, 14628, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1542, 0, 0, random.Next(8, 10), 7612, 18240, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "6_3 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map6_3();
            }
        }
        public void map6_4()
        {
            
            map6_4 map = new map6_4(data);
            
            



            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.reinforceTeam(map.Spots.dic[1]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1574, 0, 0, random.Next(8, 10), 8706, 14313, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1752, 0, 0, random.Next(8, 10), 7344, 22256, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1575, 0, 0, random.Next(8, 10), 9491, 14603, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(1578, 1, 0, random.Next(8, 10), 9491, 14603, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1576, 0, 0, random.Next(8, 10), 7648, 18352, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1569, 0, 0, random.Next(8, 10), 10716, 14316, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "6_4 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map6_4();
            }
        }
        public void map6_5()
        {
            
            map6_5 map = new map6_5(data);
            
            


            userData.battle.startMission(map, data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1600, 0, 0, random.Next(8, 10), 9480, 15616, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(1600, 0, 0, random.Next(8, 10), 9328, 15616, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.reinforceTeam(map.Spots.dic[1]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1591, 0, 0, random.Next(8, 10), 5865, 4880, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(1592, 1, 0, random.Next(8, 10), 9480, 15616, 10004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1583, 0, 0, random.Next(8, 10), 7496, 18780, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1581, 0, 0, random.Next(8, 10), 7496, 18780, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1579, 0, 0, random.Next(8, 10), 8669, 19756, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "6_5 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map6_5();
            }
        }
        public void map6_6()
        {
            
            
            

            Map_Controller.map6_6 map = new Map_Controller.map6_6(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1634, 0, 0, random.Next(8, 10), 5980, 15210, 10004, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1620, 0, 0, random.Next(8, 10), 7988, 19644, 10006, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(1621, 0, 0, random.Next(8, 10), 7988, 19644, 10006, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1632, 0, 0, random.Next(8, 10), 8578, 17114, 10005, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1633, 0, 0, random.Next(8, 10), 18986, 42505, 900033, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "6_6 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map6_6();
            }
        }
        public void map7_6()
        {
            
            

            
            Map_Controller.map7_6 map = new Map_Controller.map7_6(data);
            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(1947, 0, 0, random.Next(4, 6), 6756, 11380, 10004, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);



            strbattledata = battleData.setData(1949, 0, 0, random.Next(8, 10), 5475, 8890, 10001, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.endTurn(data);



            strbattledata = battleData.setData(1949, 0, 0, random.Next(8, 10), 5475, 8890, 10001, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);



            strbattledata = battleData.setData(1947, 0, 0, random.Next(8, 10), 6752, 5688, 10005, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.Spots.dic[1]);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.withdrawTeam(map.withdrawSpot);

            userData.battle.abortMission();




        }
        public void map7_6boss()
        {
            
            
            


            Map_Controller.map7_6boss map = new Map_Controller.map7_6boss(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1947, 0, 0, random.Next(8, 10), 6756, 11380, 10004, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.Spots.dic[1]);


            userData.battle.endTurn(data);

            strbattledata = battleData.setData(1947, 0, 0, random.Next(8, 10), 6752, 5688, 10005, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            strbattledata = battleData.setData(1948, 1, 0, random.Next(8, 10), 5475, 8890, 10001, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(1946, 0, 0, random.Next(8, 10), 10875, 16022, 10002, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(2152, 0, 0, random.Next(8, 10), 10415, 23979, 10006, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(1941, 0, 0, random.Next(8, 10), 12904, 17068, 10008, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.endTurn(data);

            strbattledata = battleData.setData(1941, 0, 0, random.Next(8, 10), 24604, 53992, 900039, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.endTurn(data);
            new Log().userInit(userData.GameAccount.GameAccountID, "7_6BOSS 成功", "").userInfo();
        }
        public void map8_6()
        {
            
            
            
            Map_Controller.map8_6 map = new Map_Controller.map8_6(data);



            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.reinforceTeam(map.Spots.dic[1]);


            strbattledata = userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if(Function.Normal_PosCheck_type2(strbattledata, 3789) == 1)
            {
                strbattledata = battleData.setData(3789, 0, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3683, 0, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3679, 0, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            strbattledata = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(strbattledata, 3679) == 1)
            {
                strbattledata = battleData.setData(3679, 0, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (Function.Normal_PosCheck_type2(strbattledata, 3788) == 1)
            {
                strbattledata = battleData.setData(3788, 1, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(strbattledata, 3681) == 1)
            {
                strbattledata = battleData.setData(3681, 0, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(strbattledata, 3682) == 1)
            {
                strbattledata = battleData.setData(3682, 0, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3667, 0, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3673, 0, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            strbattledata = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(strbattledata, 3788) == 1)
            {
                strbattledata = battleData.setData(3788, 1, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3664, 0, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3670, 0, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3669, 0, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = userData.battle.endTurn(data);
            if (Function.Normal_PosCheck_type2(strbattledata, 3788) == 1)
            {
                strbattledata = battleData.setData(3788, 1, 0, random.Next(8, 10), 14216, 11880, 10005, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3668, 0, 0, random.Next(8, 10), 27549, 38000, 900071, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }











            if (result.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "8_6BOSS 成功", "").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map8_6();
            }
        }

        public void map9_6()
        {
            
            
            
            Map_Controller.map9_6 map = new Map_Controller.map9_6(data);



            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(4783, 0, 0, random.Next(8, 10), 18794, 28129, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(4790, 0, 0, random.Next(8, 10), 25263, 65786, 900081, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            if (userData.battle.withdrawTeam(map.withdrawTeam))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "9_6BOSS 成功", "").userInfo();
                userData.battle.abortMission();
            }
            else
            {
                userData.battle.abortMission();
                this.map8_6();
            }
        }



        public void map10_6()
        {
            
            
            
            map10_6 map = new map10_6(data);

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(5360, 0, 0, random.Next(8, 10), 22672, 21562, 10017, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.Spots.dic[1]);

            userData.battle.allyMySideMove();
            string endTurn = userData.battle.endTurn(data);
            int home = Function.Normal_PosCheck_type2(endTurn, 5363);
            int pos1 = Function.Normal_PosCheck_type2(endTurn, 5360);
            int pos2 = Function.Normal_PosCheck_type2(endTurn, 5357);
            int pos3 = Function.Normal_PosCheck_type2(endTurn, 5346);
            if (home == 1)
            {

                strbattledata = battleData.setData(5363, 1, 0, random.Next(8, 10), 14216, 16880, 10005, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            if (pos1 == 1)
            {

                strbattledata = battleData.setData(5360, 0, 0, random.Next(8, 10), 22672, 21562, 10017, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();
            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (pos2 == 1)
            {

                strbattledata = battleData.setData(5357, 0, 0, random.Next(8, 10), 22672, 21562, 10017, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (pos3 == 1)
            {

                strbattledata = battleData.setData(5346, 0, 0, random.Next(100, 160), 37053, 107083, 900087, userData.user_Info.experience);

                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            if (result.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "10_6BOSS 成功", "").userInfo();
            }
            userData.battle.abortMission();
        }

        public void map11_6()
        {
            
            
            
            map11_6 map = new map11_6(data);

            if (userData.battle.startMission(map,data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(9193, 0, 0, random.Next(8, 10), 30487, 84520, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(9191, 0, 0, random.Next(8, 10), 25326, 75564, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(9192, 0, 0, random.Next(8, 10), 19698, 58772, 10034, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(9170, 0, 0, random.Next(8, 10), 30708, 63010, 10036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(9171, 0, 0, random.Next(8, 10), 30708, 63010, 10036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endResult = userData.battle.endTurn(data);

            if (Function.Normal_PosCheck_type2(endResult, 9171) == 1)
            {
                strbattledata = battleData.setData(9171, 0, 0, random.Next(8, 10), 27566, 68288, 10035, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            if(Function.Normal_PosCheck_type2(endResult, 9172) == 1)
            {
                strbattledata = battleData.setData(9172, 0, 0, random.Next(8, 10), 27566, 68288, 10035, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(9174, 0, 0, random.Next(8, 10), 33194, 85080, 10035, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            endResult = userData.battle.endTurn(data);


            if (!endResult.Contains("rank"))
            {
                userData.battle.abortMission();
            }
        }


        public void map10_4e()
        {

            
            
            
            map10_4e map = new map10_4e(data);






            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            //右移一步

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(5495, 0, 0, random.Next(10, 12), 26702, 43140, 10027, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            //右移一步

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            //战斗结算 经验，装备，指挥官经验

            strbattledata = battleData.setData(5492, 0, 0, random.Next(10, 12), 39015, 63520, 10027, userData.user_Info.experience);


            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(5497, 0, 0, random.Next(10, 12), 26702, 43140, 10027, userData.user_Info.experience);


            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.allyMySideMove();
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startOtherSideTurn();

            strbattledata = battleData.setData(5497, 0, 0, random.Next(10, 12), 39015, 63520, 10027, userData.user_Info.experience);


            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endOtherSideTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            //撤离

            userData.battle.withdrawTeam(map.withdrawSpot);

            //战役结束

            userData.battle.abortMission();
        }
        public void map5_2n()
        {
            
            
            
            map5_2n map = new map5_2n(data);

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(3037, 0, 0, random.Next(8, 10), 13376, 19401, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(3038, 0, 0, random.Next(8, 10), 11830, 2430, 10018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(3047, 0, 0, random.Next(8, 10), 14196, 2916, 10018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(3052, 0, 0, random.Next(8, 10), 11370, 17811, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }



            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(3056, 0, 0, random.Next(8, 10), 13376, 19401, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.withdrawTeam(map.withdrawSpot);
            userData.battle.abortMission();









        }
        public void map1_4n()
        {
            
            
            string strbattledata,endTurnResult;
            map1_4n map = new map1_4n(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.reinforceTeam(map.Spots.dic[1], true);

            userData.battle.endTurn(data);//门口两点
            strbattledata = battleData.setData(1317, 0, 0, random.Next(8, 10), 2241, 3606, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(1408, 0, 0, random.Next(8, 10), 2241, 3606, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            endTurnResult = userData.battle.endTurn(data);//站在雷达上
            strbattledata = battleData.setData(1408, 0, 0, random.Next(8, 10), 2988, 4808, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(1409, 0, 0, random.Next(8, 10), 2241, 3606, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(1411, 0, 0, random.Next(8, 10), 2241, 3606, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(1410, 0, 0, random.Next(8, 10), 2241, 3606, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.abortMission();





















        }
        public void map2_4n()
        {
            
            
            
            map2_4n map = new map2_4n(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(1453, 0, 0, random.Next(8, 10), 7012, 5568, 10005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTurn1 = userData.battle.endTurn(data);//能否靠这个猜测第二个光头 如果记得被占则终止作战
            if (map.PosCheck1(endTurn1) == 1)
            {

                strbattledata = battleData.setData(1453, 0, 0, random.Next(8, 10), 6707, 10016, 10016, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }


            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(1461, 0, 0, random.Next(8, 10), 5988, 7624, 10008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.abortMission();

        }

        public void map3_4n()
        {
            
            
            
            map3_4n map = new map3_4n(data);







            //是否需要单独补给



            //部署梯队
            //回合开始

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }





            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(1347, 0, 0, random.Next(8, 10), 6020, 10112, 20008, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }






            string endTurn1 = userData.battle.endTurn(data);//能否靠这个猜测第二个光头 如果记得被占则终止作战
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            var regex = new Regex("1485");
            var matches = regex.Matches(endTurn1);
            if (matches.Count == 2)
            {
                userData.battle.abortMission();
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            strbattledata = battleData.setData(1503, 0, 0, random.Next(8, 10), 6044, 5056, 20008, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }




            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            //第二个光头在还不在?


            strbattledata = battleData.setData(1504, 0, 0, random.Next(8, 10), 7775, 6505, 20008, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            //else
            //{
            //    userData.battle.abortMission();
            //    return;
            //}


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            string endTurn2 = userData.battle.endTurn(data);//分支开始推测强无敌位置  站在机场 回合结束
            int Bosscase = map.BossPos(endTurn2);
            int rCase = map.rPos(endTurn2);

            switch (rCase)
            {
                case 1:
                    {

                        strbattledata = battleData.setData(1505, 0, 0, random.Next(8, 10), 7775, 6505, 20008, userData.user_Info.experience);

                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }
                        break;
                    }
                default:
                    break;
            }


            switch (Bosscase)
            {
                case 0:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn(data);
                        //机场上方

                        userData.battle.teamMove(map.teamMove.dic[4]);


                        strbattledata = battleData.setData(1489, 0, 0, random.Next(8, 10), 9685, 21662, 20008, userData.user_Info.experience);

                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }



                        break;
                    }
                case 1:
                    {

                        strbattledata = battleData.setData(1505, 0, 0, random.Next(8, 10), 9685, 21662, 20008, userData.user_Info.experience);

                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }

                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn(data);
                        break;

                    }
                case 2:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn(data);

                        userData.battle.teamMove(map.teamMove.dic[7]);


                        userData.battle.teamMove(map.teamMove.dic[8]);


                        strbattledata = battleData.setData(1506, 0, 0, random.Next(8, 10), 9685, 21662, 20008, userData.user_Info.experience);

                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }


                        break;

                    }

                case 3:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn(data);

                        userData.battle.teamMove(map.teamMove.dic[7]);


                        userData.battle.teamMove(map.teamMove.dic[9]);


                        strbattledata = battleData.setData(1507, 0, 0, random.Next(8, 10), 9685, 21662, 20008, userData.user_Info.experience);

                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }



                        break;

                    }

                case 4:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn(data);

                        userData.battle.teamMove(map.teamMove.dic[7]);


                        strbattledata = battleData.setData(1509, 0, 0, random.Next(8, 10), 9685, 21662, 20008, userData.user_Info.experience);

                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }
                        break;

                    }

                case 5:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn(data);

                        userData.battle.teamMove(map.teamMove.dic[4]);


                        userData.battle.teamMove(map.teamMove.dic[10]);


                        strbattledata = battleData.setData(1506, 0, 0, random.Next(8, 10), 9685, 21662, 20008, userData.user_Info.experience);

                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }
                        break;
                    }

                case 6:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn(data);

                        userData.battle.teamMove(map.teamMove.dic[4]);


                        userData.battle.teamMove(map.teamMove.dic[11]);



                        strbattledata = battleData.setData(1490, 0, 0, random.Next(8, 10), 9685, 21662, 20008, userData.user_Info.experience);

                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }



                        break;
                    }

                case 7:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn(data);

                        userData.battle.teamMove(map.teamMove.dic[4]);


                        userData.battle.teamMove(map.teamMove.dic[12]);


                        strbattledata = battleData.setData(1501, 0, 0, random.Next(8, 10), 9685, 21662, 20008, userData.user_Info.experience);

                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }
                        break;
                    }

                case 8:
                    {
                        userData.battle.endEnemyTurn();
                        userData.battle.startTurn(data);

                        userData.battle.teamMove(map.teamMove.dic[4]);


                        userData.battle.teamMove(map.teamMove.dic[13]);


                        strbattledata = battleData.setData(1476, 0, 0, random.Next(8, 10), 9685, 21662, 20008, userData.user_Info.experience);

                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }



                        break;
                    }

                default:
                    break;
            }








            userData.battle.abortMission();

        }
        public void map4_4n()
        {
            
            
            string strbattledata, endTurnResult;
            map4_4n map = new map4_4n(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(1819, 0, 0, random.Next(8, 10), 17708, 30868, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(1825, 0, 0, random.Next(8, 10), 13520, 44880, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(1829, 0, 0, random.Next(8, 10), 13520, 36668, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(1835, 0, 0, random.Next(8, 10), 10420, 25400, 900036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.abortMission();
        }
        public void map5_4n()
        {
            
            
            string strbattledata, endTurnResult;
            map5_4n map = new map5_4n(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3090, 0, 0, random.Next(8, 10), 19558, 20477, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3102, 0, 0, random.Next(8, 10), 21272, 38024, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3108, 0, 0, random.Next(8, 10), 20813, 45800, 900036, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.abortMission();
        }
        public void map6_4n()
        {
            
            
            
            map6_4n map = new map6_4n(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);



            strbattledata = battleData.setData(4078, 0, 0, random.Next(8, 10), 15024, 27914, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);



            strbattledata = battleData.setData(4082, 0, 0, random.Next(8, 10), 9934, 20116, 10009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTurn1 = userData.battle.endTurn(data);//能否靠这个猜测第二个光头 如果记得被占则终止作战


            if (Function.Night_PosCheck_type1(endTurn1, 4082) == 1)
            {

                strbattledata = battleData.setData(4082, 0, 0, random.Next(10, 18), 16354, 52503, 10012, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(4068, 0, 0, random.Next(10, 18), 28741, 61209, 900060, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.withdrawTeam(map.withdrawSpot);
            userData.battle.abortMission();







        }
        public void map7_4n()
        {
            
            
            
            map7_4n map = new map7_4n(data);


            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(6668, 0, 0, random.Next(8, 10), 20796, 30184, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(6669, 0, 0, random.Next(8, 10), 24232, 37552, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(6658, 0, 0, random.Next(8, 10), 24232, 37552, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            strbattledata = battleData.setData(6658, 0, 0, random.Next(8, 10), 30536, 6798, 10018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(6657, 0, 0, random.Next(8, 10), 24232, 37552, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(6660, 0, 0, random.Next(8, 10), 26770, 39575, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(6663, 0, 0, random.Next(8, 10), 30381, 56000, 900102, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            if (result.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "7_4n 成功", "").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map8_6();
            }
        }
        public void map8_1n()
        {
            
            
            
            map8_1n map = new map8_1n(data);

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7076, 0, 0, random.Next(8, 10), 22542, 5018, 10018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(7068, 0, 0, random.Next(8, 10), 22542, 5018, 10018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(7067, 0, 0, random.Next(8, 10), 7410, 11135, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(7075, 0, 0, random.Next(8, 10), 22542, 5018, 10018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7074, 0, 0, random.Next(8, 10), 7410, 11135, 10003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.withdrawTeam(map.withdrawSpot);
            userData.battle.abortMission();
        }
        public void map8_4n()
        {
            
            
            
            map8_4n map = new map8_4n(data);

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7034, 0, 0, random.Next(8, 10), 30516, 24612, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7039, 0, 0, random.Next(8, 10), 99260, 366832, 10022, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7065, 0, 0, random.Next(8, 10), 27252, 35988, 10002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7056, 0, 0, random.Next(8, 10), 28443, 34237, 10017, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(7055, 0, 0, random.Next(8, 10), 46710, 83040, 900106, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            if (result.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "8_4n 成功", "").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map8_6();
            }
        

















    }
        public void map0_1()
        {
            
            
            
            map0_1 map = new map0_1(data);

            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(3, 0, 0, random.Next(8, 10), 6062, 16773, 20006, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(6, 0, 0, random.Next(8, 10), 3120, 5376, 20006, userData.user_Info.experience);

            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
        }
        public void map1_1e()
        {
            
             
            map1_1e map = new map1_1e(data);
            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(153, 0, 0, random.Next(8, 10), 260, 550, 20001, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(158, 0, 0, random.Next(8, 10), 520, 1160, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);





            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "1-1e成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map1_1e();
            }
        }
        public void map1_2e()
        {
            
             
            map1_2e map = new map1_2e(data);
            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(166, 0, 0, random.Next(8, 10), 300, 666, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(168, 0, 0, random.Next(8, 10), 535, 142, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "1_2E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map1_2e();
            }
        }
        public void map1_3e()
        {
            
             

            map1_3e map = new map1_3e(data);
            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(176, 0, 0, random.Next(8, 10), 545, 1240, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(180, 0, 0, random.Next(8, 10), 366, 930, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);



            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "1_3E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map1_3e();
            }
        }
        public void map1_4e()
        {
            
             
            map1_4e map = new map1_4e(data);

            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(187, 0, 0, random.Next(8, 10), 425, 1158, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(188, 0, 0, random.Next(8, 10), 735, 2040, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);


            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(196, 0, 0, random.Next(8, 10), 611, 1531, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(200, 0, 0, random.Next(8, 10), 611, 1531, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(201, 0, 0, random.Next(8, 10), 611, 1531, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(198, 0, 0, random.Next(8, 10), 611, 1531, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(199, 0, 0, random.Next(8, 10), 611, 1531, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "1_4E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map1_4e();
            }
        }
        public void map2_1e()
        {
            
             
            map2_1e map = new map2_1e(data);

            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(286, 0, 0, random.Next(8, 10), 1296, 3368, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(285, 0, 0, random.Next(8, 10), 1074, 2478, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(281, 0, 0, random.Next(8, 10), 775, 2100, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "2_1E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map2_1e();
            }
        }
        public void map2_2e()
        {
            
             
            map2_2e map = new map2_2e(data);

            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(292, 0, 0, random.Next(8, 10), 1845, 3475, 20002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(295, 0, 0, random.Next(8, 10), 975, 2860, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(295, 0, 0, random.Next(8, 10), 975, 2860, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(297, 0, 0, random.Next(8, 10), 876, 2552, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(298, 0, 0, random.Next(8, 10), 1053, 2962, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(300, 0, 0, random.Next(8, 10), 1019, 2486, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "2_2E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map2_2e();
            }
        }
        public void map2_3e()
        {
            
             
            map2_3e map = new map2_3e(data);

            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(304, 0, 0, random.Next(8, 10), 1021, 2324, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.reinforceTeam(map.Spots.dic[1]);
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(302, 1, 0, random.Next(8, 10), 1460, 1030, 20003, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            strbattledata = battleData.setData(304, 0, 0, random.Next(8, 10), 882, 2044, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "2_3E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map2_3e();
            }
        }
        public void map2_4e()
        {
            
             
            map2_4e map = new map2_4e(data);

            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(320, 0, 0, random.Next(8, 10), 1353, 3195, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(320, 0, 0, random.Next(8, 10), 1840, 4544, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(324, 0, 0, random.Next(8, 10), 3887, 8029, 90005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);


            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "2_4E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map2_4e();
            }
        }
        public void map3_1e()
        {
            
             
            map3_1e map = new map3_1e(data);


            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(446, 0, 0, random.Next(8, 10), 2480, 5637, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.Spots.dic[1]);
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(446, 0, 0, random.Next(8, 10), 1534, 4461, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            strbattledata = battleData.setData(449, 1, 0, random.Next(8, 10), 1534, 4461, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(442, 0, 0, random.Next(8, 10), 1534, 4461, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(438, 0, 0, random.Next(8, 10), 2204, 6680, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "3_1E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map3_1e();
            }
        }
        public void map3_2e()
        {
            
             
            map3_2e map = new map3_2e(data);



            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(455, 0, 0, random.Next(8, 10), 1910, 3190, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(459, 0, 0, random.Next(8, 10), 1910, 3190, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(459, 0, 0, random.Next(8, 10), 1795, 5105, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(462, 0, 0, random.Next(8, 10), 2703, 7920, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "3_2E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map3_2e();
            }
        }
        public void map3_3e()
        {
            
             
            map3_3e map = new map3_3e(data);



            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(478, 0, 0, random.Next(8, 10), 2564, 7504, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(481, 0, 0, random.Next(8, 10), 2564, 7504, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(480, 0, 0, random.Next(8, 10), 2248, 5734, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "3_3E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map3_3e();
            }
        }
        public void map3_4e()
        {
            
             
            map3_4e map = new map3_4e(data);

            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(490, 0, 0, random.Next(8, 10), 2203, 6152, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(492, 0, 0, random.Next(8, 10), 6710, 11422, 90007, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "3_4E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map3_4e();
            }
        }
        public void map4_1e()
        {
            
             
            map4_1e map = new map4_1e(data);

            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(613, 0, 0, random.Next(8, 10), 3015, 9465, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(620, 0, 0, random.Next(8, 10), 3030, 9000, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(621, 0, 0, random.Next(8, 10), 3276, 10378, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);

            strbattledata = battleData.setData(621, 0, 0, random.Next(8, 10), 1790, 4415, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            strbattledata = battleData.setData(609, 1, 0, random.Next(8, 10), 1790, 4415, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(625, 0, 0, random.Next(8, 10), 3414, 9814, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "4_1E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map4_1e();
            }
        }
        public void map4_2e()
        {
            
             
            map4_2e map = new map4_2e(data);

            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(637, 0, 0, random.Next(8, 10), 2570, 6865, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(640, 0, 0, random.Next(8, 10), 2570, 6865, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(639, 0, 0, random.Next(8, 10), 2915, 7918, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "4_2E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map4_2e();
            }
        }
        public void map4_3e()
        {
            
             
            map4_3e map = new map4_3e(data);

            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(659, 0, 0, random.Next(8, 10), 1597, 3567, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(660, 0, 0, random.Next(8, 10), 1597, 3567, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(661, 0, 0, random.Next(8, 10), 1597, 3567, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(662, 0, 0, random.Next(8, 10), 2568, 7209, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }


            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "4_3E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map4_3e();
            }
        }
        public void map4_4e()
        {
            
             
            map4_4e map = new map4_4e(data);

            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(670, 0, 0, random.Next(8, 10), 2790, 8050, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(676, 0, 0, random.Next(8, 10), 2303, 3881, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(680, 0, 0, random.Next(8, 10), 2303, 3881, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(686, 0, 0, random.Next(8, 10), 10289, 19176, 900012, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "4_4E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map4_4e();
            }
        }
        public void map5_1e()
        {
            
             
            map5_1e map = new map5_1e(data);



            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(837, 0, 0, random.Next(8, 10), 3579, 10815, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(843, 0, 0, random.Next(8, 10), 3933, 16781, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(844, 0, 0, random.Next(8, 10), 3810, 12753, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(846, 1, 0, random.Next(8, 10), 4896, 7064, 20002, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(851, 1, 0, random.Next(8, 10), 3972, 11960, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(844, 0, 0, random.Next(8, 10), 4100, 10304, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            strbattledata = battleData.setData(851, 1, 0, random.Next(8, 10), 4100, 10304, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(842, 0, 0, random.Next(8, 10), 4100, 10304, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(839, 0, 0, random.Next(8, 10), 4117, 10615, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(838, 0, 0, random.Next(8, 10), 4181, 16918, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "5_1E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map5_1e();
            }
        }
        public void map5_2e()
        {
            
             
            map5_2e map = new map5_2e(data);



            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(861, 0, 0, random.Next(8, 10), 4108, 10008, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(870, 0, 0, random.Next(8, 10), 2748, 8048, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(869, 0, 0, random.Next(8, 10), 5856, 13296, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "5_2E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map5_2e();
            }
        }
        public void map5_3e()
        {
            
             
            map5_3e map = new map5_3e(data);



            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(903, 1, 0, random.Next(8, 10), 4575, 13360, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(904, 0, 0, random.Next(8, 10), 4383, 11160, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.Spots.dic[2]);
            userData.battle.endTurn(data);

            strbattledata = battleData.setData(907, 2, 0, random.Next(8, 10), 4575, 13360, 20004, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(895, 0, 0, random.Next(8, 10), 5552, 15972, 20008, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(886, 0, 0, random.Next(8, 10), 3393, 11356, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(884, 0, 0, random.Next(8, 10), 4560, 10456, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(883, 0, 0, random.Next(8, 10), 4867, 16918, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "5_3E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map5_3e();
            }
        }
        public void map5_4e()
        {
            

            map5_4e map = new map5_4e(data);

            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(914, 0, 0, random.Next(8, 10), 4090, 12760, 20005, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(919, 0, 0, random.Next(8, 10), 4132, 10100, 20006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(926, 0, 0, random.Next(8, 10), 3997, 13015, 20009, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            strbattledata = battleData.setData(932, 0, 0, random.Next(8, 10), 15124, 23990, 900018, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            string endTrun = userData.battle.endTurn(data);
            if (endTrun.Contains("rank"))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "5_4E 成功").userInfo();
            }
            else
            {
                userData.battle.abortMission();
                this.map5_4e();
            }
        }

        public void map1_1n()
        {
            map1_1n map = new map1_1n(data);
            if (userData.battle.startMission(map, data) == -1) { data.Loop = false; return; }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(1348, 0, 0, random.Next(8, 10), 1416, 2976, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.reinforceTeam(map.Spots.dic[1], true);

            string endTurnResult =  userData.battle.endTurn(data);
            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            int type =  Function.Night_PosCheck_type1(endTurnResult, 1349);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(1310, 1, 0, random.Next(8, 10), 1190, 1100, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }

            //1 走中间 2 走上边
            switch (type)
            {
                case 1:
                    {
                        userData.battle.teamMove(map.teamMove.dic[4]);
                        strbattledata = battleData.setData(1349, 0, 0, random.Next(8, 10), 1190, 1100, 10016, userData.user_Info.experience);
                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }
                        userData.battle.teamMove(map.teamMove.dic[5]);
                        strbattledata = battleData.setData(1352, 0, 0, random.Next(8, 10), 1785, 1650, 10016, userData.user_Info.experience);
                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }





                        break;
                    }

                case 2:
                    {
                        userData.battle.teamMove(map.teamMove.dic[2]);
                        strbattledata = battleData.setData(1351, 0, 0, random.Next(8, 10), 1190, 1100, 10016, userData.user_Info.experience);
                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }
                        userData.battle.teamMove(map.teamMove.dic[3]);
                        strbattledata = battleData.setData(1352, 0, 0, random.Next(8, 10), 1785, 1650, 10016, userData.user_Info.experience);
                        if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                        {
                            userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                        }
                        break;
                    }



                default:
                    break;
            }

            userData.battle.endTurn(data);
            strbattledata = battleData.setData(1310, 1, 0, random.Next(8, 10), 1785, 1650, 10016, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            if (!result.Contains("90002"))
            {
                userData.battle.abortMission();
                map1_1n();
            }




        }

        public void map8_2emod2()
        {

            
            
            map8_2emod2 map = new map8_2emod2(data);
            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            strbattledata = battleData.setData(3859, 0, 0, random.Next(8, 10), 15231, 40278, 10006, userData.user_Info.experience);
            if (userData.battle.Normal_battleFinish(strbattledata, ref result))
            {
                userData.battle.Battle_Result_PRO(ref data, 0, ref result);
            }
            userData.battle.teamMove_Random(map.teamMove.dic[map.stepNum++],data);
            userData.battle.abortMission();

        }




        public void map8_3emod2()
        {
            map8_3emod2 map = new map8_3emod2(data);
            if (userData.battle.startMission(map, data) == -1)
            {
                data.Loop = false;
                //这里该怎么办呢
                return;
            }

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);

            userData.battle.reinforceTeam(map.Spots.dic[1]);

            string endResult = userData.battle.endTurn(data);

            if(Function.Normal_PosCheck_type2(endResult, 3892) == 1)
            {
                strbattledata = battleData.setData(3892, 1, 0, random.Next(8, 10), 11650, 9675, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.endEnemyTurn();
            userData.battle.startTurn(data);

            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(endResult, 3897) == 1)
            {
                strbattledata = battleData.setData(3897, 0, 0, random.Next(8, 10), 11650, 9675, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            //3894
            userData.battle.teamMove(map.teamMove.dic[map.stepNum++]);
            if (Function.Normal_PosCheck_type2(endResult, 3897) != 1 && Function.Normal_PosCheck_type2(endResult, 3893) != 1)
            {
                strbattledata = battleData.setData(3894, 0, 0, random.Next(8, 10), 11650, 9675, 10005, userData.user_Info.experience);
                if (userData.battle.Normal_battleFinish(strbattledata, ref result))
                {
                    userData.battle.Battle_Result_PRO(ref data, 0, ref result);
                }
            }

            userData.battle.teamMove_Random(map.teamMove.dic[map.stepNum++],data);

            userData.battle.abortMission();

            
        }
        
    }




}

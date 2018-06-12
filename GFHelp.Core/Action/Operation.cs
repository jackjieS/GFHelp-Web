using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.Action
{
    class Operation
    {
        public static void Start_Loop_Operation_Act(UserData userData, Operation_Act_Info operation_act_info)
        {
            ////检测后勤条件
            //int team_leader_min_level, gun_min;
            //team_leader_min_level = CatachData.operation_info[operation_act_info.operation_id - 1].team_leader_min_level;
            //gun_min = CatachData.operation_info[operation_act_info.operation_id - 1].gun_min;

            //bool Out = false;


            //if (team_leader_min_level > UserDataSummery.team_info[operation_act_info.team_id][1].gun_level)
            //{
            //    Out = true;
            //    im.mainWindow.Dispatcher.Invoke(() =>
            //    {
            //        MessageBox.Show("梯队队长等级不符合后勤任务要求");
            //    });
            //};

            //if (gun_min > UserDataSummery.team_info[operation_act_info.team_id].Count)
            //{
            //    Out = true;
            //    im.mainWindow.Dispatcher.Invoke(() =>
            //    {
            //        MessageBox.Show("梯队人形总数不符合后勤任务要求");
            //    });
            //}
            //if (Out == true) return;
            //im.Dic_auto_operation_act[0]
            userData.webData.StatusBarText = String.Format(" 第 {0} 梯队后勤任务结束 ", operation_act_info.team_id);
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = new JsonWriter(sb);
            writer.WriteObjectStart();
            writer.WritePropertyName("operation_id");
            writer.Write(operation_act_info.operation_id);
            writer.WriteObjectEnd();
            int count = 0;
            //发送请求
            while (true)
            {
                string result = API.Operation.FinishOperation(userData.GameAccount, sb.ToString());
                int k = Helper.Response.Check(userData.GameAccount, ref result, "Finish_Operation_Pro", true);
                switch (k)
                {
                    case 1:
                        {
                            break;
                        }
                    case 0:
                        {
                            break;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount)
                            {
                                WarningNote note = new WarningNote(-1, result.ToString());
                                userData.warningNotes.Add(note);
                                return;
                            }
                            break;
                        }
                    default:
                        break;
                }
                if (k == 1) break;
            }

            sb = new StringBuilder();
            writer = new JsonWriter(sb);
            writer.WriteObjectStart();
            writer.WritePropertyName("team_id");
            writer.Write(operation_act_info.team_id);
            writer.WritePropertyName("operation_id");
            writer.Write(operation_act_info.operation_id);
            writer.WriteObjectEnd();
            userData.webData.StatusBarText = String.Format(" 第 {0} 梯队后勤任务开始 ", operation_act_info.team_id);
            while (true)
            {
                string result = API.Operation.StartOperation(userData.GameAccount, sb.ToString());
                int k = Helper.Response.Check(userData.GameAccount, ref result, "GUN_OUTandIN_Team_PRO", false);
                switch (k)
                {
                    case 1:
                        {
                            break;
                        }
                    case 0:
                        {
                            break;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount)
                            {
                                WarningNote note = new WarningNote(-1, result.ToString());
                                userData.warningNotes.Add(note);
                                return;
                            }

                            break;
                        }
                    default:
                        break;
                }

                if (k == 1)
                {
                    userData.operation_Act_Info.dicOperation[operation_act_info.key].start_time = Helper.Decrypt.ConvertDateTime_China_Int(DateTime.Now);
                    break;

                }

            }



        }


        public static void Start_Operation_Act(UserData userData, Operation_Act_Info operation_act_info)
        {
            ////检测后勤条件
            //int team_leader_min_level, gun_min;
            //team_leader_min_level = im.catchdatasummery.operation_info[operation_act_info.operation_id - 1].team_leader_min_level;
            //gun_min = im.catchdatasummery.operation_info[operation_act_info.operation_id - 1].gun_min;

            //bool Out = false;


            //if (team_leader_min_level > UserDataSummery.team_info[operation_act_info.team_id][1].gun_level)
            //{
            //    Out = true;
            //    im.mainWindow.Dispatcher.Invoke(() =>
            //    {
            //        MessageBox.Show("梯队队长等级不符合后勤任务要求");
            //    });
            //};

            //if (gun_min > UserDataSummery.team_info[operation_act_info.team_id].Count)
            //{
            //    Out = true;
            //    im.mainWindow.Dispatcher.Invoke(() =>
            //    {
            //        MessageBox.Show("梯队人形总数不符合后勤任务要求");
            //    });
            //}



            //if (Out == true) return;
            //im.Dic_auto_operation_act[0]
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = new JsonWriter(sb);
            writer.WriteObjectStart();
            writer.WritePropertyName("team_id");
            writer.Write(operation_act_info.team_id);
            writer.WritePropertyName("operation_id");
            writer.Write(operation_act_info.operation_id);
            writer.WriteObjectEnd();
            userData.webData.StatusBarText = String.Format(" 第 {0} 梯队后勤任务开始 ", operation_act_info.team_id);
            int count = 0;
            while (true)
            {
                string result = API.Operation.StartOperation(userData.GameAccount, sb.ToString());
                int k = Helper.Response.Check(userData.GameAccount, ref result, "GUN_OUTandIN_Team_PRO", false);
                switch (k)
                {
                    case 1:
                        {
                            return;
                        }
                    case 0:
                        {
                            break;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount)
                            {
                                WarningNote note = new WarningNote(-1, result.ToString());
                                userData.warningNotes.Add(note);
                                return;
                            }

                            break;
                        }
                    default:
                        break;
                }
            }
        }

        public static void Abort_Operation_Act(UserData userData, Operation_Act_Info operation_act_info)
        {
            userData.webData.StatusBarText = String.Format(" 第 {0} 梯队后勤任务终止 ", operation_act_info.team_id);
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = new JsonWriter(sb);
            writer.WriteObjectStart();
            writer.WritePropertyName("operation_id");
            writer.Write(operation_act_info.operation_id);
            writer.WriteObjectEnd();

            int count = 0;
            while (true)
            {
                string result =  API.Operation.AbortOperation(userData.GameAccount, sb.ToString());
                switch (Helper.Response.Check(userData.GameAccount, ref result, "AbortOperation", true))
                {
                    case 1:
                        {
                            return;
                        }
                    case 0:
                        {
                            break;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                WarningNote note = new WarningNote(-1, "AbortOperation ERROR");
                                userData.warningNotes.Add(note);
                                return;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
        }






    }








}

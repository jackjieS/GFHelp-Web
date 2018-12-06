using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using GFHelp.Core.MulitePlayerData;
using LitJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.Action
{
    public class Operation
    {
        /// <summary>
        /// 不再使用
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="data"></param>
        public static void Start_Loop_Operation_Act(UserData userData, Operation_Act_Info.Data data)
        {

            userData.webData.StatusBarText = String.Format(" 第 {0} 梯队后勤任务结束 ", data.team_id);
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = new JsonWriter(sb);
            writer.WriteObjectStart();
            writer.WritePropertyName("operation_id");
            writer.Write(data.operation_id);
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
                            userData.operation_Act_Info.Finish(data);
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
                                new Log().userInit(userData.GameAccount.GameAccountID, "后勤结束", result.ToString()).userInfo();
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
            writer.Write(data.team_id);
            writer.WritePropertyName("operation_id");
            writer.Write(data.operation_id);
            writer.WriteObjectEnd();
            userData.webData.StatusBarText = String.Format(" 第 {0} 梯队后勤任务开始 ", data.team_id);
            while (true)
            {
                string result = API.Operation.StartOperation(userData.GameAccount, sb.ToString());
                int k = Helper.Response.Check(userData.GameAccount, ref result, "GUN_OUTandIN_Team_PRO", false);
                switch (k)
                {
                    case 1:
                        {
                            userData.operation_Act_Info.Start(data);
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
                                new Log().userInit(userData.GameAccount.GameAccountID, "后勤任务开始 ERROR", result.ToString()).userInfo();
                                return;
                            }

                            break;
                        }
                    default:
                        break;
                }

                if (k == 1)
                {
                    data.start_time = Helper.Decrypt.ConvertDateTime_China_Int(DateTime.Now);
                    break;

                }

            }



        }


        public static int Finish_Operation_Act(UserData userData, Operation_Act_Info.Data data)
        {
            userData.webData.StatusBarText = String.Format(" 第 {0} 梯队后勤任务结束 ", data.team_id);
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = new JsonWriter(sb);
            writer.WriteObjectStart();
            writer.WritePropertyName("operation_id");
            writer.Write(data.operation_id);
            writer.WriteObjectEnd();
            int count = 0;
            //发送请求
            while (true)
            {
                string result = API.Operation.FinishOperation(userData.GameAccount, sb.ToString());
                switch (Response.Check(userData.GameAccount, ref result, "Finish_Operation_Pro", true))
                {
                    case 1:
                        {
                            return 1;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "后勤结束失败", result.ToString()).userInfo();
                                return -1;
                            }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }

        public static int Start_Operation_Act(UserData userData, Operation_Act_Info.Data data)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = new JsonWriter(sb);
            writer.WriteObjectStart();
            writer.WritePropertyName("team_id");
            writer.Write(data.team_id);
            writer.WritePropertyName("operation_id");
            writer.Write(data.operation_id);
            writer.WriteObjectEnd();
            userData.webData.StatusBarText = String.Format(" 第 {0} 梯队后勤任务开始 ", data.team_id);
            int count = 0;
            while (true)
            {
                string result = API.Operation.StartOperation(userData.GameAccount, sb.ToString());
                int k = Helper.Response.Check(userData.GameAccount, ref result, "GUN_OUTandIN_Team_PRO", false);
                switch (k)
                {
                    case 1:
                        {
                            return 1;
                        }
                    case 0:
                        {
                            break;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, " 开始后勤任务出错", result.ToString()).userInfo();
                                return -1;
                            }

                            break;
                        }
                    default:
                        break;
                }
            }
        }

        public static int Abort_Operation_Act(UserData userData, Operation_Act_Info.Data data)
        {
            userData.webData.StatusBarText = String.Format(" 第 {0} 梯队后勤任务终止 ", data.team_id);
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = new JsonWriter(sb);
            writer.WriteObjectStart();
            writer.WritePropertyName("operation_id");
            writer.Write(data.operation_id);
            writer.WriteObjectEnd();

            int count = 0;
            while (true)
            {
                string result =  API.Operation.AbortOperation(userData.GameAccount, sb.ToString());
                switch (Convert.ToInt32(result))
                {
                    case 1:
                        {
                            return 1;
                        }
                    case 0:
                        {
                            break;
                        }
                    case -1:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "AbortOperation ERROR", result).userInfo();
                                return -1;
                            }
                            break;
                        }
                    default:
                        {
                            if (count++ > userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, "AbortOperation ERROR", result).userInfo();
                                return -1;
                            }
                            break;
                        }
                }
            }
        }






    }








}

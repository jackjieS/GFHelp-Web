using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GFHelp.Core.MulitePlayerData
{


    public class Operation_Act_Info
    {
        public Operation_Act_Info(UserData userData)
        {
            this.userData = userData;
            initMdata();
        }
        public class Data
        {
            public Data()
            {

            }

            public int key;//表示当前字段在字典里的键位
            public int id;
            public int operation_id=0;
            public int user_id;
            public int team_id=0;
            public int start_time;
            public int Duration
            {
                get
                {
                    if (operation_id > 0)
                    {
                        return CatachData.operation_info[operation_id - 1].duration + 10;
                    }
                    return 0;
                }
            }

            public int EndTime
            {
                get
                {
                    if (operation_id > 0)
                    {
                        return this.start_time + CatachData.operation_info[operation_id - 1].duration + 10;
                    }
                    return 0;
                }
            }
        }
        public UserData userData;
        public Dictionary<int, Data> dicOperation = new Dictionary<int, Data>();
        public List<Data> DefaultOperationMissionList = new List<Data>();

        public void initMdata()
        {
            DefaultOperationMissionList.Clear();
            Data data0 = new Data();
            data0.operation_id = 1;
            DefaultOperationMissionList.Add(data0);

            Data data1 = new Data();
            data1.operation_id = 2;
            DefaultOperationMissionList.Add(data1);

            Data data2 = new Data();
            data2.operation_id = 17;
            DefaultOperationMissionList.Add(data2);

            Data data3 = new Data();
            data3.operation_id = 30;
            DefaultOperationMissionList.Add(data3);
        }
        private object ObjectLocker = new object();
        public bool Locker = false;
        private int _NextTime;
        public int NextTime
        {
            get
            {
                return _NextTime;
            }
            set
            {
                _NextTime = value;
                AutoLoop.dic[userData.GameAccount.GameAccountID].OperationNextTime = value;
            }
        }


        public Data data = new Data();

        public void SetNextTime()
        {
            var dic = dicOperation.Keys.Select(x => new { x, y = dicOperation[x] }).OrderBy(x => x.y.EndTime).ToList();
            foreach (var item in dic)
            {
                if (item.y.start_time > 0 && item.y.operation_id > 0) { NextTime = item.y.EndTime; return; }
            }
            NextTime = 1853518917;
        }


        public async void AutoRun()
        {
            if (Locker) return;
            Locker = true;
            R();

        }
        private void R()
        {
            Task.Run(() =>
            {
                Interlocked.Increment(ref AutoLoop.ThreadInfo.OperationThreadNum);

                for (int i = 0; i < dicOperation.Count; i++)
                {
                    if (dicOperation[i].operation_id == 0) continue;
                    if (dicOperation[i].start_time == 0) continue;
                    if (dicOperation[i].EndTime < Decrypt.getDateTime_China_Int(DateTime.Now))
                    {
                        OperationLoop(dicOperation[i]);
                    }
                }

                this.Locker = false;
                Interlocked.Decrement(ref AutoLoop.ThreadInfo.OperationThreadNum);


            });


            //ThreadPool.QueueUserWorkItem(state =>
            //{
            //    Interlocked.Increment(ref AutoLoop.ThreadInfo.OperationThreadNum);

            //    for (int i = 0; i < dicOperation.Count; i++)
            //    {
            //        if (dicOperation[i].operation_id == 0) continue;
            //        if (dicOperation[i].start_time == 0) continue;
            //        if (dicOperation[i].EndTime < Decrypt.getDateTime_China_Int(DateTime.Now))
            //        {
            //            OperationLoop(dicOperation[i]);
            //        }
            //    }

            //    this.Locker = false;
            //    Interlocked.Decrement(ref AutoLoop.ThreadInfo.OperationThreadNum);

            //});
        }

        public void OperationLoop(Data data)
        {
            if (FinishHandle(data) == 1)
            {
                Thread.Sleep(1000);
                StartHandle(data);
                return;
            }
        }



        public bool Read(dynamic jsonobj)
        {
            dicOperation.Clear();
            foreach (var item in jsonobj.operation_act_info)
            {
                Data data = new Data();
                try
                {
                    data.key = dicOperation.Count;
                    data.id = Convert.ToInt32(item.id);
                    data.operation_id = Convert.ToInt32(item.operation_id);
                    data.user_id = Convert.ToInt32(item.user_id);
                    data.team_id = Convert.ToInt32(item.team_id);
                    data.start_time = Convert.ToInt32(item.start_time);
                }
                catch (Exception e)
                {
                    new Log().systemInit("读取UserData_operation_act_info遇到错误", e.ToString()).coreError();

                    continue;
                }
                dicOperation.Add(dicOperation.Count, data);
            }

            while (dicOperation.Count<4)
            {
                dicOperation.Add(dicOperation.Count, new Data());
            }
            SetNextTime();
            return true;
        }

        public void StopAllOperation()
        {
            for (int i = 0; i < dicOperation.Count; i++)
            {

                if (Abort(dicOperation[i]) == 1)
                {
                    dicOperation[i].start_time = (int)DateTime.MinValue.Ticks;
                    dicOperation[i].operation_id = 0;
                }
                Thread.Sleep(1000);
            }
        }
        public void StartAllOperationM()
        {
            initMdata();
            for (int i = 0; i < DefaultOperationMissionList.Count; i++)
            {
                if (userData.others.getAvailableTeamID().Contains(i))
                {
                    DefaultOperationMissionList[i].team_id = userData.others.getAvailableTeamID()[i];
                }
                else
                {
                    DefaultOperationMissionList.RemoveAt(i);
                }

            }
            for (int i = 0; i < dicOperation.Count; i++)
            {
                dicOperation[i] = DefaultOperationMissionList[i];
                StartHandle(DefaultOperationMissionList[i]);
            }
        }


        public bool isRunning()
        {
            int count = 0;
            foreach (var item in dicOperation)
            {
                if (item.Value.operation_id > 0) count++;
            }
            if (count == 4) return true;
            return false;
        }

        public int getEmptyDicOperationIndex()
        {
            foreach (var o in dicOperation)
            {
                if (o.Value.operation_id == 0) return o.Key;
            }

            return -1;
        }

        private void startMissing()
        {
            List<Data> NeedTostart = DefaultOperationMissionList;
            foreach (var item in dicOperation)
            {
                if (item.Value.operation_id != 0)
                {
                    NeedTostart.RemoveAll(q => q.operation_id == item.Value.operation_id);
                }
            }

            var AvilableTeamID = userData.others.getAvailableTeamID();
            for (int i = 0; i < AvilableTeamID.Count; i++)
            {
                if (userData.Teams[AvilableTeamID[i]].Count != 5)
                {
                    userData.others.TeamBuildLeaderLevel50(AvilableTeamID[i]);
                    userData.others.EmptyTeam(AvilableTeamID[i]);
                    userData.home.GetUserInfo();
                    userData.others.TeamMemberRefill(AvilableTeamID[i]);
                }
            }
            for (int i = 0; i < NeedTostart.Count; i++)
            {
                if (AvilableTeamID.Count > i)
                {
                    NeedTostart[i].team_id = AvilableTeamID[i];
                }
                else
                {
                    new Log().systemInit(string.Format("{0} StartMissing AvilableTeamID Error 梯队不够用", userData.GameAccount.GameAccountID)).coreInfo();
                }
            }
            for (int i = 0; i < NeedTostart.Count; i++)
            {
                if (NeedTostart[i].team_id == 0) return;
                if (getEmptyDicOperationIndex() != -1)
                {
                    dicOperation[getEmptyDicOperationIndex()] = NeedTostart[i];
                }

                StartHandle(NeedTostart[i]);
            }
            userData.home.GetUserInfo();
        }


        public void StartMissing()
        {

            if (isRunning()) return;
            if (userData.mission_With_User_Info.CheckMissionisOpen() == true)
            {
                //检查人形等级
                if (userData.others.CheckGunsLeval(48) == true)
                {
                    userData.operation_Act_Info.startMissing();
                    return;
                }
                return;
            }
        }

        public int FinishHandle(Data data)
        {
            int result = Finish(data);
            if (result == 1)
            {

            }
            else
            {
                dicOperation[data.key] = new Data();
            }
            SetNextTime();
            return result;


        }
        public int Finish(Data data)
        {
            userData.webData.StatusBarText = String.Format(" 第 {0} 梯队后勤任务结束 ", data.team_id);
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = new JsonWriter(sb);
            writer.WriteObjectStart();
            writer.WritePropertyName("operation_id");
            writer.Write(data.operation_id);
            writer.WriteObjectEnd();
            //发送请求
            string result;
            while (true)
            {
                try
                {
                    result = userData.Net.Operation.FinishOperation(userData.GameAccount, sb.ToString());
                }
                catch (Exception)
                {
                    return -1;
                }
                return userData.Response.Check(ref result, "Finish_Operation_Pro", true);
            }
        }

        public int StartHandle(Data data)
        {
            int result = Start(data);
            if (result == 1)
            {
                dicOperation[data.key].start_time = Decrypt.getDateTime_China_Int(DateTime.Now) + 10;
            }
            else
            {
                dicOperation[data.key] = new Data();
            }
            SetNextTime();
            return result;
        }
        private int Start(Data data)
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
            string result;
            while (true)
            {
                try
                {
                    result = userData.Net.Operation.StartOperation(userData.GameAccount, sb.ToString());
                }
                catch (Exception)
                {
                    return -1;
                }
                return userData.Response.Check(ref result, "GUN_OUTandIN_Team_PRO", false);
            }
        }

        public int Abort(Data data)
        {
            userData.webData.StatusBarText = String.Format(" 第 {0} 梯队后勤任务终止 ", data.team_id);
            StringBuilder sb = new StringBuilder();
            JsonWriter writer = new JsonWriter(sb);
            writer.WriteObjectStart();
            writer.WritePropertyName("operation_id");
            writer.Write(data.operation_id);
            writer.WriteObjectEnd();

            int count = 0;

            string result;
            while (true)
            {

                try
                {
                    result = userData.Net.Operation.AbortOperation(userData.GameAccount, sb.ToString());
                }
                catch (Exception)
                {
                    Thread.Sleep(5000);
                    continue;
                }

                if (result.ToLower().Contains("error"))
                {
                    if (count < 5)
                    {
                        count++;
                        continue;
                    }
                    if (count > 5)
                    {
                        return -1;
                    }
                }

                switch (userData.Response.Check(ref result, "GUN_OUTandIN_Team_PRO", false))
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
                            break;
                        }
                    default:
                        break;
                }
            }
        }

    }


}

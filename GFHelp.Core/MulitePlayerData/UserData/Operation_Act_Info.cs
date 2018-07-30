using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core.MulitePlayerData
{
    

    public class Operation_Act_Info
    {
        public class Data
        {
            public Data()
            {
                this.Using = false;
            }
            public bool Using;
            public int key;//表示当前字段在字典里的键位
            public int id;
            public int operation_id;
            public int user_id;
            public int team_id;
            public int start_time;
            public int remaining_time;
        }
        public UserData userData;
        public Dictionary<int, Data> dicOperation = new Dictionary<int, Data>();
        public Data data = new Data();
        public void SetUserdata(UserData ud)
        {
            userData = ud;
        }

        public void TimeReduce()
        {
            //剩下时间 = 开始时间+任务时间 - 当前时间
            try
            {
                for (int i = 0; i < dicOperation.Count; i++)
                {
                    if (dicOperation[i].start_time == (int)DateTime.MinValue.Ticks) continue;
                    dicOperation[i].remaining_time = dicOperation[i].start_time + /*任务时间*/ CatachData.operation_info[dicOperation[i].operation_id - 1].duration - Decrypt.ConvertDateTime_China_Int(DateTime.Now);
                    if (dicOperation[i].remaining_time < 0)
                    {
                        Data data = dicOperation[i];
                        dicOperation[i].Using = false;
                        Task<int> taskFinish = new Task<int>(() => Finish(data));
                        Task<int> taskStart = new Task<int>(() => Start(data));
                        taskFinish.Start();

                        taskFinish.ContinueWith(t =>
                        {
                            if (taskFinish.Result == 1)
                            {
                                taskStart.Start();
                            }
                            else
                            {
                                dicOperation[i].start_time = (int)DateTime.MinValue.Ticks;
                                dicOperation[i].Using = false;
                                dicOperation[i].remaining_time = 0;
                            }
                        });
                        Task.WaitAll(taskStart);
                    }
                    else
                    {
                        dicOperation[i].Using = true;
                    }
                }

            }
            catch (Exception e)
            {
                //MessageBox.Show("计算后勤剩余时间出错");
                //MessageBox.Show(e.ToString());
            }
        }
        public int Start(Data data)
        {
            //string accountID = text.accountID.ToString();
            //string operationID = text.operationID.ToString();
            //string TeamID = text.TeamID.ToString();
            if (dicOperation.Count >= 4)
            {
                new Log().userInit(userData.GameAccount.Base.AndroidID, "后勤开始失败" + data.ToString());
            }
            for (int i = 0; i < dicOperation.Count; i++)
            {
                if (dicOperation[i].Using == false)
                {
                    if (Action.Operation.Start_Operation_Act(userData, data) == 1)
                    {
                        data.start_time = Decrypt.ConvertDateTime_China_Int(DateTime.Now) + 10;
                        dicOperation[i] = data;
                        return 1;
                    }
                }
            }
            new Log().userInit(userData.GameAccount.Base.AndroidID, "后勤开始失败 " + data.ToString());
            return -1;
        }
        

        public int Finish(Data data)
        {
            return Action.Operation.Finish_Operation_Act(userData, data);
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
            return true;
        }



        public void Abort(Data data)
        {
            for (int i = 0; i < dicOperation.Count; i++)
            {
                if (dicOperation[i].operation_id == data.operation_id)
                {
                    Task taskAbort = new Task(() =>
                    {
                        int key = i;
                        if (Action.Operation.Abort_Operation_Act(userData, data) == 1)
                        {
                            dicOperation[i].start_time = (int)DateTime.MinValue.Ticks;
                            dicOperation[i].Using = false;
                            dicOperation[i].remaining_time = 0;
                        }
                    });
                    taskAbort.Start();
                    Task.WaitAll(taskAbort);
                }
            }
        }

    }


}

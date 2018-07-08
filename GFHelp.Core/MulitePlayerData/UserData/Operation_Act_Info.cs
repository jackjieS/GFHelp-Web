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
                foreach (var item in dicOperation)
                {
                    item.Value.remaining_time= item.Value.start_time + /*任务时间*/ CatachData.operation_info[item.Value.operation_id - 1 ].duration - Decrypt.ConvertDateTime_China_Int(DateTime.Now);
                }

                for (int i = 0; i < dicOperation.Count; i++)
                {
                    if (!dicOperation.ContainsKey(i)) continue;
                    if (dicOperation[i].remaining_time <= 0)
                    {
                        Data data = dicOperation[i];
                        dicOperation.Remove(i);
                        Task taskFinish = new Task(() => Finish(data));
                        taskFinish.ContinueWith(t=> Start(data));
                        taskFinish.Start();

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
            foreach (var item in dicOperation)
            {
                if(item.Value.operation_id == data.operation_id || item.Value.team_id == data.team_id)
                {
                    //当前任务已存在
                    return -1;
                }
            }
            if (dicOperation.Count >= 4)
            {
                //已有4个任务
                return -2;
            }
            for (int i = 0; i < 4; i++)
            {
                if (!dicOperation.ContainsKey(i))
                {
                    if (Action.Operation.Start_Operation_Act(userData, data) == 1)
                    {

                        data.start_time = Decrypt.ConvertDateTime_China_Int(DateTime.Now);
                        dicOperation.Add(i, data);
                        return 1;
                    }
                }
            }
            return -1;
        }
        

        public void Finish(Data data)
        {
            //string accountID = text.accountID.ToString();
            //string operationID = text.operationID.ToString();
            //string TeamID = text.TeamID.ToString();
            if (Action.Operation.Finish_Operation_Act(userData, data) == 1)
            {

            }
            //没有这个任务
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
            return true;
        }



        public void Abort(Data data)
        {
            //
            for (int i = 0; i < dicOperation.Count; i++)
            {
                if (!dicOperation.ContainsKey(i)) continue;
                if (dicOperation[i].operation_id == data.operation_id)
                {
                    int result = 0;
                    int key = i;
                    Task taskAbort = new Task(() =>
                    {
                        result = Action.Operation.Abort_Operation_Act(userData, data);
                    });
                    taskAbort.ContinueWith(t =>
                    {
                        if (result == 1)
                        {
                            dicOperation.Remove(key);
                        }
                    });
                    taskAbort.Start();
                }
            }
        }

    }


}

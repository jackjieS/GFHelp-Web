using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Operation_Act_Info
    {
        public Dictionary<int, Operation_Act_Info> dicOperation = new Dictionary<int, Operation_Act_Info>();
        public int key;//表示当前字段在字典里的键位
        public int id;
        public int operation_id;
        public int user_id;
        public int team_id;
        public int start_time;

        public int remaining_time;
        public bool Added = false;//true 已经添加到任务队列
        public void Time_Operate(int operation_time)
        {
            //剩下时间 = 开始时间+任务时间 - 当前时间
            try
            {
                if (string.IsNullOrEmpty(id.ToString()) == false)
                {
                    remaining_time = start_time + operation_time - Helper.Decrypt.ConvertDateTime_China_Int(DateTime.Now);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("计算后勤剩余时间出错");
                //MessageBox.Show(e.ToString());
            }
        }


        public bool Read(dynamic jsonobj)
        {
            dicOperation.Clear();

            foreach (var item in jsonobj.operation_act_info)
            {
                Operation_Act_Info oai = new Operation_Act_Info();
                try
                {
                    oai.key = dicOperation.Count;
                    oai.id = Convert.ToInt32(item.id);
                    oai.operation_id = Convert.ToInt32(item.operation_id);
                    oai.user_id = Convert.ToInt32(item.user_id);
                    oai.team_id = Convert.ToInt32(item.team_id);
                    oai.start_time = Convert.ToInt32(item.start_time);
                }
                catch (Exception e)
                {
                    SystemEvents.Log log = new SystemEvents.Log(1, "读取UserData_operation_act_info遇到错误", e.ToString());
                    SystemEvents.Viewer.Logs.Add(log);
                    continue;
                }
                dicOperation.Add(dicOperation.Count, oai);

            }
            return true;
        }


    }


}

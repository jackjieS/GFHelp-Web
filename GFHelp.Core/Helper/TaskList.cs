using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core.Helper
{
    public class TaskListInfo
    {
        public TaskListInfo(string tasknme, int tasknumber)
        {
            TaskName = tasknme;
            TaskNumber = tasknumber;
        }

        public int TaskNumber;
        public string TaskName;
    }

    public class TaskList
    {
        public static TaskListInfo taskfree = new TaskListInfo("空闲", 0);
        public static TaskListInfo Login = new TaskListInfo("登陆", 1);
        public static TaskListInfo GetuserInfo = new TaskListInfo("读取用户信息", 2);

        public static TaskListInfo Click_Kalina = new TaskListInfo("格琳娜好感上升", 21);
        public static TaskListInfo Click_Girls_In_Dorm = new TaskListInfo("宿舍少女好感上升", 22);
        public static TaskListInfo Get_Battary_Friend = new TaskListInfo("获取好友电池", 23);
        public static TaskListInfo Get_Battary_Mine = new TaskListInfo("获取自己电池", 24);
        public static TaskListInfo Get_Dorm_Info = new TaskListInfo("获取自己宿舍信息", 25);
        public static TaskListInfo Friend_Praise = new TaskListInfo("好友点赞", 26);
        public static TaskListInfo Start_Trial = new TaskListInfo("无限防御", 31);
        public static TaskListInfo GetRecoverBp = new TaskListInfo("获取BP点数", 32);
        public static TaskListInfo Simulation_DATA = new TaskListInfo("资料采样", 33);
        public static TaskListInfo Simulation_Corridor = new TaskListInfo("云图回廊", 34);


        public static TaskListInfo TaskBattle_1 = new TaskListInfo("练级任务1", 41);
        public static TaskListInfo TaskBattle_2 = new TaskListInfo("练级任务2", 42);
        public static TaskListInfo TaskBattle_3 = new TaskListInfo("练级任务3", 43);
        public static TaskListInfo TaskBattle_4 = new TaskListInfo("练级任务4", 44);

        public static TaskListInfo BattleReport_Write = new TaskListInfo("作战报告_开始", 51);
        public static TaskListInfo BattleReport_Finish = new TaskListInfo("作战报告_结束", 52);
    }
}

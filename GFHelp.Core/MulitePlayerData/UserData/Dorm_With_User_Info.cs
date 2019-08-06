using Codeplex.Data;
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
    /// <summary>
    /// 主要用途: 获取电池 
    /// </summary>
    public class Dorm_With_User_Info
    {
        public Dorm_With_User_Info(UserData userData)
        {
            this.userData = userData;
        }
        public void Read(dynamic jsonobj)
        {
            try
            {
                info.dorm_id = jsonobj.info.dorm_id.ToString();
                info.praise_num = jsonobj.info.praise_num.ToString();
                info.user_id = jsonobj.info.user_id.ToString();
                info.visit_num = jsonobj.info.visit_num.ToString();
                current_build_coin = Convert.ToInt32(jsonobj.current_build_coin);
                build_coin_flag = Convert.ToInt32(jsonobj.build_coin_flag);
            }
            catch (Exception e)
            {
                new Log().systemInit("读取DormData遇到错误", e.ToString()).coreError();
            }
        }
        public info info = new info();
        public int current_build_coin;
        public int build_coin_flag;
        public UserData userData;
        Dictionary<Friend_With_User_Info.Data, int> dicFridentBatteryNumber = new Dictionary<Friend_With_User_Info.Data, int>();
        private bool is3AMswitchStart = false;
        private bool is15PMswitchStart = false;
        private bool is11PMswitchMineStart = false;
        private bool is17PMswitchMineStart = false;

        public void TimeReduce()
        {
            DateTime BeijingTimeNow = Decrypt.ChinaTimeDateTime;
            //3点
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 3 + 3))
            {
                if (is3AMswitchStart == false)
                {
                    Task getFriendBattery = new Task(() => FriendBattery());
                    is3AMswitchStart = true;
                    getFriendBattery.Start();
                    
                }
            }
            else
            {
                is3AMswitchStart = false;
            }


            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 15 + 3))
            {
                if (is15PMswitchStart == false)
                {
                    Task getFriendBattery = new Task(() => FriendBattery());
                    is15PMswitchStart = true;
                    getFriendBattery.Start();
                }
            }
            else
            {
                is15PMswitchStart = false;
            }

            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 11 + 10))
            {
                if (is11PMswitchMineStart == false)
                {
                    Task getMyDormInfo = new Task(() => Get_Dorm_Info(userData));
                    Task getMyBattery = new Task(() => Get_Build_Coin(userData));
                    is11PMswitchMineStart = true;
                    getMyDormInfo.Start();
                    getMyDormInfo.ContinueWith(t=>getMyBattery.Start());
                }

            }
            else
            {
                is11PMswitchMineStart = false;
            }

            //17点
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 17 + 10))
            {

                if (is17PMswitchMineStart == false)
                {
                    Task getMyDormInfo = new Task(() => Get_Dorm_Info(userData));
                    Task getMyBattery = new Task(() => Get_Build_Coin(userData));
                    is17PMswitchMineStart = true;
                    getMyDormInfo.Start();
                    getMyDormInfo.ContinueWith(t => getMyBattery.Start());
                }
            }
            else
            {
                is17PMswitchMineStart = false;
            }

            //0点
            if (BeijingTimeNow.Hour==0 &&  BeijingTimeNow.Minute==10 && BeijingTimeNow.Second ==1)
            {
                Thread.Sleep(1000);
                Task getdata = new Task(() => GetOandPDataHandle());
                getdata.Start();



            }
            //8点
            if (BeijingTimeNow.Hour == 8 && BeijingTimeNow.Minute == 10 && BeijingTimeNow.Second == 1)
            {
                Thread.Sleep(1000);
                Task getdata = new Task(() => GetOandPDataHandle());
                getdata.Start();



            }
            //16点
            if (BeijingTimeNow.Hour == 16 && BeijingTimeNow.Minute == 10 && BeijingTimeNow.Second == 1)
            {
                Thread.Sleep(1000);
                Task getdata = new Task(() => GetOandPDataHandle());
                getdata.Start();



            }
        }

        public void ClickGirlsFavor()
        {
            //编列梯队列表
            //梯队内人形can_click ==1 则发送post
            //根据result can_click +1;
            if (userData.config.M == true) return;
            for (int x = 1; x <= userData.Teams.Count; x++)
            {
                if (userData.Teams[x].Count == 0) continue;
                for (int y = 1; y <= userData.Teams[x].Count; y++)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(userData.Teams[x][y].location.ToString())) continue;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (userData.Teams[x][y].canClick == 1)
                    {
                        bool Loop = true;
                        int count = 0;
                        while (Loop)
                        {
                            string result = userData.Net.Dorm.ClickGirlsFavor(userData.GameAccount, x, userData.Teams[x][y].id);
                            switch (userData.Response.Check( ref result, "ClickGirlsFavor", true))
                            {
                                case 1:
                                    {
                                        var jsonobj = DynamicJson.Parse(result);
                                        result = jsonobj.favor_click.ToString();
                                        userData.webData.StatusBarText = String.Format(" 第 {0} 宿舍 少女 {1} 好感度提升 result = {2}", x, userData.Teams[x][y].gun_id.ToString(), result);
                                        userData.Teams[x][y].canClick++;
                                        Loop = false;
                                        break;
                                    }
                                case 0:
                                    {
                                        if (count++ >= userData.config.ErrorCount) break;
                                        break;
                                    }
                                case -1:
                                    {
                                        if (count++ >= userData.config.ErrorCount) break;
                                        break;
                                    }
                                default: break;
                            }
                        }
                    }
                }
            }

        }
        private void printBatteryNumber()
        {
            int i = 1;
            foreach (var item in dicFridentBatteryNumber)
            {
                if (item.Value > 0)
                {
                    new Log().userInit(userData.GameAccount.GameAccountID, string.Format(" {0} 宿舍 电池数 {1}", item.Key.name, item.Value)).userInfo();
                    i++;
                }
                
            }
            new Log().userInit(userData.GameAccount.GameAccountID,string.Format(" -----------展示好友电池信息({0})------------",i)).userInfo();
        }

        public void FriendBattery()
        {
            if (userData.Dorm_Rest_Friend_Build_Coin_Count <= 0) return;
            dicFridentBatteryNumber.Clear();
            try
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "-----------获取好友电池信息------------").userInfo();
                foreach (var item in userData.friend_with_user_info.dicFriend)
                {
                    int Friend_BattaryNum = GetFriendBatteryNum(userData, item.Value.f_userid);
                    dicFridentBatteryNumber.Add(item.Value, Friend_BattaryNum);
                }
                dicFridentBatteryNumber = dicFridentBatteryNumber.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
                printBatteryNumber();
                foreach (var item in dicFridentBatteryNumber)
                {
                    if (userData.Dorm_Rest_Friend_Build_Coin_Count <= 0) return;
                    new Log().userInit(userData.GameAccount.GameAccountID, String.Format(" 获取好友 {0} 电池 数量 {1}", item.Key.name, item.Value)).userInfo();
                    GetFriendBattery(userData, item.Key.f_userid);
                    userData.Dorm_Rest_Friend_Build_Coin_Count--;
                }
            }
            catch (Exception e)
            {
                new Log().userInit(userData.GameAccount.GameAccountID, "非法操作 " + e.ToString()).userInfo();
            }

        }
        private int GetFriendBatteryNum(UserData userData, int id)
        {
            int count = 0;
            while (true)
            {
                var result = userData.Net.Dorm.Get_Friend_BattaryNum(userData.GameAccount, id);
                switch (userData.Response.Check( ref result, "Get_Friend_BattaryNum", true))
                {
                    case 1:
                        {
                            var jsonobj = DynamicJson.Parse(result);
                            return Convert.ToInt32(jsonobj.build_coin_flag.ToString());
                        }
                    case 0:
                        {
                            if (count++ >= userData.config.ErrorCount) return 0;
                            continue;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount) return 0;
                            continue;
                        }
                    default: break;
                }
            }
        }

        private bool GetFriendBattery(UserData userData, int id)
        {
            int count = 0;
            while (true)
            {
                var result = userData.Net.Dorm.Get_Friend_Battary(userData.GameAccount, id, 0);
                switch (userData.Response.Check( ref result, "Get_Friend_Battary", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            if (count++ >= userData.config.ErrorCount) return false;
                            continue;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount) return false;
                            continue;
                        }
                    default: break;
                }
            }
        }

        private void Get_Dorm_Info(UserData userData)
        {
            if (userData.config.M == true) return;
            try
            {
                int count = 0;
                while (true)
                {
                    string result = userData.Net.Dorm.GetFriend_DormInfo(userData.GameAccount);

                    switch (userData.Response.Check( ref result, "GetFriend_DormInfo_Pro", true))
                    {
                        case 1:
                            {
                                var jsonobj = DynamicJson.Parse(result);
                                userData.dorm_with_user_info.Read(jsonobj);
                                return;
                            }
                        case 0:
                            {
                                if (count++ >= userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.GameAccountID, "获取电池出错", result).userInfo();
                                    return;
                                }
                                break;
                            }
                        case -1:
                            {
                                if (count++ >= userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.GameAccountID, "获取宿舍信息出错", result).userInfo();
                                    return;
                                }
                                break;
                            }
                        default:
                            break;
                    }

                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void Get_Build_Coin(UserData userData)
        {
            if (userData.config.M == true) return;
            try
            {
                if (userData.dorm_with_user_info.current_build_coin <= 0) return;
                //开始获得
                userData.dorm_with_user_info.current_build_coin = 0;
                int count = 0;
                while (true)
                {
                    string result = userData.Net.Dorm.Get_Build_Coin(userData.GameAccount, userData.dorm_with_user_info.info.user_id, userData.dorm_with_user_info.info.dorm_id);

                    switch (userData.Response.Check( ref result, "Get_Friend_Build_Coin_Pro", true))
                    {
                        case 1:
                            {
                                return;
                            }
                        case 0:
                            {
                                if (count++ >= userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.GameAccountID, "获取电池出错", result.ToString()).userInfo();
                                    return;
                                }
                                break;
                            }
                        case -1:
                            {
                                if (count++ >= userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.GameAccountID, " 获取电池出错", result.ToString()).userInfo();
                                    return;
                                }
                                break;
                            }
                        default:
                            break;
                    }

                }

            }
            catch (Exception)
            {
                return;
            }
        }

        private void GetOandPDataHandle()
        {
            if (userData.config.M == true) return;
            if (userData.config.DataAnalysis == false) return;
            string result = "";
            if(GetOandPData(ref result))
            {
                JsonData jsonData = JsonMapper.ToObject(result);
                this.userData.item_With_User_Info.originalData+= jsonData["base_cell"].Int;
                this.userData.item_With_User_Info.PureData += jsonData["senior_cell"].Int;
            }




        }

        private bool GetOandPData(ref string result)
        {
            if (userData.config.M == true) return true;
            new Log().userInit(userData.GameAccount.GameAccountID, "收集数据 数据监测枢纽 ").userInfo();
            int count = 0;
            while (true)
            {
                result = userData.Net.Dorm.getDataCell(userData.GameAccount);

                switch (userData.Response.Check( ref result, "getDataCell_Pro", true))
                {
                    case 1:
                        {
                            new Log().userInit(userData.GameAccount.GameAccountID, "收集数据 数据监测枢纽 完成").userInfo();
                            return true;
                        }
                    case 0:
                        {
                            if (count++ >= userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, " 获取数据样本出错", result.ToString()).userInfo();
                                return false;
                            }
                            break;
                        }
                    case -1:
                        {
                            if (count++ >= userData.config.ErrorCount)
                            {
                                new Log().userInit(userData.GameAccount.GameAccountID, " 获取数据样本出错", result.ToString()).userInfo();
                                return false;
                            }
                            break;
                        }
                    default:
                        break;
                }








            }






        }


































    }

    public class info
    {
        public string praise_num;
        public string visit_num;
        public string user_id;//记录这个
        public string dorm_id;//记录这个
    }
}

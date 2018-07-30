using Codeplex.Data;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core.MulitePlayerData
{
    /// <summary>
    /// 主要用途: 获取电池 
    /// </summary>
    public class Dorm_With_User_Info
    {
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
        public void SetUserdata(UserData ud)
        {
            userData = ud;
        }
        private bool is3AMswitchStart = false;
        private bool is15PMswitchStart = false;
        private bool is11PMswitchMineStart = false;
        private bool is17PMswitchMineStart = false;

        public void TimeReduce()
        {
            DateTime BeijingTimeNow = Decrypt.LocalDateTimeConvertToChina(DateTime.Now);
            //3点
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 3 + 1))
            {
                if (is3AMswitchStart == false)
                {
                    Task getFriendBattery = new Task(() => FriendBattery(userData));
                    is3AMswitchStart = true;
                    getFriendBattery.Start();
                }
            }
            else
            {
                is3AMswitchStart = false;
            }


            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 15 + 1))
            {
                if (is15PMswitchStart == false)
                {
                    Task getFriendBattery = new Task(() => FriendBattery(userData));
                    is3AMswitchStart = true;
                    getFriendBattery.Start();
                }
            }
            else
            {
                is3AMswitchStart = false;
            }

            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 11 + 1))
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
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 17 + 1))
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




        }




        private void FriendBattery(UserData userData)
        {
            int BattaryNum = 10;
            for (int i = 0; i < userData.friend_with_user_info.dicFriend.Count; i++)
            {
                var friend = userData.friend_with_user_info.dicFriend[i];
                int Friend_BattaryNum = GetFriendBatteryNum(userData, friend.f_userid);
                new Log().userInit(userData.GameAccount.Base.GameAccountID, String.Format(" {0} 宿舍 电池数 {1} 剩余 {2}", friend.name, Friend_BattaryNum, userData.friend_with_user_info.dicFriend.Count - i+1)).userInfo();
                if (Friend_BattaryNum == BattaryNum)
                {
                    GetFriendBattery(userData, friend.f_userid);
                    userData.Dorm_Rest_Friend_Build_Coin_Count--;
                    if (userData.Dorm_Rest_Friend_Build_Coin_Count == 0) return;
                }
            }
        }
        private int GetFriendBatteryNum(UserData userData, int id)
        {
            int count = 0;
            while (true)
            {
                var result = API.Dorm.Get_Friend_BattaryNum(userData.GameAccount, id);
                switch (Helper.Response.Check(userData.GameAccount, ref result, "Get_Friend_BattaryNum", true))
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
                var result = API.Dorm.Get_Friend_Battary(userData.GameAccount, id, 0);
                switch (Helper.Response.Check(userData.GameAccount, ref result, "Get_Friend_Battary", true))
                {
                    case 1:
                        {
                            userData.Dorm_Rest_Friend_Build_Coin_Count--;
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
            try
            {
                int count = 0;
                while (true)
                {
                    string result = API.Dorm.GetFriend_DormInfo(userData.GameAccount);

                    switch (Helper.Response.Check(userData.GameAccount, ref result, "GetFriend_DormInfo_Pro", true))
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
                                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "获取电池出错", result).userInfo();
                                    return;
                                }
                                break;
                            }
                        case -1:
                            {
                                if (count++ >= userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "获取宿舍信息出错", result).userInfo();
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
            try
            {
                if (userData.dorm_with_user_info.current_build_coin <= 0) return;
                //开始获得
                userData.dorm_with_user_info.current_build_coin = 0;
                int count = 0;
                while (true)
                {
                    string result = API.Dorm.Get_Build_Coin(userData.GameAccount, userData.dorm_with_user_info.info.user_id, userData.dorm_with_user_info.info.dorm_id);

                    switch (Helper.Response.Check(userData.GameAccount, ref result, "Get_Friend_Build_Coin_Pro", true))
                    {
                        case 1:
                            {
                                return;
                            }
                        case 0:
                            {
                                if (count++ >= userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.Base.GameAccountID, "获取电池出错", result.ToString()).userInfo();
                                    return;
                                }
                                break;
                            }
                        case -1:
                            {
                                if (count++ >= userData.config.ErrorCount)
                                {
                                    new Log().userInit(userData.GameAccount.Base.GameAccountID, " 获取电池出错", result.ToString()).userInfo();
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





































    }

    public class info
    {
        public string praise_num;
        public string visit_num;
        public string user_id;//记录这个
        public string dorm_id;//记录这个
    }
}

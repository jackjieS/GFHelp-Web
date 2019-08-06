using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class Share_With_User_Info
    {
        public Share_With_User_Info(UserData userData)
        {
            this.userData = userData;
            this.data = new Data();
        }
        private UserData userData;
        public  Data data; 

        public void Read(dynamic jsonobj)
        {
           data.last_time = int.Parse(jsonobj.share_with_user_info.last_time.ToString());
           AutoShare();
        }

        private void AutoShare()
        {
            Decrypt.getDateTime_China_Int(DateTime.Now);
            if(data.last_time < Decrypt.getDateTime_China_Int(DateTime.Now))
            {
                new Log().userInit(userData.GameAccount.GameAccountID, " 自动分享获取30钻石").userInfo();
                userData.Net.Dorm.WeeklyShare(userData.GameAccount);
                data.last_time += 999999999;
            }
        }



        public class Data
        {
            public int last_time;
        }
     



    }
}

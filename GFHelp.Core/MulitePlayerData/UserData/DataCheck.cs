using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class DataCheck
    {
        public UserData userData;
        public DataCheck(UserData userData)
        {
            this.userData = userData;
        }  

        public void AutoRunning()
        {
            if (userData.config.FinalLoginSuccess == false) return;
            Doll_Build();
            UpdateUserInfo();
        }
        public void Doll_Build()
        {
            userData.doll_Build.AutoRun();
        }
        public void UpdateUserInfo()
        {
            userData.dailyReFlash.AutoRun();


        }



    }
}

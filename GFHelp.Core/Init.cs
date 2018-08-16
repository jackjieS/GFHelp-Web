using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core
{
    public class Init
    {
        public static void InitFromDatabase()
        {
            var GetGameAccounts = DataBase.DataBase.GetGameAccounts();
            var AccountInfo = DataBase.DataBase.GetAccountInfos();
            foreach (var item in GetGameAccounts)
            {
                UserData ud = new UserData();
                ud.CreatGameAccount(item);
                Data.Seed(ud);
            }
            foreach (var item in AccountInfo)
            {
                SystemOthers.ConfigData.WebUserData.Add(item);
            }


        }



    }
}

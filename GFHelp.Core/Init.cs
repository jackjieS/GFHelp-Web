using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core
{
    public class Init
    {


        public static void InitFromDatabase()
        {
            Helper.Decrypt.init();
            Task task = new Task(() =>
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
                    SystemManager.ConfigData.WebUserData.Add(item);
                }
            });
            task.Start();
            task.ContinueWith(t => { Console.WriteLine("InitFromDatabase Success"); });

            AutoLoop operationLoop = new AutoLoop();
           
        }



    }
}

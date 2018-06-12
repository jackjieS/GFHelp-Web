using Codeplex.Data;
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GFHelp.Core.Action
{
    class Battle
    {
        public static void Abort_Mission_login(UserData userData)
        {
            if (userData.others.Mission_S)
            {
                abortMission(userData);
            }
        }

        public static bool abortMission(UserData userData)
        {
            userData.webData.StatusBarText = (" 终止作战");

            int count = 0;
            while (true)
            {
                string result = API.Battle.abortMission(userData.GameAccount);
                Thread.Sleep(1000);

                switch (Response.Check(userData.GameAccount,ref result, "Abort_Mission_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {

                            if (count >= userData.config.ErrorCount) { return false; }
                            continue;
                        }
                    default:
                        break;
                }
            }
        }

        public static bool GetRecoverBP(UserData userData)
        {
            userData.webData.StatusBarText = "动能点数恢复";

            int count = 0;
            while (true)
            {
                string result =API.Battle.GetRecoverBP(userData.GameAccount);

                switch (Response.Check(userData.GameAccount,ref result, "Get_RecoverBP_Pro", true))
                {
                    case 1:
                        {

                            var jsonobj = DynamicJson.Parse(result);
                            userData.user_Info.bp += Convert.ToInt32(jsonobj.recover_bp);
                            userData.user_Info.last_bp_recover_time = Convert.ToInt32(jsonobj.last_bp_recover_time);
                            return true;
                        }
                    case 0:
                        {
                            if (count >= userData.config.ErrorCount) { return false; }
                            break;
                        }
                    case -1:
                        {
                            if (count >= userData.config.ErrorCount) { return false; }
                            break;
                        }
                    default:
                        break;
                }

            }
        }

    }
}

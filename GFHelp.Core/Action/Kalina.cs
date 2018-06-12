using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.Action
{
    class Kalina
    {
        public static void Click_Kalina(UserData userData)
        {

            string result = API.Kalina.Click_kalinaFavor(userData.GameAccount);
            if (result.Contains("1"))
            {
                userData.webData.StatusBarText = String.Format(" Kalina好感度 + 1 ");
            }

        }
    }
}

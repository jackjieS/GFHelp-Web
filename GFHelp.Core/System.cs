using System;
using System.Collections.Generic;

namespace GFHelp.Core.SysteOthers
{
    public class Log
    {
        public int code;
        public string message;
        public string exception;
        public string timpstamp;
        public Log(int code,string message,string exception)
        {
            this.code = code;
            this.message = message;
            this.exception = exception;
            this.timpstamp = DateTime.Now.ToString();
        }
        public Log(int code, string message)
        {
            this.code = code;
            this.message = message;
            this.timpstamp = DateTime.Now.ToString();
        }
    }

    public class Viewer
    {
        public static List< Log> Logs = new List<Log>();
    }

    public class ConfigData
    {
        public static string DataVersion;
        public static int tomorrow_zero;
        public static int weekday;
        public static List<string> BattleMap = new List<string>()
        {
            "0-2",
            "5-2N",
            "10-4E"
        };
        public static int Error_num =3;
        public static int BL_ReLogin_num = 20;
    }
}

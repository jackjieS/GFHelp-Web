using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    class Asset_Textes
    {
        struct ConfigNode
        {
            public string key;
            public string value;

            public ConfigNode(string key, string value)
            {
                this.key = key;
                this.value = value;
            }

            public override string ToString()
            {
                return this.value;
            }
        }

        private static string operationfileName = "textRes\\operation.csv";
        private static string prizefilename = "textRes\\prize.csv";
        private static string dailyfilename = "textRes\\daily.csv";
        private static string achievementfilename = "textRes\\achievement.csv";
        private static string weeklyfilename = "textRes\\weekly.csv";
        private static string equipfilename = "textRes\\equip.csv";
        private static string gunfilename = "textRes\\gun.csv";
        private static Dictionary<int, ConfigNode> csvdata = new Dictionary<int, ConfigNode>();
        private static int maxline = 0;



        static public bool Read_ALL_CSV()
        {
            try
            {
                ReadCsv(operationfileName, ref csvdata);
                ReadCsv(prizefilename, ref csvdata);
                ReadCsv(dailyfilename, ref csvdata);
                ReadCsv(achievementfilename, ref csvdata);
                ReadCsv(weeklyfilename, ref csvdata);
                ReadCsv(equipfilename, ref csvdata);
                ReadCsv(gunfilename, ref csvdata);
            }
            catch (Exception e)
            {
                SysteOthers.Log log = new SysteOthers.Log(1, "读取 csv 出错", e.ToString());
                SysteOthers.Viewer.Logs.Add(log);
                return false;
            }
            return true;
        }

        static bool  ReadCsv(string filename, ref Dictionary<int, ConfigNode> tempdictionary)
        {
            if (String.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                return false;
            }

            string[] con = File.ReadAllLines(filename);
            try
            {
                int linenum = csvdata.Count - 1;
                foreach (string line in con)
                {
                    ++linenum;
                    if (String.IsNullOrEmpty(line) || line[0] == '#') continue;//注释
                    string[] c = line.Split(',');
                    tempdictionary.Add(linenum, new ConfigNode(c[0].Trim(), c[1].Trim().ToLower()));
                }
                maxline = con.Length;
                return true;
            }
            catch (Exception e)
            {
                SysteOthers.Log log = new SysteOthers.Log(1, string.Format("读取 {0} 出错", filename.ToString()), e.ToString());
                SysteOthers.Viewer.Logs.Add(log);

                return false;
            }
        }

        public static string ChangeCodeFromeCSV(string res)
        {
            foreach (var item in csvdata)
            {
                if (res == item.Value.key)
                {
                    return item.Value.value;
                }
            }

            return string.Format("解析错误 {0}", res);
        }

    }
}

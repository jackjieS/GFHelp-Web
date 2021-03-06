﻿using GFHelp.Core.Helper;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace GFHelp.Core.CatchData.Base
{
    public class Asset_Textes
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

        static string currentDirectory = SystemManager.ConfigData.currentDirectory;
        private static string operationfileName = currentDirectory+ "\\textRes\\operation.csv";
        private static string prizefilename = currentDirectory + "\\textRes\\prize.csv";
        private static string dailyfilename = currentDirectory + "\\textRes\\daily.csv";
        private static string achievementfilename = currentDirectory + "\\textRes\\achievement.csv";
        private static string weeklyfilename = currentDirectory + "\\textRes\\weekly.csv";
        private static string equipfilename = currentDirectory + "\\textRes\\equip.csv";
        private static string gunfilename = currentDirectory + "\\textRes\\gun.csv";
        private static string squadtypename = currentDirectory + "\\textRes\\squad_type.csv";
        private static string squadname = currentDirectory + "\\textRes\\squad.csv";
        private static Dictionary<int, ConfigNode> csvdata = new Dictionary<int, ConfigNode>();



        static public bool Read_ALL_CSV()
        {
            csvdata.Clear();
            try
            {
                ReadCsv(operationfileName, ref csvdata);
                ReadCsv(prizefilename, ref csvdata);
                ReadCsv(dailyfilename, ref csvdata);
                ReadCsv(achievementfilename, ref csvdata);
                ReadCsv(weeklyfilename, ref csvdata);
                ReadCsv(equipfilename, ref csvdata);
                ReadCsv(gunfilename, ref csvdata);
                ReadCsv(squadtypename, ref csvdata);
                ReadCsv(squadname, ref csvdata);
            }
            catch (Exception e)
            {
                new Log().systemInit("读取 csv 出错", e.ToString()).coreError();
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
                int linenum = csvdata.Count;
                foreach (string line in con)
                {
 
                    if (String.IsNullOrEmpty(line) || line[0] == '#') continue;//注释
                    string[] c = line.Split(',');
                    tempdictionary.Add(linenum, new ConfigNode(c[0].Trim(), c[1].Trim().ToLower()));
                    linenum++;
                }
                return true;
            }
            catch (Exception e)
            {
                new Log().systemInit(string.Format("读取 {0} 出错", filename.ToString()), e.ToString()).coreError();
                return false;
            }
        }

        public static string ChangeCodeFromeCSV(string res)
        {
            foreach (var item in csvdata)
            {
                if (res == item.Value.key)
                {
                    return Unicode2String(item.Value.value);
                }
            }

            return res;
        }

        public static string Unicode2String(string source)
        {
            return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
                         source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
        }

    }
}

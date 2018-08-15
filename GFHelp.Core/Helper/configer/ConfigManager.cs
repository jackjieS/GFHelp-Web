using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFHelp.Core.Helper.Configer
{
    public class ConfigManager
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

        public static string fileName = SystemOthers.ConfigData.currentDirectory + @"\config.cfg";
        public static string UpgradeInfoFile = SystemOthers.ConfigData.currentDirectory + @"\UpgradeInfo.txt";
        public static Dictionary<string, object> defultValue = new Dictionary<string, object>();
        public static string[] UpgradeInfo;

        private static Dictionary<int, ConfigNode> config = new Dictionary<int, ConfigNode>();
        private static int maxline = 0;

        public static bool Load()
        {
            if (String.IsNullOrEmpty(UpgradeInfoFile) || !File.Exists(UpgradeInfoFile)) return false;
            if (String.IsNullOrEmpty(fileName) || !File.Exists(fileName)) return false;
            UpgradeInfo = File.ReadAllLines(UpgradeInfoFile);
            string[] con = File.ReadAllLines(fileName);

            try
            {
                int linenum = -1;
                foreach (string line in con)
                {
                    ++linenum;
                    if (String.IsNullOrEmpty(line) || line[0] == '#') continue;//注释
                    string[] c = line.Split('=');
                    config.Add(linenum, new ConfigNode(c[0].Trim(), c[1].Trim().ToLower()));
                }

                maxline = con.Length;
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }

        public static void Save()
        {
            try
            {
                var configfile = File.ReadAllLines(fileName, Encoding.UTF8);
                string[] newconfigfile = new string[maxline];

                for (int i = 0; i < configfile.Length; ++i)
                    newconfigfile[i] = configfile[i];

                foreach (var line in config)
                {
                    newconfigfile[line.Key] = String.Format("{0}={1}", line.Value.key, line.Value.value);
                }

                File.WriteAllLines(fileName, newconfigfile, System.Text.Encoding.UTF8);
            }
            catch (Exception e)
            {

            }
        }

        private static ConfigNode findConfig(string key)
        {
            foreach (var i in config)
                if (i.Value.key == key) return i.Value;

            throw new KeyNotFoundException();
        }
        public static bool FindConfig(string key)
        {
            foreach (var i in config)
                if (i.Value.key == key) return true;
            return false;
        }
        public static void SetConfig(string key, object value)
        {
            int i = 0;
            foreach (var item in config)
            {
                if(item.Value.key == key)
                {
                    i = item.Key;
                }
            }
            ConfigNode cn = new ConfigNode();
            cn.key = key;
            cn.value = value.ToString().ToLower();
            config[i] = cn;
            Save();
        }

        private static string getConfigString(string key)
        {
            try
            {
                return findConfig(key).ToString();
            }
            catch (KeyNotFoundException)
            {
                return String.Empty;
            }
        }

        private static bool getConfigBool(string key)
        {
            try
            {
                return findConfig(key).ToString() == "true";
            }
            catch (KeyNotFoundException)
            {
                SetConfig(key, defultValue[key]);
                return defultValue[key].ToString() == "True";
            }
        }

        private static int getConfigInt(string key)
        {
            try
            {
                return Convert.ToInt32(findConfig(key).ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static bool getConfig()
        {
            try
            {
                if (!Load())
                {
                    Console.WriteLine("配置文件加载失败!");
                }
                SystemOthers.ConfigData.DataVersion = getConfigString("catchdata").ToLower();
                SystemOthers.ConfigData.LogID = getConfigInt("LogID");

            }
            catch (Exception e)
            {
                Console.WriteLine("配置读取失败！错误原因: " + e.ToString());
                return false;
            }


            return true;
        }


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFHelp.Core.Helper.Configer
{
    public class HostAddress
    {

        private static string fileName = SystemManager.ConfigData.currentDirectory + @"\HostAddress.cfg";

        private static List<Data> Address = new List<Data>();
        private class Data
        {
            public Data(string HostName, string HostAddress)
            {
                this.HostName = HostName;
                this.HostAddress = HostAddress;
            }
            public string HostName;
            public string HostAddress;
        }




        public static bool Load()
        {
            if (String.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                new Log().systemInit("HostAddress.cfg 不存在").coreInfo();
            }
            Address.Clear();
            string[] con = File.ReadAllLines(fileName);
            try
            {

                foreach (string line in con)
                {

                    if (String.IsNullOrEmpty(line) || line[0] == '#') continue;//注释
                    string line0 = line.ToLower();
                    string[] c = line0.Split(',');
                    Data data = new Data(c[0], c[1]);
                    Address.Add(data);
                }
                return true;
            }
            catch (Exception e)
            {
                new Log().systemInit("读取 HostAddress.cgf 出错",e.ToString()).coreInfo();
                return false;
            }
        }
        public static string GetAddressByName(string name)
        {
            foreach (var item in Address)
            {
                if (item.HostName == name)
                {
                    return item.HostAddress;
                }
            }
            new Log().systemInit("没有对应的HostName 无法返回HostAddress").coreInfo();
            return "http://gf-adrgw-cn-zs-game-0001.ppgame.com/index.php/1000/";
        }


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace GFHelp.NetBase
{
    public class webProxy
    {
        
        public class Data
        {
            public Data(string Host)
            {
                this.Host = Host;
                this.webProxy = new WebProxy(Host);
            }
            public string Host;
            public WebProxy webProxy;
        }

        public static List<Data> webProxies = new List<Data>();

        public static void Read()
        {
            webProxies.Clear();
            using (StreamReader sr = new StreamReader(@"C:\WebProxy.txt", Encoding.Default))
            {

                while (!sr.EndOfStream)
                {

                    string Line = sr.ReadLine();

                    if (webProxies.FindIndex(a => a.Host == Line) == -1)
                    {
                        webProxies.Add(new Data(Line));
                    }
                }
            }
            Console.WriteLine("读取账号完毕");
        }
        public static void Clear()
        {
            webProxies.Clear();
        }

















    }
}

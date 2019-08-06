using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        public static Task task;
        public static bool Using = true;



        public static void Trigger()
        {
            if(Using == true)
            {
                //关闭 清空
                Clear();

                Using = false;
                return;
            }



            if (Using == false){

                Using = true;
                return;
            }
        }



        public static void Init()
        {
            task = new Task(()=>GetWebProxies());
            //task.Start();
        }


        public static void GetWebProxies()
        {
            while (true)
            {
                if (!Using)
                {
                    Thread.Sleep(1000);
                    continue;
                }

                string result = "";
                try
                {
                    HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("http://45.32.27.25:5010/get_all/");
                    Req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; QQWubi 133; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; CIBA; InfoPath.2)";
                    Req.Method = "GET";
                    Req.Timeout = 15000;
                    HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();
                    Encoding code = Encoding.Default;
                    using (StreamReader sr = new StreamReader(Resp.GetResponseStream(), code))
                    {
                        result = sr.ReadToEnd();
                    }
                    webProxies.Clear();
                    LitJson.JsonData jsonData = LitJson.JsonMapper.ToObject(result);

                    if (Using == false) return;

                    for (int num8 = 0; num8 < jsonData.Count; num8++)
                    {
                        if (webProxies.FindIndex(a => a.Host == jsonData[num8].String) == -1)
                        {
                            webProxies.Add(new Data(jsonData[num8].String));
                        }
                    }






                    Thread.Sleep(10000);
                }
                catch (Exception)
                {
                    ;

                }
            }



        }



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

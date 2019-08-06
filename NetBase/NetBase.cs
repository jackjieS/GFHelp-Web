using GFHelp.NetBase;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace GFHelp.NetBase
{
    public class BaseRequset
    {
        public string DoPost(string url, string data)
        {
            try
            {
                WebProxy proxyObject;


                byte[] bs = Encoding.ASCII.GetBytes(data);
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                if (webProxy.webProxies.Count != 0)
                {
                    proxyObject = webProxy.webProxies[new Random().Next(webProxy.webProxies.Count)].webProxy;
                    req.Proxy = proxyObject;
                }


                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = bs.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                }
                using (WebResponse wr = req.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(wr.GetResponseStream(), Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }

                }


            }
            catch (WebException e)
            {
                return "false " + e.ToString();
            }

        }


        public static string DoPoststatic(string url, string data)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                //wc.Headers.Add("Accept-Encoding", "gzip， deflate");
                wc.Encoding = Encoding.UTF8;
                byte[] postData = wc.Encoding.GetBytes(data);
                string result = Encoding.UTF8.GetString(wc.UploadData(url, "POST", postData));
                return result;
            }
            catch (WebException e)
            {
                return "false " + e.ToString();
            }
        }
        public string DoPost(string url, byte[] postData)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                wc.Encoding = Encoding.UTF8;
                string result = Encoding.UTF8.GetString(wc.UploadData(url, "POST", postData));
                return result;
            }
            catch (WebException e)
            {
                return "false " + e.ToString();
            }
        }





    }
}

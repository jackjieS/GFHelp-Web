using GFHelp.NetBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace GFHelp.NetBase
{
    public class BaseRequset
    {
        public DateTime DateTime = DateTime.Now;

        public string DoPost(string url, string data)
        {
            var result = doPost(url, data);
            return result;

        }

        public string DoPost(string url, byte[] postData)
        {

            return doPost(url, postData);

        }


        private string doPost(string url, string data)
        {

            Start: WebProxy proxyObject;
            byte[] bs = Encoding.ASCII.GetBytes(data);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            req.ContinueTimeout = 20000;
            req.Timeout = 20000;
            req.ReadWriteTimeout = 20000;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }

            if (webProxy.webProxies.Count != 0)
            {
                if (url.Contains("getDigitalSkyNbUid"))
                {
                    proxyObject = webProxy.webProxies[new Random().Next(webProxy.webProxies.Count)].webProxy;
                    req.Proxy = proxyObject;
                }
            }
            try
            {
                return new StreamReader(req.GetResponse().GetResponseStream(), Encoding.UTF8).ReadToEnd();

            }
            catch (Exception e)
            {
                if(e.ToString().ToLower().Contains("the operation has timed out."))
                {
                    goto Start;
                }
                throw e;
            }
        }

        private string doPost(string url, byte[] postData)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            WebProxy proxyObject;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = postData.Length;
            req.ContinueTimeout = 20000;
            req.Timeout = 20000;
            req.ReadWriteTimeout = 20000;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(postData, 0, postData.Length);
            }

            if (webProxy.webProxies.Count != 0)
            {
                proxyObject = webProxy.webProxies[new Random().Next(webProxy.webProxies.Count)].webProxy;
                req.Proxy = proxyObject;
            }
            try
            {
                return new StreamReader(req.GetResponse().GetResponseStream(), Encoding.UTF8).ReadToEnd();
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public string DoPost(string url, IDictionary<string, string> postData)
        {
            return DoPost(url, StringBuilder(postData));
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




        public static string StringBuilder(IDictionary<string, string> parameters)
        {
            StringBuilder buffer = new StringBuilder();
            if (!(parameters == null || parameters.Count == 0))
            {
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
            }
            return buffer.ToString();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest.Login
{
    class NetBase
    {
        public static string StringBuilder_(IDictionary<string, string> parameters)
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
        public static string DoPost(string url, string data)
        {
            try
            {
                WebClient wc = new WebClient();
                //wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                wc.Headers.Add("User-Agent", "Mozilla/5.0 BSGameSDK");
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                ServicePointManager.Expect100Continue = false;
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

        public static string DoPost(string url, byte[] postData)
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

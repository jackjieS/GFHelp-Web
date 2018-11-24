using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
                    string keyA = HttpUtility.UrlEncode(key);
                    string keyB = HttpUtility.UrlEncode(parameters[key]);
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", keyA, keyB);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", keyA, keyB);
                    }
                    i++;
                }
            }
            return buffer.ToString();
        }
        public static string HttpPost(string url,string postData)
        {

            byte[] postBytes = Encoding.ASCII.GetBytes(postData);     //将参数转化为assic码
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = postBytes.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(postBytes, 0, postBytes.Length);
            }
            using (WebResponse wr = req.GetResponse())
            {
                StreamReader sr = new StreamReader(wr.GetResponseStream());
                return sr.ReadToEnd();
            }

        }


    }
}

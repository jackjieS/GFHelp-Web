
using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GFHelp.Core.API
{
    class BaseRequset
    {
        public static string DoPost(string url, string data)
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

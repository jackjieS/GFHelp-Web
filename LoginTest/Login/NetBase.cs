using FSLib.Network.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GFLogin
{
    class NetBase
    {
        public static string HttpPost(string url, IDictionary<string, string> postData)
        {
            var client = new HttpClient();
            var ctx = client.Create<string>(HttpMethod.Post, url, data: postData);
            ctx.SetRequestContentType(ContentType.FormUrlEncoded);
            ctx.Send();
            if (ctx.IsValid())
            {
                return ctx.Result;
            }
            else
            {
                return "错误！状态码：" + ctx.Response.Status;
            }
        }
        public static string HttpPost(string url, byte[] postData)
        {
            var client = new HttpClient();
            var ctx = client.Create<string>(HttpMethod.Post, url, data: postData);
            ctx.SetRequestContentType(ContentType.FormUrlEncoded);
            ctx.Send();
            if (ctx.IsValid())
            {
                return ctx.Result;
            }
            else
            {
                return "错误！状态码：" + ctx.Response.Status;
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GFHelp.Core.Helper;

namespace GFHelp.Core.API
{
    public class Login
    {

        public static string Digitalsky(Management.GameAccount gameAccount)
        {
            string login_pwd = md5.EncryptWithMD5(gameAccount.Base.Password);
            string login_identify = gameAccount.Base.Accountid;

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter data = new JsonTextWriter(sw);
            data.WriteStartObject();
            data.WritePropertyName("login_pwd");
            data.WriteValue(login_pwd);
            data.WritePropertyName("app_id");
            data.WriteValue("0002000100021001");
            data.WritePropertyName("encrypt_mode");
            data.WriteValue("md5");
            data.WritePropertyName("login_identify");
            data.WriteValue(login_identify);
            data.WriteEndObject();
            return createUserCenterHttpRequest(sb.ToString());

        }
        public static byte[] packageRequestData(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter head = new JsonTextWriter(sw);

            head.WriteStartObject();
            head.WritePropertyName("app_id");
            head.WriteValue("0002000100021001");
            head.WritePropertyName("version");
            head.WriteValue("1.0");
            head.WriteEndObject();



            List<Byte> listbyte = new List<Byte>();  // 复制目的

            // 迭代 bytes 数组中的内容后添加到 lbyte 中

            foreach (byte b in Encoding.Default.GetBytes(sb.ToString()))
            {
                listbyte.Add(b);
            }
            listbyte.Add(0x0);
            foreach (var b in data)
            {
                listbyte.Add(b);
            }

            return listbyte.ToArray();
        }

        public static string createUserCenterHttpRequest(string data)
        {
            byte[] strEncrypt = XXTea.Encrypt(data);
            byte[] body = packageRequestData(strEncrypt);
            return BaseRequset.DoPost("http://gf.ucenter.ppgame.com/normal_login", body);
        }


    }
}

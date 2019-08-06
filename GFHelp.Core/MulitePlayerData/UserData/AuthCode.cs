using GFHelp.Core.Helper;
using GFHelp.Core.Management;
using ICSharpCode.SharpZipLib.GZip;
using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GFHelp.Core.MulitePlayerData
{
    public class AuthCode
    {
        public AuthCode(UserData userData)
        {
            this.userData = userData;
        }
        //public Assembly assembly = null;
        //Type type = null;
        //dynamic instance = null;
        static object locker = new object();
        private UserData userData;
        public int IntDelegate()
        {
            return Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds - userData.GameAccount.realtimeSinceLogin + userData.GameAccount.loginTime);

        }

        public void init()
        {

            //if (assembly == null)
            //{
            //    assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "AuthCode.dll");
            //    type = assembly.GetType("AC.AuthCode");
            //    instance = assembly.CreateInstance("AC.AuthCode"); // 创建类的实例 
            //}
        }
        public void Init()
        {
            AC.AuthCode.Init(new AC.AuthCode.IntDelegate(userData.GameAccount.GetCurrentTimeStamp));
        }
        public byte[] DecodeWithGzip(string source,string key)
        {
            //Type[] params_type = new Type[2];
            //params_type[0] = Type.GetType("System.String");
            //params_type[1] = Type.GetType("System.String");
            //Object[] params_obj = new Object[1];
            //params_obj[0] = source;
            //params_obj[1] = key;
            //return type.GetMethod("DecodeWithGzip", params_type).Invoke(instance, params_obj);



            byte[] result;
            lock (locker)
            {
                Init();
                result = AC.AuthCode.DecodeWithGzip(source, key);
            }
            return result;






        }




        public string Decode(string source, string key)
        {
            //Type[] params_type = new Type[2];
            //params_type[0] = Type.GetType("System.String");
            //params_type[1] = Type.GetType("System.String");

            //Object[] params_obj = new Object[2];
            //params_obj[0] = source;
            ////params_obj[1] = key;
            //return type.GetMethod("Decode", params_type).Invoke(instance, params_obj);
            string result;
            lock (locker)
            {
                Init();
                result = AC.AuthCode.Decode(source, key);
            }
            return result;
        }

        public string Encode(string source, string key)
        {
            string result;
            lock (locker)
            {
                Init();
                result = AC.AuthCode.Encode(source, key);
            }
            return result;
        }





        public string DecodeAndMapJson(string wwwText)
        {
            JsonData result = new JsonData();
            try
            {
                if (wwwText.StartsWith("#"))
                {
                    using (MemoryStream memoryStream = new MemoryStream(DecodeWithGzip(wwwText.Substring(1), userData.GameAccount.sign)))
                    {
                        using (Stream stream = new GZipInputStream(memoryStream))
                        {
                            using (StreamReader streamReader = new StreamReader(stream, Encoding.Default))
                            {
                                result = JsonMapper.ToObject(streamReader);
                                return result.ToJson();
                            }
                        }
                    }
                }
                string text2 = Decode(wwwText, userData.GameAccount.sign);

                result = JsonMapper.ToObject(text2);
            }
            catch (Exception e)
            {
                new Log().systemInit("DecodeAndMapJson", e.ToString()).coreError();

            }
            return result.ToJson();
        }

        //public void DecodeSign(string result)
        //{
        //    JsonData jsonData2 = null;
        //    userData.GameAccount.realtimeSinceLogin = Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);

        //    Init(new AuthCode.IntDelegate(userData.GameAccount.GetCurrentTimeStamp));

        //    userData.GameAccount.loginTime = Decrypt.ConvertDateTime_China_Int(DateTime.Now);
        //    try
        //    {
        //        using (MemoryStream stream = new MemoryStream(DecodeWithGzip(result.Substring(1), "yundoudou")))
        //        {
        //            using (Stream stream2 = new GZipInputStream(stream))
        //            {
        //                using (StreamReader streamReader = new StreamReader(stream2, Encoding.Default))
        //                {
        //                    jsonData2 = JsonMapper.ToObject(streamReader);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //向網頁傳輸數據一個錯誤窗口之類的
        //        throw;
        //    }
        //    userData.GameAccount.uid = jsonData2["uid"].String;
        //    userData.GameAccount.sign = jsonData2["sign"].String;
        //}









    }

}

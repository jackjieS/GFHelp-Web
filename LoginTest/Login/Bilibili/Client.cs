using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest.Login.Bilibili
{
    class Client
    {
        public Client()
        {
            this.platfromInfo = new Platfrom();
            this.rsaRespone = new RsaRespone();
        }

        public string Login()
        {

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string[] stringArray = new string[] { "app_id", "c", "channel_id", "domain", "domain_switch_count", "dp", "game_id", "isRoot", "merchant_id", "model", "net", "operators", "pf_ver", "platform_type", "sdk_log_type", "sdk_type", "sdk_ver", "server_id", "support_abis", "timestamp", "udid", "ver", "version" };
            platfromInfo.setSign(stringArray);
            foreach (var item in platfromInfo.getPlatfromInfoDic(stringArray))
            {
                parameters.Add(item.Key, item.Value);
            }
            parameters.Add("sign", platfromInfo.sign);

            string data = NetBase.StringBuilder_(parameters);

            string result = NetBase.HttpPost(platfromInfo.RSAURL, data.ToString());




            JsonData jsonData = JsonMapper.ToObject(result);

            if (jsonData["code"].Int == 0)
            {
                this.rsaRespone = new RsaRespone(jsonData);
            }

            platfromInfo.dicInfos["pwd"] = CryptData.Rsa(jsonData["rsa_key"].String, jsonData["hash"].String + platfromInfo.dicInfos["pwdPlain"]);



            stringArray = new string[] { "app_id","c", "channel_id", "domain", "domain_switch_count", "dp", "game_id", "isRoot", "merchant_id", "model", "net", "operators", "pf_ver", "platform_type", "pwd","sdk_log_type", "sdk_type", "sdk_ver", "server_id", "support_abis", "timestamp", "udid","uid","user_id", "ver", "version" };
            platfromInfo.setSign(stringArray);
            parameters = new Dictionary<string, string>();
            foreach (var item in platfromInfo.getPlatfromInfoDic(stringArray))
            {
                parameters.Add(item.Key, item.Value);
            }

            parameters.Add("sign", platfromInfo.sign);

            data = NetBase.StringBuilder_(parameters);

            return NetBase.HttpPost(platfromInfo.LoginURL, data.ToString());



            //return jsonData.ToString();
        }

        public Platfrom platfromInfo;
        public RsaRespone rsaRespone;
        public class Platfrom
        {
            public Platfrom()
            {
                Randam();
            }

            public Dictionary<string, string> dicInfos = new Dictionary<string, string>()
            {
                {"user_id","13925924243" },
                {"pwdPlain","20151203" },
                {"pwd","" },
                {"app_id","159" },
                {"c","0" },
                {"channel_id","1" },
                {"domain","line1-sdkcenter-login.bilibiligame.net" },
                {"domain_switch_count","0" },
                {"dp","919*517" },
                {"game_id","159" },
                {"isRoot","1" },
                {"merchant_id","49" },
                {"model","SM-G955N" },
                {"net","4" },
                {"operators","5" },
                {"pf_ver","5.1.1" },
                {"platform_type","3" },
                {"sdk_log_type","1" },
                {"sdk_type","1" },
                {"sdk_ver","1.8.2" },
                {"server_id","345" },
                {"support_abis","x86,armeabi-v7a,armeabi" },
                {"timestamp",timestamp },
                {"udid","Gysaf00sGCkceBt6BjQGNAY/W2JbYlprD3MPPVxoWWwIawo/Dj8OPg4/Wg==" },
                {"ver","2.0221_339" },
                {"version","1" },
                {"original_domain","" },
                {"uid","28557410" },
                { "access_key",""},
            };
            public static string timestamp { get { return CryptData.ConvertDateTime_China_Int(DateTime.Now).ToString(); } }
            public string sign;
            public string key = "d63617abcda1445daeb4546a037ef0d4";
            public string RSAURL = "http://line1-sdkcenter-login.bilibiligame.net/api/client/rsa";
            public string LoginURL = "http://line1-sdkcenter-login.bilibiligame.net/api/client/login";

            public Dictionary<string,string> getPlatfromInfoDic(string[] names)
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                foreach (var item in names)
                {
                    if (string.IsNullOrEmpty(item) || !dicInfos.ContainsKey(item))
                        continue;
                    data.Add(item, dicInfos[item]);
                }
                return data;
            }


            private void Randam()
            {
                //Random random = new Random();
                //dicInfos["dp"] = string.Format(random.Next(1000, 2000).ToString() + "*" + random.Next(1000, 2000).ToString());
                //dicInfos["udid"] = Guid.NewGuid().ToString("N");
            }
            public void setSign(string[] names)
            {
                string data = "";
                foreach (var item in names)
                {
                    data += dicInfos[item];
                }
                data += key;
                sign = CryptData.MD5Encrypt(data);
            }




        }



        public class RsaRespone
        {
            public RsaRespone()
            {
            }
            public RsaRespone(JsonData jsonData)
            {
                this.code = jsonData["code"].Int;
                this.hash = jsonData["hash"].String;
                this.requestId = jsonData["requestId"].String;
                this.rsa_key = jsonData["rsa_key"].String;
                this.server_message = jsonData["server_message"].String;
                this.timestamp = jsonData["timestamp"].String;
            }
            public int code;
            public string hash;
            public string requestId;
            public string rsa_key;
            public string server_message;
            public string timestamp;
        }


    }
}

using LitJson;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GFLogin
{
    public class LoginManager
    {
        public LoginManager()
        {

        }

        public LoginManager setAccountID(string id)
        {
            this.AccountID = id;
            return this;
        }
        public LoginManager setPWD(string pwd)
        {
            this.PWD = pwd;
            return this;
        }
        public LoginManager setChannelID(string id)
        {
            this.ChannelID = id;
            return this;
        }

        public LoginManager Login()
        {

            switch (ChannelID.ToLower())
            {
                case "gwpz":
                    {
                        SkyLoginManager skyLogin = new SkyLoginManager().setAccountID(AccountID).setPWD(PWD).setChannelId(ChannelID);
                        skyLogin.Login();
                        isSuccessLogin = skyLogin.data.isSuccessLogin;
                        EncryptResult = skyLogin.data.EncryptResult;
                        break;
                    }
                case "ios":
                    {
                        SkyLoginManager skyLogin = new SkyLoginManager().setAccountID(AccountID).setPWD(PWD).setChannelId(ChannelID);
                        skyLogin.Login();
                        isSuccessLogin = skyLogin.data.isSuccessLogin;
                        EncryptResult = skyLogin.data.EncryptResult;
                        break;
                    }
                case "bili":
                    {
                        BiliLoginManager skyLogin = new BiliLoginManager().setAccountID(AccountID).setPWD(PWD).setChannelId(ChannelID);
                        skyLogin.Login();
                        isSuccessLogin = skyLogin.data.isSuccessLogin;
                        EncryptResult = skyLogin.data.EncryptResult;
                        break;
                    }
                default:
                    break;
            }
            return this;



        }

        string AccountID;
        string PWD;
        string ChannelID;
        public bool isSuccessLogin = false;
        public string EncryptResult;
    }


    class BiliLoginManager : SignManager
    {
        public BiliLoginManager()
        {
            Randam();
        }

        public BiliData Bilidata = new BiliData();
        public DisitalSkyData disitalSkyData = new DisitalSkyData();
        public GFHelp.NetBase.BaseRequset netBase = new GFHelp.NetBase.BaseRequset();
        public class BiliData
        {
            public BiliData(string user_id, string pwdPlain)
            {
                this.dicInfos["user_id"] = user_id;
                this.dicInfos["pwdPlain"] = pwdPlain;
            }
            public BiliData()
            {

            }
            public static string timestamp { get { return CryptData.ConvertDateTime_China_Int(DateTime.Now).ToString(); } }
            public string sign;
            public string key = "d63617abcda1445daeb4546a037ef0d4";
            public string RSAURL = "http://line1-sdkcenter-login.bilibiligame.net/api/client/rsa";
            public string LoginURL = "http://line1-sdkcenter-login.bilibiligame.net/api/client/login";
            public String DigitalSkyLoginURL = "http://l.ucenter.ppgame.com/third_login_2";
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
                {"sdk_ver","2.2.1" },
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

        }

        public class DisitalSkyData
        {
            public DisitalSkyData(JsonData jsonData)
            {
                this.access_token = jsonData["access_token"].String;
                this.uid = jsonData["uid"].String;
                this.authorization_code = jsonData["verify_json_data"]["authorization_code"].String;
                this.expiration = jsonData["verify_json_data"]["expiration"].String;
                this.openid = jsonData["openid"].String;
            }
            public DisitalSkyData()
            {

            }
            public string access_token;
            public string uid;
            public string authorization_code;
            public string expiration;
            public string openid;
            public string channelID = "Bili";
            public string Host = "http://gf-adrbili-cn-zs-game-0001.ppgame.com";
            public string GetDigitalUidURL = "/index.php/5000/Index/getDigitalSkyNbUid";

        }

        public Dictionary<string, string> getPlatfromInfoDic(string[] names)
        {
            setSign(names);

            Dictionary<string, string> dic_data = new Dictionary<string, string>();
            foreach (var item in names)
            {
                if (string.IsNullOrEmpty(item) || !this.Bilidata.dicInfos.ContainsKey(item))
                    continue;
                dic_data.Add(item, this.Bilidata.dicInfos[item]);
            }

            dic_data.Add("sign", this.Bilidata.sign);

            return dic_data;
        }

        public BiliLoginManager setAccountID(string accountID)
        {
            this.Bilidata.dicInfos["user_id"] = accountID;
            return this;
        }
        public BiliLoginManager setPWD(string PWD)
        {
            this.Bilidata.dicInfos["pwdPlain"] = PWD;
            return this;
        }
        public BiliLoginManager setChannelId(string id)
        {
            data.channelid = id;
            data.dicInfos["channelid"] = data.channelid;
            return this;
        }
        private void Randam()
        {
            Random random = new Random();
            this.Bilidata.dicInfos["dp"] = string.Format(random.Next(1000, 2000).ToString() + "*" + random.Next(1000, 2000).ToString());
            this.Bilidata.dicInfos["udid"] = Guid.NewGuid().ToString("N");
        }
        private void setSign(string[] names)
        {
            string data = "";
            foreach (var item in names)
            {
                data += this.Bilidata.dicInfos[item];
            }
            data += this.Bilidata.key;
            this.Bilidata.sign = CryptData.MD5Encrypt(data);
        }

        public void Login()
        {
            GetBiliPublicKey();
            LoginBilibili();
            DigitalSkyLogin();
            setAccessToken(disitalSkyData.access_token).setOpenID(disitalSkyData.openid);
            GetDigitaluid();
        }

        private bool GetBiliPublicKey()
        {

            string[] stringArray = new string[] { "app_id", "c", "channel_id", "domain", "domain_switch_count", "dp", "game_id", "isRoot", "merchant_id", "model", "net", "operators", "pf_ver", "platform_type", "sdk_log_type", "sdk_type", "sdk_ver", "server_id", "support_abis", "timestamp", "udid", "ver", "version" };
            string result = netBase.DoPost(this.Bilidata.RSAURL, getPlatfromInfoDic(stringArray));

            JsonData jsonData = JsonMapper.ToObject(result);

            if (jsonData["code"].Int == 0)
            {
                this.Bilidata.dicInfos["pwd"] = CryptData.Rsa(jsonData["rsa_key"].String, jsonData["hash"].String + this.Bilidata.dicInfos["pwdPlain"]);
            }
            else
            {
                return false;
            }
            return true;


        }
        private void LoginBilibili()
        {
            string[] stringArray = new string[] { "app_id", "c", "channel_id", "domain", "domain_switch_count", "dp", "game_id", "isRoot", "merchant_id", "model", "net", "operators", "pf_ver", "platform_type", "pwd", "sdk_log_type", "sdk_type", "sdk_ver", "server_id", "support_abis", "timestamp", "udid", "uid", "user_id", "ver", "version" };
            string result = netBase.DoPost(this.Bilidata.LoginURL, this.getPlatfromInfoDic(stringArray));
            JsonData jsonData = JsonMapper.ToObject(result);
            if (jsonData["code"].Int != 0)
            {
                throw new Exception();
            }
            this.Bilidata.dicInfos["access_key"] = jsonData["access_key"].String;
            this.Bilidata.dicInfos["uid"] = jsonData["uid"].String;
        }


        private void DigitalSkyLogin()
        {
            string result = netBase.DoPost(this.Bilidata.DigitalSkyLoginURL, packageRequestData(XXTea.Encrypt(XXTEAPackage())));
            JsonData jsonData = JsonMapper.ToObject(result);
            this.disitalSkyData = new DisitalSkyData(jsonData);


        }

        private string XXTEAPackage()
        {
            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();

            jsonWriter.WritePropertyName("app_id");
            jsonWriter.Write("0002000100021001");
            jsonWriter.WritePropertyName("platform_type");
            jsonWriter.Write(10047);

            jsonWriter.WritePropertyName("verify_json_data");
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("app_id");
            jsonWriter.Write("0002000100021001");
            jsonWriter.WritePropertyName("platform_type");
            jsonWriter.Write(10047);
            jsonWriter.WritePropertyName("uid");
            jsonWriter.Write(Bilidata.dicInfos["uid"]);
            jsonWriter.WritePropertyName("name");
            jsonWriter.Write("");
            jsonWriter.WritePropertyName("token");
            jsonWriter.Write(Bilidata.dicInfos["access_key"]);
            jsonWriter.WritePropertyName("expiration");
            jsonWriter.Write(CryptData.ConvertDateTime_China_LONG(DateTime.Now.AddDays(20)).ToString());
            jsonWriter.WritePropertyName("authorization_code");
            jsonWriter.Write(Bilidata.dicInfos["access_key"]);
            jsonWriter.WritePropertyName("session_id");
            jsonWriter.Write("");
            jsonWriter.WriteObjectEnd();
            jsonWriter.WriteObjectEnd();

            return stringBuilder.ToString();

        }


        private static byte[] packageRequestData(byte[] data)
        {

            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("app_id");
            jsonWriter.Write("0002000100021001");
            jsonWriter.WritePropertyName("version");
            jsonWriter.Write("1.0");
            jsonWriter.WriteObjectEnd();

            List<Byte> listbyte = new List<Byte>();  // 复制目的

            // 迭代 bytes 数组中的内容后添加到 lbyte 中

            foreach (byte b in Encoding.Default.GetBytes(stringBuilder.ToString()))
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
    }




    class SkyLoginManager : SignManager
    {

        public SkyLoginManager()
        {
            digitalData = new DigitalSkyData();
        }
        public SkyLoginManager(string id, string pwd)
        {
            digitalData = new DigitalSkyData();
            this.digitalData.User_ID = id;
            this.digitalData.pwd_plan = pwd;

        }
        public SkyLoginManager setAccountID(string id)
        {
            this.digitalData.User_ID = id;
            return this;
        }
        public SkyLoginManager setPWD(string pwd)
        {
            this.digitalData.pwd_plan = pwd;
            return this;
        }
        public SkyLoginManager setYunDouDou(string yundoudou)
        {
            this.digitalData.YunDouDou = yundoudou;
            return this;
        }
        public SkyLoginManager setChannelId(string id)
        {
            data.channelid = id;
            data.dicInfos["channelid"] = data.channelid;
            return this;
        }

        public class DigitalSkyData
        {
            public DigitalSkyData()
            {

            }
            public void setAccessToken(JsonData jsonData)
            {
                this.access_token = jsonData["access_token"].String;
                this.openid = jsonData["openid"].String;
            }
            internal string User_ID;
            internal string pwd_plan;
            internal string pwd { get { return CryptData.MD5Encrypt(pwd_plan); } }
            internal string YunDouDou;


            internal string DigitalSkyLoginURL = "http://gf.ucenter.ppgame.com/normal_login";

            internal string access_token;
            internal string openid;


        }

        public void Login()
        {
            DigitalSkyLogin();
        }
        private void DigitalSkyLogin()
        {
            string result="";
            while (true)
            {
                try
                {
                    result = netBase.DoPost(digitalData.DigitalSkyLoginURL, packageRequestData(XXTea.Encrypt(XXTEAPackage())));
                }
                catch (Exception)
                {
                    if (result.Contains("not match"))
                    {
                        throw new Exception("id pw not match");
                    }
                    continue;
                }
                finally
                {
                    if(result.Contains("error"))
                        throw new Exception("id pw not match");
                }
                break;
            }








            digitalData.setAccessToken(JsonMapper.ToObject(result));
            setAccessToken(digitalData.access_token).setOpenID(digitalData.openid);
            GetDigitaluid();
        }




        private string XXTEAPackage()
        {
            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("login_pwd");
            jsonWriter.Write(digitalData.pwd);
            jsonWriter.WritePropertyName("app_id");
            jsonWriter.Write("0002000100021001");
            jsonWriter.WritePropertyName("encrypt_mode");
            jsonWriter.Write("md5");
            jsonWriter.WritePropertyName("login_identify");
            jsonWriter.Write(digitalData.User_ID);
            jsonWriter.WriteObjectEnd();
            return stringBuilder.ToString();
        }
        private static byte[] packageRequestData(byte[] data)
        {

            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("app_id");
            jsonWriter.Write("0002000100021001");
            jsonWriter.WritePropertyName("version");
            jsonWriter.Write("1.0");
            jsonWriter.WriteObjectEnd();

            List<Byte> listbyte = new List<Byte>();  // 复制目的

            foreach (byte b in Encoding.Default.GetBytes(stringBuilder.ToString()))
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

        internal DigitalSkyData digitalData;

    }

    class SignManager
    {
        public GFHelp.NetBase.BaseRequset netBase = new GFHelp.NetBase.BaseRequset();
        public SignManager()
        {
            this.data.dicInfos["mac"] = Helper.GetNewMac();
            this.data.dicInfos["androidid"] = Guid.NewGuid().ToString("N");
        }

        public SignManager setAccessToken(string t)
        {
            data.access_token = t;
            this.data.dicInfos["access_token"] = data.access_token;
            return this;
        }
        public SignManager setOpenID(string id)
        {
            data.openid = id;
            this.data.dicInfos["openid"] = data.openid;
            return this;
        }


        public class Data
        {
            public Data()
            {

            }
            internal string Host
            {
                get
                {
                    switch (channelid)
                    {
                        case "gwpz":return "http://gf-adrgw-cn-zs-game-0001.ppgame.com/";
                        case "ios":return "http://gf-ios-cn-zs-game-0001.ppgame.com/";
                        case "bili":return "http://gf-adrbili-cn-zs-game-0001.ppgame.com/";
                        default:
                        return "http://gf-adrgw-cn-zs-game-0001.ppgame.com/"; 
                    }
                }
            }

            internal string UIDAPI
            {
                get
                {
                    switch (channelid)
                    {
                        case "gwpz": return "index.php/1000/Index/getDigitalSkyNbUid";
                        case "ios": return "index.php/3000/Index/getDigitalSkyNbUid";
                        case "bili": return "index.php/5000/Index/getDigitalSkyNbUid";
                        default:
                            return "index.php/1000/Index/getDigitalSkyNbUid";
                    }
                }
            }
            public string openid;
            public string access_token;
            public string channelid;
            public bool isSuccessLogin = false;
            public string EncryptResult = "";
            internal Dictionary<string, string> dicInfos = new Dictionary<string, string>()
            {
                {"YunDouDou","" },
                {"access_token","" },
                {"openid","" },
                {"app_id","0002000100021001" },
                {"channelid","0" },
                {"idfa","" },
                {"androidid","" },
                {"mac","" },
                {"req_id","" }
            };



        }
        public string GetDigitaluid()
        {
            return getDigitalUid();
        }

        private string getDigitalUid()
        {
            data.dicInfos["req_id"] = CryptData.ConvertDateTime_China_Int(DateTime.Now).ToString();
            string[] stringArray = new string[] { "openid", "access_token", "app_id", "channelid", "idfa", "androidid", "mac", "req_id" };
            string result = "";
            while (true)
            {
                try
                {
                    result = netBase.DoPost(data.Host + data.UIDAPI, getPlatfromInfoDic(stringArray));
                }
                catch (Exception e)
                {

                    continue;
                }
                if (result.Contains("u767b") && result.Contains("u8d25") && result.Contains("u8bc1"))
                {
                    throw new System.Exception();
                }
                if (result.StartsWith("#"))
                {
                    data.EncryptResult = result;
                    data.isSuccessLogin = true;
                    return result;
                }
                
            }
        }
        private Dictionary<string, string> getPlatfromInfoDic(string[] names)
        {
            Dictionary<string, string> dic_data = new Dictionary<string, string>();
            foreach (var item in names)
            {
                if (string.IsNullOrEmpty(item) || !this.data.dicInfos.ContainsKey(item))
                    continue;
                dic_data.Add(item, this.data.dicInfos[item]);
            }

            return dic_data;
        }

        public Data data = new Data();
    }


}


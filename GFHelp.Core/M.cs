using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GFHelp.Core
{
    public class M
    {
        public class AccountInfo
        {
            public AccountInfo(string id,string pw)
            {
                this.ID = id;
                this.PW = pw;
            }
            public AccountInfo(string id, string pw,int gem)
            {
                this.ID = id;
                this.PW = pw;
                this.Gem = gem;
            }
            public AccountInfo()
            {

            }
            public AccountInfo setID(string id)
            {

                this.ID = id.Remove(0, 3);
                return this;
            }
            public AccountInfo setPW(string pw)
            {

                this.PW = pw.Remove(0, 3);
                return this;
            }
            public AccountInfo setGem(string gem)
            {
                this.Gem = int.Parse(gem.Remove(0, 4));
                return this;
            }


            public string ID;
            public string PW;
            public int Gem;
        }

        public static void SetGem(string id,int gem)
        {
            for(int i=0;i< MaccountInfosInput.Count; i++)
            {

                if (MaccountInfosInput[i].ID == id)
                {
                    Console.WriteLine("GEM = {0} {1}/{2}",gem, i, MaccountInfosInput.Count);
                    MaccountInfosInput[i].Gem = gem;
                }
            }

        }
        static object  locker = new object();
        public static List<AccountInfo> MaccountInfosInput = new List<AccountInfo>();
        public static List<AccountInfo> MaccountInfoOutput = new List<AccountInfo>();
        public static void Read( )
        {
            using (StreamReader sr = new StreamReader(@"C:\MaccountInfo.txt", Encoding.Default))
            {

                while (!sr.EndOfStream)
                {
                    string Line = sr.ReadLine();

                    string[] k = Line.Split(',');
                    AccountInfo account = new AccountInfo()
                        .setID(k[0])
                        .setPW(k[1])
                        .setGem(k[2]);

                    if (MaccountInfosInput.FindIndex(a => a.ID == account.ID)==-1)
                    {
                        MaccountInfosInput.Add(account);
                    }
                }
            }
            Console.WriteLine("读取账号完毕");
        }

        public static void Delted()
        {
            try
            {
                File.Delete(@"C:\3.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void Write(AccountInfo account)
        {
            lock (locker)
            {
                using (StreamWriter sw = new StreamWriter(@"F:\3.txt", true))
                {
                    string test = string.Format("id={0},pw={1},gem={2}", account.ID, account.PW, account.Gem);
                    sw.WriteLine(test);
                    sw.Flush();
                }
            }
        }

        public static void WriteList(string PatchName)
        {
            lock (locker)
            {
                using (StreamWriter sw = new StreamWriter(@"F:\"+PatchName, true))
                {
                    foreach (var account in MaccountInfoOutput)
                    {
                        string test = string.Format("id={0},pw={1},gem={2}", account.ID, account.PW, account.Gem);
                        sw.WriteLine(test);
                        sw.Flush();
                    }
                }
            }




        }

        public static void Order()
        {
            MaccountInfosInput = MaccountInfosInput.OrderByDescending(o => o.Gem).ToList();


        }
    }
}

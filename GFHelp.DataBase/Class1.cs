using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GFHelp.DataBase
{

    public class DataBase
    {

        public DbSet<AccountInfo> AccountInfo { get; set; }
        public DbSet<GameAccount> GameAccount { get; set; }

        private static string currentDirectory = Path.GetDirectoryName((new Program()).GetType().Assembly.Location) + @"\database.db";

        public static List<GameAccount> GetGameAccounts()
        {
            string cmd = "Select * From GameAccount";
            //Select * From GameAccount
            //GameAccount
            List<GameAccount> gameAccounts = new List<GameAccount>();
            using (SqliteConnection db = new SqliteConnection("Filename=" + currentDirectory))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand(cmd, db);

                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();
                    while (query.Read())
                    {
                        List<string> data = new List<string>();
                        for (int i = 0; i < 7; i++)
                        {
                            data.Add(query.GetString(i));
                        }
                        GameAccount gameAccount = new GameAccount(data);
                        gameAccounts.Add(gameAccount);
                    }
                }
                catch (Exception e)
                {

                }

                db.Close();
            }

            return gameAccounts;

        }
        public static List<AccountInfo> GetAccountInfos()
        {

            string cmd = "Select * From AccountInfo";
            //Select * From GameAccount
            //GameAccount
            List<AccountInfo> AccountInfo = new List<AccountInfo>();
            using (SqliteConnection db = new SqliteConnection("Filename=" + currentDirectory))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand(cmd, db);

                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();
                    while (query.Read())
                    {
                        List<string> data = new List<string>();
                        for (int i = 0; i < 2; i++)
                        {
                            data.Add(query.GetString(i));
                        }
                        AccountInfo gameAccount = new AccountInfo(data);
                        AccountInfo.Add(gameAccount);
                    }
                }
                catch (Exception e)
                {

                }

                db.Close();
            }

            return AccountInfo;



        }



        public static List<GameAccount> GetGameAccountByUserName(string UserName)
        {
            //GameAccount
            List<GameAccount> gameAccounts = new List<GameAccount>();
            using (SqliteConnection db = new SqliteConnection("Filename=" + currentDirectory))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("Select * from GameAccount Where WebUsername = '" + UserName + "'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    List<string> data = new List<string>();
                    for (int i = 0; i < 7; i++)
                    {
                        data.Add(query.GetString(i));
                    }
                    GameAccount gameAccount = new GameAccount(data);
                    gameAccounts.Add(gameAccount);
                }

                db.Close();
            }

            return gameAccounts;
        }
        public static bool DelGameAccount(GameAccount gameAccount)
        {
            string cmd = "DELETE FROM GameAccount WHERE GameAccountID ='" + gameAccount.GameAccountID + "'";

            using (SqliteConnection db = new SqliteConnection("Filename=" + currentDirectory))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand(cmd, db);
                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();
                }
                catch (Exception e)
                {
                    db.Close();
                    return false;
                    
                }

                db.Close();
                return true;
            }
        }
        public static bool creatGameAccount(GameAccount gameAccount)
        {
            //INSERT INTO GameAccount (WebUsername,GameAccountID,GamePassword,ChannelID,WorldID,YunDouDou,Parm) VALUES("1","1","1","1","1","1","1");
            string cmd = "INSERT INTO GameAccount (WebUsername,GameAccountID,GamePassword,ChannelID,WorldID,YunDouDou,Parm) VALUES(" + "\"" + gameAccount.WebUsername + "\"," + "\"" + gameAccount.GameAccountID + "\"," + "\"" + gameAccount.GamePassword + "\"," + "\"" + gameAccount.ChannelID + "\"," + "\"" + gameAccount.WorldID + "\"," + "\"" + gameAccount.YunDouDou + "\"," + "\"" + gameAccount.Parm + "\")";
            using (SqliteConnection db = new SqliteConnection("Filename=" + currentDirectory))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand(cmd, db);
                try
                {
                    SqliteDataReader query = selectCommand.ExecuteReader();
                }
                catch (Exception)
                {
                    db.Close();
                    return false;
                }

                db.Close();
                return true;
            }
        }
        public static bool isUserAdmin(string username)
        {

            string cmd = "SELECT Policy from AccountInfo Where Username='" + username + "'";
            using (SqliteConnection db = new SqliteConnection("Filename=" + currentDirectory))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand(cmd, db);
                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();
                }
                catch (Exception)
                {
                    db.Close();
                    return false;
                }
                string result = query.GetString(0);
                if (result == "1") return true;
                db.Close();
                return false;
            }
        }
        public static bool isMulteAccount(string username)
        {
            string cmd = "SELECT count(*) FROM GameAccount Where WebUsername='" + username + "'";
            using (SqliteConnection db = new SqliteConnection("Filename=" + currentDirectory))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand(cmd, db);
                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();

                }
                catch (Exception)
                {
                    db.Close();
                    return false;
                }
                int result =Convert.ToInt32(query[0]);
                if (result >1) return true;
                db.Close();
                return false;
            }
        }
        public static bool isAccCreated(GameAccount gameAccount)
        {
            string GameAccountID = gameAccount.GameAccountID;

            string cmd = "SELECT count(*) FROM GameAccount Where GameAccountID='" + GameAccountID + "'";
            using (SqliteConnection db = new SqliteConnection("Filename=" + currentDirectory))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand(cmd, db);
                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();

                }
                catch (Exception)
                {
                    db.Close();
                    return false;
                }
                int result = Convert.ToInt32(query[0]);
                if (result > 0) return true;
                db.Close();
                return false;
            }
        }
        public static bool isUserNameExist(string name)
        {
            //SELECT count(*) FROM AccountInfo Where Username='admin'
            string cmd = "SELECT count(*) FROM AccountInfo Where Username='" + name + "'";
            using (SqliteConnection db = new SqliteConnection("Filename=" + currentDirectory))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand(cmd, db);
                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();

                }
                catch (Exception)
                {
                    db.Close();
                    return false;
                }
                int result = Convert.ToInt32(query[0]);
                if (result > 0) return true;
                db.Close();
                return false;
            }




        }
        public static bool CheckUser(string username, string password)
        {
            //SELECT count(*) FROM AccountInfo Where Username='admin' and Password='admin'
            string cmd = "SELECT count(*) FROM AccountInfo Where Username='" + username + "' and Password='" + password + "'";
            using (SqliteConnection db = new SqliteConnection("Filename=" + currentDirectory))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand(cmd, db);
                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();

                }
                catch (Exception)
                {
                    db.Close();
                    return false;
                }
                int result = Convert.ToInt32(query[0]);
                if (result > 0) return true;
                db.Close();
                return false;
            }


        }
        public static bool creatWebAccount(LoginModel model)
        {
            if (isUserNameExist(model.Username)) return false;
            string policy = "2";
            //INSERT INTO AccountInfo (Username,Password,Policy) VALUES("2","1","2");
            string cmd = "INSERT INTO AccountInfo (Username,Password,Policy) VALUES(\"" + model.Username + "\",\"" + model.Password + "\",\"" + policy + "\")";
            using (SqliteConnection db = new SqliteConnection("Filename=" + currentDirectory))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand(cmd, db);
                try
                {
                    SqliteDataReader query = selectCommand.ExecuteReader();
                }
                catch (Exception)
                {
                    db.Close();
                    return false;
                }

                db.Close();
                return true;
            }



        }



    }
    public class AccountInfo
    {
        public AccountInfo()
        {

        }
        public AccountInfo(List<string> data)
        {
            Username = data[0];
            Password = data[1];
            Policy = data[2];
        }
        /// <summary>
        /// 用户名
        /// </summary>
        [Key]
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public string Policy { get; set; }
    }
    public class GameAccount
    {
        public GameAccount(List<string> data)
        {
            WebUsername = data[0];
            GameAccountID = data[1];
            GamePassword = data[2];
            ChannelID = data[3];
            WorldID = data[4];
            YunDouDou = data[5];
            Parm = data[6];
        }
        public GameAccount()
        {
        }

        /// <summary>
        /// 网站用户名字
        /// </summary>
        //[Required(ErrorMessage = "Username is required.")]
        public string WebUsername { get; set; }
        /// <summary>
        /// 游戏账号
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        [Key]
        public string GameAccountID { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string GamePassword { get; set; }

        /// <summary>
        /// 渠道 官服B服腾讯服
        /// </summary>
        public string ChannelID { get; set; }

        /// <summary>
        /// 服
        /// </summary>
        public string WorldID { get; set; }

        /// <summary>
        /// 不必要 后端自动生成
        /// </summary>

        /// <summary>
        /// 
        /// </summary>
        public string YunDouDou;
        /// <summary>
        /// 
        /// </summary>
        public string Parm { get; set; }
    }
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Passsword is required.")]
        public string Password { get; set; }
    }

}

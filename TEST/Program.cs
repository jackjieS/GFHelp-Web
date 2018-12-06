using System;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {


            GFLogin.LoginManager login = new GFLogin.LoginManager().setAccountID("18674495931").setPWD("3326172336952dsq").setChannelID("bili");
            login.Login();
            Console.Read();
        }
    }
}

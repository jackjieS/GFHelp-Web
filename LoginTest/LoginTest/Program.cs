using LoginTest.Login.Bilibili;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Client BiliClient = new Client();
            BiliClient.Login();
            Console.Read();
        }
    }
}

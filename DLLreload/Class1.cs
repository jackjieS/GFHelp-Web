using System;
using System.Threading;

namespace DLLreload
{
    public class Reload
    {
        public void Test(){

            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine(DateTime.Now.ToString());
            }

        }





    }
}

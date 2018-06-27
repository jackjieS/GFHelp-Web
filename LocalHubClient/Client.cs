using GFHelp.Core.MulitePlayerData.WebData;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GFHelp.LocalChatClient
{
    public class Client
    {
        private static HubConnection connection;
        /// <summary>
        /// Key 是 Signarl 的id , value 是游戏实例accountID
        /// </summary>
        public static List<SignalRInfo> userList;
        public class SignalRInfo
        {
            public string SignalRID;
            public string SignalRName;
        }


        public static void seed()
        {
            build();
            connectStart();
            connection.InvokeAsync("Login", "LocalClient");
            Task task = new Task(() => LoopMessage());
            task.Start();
        }
        public static Dictionary<string, WebStatus> GamesStatus = new Dictionary<string, WebStatus>();
        //public static Dictionary<string, WebData> GameDetails = new Dictionary<string, WebData>();
        public static List<WebData> GameDetails = new List<WebData>();

        private async static Task LoopMessage()
        {
            //检查是否有客户端 如果没有的话就不发送了
            while (true)
            {
                Thread.Sleep(1000);
                if (userList.Count <= 1) { continue; }

                foreach (var item in userList)
                {
                    GamesStatus.Clear();
                    //GamesStatus
                    foreach (var k in Core.Management.Data.data)
                    {
                        if (item.SignalRName == k.Value.GameAccount.Base.WebUsername)
                        {
                            k.Value.webData.Get(k.Value);
                            GamesStatus.Add(k.Value.GameAccount.Base.Accountid, k.Value.webData.webStatus);
                        }
                    }
                    if (GamesStatus.Count != 0)
                    {
                        await connection.InvokeAsync("SendGamesStatus", item.SignalRID, JsonConvert.SerializeObject(GamesStatus));
                    }


                }
                foreach (var item in userList)
                {
                    //GameDetails
                    GameDetails.Clear();

                    foreach (var k in Core.Management.Data.data)
                    {
                        if (item.SignalRName == k.Value.GameAccount.Base.Accountid)
                        {
                            k.Value.webData.Get(k.Value);
                            //GameDetails.Add(k.Value.GameAccount.Base.Accountid, k.Value.webData);
                            GameDetails.Add(k.Value.webData);
                        }
                    }
                    if (GameDetails.Count != 0)
                    {
                        await connection.InvokeAsync("SendGameDetails", item.SignalRID, JsonConvert.SerializeObject(GameDetails));
                    }

                }

            }
        }

        private static void build()
        {
            userList = new List<SignalRInfo>();
            connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:7777/chathub")
            .Build();
        }
        private static void connectStart()
        {
            try
            {
                connection.StartAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async void sendButton_Click()
        {
            try
            {
                await connection.InvokeAsync("RegisterId", "jack");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //messagesList.Items.Add(ex.Message);
            }
        }



    }
}

using GFHelp.Core.Helper;
using GFHelp.Core.MulitePlayerData.WebData;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GFHelp.Core
{
    public class SignaIRClient
    {
        private static HubConnection connection;
        /// <summary>
        /// Key 是 Signarl 的id , value 是游戏实例accountID
        /// </summary>
        public static Dictionary<string,SignalRInfo> userList;
        public class SignalRInfo
        {
            public string SignalRID;
            public string SignalRName;
            public bool isAdmin=false;
        }


        public async static Task seed()
        {
            build();
            await connectStart();

            Task MessageTask = new Task(() => LoopGameMessage());
            MessageTask.Start();

        }
        public static Dictionary<string, WebStatus> GamesStatus = new Dictionary<string, WebStatus>();
        public static List<WebData> GameDetails = new List<WebData>();


        public async static Task SendSystemNotice(string ConnectionId)
        {
            if (Viewer.systemLogs.Count == 0 ) { return; }
            foreach (var user in userList)
            {
                if (!user.Value.isAdmin) continue;
                if (user.Key != ConnectionId) continue;
                foreach (var log in Viewer.systemLogs)
                {
                    await connection.InvokeAsync("SendSystemNotification", user.Value.SignalRID, JsonConvert.SerializeObject(log));
                }
            }
        }
        public async static Task SendSystemNotice(Data data)
        {
            foreach (var item in userList)
            {
                if (!item.Value.isAdmin) continue;
                await connection.InvokeAsync("SendSystemNotification", item.Value.SignalRID, JsonConvert.SerializeObject(data));
            }
        }


        public async static Task SendGameNotice(string ConnectionId)
        {
            foreach (var user in userList)
            {
                if (user.Key != ConnectionId) continue;
                if (Viewer.usersLogs.ContainsKey(user.Value.SignalRName))
                {
                    foreach (var item in Viewer.usersLogs[user.Value.SignalRName])
                    {
                        await connection.InvokeAsync("SendGameNotification", ConnectionId, JsonConvert.SerializeObject(item));
                    }
                }
            }
        }

        public async static Task SendGameNotice(string gameID,Data data)
        {
            foreach (var user in userList)
            {
                if (user.Value.SignalRName != gameID) continue;
                if (Viewer.usersLogs.ContainsKey(user.Value.SignalRName))
                {
                    await connection.InvokeAsync("SendGameNotification", user.Value.SignalRID, JsonConvert.SerializeObject(data));
                }
            }
        }








        private async static Task LoopGameMessage()
        {
            //检查是否有客户端 如果没有的话就不发送了
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    //if (userList.Count <= 1) { continue; }
                    foreach (var item in userList)
                    {
                        GamesStatus.Clear();
                        //GamesStatus
                        foreach (var k in Core.Management.Data.data)
                        {
                            if (item.Value.SignalRName == k.Value.GameAccount.Base.WebUsername)
                            {
                                k.Value.webData.Get(k.Value);
                                GamesStatus.Add(k.Value.GameAccount.Base.Accountid, k.Value.webData.webStatus);
                            }
                        }
                        if (GamesStatus.Count != 0)
                        {
                            await connection.InvokeAsync("SendGamesStatus", item.Value.SignalRID, JsonConvert.SerializeObject(GamesStatus));
                        }


                    }
                    foreach (var item in userList)
                    {
                        //GameDetails
                        GameDetails.Clear();

                        foreach (var k in Core.Management.Data.data)
                        {
                            if (item.Value.SignalRName == k.Value.GameAccount.Base.Accountid)
                            {
                                k.Value.webData.Get(k.Value);
                                GameDetails.Add(k.Value.webData);
                            }
                        }
                        if (GameDetails.Count != 0)
                        {
                            await connection.InvokeAsync("SendGameDetails", item.Value.SignalRID, JsonConvert.SerializeObject(GameDetails));
                        }

                    }

                }
                catch (Exception)
                {
                    //做记录
                    //throw;
                }


            }
        }

        private static void build()
        {
            userList = new Dictionary<string, SignalRInfo>();
            connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:7777/chathub?name=LocalClient")
            .Build();
        }
        private async static Task connectStart()
        {
            try
            {
                await connection.StartAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async static Task sendButton_Click()
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

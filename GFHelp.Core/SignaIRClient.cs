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
        public static List<SignalRInfo> userList;
        public class SignalRInfo
        {
            public string SignalRID;
            public string SignalRName;
            public bool isAdmin = false;
        }


        public async static Task seed()
        {
            build();
            //await connectStart();

            Task MessageTask = new Task(() => LoopGameMessage());
            MessageTask.Start();

        }
        public static Dictionary<string, WebStatus> GamesStatus = new Dictionary<string, WebStatus>();
        public static List<WebData> GameDetails = new List<WebData>();


        public async static Task SendSystemNotice(string ConnectionId)
        {
            if (Viewer.systemLogs.Count == 0) { return; }
            for (int i = 0; i < userList.Count; i++)
            {
                if (!userList[i].isAdmin) continue;
                if (userList[i].SignalRID != ConnectionId) continue;
                foreach (var log in Viewer.systemLogs)
                {
                    await connection.InvokeAsync("SendSystemNotification", userList[i].SignalRID, JsonConvert.SerializeObject(log));
                }
            }

        }
        public async static Task SendSystemNotice(Data data)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].isAdmin)
                {
                    await connection.InvokeAsync("SendSystemNotification", userList[i].SignalRID, JsonConvert.SerializeObject(data));
                }
            }

        }


        public async static Task SendGameNotice(string ConnectionId)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].SignalRID != ConnectionId) continue;
                if (Viewer.usersLogs.ContainsKey(userList[i].SignalRName))
                {
                    foreach (var item in Viewer.usersLogs[userList[i].SignalRName])
                    {
                        await connection.InvokeAsync("SendGameNotification", ConnectionId, JsonConvert.SerializeObject(item));
                    }
                }
            }

        }

        public async static Task SendGameNotice(string gameID, Data data)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].SignalRName != gameID) continue;
                if (Viewer.usersLogs.ContainsKey(userList[i].SignalRName))
                {
                    await connection.InvokeAsync("SendGameNotification", userList[i].SignalRID, JsonConvert.SerializeObject(data));
                }
            }

        }








        private async static Task LoopGameMessage()
        {
            //检查是否有客户端 如果没有的话就不发送了
            while (true)
            {
                Thread.Sleep(1000);
                if (userList.Count == 0)
                {
                    continue;
                }
                if (userList.Count == 1 && userList[0].SignalRName == "LocalClient")
                {
                    await connection.StopAsync();
                    continue;
                }
                await connection.StartAsync();
                for (int i = 0; i < userList.Count;i++)
                {
                    GamesStatus.Clear();
                    foreach (var k in Management.Data.data)
                    {
                        if (userList[i].SignalRName == k.Value.GameAccount.Base.WebUsername)
                        {
                            k.Value.webData.Get(k.Value);
                            GamesStatus.Add(k.Value.GameAccount.Base.GameAccountID, k.Value.webData.webStatus);
                        }
                    }
                    if (GamesStatus.Count != 0)
                    {
                        try
                        {
                            await connection.InvokeAsync("SendGamesStatus", userList[i].SignalRID, JsonConvert.SerializeObject(GamesStatus));
                        }
                        catch (Exception e)
                        {
                            new Log().systemInit("SendGamesStatus Error", e.ToString()).signarlError();
                        }
                        finally
                        {
                            ;
                        }
                    }
                }

                for (int i = 0; i < userList.Count;i++)
                {
                    GameDetails.Clear();
                    foreach (var k in Core.Management.Data.data)
                    {
                        if (userList[i].SignalRName == k.Value.GameAccount.Base.GameAccountID)
                        {
                            k.Value.webData.Get(k.Value);
                            GameDetails.Add(k.Value.webData);
                        }
                    }
                    if (GameDetails.Count != 0)
                    {
                        try
                        {
                            await connection.InvokeAsync("SendGameDetails", userList[i].SignalRID, JsonConvert.SerializeObject(GameDetails));
                        }
                        catch (Exception e)
                        {
                            new Log().systemInit("SendGameDetails Error", e.ToString()).signarlError();
                        }
                        finally
                        {
                            ;
                        }

                    }
                }
            }
        }

        private static void build()
        {
            userList = new List<SignalRInfo>();
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




    }
}

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
            Task MessageTask = new Task(() => Loop());
            MessageTask.Start();

        }
        public static Dictionary<string, List<WebStatus>> GamesStatus = new Dictionary<string, List<WebStatus>>();
        public static Dictionary<string, List<WebData>> GameDetails = new Dictionary<string, List<WebData>>();


        public async static Task SendSystemNotice(string ConnectionId)
        {
            if (Viewer.systemLogs.Count == 0) { return; }
            for (int i = 0; i < userList.Count; i++)
            {
                if (!userList[i].isAdmin) continue;
                if (userList[i].SignalRID != ConnectionId) continue;
                await connection.StartAsync();
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
                    await connection.StartAsync();
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
                    await connection.StartAsync();
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
                await connection.StartAsync();
                if (Viewer.usersLogs.ContainsKey(userList[i].SignalRName))
                {
                    await connection.InvokeAsync("SendGameNotification", userList[i].SignalRID, JsonConvert.SerializeObject(data));
                }
            }

        }
        public static void Loop()
        {
            while (true)
            {
                try
                {
                    Task MessageTask = new Task(() => LoopGameMessage());
                    MessageTask.Start();
                    Task.WaitAll(MessageTask);
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    new Log().systemInit(e.ToString()).webInfo();
                }

            }

        }




        private static void getWebData()
        {
            GamesStatus.Clear();
            GameDetails.Clear();
            List<WebStatus> webStatuses = new List<WebStatus>();
            foreach (var k in Management.Data.data)
            {
                try
                {
                    if (k.taskDispose == true) continue;
                    k.webData.Get();
                    if (!GamesStatus.ContainsKey(k.GameAccount.WebUsername))
                    {
                        GamesStatus.Add(k.GameAccount.WebUsername, new List<WebStatus>());
                    }
                    GamesStatus[k.GameAccount.WebUsername].Add(k.webData.webStatus);

                    if (!GameDetails.ContainsKey(k.GameAccount.GameAccountID))
                    {
                        GameDetails.Add(k.GameAccount.GameAccountID, new List<WebData>());
                    }
                    GameDetails[k.GameAccount.GameAccountID].Add(k.webData);

                }
                catch (Exception e)
                {
                    new Log().systemInit("getGamesStatus Error", e.ToString()).signarlError();
                }
                finally
                {

                }

            }
        }

        private static void LoopGameMessage()
        {
            //检查是否有客户端 如果没有的话就不发送了

            getWebData();
            if (userList.Count == 0) return;
            for (int i = 0; i < userList.Count; i++)
            {
                connection.StartAsync();
                if (userList[i].SignalRName == "LocalClient") continue;
                if (GamesStatus.Count != 0 || GameDetails.Count != 0)
                {
                    try
                    {
                        if (GamesStatus.ContainsKey(userList[i].SignalRName))
                        {
                            connection.InvokeAsync("SendGamesStatus", userList[i].SignalRID, JsonConvert.SerializeObject(GamesStatus[userList[i].SignalRName]));
                        }
                    }
                    catch (Exception e)
                    {
                        new Log().systemInit("SendGamesStatus Error", e.ToString()).signarlError();

                    }
                    try
                    {
                        if (GameDetails.ContainsKey(userList[i].SignalRName))
                        {
                            connection.InvokeAsync("SendGameDetails", userList[i].SignalRID, JsonConvert.SerializeObject(GameDetails[userList[i].SignalRName]));
                        }

                    }
                    catch (Exception e)
                    {
                        new Log().systemInit("SendGameDetails Error", e.ToString()).signarlError();
                    }
                }
            }
            return;

        }

        private static void build()
        {
            userList = new List<SignalRInfo>();
            connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:7777/chathub?name=LocalClient")
            .Build();
        }





    }
}

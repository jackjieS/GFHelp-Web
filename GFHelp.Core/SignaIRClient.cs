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
            public int Level = -1;
        }
        public static void init()
        {

        }

        public async static Task SendSystemNotice(string ConnectionId)
        {
            if (Viewer.systemLogs.Count == 0) { return; }

            foreach (var log in Viewer.systemLogs)
            {
                await connection.InvokeAsync("SendSystemNotification", ConnectionId, JsonConvert.SerializeObject(log));
            }

        }
        public async static Task SendSystemNotice(Data data)
        {
            if (userList == null) return;
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Level==1)
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





        private static void LoopSystemMessage()
        {
            //检查是否有客户端 如果没有的话就不发送了

            if (userList.Count == 0) return;
            for (int i = 0; i < userList.Count; i++)
            {
                connection.StartAsync();
                if (userList[i].SignalRName == "LocalClient") continue;
                if (userList[i].Level != 1) continue;
                try
                {
                    //SendSystemNotice(userList[i].SignalRID);
                }
                catch (Exception e )
                {
                    new Log().systemInit("LoopSystemMessage Error", e.ToString()).signarlError();
                }
            }
            return;

        }




    }
}

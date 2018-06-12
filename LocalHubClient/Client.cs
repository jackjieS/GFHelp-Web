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
        public static Dictionary<string, string> userList;
        public static void seed()
        {
            build();
            connectStart();
            connection.InvokeAsync("Login", "LocalClient");
            Task task = new Task(() => LoopMessage());
            task.Start();
        }
        public static Dictionary<string, WebData> message = new Dictionary<string, WebData>();
        private async static Task LoopMessage()
        {
            //检查是否有客户端 如果没有的话就不发送了
            while (true)
            {
                if (userList.Count <= 1) { Thread.Sleep(1000);continue; }

                foreach (var item in userList)
                {
                    message.Clear();
                    foreach (var k in Core.Management.Data.data)
                    {
                        if (item.Value == k.Value.GameAccount.Base.WebUsername)
                        {
                            k.Value.webData.Get(k.Value);
                            //await connection.InvokeAsync("SendGamesInfo", item.Key, JsonConvert.SerializeObject(k.Value.webData));

                            message.Add(k.Value.GameAccount.Base.Accountid,k.Value.webData);
                        }
                    }

                    await connection.InvokeAsync("SendGamesInfo", item.Key, JsonConvert.SerializeObject(message));
                    //if (k.Value.warningNotes.Count != 0)
                    //{
                    //    await connection.InvokeAsync("SendGamesWarning", item.Value, item.Value.warningNotes[0].Note);
                    //}
                }
                Thread.Sleep(1000);
            }
        }

        private static void build()
        {
            userList = new Dictionary<string, string>();
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

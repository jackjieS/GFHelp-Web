using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using GFHelp.Core.Management;
using GFHelp.Core;
using static GFHelp.Core.SignaIRClient;

namespace GFHelp.Web
{

    public class Chat : Hub
    {

        /// <summary>
        /// 向所有人推送消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task Send(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId}: {message}");
        }
        /// <summary>
        /// 向指定组推送消息
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendToGroup(string groupName, string message)
        {
            return Clients.Group(groupName).SendAsync("ReceiveMessage", $"{Context.ConnectionId}@{groupName}: {message}");
        }
        /// <summary>
        /// 加入指定组并向组推送消息
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public async Task JoinGroup(string groupName)
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            //await Clients.Group(groupName).SendAsync("ReceiveMessage", $"{Context.ConnectionId} joined {groupName}");
        }
        /// <summary>
        /// 推出指定组并向组推送消息
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("ReceiveMessage", $"{Context.ConnectionId} left {groupName}");
        }

        /// <summary>
        /// 向指定Id推送消息
        /// </summary>
        /// <param name="userid">要推送消息的对象</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task Echo(string userid, string message)
        {
            return Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", $"{Context.ConnectionId}: {message}");
        }




        /// <summary>
        /// 后端向前端发送信息
        /// 单个游戏实例
        /// </summary>
        /// <returns></returns>
        public async Task SendGamesStatus(string SignalRID, string message)
        {
            await Clients.Client(SignalRID).SendAsync("ReceiveGamesStatus", message);
        }





        /// <summary>
        /// 后端向前端发送信息
        /// 单个游戏实例
        /// </summary>
        /// <returns></returns>
        public async Task SendGameDetails(string SignalRID, string message)
        {
            await Clients.Client(SignalRID).SendAsync("ReceiveGamesDetails", message);
        }

        /// <summary>
        /// 后端向前端发送信息
        /// </summary>
        /// <returns></returns>
        public async Task SendGamesNotes(string SignalRID, string message)
        {
            await Clients.Client(SignalRID).SendAsync("ReceiveGamesNotes", message);
        }
        /// <summary>
        /// 后端向前端发送信息
        /// </summary>
        /// <returns></returns>
        public async Task SendSystemNotification(string SignalRID, string message)
        {
            await Clients.Client(SignalRID).SendAsync("ReceiveSystemNotification", message);
        }
        public async Task SendGameNotification(string SignalRID, string message)
        {
            await Clients.Client(SignalRID).SendAsync("ReceiveGameNotification", message);
        }






        /// <summary>
        /// 建立连接时触发
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            string name = Context.GetHttpContext().Request.Query["name"].ToString();
            if (name.ToLower() == "null" || string.IsNullOrEmpty(name)) return;
            await Task.Run(() => {
                try
                {
                    SignalRInfo user = new SignalRInfo();
                    user.SignalRID = Context.ConnectionId;
                    user.SignalRName = name;
                    user.isAdmin = false;
                    foreach (var k in Core.SystemOthers.ConfigData.WebUserData)
                    {
                        if (k.Username == name && k.Policy == "1")
                        {
                            user.isAdmin = true;
                        }
                    }
                    userList.Add(user);
                    SendSystemNotice(Context.ConnectionId);
                    SendGameNotice(Context.ConnectionId);
                }
                catch (Exception e)
                {
                    new Core.Helper.Log().systemInit("OnDisconnectedAsync ERROR", e.ToString()).signarlError();
                }
                
            });
        }


        /// <summary>
        /// 离开连接时触发
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Task.Run(() => {
                try
                {
                    for (int i = 0; i < userList.Count; i++)
                    {
                        if(userList[i].SignalRID == Context.ConnectionId)
                        {
                            userList[i] = null;
                            userList.RemoveAt(i);
                            return;
                        }
                    }
                }
                catch (Exception e)
                {
                    new Core.Helper.Log().systemInit("OnDisconnectedAsync ERROR", e.ToString()).signarlError();

                }


            });
        }


        /// <summary>
        /// 移除所有系统消息
        /// </summary>
        /// <param name="ID"></param>
        public async Task RemoveAllSystemNotice(string ID)
        {
            await Task.Run(() => {
                foreach (var item in Core.SystemOthers.ConfigData.WebUserData)
                {
                    if(item.Username == ID && item.Policy == "1")
                    {
                        Core.Helper.Viewer.systemLogs.Clear();
                        return 1;
                    }
                }
                return 0;
            });
        }
        /// <summary>
        /// 移除游戏消息
        /// </summary>
        /// <param name="ID"></param>
        public async Task RemoveGameNotice(string ID)
        {
            await Task.Run(() => {
                var listId = Core.SignaIRClient.userList
                    .Where(t =>
                    t.SignalRName == Context.ConnectionId)
                    .Select(t => t.SignalRName).ToList();
                if (Core.Helper.Viewer.usersLogs.ContainsKey(listId[0]))
                {
                    Core.Helper.Viewer.usersLogs[listId[0]].Clear();
                }
                return 1;
            });
        }







    }
}

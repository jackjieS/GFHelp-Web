using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using GFHelp.Core.Management;
using static GFHelp.LocalChatClient.Client;

namespace GFHelp.Web
{

    public class Chat : Hub
    {
        //public Task SendMessage(string message)
        //{
        //    return Clients.All.SendAsync(message);
        //}

        /// <summary>
        /// Key ConnectionId
        /// value AccountID
        /// </summary>







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
        /// 建立连接时触发
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            ;
        }


        /// <summary>
        /// 离开连接时触发
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Task.Run(() => {
                SignalRInfo signalRInfo = new SignalRInfo();
                foreach (var item in userList)
                {
                    if (item.SignalRID == Context.ConnectionId)
                    {
                        signalRInfo = item;
                    }
                }
                userList.Remove(signalRInfo);
            });
        }




        /// <summary>
        /// ChatHub 登陆用户ID 网站用户 实例账户ID
        /// </summary>
        /// <param name="ID"></param>
        public async Task Login(string ID)
        {
            await Task.Run(() => {
                SignalRInfo user = new SignalRInfo();
                user.SignalRID = Context.ConnectionId;
                user.SignalRName = ID;
                userList.Add(user);
            });

        }

        /// <summary>
        /// ChatHub 注销用户
        /// </summary>
        /// <param name="WebAccountId"></param>
        public async Task Logoff(string WebAccountId)
        {

            await Task.Run(() => {
                SignalRInfo signalRInfo = new SignalRInfo();
                foreach (var item in LocalChatClient.Client.userList)
                {
                    if (item.SignalRName == WebAccountId)
                    {
                        signalRInfo = item;
                    }
                }
                LocalChatClient.Client.userList.Remove(signalRInfo);
            });
        }

    }
}

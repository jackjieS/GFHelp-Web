using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using GFHelp.Core.Management;
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

            await Clients.Group(groupName).SendAsync("ReceiveMessage", $"{Context.ConnectionId} joined {groupName}");
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
        /// </summary>
        /// <returns></returns>
        public async Task SendGamesInfo(string WebAccountId,string message)
        {
            await Clients.Client(WebAccountId).SendAsync("ReceiveGamesInfo", message);
        }

        /// <summary>
        /// 后端向前端发送信息
        /// </summary>
        /// <returns></returns>
        public async Task SendGamesWarning(string WebAccountId, string message)
        {
            await Clients.Client(WebAccountId).SendAsync("ReceiveGamesWarning", message);
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
            foreach (var item in LocalChatClient.Client.userList)
            {
                if (item.Key == Context.ConnectionId)
                {
                    LocalChatClient.Client.userList.Remove(Context.ConnectionId);
                    break;
                }
            }
        }

        /// <summary>
        /// ChatHub 登陆用户
        /// </summary>
        /// <param name="WebAccountId"></param>
        public void Login(string WebAccountId)
        {
            foreach (var item in LocalChatClient.Client.userList)
            {
                if (item.Key == Context.ConnectionId)
                    return;
            }
            LocalChatClient.Client.userList.Add(Context.ConnectionId, WebAccountId);
        }

        /// <summary>
        /// ChatHub 注销用户
        /// </summary>
        /// <param name="WebAccountId"></param>
        public void Logoff(string WebAccountId)
        {
            string key = "";
            foreach (var item in LocalChatClient.Client.userList)
            {
                if (item.Value == WebAccountId)
                {
                    key = item.Key;
                    break;
                }
            }
            if (!string.IsNullOrEmpty(key))
            {
                LocalChatClient.Client.userList.Remove(key);
            }
        }

    }
}

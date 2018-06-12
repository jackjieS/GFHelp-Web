using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GFHelp.Web.Models;
using GFHelp.Web.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Newtonsoft.Json;
using GFHelp.Core.Management;

namespace GFHelp.Web.Controllers
{
    /// <summary>
    /// 网站用户相关操作
    /// </summary>
    //[Route("[controller]")]
    [Authorize]
    public class AccountController : Controller
    {

        private appContext context;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="context"></param>
        public AccountController(appContext context)
        {
            this.context = context;
        }


        internal List<Data.GameAccount> GetAccountInfo(string username)
        {
            List<Data.GameAccount> gameaccount = new List<Data.GameAccount>();
            foreach (var item in context.GameAccount.ToList())
            {
                if (item.WebUsername == username)
                {
                    gameaccount.Add(item);
                }
            }

            if (gameaccount.Count > 0)
            {
                return gameaccount;
            }
            return null;

        }

        private bool delGameAccount(string accountid)
        {
            Data.GameAccount data = null;
            foreach (var item in context.GameAccount.ToList())
            {
                if (item.Accountid == accountid)
                {
                    data = item;
                    break;
                }
            }

            try
            {
                var ranks = context.GameAccount.Remove(data);
                var count = context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }

        private bool creatGameAccount(GameAccountBase accInfo)
        {
            context.GameAccount.Add(new Data.GameAccount
            {
                WebUsername = accInfo.WebUsername,
                Accountid = accInfo.Accountid,
                Password = accInfo.Password,

                Platform = accInfo.Platform,
                Channelid = accInfo.Channelid,
                WorldId = accInfo.WorldId,
                YunDouDou = accInfo.YunDouDou,
            });
            var count = context.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        private bool isAdmin(string username)
        {
            foreach (var item in context.AccountInfo.ToList())
            {
                if (item.Username == username && item.Policy =="admin")
                {
                    return true;
                }
            }
            return false;
        }

        private bool isMulteAccount(string username)
        {
            int i = 0;
            foreach (var item in context.GameAccount.ToList())
            {
                if (item.WebUsername == username)
                {
                    i++;
                }
            }

            if (i >= 1)
            {
                return true;
            }
            return false;

        }

        private bool isAccCreated(string accountid)
        {
            foreach (var item in context.GameAccount.ToList())
            {
                if (item.Accountid == accountid)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取当前用户的信息
        /// </summary>
        /// <returns></returns>
        [Route("/Account/GetInfo")]
        [HttpGet]
        public IActionResult GetInfo()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<Data.GameAccount> result = GetAccountInfo(username);

            return Ok(new
            {
                code = 1,
                data = result,
                message = string.Format("欢迎回来 {0}", username)

            });
        }
        //public string Accountid { get; set; }
        //public string Password { get; set; }

        //public string Platform { get; set; }
        //public string Channelid { get; set; }
        //public string WorldId { get; set; }

        /// <summary>
        /// 创建一个游戏实例
        /// Username 网站用户名字
        /// Accountid 游戏账户(主键)
        /// Password 
        /// Platform 平台 安卓苹果
        /// Channelid 官网填写GWPZ，ios留空不填,腾讯应用宝TX B服Bili 其它渠道服channelid也不一样
        /// WorldId 频道 默认0
        /// Androidid 不必要 自动生成
        /// MAC 不必要 自动生成
        /// YunDouDou 默认为空(这是备用登陆游戏登陆方案)
        /// </summary>
        /// <param name="accountbase.Username">网站用户名字</param>
        /// <param name2="accountbase.Accountid">游戏账户(主键)</param>
        /// <param name3="accountbase.Password">密码</param>
        /// <param name4="accountbase.Platform">平台 安卓苹果</param>
        /// <param name5="accountbase.Channelid">官网填写GWPZ，ios留空不填,腾讯应用宝TX B服Bili 其它渠道服channelid也不一样</param>
        /// <param name6="accountbase.WorldId">频道 默认0</param>
        /// <param name7="accountbase.Androidid">不必要 后端自动生成</param>
        /// <param name8="accountbase.MAC">不必要 后端自动生成</param>
        /// <param name9="accountbaseYunDouDou">默认为空(这是备用登陆游戏登陆方案)</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult CreatNewGame([FromBody] GameAccountBase accountbase)
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //检查是否admin
            if (isAdmin(username) && !isAccCreated(accountbase.Accountid))
            {
                goto Creat;
            }
            //检查是否有多个账号
            if (isMulteAccount(username) || isAccCreated(accountbase.Accountid))
            {
                return Ok(new
                {
                    code = 0,
                    //data = count,
                    message = string.Format("游戏账号已存在")

                });
            }

            Creat:
            bool isCreatSussess = creatGameAccount(accountbase);

            if (isCreatSussess)
            {
                return Ok(new
                {
                    code = 1,
                    message = string.Format("游戏账号记录成功")
                });
            }
            else
            {
                return Ok(new
                {
                    code = -1,
                    message = string.Format("游戏账号记录失败")

                });
            }
        }

        /// <summary>
        /// 删除一个游戏实例
        /// </summary>
        /// <param name="Accountid">游戏帐户id</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult Delete([FromBody]string Accountid)
        {
            bool reslut=true;
            if(isAccCreated(Accountid))
            {
                reslut = delGameAccount(Accountid);
            }

            if (reslut)
            {
                return Ok(new
                {
                    code = 1,
                    //data = count,
                    message = string.Format("游戏账号刪除成功")
                });
            }
            return Ok(new
            {
                code = -1,
                //data = count,
                message = string.Format("游戏账号刪除失敗")
            });

        }

    }
}

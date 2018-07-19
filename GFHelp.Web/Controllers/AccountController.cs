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
using GFHelp.Core.Helper;

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
            var gameaccount =  context.GameAccount.Where(p => p.WebUsername == username).ToList();
            if (gameaccount.Count > 0)
            {
                return gameaccount;
            }
            return null;
        }

        private bool delGameAccount(GameAccountBase gameAccountBase)
        {
            var list = context.GameAccount.Where(p => p.GameAccountID == gameAccountBase.GameAccountID && p.WebUsername == gameAccountBase.WebUsername).ToList();
            if (list.Count == 0) return false;
            foreach (var item in list)
            {
                try
                {
                    var data = item;
                    var ranks = context.GameAccount.Remove(data);
                    var count = context.SaveChanges();
                    if (Core.Management.Data.data.ContainsKey(data.GameAccountID))
                    {
                        Core.Management.Data.data.Remove(data.GameAccountID);
                    }
                    if (Core.Management.Data.tasks.ContainsKey(data.GameAccountID))
                    {
                        Core.Management.Data.tasks.Remove(data.GameAccountID);
                    }
                }
                catch (Exception e)
                {
                    new Log().systemInit(string.Format("删除游戏实例出现错误. {0}", gameAccountBase.ToString()), e.ToString()).coreError();
                    return false;
                }
            }
            return false;
        }

        private bool creatGameAccount(GameAccountBase accInfo)
        {
            context.GameAccount.Add(new Data.GameAccount
            {
                WebUsername = accInfo.WebUsername,
                GameAccountID = accInfo.GameAccountID,
                GamePassword = accInfo.GamePassword,
                Platform = accInfo.Platform,
                ChannelID = accInfo.ChannelID,
                WorldID = accInfo.WorldID,
                YunDouDou = accInfo.YunDouDou,
                Parm = accInfo.Parm,
            });
            var count = context.SaveChanges();
            UserData userdata = new UserData();
            userdata.CreatGameAccount(accInfo);
            Core.Management.Data.seed(userdata);
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        private bool isAdmin(string username)
        {
            var list = context.AccountInfo.Where(p => p.Username == username && p.Policy == "admin").ToList();
            return list.Count > 0 ? true : false;
        }

        private bool isMulteAccount(string username)
        {
            var list = context.GameAccount.Where(p => p.WebUsername == username).ToList();
            return list.Count >= 1 ? true : false;
        }

        private bool isAccCreated(GameAccountBase gameAccountBase)
        {
            var list = context.GameAccount.Where(p => p.GameAccountID == gameAccountBase.GameAccountID).ToList();
            return list.Count > 0 ? true : false;
        }

        /// <summary>
        /// 获取当前用户的信息
        /// </summary>
        /// <returns></returns>
        [Route("/Account/GetGamesInfo")]
        [HttpGet]
        public IActionResult GetGamesInfo()
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
        public IActionResult CreatGame([FromBody] GameAccountBase accountbase)
        {
            bool isCreatSussess=false;
            string username =User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            accountbase.WebUsername = username;
            //检查是否admin
            if (isAdmin(username))
            {
                if (!isAccCreated(accountbase))
                {
                    isCreatSussess =  creatGameAccount(accountbase);
                }

            }
            else
            {
                //检查是否有多个账号
                if (!isMulteAccount(username)  && !isAccCreated(accountbase))
                {
                    isCreatSussess = creatGameAccount(accountbase);
                }
            }



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
        /// <param name="accountbase"></param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult DeleteGame([FromBody] GameAccountBase accountbase)
        {
            bool reslut=true;
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            accountbase.WebUsername = username;




            if (isAccCreated(accountbase))
            {
                reslut = delGameAccount(accountbase);
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

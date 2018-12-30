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



        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="context"></param>
        public AccountController()
        {
            ;
        }


        internal List<DataBase.GameAccount> GetAccountInfo(string username)
        {
            var gameaccount = DataBase.DataBase.GetGameAccountByUserName(username);
            if (gameaccount.Count > 0)
            {
                return gameaccount;
            }
            return null;
        }

        internal List<DataBase.GameAccount> GetDefaultAccountInfo()
        {
            var listGameInfo = DataBase.DataBase.GetGameAccounts();
            List<DataBase.GameAccount> resultList = new List<DataBase.GameAccount>();


            foreach (var item in listGameInfo)
            {
                if (item.isDefault) resultList.Add(item);
            }
            return resultList;
        }

        private bool delGameAccount(DataBase.GameAccount gameAccount)
        {
            bool result = false;
            if (DataBase.DataBase.DelGameAccount(gameAccount))
            {
                try
                {
                    if (Core.Management.Data.data.ContainsKey(gameAccount.GameAccountID))
                    {
                        Core.Management.Data.data.getDataByID(gameAccount.GameAccountID).taskDispose = true;
                        Core.Management.Data.data.RemoveByID(gameAccount.GameAccountID);
                        result = true;
                    }

                }
                catch (Exception e)
                {
                    new Log().systemInit(string.Format("删除游戏实例data出现错误. {0}", gameAccount.GameAccountID.ToString()), e.ToString()).coreError();
                    result = false;
                }
                return result;
            }
            return result;
        }

        private bool creatGameAccount(DataBase.GameAccount accInfo)
        {
            bool result =  DataBase.DataBase.creatGameAccount(accInfo);
            if(result == true)
            {
                UserData userdata = new UserData();
                userdata.CreatGameAccount(accInfo);
                Core.Management.Data.Seed(userdata);
                return true;
            }
            return false;
        }


        private bool isMulteAccount(string username)
        {
            return DataBase.DataBase.isMulteAccount(username);
        }

        private bool isAccCreated(DataBase.GameAccount gameAccount)
        {
            return DataBase.DataBase.isAccCreated(gameAccount);

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
            List<DataBase.GameAccount> result = GetAccountInfo(username);

            return Ok(new
            {
                code = 1,
                data = result,
                message = string.Format("欢迎回来 {0}", username)
            });
        }


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
        public IActionResult CreatGame([FromBody] DataBase.GameAccount accountbase)
        {
            if (CheckDataVailed(accountbase) == false) return NoContent();
            bool isCreatSussess=false;
            string username =User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            accountbase.WebUsername = username;
            accountbase.isDefault = false;
            //检查是否admin
            if (DataBase.DataBase.getLevelNumber(username) <= 2)
            {
                if (!isAccCreated(accountbase))
                {
                    isCreatSussess = creatGameAccount(accountbase);
                }
            }
            if (DataBase.DataBase.getLevelNumber(username) > 2)
            {
                //检查是否有多个账号
                if (!isMulteAccount(username) && !isAccCreated(accountbase))
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
        public IActionResult DeleteGame([FromBody] DataBase.GameAccount accountbase)
        {
            if (CheckDataVailed(accountbase) == false) return NoContent();
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



        /// <summary>
        /// 获取Default的游戏实例
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetDefaultGamesInfo()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //检查是否admin
            if (DataBase.DataBase.getLevelNumber(username) != 1)
            {
                return Ok(new
                {
                    code = -1,
                    message = string.Format("权限不足")
                });
            }
            return Ok(new
            {
                code = 1,
                data = GetDefaultAccountInfo(),
                message = string.Format("嘤嘤嘤")
            });

        }


        /// <summary>
        /// 创建一个游戏实例
        /// </summary>
        [Route("[action]")]
        [HttpPost]
        public IActionResult CreatDefaultGame([FromBody] DataBase.GameAccount AccountInfo)
        {
            if (CheckDataVailed(AccountInfo) == false) return NoContent();



            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;




            //检查是否admin
            if (DataBase.DataBase.getLevelNumber(username) != 1)
            {
                return Ok(new
                {
                    code = -1,
                    message = string.Format("权限不足")
                });
            }

            AccountInfo.isDefault = true;
            //检查是否有多个账号
            if (!isAccCreated(AccountInfo))
            {
                creatGameAccount(AccountInfo);
            }

            return Ok(new
            {
                code = 1,
                data = GetDefaultAccountInfo(),
                message = string.Format("游戏账号记录成功")
            });

        }

        /// <summary>
        /// 创建多个游戏实例
        /// </summary>
        [Route("[action]")]
        [HttpPost]
        public IActionResult CreatDefaultGames([FromBody] List<DataBase.GameAccount> ListAccountInfo)
        {
            if (CheckDataVailed(ListAccountInfo) == false) return NoContent();
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<DataBase.GameAccount> resultList = new List<DataBase.GameAccount>();
            //检查是否admin
            if (DataBase.DataBase.getLevelNumber(username) != 1)
            {
                return Ok(new
                {
                    code = -1,
                    message = string.Format("权限不足")
                });
            }


            for (int i = 0; i < ListAccountInfo.Count; i++)
            {
                ListAccountInfo[i].isDefault = true;
            }

            foreach (var item in ListAccountInfo)
            {
                //检查是否有多个账号
                if (!isAccCreated(item))
                {
                    if (!creatGameAccount(item)) resultList.Add(item);
                }

            }



            return Ok(new
            {
                code = 1,
                data = GetDefaultAccountInfo(),
                message = string.Format("游戏账号记录成功")
            });

        }


        /// <summary>
        /// 删除一个游戏实例
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult DeleteDefaultGame([FromBody] DataBase.GameAccount accountbase)
        {
            if (CheckDataVailed(accountbase) == false) return NoContent();
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //检查是否admin
            if (DataBase.DataBase.getLevelNumber(username) != 1)
            {
                return Ok(new
                {
                    code = -1,
                    data = "",
                    message = string.Format("权限不足")
                });
            }

            if (isAccCreated(accountbase))
            {
                delGameAccount(accountbase);
            }
            return Ok(new
            {
                code = 1,
                data = GetDefaultAccountInfo(),
                message = string.Format("已清空")
            });

        }

        private bool CheckDataVailed(object data)
        {
            if (data == null) return false;
            return true;


        }
















    }
}

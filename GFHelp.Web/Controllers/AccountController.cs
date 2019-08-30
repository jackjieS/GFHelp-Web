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
using System.Threading;

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
        private bool PauseGameAccount(DataBase.GameAccount gameAccount)
        {
            bool result = false;
            try
            {
                if (Core.Management.Data.data.ContainsKey(gameAccount.GameAccountID))
                {
                    Core.Management.Data.data.PauseById(gameAccount.GameAccountID);
                    result = true;
                }

            }
            catch (Exception e)
            {
                new Log().systemInit(string.Format("暂停游戏实例出现错误. {0}", gameAccount.GameAccountID.ToString()), e.ToString()).coreError();
                result = false;
            }
            return result;
        }

        private bool RestartGameAccount(DataBase.GameAccount gameAccount)
        {
            bool result = false;
            try
            {
                if (Core.Management.Data.data.ContainsKey(gameAccount.GameAccountID))
                {
                    Core.Management.Data.data.RestartById(gameAccount.GameAccountID);
                    Task task = new Task(() => Core.Management.Data.data.getDataByID(gameAccount.GameAccountID).home.Login());
                    task.Start();
                    result = true;
                }

            }
            catch (Exception e)
            {
                new Log().systemInit(string.Format("恢复游戏实例出现错误. {0}", gameAccount.GameAccountID.ToString()), e.ToString()).coreError();
                result = false;
            }
            return result;
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
                        Core.Management.Data.data.getDataByID(gameAccount.GameAccountID).Net = null;
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



        public async Task C(Core.M.AccountInfo account, string Name)
        {

            DataBase.GameAccount Account = new DataBase.GameAccount();
            Account.WebUsername = Name;
            Account.GameAccountID = account.ID;
            Account.GamePassword = account.PW;
            Account.ChannelID = "gwpz";
            Account.WorldID = "0";
            Account.isDefault = false;
            Account.Parm = "-m";

            bool result = DataBase.DataBase.creatGameAccount(Account);
            if (result == true)
            {
                UserData userdata = new UserData();
                userdata.CreatGameAccount(Account);
                Core.Management.Data.Seed(userdata);
                userdata.home.Login();
                return;
            }
        }

        public void OutputGameAccounts(string Name)
        {
            new Log().systemInit(string.Format("开始 输出账号")).coreInfo();
            Core.M.MaccountInfoOutput.Clear();
            foreach (var item in Core.Management.Data.data.getDatasByWebID(Name))
            {
                if (item.config.FinalLoginSuccess == true)
                {

                    Core.M.AccountInfo accountInfo = new Core.M.AccountInfo(item.GameAccount.GameAccountID, item.GameAccount.GamePassword, item.user_Info.gem);
                    Core.M.MaccountInfoOutput.Add(accountInfo);
                }
            }
            Core.M.WriteList("MaccountInfosOutput.txt");


            new Log().systemInit(string.Format("完成 输出账号")).coreInfo();
            return;
        }

        public void L(string Name)
        {
            new Log().systemInit(string.Format("开始 二次登陆")).coreInfo();
            int TaskLimited = 4;
            int Count = 0;
            int X = 1;

            foreach (var item in Core.Management.Data.data.getDatasByWebID(Name))
            {
                if (item.config.FinalLoginSuccess == false)
                {
                    while (Count > TaskLimited)
                    {
                        Thread.Sleep(1000);
                    }
                    Task task = new Task(() => item.home.Login());
                    task.Start();
                    Count++;
                    task.ContinueWith(t =>
                    {
                        Count--;
                    });
                }
            }
            while (Count > 0)
            {
                Thread.Sleep(1000);
            }


            new Log().systemInit(string.Format("二次登完成录", X++.ToString())).coreInfo();
            return;
        }



        private void PauseGameAccounts(string Name)
        {

            var list = Core.Management.Data.data.getGameAccountByName(Name);

            foreach (var item in list)
            {
                try
                {
                    if (Core.Management.Data.data.ContainsKey(item.GameAccountID))
                    {
                        Core.Management.Data.data.PauseById(item.GameAccountID);
                    }
                }
                catch (Exception e)
                {
                    new Log().systemInit(string.Format("暂停游戏实例出现错误. {0}", item.GameAccountID.ToString()), e.ToString()).coreError();
                }
            }
        }
        private void RestartGameAccounts(string Name)
        {

            var list = Core.Management.Data.data.getGameAccountByName(Name);

            foreach (var item in list)
            {
                try
                {
                    if (Core.Management.Data.data.ContainsKey(item.GameAccountID))
                    {
                        Core.Management.Data.data.RestartById(item.GameAccountID);
                        Task task = new Task(() => Core.Management.Data.data.getDataByID(item.GameAccountID).home.Login());
                        task.Start();
                    }
                }
                catch (Exception e)
                {
                    new Log().systemInit(string.Format("恢复游戏实例出现错误. {0}", item.GameAccountID.ToString()), e.ToString()).coreError();
                }
            }
        }
        private void DelteGameAccounts(string Name)
        {

            var list = Core.Management.Data.data.getGameAccountByName(Name);

            foreach (var item in list)
            {
                if (DataBase.DataBase.DelGameAccount(item))
                {
                    try
                    {
                        if (Core.Management.Data.data.ContainsKey(item.GameAccountID))
                        {
                            Core.Management.Data.data.getDataByID(item.GameAccountID).Net = null;
                            Core.Management.Data.data.RemoveByID(item.GameAccountID);
                        }
                    }
                    catch (Exception e)
                    {
                        new Log().systemInit(string.Format("删除游戏实例data出现错误. {0}", item.GameAccountID.ToString()), e.ToString()).coreError();
                    }
                }
            }
        }
        public static object ThreadLocker = new object();
        private async Task creatGameAccounts(string Name)
        {
            //读取

            Core.M.Read();
            DateTime dateTime = DateTime.Now;

            int Count = 0;
            int Index = 0;
            while (Index  < Core.M.MaccountInfosInput.Count)
            {
                if (Count < 6)
                {
                    lock (ThreadLocker)
                    {
                        var account = Core.M.MaccountInfosInput[Index];
                        Interlocked.Increment(ref Count);
                        Interlocked.Increment(ref Index);
                        Task.Run(() =>
                        {
                            C(account, Name);
                            lock (ThreadLocker)
                            {
                                Interlocked.Decrement(ref Count);
                            }

                        });
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                }

            }
            TimeSpan ts = DateTime.Now - dateTime;

            new Log().systemInit(string.Format("创建游戏M 任务完成 总共用时 {0} 时 {1} 分", ts.Hours, ts.Minutes)).coreInfo();



            new Log().systemInit(string.Format("开始 二次登陆")).coreInfo();


            Thread.Sleep(120000);
            L(Name);



            return;
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


        [Route("[action]")]
        [HttpGet]
        public IActionResult cGameAccounts()
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

            Task task = new Task(() => creatGameAccounts(username));
            task.Start();
            return Ok(new
            {
                code = 1,
                data = "",
                message = string.Format("正在读取与创建")
            });
        }


        [Route("[action]")]
        [HttpGet]
        public IActionResult sGameAccounts()
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

            Task task = new Task(() => L(username));
            task.Start();
            return Ok(new
            {
                code = 1,
                data = "",
                message = string.Format("正在读取与创建")
            });
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult oGameAccounts()
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

            Task task = new Task(() => OutputGameAccounts(username));
            task.Start();
            return Ok(new
            {
                code = 1,
                data = "",
                message = string.Format("正在读取与创建")
            });
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult dGameAccounts()
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


            Task task = new Task(() => DelteGameAccounts(username));
            task.Start();
            return Ok(new
            {
                code = 1,
                data = "",
                message = string.Format("正在删除")
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
        /// 暂停一个游戏实例
        /// </summary>
        /// <param name="accountbase"></param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult PauseGame([FromBody] DataBase.GameAccount accountbase)
        {
            if (CheckDataVailed(accountbase) == false) return NoContent();
            bool reslut = true;
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            accountbase.WebUsername = username;

            if (isAccCreated(accountbase))
            {
                reslut = PauseGameAccount(accountbase);
            }

            if (reslut)
            {
                return Ok(new
                {
                    code = 1,
                    //data = count,
                    message = string.Format("游戏账号暂停成功")
                });
            }
            return Ok(new
            {
                code = -1,
                //data = count,
                message = string.Format("游戏账号暂停失敗")
            });

        }

        /// <summary>
        /// 恢复一个游戏实例
        /// </summary>
        /// <param name="accountbase"></param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult RestartGame([FromBody] DataBase.GameAccount accountbase)
        {
            if (CheckDataVailed(accountbase) == false) return NoContent();
            bool reslut = true;
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            accountbase.WebUsername = username;

            if (isAccCreated(accountbase))
            {
                reslut = RestartGameAccount(accountbase);
            }

            if (reslut)
            {
                return Ok(new
                {
                    code = 1,
                    //data = count,
                    message = string.Format("游戏账号恢复成功")
                });
            }
            return Ok(new
            {
                code = -1,
                //data = count,
                message = string.Format("游戏账号暂停失敗")
            });

        }

        /// <summary>
        /// 暂停所有实例
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult PauseGameAccounts()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Task task = new Task(() => PauseGameAccounts(username));
            task.Start();
            return Ok(new
            {
                code = 1,
                data = "",
                message = string.Format("正在暂停")
            });
        }
        /// <summary>
        /// 恢复所有实例
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult RestartGameAccounts()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Task task = new Task(() => RestartGameAccounts(username));
            task.Start();
            return Ok(new
            {
                code = 1,
                data = "",
                message = string.Format("正在恢复")
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
            AccountInfo.isDefault = true;
            if (string.IsNullOrEmpty(AccountInfo.WebUsername)) AccountInfo.WebUsername = username;
            if (string.IsNullOrEmpty(AccountInfo.WorldID)) AccountInfo.WorldID = "0";


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
                if (string.IsNullOrEmpty(ListAccountInfo[i].WebUsername)) ListAccountInfo[i].WebUsername = username;
                if (string.IsNullOrEmpty(ListAccountInfo[i].WorldID)) ListAccountInfo[i].WorldID = "0";
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

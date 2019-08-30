using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GFHelp.Core;
using GFHelp.Core.Helper;
using GFHelp.Core.Helper.Configer;
using GFHelp.Core.SystemManager;

using GFHelp.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GFHelp.Core.SystemManager.SystemHelper;
using static GFHelp.Web.Controllers.GameController;


namespace GFHelp.Web.Controllers
{
    /// <summary>
    /// 系统运行的情况
    /// </summary>

    public class SystemController : Controller
    {

        /// <summary>
        /// 系统控制器
        /// </summary>
        public SystemController()
        {

        }


        /// <summary>
        /// 获取系统错误信息
        /// </summary>
        /// <returns></returns>
        [Route("/System/GetLogs")]
        [HttpGet]
        [Authorize]
        public IActionResult GetLogs()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (DataBase.DataBase.isLevel1(username))
            {
                return Ok(new
                {
                    code = 1,
                    data = Core.Helper.Viewer.systemLogs,
                    message = string.Format("欢迎回来 {0} 管理员", username)

                });
            }
            else
            {
                return Ok(new
                {
                    code = -1,
                    data = "error",
                    message = string.Format("请使用管理员账号登陆")

                });
            }

        }

        /// <summary>
        /// 获取M的情况
        /// </summary>
        /// <returns></returns>
        [Route("/System/GetRunningNumberOfM")]
        [HttpGet]
        [Authorize]
        public IActionResult GetRunningNumberOfM()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!DataBase.DataBase.isLevel1(username))
            {
                return Ok(new
                {
                    code = -1,
                    data = "error",
                    message = string.Format("请使用管理员账号登陆")

                });
            }


            OperationStatus os =  SystemHelper.GetRunningNumberOfM();
            string result = "\r\n";

            result += string.Format("TotalNumber = {0} TotalFinalLoginNum = {1} \r\n", os.TotalNum,os.TotalFinalTimeLogin);

            result +=string.Format("OperationRunning = {0} OperationProblem =  {1} \r\n", os.OperationRunning , os.OperationProblem);


            string accountList = "";
            foreach (var item in os.ListOperationProblem)
            {
                accountList += "\t" + item.ToString();
            }
            result += accountList + "\r\n";

            result += string.Format("DollBuildRunning = {0} DollBuildProblem =  {1} \r\n", os.DollBuildRunning, os.DollBuildProblem);
            accountList = "";
            foreach (var item in os.ListDollBuildProblem)
            {
                accountList += "\t" + item.ToString();
            }
            result += accountList + "\r\n";



            result += string.Format("Battling = {0} MissionClosed  =  {1} \r\n", os.BattleNum, os.MissionClosed);

            accountList = "";
            foreach (var item in os.ListBattleNum)
            {
                accountList += "\t" + item.ToString();
            }
            result += accountList + "\r\n";



            accountList = "";
            foreach (var item in os.ListMissionClosed)
            {
                accountList +="\t" + item.ToString();
            }
            result += accountList + "\r\n";

            result += string.Format("LoginFalse = {0} \r\n", os.LoginFalse);

            accountList = "";
            foreach (var item in os.ListLoginFalse)
            {
                accountList += "\t" + item.ToString();
            }
            result += accountList + "\r\n";






            return Ok(new
            {
                code = 1,
                data = os,
                message = result

            });

        }

        /// <summary>
        /// 删除全部系统消息信息
        /// </summary>
        /// <returns></returns>
        [Route("/System/RemoveALLSystemNotice")]
        [HttpGet]
        [Authorize]
        public IActionResult RemoveALLSystemNotice()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (DataBase.DataBase.isLevel1(username))
            {
                if (Core.Helper.Viewer.systemLogs.Count != 0)
                {
                    Core.Helper.Viewer.systemLogs.Clear();
                }
                return Ok(new
                {
                    code = 1,
                    data = Core.Helper.Viewer.systemLogs,
                    message = string.Format("删除成功")

                });
            }
            else
            {
                return Ok(new
                {
                    code = -1,
                    data = "error",
                    message = string.Format("请使用管理员账号登陆")

                });
            }

        }


        /// <summary>
        /// 获取基础信息 如10张图的后勤信息
        /// </summary>
        /// <returns></returns>
        [Route("/System/GetOperationInfo")]
        [HttpGet]
        [Authorize]
        public IActionResult GetOperationInfo()
        {
            var temp = new
            {
                OperationInfo = Core.CatachData.GetOperationInfo(),
                BattleMap = Core.SystemManager.ConfigData.BattleMap
            };
            return Ok(new
            {
                code = 1,
                data = temp,
                message = "获取后勤信息"
            });
        }


        /// <summary>
        /// 系统是否正在运行
        /// </summary>
        /// <returns></returns>
        [Route("/System/isRunning")]
        [HttpGet]
        public IActionResult isRunning()
        {

            return Ok(new
            {
                code = 1,
                message = "Running"
            });
        }

        /// <summary>
        /// 获取系统信息
        /// </summary>
        /// <returns></returns>
        [Route("/System/UpgradeInfo")]
        [HttpGet]
        public IActionResult UpgradeInfo()
        {
            string data="";
            foreach (var item in ConfigManager.UpgradeInfo)
            {
                data += "<p>"+item+ "</p>";
            }

            return Ok(new
            {
                code = 1,
                data = data,
                message = ""
            });
        }

        /// <summary>
        /// 这是一个测试接口，模拟生成一个系统消息并推送到前端
        /// </summary>
        /// <returns></returns>
        [Route("/System/TestInitSystemNotice")]
        [HttpPost]
        [Authorize]
        public  IActionResult TestInitSystemNotice()
        {

            Task.Run(()=> 
            {
                new Log().systemInit(DateTime.Now.ToString()).coreInfo();
            });
            return Ok(new
            {
                code = 1,
                data = DateTime.Now.ToString(),
                message = string.Format("测试")
            });

        }

        /// <summary>
        /// 获取当前游戏实例个数
        /// </summary>
        /// <returns></returns>
        [Route("/System/GetCountOfGame")]
        [HttpGet]
        [Authorize]
        public IActionResult GetCountOfGame()
        {
            int count = Core.Management.Data.data.Count;

            return Ok(new
            {
                code = 1,
                data = count,
                message = string.Format("当前共有 {0} 个游戏实例托管中", count)
            });
        }

        /// <summary>
        /// 获取当前游戏实例个数
        /// </summary>
        /// <returns></returns>
        [Route("/System/LoadHostAddress")]
        [HttpGet]
        [Authorize]
        public IActionResult LoadHostAddress()
        {
            bool result = HostAddress.Load();
            if(result == true)
            {
                return Ok(new
                {
                    code = 1,
                    data = 1,
                    message = string.Format("LoadHostAddress Success ")
                });
            }
            else
            {
                return Ok(new
                {
                    code = 0,
                    data = 0,
                    message = string.Format("LoadHostAddress failed ")
                });
            }
        }

        /// <summary>
        /// ReloadMissionDll
        /// </summary>
        /// <returns></returns>
        [Route("/System/ReloadLibeary")]
        [HttpGet]
        [Authorize]
        public IActionResult ReloadLibeary()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!DataBase.DataBase.isLevel1(username))
            {
                return Ok(new
                {
                    code = -1,
                    //data = result,
                    message = string.Format("没有权限")
                });
            }

            Core.CatchData.Base.Asset_Textes.Read_ALL_CSV();
            HostAddress.Load();
            //Core.Action.MissionData.Reload();
            GC.Collect();
            return Ok(new
            {
                code = 1,
                //data = result,
                message = string.Format("完成")
            });
        }



        /// <summary>
        /// LoadWebProxy
        /// </summary>
        /// <returns></returns>
        [Route("/System/LoadWebProxy")]
        [HttpGet]
        [Authorize]
        public IActionResult LoadWebProxy()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!DataBase.DataBase.isLevel1(username))
            {
                return Ok(new
                {
                    code = -1,
                    //data = result,
                    message = string.Format("没有权限")
                });
            }

            string accountList = "\r\n";
            foreach (var item in NetBase.webProxy.webProxies)
            {
                accountList += "\t" + item.Host;
            }
            string Result = string.Format("可用代理共有 {0} 个 : {1} ", NetBase.webProxy.webProxies.Count, accountList);


            return Ok(new
            {
                code = 1,
                data = NetBase.webProxy.webProxies,
                message = Result
            });
        }

        /// <summary>
        /// WebProxyTrigger
        /// </summary>
        /// <returns></returns>
        [Route("/System/WebProxyTrigger")]
        [HttpGet]
        [Authorize]
        public IActionResult WebProxyTrigger()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!DataBase.DataBase.isLevel1(username))
            {
                return Ok(new
                {
                    code = -1,
                    //data = result,
                    message = string.Format("没有权限")
                });
            }

            NetBase.webProxy.Trigger();



            return Ok(new
            {
                code = 1,
                message = string.Format("完成")
            });
        }

        /// <summary>
        /// DownloadCatchdata
        /// </summary>
        /// <returns></returns>
        [Route("/System/DownloadCatchdata")]
        [HttpGet]
        [Authorize]
        public IActionResult DownloadCatchdata()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!DataBase.DataBase.isLevel1(username))
            {
                return Ok(new
                {
                    code = -1,
                    //data = result,
                    message = string.Format("没有权限")
                });
            }

            Core.CatchData.Seed.Updata();



            return Ok(new
            {
                code = 1,
                message = string.Format("完成")
            });
        }





        /// <summary>
        /// 获取网站所有用户 注意并不是 游戏帐户
        /// </summary>
        /// <returns></returns>
        [Route("/System/GetWebUsers")]
        [HttpGet]
        [Authorize]        public IActionResult GetWebUsers()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!DataBase.DataBase.isLevel1(username))
            {
                return Ok(new
                {
                    code = -1,
                    //data = result,
                    message = string.Format("没有权限")
                });
            }

            var AccountInfo = DataBase.DataBase.GetAccountInfos();
            for (int i = 0; i < AccountInfo.Count; i++)
            {
                AccountInfo[i].Password = null;
            }
            return Ok(new
            {
                code = 1,
                data = AccountInfo,
                message = string.Format("完成")
            });
        }




    }
}
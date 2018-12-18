using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GFHelp.Core.Helper;
using GFHelp.Core.Helper.Configer;
using GFHelp.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private bool isAdmin(string username)
        {
            return DataBase.DataBase.isUserAdmin(username);
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
            if (isAdmin(username))
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
        /// 删除全部系统消息信息
        /// </summary>
        /// <returns></returns>
        [Route("/System/RemoveALLSystemNotice")]
        [HttpGet]
        [Authorize]
        public IActionResult RemoveALLSystemNotice()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (isAdmin(username))
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
                BattleMap = Core.SystemOthers.ConfigData.BattleMap
            };
            return Ok(new
            {
                code = 1,
                data = temp,
                message = "获取后勤信息"
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
            Log log = new Log().systemInit(DateTime.Now.ToString()).coreInfo();
            Task.Run(()=> 
            {
                Core.SignaIRClient.SendSystemNotice(log.data);
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
        [Route("/Game/ReloadLibeary")]
        [HttpGet]
        public IActionResult ReloadLibeary()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!isAdmin(username))
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
            Core.Action.MissionData.Reload();
            GC.Collect();
            return Ok(new
            {
                code = 1,
                //data = result,
                message = string.Format("完成")
            });
        }



    }
}
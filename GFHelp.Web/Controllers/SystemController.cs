using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GFHelp.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFHelp.Web.Controllers
{
    /// <summary>
    /// 系统运行的情况
    /// </summary>
    [Authorize]
    public class SystemController : Controller
    {
        private appContext context;
        /// <summary>
        /// 系统控制器
        /// </summary>
        public SystemController(appContext context)
        {
            this.context = context;
        }
        private bool isAdmin(string username)
        {
            foreach (var item in context.AccountInfo.ToList())
            {
                if (item.Username == username && item.Policy == "admin")
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取系统错误信息
        /// </summary>
        /// <returns></returns>
        [Route("/System/GetLogs")]
        [HttpGet]
        public IActionResult GetLogs()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (isAdmin(username))
            {
                return Ok(new
                {
                    code = 1,
                    data = Core.SysteOthers.Viewer.Logs,
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
        /// 删除一条系统记录信息
        /// </summary>
        /// <returns></returns>
        [Route("/System/RemoveLog")]
        [HttpGet]
        public IActionResult RemoveLog()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (isAdmin(username))
            {
                if (Core.SysteOthers.Viewer.Logs.Count != 0)
                {
                    Core.SysteOthers.Viewer.Logs.RemoveAt(0);
                }
                return Ok(new
                {
                    code = 1,
                    data = Core.SysteOthers.Viewer.Logs,
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
        /// 删除全部系统信息
        /// </summary>
        /// <returns></returns>
        [Route("/System/RemoveALLLogs")]
        [HttpGet]
        public IActionResult RemoveALLLogs()
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (isAdmin(username))
            {
                if (Core.SysteOthers.Viewer.Logs.Count != 0)
                {
                    Core.SysteOthers.Viewer.Logs.Clear();
                }
                return Ok(new
                {
                    code = 1,
                    data = Core.SysteOthers.Viewer.Logs,
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
        public IActionResult GetOperationInfo()
        {
            var temp = new
            {
                OperationInfo = Core.CatachData.GetOperationInfo(),
                BattleMap = Core.SysteOthers.ConfigData.BattleMap
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
        [Route("/System/News")]
        [HttpGet]
        public IActionResult GetNews()
        {
            return Ok(new
            {
                code = 1,
                data = "系统信息",
                message = "系统信息"
            });
        }



    }
}
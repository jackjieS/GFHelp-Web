using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Codeplex.Data;
using GFHelp.Core.MulitePlayerData;
using GFHelp.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFHelp.Web.Controllers
{
    /// <summary>
    /// 游戏操作的
    /// </summary>
    [Authorize]
    public class GameController : Controller
    {

        private appContext context;
        /// <summary>
        /// Game控制器
        /// </summary>
        public GameController(appContext context)
        {
            this.context = context;
        }



        /// <summary>
        /// 获取用户 下所有游戏实例的详细信息
        /// </summary>
        /// <returns></returns>
        [Route("/Game/GetGameDetails")]
        [HttpGet]
        public IActionResult GetGameDetails()
        {
            //var temp = new
            //{
            //    OperationInfo = Core.CatachData.GetOperationInfo(),
            //    BattleMap = Core.SystemEvents.ConfigData.BattleMap
            //};
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var details = Core.Management.Data.GetWebData(username);

            return Ok(new
            {
                code = 1,
                data = details,
            });
        }

        /// <summary>
        /// 游戏登陆
        /// </summary>
        /// <param name="Accountid"> 游戏账户id</param>
        /// <returns></returns>
        [Route("/Game/Login")]
        [HttpPost]
        public IActionResult Login([FromBody] string Accountid)
        {
            //加入控制符
            Core.Management.Data.data[Accountid].Task.Add(Core.Helper.TaskList.Login);
            return Ok(new
            {
                code = 1,
                //data = result,
                message = string.Format("正在登陆 {0}", Accountid)

            });
        }

        /// <summary>
        /// [josn] accountID,后勤KEY, 后勤ID,后勤梯队ID sample:{"accountID":"13201546359","Key":"0","operationID":"5","TeamID":"1"}
        /// </summary>
        /// <param text="json"> json</param>
        /// <returns></returns>
        [Route("/Game/StartOperation")]
        [HttpPost]
        public IActionResult StartOperation([FromBody] Operation text)
        {
            // accountID
            // key
            // operationID
            // TeamID

            //var jsonobj = DynamicJson.Parse(text); //讲道理，我真不想写了
            //string accountID = jsonobj.accountID.ToString();
            //string key = jsonobj.Key.ToString();
            //string operationID = jsonobj.operationID.ToString();
            //string TeamID = jsonobj.TeamID.ToString();


            string accountID = text.accountID.ToString();
            string key = text.key.ToString();
            string operationID = text.operationID.ToString();
            string TeamID = text.TeamID.ToString();

            if (!Core.Management.Data.data[accountID].operation_Act_Info.dicOperation.ContainsKey(Convert.ToInt32(key)))
            {
                Operation_Act_Info oai = new Operation_Act_Info();
                Core.Management.Data.data[accountID].operation_Act_Info.dicOperation.Add(Convert.ToInt32(key), oai);
            }

            Core.Management.Data.data[accountID].operation_Act_Info.dicOperation[Convert.ToInt32(key)].team_id =Convert.ToInt32(TeamID);
            Core.Management.Data.data[accountID].operation_Act_Info.dicOperation[Convert.ToInt32(key)].operation_id = Convert.ToInt32(operationID);
            //加入控制符
            switch (Convert.ToInt32(key))
            {
                case 0:
                    {
                        Core.Management.Data.data[accountID].Task.Add(Core.Helper.TaskList.Start_Operation_Act1);
                        break;
                    }
                case 1:
                    {
                        Core.Management.Data.data[accountID].Task.Add(Core.Helper.TaskList.Start_Operation_Act2);
                        break;
                    }
                case 2:
                    {
                        Core.Management.Data.data[accountID].Task.Add(Core.Helper.TaskList.Start_Operation_Act3);
                        break;
                    }
                case 3:
                    {
                        Core.Management.Data.data[accountID].Task.Add(Core.Helper.TaskList.Start_Operation_Act4);
                        break;
                    }
                default:
                    break;
            }

            return Ok(new
            {
                code = 1,
                //data = result,
                message = string.Format("开始后勤")

            });
        }


        /// <summary>
        /// [josn] accountID,后勤KEY, 后勤ID, sample:{"accountID":"13201546359","Key":"0","operationID":"5"}
        /// </summary>
        /// <param text="json"> json</param>
        /// <returns></returns>
        [Route("/Game/AbortOperation")]
        [HttpPost]
        public IActionResult AbortOperation([FromBody] Operation text)
        {
            // accountID
            // key
            // operationID
            // TeamID

            //var jsonobj = DynamicJson.Parse(text); //讲道理，我真不想写了
            //string accountID = jsonobj.accountID.ToString();
            //string key = jsonobj.Key.ToString();
            //string operationID = jsonobj.operationID.ToString();

            string accountID = text.accountID.ToString();
            string key = text.key.ToString();
            string operationID = text.operationID.ToString();
            Core.Management.Data.data[accountID].operation_Act_Info.dicOperation[Convert.ToInt32(key)].operation_id = Convert.ToInt32(operationID);
            //加入控制符
            switch (Convert.ToInt32(key))
            {
                case 0:
                    {
                        Core.Management.Data.data[accountID].Task.Add(Core.Helper.TaskList.Abort_Operation_Act1);
                        break;
                    }
                case 1:
                    {
                        Core.Management.Data.data[accountID].Task.Add(Core.Helper.TaskList.Abort_Operation_Act2);
                        break;
                    }
                case 2:
                    {
                        Core.Management.Data.data[accountID].Task.Add(Core.Helper.TaskList.Abort_Operation_Act3);
                        break;
                    }
                case 3:
                    {
                        Core.Management.Data.data[accountID].Task.Add(Core.Helper.TaskList.Abort_Operation_Act4);
                        break;
                    }
                default:
                    break;
            }
            return Ok(new
            {
                code = 1,
                //data = result,
                message = string.Format("终止后勤")

            });
        }


        public class Operation
        {
            public string accountID;
            public string key; 
            public string operationID;
            public string TeamID;
        }
    }
}
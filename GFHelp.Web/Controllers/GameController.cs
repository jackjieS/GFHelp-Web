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


        /// <summary>
        /// Game控制器
        /// </summary>
        public GameController()
        {

        }

        private bool isAdmin(string username)
        {
            return DataBase.DataBase.isUserAdmin(username);
        }

        /// <summary>
        /// 获取游戏实例的详细信息
        /// </summary>
        /// <returns></returns>
        [Route("/Game/GetGameDetails")]
        [HttpPost]
        public IActionResult GetGameDetails([FromBody] string Accountid)
        {

            //string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var details = Core.Management.Data.GetWebData(Accountid);

            return Ok(new
            {
                code = 1,
                data = details,
            });
        }

        /// <summary>
        /// 获取游戏实例的状态
        /// </summary>
        /// <returns></returns>
        [Route("/Game/GetGameStatus")]
        [HttpPost]
        public IActionResult GetGameStatus([FromBody] string Accountid)
        {

            //string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var status = Core.Management.Data.GetWebStatus(Accountid);
            return Ok(new
            {
                code = 1,
                data = status,
            });
        }





        /// <summary>
        /// 游戏登陆
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [Route("/Game/Login")]
        [HttpPost]
        public IActionResult Login([FromBody] Account account)
        {
            //加入控制符
            Core.Management.Data.data.getDataByID(account.GameID).eventAction.Login();
            return Ok(new
            {
                code = 1,
                //data = result,
                message = string.Format("正在登陆 {0}", account.GameID)

            });
        }
       
        /// <summary>
        /// Test
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [Route("/Game/Test")]
        [HttpPost]
        public IActionResult Test([FromBody] Account account)
        {
            //加入控制符
            Core.Management.Data.data.getDataByID(account.GameID).eventAction.Test();
            return Ok(new
            {
                code = 1,
                //data = result,
                message = string.Format("正在登陆 {0}", account.GameID)

            });
        }


        /// <summary>
        /// [josn] accountID,后勤KEY, 后勤ID,后勤梯队ID sample:{"accountID":"13201546359",,"operationID":5,"TeamID":1}
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
            Operation_Act_Info.Data data = new Operation_Act_Info.Data();
            data.team_id = text.TeamID;
            data.operation_id = text.operationID;
            Core.Management.Data.data.getDataByID(accountID).operation_Act_Info.Start(data);
            return Ok(new
            {
                code = 1,
                //data = result,
                message = string.Format("开始后勤")

            });
        }


        /// <summary>
        /// [josn] accountID,后勤KEY, 后勤ID, sample:{"accountID":"13201546359",,"operationID":5,"TeamID":1}
        /// </summary>
        /// <param text="json"> json</param>
        /// <returns></returns>
        [Route("/Game/AbortOperation")]
        [HttpPost]
        public IActionResult AbortOperation([FromBody] Operation text)
        {
            string accountID = text.accountID.ToString();
            Operation_Act_Info.Data data = new Operation_Act_Info.Data();
            data.team_id = text.TeamID;
            data.operation_id = text.operationID;
            Core.Management.Data.data.getDataByID(accountID).operation_Act_Info.Abort(data);
            return Ok(new
            {
                code = 1,
                //data = result,
                message = string.Format("终止后勤")

            });
        }


        /// <summary>
        /// 开始作战
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        [Route("/Game/StartBattle")]
        [HttpPost]
        public IActionResult StartBattle([FromBody] Core.Action.BattleBase.Battle bs)
        {
            //加入控制符
            if (bs.Teams.Count() == 0)
            {
                return Ok(new
                {
                    code = -1,
                    data = "error",
                    message = string.Format("0 梯队", bs.accountID)

                });
                
            }


            if (!Core.Management.Data.data.ContainsKey(bs.accountID))
            {
                return Ok(new
                {
                    code = -1,
                    data = "error",
                    message = string.Format("不存在 {0} 游戏实例", bs.accountID)

                });
            }
            Core.Action.BattleBase.Normal_MissionInfo normal_MissionInfo = new Core.Action.BattleBase.Normal_MissionInfo(Core.Management.Data.data.getDataByID(bs.accountID), bs);
            Core.Management.Data.data.getDataByID(bs.accountID).normal_MissionInfo = normal_MissionInfo;
            Core.Management.Data.data.getDataByID(bs.accountID).eventAction.TaskBattle_1();
            return Ok(new
            {
                code = 1,
                data = bs,
                message = "开始作战"

            });
        }

        /// <summary>
        /// 终止作战
        /// </summary>
        /// <param name="Accountid"> 游戏账户id</param>
        /// <returns></returns>
        [Route("/Game/AbortBattle")]
        [HttpPost]
        public IActionResult AbortBattle([FromBody] Core.Action.BattleBase.Battle bs)
        {
            //加入控制符
            if (!Core.Management.Data.data.ContainsKey(bs.accountID))
            {
                return Ok(new
                {
                    code = -1,
                    data = "error",
                    message = string.Format("不存在 {0} 游戏实例", bs.accountID)

                });
            }
            Core.Management.Data.data.getDataByID(bs.accountID).normal_MissionInfo.Loop = false;


            return Ok(new
            {
                code = 1,
                data =bs,
                message = "终止作战"

            });
        }
        /// <summary>
        /// 
        /// </summary>
        public class Account
        {
            public string username;
            public string GameID;
        }

        /// <summary>
        /// 
        /// </summary>
        public class Operation
        {
            public string accountID;
            public int operationID;
            public int TeamID;
        }

    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GFHelp.Web.Data;
using GFHelp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GFHelp.Web.Controllers
{

    /// <summary>
    /// 认证与登陆
    /// </summary>
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public AuthController(/*UserManager<ApplicationUser> userManager*/)
        {
            //this.userManager = userManager;
        }

        private async Task<bool>isUserNameExist(string username)
        {
            return DataBase.DataBase.isUserNameExist(username);
        }

        private async Task<bool> CheckUser(string username,string password)
        {
            return DataBase.DataBase.CheckUser(username, password);
        }
        private bool creatWebAccount(DataBase.LoginModel accInfo)
        {
            return DataBase.DataBase.creatWebAccount(accInfo);
        }
        private JwtSecurityToken CreateToken(string username)
        {
            var claims = new[]
{
                    new Claim(JwtRegisteredClaimNames.Sub,username),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

            var token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.UtcNow.AddHours(6),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)

                );

            return token;

        }

        /// <summary>
        /// 网站登陆
        /// Username
        /// Password
        /// </summary>
        /// <param name="model.Username"> 123 </param>
        /// <returns>123</returns>
        [Route("[action]")]
        [HttpPost]

        public async Task<IActionResult> WebLogin([FromBody]DataBase.LoginModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
                return Ok(new
                {
                    code = -1,
                    message = "登陆失败"

                });
            bool isUser = await CheckUser(model.Username, model.Password);

            if (isUser)
            {
                var token = CreateToken(model.Username);

                return Ok(new
                {
                    code = 1,
                    data = new JwtSecurityTokenHandler().WriteToken(token),
                    message = "登陆成功"

                });
            }

            return Ok(new
            {
                code = -1,
                message = "登陆失败"

            });
        }


        /// <summary>
        /// 网站注册
        /// Username
        /// Password
        /// </summary>
        /// <param name="model.Username"> 123 </param>
        /// <returns>123</returns>
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> WebRegister([FromBody]DataBase.LoginModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
                return Ok(new
                {
                    code = -1,
                    message = "注册失败"

                });
        
            if (await isUserNameExist(model.Username))
                return Ok(new
                {
                    code = -1,
                    message = model.Username + " 已存在"

                });


            if (creatWebAccount(model))
            {
                var token = CreateToken(model.Username);
                return Ok(new
                {
                    code = 1,
                    data = new JwtSecurityTokenHandler().WriteToken(token),
                    message = "注册成功"

                });
            }
            else
            {
                return Ok(new
                {
                    code = -1,
                    message = "注册失败"

                });
            }





        }




    }
}
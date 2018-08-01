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
        private appContext context;
        public AuthController(UserManager<ApplicationUser> userManager, appContext context)
        {
            this.userManager = userManager;
            this.context = context;

        }

        private async Task<bool>isUserNameExist(string username)
        {

            foreach (var item in context.AccountInfo.ToList())
            {
                if (item.Username == username) { return true; }
            }
            return false;
        }

        private async Task<bool> CheckUser(string username,string password)
        {

            foreach (var item in context.AccountInfo.ToList())
            {
                if (item.Username == username && item.Password == password) { return true; }
            }
            return false;

        }
        private bool creatWebAccount(LoginModel accInfo)
        {
            context.AccountInfo.Add(new Data.AccountInfo
            {
                Username = accInfo.Username,
                Password = accInfo.Password,
                Policy="2"
            });
            var count = context.SaveChanges();

            if (count != 0)
            {
                return true;
            }
            return false;
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
        public async Task<IActionResult> WebLogin([FromBody]LoginModel model)
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
        public async Task<IActionResult> WebRegister([FromBody]LoginModel model)
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
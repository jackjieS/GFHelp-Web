using GFHelp.Core.Management;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFHelp.Web.Data
{
    /// <summary>
    /// 数据库初始化
    /// </summary>
    public static class SeedDatabase
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<appContext>();
            Task cd = new Task(() => Loop.CountDown());
            cd.Start();

            foreach (var item in context.GameAccount.ToList())
            {
                UserData ud = new UserData();
                ud.CreatGameAccount(item);
                Core.Management.Data.seed(ud);
            }
            foreach (var item in context.AccountInfo.ToList())
            {
                Core.SystemOthers.ConfigData.WebUserData.Add(item);

            }
        }

    }
}

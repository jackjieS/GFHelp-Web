
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using System.Threading.Tasks;

namespace GFHelp.Web.Data
{
    public class appContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AccountInfo> AccountInfo { get; set; }
        public DbSet<GameAccount> GameAccount { get; set; }
        public appContext(DbContextOptions<appContext> options)
    : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //var directory = System.IO.Directory.GetCurrentDirectory();
            //string con = "Data Source=" +  @"\database.db";
            //optionsBuilder.UseSqlite(con);
            //this.app
        }



        public async Task<bool>CheckUserNameAsync(string username)
        {

            //var context = serviceProvider.GetRequiredService<appContext>();
            //var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            //context.Database.EnsureCreated();

            //if (!context.userInfos.Any())
            //{
            //    context.userInfos.Add(new UserInfo
            //    {
            //        id = 0,
            //        Username = "admin",
            //        Password = "admin",
            //        Lv = 0,
            //    });
            //    var count = context.SaveChanges();
            //};

            return false;
        }


    }

    /// <summary>
    /// 网站账户信息
    /// </summary>
    public class AccountInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Key]
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public string Policy { get; set; }
    }
    public class GameAccount : Core.Management.GameAccountBase
    {


    }


}

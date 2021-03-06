﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GFHelp.Core.SystemManager;
using GFHelp.Web.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace GFHelp.Web
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        static string currentDirectory = Core.SystemManager.ConfigData.currentDirectory;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();
            services.AddSignalR();




            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddDefaultTokenProviders();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "GFHelp API - V1",
                        Version = "v1",
                        Description = " 这是 项目GFHelp API 的测试助手。 所有 API 接口都是用JWT 身份验证\n\r" +
                        "首先你需要使用 /Auth/WebLogin 进行网站登陆 ( 账号 admin 密码 admin) \n\r" +
                        "在 Authorize 按钮里的 value 填入 密匙 格式 Bearer {token}\n\r " +
                        "范例  Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCbalabalabalabalabalabalabalabalabalabala\n\r"
                    }
                 );

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "GFHelpapi.xml");
                c.IncludeXmlComments(filePath);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "http://oec.com",
                    ValidIssuer = "http://oec.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"))
                };



            });


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseAuthentication();


            var staticfile = new StaticFileOptions();

            staticfile.FileProvider = new PhysicalFileProvider(currentDirectory + @"\wwwroot");//指定目录 这里指定C盘,也可以是其它目录
            app.UseStaticFiles(staticfile);

            app.UseCors(builder => builder
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .WithOrigins("https://*.nai-ve.top")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());





            app.UseSignalR(u => u.MapHub<Chat>("/chathub"));
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Auth}/{action=WebLogin}/{id?}");
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            GameServerStatus checkGameServer = new GameServerStatus();
            Core.SystemManager.ConfigData.Initialize();
            Core.Init.InitFromDatabase();
            Core.SignaIRClient.init();
            NetBase.webProxy.Init();
            ServicePointManager.DefaultConnectionLimit = 512;

        }
    }
}
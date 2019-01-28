using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangHeWebSite.Areas.Admin.Base;
using ChangHeWebSite.Areas.Admin.Base.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChangHeWebSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });*/


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            /*添加Session服务*/
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(3600);
                option.Cookie.HttpOnly = true;
            });
            /*数据库连接字符串*/
            services.AddDbContext<EFContext>(x=>x.UseSqlServer(Configuration.GetConnectionString("default")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession(); //使用Session

            app.UseMvc(routes =>
            {
                /*前端路由*/
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Index}/{action=Index}/{id?}");
                /*后台路由*/
                routes.MapAreaRoute(
                    "Admin",
                    "Admin",
                    "Admin/{controller=ManagementSystem}/{action=ManagementSystem}/{id?}");
            });

            /*配置数据传输对象映射关系*/
            AutoMapperConfiguration.InitializeMapper();
        }
    }
}

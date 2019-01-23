using System;
using System.Threading.Tasks;
using ChangHeWebSite.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace ChangHeWebSite.Areas.Admin.Base.Database
{
    public class DatabaseInitialize
    {
        /// <summary>
        /// 初始化数据库方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="serviceProvider"></param>
        public async static Task InitializeDatabase(IServiceProvider service)
        {
            using (var serviceScope = service.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<EFContext>();

                /*确认数据库不为空*/
                if (context.Database != null && context.Database.EnsureCreated())
                {
                    /*初始化公司信息*/
                    if (!context.Company.Any())
                    {
                        context.Company.Add(new CompanyInfo()
                        {
                            CompanyName = "111",
                            CompanyCopyright = "111",
                            CompanyEmail = "111",
                            CompanyDescription = "111",
                            CompanyLogo = "111",
                            CompanyKeyWord = "111",
                            CompanyLocation = "111",
                            CompanyPhone = "111",
                            CompanyLatitudeLongitude = "111",
                            CompanyQRcode = "111"
                        });
                    }

                    /*初始化管理账号密码*/
                    if (!context.Manager.Any())
                    {
                        context.Manager.Add(new Manager()
                        {
                            ManagerName = "admin",
                            ManagerPassword = "21232f297a57a5a743894a0e4a801fc3"
                        });
                    }

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
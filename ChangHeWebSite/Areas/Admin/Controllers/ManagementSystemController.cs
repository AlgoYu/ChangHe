using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ChangHeWebSite.Areas.Admin.Base;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Areas.Admin.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    /// <summary>
    /// 后台管理控制器
    /// </summary>
    public class ManagementSystemController : ManagementSystemControllerBase
    {
        private readonly EFContext _db;

        public ManagementSystemController(EFContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 后台管理主页
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ManagementSystem()
        {
            ViewData["ManagerName"] = HttpContext.Session.GetString("Token");
            return View();
        }
    }
}
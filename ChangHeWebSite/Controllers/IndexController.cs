using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Areas.Admin.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChangHeWebSite.Controllers
{
    /// <summary>
    /// 主页控制器
    /// </summary>
    public class IndexController : Controller
    {
        private readonly EFContext _db;

        public IndexController(EFContext db)
        {
            _db = db;
        }
        /// <summary>
        /// 主页视图返回
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            ResponseTemplate response = new ResponseTemplate();
            response.Data = await _db.Company.FirstOrDefaultAsync();
            response.Success = true;
            return View(response);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    /// <summary>
    /// 新闻控制器
    /// </summary>
    public class NewsController : Controller
    {
        /// <summary>
        /// 返回新闻视图
        /// </summary>
        /// <returns></returns>
        public IActionResult NewsManager()
        {
            return View();
        }
    }
}
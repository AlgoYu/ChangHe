using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChangHeWebSite.Controllers
{
    /// <summary>
    /// 主页控制器
    /// </summary>
    public class IndexController : Controller
    {
        /// <summary>
        /// 主页视图返回
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChangHeWebSite.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult News()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
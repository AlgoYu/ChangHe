using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    public class ManagementSystemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
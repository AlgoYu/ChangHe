using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangHeWebSite.Areas.Admin.Base.Database;
using Microsoft.AspNetCore.Mvc;

namespace ChangHeWebSite.Controllers
{
    public class MapController : Controller
    {
        private readonly EFContext _db;

        public MapController(EFContext db)
        {
            _db = db;
        }

        public IActionResult Map()
        {
            
            return View();
        }
    }
}
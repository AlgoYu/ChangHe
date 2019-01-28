using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangHeWebSite.Areas.Admin.Filter;
using Microsoft.AspNetCore.Mvc;

namespace ChangHeWebSite.Areas.Admin.Base
{
    [TokenFilter]
    [Area("admin")]
    public class ManagementSystemControllerBase : Controller
    {

    }
}
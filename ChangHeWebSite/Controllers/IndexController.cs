using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Models;
using ChangHeWebSite.Models.Dto;
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
        public IActionResult Index()
        {
            FrontDto dto = new FrontDto();
            dto.CompanyDto = Mapper.Map<FrontCompanyInfoDto>(_db.Company.FirstOrDefault());
            return View(dto);
        }
    }
}
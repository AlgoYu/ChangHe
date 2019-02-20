using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Areas.Admin.Models;
using ChangHeWebSite.Areas.Admin.Models.Dto;
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
            dto.Newses = _db.Newses.Take(4).ToList();
            dto.Covers = Mapper.Map<List<FrontImageDto>>(_db.Images.Where(i => i.ImageType == ImageType.Cover).ToList());
            return View(dto);
        }
        /// <summary>
        /// 插入一条信息数据
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public JsonResult InsertMessage(Message message)
        {
            ResponseTemplate response = new ResponseTemplate();
            _db.Messages.Add(message);
            response.Data = _db.SaveChanges();
            response.Success = true;
            return Json(response);
        }
    }
}
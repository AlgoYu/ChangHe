using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Areas.Admin.Models.Dto;
using ChangHeWebSite.lib;
using ChangHeWebSite.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChangHeWebSite.Controllers
{
    public class NewsController : Controller
    {
        private readonly EFContext _db;

        public NewsController(EFContext db)
        {
            _db = db;
        }

        public IActionResult News()
        {
            FrontDto dto = new FrontDto();
            dto.CompanyDto = Mapper.Map<FrontCompanyInfoDto>(_db.Company.FirstOrDefault());
            dto.NewsClassifications = _db.NewsClassifications.ToList();
            dto.Newses = _db.Newses.Take(10).ToList();
            return View(dto);
        }
        /// <summary>
        /// 返回新闻数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult ResponseNewses(NewsClassificationPageRequest request)
        {
            PageResponse response = new PageResponse();
            response.CurrentPage = request.Page;
            var datas = _db.Newses.WhereIf(request.NewsClassificationId.HasValue, n => n.NewsClassificationId == request.NewsClassificationId);
            response.Total = datas.Count();
            response.Data = datas.Skip((request.Page - 1) * request.Limit).Take(request.Limit).ToList();
            return Json(response);
        }

        public IActionResult Detail(int id)
        {
            FrontDto dto = new FrontDto();
            dto.CompanyDto = Mapper.Map<FrontCompanyInfoDto>(_db.Company.FirstOrDefault());
            dto.NewsClassifications = _db.NewsClassifications.ToList();
            dto.NewsDto = Mapper.Map<FrontNewsDto>(_db.Newses.SingleOrDefault(x => x.Id == id));
            _db.Newses.Where(n => n.NewsClassificationId == id).ToList();
            return View(dto);
        }
    }
}
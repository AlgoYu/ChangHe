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

        public IActionResult News(int? newsClassificationId)
        {
            FrontDto dto = new FrontDto();
            dto.CompanyDto = Mapper.Map<FrontCompanyInfoDto>(_db.Company.FirstOrDefault());
            dto.NewsClassifications = _db.NewsClassifications.ToList();
            if (newsClassificationId!=null)
            {
                dto.CurrentNewsClassification = newsClassificationId;
            }
            dto.Newses = _db.Newses.WhereIf(newsClassificationId != null,n=>n.NewsClassificationId == newsClassificationId).Take(10).ToList();
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
        /// <summary>
        /// 新闻详情的数据返回
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IActionResult Detail(FrontNewsDetailRequestDto request)
        {
            FrontDto dto = new FrontDto();
            dto.CompanyDto = Mapper.Map<FrontCompanyInfoDto>(_db.Company.FirstOrDefault());
            dto.NewsClassifications = _db.NewsClassifications.ToList();
            dto.CurrentNewsClassification = request.NewsClassificationId;
            var datas = _db.Newses.WhereIf(request.NewsClassificationId != null,
                n => n.NewsClassificationId == request.NewsClassificationId).ToList();
            //dto.NewsDto = Mapper.Map<FrontNewsDto>(_db.Newses.SingleOrDefault(x => x.Id == id));
            /*找出上一篇文章和下一篇文章*/
            for (int j = 0; j < datas.Count; j++)
            {
                if (datas[j].Id == request.NewsId)
                {
                    dto.NewsDto = Mapper.Map<FrontNewsDto>(datas[j]);
                    if (j>0)
                    {
                        dto.PreviousNews = datas[j - 1];
                    }

                    if (j < datas.Count-1)
                    {
                        dto.NextNews = datas[j + 1];
                    }

                    break;
                }
            }
            return View(dto);
        }
    }
}
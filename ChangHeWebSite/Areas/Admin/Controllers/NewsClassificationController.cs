using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Areas.Admin.Models;
using ChangHeWebSite.Areas.Admin.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    public class NewsClassificationController : Controller
    {
        private readonly EFContext _db;

        public NewsClassificationController(EFContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 返回新闻分类管理视图
        /// </summary>
        /// <returns></returns>
        public IActionResult NewsClassificationManager()
        {
            return View();
        }
        /// <summary>
        /// 分页返回当前分类数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult NewsClassifications(PageRequest request)
        {
            PageResponse response = new PageResponse();
            response.Success = true;
            response.CurrentPage = request.Page;
            response.Total = _db.NewsClassifications.Count();
            response.Data = _db.NewsClassifications.Skip((request.Page - 1) * request.Limit).Take(request.Limit).ToList();
            return Json(response);
        }
        /// <summary>
        /// 新增一个新闻分类
        /// </summary>
        /// <param name="newsClassification"></param>
        /// <returns></returns>
        public async Task<JsonResult> InsertNewsClassification(NewsClassification newsClassification)
        {
            _db.NewsClassifications.Add(newsClassification);
            ResponseTemplate response = new ResponseTemplate();
            response.Success = true;
            response.Data = await _db.SaveChangesAsync();
            return Json(response);
        }
        /// <summary>
        /// 批量删除新闻分类
        /// </summary>
        /// <param name="newsClassifications"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteNewsClassifications(List<NewsClassification> newsClassifications)
        {
            _db.NewsClassifications.RemoveRange(newsClassifications);
            ResponseTemplate response = new ResponseTemplate();
            response.Success = true;
            response.Data = await _db.SaveChangesAsync();
            return Json(response);
        }
        /// <summary>
        /// 更新新闻分类
        /// </summary>
        /// <param name="newsClassification"></param>
        /// <returns></returns>
        public async Task<JsonResult> UpdateNewsClassification(NewsClassification newsClassification)
        {
            _db.NewsClassifications.Update(newsClassification);
            ResponseTemplate response = new ResponseTemplate();
            response.Success = true;
            response.Data = await _db.SaveChangesAsync();
            return Json(response);
        }
    }
}
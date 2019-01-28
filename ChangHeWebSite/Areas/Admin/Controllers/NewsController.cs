using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChangHeWebSite.Areas.Admin.Base;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Areas.Admin.Models;
using ChangHeWebSite.Areas.Admin.Models.Dto;
using ChangHeWebSite.lib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    /// <summary>
    /// 新闻控制器
    /// </summary>
    public class NewsController : ManagementSystemControllerBase
    {
        private readonly EFContext _db;

        public NewsController(EFContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 返回新闻管理视图
        /// </summary>
        /// <returns></returns>
        public IActionResult NewsManager()
        {
            return View();
        }
        /// <summary>
        /// 返回新闻发布视图
        /// </summary>
        /// <returns></returns>
        public IActionResult ReleaseNews()
        {
            ReleaseNewsDto dto = new ReleaseNewsDto();
            dto.NewsClassifications = _db.NewsClassifications.ToList();
            return View(dto);
        }
        /// <summary>
        /// 返回新闻修改视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditNews(int id)
        {
            UpdateNewsDto dto = new UpdateNewsDto();
            dto.News = _db.Newses.SingleOrDefault(n => n.Id == id);
            dto.NewsClassifications = _db.NewsClassifications.ToList();
            return View(dto);
        }
        /// <summary>
        /// 插入新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public async Task<JsonResult> InsertNews(News news)
        {
            _db.Newses.Add(news);
            ResponseTemplate response = new ResponseTemplate();
            response.Success = true;
            response.Data = await _db.SaveChangesAsync();
            return Json(response);
        }
        /// <summary>
        /// 分页查询新闻数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<JsonResult> SelectNewses(PageRequest request)
        {
            PageResponse response = new PageResponse();
            var datas = _db.Newses.WhereIf(!string.IsNullOrEmpty(request.KeyWord),n=>n.NewsTitle.Contains(request.KeyWord)||n.NewsContent.Contains(request.KeyWord)).Skip((request.Page - 1) * request.Limit).Take(request.Limit).Include(n=>n.NewsClassification).ToList();
            response.Total = _db.Newses.Count();
            response.Data = Mapper.Map<List<NewsTableDto>>(datas);
            response.CurrentPage = request.Page;
            response.Success = true;
            return Json(response);
        }

        /// <summary>
        /// 批量删除新闻
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteNewses(List<News> newses)
        {
            _db.Newses.RemoveRange(newses);
            ResponseTemplate response = new ResponseTemplate();
            response.Data = await _db.SaveChangesAsync();
            response.Success = true;
            return Json(response);
        }

        /// <summary>
        /// 更新新闻
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<JsonResult> UpdateNews(News news)
        {
            _db.Newses.Update(news);
            ResponseTemplate response = new ResponseTemplate();
            response.Data = await _db.SaveChangesAsync();
            response.Success = true;
            return Json(response);
        }
    }
}
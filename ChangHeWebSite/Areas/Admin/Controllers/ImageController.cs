using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangHeWebSite.Areas.Admin.Base;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Areas.Admin.Models;
using ChangHeWebSite.Areas.Admin.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    public class ImageController : ManagementSystemControllerBase
    {
        private readonly EFContext _db;

        public ImageController(EFContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 轮播图管理
        /// </summary>
        /// <returns></returns>
        public IActionResult CarouselManager()
        {
            BackstageDto dto = new BackstageDto();
            dto.Covers = _db.Images.Where(i => i.ImageType == ImageType.Cover).ToList();
            return View(dto);
        }
        /// <summary>
        /// 增加封面接口
        /// </summary>
        /// <param name="cover"></param>
        /// <returns></returns>
        public JsonResult InsertCover(Image cover)
        {
            cover.ImageType = ImageType.Cover;
            _db.Images.Add(cover);
            ResponseTemplate response = new ResponseTemplate();
            response.Success = true;
            response.Data = _db.SaveChanges();
            return Json(response);
        }
        /// <summary>
        /// 删除封面接口
        /// </summary>
        /// <param name="cover"></param>
        /// <returns></returns>
        public JsonResult DeleteCover(List<Image> covers)
        {
            _db.Images.RemoveRange(covers);
            ResponseTemplate response = new ResponseTemplate();
            response.Success = true;
            response.Data = _db.SaveChanges();
            return Json(response);
        }
        /// <summary>
        /// 修改封面接口
        /// </summary>
        /// <param name="cover"></param>
        /// <returns></returns>
        public JsonResult UpdateCover(Image cover)
        {
            cover.ImageType = ImageType.Cover;
            _db.Images.Update(cover);
            ResponseTemplate response = new ResponseTemplate();
            response.Success = true;
            response.Data = _db.SaveChanges();
            return Json(response);
        }
        /// <summary>
        /// 查询封面接口
        /// </summary>
        /// <param name="cover"></param>
        /// <returns></returns>
        public JsonResult SelectCover(PageRequest request)
        {
            PageResponse response = new PageResponse();
            var data = _db.Images.Where(i => i.ImageType == ImageType.Cover).Skip((request.Page - 1) * request.Limit)
                .Take(request.Limit);
            response.Total = data.Count();
            response.Data = data.ToList();
            response.CurrentPage = request.Page;
            response.Success = true;
            return Json(response);
        }
    }
}
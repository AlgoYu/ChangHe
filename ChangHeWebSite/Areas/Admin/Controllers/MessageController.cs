using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ChangHeWebSite.Areas.Admin.Base;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Areas.Admin.Models;
using ChangHeWebSite.Areas.Admin.Models.Dto;
using ChangHeWebSite.lib;
using Microsoft.AspNetCore.Mvc;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    public class MessageController : ManagementSystemControllerBase
    {
        private readonly EFContext _db;

        public MessageController(EFContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult MessageManager()
        {

            return View();
        }
        /// <summary>
        /// 查询留言
        /// </summary>
        /// <returns></returns>
        public JsonResult SelectMessages(PageRequest request)
        {
            PageResponse response = new PageResponse();
            response.CurrentPage = request.Page;
            response.Total = _db.Messages.Count();
            response.Data = Mapper.Map<List<MessageDto>>(_db.Messages.WhereIf(!string.IsNullOrEmpty(request.KeyWord),m=>m.Name.Contains(request.KeyWord) || m.Content.Contains(request.KeyWord)||m.Email.Contains(request.KeyWord) || m.Phone.Contains(request.KeyWord)).Skip((request.Page - 1) * request.Limit).Take(request.Limit).ToList());
            response.Success = true;
            return Json(response);
        }
        /// <summary>
        /// 删除留言
        /// </summary>
        /// <returns></returns>
        public JsonResult DeleteMessages(List<Message> messages)
        {
            ResponseTemplate response = new ResponseTemplate();
            _db.Messages.RemoveRange(messages);
            response.Data = _db.SaveChanges();
            response.Success = true;
            return Json(response);
        }
        /// <summary>
        /// 已经阅读
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult ReadMessage(int id)
        {
            ResponseTemplate response = new ResponseTemplate();
            var data = _db.Messages.SingleOrDefault(m => m.Id == id);
            data.IsRead = IsRead.AlreadyRead;
            response.Success = true;
            response.Data = _db.SaveChanges();
            return Json(response);
        }
    }
}
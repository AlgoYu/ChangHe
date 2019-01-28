using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangHeWebSite.Areas.Admin.Base;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Areas.Admin.Models;
using ChangHeWebSite.Areas.Admin.Models.Dto;
using ChangHeWebSite.lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    public class LoginController : ManagementSystemControllerBase
    {
        private readonly EFContext _db;

        public LoginController(EFContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 返回登录视图
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 验证登录账号
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public async Task<JsonResult> Verify(LoginInfoDto logoInfo)
        {
            ResponseTemplate response = new ResponseTemplate();
            if (string.IsNullOrEmpty(logoInfo.VerificationCode) || logoInfo.VerificationCode != HttpContext.Session.GetString("VerificationCode"))
            {
                response.Message = "验证码错误！";
                return Json(response);
            }
            var manager = await _db.Manager.SingleOrDefaultAsync(m => m.ManagerName == logoInfo.UserName);
            if (manager != null && manager.ManagerPassword == logoInfo.PassWord)
            {
                response.Success = true;
                response.Message = "登录成功！";
                HttpContext.Session.SetString("Identification",manager.ManagerName);
            }
            else
            {
                response.Message = "账号或密码无效！";
            }
            return Json(response);
        }
    }
}
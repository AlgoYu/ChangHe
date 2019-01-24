using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangHeWebSite.Areas.Admin.Base;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Areas.Admin.Models;
using ChangHeWebSite.Areas.Admin.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    /// <summary>
    /// 公司信息管理控制器
    /// </summary>
    public class CompanyInfoController : ManagementSystemControllerBase
    {
        private readonly EFContext _db;

        public CompanyInfoController(EFContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 公司信息管理页面
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CompanyManager()
        {
            var data = await _db.Company.FirstOrDefaultAsync();
            ResponseTemplate response = new ResponseTemplate();
            response.Success = true;
            response.Data = data;
            return View(response);
        }
        /// <summary>
        /// 公司地图定位管理页面
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CompanyMapManager()
        {
            var data = await _db.Company.FirstOrDefaultAsync();
            PointDto dto = new PointDto();
            dto.Lng = data.Lng;
            dto.Lat = data.Lat;
            return View(dto);
        }
        /// <summary>
        /// 更新公司信息
        /// </summary>
        /// <param name="companyInfo"></param>
        /// <returns></returns>
        public async Task<JsonResult> UpdateCompanyInfo(CompanyInfo companyInfo)
        {
            _db.Company.Update(companyInfo);
            ResponseTemplate response = new ResponseTemplate();
            response.Success = true;
            response.Data = await _db.Company.FirstOrDefaultAsync();
            return Json(response);
        }

        /// <summary>
        /// 更新公司信息
        /// </summary>
        /// <param name="companyInfo"></param>
        /// <returns></returns>
        public async Task<JsonResult> UpdateCompanyLocation(PointDto point)
        {
            var company = await _db.Company.FirstOrDefaultAsync();
            company.Lng = point.Lng;
            company.Lat = point.Lat;
            ResponseTemplate response = new ResponseTemplate();
            response.Success = true;
            response.Data = await _db.SaveChangesAsync();
            return Json(response);
        }
    }
}
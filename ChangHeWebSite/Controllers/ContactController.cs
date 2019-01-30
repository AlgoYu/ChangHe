using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChangHeWebSite.Areas.Admin.Base.Database;
using ChangHeWebSite.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ChangHeWebSite.Controllers
{
    public class ContactController : Controller
    {
        private readonly EFContext _db;

        public ContactController(EFContext db)
        {
            _db = db;
        }

        public IActionResult Contact()
        {
            FrontDto dto = new FrontDto();
            dto.CompanyDto = Mapper.Map<FrontCompanyInfoDto>(_db.Company.FirstOrDefault());
            return View(dto);
        }
    }
}
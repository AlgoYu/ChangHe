using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangHeWebSite.Areas.Admin.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UEditor.Core;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    /// <summary>
    /// 这个类是为UEditor创建的后端类
    /// </summary>
    public class UEditorController : ManagementSystemControllerBase
    {
        private readonly UEditorService _ueditorService;
        public UEditorController(UEditorService ueditorService)
        {
            this._ueditorService = ueditorService;
        }

        //如果是API，可以按MVC的方式特别指定一下API的URI
        [HttpGet, HttpPost]
        public ContentResult Upload()
        {
            var response = _ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result, response.ContentType);
        }
    }
}
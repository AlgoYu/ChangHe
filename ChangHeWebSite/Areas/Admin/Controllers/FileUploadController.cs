using System;
using System.IO;
using System.Linq;
using ChangHeWebSite.Areas.Admin.Base;
using ChangHeWebSite.Areas.Admin.Models.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    /// <summary>
    /// 文件上传控制器
    /// </summary>
    public class FileUploadController : ManagementSystemControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileUploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 上传接口
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadImage(IFormFile file)
        {
            if (file==null)
            {
                return Json(new ResponseTemplate()
                {
                    Message = "没有检查到文件"
                });
            }

            //var file = files[0];
            var extName = Path.GetExtension(file.FileName);
            var imgExts = new[] { ".jpg", ".bmp", ".png", ".gif" };

            if (imgExts.All(ext => ext != extName))
            {
                return Json(new ResponseTemplate()
                {
                    Message = "文件格式不正确"
                });
            }

            var saveDirectory = "/upload/images/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmsssfff") + extName;
            var absSavePath = _hostingEnvironment.WebRootPath + saveDirectory;
            var fullFileName = absSavePath + fileName;

            if (!Directory.Exists(absSavePath))
            {
                Directory.CreateDirectory(absSavePath);
            }

            using (FileStream fileStream = System.IO.File.Create(fullFileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            return Json(new ResponseTemplate()
            {
                Success = true,
                Data = saveDirectory + fileName
            });
        }
    }
}
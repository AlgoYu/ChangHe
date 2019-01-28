using ChangHeWebSite.Areas.Admin.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VerifyCode.Gif;

namespace ChangHeWebSite.Areas.Admin.Controllers
{
    /// <summary>
    /// 验证码生成类
    /// </summary>
    public class VerificationCodeController : ManagementSystemControllerBase
    {
        /// <summary>
        /// 返回二维码gir动图
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public FileResult VerificationCodeImage()
        {
            var vg = new VerificationGif(105, 36);
            var stream = vg.Create();

            HttpContext.Session.SetString("VerificationCode", vg.IdentifyingCode.ToLower());
            var codeBytes = stream.ToArray();
            stream.Close();

            return File(codeBytes, "image/gif");
        }
    }
}


using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChangHeWebSite.Areas.Admin.Filter
{
    /// <summary>
    /// 后台验证信息
    /// </summary>
    public class TokenFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor.FilterDescriptors.Any(x => x.Filter.GetType() == typeof(AllowAnonymousFilter)))
            {
                return;
            }

            if (context.HttpContext.Session.GetString("Token") == null)
            {
                context.HttpContext.Response.Redirect("/admin/Login/Login");

            }
            base.OnActionExecuting(context);
        }
    }
}
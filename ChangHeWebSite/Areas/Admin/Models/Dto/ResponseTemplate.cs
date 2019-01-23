using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangHeWebSite.Areas.Admin.Models.Dto
{
    /// <summary>
    /// 返回数据格式封装
    /// </summary>
    public class ResponseTemplate
    {
        /// <summary>
        /// 后台操作是否成功
        /// </summary>
        public Boolean Success { get; set; }
        /// <summary>
        /// 返回状态码
        /// </summary>
        public ResponseStatus Status { get; set; }
        /// <summary>
        /// 返回的信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public object Data { get; set; }
    }
}

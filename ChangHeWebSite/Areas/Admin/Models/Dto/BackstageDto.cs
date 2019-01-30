using System.Collections.Generic;

namespace ChangHeWebSite.Areas.Admin.Models.Dto
{
    /// <summary>
    /// 后台数据传输对象
    /// </summary>
    public class BackstageDto
    {
        /// <summary>
        /// 封面图片
        /// </summary>
        public List<Image> Covers { get; set; }
    }
}
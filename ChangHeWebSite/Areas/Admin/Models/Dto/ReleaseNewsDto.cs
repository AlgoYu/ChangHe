using System.Collections.Generic;

namespace ChangHeWebSite.Areas.Admin.Models.Dto
{
    /// <summary>
    /// 发布新闻传输对象
    /// </summary>
    public class ReleaseNewsDto
    {
        /// <summary>
        /// 分类信息
        /// </summary>
        public List<NewsClassification> NewsClassifications { get; set; }
    }
}
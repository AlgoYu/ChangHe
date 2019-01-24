using System.Collections.Generic;

namespace ChangHeWebSite.Areas.Admin.Models.Dto
{
    /// <summary>
    /// 更新新闻时候的数据传输对象
    /// </summary>
    public class UpdateNewsDto
    {
        /// <summary>
        /// 分类信息
        /// </summary>
        public List<NewsClassification> NewsClassifications { get; set; }
        /// <summary>
        /// 当前需要修改的新闻对象
        /// </summary>
        public News News { get; set; }
    }
}
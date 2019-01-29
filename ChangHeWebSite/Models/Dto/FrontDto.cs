using System.Collections.Generic;
using ChangHeWebSite.Areas.Admin.Models;

namespace ChangHeWebSite.Models.Dto
{
    /// <summary>
    /// 前端数据传输对象
    /// </summary>
    public class FrontDto
    {
        /// <summary>
        /// 公司信息
        /// </summary>
        public FrontCompanyInfoDto CompanyDto { get; set; }
        /// <summary>
        /// 新闻分类信息
        /// </summary>
        public List<NewsClassification> NewsClassifications { get; set; }
        /// <summary>
        /// 新闻信息
        /// </summary>
        public List<News> Newses { get; set; }
        /// <summary>
        /// 新闻详细信息
        /// </summary>
        public FrontNewsDto NewsDto { get; set; }
        /// <summary>
        /// 当前新闻分类
        /// </summary>
        public int? CurrentNewsClassification { get; set; }
    }
}
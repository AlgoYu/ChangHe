using System.Collections.Generic;

namespace ChangHeWebSite.Areas.Admin.Models
{
    /// <summary>
    /// 新闻分类
    /// </summary>
    public class NewsClassification
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 新闻分类名称
        /// </summary>
        public string NewsClassificationName { get; set; }
        /// <summary>
        /// 新闻关系映射
        /// </summary>
        public virtual ICollection<News> Newses{ get; set; }
    }
}
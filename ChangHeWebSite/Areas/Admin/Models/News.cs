using System;

namespace ChangHeWebSite.Areas.Admin.Models
{
    /// <summary>
    /// 新闻内容
    /// </summary>
    public class News
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 新闻封面
        /// </summary>
        public string NewsCover { get; set; }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string NewsTitle { get; set; }
        /// <summary>
        /// 新闻作者
        /// </summary>
        public string NewsAuthor { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string NewsContent { get; set; }
        /// <summary>
        /// 新闻分类
        /// </summary>
        public int NewsClassificationId { get; set; }
        /// <summary>
        /// 新闻分类虚拟关系映射
        /// </summary>
        public virtual NewsClassification NewsClassification { get; set; }

        /// <summary>
        /// 新闻创建时间
        /// </summary>
        public DateTime NewsCreateDate { get; set; } = DateTime.Now;
    }
}
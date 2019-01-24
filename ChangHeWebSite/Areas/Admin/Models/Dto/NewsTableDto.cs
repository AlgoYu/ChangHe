using System;

namespace ChangHeWebSite.Areas.Admin.Models.Dto
{
    /// <summary>
    /// 后台新闻表格数据传输对象
    /// </summary>
    public class NewsTableDto
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
        /// 所属新闻分类名称
        /// </summary>
        public String NewsClassificationName { get; set; }
        /// <summary>
        /// 新闻创建时间
        /// </summary>
        public DateTime NewsCreateDate { get; set; }
    }
}
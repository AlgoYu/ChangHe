using System;

namespace ChangHeWebSite.Models.Dto
{
    /// <summary>
    /// 前端新闻数据传输对象
    /// </summary>
    public class FrontNewsDto
    {
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
        /// 新闻创建时间
        /// </summary>
        public DateTime NewsCreateDate { get; set; }
    }
}
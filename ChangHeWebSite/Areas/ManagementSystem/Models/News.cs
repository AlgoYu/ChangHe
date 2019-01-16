namespace ChangHeWebSite.Areas.ManagementSystem.Models
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
        /// 新闻标题
        /// </summary>
        public string NewsTitle { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string NewsContent { get; set; }
        /// <summary>
        /// 新闻分类
        /// </summary>
        public int NewsClassification { get; set; }
    }
}
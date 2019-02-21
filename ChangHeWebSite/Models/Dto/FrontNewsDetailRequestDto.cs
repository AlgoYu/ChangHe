namespace ChangHeWebSite.Models.Dto
{
    /// <summary>
    /// 新闻内容请求数据传输对象
    /// </summary>
    public class FrontNewsDetailRequestDto
    {
        /// <summary>
        /// 当前请求的新闻ID
        /// </summary>
        public int NewsId { get; set; }
        /// <summary>
        /// 当前分类的ID
        /// </summary>
        public int? NewsClassificationId { get; set; }
    }
}
namespace ChangHeWebSite.Areas.Admin.Models.Dto
{
    public class PageRequest : RequestTemplate
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 限制条数
        /// </summary>
        public int Limit { get; set; }
    }
}
namespace ChangHeWebSite.Areas.Admin.Models.Dto
{
    public class PageRequest : RequestTemplate
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// 限制条数
        /// </summary>
        public int Limit { get; set; } = 10;
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord { get; set; }
    }
}
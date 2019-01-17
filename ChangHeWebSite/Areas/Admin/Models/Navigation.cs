namespace ChangHeWebSite.Areas.Admin.Models
{
    /// <summary>
    /// 导航栏
    /// </summary>
    public class Navigation
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 导航页名称
        /// </summary>
        public string NavigationName { get; set; }
        /// <summary>
        /// 导航页地址
        /// </summary>
        public string NavigationUrl { get; set; }
    }
}
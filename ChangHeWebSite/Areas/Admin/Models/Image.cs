namespace ChangHeWebSite.Areas.Admin.Models
{
    /// <summary>
    /// 首页图片
    /// </summary>
    public class Image
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 图片类型
        /// </summary>
        public ImageType ImageType { get; set; }
    }

    public enum ImageType
    {
        Cover = 1,  //轮播图
        Project = 2,    //服务项目
        Description = 3,    //公司介绍图片
        Domain = 4,  //服务领域图片
        Background = 5 //其他页面的背景图片
    }
}
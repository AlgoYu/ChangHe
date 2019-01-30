using ChangHeWebSite.Areas.Admin.Models;

namespace ChangHeWebSite.Models.Dto
{
    public class FrontImageDto
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 图片类型
        /// </summary>
        public ImageType ImageType { get; set; }
    }
}
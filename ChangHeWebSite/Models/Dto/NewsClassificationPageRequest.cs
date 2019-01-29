using ChangHeWebSite.Areas.Admin.Models.Dto;

namespace ChangHeWebSite.Models.Dto
{
    public class NewsClassificationPageRequest : PageRequest
    {
        /// <summary>
        /// 增加ID
        /// </summary>
        public int? NewsClassificationId { get; set; }
    }
}
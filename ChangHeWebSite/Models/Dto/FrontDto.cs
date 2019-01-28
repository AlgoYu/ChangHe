using ChangHeWebSite.Areas.Admin.Models;

namespace ChangHeWebSite.Models.Dto
{
    /// <summary>
    /// 前端数据传输对象
    /// </summary>
    public class FrontDto
    {
        /// <summary>
        /// 公司信息
        /// </summary>
        public FrontCompanyInfoDto CompanyDto { get; set; }
    }
}
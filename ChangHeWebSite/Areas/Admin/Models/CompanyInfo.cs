namespace ChangHeWebSite.Areas.Admin.Models
{
    /// <summary>
    /// 公司信息
    /// </summary>
    public class CompanyInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 公司名字
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司Logo
        /// </summary>
        public string CompanyLogo { get; set; }
        /// <summary>
        /// 公司描述
        /// </summary>
        public string CompanyDescription { get; set; }
        /// <summary>
        /// 公司版权
        /// </summary>
        public string CompanyCopyright { get; set; }
        /// <summary>
        /// 公司备案
        /// </summary>
        public string CompanyRecord { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyLocation { get; set; }
        /// <summary>
        /// 公司电话
        /// </summary>
        public string CompanyPhone { get; set; }
        /// <summary>
        /// 公司邮箱
        /// </summary>
        public string CompanyEmail { get; set; }
        /// <summary>
        /// 公司联系人
        /// </summary>
        public string CompanyContactPerson { get; set; }
        /// <summary>
        /// 公司QQ
        /// </summary>
        public string CompanyQQ { get; set; }
        /// <summary>
        /// 公司微信
        /// </summary>
        public string CompanyWeChat { get; set; }
        /// <summary>
        /// 公司二维码
        /// </summary>
        public string CompanyQRcode { get; set; }
        /// <summary>
        /// 公司关键字
        /// </summary>
        public string CompanyKeyWord { get; set; }
        /// <summary>
        /// 地图纬度
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// 地图经度
        /// </summary>
        public double Lng { get; set; }
    }
}
namespace ChangHeWebSite.Areas.Admin.Models
{
    /// <summary>
    /// 管理人员
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 管理人员姓名
        /// </summary>
        public string ManagerName { get; set; }
        /// <summary>
        /// 管理人员密码
        /// </summary>
        public string ManagerPassword { get; set; }
    }
}
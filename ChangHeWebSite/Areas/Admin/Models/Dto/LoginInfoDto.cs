namespace ChangHeWebSite.Areas.Admin.Models.Dto
{
    /// <summary>
    /// 登录信息
    /// </summary>
    public class LoginInfoDto
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 登录验证码
        /// </summary>
        public string VerificationCode { get; set; }
    }
}
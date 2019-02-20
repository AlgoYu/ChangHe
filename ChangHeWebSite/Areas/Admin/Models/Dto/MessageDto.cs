using System;

namespace ChangHeWebSite.Areas.Admin.Models.Dto
{
    /// <summary>
    /// 留言传输对象
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 留言者姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 留言者的手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 留言者的邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否已经阅读
        /// </summary>
        public string IsRead { get; set; }
        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
using System;
using System.ComponentModel;

namespace ChangHeWebSite.Areas.Admin.Models
{
    /// <summary>
    /// 留言信息
    /// </summary>
    public class Message
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
        public IsRead IsRead { get; set; } = IsRead.NoRead;
        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
    /// <summary>
    /// 是否已经阅读枚举类型
    /// </summary>
    public enum IsRead
    {
        [Description("暂未阅读")]
        NoRead = 0,
        [Description("已经阅读")]
        AlreadyRead = 1
    }
}
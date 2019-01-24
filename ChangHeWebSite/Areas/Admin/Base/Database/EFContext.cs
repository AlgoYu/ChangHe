using ChangHeWebSite.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace ChangHeWebSite.Areas.Admin.Base.Database
{
    /// <summary>
    /// 数据库环境
    /// </summary>
    public class EFContext : DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        public EFContext(DbContextOptions options) : base(options)
        {

        }
        /// <summary>
        /// 管理人员表
        /// </summary>
        public DbSet<Manager> Manager { get; set; }
        /// <summary>
        /// 系统信息表
        /// </summary>
        public DbSet<SystemInfo> System { get; set; }
        /// <summary>
        /// 公司信息表
        /// </summary>
        public DbSet<CompanyInfo> Company { get; set; }
        /// <summary>
        /// 新闻分类表
        /// </summary>
        public DbSet<NewsClassification> NewsClassifications { get; set; }
        /// <summary>
        /// 新闻表
        /// </summary>
        public DbSet<News> Newses { get; set; }

        /// <summary>
        /// 表配置信息
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*管理人员表*/
            modelBuilder.Entity<Manager>(m =>
            {
                m.HasKey(x => x.Id);
                m.HasData(new Manager()
                {
                    Id = 1,
                    ManagerName = "admin",
                    ManagerPassword = "21232F297A57A5A743894A0E4A801FC3"
                });
                m.ToTable("Manager");
            });
            /*系统信息表*/
            modelBuilder.Entity<SystemInfo>(s =>
            {
                s.HasKey(x => x.Id);
                s.ToTable("SystemInfo");
            });
            /*公司信息表*/
            modelBuilder.Entity<CompanyInfo>(c =>
            {
                c.HasKey(x => x.Id);
                c.HasData(new CompanyInfo()
                {
                    Id = 1,
                    CompanyName = "111",
                    CompanyCopyright = "111",
                    CompanyEmail = "111",
                    CompanyDescription = "111",
                    CompanyLogo = "111",
                    CompanyKeyWord = "111",
                    CompanyLocation = "111",
                    CompanyPhone = "111",
                    Lat = 26.58532,
                    Lng = 107.98509,
                    CompanyQRcode = "111"
                });
                c.ToTable("CompanyInfo");
            });
            /*新闻分类表*/
            modelBuilder.Entity<NewsClassification>(n =>
            {
                n.HasKey(x => x.Id);
                /*与新闻的一对多关系映射*/
                n.HasMany(x => x.Newses).WithOne(x=>x.NewsClassification).HasForeignKey(x => x.NewsClassificationId);
                n.ToTable("NewsClassification");
            });
            /*新闻表*/
            modelBuilder.Entity<News>(n =>
            {
                n.HasKey(x => x.Id);
                n.ToTable("News");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
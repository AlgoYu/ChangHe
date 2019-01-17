using Microsoft.EntityFrameworkCore;

namespace ChangHeWebSite.Areas.Admin.Models.Database
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
        /// 系统信息表
        /// </summary>
        public DbSet<SystemInfo> System { get; set; }
        /// <summary>
        /// 公司信息表
        /// </summary>
        public DbSet<CompanyInfo> Company { get; set; }
        /// <summary>
        /// 导航表
        /// </summary>
        public DbSet<Navigation> Navigations { get; set; }
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
            /*系统信息表*/
            modelBuilder.Entity<SystemInfo>(s =>
            {
                s.HasKey(x => x.SystemName);
                s.ToTable("SystemInfo");
            });
            /*公司信息表*/
            modelBuilder.Entity<CompanyInfo>(c =>
            {
                c.HasKey(x => x.CompanyName);
                c.ToTable("CompanyInfo");
            });
            /*导航表*/
            modelBuilder.Entity<Navigation>(n =>
            {
                n.HasKey(x => x.Id);
                n.ToTable("Navigation");
            });
            /*新闻分类表*/
            modelBuilder.Entity<NewsClassification>(n =>
            {
                n.HasKey(x => x.Id);
                n.HasMany(x => x.Newses).WithOne().HasForeignKey(x => x.NewsClassification);
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
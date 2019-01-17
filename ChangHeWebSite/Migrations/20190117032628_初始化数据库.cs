using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChangHeWebSite.Migrations
{
    public partial class 初始化数据库 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    CompanyName = table.Column<string>(nullable: false),
                    CompanyLogo = table.Column<string>(nullable: true),
                    CompanyDescription = table.Column<string>(nullable: true),
                    CompanyCopyright = table.Column<string>(nullable: true),
                    CompanyLocation = table.Column<string>(nullable: true),
                    CompanyPhone = table.Column<string>(nullable: true),
                    CompanyEmail = table.Column<string>(nullable: true),
                    CompanyQRcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.CompanyName);
                });

            migrationBuilder.CreateTable(
                name: "Navigation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NavigationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsClassification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewsClassificationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsClassification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemInfo",
                columns: table => new
                {
                    SystemName = table.Column<string>(nullable: false),
                    SystemLogo = table.Column<string>(nullable: true),
                    SystemCopyright = table.Column<string>(nullable: true),
                    SystemDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemInfo", x => x.SystemName);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewsTitle = table.Column<string>(nullable: true),
                    NewsContent = table.Column<string>(nullable: true),
                    NewsClassification = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_NewsClassification_NewsClassification",
                        column: x => x.NewsClassification,
                        principalTable: "NewsClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsClassification",
                table: "News",
                column: "NewsClassification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInfo");

            migrationBuilder.DropTable(
                name: "Navigation");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "SystemInfo");

            migrationBuilder.DropTable(
                name: "NewsClassification");
        }
    }
}

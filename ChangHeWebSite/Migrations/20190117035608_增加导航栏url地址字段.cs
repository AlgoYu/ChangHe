using Microsoft.EntityFrameworkCore.Migrations;

namespace ChangHeWebSite.Migrations
{
    public partial class 增加导航栏url地址字段 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NavigationUrl",
                table: "Navigation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NavigationUrl",
                table: "Navigation");
        }
    }
}

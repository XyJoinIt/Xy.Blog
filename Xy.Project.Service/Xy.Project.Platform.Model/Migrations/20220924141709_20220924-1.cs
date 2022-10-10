using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    public partial class _202209241 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Comment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RootParentId",
                table: "Comment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "RootParentId",
                table: "Comment");
        }
    }
}

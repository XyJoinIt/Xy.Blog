using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    /// <inheritdoc />
    public partial class v102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sys_role",
                table: "sys_role");

            migrationBuilder.RenameTable(
                name: "sys_role",
                newName: "SysRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SysRole",
                table: "SysRole",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SysRole",
                table: "SysRole");

            migrationBuilder.RenameTable(
                name: "SysRole",
                newName: "sys_role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sys_role",
                table: "sys_role",
                column: "Id");
        }
    }
}

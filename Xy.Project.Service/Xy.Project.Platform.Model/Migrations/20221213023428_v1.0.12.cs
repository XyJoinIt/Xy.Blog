using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    /// <inheritdoc />
    public partial class v1012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SysUserRole_SysRole_SysRoleId",
                table: "SysUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_SysUserRole_SysUser_SysUserId",
                table: "SysUserRole");

            migrationBuilder.DropIndex(
                name: "IX_SysUserRole_SysRoleId",
                table: "SysUserRole");

            migrationBuilder.DropIndex(
                name: "IX_SysUserRole_SysUserId",
                table: "SysUserRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SysUserRole_SysRoleId",
                table: "SysUserRole",
                column: "SysRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserRole_SysUserId",
                table: "SysUserRole",
                column: "SysUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SysUserRole_SysRole_SysRoleId",
                table: "SysUserRole",
                column: "SysRoleId",
                principalTable: "SysRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SysUserRole_SysUser_SysUserId",
                table: "SysUserRole",
                column: "SysUserId",
                principalTable: "SysUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

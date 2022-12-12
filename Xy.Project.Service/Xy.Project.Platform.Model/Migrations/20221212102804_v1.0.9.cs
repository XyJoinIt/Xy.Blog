using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    /// <inheritdoc />
    public partial class v109 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysUserRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SysUserId = table.Column<long>(type: "bigint", nullable: false, comment: "用户Id"),
                    SysRoleId = table.Column<long>(type: "bigint", nullable: false, comment: "角色Id"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedId = table.Column<long>(type: "bigint", nullable: true),
                    DeleteId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysUserRole_SysRole_SysRoleId",
                        column: x => x.SysRoleId,
                        principalTable: "SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysUserRole_SysUser_SysUserId",
                        column: x => x.SysUserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "用户角色表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserRole_SysRoleId",
                table: "SysUserRole",
                column: "SysRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserRole_SysUserId",
                table: "SysUserRole",
                column: "SysUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysUserRole");
        }
    }
}

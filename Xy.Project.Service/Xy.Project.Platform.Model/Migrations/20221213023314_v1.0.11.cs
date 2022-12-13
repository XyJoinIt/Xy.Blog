using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    /// <inheritdoc />
    public partial class v1011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "SysUserRole");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "SysUserRole");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "SysUserRole");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SysUserRole");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "SysUserRole");

            migrationBuilder.DropColumn(
                name: "LastModifiedId",
                table: "SysUserRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreateId",
                table: "SysUserRole",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "SysUserRole",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteId",
                table: "SysUserRole",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SysUserRole",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "SysUserRole",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedId",
                table: "SysUserRole",
                type: "bigint",
                nullable: true);
        }
    }
}

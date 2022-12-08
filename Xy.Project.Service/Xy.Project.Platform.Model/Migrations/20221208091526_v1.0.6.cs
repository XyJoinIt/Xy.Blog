using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    /// <inheritdoc />
    public partial class v106 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreateId",
                table: "SysUserRole",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteId",
                table: "SysUserRole",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedId",
                table: "SysUserRole",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SysUser",
                keyColumn: "Name",
                keyValue: null,
                column: "Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SysUser",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "姓名",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "姓名")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<long>(
                name: "CreateId",
                table: "SysUser",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteId",
                table: "SysUser",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedId",
                table: "SysUser",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateId",
                table: "SysRole",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteId",
                table: "SysRole",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedId",
                table: "SysRole",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateId",
                table: "SysOrg",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteId",
                table: "SysOrg",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedId",
                table: "SysOrg",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateId",
                table: "SysMenu",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteId",
                table: "SysMenu",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedId",
                table: "SysMenu",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateId",
                table: "SysFile",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteId",
                table: "SysFile",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedId",
                table: "SysFile",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateId",
                table: "bl_comment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteId",
                table: "bl_comment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedId",
                table: "bl_comment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateId",
                table: "bl_category",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteId",
                table: "bl_category",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedId",
                table: "bl_category",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateId",
                table: "bl_article",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteId",
                table: "bl_article",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedId",
                table: "bl_article",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateId",
                table: "bl_accessory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteId",
                table: "bl_accessory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedId",
                table: "bl_accessory",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "SysUserRole");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "SysUserRole");

            migrationBuilder.DropColumn(
                name: "LastModifiedId",
                table: "SysUserRole");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "SysUser");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "SysUser");

            migrationBuilder.DropColumn(
                name: "LastModifiedId",
                table: "SysUser");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "SysRole");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "SysRole");

            migrationBuilder.DropColumn(
                name: "LastModifiedId",
                table: "SysRole");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "SysOrg");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "SysOrg");

            migrationBuilder.DropColumn(
                name: "LastModifiedId",
                table: "SysOrg");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "LastModifiedId",
                table: "SysMenu");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "SysFile");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "SysFile");

            migrationBuilder.DropColumn(
                name: "LastModifiedId",
                table: "SysFile");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "bl_comment");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "bl_comment");

            migrationBuilder.DropColumn(
                name: "LastModifiedId",
                table: "bl_comment");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "bl_category");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "bl_category");

            migrationBuilder.DropColumn(
                name: "LastModifiedId",
                table: "bl_category");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "bl_article");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "bl_article");

            migrationBuilder.DropColumn(
                name: "LastModifiedId",
                table: "bl_article");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "bl_accessory");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "bl_accessory");

            migrationBuilder.DropColumn(
                name: "LastModifiedId",
                table: "bl_accessory");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SysUser",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "姓名",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldComment: "姓名")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}

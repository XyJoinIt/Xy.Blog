using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    /// <inheritdoc />
    public partial class v105 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "SysRole",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "备注",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldComment: "备注")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "SysMenu",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "备注",
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256,
                oldComment: "备注")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Redirect",
                table: "SysMenu",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "重定向",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldComment: "重定向")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Permission",
                table: "SysMenu",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "权限标识",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldComment: "权限标识")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "SysMenu",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "路由地址",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldComment: "路由地址")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "OutLink",
                table: "SysMenu",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "外链链接",
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256,
                oldComment: "外链链接")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "SysMenu",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "图标",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldComment: "图标")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Component",
                table: "SysMenu",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "组件路径",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldComment: "组件路径")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SysRole",
                keyColumn: "Remark",
                keyValue: null,
                column: "Remark",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "SysRole",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "备注",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "备注")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysMenu",
                keyColumn: "Remark",
                keyValue: null,
                column: "Remark",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "SysMenu",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                comment: "备注",
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "备注")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysMenu",
                keyColumn: "Redirect",
                keyValue: null,
                column: "Redirect",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Redirect",
                table: "SysMenu",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "重定向",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "重定向")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysMenu",
                keyColumn: "Permission",
                keyValue: null,
                column: "Permission",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Permission",
                table: "SysMenu",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "权限标识",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "权限标识")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysMenu",
                keyColumn: "Path",
                keyValue: null,
                column: "Path",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "SysMenu",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "路由地址",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "路由地址")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysMenu",
                keyColumn: "OutLink",
                keyValue: null,
                column: "OutLink",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "OutLink",
                table: "SysMenu",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                comment: "外链链接",
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "外链链接")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysMenu",
                keyColumn: "Icon",
                keyValue: null,
                column: "Icon",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "SysMenu",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "图标",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "图标")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysMenu",
                keyColumn: "Component",
                keyValue: null,
                column: "Component",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Component",
                table: "SysMenu",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "组件路径",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "组件路径")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}

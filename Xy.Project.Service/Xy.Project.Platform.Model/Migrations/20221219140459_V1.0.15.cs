using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    /// <inheritdoc />
    public partial class V1015 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "外链地址",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldComment: "外链地址")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Suffix",
                table: "SysFile",
                type: "varchar(16)",
                maxLength: 16,
                nullable: true,
                comment: "文件后缀",
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldMaxLength: 16,
                oldComment: "文件后缀")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SizeKb",
                table: "SysFile",
                type: "varchar(16)",
                maxLength: 16,
                nullable: true,
                comment: "文件大小KB",
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldMaxLength: 16,
                oldComment: "文件大小KB")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SizeInfo",
                table: "SysFile",
                type: "varchar(64)",
                maxLength: 64,
                nullable: true,
                comment: "文件大小信息",
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64,
                oldComment: "文件大小信息")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Provider",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "提供者",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldComment: "提供者")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "存储路径",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldComment: "存储路径")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "文件名称",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldComment: "文件名称")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BucketName",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "仓储名称",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldComment: "仓储名称")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SysFile",
                keyColumn: "Url",
                keyValue: null,
                column: "Url",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "外链地址",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "外链地址")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysFile",
                keyColumn: "Suffix",
                keyValue: null,
                column: "Suffix",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Suffix",
                table: "SysFile",
                type: "varchar(16)",
                maxLength: 16,
                nullable: false,
                comment: "文件后缀",
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldMaxLength: 16,
                oldNullable: true,
                oldComment: "文件后缀")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysFile",
                keyColumn: "SizeKb",
                keyValue: null,
                column: "SizeKb",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SizeKb",
                table: "SysFile",
                type: "varchar(16)",
                maxLength: 16,
                nullable: false,
                comment: "文件大小KB",
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldMaxLength: 16,
                oldNullable: true,
                oldComment: "文件大小KB")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysFile",
                keyColumn: "SizeInfo",
                keyValue: null,
                column: "SizeInfo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SizeInfo",
                table: "SysFile",
                type: "varchar(64)",
                maxLength: 64,
                nullable: false,
                comment: "文件大小信息",
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64,
                oldNullable: true,
                oldComment: "文件大小信息")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysFile",
                keyColumn: "Provider",
                keyValue: null,
                column: "Provider",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Provider",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "提供者",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "提供者")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysFile",
                keyColumn: "FilePath",
                keyValue: null,
                column: "FilePath",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "存储路径",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "存储路径")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysFile",
                keyColumn: "FileName",
                keyValue: null,
                column: "FileName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "文件名称",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "文件名称")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SysFile",
                keyColumn: "BucketName",
                keyValue: null,
                column: "BucketName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "BucketName",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "仓储名称",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "仓储名称")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}

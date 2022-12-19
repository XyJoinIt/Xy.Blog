using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    /// <inheritdoc />
    public partial class V1014 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileNewName",
                table: "SysFile");

            migrationBuilder.DropColumn(
                name: "FileOldName",
                table: "SysFile");

            migrationBuilder.AlterColumn<string>(
                name: "Provider",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "提供者",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 5,
                oldComment: "提供者")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                comment: "文件名称")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SizeInfo",
                table: "SysFile",
                type: "varchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                comment: "文件大小信息")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "SysFile");

            migrationBuilder.DropColumn(
                name: "SizeInfo",
                table: "SysFile");

            migrationBuilder.AlterColumn<int>(
                name: "Provider",
                table: "SysFile",
                type: "int",
                maxLength: 5,
                nullable: false,
                comment: "提供者",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128,
                oldComment: "提供者")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FileNewName",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                comment: "上传后名称")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FileOldName",
                table: "SysFile",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                comment: "上传前名称")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

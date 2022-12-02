using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    /// <inheritdoc />
    public partial class v104 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysMenu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Pid = table.Column<long>(type: "bigint", nullable: false, comment: "父Id"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "菜单类型"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Path = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "路由地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Component = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "组件路径")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Redirect = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "重定向")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Permission = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "权限标识")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icon = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "图标")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsIframe = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否内嵌"),
                    OutLink = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "外链链接")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsHide = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否隐藏"),
                    IsKeepAlive = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否缓存"),
                    IsAffix = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否固定"),
                    Order = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "状态"),
                    Remark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.Id);
                },
                comment: "系统菜单表")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysMenu");
        }
    }
}

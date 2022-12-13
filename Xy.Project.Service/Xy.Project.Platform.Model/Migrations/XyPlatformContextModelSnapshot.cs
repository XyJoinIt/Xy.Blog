﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xy.Project.Platform.Model;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    [DbContext(typeof(XyPlatformContext))]
    partial class XyPlatformContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Xy.Project.Platform.Model.Entities.Blogs.Accessory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("DeleteId")
                        .HasColumnType("bigint");

                    b.Property<string>("HashCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("bl_accessory");
                });

            modelBuilder.Entity("Xy.Project.Platform.Model.Entities.Blogs.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("CreateId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("DeleteId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("IssuerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("bl_article");
                });

            modelBuilder.Entity("Xy.Project.Platform.Model.Entities.Blogs.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("CreateId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("DeleteId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Remarks")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("bl_category");
                });

            modelBuilder.Entity("Xy.Project.Platform.Model.Entities.Blogs.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("CreateId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("DeleteId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long>("RootParentId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("bl_comment");
                });

            modelBuilder.Entity("Xy.Project.Platform.Model.Entities.Sys.SysFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("BucketName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasComment("仓储名称");

                    b.Property<long?>("CreateId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("DeleteId")
                        .HasColumnType("bigint");

                    b.Property<string>("FileNewName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasComment("上传后名称");

                    b.Property<string>("FileOldName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasComment("上传前名称");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasComment("存储路径");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<int>("Modular")
                        .HasMaxLength(5)
                        .HasColumnType("int")
                        .HasComment("所在系统模块");

                    b.Property<int>("Provider")
                        .HasMaxLength(5)
                        .HasColumnType("int")
                        .HasComment("提供者");

                    b.Property<string>("SizeKb")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasComment("文件大小KB");

                    b.Property<string>("Suffix")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasComment("文件后缀");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasComment("外链地址");

                    b.HasKey("Id");

                    b.ToTable("SysFile");
                });

            modelBuilder.Entity("Xy.Project.Platform.Model.Entities.Sys.SysMenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Component")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasComment("组件路径");

                    b.Property<long?>("CreateId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("DeleteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Icon")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasComment("图标");

                    b.Property<bool>("IsAffix")
                        .HasColumnType("tinyint(1)")
                        .HasComment("是否固定");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsHide")
                        .HasColumnType("tinyint(1)")
                        .HasComment("是否隐藏");

                    b.Property<bool>("IsIframe")
                        .HasColumnType("tinyint(1)")
                        .HasComment("是否内嵌");

                    b.Property<bool>("IsKeepAlive")
                        .HasColumnType("tinyint(1)")
                        .HasComment("是否缓存");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasComment("名称");

                    b.Property<int>("Order")
                        .HasColumnType("int")
                        .HasComment("排序");

                    b.Property<string>("OutLink")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasComment("外链链接");

                    b.Property<string>("Path")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasComment("路由地址");

                    b.Property<string>("Permission")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasComment("权限标识");

                    b.Property<long>("Pid")
                        .HasColumnType("bigint")
                        .HasComment("父Id");

                    b.Property<string>("Redirect")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasComment("重定向");

                    b.Property<string>("Remark")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasComment("备注");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasComment("状态");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasComment("标题");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasComment("菜单类型");

                    b.HasKey("Id");

                    b.ToTable("SysMenu", t =>
                        {
                            t.HasComment("系统菜单表");
                        });
                });

            modelBuilder.Entity("Xy.Project.Platform.Model.Entities.Sys.SysOrg", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("DeleteId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<long>("Pid")
                        .HasColumnType("bigint");

                    b.Property<string>("Remark")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SysOrg", t =>
                        {
                            t.HasComment("系统机构表");
                        });
                });

            modelBuilder.Entity("Xy.Project.Platform.Model.Entities.Sys.SysRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("编码");

                    b.Property<long?>("CreateId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("DeleteId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("备注");

                    b.Property<int>("Sort")
                        .HasColumnType("int")
                        .HasComment("排序");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasComment("状态");

                    b.HasKey("Id");

                    b.ToTable("SysRole", t =>
                        {
                            t.HasComment("角色表");
                        });
                });

            modelBuilder.Entity("Xy.Project.Platform.Model.Entities.Sys.SysUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("账号");

                    b.Property<int>("AdminType")
                        .HasColumnType("int")
                        .HasComment("管理员类型 -超级管理员_1、管理员_2、普通账号_3");

                    b.Property<string>("Avatar")
                        .HasColumnType("longtext")
                        .HasComment("头像");

                    b.Property<DateTimeOffset?>("Birthday")
                        .HasColumnType("datetime")
                        .HasComment("生日");

                    b.Property<long?>("CreateId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("DeleteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("邮箱");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastLoginIp")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("最后登录IP");

                    b.Property<DateTimeOffset?>("LastLoginTime")
                        .HasColumnType("datetime")
                        .HasComment("最后登录时间");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("姓名");

                    b.Property<string>("NickName")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("昵称");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("密码");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("手机");

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("个人秘钥");

                    b.Property<int>("Sex")
                        .HasColumnType("int")
                        .HasComment("性别-男_1、女_2");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasComment("状态-正常_0、停用_1、删除_2");

                    b.Property<string>("Tel")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("电话");

                    b.HasKey("Id");

                    b.ToTable("SysUser", t =>
                        {
                            t.HasComment("用户表");
                        });
                });

            modelBuilder.Entity("Xy.Project.Platform.Model.Entities.Sys.SysUserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("SysRoleId")
                        .HasColumnType("bigint")
                        .HasComment("角色Id");

                    b.Property<long>("SysUserId")
                        .HasColumnType("bigint")
                        .HasComment("用户Id");

                    b.HasKey("Id");

                    b.ToTable("SysUserRole", t =>
                        {
                            t.HasComment("用户角色表");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

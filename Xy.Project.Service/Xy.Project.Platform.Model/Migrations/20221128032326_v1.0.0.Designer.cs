﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xy.Project.Platform.Model;

#nullable disable

namespace Xy.Project.Platform.Model.Migrations
{
    [DbContext(typeof(XyPlatformContext))]
    [Migration("20221128032326_v1.0.0")]
    partial class v100
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Xy.Project.Platform.Model.Entities.Sys.SysOrg", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

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

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("名称");

                    b.Property<string>("Remark")
                        .IsRequired()
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

                    b.ToTable("sys_role", t =>
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

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

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

                    b.Property<string>("Name")
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

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

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

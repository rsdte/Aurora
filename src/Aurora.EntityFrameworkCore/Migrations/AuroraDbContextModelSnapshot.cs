﻿// <auto-generated />
using System;
using Aurora.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aurora.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(AuroraDbContext))]
    partial class AuroraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Aurora.Domain.Systems.Permission", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 11, 24, 21, 12, 55, 964, DateTimeKind.Local).AddTicks(4662));

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("tb_permission", (string)null);
                });

            modelBuilder.Entity("Aurora.Domain.Systems.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 11, 24, 21, 12, 55, 964, DateTimeKind.Local).AddTicks(7740));

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.HasKey("Id");

                    b.ToTable("tb_role", (string)null);
                });

            modelBuilder.Entity("Aurora.Domain.Systems.Tenant", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 11, 24, 21, 12, 55, 966, DateTimeKind.Local).AddTicks(2674));

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.HasKey("Id");

                    b.ToTable("tb_tenant", (string)null);
                });

            modelBuilder.Entity("Aurora.Domain.Systems.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 11, 24, 21, 12, 55, 966, DateTimeKind.Local).AddTicks(6993));

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tb_user", (string)null);
                });

            modelBuilder.Entity("Aurora.Domain.Systems.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 11, 24, 21, 12, 55, 966, DateTimeKind.Local).AddTicks(8188));

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.HasKey("Id");

                    b.ToTable("tb_user_role", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

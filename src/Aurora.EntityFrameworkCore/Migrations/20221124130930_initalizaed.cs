using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aurora.EntityFrameworkCore.Migrations
{
    public partial class initalizaed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "db_tenant",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentId = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 861, DateTimeKind.Local).AddTicks(3694)),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    CreatorId = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_db_tenant", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "db_user_role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 861, DateTimeKind.Local).AddTicks(5856)),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    CreatorId = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_db_user_role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_permission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icon = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 860, DateTimeKind.Local).AddTicks(3702)),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    CreatorId = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_permission", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 860, DateTimeKind.Local).AddTicks(6718)),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    CreatorId = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 861, DateTimeKind.Local).AddTicks(4888)),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    CreatorId = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "db_tenant");

            migrationBuilder.DropTable(
                name: "db_user_role");

            migrationBuilder.DropTable(
                name: "tb_permission");

            migrationBuilder.DropTable(
                name: "tb_role");

            migrationBuilder.DropTable(
                name: "tb_user");
        }
    }
}

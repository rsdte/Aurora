using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aurora.EntityFrameworkCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_permission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Icon = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ParentId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2022, 11, 26, 17, 13, 43, 366, DateTimeKind.Local).AddTicks(8414)),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatorId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    TenantId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2022, 11, 26, 17, 13, 43, 367, DateTimeKind.Local).AddTicks(6011)),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatorId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_role_permission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    RoleId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    PermissionId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2022, 11, 26, 17, 13, 43, 367, DateTimeKind.Local).AddTicks(5056)),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatorId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role_permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tenant",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2022, 11, 26, 17, 13, 43, 368, DateTimeKind.Local).AddTicks(2525)),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatorId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2022, 11, 26, 17, 13, 43, 368, DateTimeKind.Local).AddTicks(5153)),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatorId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user_role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    TenantId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    UserId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    RoleId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2022, 11, 26, 17, 13, 43, 368, DateTimeKind.Local).AddTicks(4223)),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatorId = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user_role", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_permission");

            migrationBuilder.DropTable(
                name: "tb_role");

            migrationBuilder.DropTable(
                name: "tb_role_permission");

            migrationBuilder.DropTable(
                name: "tb_tenant");

            migrationBuilder.DropTable(
                name: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_user_role");
        }
    }
}

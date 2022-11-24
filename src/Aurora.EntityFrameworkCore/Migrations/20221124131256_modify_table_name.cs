using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aurora.EntityFrameworkCore.Migrations
{
    public partial class modify_table_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_db_user_role",
                table: "db_user_role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_db_tenant",
                table: "db_tenant");

            migrationBuilder.RenameTable(
                name: "db_user_role",
                newName: "tb_user_role");

            migrationBuilder.RenameTable(
                name: "db_tenant",
                newName: "tb_tenant");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "tb_user",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 21, 12, 55, 966, DateTimeKind.Local).AddTicks(6993),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 861, DateTimeKind.Local).AddTicks(4888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "tb_role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 21, 12, 55, 964, DateTimeKind.Local).AddTicks(7740),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 860, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "tb_permission",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 21, 12, 55, 964, DateTimeKind.Local).AddTicks(4662),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 860, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "tb_user_role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 21, 12, 55, 966, DateTimeKind.Local).AddTicks(8188),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 861, DateTimeKind.Local).AddTicks(5856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "tb_tenant",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 21, 12, 55, 966, DateTimeKind.Local).AddTicks(2674),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 861, DateTimeKind.Local).AddTicks(3694));

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user_role",
                table: "tb_user_role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tenant",
                table: "tb_tenant",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user_role",
                table: "tb_user_role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tenant",
                table: "tb_tenant");

            migrationBuilder.RenameTable(
                name: "tb_user_role",
                newName: "db_user_role");

            migrationBuilder.RenameTable(
                name: "tb_tenant",
                newName: "db_tenant");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "tb_user",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 861, DateTimeKind.Local).AddTicks(4888),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 24, 21, 12, 55, 966, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "tb_role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 860, DateTimeKind.Local).AddTicks(6718),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 24, 21, 12, 55, 964, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "tb_permission",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 860, DateTimeKind.Local).AddTicks(3702),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 24, 21, 12, 55, 964, DateTimeKind.Local).AddTicks(4662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "db_user_role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 861, DateTimeKind.Local).AddTicks(5856),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 24, 21, 12, 55, 966, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "db_tenant",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 21, 9, 30, 861, DateTimeKind.Local).AddTicks(3694),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 24, 21, 12, 55, 966, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.AddPrimaryKey(
                name: "PK_db_user_role",
                table: "db_user_role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_db_tenant",
                table: "db_tenant",
                column: "Id");
        }
    }
}

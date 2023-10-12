using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    public partial class deleteGroupfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_groups_GroupsidGroup",
                table: "users");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropIndex(
                name: "IX_users_GroupsidGroup",
                table: "users");

            migrationBuilder.DropColumn(
                name: "GroupsidGroup",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupsidGroup",
                table: "users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    idGroup = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nameGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    permissionGroup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.idGroup);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_GroupsidGroup",
                table: "users",
                column: "GroupsidGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_users_groups_GroupsidGroup",
                table: "users",
                column: "GroupsidGroup",
                principalTable: "groups",
                principalColumn: "idGroup");
        }
    }
}

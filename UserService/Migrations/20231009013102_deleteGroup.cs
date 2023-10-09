using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    public partial class deleteGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_groups_idGroup",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_idGroup",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "idGroup",
                table: "users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "GroupsidGroup",
                table: "users",
                type: "nvarchar(450)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_groups_GroupsidGroup",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_GroupsidGroup",
                table: "users");

            migrationBuilder.DropColumn(
                name: "GroupsidGroup",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "idGroup",
                table: "users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_idGroup",
                table: "users",
                column: "idGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_users_groups_idGroup",
                table: "users",
                column: "idGroup",
                principalTable: "groups",
                principalColumn: "idGroup",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

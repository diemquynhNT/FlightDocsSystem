﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    idGroup = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.idGroup);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    emailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statusUser = table.Column<bool>(type: "bit", nullable: false),
                    idGroup = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.idUser);
                    table.ForeignKey(
                        name: "FK_users_groups_idGroup",
                        column: x => x.idGroup,
                        principalTable: "groups",
                        principalColumn: "idGroup",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_idGroup",
                table: "users",
                column: "idGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "groups");
        }
    }
}

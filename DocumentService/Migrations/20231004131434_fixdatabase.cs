using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentService.Migrations
{
    public partial class fixdatabase : Migration
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
                name: "assignments",
                columns: table => new
                {
                    idGroup = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idDoc = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignments", x => new { x.idGroup, x.idDoc });
                    table.ForeignKey(
                        name: "FK_assignment_document",
                        column: x => x.idDoc,
                        principalTable: "Documents",
                        principalColumn: "IdDocument",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phancong_group",
                        column: x => x.idGroup,
                        principalTable: "groups",
                        principalColumn: "idGroup",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permisstions",
                columns: table => new
                {
                    idType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idGroup = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    permisstion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permisstions", x => new { x.idGroup, x.idType });
                    table.ForeignKey(
                        name: "FK_quyen_group",
                        column: x => x.idGroup,
                        principalTable: "groups",
                        principalColumn: "idGroup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quyen_type",
                        column: x => x.idType,
                        principalTable: "typeDocuments",
                        principalColumn: "IdType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignments_idDoc",
                table: "assignments",
                column: "idDoc");

            migrationBuilder.CreateIndex(
                name: "IX_permisstions_idType",
                table: "permisstions",
                column: "idType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignments");

            migrationBuilder.DropTable(
                name: "permisstions");

            migrationBuilder.DropTable(
                name: "groups");
        }
    }
}

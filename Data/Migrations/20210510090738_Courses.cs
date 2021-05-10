using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrivateOffice2.Data.Migrations
{
    public partial class Courses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    IdCourse = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameCourse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTeacher = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    CountTime = table.Column<int>(type: "int", nullable: false),
                    NameUniversity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.IdCourse);
                    table.ForeignKey(
                        name: "FK_Course_AspNetUsers_IdTeacher",
                        column: x => x.IdTeacher,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_IdTeacher",
                table: "Course",
                column: "IdTeacher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");
        }
    }
}

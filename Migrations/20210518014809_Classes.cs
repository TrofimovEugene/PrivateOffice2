using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrivateOffice2.Migrations
{
    public partial class Classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "GroupIdGroup",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    IdGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGroup = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.IdGroup);
                });

            migrationBuilder.CreateTable(
                name: "TypeClasses",
                columns: table => new
                {
                    IdTypeClasses = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeClass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeClasses", x => x.IdTypeClasses);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    IdClasses = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdTypeClasses = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdCourse = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NameClasses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DateClasses = table.Column<DateTime>(type: "date", nullable: false),
                    DaysWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cabinet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplayClasses = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.IdClasses);
                    table.ForeignKey(
                        name: "FK_Classes_Course_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Course",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_TypeClasses_IdTypeClasses",
                        column: x => x.IdTypeClasses,
                        principalTable: "TypeClasses",
                        principalColumn: "IdTypeClasses",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_GroupIdGroup",
                table: "Course",
                column: "GroupIdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_IdCourse",
                table: "Classes",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_IdTypeClasses",
                table: "Classes",
                column: "IdTypeClasses");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Group_GroupIdGroup",
                table: "Course",
                column: "GroupIdGroup",
                principalTable: "Group",
                principalColumn: "IdGroup",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Group_GroupIdGroup",
                table: "Course");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "TypeClasses");

            migrationBuilder.DropIndex(
                name: "IX_Course_GroupIdGroup",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "GroupIdGroup",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

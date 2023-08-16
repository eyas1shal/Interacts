using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eyas_task3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StCs",
                columns: table => new
                {
                    StId = table.Column<int>(type: "int", nullable: false),
                    CId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StCs", x => new { x.StId, x.CId });
                    table.ForeignKey(
                        name: "FK_StCs_Courses_CId",
                        column: x => x.CId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StCs_Students_StId",
                        column: x => x.StId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StCs_CId",
                table: "StCs",
                column: "CId");
            migrationBuilder.Sql("INSERT INTO Students (Name) VALUES  ('tareq')");
            Seed(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StCs");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }


        private void Seed(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                          table: "Student",
                          columns: new[] {"Id","Name" },
                          values: new object[,] {


                               { default,"Name" },
                               {default,"ammar" }
                          });

            migrationBuilder.InsertData(
              table: "Courses",
              columns: new[] { "Id", "Name" },
              values: new object[,] {


                               { default,"WEB" },
                               {default,"Java" }
              });



            migrationBuilder.InsertData(
                  table: "Student",
                  columns: new[] { "Id", "Name" },
                  values: new object[,] {


                               { 1,1 },
                               {2,2}
                  });
        }


    }
}

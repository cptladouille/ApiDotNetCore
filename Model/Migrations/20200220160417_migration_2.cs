using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    IdMovie = table.Column<int>(nullable: false),
                    IdPerson = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: true),
                    ActorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => new { x.IdPerson, x.IdMovie });
                    table.ForeignKey(
                        name: "FK_MovieActor_Person_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MovieId",
                table: "Comment",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_ActorId",
                table: "MovieActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_MovieId",
                table: "MovieActor",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Person_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Person_DirectorId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Movies");
        }
    }
}

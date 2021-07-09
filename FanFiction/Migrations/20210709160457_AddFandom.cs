using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FanFiction.Migrations
{
    public partial class AddFandom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fandom",
                table: "Story");

            migrationBuilder.AddColumn<int>(
                name: "FandomId",
                table: "Story",
                type: "int",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Story",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Fandom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fandom", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Story_FandomId",
                table: "Story",
                column: "FandomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Fandom_FandomId",
                table: "Story",
                column: "FandomId",
                principalTable: "Fandom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Story_Fandom_FandomId",
                table: "Story");

            migrationBuilder.DropTable(
                name: "Fandom");

            migrationBuilder.DropIndex(
                name: "IX_Story_FandomId",
                table: "Story");

            migrationBuilder.DropColumn(
                name: "FandomId",
                table: "Story");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Story");

            migrationBuilder.AddColumn<string>(
                name: "Fandom",
                table: "Story",
                type: "nvarchar(max)",
                nullable: false);
        }
    }
}

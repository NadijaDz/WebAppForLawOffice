using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Advokati.WebAPI.Migrations
{
    public partial class izmjenatroskovaipredmeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RokUplate",
                table: "Troskovi");

            migrationBuilder.RenameColumn(
                name: "RokZavrsetka",
                table: "Predmeti",
                newName: "RokUplate");

            migrationBuilder.AddColumn<decimal>(
                name: "UkupniTrosak",
                table: "Predmeti",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UkupniTrosak",
                table: "Predmeti");

            migrationBuilder.RenameColumn(
                name: "RokUplate",
                table: "Predmeti",
                newName: "RokZavrsetka");

            migrationBuilder.AddColumn<DateTime>(
                name: "RokUplate",
                table: "Troskovi",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

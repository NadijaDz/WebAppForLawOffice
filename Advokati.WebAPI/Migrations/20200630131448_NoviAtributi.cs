using Microsoft.EntityFrameworkCore.Migrations;

namespace Advokati.WebAPI.Migrations
{
    public partial class NoviAtributi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VrstaUsluge",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Uloge",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ListaKontakata",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "KategorijeDokumenata",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FajloviPredmeta",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Dokumenti",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VrstaUsluge");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Uloge");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ListaKontakata");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "KategorijeDokumenata");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FajloviPredmeta");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Dokumenti");
        }
    }
}

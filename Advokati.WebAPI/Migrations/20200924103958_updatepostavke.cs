using Microsoft.EntityFrameworkCore.Migrations;

namespace Advokati.WebAPI.Migrations
{
    public partial class updatepostavke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Postavke",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Postavke_KorisnikId",
                table: "Postavke",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postavke_Korisnici_KorisnikId",
                table: "Postavke",
                column: "KorisnikId",
                principalTable: "Korisnici",
                principalColumn: "KorisnikId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postavke_Korisnici_KorisnikId",
                table: "Postavke");

            migrationBuilder.DropIndex(
                name: "IX_Postavke_KorisnikId",
                table: "Postavke");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Postavke");
        }
    }
}

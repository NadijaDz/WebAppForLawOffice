using Microsoft.EntityFrameworkCore.Migrations;

namespace Advokati.WebAPI.Migrations
{
    public partial class promjenaatributaupostavkama : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Skriveno",
                table: "Postavke",
                newName: "Prikazi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prikazi",
                table: "Postavke",
                newName: "Skriveno");
        }
    }
}

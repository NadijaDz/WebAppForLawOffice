using Microsoft.EntityFrameworkCore.Migrations;

namespace Advokati.WebAPI.Migrations
{
    public partial class noviatribut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fajl",
                table: "FajloviPredmeta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fajl",
                table: "FajloviPredmeta");
        }
    }
}

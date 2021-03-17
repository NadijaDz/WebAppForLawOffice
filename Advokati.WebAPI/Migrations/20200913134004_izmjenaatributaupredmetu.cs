using Microsoft.EntityFrameworkCore.Migrations;

namespace Advokati.WebAPI.Migrations
{
    public partial class izmjenaatributaupredmetu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predmeti_FajloviPredmeta_FajloviPredmetaId",
                table: "Predmeti");

            migrationBuilder.DropIndex(
                name: "IX_Predmeti_FajloviPredmetaId",
                table: "Predmeti");

            migrationBuilder.DropColumn(
                name: "FajloviPredmetaId",
                table: "Predmeti");

            migrationBuilder.RenameColumn(
                name: "Fajl",
                table: "FajloviPredmeta",
                newName: "Url");

            migrationBuilder.AddColumn<int>(
                name: "PredmetID",
                table: "FajloviPredmeta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FajloviPredmeta_PredmetID",
                table: "FajloviPredmeta",
                column: "PredmetID");

            migrationBuilder.AddForeignKey(
                name: "FK_FajloviPredmeta_Predmeti_PredmetID",
                table: "FajloviPredmeta",
                column: "PredmetID",
                principalTable: "Predmeti",
                principalColumn: "PredmetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FajloviPredmeta_Predmeti_PredmetID",
                table: "FajloviPredmeta");

            migrationBuilder.DropIndex(
                name: "IX_FajloviPredmeta_PredmetID",
                table: "FajloviPredmeta");

            migrationBuilder.DropColumn(
                name: "PredmetID",
                table: "FajloviPredmeta");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "FajloviPredmeta",
                newName: "Fajl");

            migrationBuilder.AddColumn<int>(
                name: "FajloviPredmetaId",
                table: "Predmeti",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Predmeti_FajloviPredmetaId",
                table: "Predmeti",
                column: "FajloviPredmetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Predmeti_FajloviPredmeta_FajloviPredmetaId",
                table: "Predmeti",
                column: "FajloviPredmetaId",
                principalTable: "FajloviPredmeta",
                principalColumn: "FajlPredmetaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

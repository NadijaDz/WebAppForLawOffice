using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Advokati.WebAPI.Migrations
{
    public partial class dodavanjetabelezapisnikrocista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZapisnikRocista",
                columns: table => new
                {
                    ZapisnikRocistaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Ekstenzija = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    RocisteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZapisnikRocista", x => x.ZapisnikRocistaId);
                    table.ForeignKey(
                        name: "FK_ZapisnikRocista_Rocista_RocisteID",
                        column: x => x.RocisteID,
                        principalTable: "Rocista",
                        principalColumn: "RocisteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZapisnikRocista_RocisteID",
                table: "ZapisnikRocista",
                column: "RocisteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZapisnikRocista");
        }
    }
}

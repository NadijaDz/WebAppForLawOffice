using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Advokati.WebAPI.Migrations
{
    public partial class PromjenaBaze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FajloviPredmeta",
                columns: table => new
                {
                    FajlPredmetaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Ekstenzija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FajloviPredmeta", x => x.FajlPredmetaId);
                });

            migrationBuilder.CreateTable(
                name: "KategorijeDokumenata",
                columns: table => new
                {
                    KategorijaDokumentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijeDokumenata", x => x.KategorijaDokumentaId);
                });

            migrationBuilder.CreateTable(
                name: "ListaKontakata",
                columns: table => new
                {
                    KontaktId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaKontakata", x => x.KontaktId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaId);
                });

            migrationBuilder.CreateTable(
                name: "Uredi",
                columns: table => new
                {
                    UredId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true),
                    ZiroRacun = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uredi", x => x.UredId);
                });

            migrationBuilder.CreateTable(
                name: "VrstaUsluge",
                columns: table => new
                {
                    VrstaUslugeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaUsluge", x => x.VrstaUslugeId);
                });

            migrationBuilder.CreateTable(
                name: "Dokumenti",
                columns: table => new
                {
                    DokumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Ekstenzija = table.Column<string>(nullable: true),
                    KategorijaDokumentaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumenti", x => x.DokumentId);
                    table.ForeignKey(
                        name: "FK_Dokumenti_KategorijeDokumenata_KategorijaDokumentaId",
                        column: x => x.KategorijaDokumentaId,
                        principalTable: "KategorijeDokumenata",
                        principalColumn: "KategorijaDokumentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    RadniStaz = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    LozinkaHash = table.Column<string>(nullable: true),
                    LozinkaSalt = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    UlogeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikId);
                    table.ForeignKey(
                        name: "FK_Korisnici_Uloge_UlogeId",
                        column: x => x.UlogeId,
                        principalTable: "Uloge",
                        principalColumn: "UlogaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Predmeti",
                columns: table => new
                {
                    PredmetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojPredmeta = table.Column<string>(nullable: true),
                    NazivPredmeta = table.Column<string>(nullable: true),
                    DatumPocetka = table.Column<DateTime>(nullable: false),
                    RokZavrsetka = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ZaposleniciId = table.Column<int>(nullable: false),
                    KlijentId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    VrstaId = table.Column<int>(nullable: false),
                    FajloviPredmetaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmeti", x => x.PredmetId);
                    table.ForeignKey(
                        name: "FK_Predmeti_FajloviPredmeta_FajloviPredmetaId",
                        column: x => x.FajloviPredmetaId,
                        principalTable: "FajloviPredmeta",
                        principalColumn: "FajlPredmetaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Predmeti_Korisnici_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Predmeti_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Predmeti_VrstaUsluge_VrstaId",
                        column: x => x.VrstaId,
                        principalTable: "VrstaUsluge",
                        principalColumn: "VrstaUslugeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Predmeti_Korisnici_ZaposleniciId",
                        column: x => x.ZaposleniciId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sastanci",
                columns: table => new
                {
                    SastanakId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumSastanka = table.Column<DateTime>(nullable: false),
                    MjestoOdrzavanja = table.Column<string>(nullable: true),
                    Poruka = table.Column<string>(nullable: true),
                    Odrzan = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Odobreno = table.Column<bool>(nullable: true),
                    ZaposleniciId = table.Column<int>(nullable: false),
                    KlijentId = table.Column<int>(nullable: false),
                    VrstaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sastanci", x => x.SastanakId);
                    table.ForeignKey(
                        name: "FK_Sastanci_Korisnici_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sastanci_VrstaUsluge_VrstaId",
                        column: x => x.VrstaId,
                        principalTable: "VrstaUsluge",
                        principalColumn: "VrstaUslugeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sastanci_Korisnici_ZaposleniciId",
                        column: x => x.ZaposleniciId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ugovori",
                columns: table => new
                {
                    UgovorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naslov = table.Column<string>(nullable: true),
                    DatumPotpisivanja = table.Column<DateTime>(nullable: false),
                    DatumRaskida = table.Column<DateTime>(nullable: true),
                    Napomena = table.Column<string>(nullable: true),
                    Zavrsen = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ZaposleniciId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugovori", x => x.UgovorId);
                    table.ForeignKey(
                        name: "FK_Ugovori_Korisnici_ZaposleniciId",
                        column: x => x.ZaposleniciId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zadaci",
                columns: table => new
                {
                    ZadatakId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    DatumPocetka = table.Column<DateTime>(nullable: false),
                    Rok = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Zavrsen = table.Column<bool>(nullable: true),
                    ZaposleniciId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadaci", x => x.ZadatakId);
                    table.ForeignKey(
                        name: "FK_Zadaci_Korisnici_ZaposleniciId",
                        column: x => x.ZaposleniciId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RadniSati",
                columns: table => new
                {
                    RadniSatiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojRadnihSati = table.Column<decimal>(nullable: false),
                    PrekovremeniSati = table.Column<decimal>(nullable: false),
                    CijenaPoSatu = table.Column<decimal>(nullable: false),
                    CijenaPrekovremenogSata = table.Column<decimal>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ZaposleniciId = table.Column<int>(nullable: false),
                    PredmetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadniSati", x => x.RadniSatiId);
                    table.ForeignKey(
                        name: "FK_RadniSati_Predmeti_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmeti",
                        principalColumn: "PredmetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RadniSati_Korisnici_ZaposleniciId",
                        column: x => x.ZaposleniciId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rocista",
                columns: table => new
                {
                    RocisteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRocista = table.Column<DateTime>(nullable: false),
                    Mjesto = table.Column<string>(nullable: true),
                    Odrzano = table.Column<bool>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    PredmetID = table.Column<int>(nullable: false),
                    ZaposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rocista", x => x.RocisteId);
                    table.ForeignKey(
                        name: "FK_Rocista_Predmeti_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmeti",
                        principalColumn: "PredmetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rocista_Korisnici_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Troskovi",
                columns: table => new
                {
                    TrosakId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sifra = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Iznos = table.Column<decimal>(nullable: false),
                    RokUplate = table.Column<DateTime>(nullable: false),
                    DatumUplate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    PredmetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troskovi", x => x.TrosakId);
                    table.ForeignKey(
                        name: "FK_Troskovi_Predmeti_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmeti",
                        principalColumn: "PredmetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dokumenti_KategorijaDokumentaId",
                table: "Dokumenti",
                column: "KategorijaDokumentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_UlogeId",
                table: "Korisnici",
                column: "UlogeId");

            migrationBuilder.CreateIndex(
                name: "IX_Predmeti_FajloviPredmetaId",
                table: "Predmeti",
                column: "FajloviPredmetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Predmeti_KlijentId",
                table: "Predmeti",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Predmeti_StatusId",
                table: "Predmeti",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Predmeti_VrstaId",
                table: "Predmeti",
                column: "VrstaId");

            migrationBuilder.CreateIndex(
                name: "IX_Predmeti_ZaposleniciId",
                table: "Predmeti",
                column: "ZaposleniciId");

            migrationBuilder.CreateIndex(
                name: "IX_RadniSati_PredmetId",
                table: "RadniSati",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_RadniSati_ZaposleniciId",
                table: "RadniSati",
                column: "ZaposleniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Rocista_PredmetID",
                table: "Rocista",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Rocista_ZaposlenikId",
                table: "Rocista",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Sastanci_KlijentId",
                table: "Sastanci",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sastanci_VrstaId",
                table: "Sastanci",
                column: "VrstaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sastanci_ZaposleniciId",
                table: "Sastanci",
                column: "ZaposleniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Troskovi_PredmetID",
                table: "Troskovi",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Ugovori_ZaposleniciId",
                table: "Ugovori",
                column: "ZaposleniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadaci_ZaposleniciId",
                table: "Zadaci",
                column: "ZaposleniciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokumenti");

            migrationBuilder.DropTable(
                name: "ListaKontakata");

            migrationBuilder.DropTable(
                name: "RadniSati");

            migrationBuilder.DropTable(
                name: "Rocista");

            migrationBuilder.DropTable(
                name: "Sastanci");

            migrationBuilder.DropTable(
                name: "Troskovi");

            migrationBuilder.DropTable(
                name: "Ugovori");

            migrationBuilder.DropTable(
                name: "Uredi");

            migrationBuilder.DropTable(
                name: "Zadaci");

            migrationBuilder.DropTable(
                name: "KategorijeDokumenata");

            migrationBuilder.DropTable(
                name: "Predmeti");

            migrationBuilder.DropTable(
                name: "FajloviPredmeta");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "VrstaUsluge");

            migrationBuilder.DropTable(
                name: "Uloge");
        }
    }
}

﻿// <auto-generated />
using System;
using Advokati.WebAPI.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Advokati.WebAPI.Migrations
{
    [DbContext(typeof(AdvokatiContext))]
    [Migration("20200617103137_PromjenaBaze")]
    partial class PromjenaBaze
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Advokati.WebAPI.Database.Dokumenti", b =>
                {
                    b.Property<int>("DokumentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ekstenzija");

                    b.Property<int>("KategorijaDokumentaId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("DokumentId");

                    b.HasIndex("KategorijaDokumentaId");

                    b.ToTable("Dokumenti");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.FajloviPredmeta", b =>
                {
                    b.Property<int>("FajlPredmetaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ekstenzija");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("FajlPredmetaId");

                    b.ToTable("FajloviPredmeta");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.KategorijeDokumenata", b =>
                {
                    b.Property<int>("KategorijaDokumentaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("KategorijaDokumentaId");

                    b.ToTable("KategorijeDokumenata");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Korisnici", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Email");

                    b.Property<string>("Grad");

                    b.Property<string>("Ime");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("JMBG");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("LozinkaHash");

                    b.Property<string>("LozinkaSalt");

                    b.Property<string>("Prezime");

                    b.Property<string>("RadniStaz");

                    b.Property<string>("Spol");

                    b.Property<bool?>("Status");

                    b.Property<string>("Telefon");

                    b.Property<int>("UlogeId");

                    b.HasKey("KorisnikId");

                    b.HasIndex("UlogeId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.ListaKontakata", b =>
                {
                    b.Property<int>("KontaktId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("Email");

                    b.Property<string>("Grad");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("KontaktId");

                    b.ToTable("ListaKontakata");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Predmeti", b =>
                {
                    b.Property<int>("PredmetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojPredmeta");

                    b.Property<DateTime>("DatumPocetka");

                    b.Property<int>("FajloviPredmetaId");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int>("KlijentId");

                    b.Property<string>("NazivPredmeta");

                    b.Property<DateTime?>("RokZavrsetka");

                    b.Property<int>("StatusId");

                    b.Property<int>("VrstaId");

                    b.Property<int>("ZaposleniciId");

                    b.HasKey("PredmetId");

                    b.HasIndex("FajloviPredmetaId");

                    b.HasIndex("KlijentId");

                    b.HasIndex("StatusId");

                    b.HasIndex("VrstaId");

                    b.HasIndex("ZaposleniciId");

                    b.ToTable("Predmeti");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.RadniSati", b =>
                {
                    b.Property<int>("RadniSatiId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BrojRadnihSati");

                    b.Property<decimal>("CijenaPoSatu");

                    b.Property<decimal>("CijenaPrekovremenogSata");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Opis");

                    b.Property<int?>("PredmetId");

                    b.Property<decimal>("PrekovremeniSati");

                    b.Property<int>("ZaposleniciId");

                    b.HasKey("RadniSatiId");

                    b.HasIndex("PredmetId");

                    b.HasIndex("ZaposleniciId");

                    b.ToTable("RadniSati");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Rocista", b =>
                {
                    b.Property<int>("RocisteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRocista");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Mjesto");

                    b.Property<string>("Napomena");

                    b.Property<bool>("Odrzano");

                    b.Property<int>("PredmetID");

                    b.Property<int>("ZaposlenikId");

                    b.HasKey("RocisteId");

                    b.HasIndex("PredmetID");

                    b.HasIndex("ZaposlenikId");

                    b.ToTable("Rocista");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Sastanci", b =>
                {
                    b.Property<int>("SastanakId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumSastanka");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int>("KlijentId");

                    b.Property<string>("MjestoOdrzavanja");

                    b.Property<bool?>("Odobreno");

                    b.Property<bool?>("Odrzan");

                    b.Property<string>("Poruka");

                    b.Property<int?>("VrstaId");

                    b.Property<int>("ZaposleniciId");

                    b.HasKey("SastanakId");

                    b.HasIndex("KlijentId");

                    b.HasIndex("VrstaId");

                    b.HasIndex("ZaposleniciId");

                    b.ToTable("Sastanci");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Troskovi", b =>
                {
                    b.Property<int>("TrosakId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DatumUplate");

                    b.Property<bool?>("IsDeleted");

                    b.Property<decimal>("Iznos");

                    b.Property<string>("Opis");

                    b.Property<int>("PredmetID");

                    b.Property<DateTime>("RokUplate");

                    b.Property<string>("Sifra");

                    b.HasKey("TrosakId");

                    b.HasIndex("PredmetID");

                    b.ToTable("Troskovi");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Ugovori", b =>
                {
                    b.Property<int>("UgovorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumPotpisivanja");

                    b.Property<DateTime?>("DatumRaskida");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Napomena");

                    b.Property<string>("Naslov");

                    b.Property<int>("ZaposleniciId");

                    b.Property<bool?>("Zavrsen");

                    b.HasKey("UgovorId");

                    b.HasIndex("ZaposleniciId");

                    b.ToTable("Ugovori");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Uloge", b =>
                {
                    b.Property<int>("UlogaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("UlogaId");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Ured", b =>
                {
                    b.Property<int>("UredId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("Email");

                    b.Property<string>("Grad");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Naziv");

                    b.Property<string>("PostanskiBroj");

                    b.Property<string>("Telefon");

                    b.Property<int>("ZiroRacun");

                    b.HasKey("UredId");

                    b.ToTable("Uredi");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.VrstaUsluge", b =>
                {
                    b.Property<int>("VrstaUslugeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("VrstaUslugeId");

                    b.ToTable("VrstaUsluge");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Zadaci", b =>
                {
                    b.Property<int>("ZadatakId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumPocetka");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<DateTime>("Rok");

                    b.Property<int>("ZaposleniciId");

                    b.Property<bool?>("Zavrsen");

                    b.HasKey("ZadatakId");

                    b.HasIndex("ZaposleniciId");

                    b.ToTable("Zadaci");
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Dokumenti", b =>
                {
                    b.HasOne("Advokati.WebAPI.Database.KategorijeDokumenata", "KategorijaDokumenta")
                        .WithMany()
                        .HasForeignKey("KategorijaDokumentaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Korisnici", b =>
                {
                    b.HasOne("Advokati.WebAPI.Database.Uloge", "Uloge")
                        .WithMany()
                        .HasForeignKey("UlogeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Predmeti", b =>
                {
                    b.HasOne("Advokati.WebAPI.Database.FajloviPredmeta", "FajloviPredmeta")
                        .WithMany()
                        .HasForeignKey("FajloviPredmetaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Advokati.WebAPI.Database.Korisnici", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Advokati.WebAPI.Database.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Advokati.WebAPI.Database.VrstaUsluge", "VrstaUsluge")
                        .WithMany()
                        .HasForeignKey("VrstaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Advokati.WebAPI.Database.Korisnici", "Zaposlenici")
                        .WithMany()
                        .HasForeignKey("ZaposleniciId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.RadniSati", b =>
                {
                    b.HasOne("Advokati.WebAPI.Database.Predmeti", "Predmeti")
                        .WithMany()
                        .HasForeignKey("PredmetId");

                    b.HasOne("Advokati.WebAPI.Database.Korisnici", "Zaposlenici")
                        .WithMany()
                        .HasForeignKey("ZaposleniciId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Rocista", b =>
                {
                    b.HasOne("Advokati.WebAPI.Database.Predmeti", "Predmeti")
                        .WithMany()
                        .HasForeignKey("PredmetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Advokati.WebAPI.Database.Korisnici", "Zaposlenici")
                        .WithMany()
                        .HasForeignKey("ZaposlenikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Sastanci", b =>
                {
                    b.HasOne("Advokati.WebAPI.Database.Korisnici", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Advokati.WebAPI.Database.VrstaUsluge", "VrstaUsluge")
                        .WithMany()
                        .HasForeignKey("VrstaId");

                    b.HasOne("Advokati.WebAPI.Database.Korisnici", "Zaposlenici")
                        .WithMany()
                        .HasForeignKey("ZaposleniciId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Troskovi", b =>
                {
                    b.HasOne("Advokati.WebAPI.Database.Predmeti", "Predmeti")
                        .WithMany()
                        .HasForeignKey("PredmetID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Ugovori", b =>
                {
                    b.HasOne("Advokati.WebAPI.Database.Korisnici", "Zaposlenici")
                        .WithMany()
                        .HasForeignKey("ZaposleniciId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Advokati.WebAPI.Database.Zadaci", b =>
                {
                    b.HasOne("Advokati.WebAPI.Database.Korisnici", "Zaposlenici")
                        .WithMany()
                        .HasForeignKey("ZaposleniciId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

using Advokati.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.EF
{
    public class AdvokatiContext: DbContext
    {
        public AdvokatiContext(DbContextOptions<AdvokatiContext> options)
    : base(options)
        {
        }

     
        public DbSet<Predmeti> Predmeti { get; set; }
        public DbSet<Rocista> Rocista { get; set; }

        public DbSet<Sastanci> Sastanci { get; set; }

        public DbSet<Zadaci> Zadaci { get; set; }

        public DbSet<Ugovori> Ugovori { get; set; }

        public DbSet<RadniSati> RadniSati { get; set; }

        public DbSet<Ured> Uredi { get; set; }
        public DbSet<Troskovi> Troskovi { get; set; }

        public DbSet<Korisnici> Korisnici { get; set; }

        public DbSet<Status> Status { get; set; }
        public DbSet<Uloge> Uloge { get; set; }

        public DbSet<VrstaUsluge> VrstaUsluge { get; set; }

        public DbSet<Dokumenti> Dokumenti { get; set; }

        public DbSet<FajloviPredmeta> FajloviPredmeta { get; set; }

        public DbSet<KategorijeDokumenata> KategorijeDokumenata { get; set; }

        public DbSet<ListaKontakata> ListaKontakata { get; set; }

        public DbSet<Ocjene> Ocjene { get; set; }

        public DbSet<Postavke> Postavke { get; set; }

        public DbSet<ZapisnikRocista> ZapisnikRocista { get; set; }



    }
}

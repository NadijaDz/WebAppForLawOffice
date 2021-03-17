using Advokati.Model.Requests;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Mappers
{
    public class Mapper: Profile
    {
        public Mapper()
        {
          
            CreateMap<Database.Korisnici, Model.Korisnici>()
                .ForMember(d => d.NazivUloge, opt => opt.MapFrom(s => s.Uloge == null ? null : s.Uloge.Naziv))
                ;

            CreateMap<Database.Korisnici, KorisniciInsertRequest>().ReverseMap();


            CreateMap<Database.Predmeti, Model.Predmeti>()
                         .ForMember(d => d.Zaposlenik, opt => opt.MapFrom(s => s.Zaposlenici == null ? null : s.Zaposlenici.Ime + " " + s.Zaposlenici.Prezime))
                      .ForMember(d => d.Klijent, opt => opt.MapFrom(s => s.Klijent == null ? null : s.Klijent.Ime + " " + s.Klijent.Prezime))
                     .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status == null ? null : s.Status.Naziv))
                    .ForMember(d => d.VrstaUsluge, opt => opt.MapFrom(s => s.VrstaUsluge == null ? null : s.VrstaUsluge.Naziv))
                    .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Klijent == null ? null : s.Klijent.Email))


                ;
            CreateMap<Database.Predmeti, PredmetiInsertRequest>().ReverseMap();



            CreateMap<Database.RadniSati, Model.RadniSati>()
                   .ForMember(d => d.Zaposlenik, opt => opt.MapFrom(s => s.Zaposlenici == null ? null : s.Zaposlenici.Ime + " " + s.Zaposlenici.Prezime))
                     .ForMember(d => d.BrojPredmeta, opt => opt.MapFrom(s => s.Predmeti == null ? null : s.Predmeti.BrojPredmeta));

            CreateMap<Database.RadniSati, RadniSatiInsertRequest>().ReverseMap();


            CreateMap<Database.Troskovi, Model.Troskovi>()
                   .ForMember(d => d.BrojPredmeta, opt => opt.MapFrom(s => s.Predmeti == null ? null : s.Predmeti.BrojPredmeta))
                ;
            CreateMap<Database.Troskovi,TroskoviInsertRequest >().ReverseMap();


          


            CreateMap<Database.Sastanci, Model.Sastanci>()
                         .ForMember(d => d.Zaposlenik, opt => opt.MapFrom(s => s.Zaposlenici == null ? null : s.Zaposlenici.Ime + " " + s.Zaposlenici.Prezime))
                      .ForMember(d => d.Klijent, opt => opt.MapFrom(s => s.Klijent == null ? null : s.Klijent.Ime + " " + s.Klijent.Prezime))
                      .ForMember(d => d.VrstaPredmeta, opt => opt.MapFrom(s => s.VrstaUsluge == null ? null : s.VrstaUsluge.Naziv))
                ;
            CreateMap<Database.Sastanci, SastanciInsertRequest>().ReverseMap();


            CreateMap<Database.Ured, Model.Ured>();
            CreateMap<Database.Ured, UredInsertRequest>().ReverseMap();


            CreateMap<Database.Rocista, Model.Rocista>()
                      .ForMember(d => d.Zaposlenik, opt => opt.MapFrom(s => s.Zaposlenici == null ? null : s.Zaposlenici.Ime + " " + s.Zaposlenici.Prezime))
                      .ForMember(d => d.BrojPredmeta, opt => opt.MapFrom(s => s.Predmeti == null ? null : s.Predmeti.BrojPredmeta))
                ;

            CreateMap<Database.Rocista, RocistaInsertRequest>().ReverseMap();


            CreateMap<Database.Zadaci, Model.Zadaci>()
                    .ForMember(d => d.Zaposlenik, opt => opt.MapFrom(s => s.Zaposlenici == null ? null : s.Zaposlenici.Ime + " " + s.Zaposlenici.Prezime))
                ;
            CreateMap<Database.Zadaci, ZadaciInsertRequest>().ReverseMap();



            CreateMap<Database.Ugovori, Model.Ugovori>()
                  .ForMember(d => d.Zaposlenik, opt => opt.MapFrom(s => s.Zaposlenici == null ? null : s.Zaposlenici.Ime+" "+s.Zaposlenici.Prezime))
                ;
            CreateMap<Database.Ugovori, UgovoriInsertRequest>().ReverseMap();


            CreateMap<Database.Dokumenti, Model.Dokumenti>()
                  .ForMember(d => d.KategorijaDokumenta, opt => opt.MapFrom(s => s.KategorijaDokumenta == null ? null : s.KategorijaDokumenta.Naziv))
                ;
            CreateMap<Database.Dokumenti, DokumentiInsertRequest>().ReverseMap();


            CreateMap<Database.Uloge, Model.Uloge>();
            CreateMap<Database.Status, Model.Status>();
            CreateMap<Database.VrstaUsluge, Model.VrstaUsluge>();

         

            CreateMap<Database.FajloviPredmeta, Model.Fajlovi>()
                   .ForMember(d => d.BrojPredmeta, opt => opt.MapFrom(s => s.Predmeti == null ? null : s.Predmeti.BrojPredmeta))
                ;
            CreateMap<Database.FajloviPredmeta, FajloviInsertRequest>().ReverseMap();




            CreateMap<Database.ListaKontakata, Model.Kontaktlista>();
            CreateMap<Database.ListaKontakata, KontaktlistaInsertRequest>().ReverseMap();

            CreateMap<Database.KategorijeDokumenata, Model.KategorijeDokumenata>();
            CreateMap<Database.KategorijeDokumenata, KategorijeDokumenataInsertRequest>().ReverseMap();


            CreateMap<Database.Ocjene, Model.Ocjene>()
                    .ForMember(d => d.Zaposlenik, opt => opt.MapFrom(s => s.Zaposlenici == null ? null : s.Zaposlenici.Ime + " " + s.Zaposlenici.Prezime))
                 .ForMember(d => d.Klijent, opt => opt.MapFrom(s => s.Klijent == null ? null : s.Klijent.Ime + " " + s.Klijent.Prezime))
                
           ;
            CreateMap<Database.Ocjene, OcjeneInsertRequest>().ReverseMap();


            CreateMap<Database.Postavke, Model.Postavke>()
                   .ForMember(d => d.Korisnik, opt => opt.MapFrom(s => s.Korisnici == null ? null : s.Korisnici.Ime + " " + s.Korisnici.Prezime))
          ;
            CreateMap<Database.Postavke, PostavkeInsertRequest>().ReverseMap();



            CreateMap<Database.ZapisnikRocista, Model.ZapisnikRocista>()
                   .ForMember(d => d.Mjesto, opt => opt.MapFrom(s => s.Rocista == null ? null : s.Rocista.Mjesto))
                ;
            CreateMap<Database.ZapisnikRocista, ZapisnikRocistaInsertRequest>().ReverseMap();





        }
    }
}

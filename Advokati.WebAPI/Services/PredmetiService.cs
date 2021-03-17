using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advokati.Model;
using Advokati.Model.Requests;
using Advokati.WebAPI.EF;
using Advokati.WebAPI.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Advokati.WebAPI.Services
{
    public class PredmetiService : IPredmetiService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public PredmetiService(AdvokatiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Predmeti> Get(PredmetiSearchRequest request)
        {
            var query = _context.Predmeti.AsQueryable().Include(c => c.Zaposlenici).Include(k => k.Klijent).Include(s => s.Status).Include(v => v.VrstaUsluge);

            if (!string.IsNullOrWhiteSpace(request?.BrojPredmeta))
            {
                query = query.Where(x => x.BrojPredmeta.StartsWith(request.BrojPredmeta)).Include(c => c.Zaposlenici).Include(k => k.Klijent).Include(s => s.Status).Include(v => v.VrstaUsluge);
            }

            var datum = DateTime.MinValue;
            if (request.DatumOd.Date != datum.Date && request.DatumDo.Date != datum.Date)
            {
                query = query.Where(x => x.DatumPocetka >= request.DatumOd && x.DatumPocetka <= request.DatumDo).Include(c => c.Zaposlenici).Include(k => k.Klijent).Include(s => s.Status).Include(v => v.VrstaUsluge);
            }



            query = query.Where(p => p.IsDeleted == false).Include(k => k.Klijent).Include(s => s.Status).Include(v => v.VrstaUsluge);

            var list = query.ToList();

            return _mapper.Map<List<Model.Predmeti>>(list);
        }

        public Model.Predmeti GetById(int id)
        {
            var entity = _context.Predmeti.Find(id);
            return _mapper.Map<Model.Predmeti>(entity);
        }

        public Model.Predmeti Insert(PredmetiInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.Predmeti>(request);

    
            _context.Predmeti.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Predmeti>(entity);

        }

        public Model.Predmeti Update(int id, PredmetiInsertRequest request)
        {
            var entity = _context.Predmeti.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();

            return _mapper.Map<Model.Predmeti>(entity);

        }


        public Model.Predmeti Delete(int id, PredmetiInsertRequest request)
        {
            var entity = _context.Predmeti.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Predmeti>(entity);
        }

        public string mailByKlijent(int id)
        {
            var query = _context.Predmeti.AsQueryable().Include(c => c.Zaposlenici).Include(k => k.Klijent).Where(x => x.PredmetId.Equals(id));

            var temp = query.FirstOrDefault();

            string mail = temp.Klijent.Email;

            return mail;


        }


        public List<Model.Predmeti> GetTodayPredmeti(PredmetiSearchRequest request)
        {
            var query = _context.Predmeti.AsQueryable().Include(c => c.Zaposlenici).Include(k => k.Klijent).Include(s => s.Status).Include(v => v.VrstaUsluge);

          

            
            query = query.Where( x => x.DatumPocetka.Date== DateTime.Now.Date).Include(c => c.Zaposlenici).Include(k => k.Klijent).Include(s => s.Status).Include(v => v.VrstaUsluge);
            



            query = query.Where(p => p.IsDeleted == false).Include(k => k.Klijent).Include(s => s.Status).Include(v => v.VrstaUsluge);

            var list = query.ToList();

            return _mapper.Map<List<Model.Predmeti>>(list);
        }





        public List<Database.Korisnici> GetAdvokatiPreporuka(int vrstaUslugeId)
        {
            var query = _context.Predmeti.AsQueryable().Include(c => c.VrstaUsluge).Include(z => z.Zaposlenici.Uloge).Include(s => s.Status);


            query = query.Where(x => x.VrstaId == vrstaUslugeId && x.Status.Naziv=="Uspješno završeno").Include(c => c.Zaposlenici).Include(s => s.Status);

            query = query.Where(p => p.IsDeleted == false).Include(c => c.Klijent).Include(z => z.Zaposlenici).Include(s => s.Status);


            var list = query.ToList();


            List<Database.Korisnici> listAdvokata = new List<Database.Korisnici>();


            foreach (var item in list)
            {

                bool alreadyExist = listAdvokata.Contains(item.Zaposlenici);
                if (alreadyExist == false)
                {
                   // if (item.Zaposlenici.UlogeId == 1)
                        if (item.Zaposlenici.Uloge.Naziv == "Advokat")
                        {
                        listAdvokata.Add(item.Zaposlenici);

                    }
                }

            }



            return listAdvokata;
        }


        public List<Model.Predmeti> Get2(PredmetiSearchRequest request)
        {


            var predmeti = _context.Predmeti.ToList();
            var troskovi = _context.Troskovi.ToList();

            List<Database.Predmeti> listPredmetaSaNulaTransakcija = new List<Database.Predmeti>();
            decimal countTransakcije = 0;
            bool transakcijeVeceODNula = false;

            foreach (var p in predmeti)
            {
                countTransakcije = 0;
                transakcijeVeceODNula = false;
                foreach (var t in troskovi)
                {
                    if (p.PredmetId == t.PredmetID && t.Iznos == 0 && p.RokUplate < DateTime.Now)
                    {
                        listPredmetaSaNulaTransakcija.Add(p);
                        //salji mail
                    }
                    if (p.PredmetId == t.PredmetID)
                    {
                        countTransakcije += t.Iznos;
                    }
                    if (p.PredmetId == t.PredmetID && t.Iznos > 0 && p.RokUplate < DateTime.Now)
                    {
                        transakcijeVeceODNula = true;
                    }
                }

                if (countTransakcije < p.UkupniTrosak && transakcijeVeceODNula)
                {
                    //salji mail
                }
            }




            var datum = DateTime.MinValue;
            if (request.DatumOd.Date != datum.Date && request.DatumDo.Date != datum.Date)
            {
                // query = query.Where(x => x.DatumPocetka >= request.DatumOd && x.DatumPocetka <= request.DatumDo).Include(c => c.Zaposlenici).Include(k => k.Klijent).Include(s => s.Status).Include(v => v.VrstaUsluge);
            }



            //  query = query.Where(p => p.IsDeleted == false).Include(k => k.Klijent).Include(s => s.Status).Include(v => v.VrstaUsluge);

            var list = listPredmetaSaNulaTransakcija.ToList();

            return _mapper.Map<List<Model.Predmeti>>(list);
        }




    }
}

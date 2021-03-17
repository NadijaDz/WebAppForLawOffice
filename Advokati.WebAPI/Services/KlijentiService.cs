using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advokati.Model;
using Advokati.Model.Requests;
using Advokati.WebAPI.EF;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Advokati.WebAPI.Services
{
    public class KlijentiService : IKlijentiService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public KlijentiService(AdvokatiContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Korisnici> Get(KorisniciSearchRequest request)
        {
           
            var uloge = _context.Uloge.ToList();
            var id = -1;
            foreach (var u in uloge)
            {
                if (u.Naziv == "Klijent")
                {
                    id = u.UlogaId;
                }
            }

            var query1 = _context.Korisnici.AsQueryable().Include(c => c.Uloge);

            if (!string.IsNullOrWhiteSpace(request?.ImePrezime))
            {
                query1 = query1.Where(x => x.Ime.StartsWith(request.ImePrezime) || x.Prezime.StartsWith(request.ImePrezime)).Include(c => c.Uloge);
            }
            query1 = query1.Where(p => p.UlogeId == id).Include(c => c.Uloge);
            query1 = query1.Where(p => p.IsDeleted == false).Include(c => c.Uloge);

            var list1 = query1.ToList();
            return _mapper.Map<List<Model.Korisnici>>(list1);

        }

        public Model.Korisnici GetById(int id)
        {
            var entity = _context.Korisnici.Find(id);
            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.Korisnici>(request);
            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Update(int id, KorisniciInsertRequest request)
        {
            var entity = _context.Korisnici.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Delete(int id, KorisniciInsertRequest request)
        {
            var entity = _context.Korisnici.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Korisnici>(entity);
            
        }
    }
}

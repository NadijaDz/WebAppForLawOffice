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
    public class OcjeneService : IOcjeneService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public OcjeneService(AdvokatiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Ocjene> Get(OcjeneSearchRequest request)
        {
            var query = _context.Ocjene.AsQueryable().Include(c => c.Zaposlenici).Include(k => k.Klijent);

            if (!string.IsNullOrWhiteSpace(request?.Ocjena))
            {
                query = query.Where(x => x.Ocjena.StartsWith(request.Ocjena)).Include(c => c.Zaposlenici).Include(k => k.Klijent);
            }

           

            query = query.Where(p => p.IsDeleted == false).Include(k => k.Klijent);

            var list = query.ToList();

            return _mapper.Map<List<Model.Ocjene>>(list);
        }

        public Model.Ocjene GetById(int id)
        {
            var entity = _context.Ocjene.Find(id);
            return _mapper.Map<Model.Ocjene>(entity);
        }

        public Model.Ocjene Insert(OcjeneInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.Ocjene>(request);


            _context.Ocjene.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Ocjene>(entity);

        }

        public Model.Ocjene Update(int id, OcjeneInsertRequest request)
        {
            var entity = _context.Ocjene.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();

            return _mapper.Map<Model.Ocjene>(entity);

        }


        public Model.Ocjene Delete(int id, OcjeneInsertRequest request)
        {
            var entity = _context.Ocjene.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Ocjene>(entity);
        }
    }
}

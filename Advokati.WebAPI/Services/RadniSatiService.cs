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
    public class RadniSatiService : IRadniSatiService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public RadniSatiService(AdvokatiContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<RadniSati> Get(RadniSatiSearchRequest request)
        {

            var query = _context.RadniSati.AsQueryable().Include(c => c.Zaposlenici).Include(p => p.Predmeti);

            if (request.ZaposleniciId>0)
            {
                query = query.Where(x => x.ZaposleniciId == request.ZaposleniciId).Include(c => c.Zaposlenici).Include(p => p.Predmeti);
            }

            if(request.BrojPredmeta!=null)
            {
                query = query.Where(x => x.Predmeti.BrojPredmeta == request.BrojPredmeta).Include(c => c.Zaposlenici).Include(p => p.Predmeti);
            }
            
           query = query.Where(p => p.IsDeleted == false).Include(c => c.Zaposlenici).Include(p => p.Predmeti);

            var list = query.ToList();
            return _mapper.Map<List<Model.RadniSati>>(list);

        }

        public Model.RadniSati GetById(int id)
        {
            var entity = _context.RadniSati.Find(id);
            return _mapper.Map<Model.RadniSati>(entity);
        }

        public Model.RadniSati Insert(RadniSatiInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.RadniSati>(request);

            _context.RadniSati.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.RadniSati>(entity);


        }

        public Model.RadniSati Update(int id, RadniSatiInsertRequest request)
        {
             var entity = _context.RadniSati.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map<Model.RadniSati>(entity);
        }

        public Model.RadniSati Delete(int id, RadniSatiInsertRequest request)
        {
            var entity = _context.RadniSati.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.RadniSati>(entity);
        }

    }
}

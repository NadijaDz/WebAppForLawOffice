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
    public class UgovoriService : IUgovoriService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public UgovoriService(AdvokatiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Ugovori> Get(UgovoriSearchRequest request)
        {

            var query = _context.Ugovori.AsQueryable().Include(c => c.Zaposlenici);

            var datum = DateTime.MinValue;


            if (datum != request.DatumPotpisivanja)

            {
                request.DatumPotpisivanja = request.DatumPotpisivanja.AddHours(-2);

                query = query.Where(x => x.DatumPotpisivanja.ToString("dd-MMM-yyyy").StartsWith(request.DatumPotpisivanja.ToString("dd-MMM-yyyy"))).Include(c => c.Zaposlenici);
            }

            query = query.Where(p => p.IsDeleted == false).Include(c => c.Zaposlenici);

            var list = query.ToList();
            return _mapper.Map<List<Model.Ugovori>>(list);
        }

        public Model.Ugovori GetById(int id)
        {
            var entity = _context.Ugovori.Find(id);
            return _mapper.Map<Model.Ugovori>(entity);
        }

        public Model.Ugovori Insert(UgovoriInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.Ugovori>(request);
            _context.Ugovori.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Ugovori>(entity);
        }

        public Model.Ugovori Update(int id, UgovoriInsertRequest request)
        {
            var entity = _context.Ugovori.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map<Model.Ugovori>(entity);
        }

        public Model.Ugovori Delete(int id, UgovoriInsertRequest request)
        {
            var entity = _context.Ugovori.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Ugovori>(entity);
        }

    }
}

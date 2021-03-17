using Advokati.Model;
using Advokati.Model.Requests;
using Advokati.WebAPI.EF;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
    public class ZapisnikRocistaService: IZapisnikRocistaService
    {


        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public ZapisnikRocistaService(AdvokatiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<ZapisnikRocista> Get(ZapisnikRocistaSearchRequest request)
        {

            var query = _context.ZapisnikRocista.AsQueryable().Include(c => c.Rocista);

            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.Naziv)).Include(c => c.Rocista);
            }

            query = query.Where(p => p.IsDeleted == false).Include(c => c.Rocista);

            var list = query.ToList();
            return _mapper.Map<List<Model.ZapisnikRocista>>(list);

        }

        public Model.ZapisnikRocista GetById(int id)
        {
            var entity = _context.FajloviPredmeta.Find(id);
            return _mapper.Map<Model.ZapisnikRocista>(entity);
        }

        public Model.ZapisnikRocista Insert(ZapisnikRocistaInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.ZapisnikRocista>(request);

            _context.ZapisnikRocista.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.ZapisnikRocista>(entity);


        }

        public Model.ZapisnikRocista Update(int id, ZapisnikRocistaInsertRequest request)
        {
            var entity = _context.ZapisnikRocista.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map<Model.ZapisnikRocista>(entity);
        }

        public Model.ZapisnikRocista Delete(int id, ZapisnikRocistaInsertRequest request)
        {
            var entity = _context.ZapisnikRocista.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.ZapisnikRocista>(entity);
        }

    }
}

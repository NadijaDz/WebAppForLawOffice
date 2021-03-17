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
    public class DokumentiService:IDokumentiService
    {

        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public DokumentiService(AdvokatiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Dokumenti> Get(DokumentiSearchReequest request)
        {

            var query = _context.Dokumenti.AsQueryable().Include(c => c.KategorijaDokumenta);

           
            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.Naziv)).Include(c => c.KategorijaDokumenta);
            }

            query = query.Where(p => p.IsDeleted == false).Include(c => c.KategorijaDokumenta);

            var list = query.ToList();
            return _mapper.Map<List<Model.Dokumenti>>(list);

        }

        public Model.Dokumenti GetById(int id)
        {
            var entity = _context.Dokumenti.Find(id);
            return _mapper.Map<Model.Dokumenti>(entity);
        }

        public Model.Dokumenti Insert(DokumentiInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.Dokumenti>(request);

            _context.Dokumenti.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Dokumenti>(entity);


        }

        public Model.Dokumenti Update(int id, DokumentiInsertRequest request)
        {
            var entity = _context.Dokumenti.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map<Model.Dokumenti>(entity);
        }

        public Model.Dokumenti Delete(int id, DokumentiInsertRequest request)
        {
            var entity = _context.Dokumenti.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Dokumenti>(entity);
        }


    }
}

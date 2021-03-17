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
    public class FajloviService:IFajloviService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public FajloviService(AdvokatiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Fajlovi> Get(FajloviSearchRequest request)
        {

            var query = _context.FajloviPredmeta.AsQueryable().Include(c => c.Predmeti);

            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.Naziv)).Include(c => c.Predmeti);
            }

            query = query.Where(p => p.IsDeleted == false).Include(c => c.Predmeti);

            var list = query.ToList();
            return _mapper.Map<List<Model.Fajlovi>>(list);

        }

        public Model.Fajlovi GetById(int id)
        {
            var entity = _context.FajloviPredmeta.Find(id);
            return _mapper.Map<Model.Fajlovi>(entity);
        }

        public Model.Fajlovi Insert(FajloviInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.FajloviPredmeta>(request);

            _context.FajloviPredmeta.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Fajlovi>(entity);


        }

        public Model.Fajlovi Update(int id, FajloviInsertRequest request)
        {
            var entity = _context.FajloviPredmeta.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map<Model.Fajlovi>(entity);
        }

        public Model.Fajlovi Delete(int id, FajloviInsertRequest request)
        {
            var entity = _context.FajloviPredmeta.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Fajlovi>(entity);
        }

       

      
     
    }
}

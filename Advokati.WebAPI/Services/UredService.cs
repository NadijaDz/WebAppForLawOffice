using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advokati.Model;
using Advokati.Model.Requests;
using Advokati.WebAPI.EF;
using AutoMapper;

namespace Advokati.WebAPI.Services
{
    public class UredService : IUredService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public UredService(AdvokatiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      

        public List<Ured> Get(UredSearchRequest request)
        {

            var query = _context.Uredi.AsQueryable();

            if(!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.Naziv));
            }

            query = query.Where(p => p.IsDeleted == false);
            var list = query.ToList();
            return _mapper.Map<List<Model.Ured>>(list);
     
        }

        public Model.Ured GetById(int id)
        {

            var entity = _context.Uredi.Find(id);

            return _mapper.Map<Model.Ured>(entity);


        }

        public Model.Ured Insert(UredInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.Ured>(request);
            _context.Uredi.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Ured>(entity);
        }

        public Model.Ured Update(int id, UredInsertRequest request)
        {
            var entity = _context.Uredi.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map<Model.Ured>(entity);
        }


        public Model.Ured Delete(int id, UredInsertRequest request)
        {
            var entity = _context.Uredi.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Ured>(entity);
        }
    }
}

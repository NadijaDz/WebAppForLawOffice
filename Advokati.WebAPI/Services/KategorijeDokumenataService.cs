using Advokati.Model;
using Advokati.Model.Requests;
using Advokati.WebAPI.EF;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advokati.WebAPI.Services
{
    public class KategorijeDokumenataService: IKategorijeDokumenataService
    {

        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public KategorijeDokumenataService(AdvokatiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<KategorijeDokumenata> Get(KategorijeDokumenataSearchRequest request)
        {

            var query = _context.KategorijeDokumenata.AsQueryable();


            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.Naziv));
            }

            query = query.Where(p => p.IsDeleted == false);

            var list = query.ToList();
            return _mapper.Map<List<Model.KategorijeDokumenata>>(list);

        }

        public Model.KategorijeDokumenata GetById(int id)
        {
            var entity = _context.KategorijeDokumenata.Find(id);
            return _mapper.Map<Model.KategorijeDokumenata>(entity);
        }

        public Model.KategorijeDokumenata Insert(KategorijeDokumenataInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.KategorijeDokumenata>(request);

            _context.KategorijeDokumenata.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.KategorijeDokumenata>(entity);


        }

        public Model.KategorijeDokumenata Update(int id, KategorijeDokumenataInsertRequest request)
        {
            var entity = _context.KategorijeDokumenata.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map<Model.KategorijeDokumenata>(entity);
        }

        public Model.KategorijeDokumenata Delete(int id, KategorijeDokumenataInsertRequest request)
        {
            var entity = _context.KategorijeDokumenata.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.KategorijeDokumenata>(entity);
        }
    }
}

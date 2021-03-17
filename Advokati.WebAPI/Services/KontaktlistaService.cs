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
    public class KontaktlistaService : IKontaktlistaService
    {

        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;


        public KontaktlistaService(AdvokatiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Model.Kontaktlista> Get(KontaktlistaSearchRequest request)
        {

          

            var query1 = _context.ListaKontakata.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.ImePrezime))
            {
                query1 = query1.Where(x => x.Ime.StartsWith(request.ImePrezime) || x.Prezime.StartsWith(request.ImePrezime));
            }
          
            query1 = query1.Where(p => p.IsDeleted == false);

            var list1 = query1.ToList();
            return _mapper.Map<List<Model.Kontaktlista>>(list1);

        }


        public Model.Kontaktlista GetById(int id)
        {
            var entity = _context.ListaKontakata.Find(id);
            return _mapper.Map<Model.Kontaktlista>(entity);
        }

        public Model.Kontaktlista Insert(KontaktlistaInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.ListaKontakata>(request);
            _context.ListaKontakata.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Kontaktlista>(entity);
        }



       

        public Model.Kontaktlista Update(int id, KontaktlistaInsertRequest request)
        {
            var entity = _context.ListaKontakata.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map < Model.Kontaktlista>(entity);
        }

        public Model.Kontaktlista Delete(int id, KontaktlistaInsertRequest request)
        {
            var entity = _context.ListaKontakata.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Kontaktlista>(entity);

        }





  
    }
}

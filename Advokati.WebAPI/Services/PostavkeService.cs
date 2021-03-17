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
    public class PostavkeService:IPostavkeService
    {

        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public PostavkeService(AdvokatiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public List<Postavke> Get(PostavkeSearchRequest request)
        {

            var query = _context.Postavke.AsQueryable().Include(c => c.Korisnici);

            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.Naziv)).Include(c => c.Korisnici);
            }




            var list = query.ToList();
            return _mapper.Map<List<Model.Postavke>>(list);

        }

        public Model.Postavke GetById(int id)
        {

            var entity = _context.Postavke.Find(id);

            return _mapper.Map<Model.Postavke>(entity);


        }

        public Model.Postavke Insert(PostavkeInsertRequest request)
        {
            
            var entity = _mapper.Map<Database.Postavke>(request);
            _context.Postavke.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Postavke>(entity);
        }

        public Model.Postavke Update(int id, PostavkeInsertRequest request)
        {
            var entity = _context.Postavke.Find(id);
            _mapper.Map(request, entity);
         
            _context.SaveChanges();
            return _mapper.Map<Model.Postavke>(entity);
        }


        public List<Model.Postavke> GetByKorisnikId(int id)
        {
            var query = _context.Postavke.AsQueryable().Include(c => c.Korisnici);

            if (id != 0)
            {
                query = query.Where(x => x.KorisnikId.Equals(id)).Include(c => c.Korisnici);
            }



            var list = query.ToList();



            return _mapper.Map<List<Model.Postavke>>(list);

        }

    }
}

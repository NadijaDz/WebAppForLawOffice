using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advokati.Model;
using Advokati.WebAPI.EF;
using AutoMapper;

namespace Advokati.WebAPI.Services
{
    public class UlogeService : IUlogeService
    {
        private readonly AdvokatiContext _context;

        private readonly IMapper _mapper;
        public UlogeService(AdvokatiContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Uloge> Get()
        {
            var list = _context.Uloge.ToList();
            return _mapper.Map<List<Model.Uloge>>(list);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advokati.Model;
using Advokati.WebAPI.EF;
using AutoMapper;

namespace Advokati.WebAPI.Services
{
    public class VrstaUslugeService : IVrstaUslugeService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public VrstaUslugeService(AdvokatiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<VrstaUsluge> Get()
        {
            var list = _context.VrstaUsluge.ToList();
            return _mapper.Map<List<Model.VrstaUsluge>>(list);
        }
    }
}

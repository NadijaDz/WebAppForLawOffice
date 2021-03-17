using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advokati.Model;
using Advokati.WebAPI.EF;
using AutoMapper;

namespace Advokati.WebAPI.Services
{
    public class StatusService : IStatusService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;
        public StatusService(AdvokatiContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public List<Status> Get()
        {
            var list = _context.Status.ToList();
            return _mapper.Map<List<Model.Status>>(list);
        }
    }
}

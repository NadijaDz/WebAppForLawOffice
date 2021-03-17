using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Advokati.Model;
using Advokati.Model.Requests;
using Advokati.WebAPI.EF;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Advokati.WebAPI.Services
{
    public class TroskoviService : ITroskoviService
    {
        private readonly AdvokatiContext _context;
        private readonly IMapper _mapper;

        public TroskoviService(AdvokatiContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

     

        public List<Troskovi> Get(TroskoviSearchRequest request)
        {
            var query = _context.Troskovi.AsQueryable().Include(c => c.Predmeti);

            if(!string.IsNullOrWhiteSpace(request?.Sifra))
            {
                query = query.Where(x => x.Sifra.StartsWith(request.Sifra)).Include(c => c.Predmeti);
            }


        
            query = query.Where(p => p.IsDeleted == false).Include(c => c.Predmeti);

            var result = query.ToList();
            return _mapper.Map<List<Model.Troskovi>>(result);
        }

        public Model.Troskovi GetById(int id)
        {
            var entity = _context.Troskovi.Find(id);
            return _mapper.Map<Model.Troskovi>(entity);
        }

        public Model.Troskovi Insert(TroskoviInsertRequest request)
        {
            request.IsDeleted = false;
            var entity = _mapper.Map<Database.Troskovi>(request);
            _context.Troskovi.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Troskovi>(entity);
        }

        public Model.Troskovi Update(int id, TroskoviInsertRequest request)
        {
            var entity = _context.Troskovi.Find(id);
            _mapper.Map(request, entity);
            entity.IsDeleted = false;
            _context.SaveChanges();
            return _mapper.Map<Model.Troskovi>(entity);
        }

        public Model.Troskovi Delete(int id, TroskoviInsertRequest request)
        {
            var entity = _context.Troskovi.Find(id);
            request.IsDeleted = true;

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Troskovi>(entity);
        }

        public List<Troskovi> GetAllForReport(string request1, string request2)
        {
           
            string[] dateString1 = request1.Split('-');
            DateTime date1 = Convert.ToDateTime(dateString1[1] + "/" + dateString1[0] + "/" + dateString1[2]);

            string[] dateString = request2.Split('-');
            DateTime date2 = Convert.ToDateTime(dateString[1] + "/" + dateString[0] + "/" + dateString[2]);



            var listaTroskova = _context.Troskovi.Include(c=>c.Predmeti).ToList();

            List<Database.Troskovi> lista = new List<Database.Troskovi>();

            foreach (var troskovi in listaTroskova)
            {
                if (troskovi.IsDeleted == false)
                {
                    int value1 = DateTime.Compare(date1, (DateTime)troskovi.DatumUplate);
                    int value2 = DateTime.Compare(date2, (DateTime)troskovi.DatumUplate);
                    if (value1 < 0 || value2>0)
                    {
                        lista.Add(troskovi);
                    }
                   
                    if (value1 == 0 || value2 == 0)
                    {
                        lista.Add(troskovi);
                    }
                }

            }

            var result = lista.ToList();
            return _mapper.Map<List<Model.Troskovi>>(result);
        }


        public List<Model.Troskovi> GetAllTroskoviByPredmetId(int id)
        {

            var troskovi = _context.Troskovi.Include(c => c.Predmeti).ToList();
            var query = new List<Database.Troskovi>();

    


            foreach (var u in troskovi)
            {
                if (u.PredmetID == id)
                {
                    query.Add(u);
                 
                }


            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Troskovi>>(list);
        }

        public List<Model.Troskovi> GetAllTroskoviByDatum(string datum)
        {

            var troskovi = _context.Troskovi.Include(c => c.Predmeti).ToList();
            var query = new List<Database.Troskovi>();
            int value;

            string[] dateString1 = datum.Split('-');
            DateTime date1 = Convert.ToDateTime(dateString1[1] + "/" + dateString1[0] + "/" + dateString1[2]);

            foreach (var u in troskovi)
            {
                     value = DateTime.Compare(date1, (DateTime)u.DatumUplate);
                    if (value == 0)
                    {
                        query.Add(u);

                    }
               

            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Troskovi>>(list);
        }




        public List<Troskovi> GetAllTroskoviByDatum(TroskoviSearchRequest request)
        {

            //var query = new List<Database.Troskovi>();

            var query = _context.Troskovi.AsQueryable().Include(c => c.Predmeti);

           


            var datum = DateTime.MinValue;

            if (datum != request.DatumUplate)

            {
              

                query = query.Where(x => x.DatumUplate.Value.ToString("dd-MMM-yyyy").StartsWith(request.DatumUplate.ToString("dd-MMM-yyyy"))).Include(p=>p.Predmeti);
            }


            if (request.PredmetID!=0)
            {
                query = query.Where(x => x.PredmetID.Equals(request.PredmetID)).Include(c => c.Predmeti);
            }




            query = query.Where(p => p.IsDeleted == false).Include(c => c.Predmeti);


            var result = query.ToList();
             return _mapper.Map<List<Model.Troskovi>>(result);

        }

        public List<Model.Troskovi> GetAllTroskoviById(int id)
        {
            var query = _context.Troskovi.AsQueryable().Include(c => c.Predmeti);

            query = query.Where(p => p.IsDeleted == false).Include(c => c.Predmeti);


            var predmeti = _context.Predmeti.AsQueryable().Include(c => c.VrstaUsluge).Include(z => z.Zaposlenici);

            predmeti = predmeti.Where(p => p.KlijentId.Equals(id)).Include(c => c.VrstaUsluge).Include(z => z.Zaposlenici);


            List<Database.Troskovi> listTroskova = new List<Database.Troskovi>();


       
            if (predmeti.Count() != 0)
            {
                foreach (var p in predmeti)
                {

                    foreach (var r in query)
                    {
                        if (p.PredmetId == r.PredmetID)
                        {
                            listTroskova.Add(r);
                          

                        }

                    }
                }

            }




          
            
           var  list = listTroskova.ToList();
              
            


            return _mapper.Map<List<Model.Troskovi>>(list);

        }






    }
}

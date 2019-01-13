using Newtonsoft.Json;
using Sistem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemWebApi.Controllers
{
    public class SehirController : ApiController
    {
        SehirDAL dal = new SehirDAL();
        public IEnumerable<Sehir> Get()
        {

            return  (dal.GetAllSehir());
        }
        public Sehir Get(int id)
        {
            return dal.GetSehirById(id);
        }
        public Sehir Post(Sehir sehir)
        {
            return dal.CreateSehir(sehir);
        }
        public Sehir Put(int id ,Sehir sehir)
        {
            return dal.UpdateSehir(id,sehir);
        }
        public void Delete(int id)
        {
             dal.DeleteSehir(id);
        }
    }
}

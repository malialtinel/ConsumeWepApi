using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem.DAL
{
    public class SehirDAL
    {

        SistemVeriEntities db = new SistemVeriEntities();
        public IEnumerable<Sehir> GetAllSehir()
        {
            
            return db.Sehirs;
        }
        public Sehir GetSehirById(int id)
        {
            return db.Sehirs.FirstOrDefault(x=>x.SehirId==id);
        }
        public Sehir CreateSehir(Sehir sehir)
        {
            db.Sehirs.Add(sehir);
            db.SaveChanges();
            return sehir;
        }
        public void DeleteSehir(int id)
        {
            db.Sehirs.Remove(db.Sehirs.FirstOrDefault(x=>x.SehirId==id));
            db.SaveChanges();

        }
        public Sehir UpdateSehir(int id,Sehir sehir)
        {
            db.Entry(sehir).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return sehir;
        }
    }
}

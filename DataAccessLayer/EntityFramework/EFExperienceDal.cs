using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFExperienceDal:GenericRepository<Experience>, IExperienceDal
    {
        public override void Delete(Experience t)
        {
            // Soft delete mantığı
            using var c = new Context();
            var experience = c.Experiences.Find(t.Id);
            if (experience != null)
            {
                experience.IsDeleted = true;
                c.Update(experience);
                c.SaveChanges();
            }
        }

        // GenericRepository'deki FİLTRESİZ LİSTE'yi eziyoruz.
        // Artık Experience için GetList çağrıldığında bu çalışacak.
        public override List<Experience> GetList()
        {
            // Sadece aktifleri getirme mantığı
            using var c = new Context();
            return c.Experiences.Where(x => !x.IsDeleted).ToList();
        }

        // --- Experience'a Özel Metotların İçi ---

        public List<Experience> GetDeletedList()
        {
            using var c = new Context();
            return c.Experiences.Where(x => x.IsDeleted).ToList();
        }

        public void PermanentDelete(int id)
        {
            using var c = new Context();
            var experience = c.Experiences.Find(id);
            if (experience != null)
            {
                base.Delete(experience); // Atasındaki ORİJİNAL (HARD DELETE) metodunu çağırır!
            }
        }

        public void Restore(int id)
        {
            using var c = new Context();
            var experience = c.Experiences.Find(id);
            if (experience != null)
            {
                experience.IsDeleted = false;
                c.Update(experience);
                c.SaveChanges();
            }
        }
    }
}

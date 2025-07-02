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
    public class EFServiceDal: GenericRepository<Service>, IServiceDal
    {
        public override void Delete(Service t)
        {
            // Soft delete mantığı
            using var c = new Context();
            var service = c.Services.Find(t.ServiceID);
            if (service != null)
            {
                service.IsDeleted = true;
                c.Update(service);
                c.SaveChanges();
            }
        }

        // GenericRepository'deki FİLTRESİZ LİSTE'yi eziyoruz.
        // Artık Experience için GetList çağrıldığında bu çalışacak.
        public override List<Service> GetList()
        {
            // Sadece aktifleri getirme mantığı
            using var c = new Context();
            return c.Services.Where(x => !x.IsDeleted).ToList();
        }

        // --- Experience'a Özel Metotların İçi ---

        public List<Service> GetDeletedList()
        {
            using var c = new Context();
            return c.Services.Where(x => x.IsDeleted).ToList();
        }

        public void PermanentDelete(int id)
        {
            using var c = new Context();
            var service = c.Services.Find(id);
            if (service != null)
            {
                base.Delete(service); // Atasındaki ORİJİNAL (HARD DELETE) metodunu çağırır!
            }
        }

        public void Restore(int id)
        {
            using var c = new Context();
            var service = c.Services.Find(id);
            if (service != null)
            {
                service.IsDeleted = false;
                c.Update(service);
                c.SaveChanges();
            }
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal ExperienceDal)
        {
            _experienceDal = ExperienceDal;
        }
        public void TAdd(Experience t)
        {
            _experienceDal.Insert(t);
        }

        public void TDelete(Experience t)
        {
            _experienceDal.Delete(t);
        }

        public Experience TGetByID(int id)
        {
            return _experienceDal.GetById(id);
        }

        public List<Experience> TGetList()
        {
            return _experienceDal.GetList();
        }

        public void TUpdate(Experience t)
        {
            _experienceDal.Update(t);   
        }
        public List<Experience> TGetDeletedList()
        {
            // DAL'daki kendine özel GetDeletedList metodunu çağırır.
            return _experienceDal.GetDeletedList();
        }

        public void TRestore(int id)
        {
            // Controller'dan gelen id'yi direkt DAL'daki Restore metoduna paslar.
            _experienceDal.Restore(id);
        }

        public void TPermanentDelete(int id)
        {
            // Controller'dan gelen id'yi direkt DAL'daki PermanentDelete metoduna paslar.
            _experienceDal.PermanentDelete(id);
        }

        public List<Experience> TGetbyFilter()
        {
            throw new NotImplementedException();
        }
    }
}

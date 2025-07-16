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
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }
        public void TAdd(Service t)
        {
            _serviceDal.Insert(t);
        }

        public void TDelete(Service t)
        {
            _serviceDal.Delete(t);
        }

        public List<Service> TGetbyFilter()
        {
            throw new NotImplementedException();
        }

        public Service TGetByID(int id)
        {
            return _serviceDal.GetById(id);
        }

        public List<Service> TGetDeletedList()
        {
            return _serviceDal.GetDeletedList();
        }

        public List<Service> TGetList()
        {
            return _serviceDal.GetList();
        }

        public void TPermanentDelete(int id)
        {
            _serviceDal.PermanentDelete(id);
        }

        public void TRestore(int id)
        {
            _serviceDal.Restore(id);
        }

        public void TUpdate(Service t)
        {
            _serviceDal.Update(t);          
        }
    }
}

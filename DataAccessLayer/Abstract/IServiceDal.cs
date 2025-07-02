using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IServiceDal : IGenericDal<Service>
    {
        List<Service> GetDeletedList();
        void Restore(int id);
        void PermanentDelete(int id);
    }
}

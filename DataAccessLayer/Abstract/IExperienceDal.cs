using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IExperienceDal : IGenericDal<Experience>
    {
        // Experience'a özel soft delete metotları
        List<Experience> GetDeletedList();
        void Restore(int id);
        void PermanentDelete(int id);
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IServiceService: IGenericService<Service>
    {
        List<Service> TGetDeletedList();

        // Silinmiş bir denetimi geri yükler
        void TRestore(int id);

        // Bir denetimi veritabanından kalıcı olarak siler
        void TPermanentDelete(int id);
    }
}

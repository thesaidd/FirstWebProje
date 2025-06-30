using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPortfolioDal : IGenericDal<Portfolio>
    {
        List<Portfolio> GetDeletedList();
        void Restore(int PortfolioID);
        void PermanentDelete(int PortfolioID);
        // Bu metot, silinmiş olsa bile bir kaydı bulmak için lazım.
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDal _portfolioDal;
        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public void TAdd(Portfolio t)
        {
            _portfolioDal.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
            _portfolioDal.Delete(t);
        }

        public Portfolio TGetByID(int id)
        {
            return _portfolioDal.GetById(id);
        }

        public List<Portfolio> TGetDeletedList()
        {
            return _portfolioDal.GetDeletedList();
        }

        public List<Portfolio> TGetList()
        {
            return _portfolioDal.GetList();
        }

        public void TPermanentDelete(int PortfolioID)
        {
            _portfolioDal.PermanentDelete(PortfolioID);
        }

        public void TRestore(int PortfolioID)
        {
            _portfolioDal.Restore(PortfolioID);
        }

        public void TUpdate(Portfolio t)
        {
            _portfolioDal.Update(t);
        }
    }
}

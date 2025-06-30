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
    public class EFPortfolioDal : GenericRepository<Portfolio>, IPortfolioDal    
    {
        public override void Delete(Portfolio t)
        {
            using var c = new Context();
            var portfolio = c.Portfolios.Find(t.PortfolioID);
            if (portfolio != null)
            {
                portfolio.IsDeleted = true;
                c.Update(portfolio);
                c.SaveChanges();
            }
        }

        public override List<Portfolio> GetList()
        {
            using var c = new Context();
            return c.Portfolios.Where(x => !x.IsDeleted).ToList();
        }

        public List<Portfolio> GetDeletedList()
        {
            using var c = new Context();
            return c.Portfolios.Where(x => x.IsDeleted).ToList();
        }

        public void PermanentDelete(int PortfolioID)
        {
            using var c = new Context();
            var Portfolio = c.Portfolios.Find(PortfolioID);
            if (Portfolio != null)
            {
                base.Delete(Portfolio); // Atasındaki ORİJİNAL (HARD DELETE) metodunu çağırır.
            }
        }

        public void Restore(int PortfolioID)
        {
            using var c = new Context();
            var Portfolio = c.Portfolios.Find(PortfolioID);
            if (Portfolio != null)
            {
                Portfolio.IsDeleted = false;
                c.Update(Portfolio);
                c.SaveChanges();
            }
        }
    }
}

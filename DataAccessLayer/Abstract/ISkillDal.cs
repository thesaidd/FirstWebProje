using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISkillDal : IGenericDal<Skill>
    {
        List<Skill> GetDeletedList();
        void Restore(int id);
        void PermanentDelete(int id);
        // Bu metot, silinmiş olsa bile bir kaydı bulmak için lazım.
        Skill GetAnyById(int id);
    }
}

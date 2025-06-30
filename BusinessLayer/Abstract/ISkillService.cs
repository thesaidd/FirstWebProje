using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillService: IGenericService<Skill>
    {
        List<Skill> TGetDeletedList();
        void TRestore(int id);
        void TPermanentDelete(int id);
        Skill TGetAnyByID(int id);
    }
}

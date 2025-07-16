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
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;
        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void TAdd(Skill t)
        {
            _skillDal.Insert(t);
        }

        public void TDelete(Skill t)
        {
            _skillDal.Delete(t);
        }

        public Skill TGetByID(int id)
        {
           return _skillDal.GetById(id);
        }

        public List<Skill> TGetList()
        {
            return _skillDal.GetList();
        }

        public void TUpdate(Skill t)
        {
            _skillDal.Update(t);
        }
        public List<Skill> TGetDeletedList()
        {
            return _skillDal.GetDeletedList();
        }

        public void TRestore(int id)
        {
            _skillDal.Restore(id);
        }

        public void TPermanentDelete(int id)
        {
            _skillDal.PermanentDelete(id);
        }

        public Skill TGetAnyByID(int id)
        {
            return _skillDal.GetAnyById(id);
        }

        public List<Skill> TGetbyFilter()
        {
            throw new NotImplementedException();
        }
    }
}

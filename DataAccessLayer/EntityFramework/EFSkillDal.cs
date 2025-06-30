using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFSkillDal: GenericRepository<Skill>, ISkillDal
    {
        public override void Delete(Skill t)
        {
            using var c = new Context();
            var skill = c.Skills.Find(t.SkillId);
            if (skill != null)
            {
                skill.IsDeleted = true;
                c.Update(skill);
                c.SaveChanges();
            }
        }

        // GenericRepository'deki FİLTRESİZ LİSTE'yi eziyoruz.
        public override List<Skill> GetList()
        {
            using var c = new Context();
            return c.Skills.Where(x => !x.IsDeleted).ToList();
        }

        // --- Skill'e Özel Metotların İçi ---

        public List<Skill> GetDeletedList()
        {
            using var c = new Context();
            return c.Skills.Where(x => x.IsDeleted).ToList();
        }

        public void PermanentDelete(int id)
        {
            using var c = new Context();
            var skill = c.Skills.Find(id);
            if (skill != null)
            {
                base.Delete(skill); // Atasındaki ORİJİNAL (HARD DELETE) metodunu çağırır.
            }
        }

        public void Restore(int id)
        {
            using var c = new Context();
            var skill = c.Skills.Find(id);
            if (skill != null)
            {
                skill.IsDeleted = false;
                c.Update(skill);
                c.SaveChanges();
            }
        }

        public Skill GetAnyById(int id)
        {
            using var c = new Context();
            return c.Skills.Find(id);
        }
    }
}

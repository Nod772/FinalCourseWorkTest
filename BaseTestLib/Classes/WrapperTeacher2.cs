using BaseTestLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTestLib.Classes
{
    public class WrapperTeacher2 : IWrapper<Teasher>
    {
        TestModel context = null;
        public WrapperTeacher2()
        {
            context = new TestModel();
        }
        public void AddItem(Teasher item)
        {
            context.Teashers.Add(item);
            Commit();
        }

        public void Delete(Teasher item)
        {
            try
            {

                var forDelete = Find(item);
                context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
                Commit();
            }
            catch (Exception)
            {
            }
        }

        public IEnumerable<Teasher> GetItems()
        {
            return context.Teashers.ToList();
        }

        public void UpdateItem(Teasher item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            Commit();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public Teasher Find(Teasher entry)
        {
            var teacher = context.Teashers.FirstOrDefault(e => e.Login == entry.Login);
            if (teacher != null)
            {
                return teacher;
            }
            throw new ArgumentNullException();
        }
    }
}

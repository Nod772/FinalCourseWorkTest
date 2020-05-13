using BaseTestLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTestLib.Classes
{
    public abstract class Wrapper<T> : IWrapper<T> where T : class
    {
        TestModel context = null;
        public DbSet<T> Set { get; set; }

        public Wrapper(TestModel testContext)
        {
            context = testContext;
            Set = context.Set<T>();
        }
        public void AddItem(T item)
        {
            Set.Add(item);
            Commit();
        }

        public virtual void Delete(T item)
        {
          
            var forDelete = Set.FirstOrDefault<T>(x => x == (item));
            context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            Commit();

        }



        public void Commit()
        {
            context.SaveChanges();
        }


        public IEnumerable<T> GetItems()
        {
            return Set.ToList<T>();
        }


        public void UpdateItem(T item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            Commit();
        }

        T IWrapper<T>.Find(T entry)
        {
            throw new NotImplementedException();
        }
    }
}

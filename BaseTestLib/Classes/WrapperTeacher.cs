using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTestLib.Classes
{
   public class WrapperTeacher:Wrapper<Teasher>
    {
        TestModel context = null;
        public new DbSet<Teasher> Set { get; set; }

        public WrapperTeacher(TestModel model):base(model)
        {
            context = model;
            Set = model.Teashers;
        }

        public override void Delete(Teasher item)
        {
            var forDelete = Set.FirstOrDefault<Teasher>(x => x.Login == (item.Login));
            context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
            Commit();
        }
        public void DeleteTeacherByID(int IDTeacher)
        {
            var forDelete = Set.FirstOrDefault<Teasher>(x => x.ID == IDTeacher);
            context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
            Commit();
        }
       
        public Teasher GetTeasher(string login,string password)
        {
            var current = Set.FirstOrDefault<Teasher>(x => x.Login == login);
            if (current.Password == password)
            {
                return current;
            }
            else
                return null; 
        }
        public void AddResultFromPassedTest(int idTeacher,string nameuser,int mark)
        {
            var t = Set.FirstOrDefault(x => x.ID == idTeacher);
            string st = String.Format("{0,20} - {1,5}", nameuser, mark);
            t.PassedTest.Add(st);
        }
       
    }
}

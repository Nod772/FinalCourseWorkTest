using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTestLib.Classes
{
   public class WrapperQuestion : Wrapper<Question>
    {
        TestModel context = null;
        public new DbSet<Question> Set { get; set; }

        public WrapperQuestion(TestModel model) : base(model)
        {
            context = model;
            Set = model.Questions;
        }
        public override void Delete(Question item)
        {
            var forDelete = Set.FirstOrDefault<Question>(x => x.ID == (item.ID));
            context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
            Commit();
        }
        public  IEnumerable<Question> GetItemsParent(int id)
        {
         //   var test= Set.Where(x=>x.Test.ID==id);
            return context.Questions.Where(x => x.Test.ID == id);
           
        }
    }
}

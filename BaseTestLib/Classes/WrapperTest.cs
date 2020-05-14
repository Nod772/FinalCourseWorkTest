using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTestLib.Classes
{
    public class WrapperTest : Wrapper<Test>
    {
        TestModel context = null;
        public new DbSet<Test> Set { get; set; }

        public WrapperTest(TestModel model) : base(model)
        {
            context = model;
            Set = model.Tests;
        }
        public override void Delete(Test item)
        {
            var forDelete = Set.FirstOrDefault<Test>(x => x.ID == (item.ID));
            context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
            Commit();
        }

        public Test  GetTest(int id)
        {
            var t = Set.FirstOrDefault(x => x.ID == id);

            return t;
        }
        public Test GetTest(string name)
        {
            var t = Set.FirstOrDefault(x => x.Name ==name);

            return t;
        }

        public IEnumerable<Test> GetTests(int id)
        {

            var t = Set.Where(x => x.TeacherID == id);
            return t.ToList();

        }
    }
}

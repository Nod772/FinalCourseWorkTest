using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTestLib.Classes
{
    public class WrapperAnswerOption : Wrapper<AnswerOption>
    {
        TestModel context = null;
        public new DbSet<AnswerOption> Set { get; set; }

        public WrapperAnswerOption(TestModel model) : base(model)
        {
            context = model;
            Set = model.AnswerOptions;
        }
        public override void Delete(AnswerOption item)
        {
            var forDelete = Set.FirstOrDefault<AnswerOption>(x => x.ID == (item.ID));
            context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
            Commit();
        }
        public IEnumerable<AnswerOption> GetAnswerOptionsFromQuestion(int idQuestion)
        {
            return Set.Where(x => x.Question.ID == idQuestion);
        }

    }
}

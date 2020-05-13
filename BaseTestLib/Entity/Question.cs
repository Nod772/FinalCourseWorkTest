using System.Collections.Generic;

namespace BaseTestLib
{
    public class Question
    {
        public Question()
        {
            AnswerOptions = new HashSet<AnswerOption>();
            Test = new Test();
        }

        public int ID { get; set; }
        public string TextQuestion { get; set; }
      
        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }
        public virtual Test Test { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTestLib
{
    public class  AnswerOption
    {
        public AnswerOption()
        {
            Question = new Question();
        }
        public int ID { get; set; }
        public string TextAnswer { get; set; }
        public bool isTrueAnswer { get; set; }


        public virtual Question Question { get; set; }

    }
}

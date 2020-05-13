using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogic.DTO
{
   public class AnswerOptionDTO
    {
        public AnswerOptionDTO()
        {
            QuestionDTO = new QuestionDTO();
        }
        public int ID { get; set; }
        public string TextAnswer { get; set; }
        public bool isTrueAnswer { get; set; }


        public virtual QuestionDTO QuestionDTO { get; set; }

    }
}

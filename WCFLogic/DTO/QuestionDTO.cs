using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogic.DTO
{
  public  class QuestionDTO
    {
        public QuestionDTO()
        {
            AnswerOptionsDTO = new HashSet<AnswerOptionDTO>();
            TestDTO = new TestDTO();
        }

        public int ID { get; set; }
        public string TextQuestion { get; set; }

        public virtual ICollection<AnswerOptionDTO> AnswerOptionsDTO { get; set; }
        public virtual TestDTO TestDTO { get; set; }
    }
}

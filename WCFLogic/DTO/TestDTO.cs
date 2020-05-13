using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogic.DTO
{
  public  class TestDTO
    {
        public TestDTO()
        {
            QuestionsDTO = new List<QuestionDTO>();
            TeasherDTO = new TeacherDTO();
        }
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<QuestionDTO> QuestionsDTO { get; set; }
        public virtual TeacherDTO TeasherDTO { get; set; }
    }
}

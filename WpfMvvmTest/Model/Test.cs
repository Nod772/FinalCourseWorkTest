using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmTest.Model
{
    public class MyTestDTO
    {
        public string NameTest { get; set; }
        public List<MyQuestionDTO> Questions { get; set; }
       
       
    }
    public class MyQuestionDTO
    {
       
        public string TextQuestion { get; set; }
        public List<MyAswerOpinionDTO> AnswerList { get; set; }
        
    }
    public class MyAswerOpinionDTO
    {
        public string AnswerText  { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}

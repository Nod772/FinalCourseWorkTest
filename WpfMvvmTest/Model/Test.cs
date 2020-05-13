using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmTest.Model
{
    public class TestDTO
    {
        public string NameTest { get; set; }
        public List<QuestionDTO> Questions { get; set; }
       
       
    }
    public class QuestionDTO
    {
       
        public string TextQuestion { get; set; }
        public List<AswerOpinionDTO> AnswerList { get; set; }
        
    }
    public class AswerOpinionDTO
    {
        public string AnswerText { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}

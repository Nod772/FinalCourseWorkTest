using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmTest.Model;

using WpfMvvmTest.ServiceReferenceTest;
using WpfMvvmTest.ServiceReferenceAnswerOption;
using WpfMvvmTest.ServiceReferenceTeacher;
using WpfMvvmTest.ServiceReferenceQuestion;
using TestDTO = WpfMvvmTest.ServiceReferenceTest.TestDTO;
using QuestionDTO = WpfMvvmTest.ServiceReferenceQuestion.QuestionDTO;
using AnswerOptionDTO = WpfMvvmTest.ServiceReferenceAnswerOption.AnswerOptionDTO;


namespace WpfMvvmTest.ViewModel.Helper
{
   public class UserHepler
    {
        public static async Task<TestDTO> GetTest(string testName)
        {
            TestthisProg testthisProg = new TestthisProg();
            testthisProg.NewTest();
            //  using()
            {

            }
            List<TestDTO> tests = new List<TestDTO>();
            foreach (var item in testthisProg.tests)
            {

            tests.Add(item);
            }
          
            if(tests.Find(x => x.Name == testName)!=null)
            {

            return tests.Find(x => x.Name == testName);
            }
            else
            {
                throw new Exception("Not Founded");
            }
        }
        public static async Task<List<QuestionDTO>> GetQuestions(string testName)
        {

            TestthisProg testthisProg = new TestthisProg();
            testthisProg.NewTest();


            TestDTO test = await GetTest(testName);           
            List<QuestionDTO> questions = new List<QuestionDTO>();
          
            foreach (var item in test.QuestionsDTO)
            {
               // questions.Add(item);
              
            }
           


            return questions;
        }
        public static async Task<List<AnswerOptionDTO>> GetAnswers(TestDTO test,QuestionDTO question)
        {
            //TestthisProg testthisProg = new TestthisProg();
            //testthisProg.NewTest();
            List<AnswerOptionDTO> aswerOpinions = new List<AnswerOptionDTO>();

            AnswerOptionDTO aswerOpinionDTO1 = new AnswerOptionDTO();
            AnswerOptionDTO aswerOpinionDTO2 = new AnswerOptionDTO();
            AnswerOptionDTO aswerOpinionDTO3 = new AnswerOptionDTO();

            aswerOpinions.Add(aswerOpinionDTO1);
            aswerOpinions.Add(aswerOpinionDTO2);
            aswerOpinions.Add(aswerOpinionDTO3);

            //  QuestionDTO questionDTO = testthisProg.questions.First(x=>x==question);

            List<AnswerOptionDTO> aswers = new List<AnswerOptionDTO>();

            foreach (var item in aswerOpinions)
            {
                aswers.Add(item);

            }

            return aswers;
        }


    }
}

using AutoMapper;
using BaseTestLib;
using BaseTestLib.Classes;
using BaseTestLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFLogic.DTO;
namespace WCFLogic
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class TestService : ITestService
    {
        IWrapper<Test> wrapper;
        IMapper mapper = null;

        public TestService(WrapperTest wrap)
        {
            wrapper = wrap;
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<TestDTO, Test>();
                x.CreateMap<Test, TestDTO>();
            });
            mapper = config.CreateMapper();
        }

        public TestService()
        {
            wrapper = new WrapperTest(new TestModel());
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<TestDTO, Test>();
                x.CreateMap<Test, TestDTO>();
            }
           );
            mapper = config.CreateMapper();
        }

        public int GetResultFromTest(int idTest,List<QuestionDTO> testQuestionsFromUser,string nameUser)
        {
            var testParent = GetTest(idTest);
     
            int countAllAnswerOption=0;
            foreach (var item in testParent)
            {
                foreach (var itemAnswer in item.AnswerOptionsDTO)
                {
                    countAllAnswerOption++;
                }
            }


            int countAnswers = 0;
   
            foreach (var itemQuestion in testParent)
            {
                QuestionDTO userAnswers = testQuestionsFromUser.FirstOrDefault(x => x.ID == itemQuestion.ID);
                foreach (var itemAnswerOptions in itemQuestion.AnswerOptionsDTO)
                {
                    AnswerOptionDTO userAnswer = userAnswers.AnswerOptionsDTO.FirstOrDefault(x => x.ID == itemAnswerOptions.ID);

                    if (itemAnswerOptions.isTrueAnswer == userAnswer.isTrueAnswer)
                    {
                        countAnswers++;
                    }
                    else
                    {
                        countAnswers--;
                    }
                }
            }

            int mark = Convert.ToInt32(countAnswers/countAllAnswerOption*100);
            int idteacher = testParent.ElementAt(0).TestDTO.TeacherID;
            (wrapper as WrapperTeacher).AddResultFromPassedTest(idteacher, nameUser, mark);
            return mark;

        }


        public void AddTest(TestDTO question)
        {
            wrapper.AddItem(mapper.Map<TestDTO, Test>(question));
        }

        public void DeleteTest(TestDTO test)
        {

            wrapper.Delete(mapper.Map<TestDTO, Test>(test));
        }

        public IEnumerable<TestDTO> GetTests()
        {
            return mapper.Map<IEnumerable<Test>, IEnumerable<TestDTO>>(wrapper.GetItems());

        }
        public IEnumerable<QuestionDTO> GetTest(int id)
        {

            Test current = (wrapper as WrapperTest).GetTest(id);
            var t = mapper.Map<Test, TestDTO>(current);
            return t.QuestionsDTO;
        }
        public TestDTO GetTestByName(string name)
        {
            Test current = (wrapper as WrapperTest).GetTest(name);
            var t = mapper.Map<Test, TestDTO>(current);
       
            return t;

        }

        public IEnumerable<TestDTO> TestFromTeacher(int id)
        {
            var t = mapper.Map<IEnumerable<Test>, IEnumerable<TestDTO>>((wrapper as WrapperTest).GetTests(id));

            return t;

        }


    }
}

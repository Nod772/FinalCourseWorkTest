using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfMvvmTest.Model;
using WpfMvvmTest.ServiceReferenceAnswerOption;
using WpfMvvmTest.ServiceReferenceQuestion;
using WpfMvvmTest.ServiceReferenceTeacher;
using WpfMvvmTest.ServiceReferenceTest;
using AnswerOptionDTO = WpfMvvmTest.ServiceReferenceAnswerOption.AnswerOptionDTO;
using QuestionDTO = WpfMvvmTest.ServiceReferenceQuestion.QuestionDTO;
using TeacherDTO = WpfMvvmTest.ServiceReferenceAnswerOption.TeacherDTO;
using TestDTO = WpfMvvmTest.ServiceReferenceTest.TestDTO;

namespace WpfMvvmTest
{
    public class TestthisProg
    {
        public ObservableCollection<ListTeacher> teachers { get; set; } = new ObservableCollection<ListTeacher>();
        public ObservableCollection<TestDTO> tests { get; set; } = new ObservableCollection<TestDTO>();
        public ObservableCollection<QuestionDTO> questions { get; set; } = new ObservableCollection<QuestionDTO>();
        public ObservableCollection<AnswerOptionDTO> aswers { get; set; } = new ObservableCollection<AnswerOptionDTO>();
        //
        public TeacherServiceClient proxyTeacher = new TeacherServiceClient();
        public TestServiceClient proxyTest = new TestServiceClient();
        public AnswerOptionServiceClient proxyAnswer = new  AnswerOptionServiceClient();
        public QuestionServiceClient proxyQuestion = new QuestionServiceClient();



        public async void NewTest()
        {
            #region MyRegion

            //TestDTO testDTO = new TestDTO();
            //TeacherDTO teacherDTO = new TeacherDTO();
            //QuestionDTO questionDTO1 = new QuestionDTO();
            //QuestionDTO questionDTO2 = new QuestionDTO();
            //QuestionDTO questionDTO3 = new QuestionDTO();

            //teacherDTO.PassedTest = new List<string>();
            //teacherDTO.Tests = new List<TestDTO>();
            //testDTO.QuestionsDTO = new List<QuestionDTO>();




            //questionDTO1.AnswerList = new List<AswerOpinionDTO>();
            //questionDTO2.AnswerList = new List<AswerOpinionDTO>();
            //questionDTO3.AnswerList = new List<AswerOpinionDTO>();


            //AswerOpinionDTO aswerOpinionDTO1 = new AswerOpinionDTO();
            //AswerOpinionDTO aswerOpinionDTO2 = new AswerOpinionDTO();
            //AswerOpinionDTO aswerOpinionDTO3 = new AswerOpinionDTO();


            //aswerOpinionDTO1.AnswerText = "C#";
            //aswerOpinionDTO2.AnswerText = "C++";
            //aswerOpinionDTO3.AnswerText = "Java";

            //aswerOpinionDTO1.IsTrueAnswer = true;
            //aswerOpinionDTO2.IsTrueAnswer = false;
            //aswerOpinionDTO3.IsTrueAnswer = false;



            //questionDTO1.TextQuestion = "First leng";
            //questionDTO2.TextQuestion = "Second leng";
            //questionDTO3.TextQuestion = "Third leng";



            //questionDTO1.AnswerList.Add(aswerOpinionDTO1);
            //questionDTO1.AnswerList.Add(aswerOpinionDTO2);
            //questionDTO1.AnswerList.Add(aswerOpinionDTO3);


            //questionDTO2.AnswerList.Add(aswerOpinionDTO1);
            //questionDTO2.AnswerList.Add(aswerOpinionDTO2);


            //questionDTO3.AnswerList.Add(aswerOpinionDTO1);


            //testDTO.NameTest = "N";
            //testDTO.Questions.Add(questionDTO1);
            //testDTO.Questions.Add(questionDTO2);
            //testDTO.Questions.Add(questionDTO3);

            //teacherDTO.Tests.Add(testDTO);
            //teacherDTO.PassedTests.Add(testDTO.NameTest);


            //aswers.Add(aswerOpinionDTO1);
            //aswers.Add(aswerOpinionDTO2);
            //aswers.Add(aswerOpinionDTO3);
            //aswers.Add(aswerOpinionDTO3);


            //questions.Add(questionDTO1);
            //questions.Add(questionDTO2);
            //questions.Add(questionDTO3);




            //teachers.Add(teacherDTO);
            //tests.Add(testDTO);
            #endregion
            // oc = new ObservableCollection<T>(new List<T>());



            aswers =new ObservableCollection<AnswerOptionDTO>(await proxyAnswer.GetAnswerOptionsAsync());
            questions = new ObservableCollection<QuestionDTO>(await proxyQuestion.GetQuestionAsync());
            teachers = new ObservableCollection<ListTeacher>(await proxyTeacher.GetListTeachersAsync());
            tests = new ObservableCollection<TestDTO>(await proxyTest.GetTestsAsync());
         

       



          


        }
        public void AddTest(TestDTO test)
        {
            tests.Add(test);
        }
        public void RemoveTest(TestDTO test)
        {
            tests.Add(test);
        }
    }
}

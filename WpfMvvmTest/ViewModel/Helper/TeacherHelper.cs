using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmTest.Model;
using WpfMvvmTest.ServiceReferenceTest;
using WpfMvvmTest.ServiceReferenceTeacher;
using WpfMvvmTest.ServiceReferenceQuestion;

using TeacherDTO = WpfMvvmTest.ServiceReferenceTeacher.TeacherDTO;
using TestDTO = WpfMvvmTest.ServiceReferenceTest.TestDTO;
using QuestionDTO = WpfMvvmTest.ServiceReferenceQuestion.QuestionDTO;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfMvvmTest.ViewModel.Helper
{
    class TeacherHelper
    {
        static TeacherServiceClient proxyTeacher = new TeacherServiceClient();
        static TestServiceClient proxyTest = new TestServiceClient();
        //public static async Task<TestDTO> GetCurrentTest(string TestName)
        //{
        //    TestDTO currentTest = new TestDTO();



        //    //using (HttpClient http = new HttpClient())
        //    //{
        //    //    var response = await http.GetAsync(url);
        //    //    string json = await response.Content.ReadAsStringAsync();

        //    //    currentCondition = (JsonConvert.DeserializeObject<List<CurrentCondition>>(json)).FirstOrDefault();
        //    //}
        //    return currentTest;
        //}
        public static async Task<ObservableCollection<TestDTO>> GetTests(int idTeacher)
        {
      
            ObservableCollection<TestDTO> tests = new ObservableCollection<TestDTO>(await proxyTest.TestFromTeacherAsync(idTeacher));
           
            return tests;
        }

        public static async Task<List<string>> GetResults()
        {
            List<string> Result = new List<string>();
            //  using()
            {

            }
            return Result;
        }
        //public static async Task<List<QuestionDTO>> GetQuestions(TestDTO test)
        //{
        //    List<QuestionDTO> questions = new List<QuestionDTO>();
        //    //  using()
        //    {

        //    }
        //   return questions;
        //}

        public static async Task<List<string>> AddTest(TestDTO test, TeacherDTO teacher)
        {
            List<string> Result = new List<string>();
            //  using()
            {

            }
            return Result;
        }

        public static async void RemoveTest(TestDTO Test)///////////////////////////////////////
        {
           /// TestthisProg testthisProg = new TestthisProg();
           /// testthisProg.NewTest();

            await proxyTest.DeleteTestAsync(Test);
            //foreach (var item in testthisProg.tests)
            //{
            //
            //    tests.Add(item);
            //}
            //  using()
            {

            }
          //  tests.Remove(Test);

        }

        internal static async Task<TeacherDTO> Logins(string login, string password)
        {
            // TeacherDTO teacher = new TeacherDTO();
            try
            {
                TeacherDTO teacher = await proxyTeacher.LogInTeacherAsync(login, "Test");
                MessageBox.Show("You in System");
                return teacher;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return null;
        }

        internal static async Task<TeacherDTO> Registers(string login, string password)
        {
            TeacherDTO teacher = new TeacherDTO();

            return teacher;
        }
    }
}

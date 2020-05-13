using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmTest.Model;

namespace WpfMvvmTest.ViewModel.Helper
{
    class TeacherHelper
    {
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
        public static async Task<List<TestDTO>> GetTests()
        {
            TestthisProg testthisProg = new TestthisProg();
            testthisProg.NewTest();

            List<TestDTO> tests = new List<TestDTO>();
            foreach (var item in testthisProg.tests)
            {

            tests.Add(item);
            }
          //  using()
            {

            }
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

        public static void  RemoveTest(TestDTO Test)///////////////////////////////////////
        {
            TestthisProg testthisProg = new TestthisProg();
            testthisProg.NewTest();

            List<TestDTO> tests = new List<TestDTO>();
            foreach (var item in testthisProg.tests)
            {

                tests.Add(item);
            }
            //  using()
            {

            }
            tests.Remove(Test);

        }

        internal static async Task<TeacherDTO> Logins(string login, string password)
        {
            TeacherDTO teacher = new TeacherDTO();
            return teacher;
        }

        internal static async Task<TeacherDTO> Registers(string login, string password)
        {
            TeacherDTO teacher = new TeacherDTO();
            return teacher;
        }
    }
}

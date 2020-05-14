using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFLogic.DTO;

namespace WCFLogic
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        void AddTest(TestDTO teasher);
        [OperationContract]
        void DeleteTest(TestDTO teasher);
        [OperationContract]
        IEnumerable<QuestionDTO> GetTest(int id);
        [OperationContract]
        IEnumerable<TestDTO> GetTests();
        [OperationContract]
        IEnumerable<TestDTO> TestFromTeacher(int IDTeacher);
        [OperationContract]
        int GetResultFromTest(int idTest, List<QuestionDTO> testQuestionsFromUser, string nameUser);
        [OperationContract]
        TestDTO GetTestByName(string name);
    }


       
}

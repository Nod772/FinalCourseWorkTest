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
    public interface IQuestionService
    {
        [OperationContract]
        void AddQuestion(QuestionDTO teasher);
        [OperationContract]
        void DeleteQuestion(QuestionDTO teasher);
        [OperationContract]
        IEnumerable<QuestionDTO> GetQuestion();
        [OperationContract]
        IEnumerable<QuestionDTO> QuestionFromIDTest(int id);
        // TODO: Добавьте здесь операции служб
    }
}

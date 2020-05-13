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
    public interface IAnswerOptionService
    {
        [OperationContract]
        void AddAnswerOption(AnswerOptionDTO teasher);
        [OperationContract]
        void DeleteAnswerOption(AnswerOptionDTO teasher);
        [OperationContract]
        IEnumerable<AnswerOptionDTO> GetAnswerOptions();
        [OperationContract]
        IEnumerable<AnswerOptionDTO> GetAnswerOptionsFromQuestion(int id);
        // TODO: Добавьте здесь операции служб
    }
}

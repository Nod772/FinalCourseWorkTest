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
    public class QuestionService : IQuestionService
    {
        IWrapper<Question> wrapper;
        IMapper mapper = null;

        public QuestionService(WrapperQuestion wrap)
        {
            wrapper = wrap;
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<QuestionDTO, Question>();
                x.CreateMap<Question, QuestionDTO>();
            });
            mapper = config.CreateMapper();
        }

        public QuestionService()
        {
            wrapper = new WrapperQuestion(new TestModel());
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<QuestionDTO, Question>();
                x.CreateMap<Question, QuestionDTO>();
            }
           );
            mapper = config.CreateMapper();
        }
        public void AddQuestion(QuestionDTO question)
        {
            wrapper.AddItem(mapper.Map<QuestionDTO, Question>(question));
        }

        public void DeleteQuestion(QuestionDTO teasher)
        {

            wrapper.Delete(mapper.Map<QuestionDTO, Question>(teasher));
        }

        public IEnumerable<QuestionDTO> GetQuestion()
        {
            return mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>(wrapper.GetItems());
        }
        public IEnumerable<QuestionDTO> QuestionFromIDTest(int id)
        {
            var t = mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>((wrapper as WrapperQuestion).GetItemsParent(id));

            return t;
            
        }
    }
}

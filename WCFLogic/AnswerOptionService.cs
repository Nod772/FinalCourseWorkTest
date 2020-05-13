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
    public class AnswerOptionService : IAnswerOptionService
    {
        IWrapper<AnswerOption> wrapper;
        IMapper mapper = null;

        public AnswerOptionService(WrapperAnswerOption wrap)
        {
            wrapper = wrap;
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<AnswerOptionDTO, AnswerOption>();
                x.CreateMap<AnswerOption, AnswerOptionDTO>();
            });
            mapper = config.CreateMapper();
        }

        public AnswerOptionService()
        {
            wrapper = new WrapperAnswerOption(new TestModel());
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<AnswerOptionDTO, AnswerOption>();
                x.CreateMap<AnswerOption, AnswerOptionDTO>();
            }
           );
            mapper = config.CreateMapper();
        }
        public void AddAnswerOption(AnswerOptionDTO answer)
        {
            wrapper.AddItem(mapper.Map<AnswerOptionDTO, AnswerOption>(answer));
        }

        public void DeleteAnswerOption(AnswerOptionDTO answer)
        {

            wrapper.Delete(mapper.Map<AnswerOptionDTO, AnswerOption>(answer));
        }

        public IEnumerable<AnswerOptionDTO> GetAnswerOptions()
        {
            return mapper.Map<IEnumerable<AnswerOption>, IEnumerable<AnswerOptionDTO>>(wrapper.GetItems());
        }

        public IEnumerable<AnswerOptionDTO> GetAnswerOptionsFromQuestion(int id)
        {
            var t = mapper.Map<IEnumerable<AnswerOption>, IEnumerable<AnswerOptionDTO>>((wrapper as WrapperAnswerOption).GetAnswerOptionsFromQuestion(id));

            return t;
        }
    }
}

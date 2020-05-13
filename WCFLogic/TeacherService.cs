using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BaseTestLib;
using BaseTestLib.Classes;
using AutoMapper;
using WCFLogic.DTO;
using BaseTestLib.Interfaces;

namespace WCFLogic
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class TeacherService : ITeacherService
    {
        IWrapper<Teasher> wrapper;
        IMapper mapper = null;
        public TeacherService(WrapperTeacher wrap)
        {
            wrapper = wrap;
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<TeacherDTO, Teasher>();
                x.CreateMap<Teasher, TeacherDTO>();
            });
            mapper = config.CreateMapper();
        }
        public TeacherService()
        {
            wrapper = new WrapperTeacher(new TestModel());
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<TeacherDTO, Teasher>();
                x.CreateMap<Teasher, TeacherDTO>();
            }
           );
            mapper = config.CreateMapper();
        }

        public void AddTeacher(TeacherDTO teasher)
        {
            wrapper.AddItem(mapper.Map<TeacherDTO, Teasher>(teasher));
        }

        public void DeleteTeacher(TeacherDTO teasher)
        {

            wrapper.Delete(mapper.Map<TeacherDTO, Teasher>(teasher));
        }

        public IEnumerable<TeacherDTO> GetTeachers()
        {
            return mapper.Map<IEnumerable<Teasher>, IEnumerable<TeacherDTO>>(wrapper.GetItems());
        }

        public IEnumerable<ListTeacher> GetListTeachers()
        {
            var teacher = GetTeachers();
            List<ListTeacher> list = new List<ListTeacher>();
            foreach (var item in teacher)
            {
                list.Add(new ListTeacher { ID = item.ID, Name = item.Name });
            }
            
            return list;
        }
        public void DeleteTeacherByID(int IDTeacher)
        {
            (wrapper as WrapperTeacher).DeleteTeacherByID(IDTeacher);
        }

        public TeacherDTO LogInTeacher(string login, string password)
        {
            var t = mapper.Map<Teasher,TeacherDTO>((wrapper as WrapperTeacher).GetTeasher(login,password));
            return t;
        }
      
    }
}

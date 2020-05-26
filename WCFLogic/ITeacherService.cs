using BaseTestLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFLogic.DTO;

namespace WCFLogic
{
    [ServiceContract]
    public interface ITeacherService
    {
        [OperationContract]
        TeacherDTO LogInTeacher(string login, string password);
        [OperationContract]
        void AddTeacher(TeacherDTO teasher);
        [OperationContract]
        void DeleteTeacher(TeacherDTO teasher);
        [OperationContract]
        IEnumerable<TeacherDTO> GetTeachers();
        [OperationContract]
        IEnumerable<ListTeacher> GetListTeachers();
        [OperationContract]
        void DeleteTeacherByID(int IDTeacher);
        [OperationContract]
        ICollection<TestDTO> GetTestFromSomeTeacher(int idTeacher);

        // TODO: Добавьте здесь операции служб
    }

    [DataContract]
    public class ListTeacher
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }


}

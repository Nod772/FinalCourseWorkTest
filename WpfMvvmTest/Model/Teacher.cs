using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmTest.Model;

namespace WpfMvvmTest
{
  public  class MyTeacherDTO
    {
        public  List<MyTestDTO> Tests { get; set; }
        public List<string> PassedTests { get;set; }
    }
   

}

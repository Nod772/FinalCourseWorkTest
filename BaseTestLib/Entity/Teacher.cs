using System.Collections.Generic;

namespace BaseTestLib
{
    public class Teasher
    {

        public Teasher()
        {
            PassedTest=new List<string>();
            Tests = new HashSet<Test>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<string> PassedTest { get; set; }

        public virtual ICollection<Test> Tests { get; set; }

    }
}
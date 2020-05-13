using System.Collections.Generic;

namespace BaseTestLib
{
    public class Test
    {
        public Test()
        {
            Questions = new HashSet<Question>();
            Teasher = new Teasher();
        }
        public int ID { get; set; }
        public int TeacherID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual Teasher Teasher { get; set; }
    }
}
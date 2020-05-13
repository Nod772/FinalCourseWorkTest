using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTestLib
{
  public  class TestModel:DbContext
    {
        public TestModel():base("name=TestModel")
        {

        }
        public virtual DbSet<AnswerOption> AnswerOptions { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Teasher>  Teashers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().HasRequired(x => x.Teasher).WithMany(z => z.Tests).HasForeignKey(z=>z.TeacherID).WillCascadeOnDelete(true);
            modelBuilder.Entity<Question>().HasRequired(x => x.Test).WithMany(z => z.Questions).WillCascadeOnDelete(true);
            modelBuilder.Entity<AnswerOption>().HasRequired(x => x.Question).WithMany(z => z.AnswerOptions).WillCascadeOnDelete(true);
        }
    }
}

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RegisterMVC.Models
{
    public class RegisterContext : DbContext
    {
            public RegisterContext() : base("RegisterDB")
            {
            }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<MySubject> MySubjects { get; set; }
        public DbSet<SClass> SClasses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<GradeList> GradeList { get; set; }
        public DbSet<News> Newses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            }
        }
}
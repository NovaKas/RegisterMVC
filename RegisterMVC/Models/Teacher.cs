using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterMVC.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string Name { get; set; }

        ////public int NewsID { get; set; }
        ////public int QuestionID { get; set; }
        ////public int MySubjectIS { get; set; }
        public int? SClassID { get; set; }
        ////public int GradeID { get; set; }


        public virtual ICollection<News> Newses { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<MySubject> MySubjects { get; set; }
        public virtual SClass SClass { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
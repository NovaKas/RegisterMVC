using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RegisterMVC.Models
{
    public class SClass
    {
        [ForeignKey("Teacher")]
        public int SClassID { get; set; }
        public string Name { get; set; }

        //public string StudentID { get; set; }
        public int TeacherID { get; set; } //wychowawca
        //public int SubjectID { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
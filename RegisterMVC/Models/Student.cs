using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterMVC.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }

        public int SClassID { get; set; }
        ////public int GradeID { get; set; }
        public int ParentID { get; set; }
        public virtual SClass SClass { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        //

        public virtual Parent Parent { get; set; }

    }
}
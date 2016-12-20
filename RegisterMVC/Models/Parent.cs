using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterMVC.Models
{
    public class Parent
    {
        public int ParentID { get; set; }
        public string FirstName { get; set; }

        //public int StudentID { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
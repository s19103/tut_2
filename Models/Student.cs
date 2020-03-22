using System;
using System.Collections.Generic;
using System.Text;

namespace tut_2.Models
{
    public class Student
    {
        public string fname  { get; set; }
        public string lname  { get; set; }
        public string birthdate  { get; set; }
        public string email  { get; set; }
        public string mothersName  { get; set; }
        public string fathersName  { get; set; }
        public List<Studies> studies  { get; set; }
        public string snumber { get; set; }


    }
}

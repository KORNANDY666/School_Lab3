using System;
using System.Collections.Generic;

namespace School_Lab3.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public int StudentId { get; set; }
        public int? FkClassId { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNr { get; set; }
        public string? Sex { get; set; }

        public virtual Class? FkClass { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}

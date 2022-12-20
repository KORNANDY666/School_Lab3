using System;
using System.Collections.Generic;

namespace School_Lab3.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Grades = new HashSet<Grade>();
        }

        public int EmployeeId { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? HiredDate { get; set; }
        public string? PhoneNr { get; set; }
        public string? Sex { get; set; }
        public int? FkTitleId { get; set; }
        public int? FkSchoolSubjectId { get; set; }

        public virtual SubjectSchool? FkSchoolSubject { get; set; }
        public virtual Title? FkTitle { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}

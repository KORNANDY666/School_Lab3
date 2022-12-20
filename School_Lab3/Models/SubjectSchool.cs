using System;
using System.Collections.Generic;

namespace School_Lab3.Models
{
    public partial class SubjectSchool
    {
        public SubjectSchool()
        {
            Employees = new HashSet<Employee>();
        }

        public int SubjectSchoolId { get; set; }
        public string? Lesson { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

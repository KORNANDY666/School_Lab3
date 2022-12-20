using System;
using System.Collections.Generic;

namespace School_Lab3.Models
{
    public partial class SchoolInfo
    {
        public SchoolInfo()
        {
            Schools = new HashSet<School>();
        }

        public int SchoolInfo1 { get; set; }
        public string? KindOfSchool { get; set; }
        public int? StudentTotal { get; set; }
        public int? EmployeeTotal { get; set; }

        public virtual ICollection<School> Schools { get; set; }
    }
}

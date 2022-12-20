using System;
using System.Collections.Generic;

namespace School_Lab3.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Schools = new HashSet<School>();
        }

        public int GradeId { get; set; }
        public int? FkStudentId { get; set; }
        public int? FkEmployeeId { get; set; }
        public string? GivenGrade { get; set; }
        public DateTime? DateOfGrade { get; set; }

        public virtual Employee? FkEmployee { get; set; }
        public virtual Student? FkStudent { get; set; }
        public virtual ICollection<School> Schools { get; set; }
    }
}

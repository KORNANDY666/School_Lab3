using System;
using System.Collections.Generic;

namespace School_Lab3.Models
{
    public partial class School
    {
        public int SchoolId { get; set; }
        public int? FkGradeId { get; set; }
        public int? FkSinfoId { get; set; }

        public virtual Grade? FkGrade { get; set; }
        public virtual SchoolInfo? FkSinfo { get; set; }
    }
}

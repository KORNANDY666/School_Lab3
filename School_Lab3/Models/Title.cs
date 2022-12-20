using System;
using System.Collections.Generic;

namespace School_Lab3.Models
{
    public partial class Title
    {
        public Title()
        {
            Employees = new HashSet<Employee>();
        }

        public int TitleId { get; set; }
        public string? WorkTitle { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace School_Lab3.Models
{

    public partial class Class
    {
        
        public Class()
        {

            Students = new HashSet<Student>();
        }
        
        public int Id { get; set; }
        public string? ClassId { get; set; }
        public string Name { get; set; }

        public enum course
        { 

        
        }


        public virtual ICollection<Student> Students { get; set; }
    }
}

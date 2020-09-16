using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebAPI.Models
{
    public class StudentPoco
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public ICollection<EnrollmentPoco> Enrollments { get; set; }
    }
}

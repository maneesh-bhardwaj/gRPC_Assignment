using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebAPI.Models
{
    public class CoursePoco
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public ICollection<EnrollmentPoco> Enrollments { get; set; }

    }
}

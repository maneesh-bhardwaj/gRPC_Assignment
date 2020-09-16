using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebAPI.Models
{
    public class EnrollmentPoco
    {
        [Key]
        public int EnrollmentID { get; set; }
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public StudentPoco Student { get; set; }
        public CoursePoco Course { get; set; }
    }
}

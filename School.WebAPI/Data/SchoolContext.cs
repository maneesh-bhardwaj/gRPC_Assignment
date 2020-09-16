using Microsoft.EntityFrameworkCore;
using School.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebAPI.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<StudentPoco> Students { get; set; }
        public DbSet<CoursePoco> Courses { get; set; }
        public DbSet<EnrollmentPoco> Enrollments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ARELPC\HUMBERBRIDGING;Initial Catalog=SCHOOLDB;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

       

        

        
    }
}

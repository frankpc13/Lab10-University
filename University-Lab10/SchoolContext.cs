using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using University_Lab10.Models;

namespace University_Lab10
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name = MyContextDB")
        {

        }

        public DbSet<Course> Courses { get; set; }
        
        public DbSet<Department> Departments { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<OfficeAssigment> OfficeAssigments { get; set; }

        public DbSet<Person> People { get; set; }
    }
}
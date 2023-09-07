using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CollegeEf.Models;
using CollegeEf.Controllers;

namespace CollegeEf.Data
{
    public class CollegeEfContext : DbContext
    {
        public CollegeEfContext (DbContextOptions<CollegeEfContext> options)
            : base(options)
        {
        }

        public DbSet<CollegeEf.Models.Students> Students { get; set; } = default!;
        public DbSet<CollegeEf.Models.Course> Courses { get; set; } = default!;
        public DbSet<Department> Departments { get; set; } = default!;
        public DbSet<Faculty> Faculty { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasOne<Course>().WithMany().HasForeignKey(v => v.CourseId);
            modelBuilder.Entity<Course>().HasOne<Faculty>().WithMany().HasForeignKey(v => v.FacultyId);
            modelBuilder.Entity<Students>().HasOne<Course>().WithMany().HasForeignKey(s => s.CourseId);
        }
    }
}

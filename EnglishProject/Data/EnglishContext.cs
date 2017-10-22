using System;
using EnglishProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishProject.Data
{
    public class EnglishContext : DbContext
    {
        public EnglishContext(DbContextOptions<EnglishContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskInfo> TaskInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Task>().ToTable("Task");
            modelBuilder.Entity<TaskInfo>().ToTable("TaskInfo");
        }
    }
}
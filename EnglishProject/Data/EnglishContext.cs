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

        public DbSet<Course> Course { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<EnglishTask> EnglishTask { get; set; }
        public DbSet<TaskInfo> TaskInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<EnglishTask>().ToTable("EnglishTask");
            modelBuilder.Entity<TaskInfo>().ToTable("TaskInfo");
        }
    }
}
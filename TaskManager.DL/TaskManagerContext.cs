using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.DL
{
    public class TaskManagerContext : DbContext, ITaskManagerContext
    {
        public TaskManagerContext() : base("name=taskdbconnectionstring")
        {
            
        }

        public DbSet<Task> Tasks { get; set; }

        public void MarkAsModified(Task task)
        {
            Entry(task).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasKey<int>(s => s.TaskId);

            modelBuilder.Entity<Task>().Property(p => p.TaskId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Task>().Property(p => p.TaskName).IsRequired();
            modelBuilder.Entity<Task>().Property(p => p.ParentId).IsOptional();
            modelBuilder.Entity<Task>().Property(p => p.Priority).IsOptional();
            modelBuilder.Entity<Task>().Property(p => p.StartDate).HasColumnType("Date").IsRequired();
            modelBuilder.Entity<Task>().Property(p => p.EndDate).HasColumnType("Date").IsRequired();
            modelBuilder.Entity<Task>().Property(p => p.EndTask).IsOptional();

            base.OnModelCreating(modelBuilder);
        }
    }
}

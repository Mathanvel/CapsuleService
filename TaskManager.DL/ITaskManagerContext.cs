using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.DL
{
    public interface ITaskManagerContext : IDisposable
    {
        DbSet<Task> Tasks { get; set; }
        void MarkAsModified(Task task);
        int SaveChanges();
    }
}

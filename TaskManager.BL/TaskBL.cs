using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.DL;
using TaskManager.Entities;

namespace TaskManager.BL
{
    public class TaskBL
    {
        private ITaskManagerContext _context;

        public TaskBL(ITaskManagerContext context)
        {
            _context = context;
        }
        public List<Task> GetAllTasks()
        {
            
            return _context.Tasks.ToList();
            
        }

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            var updateTask = _context.Tasks.Where(x => x.TaskId == task.TaskId).SingleOrDefault();
            updateTask.TaskName = task.TaskName;
            updateTask.ParentId = task.ParentId;
            updateTask.Priority = task.Priority;
            updateTask.StartDate = task.StartDate;
            updateTask.EndDate = task.EndDate;
            
            _context.MarkAsModified(updateTask);
            _context.SaveChanges();
        }

        public void EndTask(int taskId)
        {
            var task = _context.Tasks.Where(x => x.TaskId == taskId).SingleOrDefault();
            task.EndTask = "Y";
            _context.MarkAsModified(task);
            _context.SaveChanges();
        }

        public Task GetById(int taskId)
        {
            return _context.Tasks.SingleOrDefault(x => x.TaskId == taskId);
        }
    }
}

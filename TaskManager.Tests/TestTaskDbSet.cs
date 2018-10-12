using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.Tests
{
    public class TestTaskDbSet : TestDbSet<Task>
    {
        public override Task Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.TaskId == (int)keyValues.Single());
        }
    }
}

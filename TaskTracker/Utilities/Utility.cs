using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Models;

namespace TaskTracker.Utilities
{
    internal class Utility
    {
        public TaskItem GetTask(String task, int countTasks)
        {
            String[] taskDetails = task.Trim().Split(',');
            return new TaskItem
            {
                Id = countTasks + 1,
                Description = taskDetails[0].Trim(),
                Status = taskDetails[1].Trim(),
                StartDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }

    }
}

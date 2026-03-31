using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Models;
using TaskTracker.Enums;

namespace TaskTracker.Utilities
{
    internal class Utility
    {
        public TaskItem GetTask(String task, int countTasks)
        {
            
            return new TaskItem
            {
                Id = countTasks + 1,
                Description = task.Trim(),
                Status = Status.Todo,
                StartDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }

        public Status GetStatus(String status)
        {
            return status switch
            {
                "1" => Status.Todo,
                "2" => Status.InProgress,
                "3" => Status.Done,
                _ => throw new ArgumentException("Invalid status option")
            };
        }
    }
}

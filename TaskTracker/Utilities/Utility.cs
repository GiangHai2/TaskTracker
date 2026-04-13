using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Models;
using TaskTracker.Enums;

namespace TaskTracker.Utilities
{
    internal class Utility
    {
        public TaskItem GetTask(String description, int id)
        {
            
            return new TaskItem
            {
                Id = id,
                Description = description?.Trim(),
                Status = Status.Todo,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        public Status GetStatus(String status)
        {
            if (string.IsNullOrWhiteSpace(status)) throw new ArgumentException("Invalid status option");
            status = status.Trim().ToLowerInvariant();
            return status switch
            {
                "1" => Status.Todo,
                "todo" => Status.Todo,
                "2" => Status.InProgress,
                "inprogress" => Status.InProgress,
                "in-progress" => Status.InProgress,
                "3" => Status.Done,
                "done" => Status.Done,
                _ => throw new ArgumentException("Invalid status option")
            };
        }
    }
}

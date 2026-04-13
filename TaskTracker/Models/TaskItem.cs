using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Enums;

namespace TaskTracker.Models
{
    internal class TaskItem
    {
        public int Id { get; set; }
        
        public String Description { get; set; }

        public Status Status { get; set; }
        // CreatedAt corresponds to when the task was created
        public DateTime CreatedAt { get; set; }

        // UpdatedAt corresponds to when the task was last updated
        public DateTime UpdatedAt { get; set; }
    }
}

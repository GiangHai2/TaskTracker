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

        public DateTime StartDate { get; set; }

        public DateTime UpdateDate {  get; set; }
    }
}

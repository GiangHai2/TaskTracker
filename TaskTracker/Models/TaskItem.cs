using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Models
{
    internal class TaskItem
    {
        public int Id { get; set; }
        
        public String Description { get; set; }

        public String Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime UpdateDate {  get; set; }
    }
}

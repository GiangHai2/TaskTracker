using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Models;
using Newtonsoft.Json;
using TaskTracker.Utilities;
using System.IO;

namespace TaskTracker.Services
{
    internal class TaskServices
    {
        private List<TaskItem> tasks;
        private String filePath = "tasks.json";

        public TaskServices() 
        {
            tasks = LoadTasks();
        }

        public void AddTask(String task)
        {
            tasks.Add(new Utility().GetTask(task, tasks.Count));
        }

        public List<TaskItem> GetTasks()
        {
            return tasks;
        }

        public void UpdateTask(int id, String newDescription)
        {
            TaskItem task = tasks.Find(t => t.Id == id);
            if(task != null)
            {
                task.Description = newDescription;
                task.UpdateDate = DateTime.Now;
            }
        }

        public void DeleteTask(int id)
        {
            TaskItem task = tasks.Find(t => t.Id == id);
            if(task != null)
            {
                tasks.Remove(task);
            }
        }

        public void SaveTasks()
        {
            String json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private List<TaskItem> LoadTasks() 
        {
            if(!File.Exists(filePath))
            {
                return new List<TaskItem>();
            }
            String json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<TaskItem>>(json);
        }

    }
}

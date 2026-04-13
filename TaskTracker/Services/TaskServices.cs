using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Models;
using System.Text.Json;
using TaskTracker.Utilities;
using System.IO;
using TaskTracker.Enums;
using System.Linq;

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

        public TaskItem AddTask(String task)
        {
            int nextId = (tasks != null && tasks.Count > 0) ? tasks.Max(t => t.Id) + 1 : 1;
            var util = new Utility();
            var item = util.GetTask(task, nextId);
            tasks.Add(item);
            SaveTasks();
            return item;
        }

        public List<TaskItem> GetTasks()
        {
            return tasks;
        }

        public void UpdateTask(int id, String newDescription)
        {
            TaskItem task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.Description = newDescription;
                task.UpdatedAt = DateTime.Now;
                SaveTasks();
            }
        }

        public void DeleteTask(int id)
        {
            TaskItem task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
                SaveTasks();
            }
        }

        public void UpdateTaskStatus(int id, Status newStatus)
        {
            TaskItem task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.Status = newStatus;
                task.UpdatedAt = DateTime.Now;
                SaveTasks();
            }
        }

        public void SaveTasks()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            String json = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(filePath, json);
        }

        private List<TaskItem> LoadTasks()
        {
            if (!File.Exists(filePath))
            {
                return new List<TaskItem>();
            }
            String json = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(json)) return new List<TaskItem>();
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }

    }
}

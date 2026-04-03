using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Services;
using TaskTracker.Views;
using TaskTracker.Utilities;

namespace TaskTracker.Controller
{
    internal class TaskController
    {
        private TaskServices taskServices;
        private TaskView taskView;

        public TaskController(TaskServices s, TaskView v)
        {
            taskServices = s;
            taskView = v;
        }

        public void Run(String[] command)
        {
            while (true)
            {
                if(command.Length == 0 || command[0] == "help") { 
                    taskView.ShowHelp();
                    command = taskView.GetInput("Enter command: ").Split(' ');
                    continue;
                }
                String choice = command[0];
                switch (choice)
                {
                    case "add":
                        String task = taskView.GetInput("Enter task details Description: ");
                        taskServices.AddTask(task);
                        break;
                    case "list":
                        taskView.DisPlayMessage("--------Tasks--------");
                        var tasks = taskServices.GetTasks();
                        foreach (var t in tasks)
                        {
                            taskView.DisPlayMessage($"Id: {t.Id}, Description: {t.Description}, Status: {t.Status}, Start Date: {t.StartDate}, Update Date: {t.UpdateDate}");
                        }
                        break;
                    case "update":
                        int idToUpdate = int.Parse(taskView.GetInput("Enter task Id to update: "));
                        String newDescription = taskView.GetInput("Enter new description: ");
                        taskServices.UpdateTask(idToUpdate, newDescription);
                        break;
                    case "delete":
                        int idToDelete = int.Parse(taskView.GetInput("Enter task Id to delete: "));
                        taskServices.DeleteTask(idToDelete);
                        break;
                    case "5":
                        int idToUpdateStatus = int.Parse(taskView.GetInput("Enter task Id to update status: "));
                        String newStatus = taskView.DisplayUpdateStatusMessage();
                        taskServices.UpdateTaskStatus(idToUpdateStatus, new Utility().GetStatus(newStatus));
                        break;
                    case "6":
                        taskServices.SaveTasks();
                        return;
                    default:
                        taskView.DisPlayMessage("Invalid option. Please try again.");
                        break;
                }
            }

        }
    }
}

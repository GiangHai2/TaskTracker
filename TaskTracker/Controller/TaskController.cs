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

        public void Run()
        {
            while (true)
            {
                taskView.DisplayMenu();
                String choice = taskView.GetInput("");
                switch (choice)
                {
                    case "1":
                        String task = taskView.GetInput("Enter task details Description: ");
                        taskServices.AddTask(task);
                        break;
                    case "2":
                        taskView.DisPlayMessage("--------Tasks--------");
                        var tasks = taskServices.GetTasks();
                        foreach (var t in tasks)
                        {
                            taskView.DisPlayMessage($"Id: {t.Id}, Description: {t.Description}, Status: {t.Status}, Start Date: {t.StartDate}, Update Date: {t.UpdateDate}");
                        }
                        break;
                    case "3":
                        int idToUpdate = int.Parse(taskView.GetInput("Enter task Id to update: "));
                        String newDescription = taskView.GetInput("Enter new description: ");
                        taskServices.UpdateTask(idToUpdate, newDescription);
                        break;
                    case "4":
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

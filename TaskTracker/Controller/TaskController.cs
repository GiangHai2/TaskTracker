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
            if (command == null || command.Length == 0 || command[0] == "help")
            {
                taskView.ShowHelp();
                return;
            }

            string choice = command[0].ToLowerInvariant();
            switch (choice)
            {
                case "add":
                    if (command.Length < 2)
                    {
                        taskView.DisPlayMessage("[Lỗi] Thiếu mô tả. Cú pháp: add <description>");
                        break;
                    }
                    string description = command.Length > 2 ? string.Join(" ", command, 1, command.Length - 1) : command[1];
                    var added = taskServices.AddTask(description);
                    taskView.DisPlayMessage($"Task added successfully (ID: {added.Id})");
                    break;

                case "list":
                    taskView.DisPlayMessage("--------Tasks--------");
                    var tasks = taskServices.GetTasks();
                    if (command.Length > 1)
                    {
                        var statusArg = command[1].ToLowerInvariant();
                        tasks = statusArg switch
                        {
                            "todo" => tasks.FindAll(t => t.Status == TaskTracker.Enums.Status.Todo),
                            "in-progress" => tasks.FindAll(t => t.Status == TaskTracker.Enums.Status.InProgress),
                            "inprogress" => tasks.FindAll(t => t.Status == TaskTracker.Enums.Status.InProgress),
                            "done" => tasks.FindAll(t => t.Status == TaskTracker.Enums.Status.Done),
                            _ => tasks
                        };
                    }
                    foreach (var t in tasks)
                    {
                        taskView.DisPlayMessage($"Id: {t.Id}, Description: {t.Description}, Status: {t.Status}, CreatedAt: {t.CreatedAt}, UpdatedAt: {t.UpdatedAt}");
                    }
                    break;

                case "update":
                    if (command.Length < 3)
                    {
                        taskView.DisPlayMessage("[Lỗi] Cú pháp: update <id> <new description>");
                        break;
                    }
                    if (!int.TryParse(command[1], out int idToUpdate))
                    {
                        taskView.DisPlayMessage("[Lỗi] Id không hợp lệ.");
                        break;
                    }
                    string newDesc = command.Length > 3 ? string.Join(" ", command, 2, command.Length - 2) : command[2];
                    taskServices.UpdateTask(idToUpdate, newDesc);
                    taskView.DisPlayMessage($"Task {idToUpdate} updated.");
                    break;

                case "delete":
                    if (command.Length < 2)
                    {
                        taskView.DisPlayMessage("[Lỗi] Cú pháp: delete <id>");
                        break;
                    }
                    if (!int.TryParse(command[1], out int idToDelete))
                    {
                        taskView.DisPlayMessage("[Lỗi] Id không hợp lệ.");
                        break;
                    }
                    taskServices.DeleteTask(idToDelete);
                    taskView.DisPlayMessage($"Task {idToDelete} deleted.");
                    break;

                case "mark-in-progress":
                    if (command.Length < 2)
                    {
                        taskView.DisPlayMessage("[Lỗi] Cú pháp: mark-in-progress <id>");
                        break;
                    }
                    if (!int.TryParse(command[1], out int idInProgress))
                    {
                        taskView.DisPlayMessage("[Lỗi] Id không hợp lệ.");
                        break;
                    }
                    taskServices.UpdateTaskStatus(idInProgress, TaskTracker.Enums.Status.InProgress);
                    taskView.DisPlayMessage($"Task {idInProgress} marked InProgress.");
                    break;

                case "mark-done":
                    if (command.Length < 2)
                    {
                        taskView.DisPlayMessage("[Lỗi] Cú pháp: mark-done <id>");
                        break;
                    }
                    if (!int.TryParse(command[1], out int idDone))
                    {
                        taskView.DisPlayMessage("[Lỗi] Id không hợp lệ.");
                        break;
                    }
                    taskServices.UpdateTaskStatus(idDone, TaskTracker.Enums.Status.Done);
                    taskView.DisPlayMessage($"Task {idDone} marked Done.");
                    break;

                case "save":
                    taskServices.SaveTasks();
                    taskView.DisPlayMessage("Tasks saved.");
                    return;

                default:
                    Console.WriteLine($"[Lỗi] Lệnh '{choice}' không hợp lệ.");
                    Console.WriteLine("Hãy gõ 'task-cli help' để xem danh sách các lệnh hỗ trợ.");
                    break;
            }
        }
    }
}

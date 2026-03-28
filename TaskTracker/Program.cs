
namespace TaskTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaskItem> task = new List<TaskItem>();

            while (true)
            {
                Console.WriteLine("------ Task Tracker ---");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        task.Add(new TaskItem {Id = task.Count + 1,  Description = description, Status = "Pending", StartDate = DateTime.Now, UpdateDate = DateTime.Now });
                        Console.WriteLine("Task added successfully!");
                        break;

                    case 2:
                        Console.WriteLine("------ Task List ---");
                        foreach (var t in task)
                        {

                            Console.WriteLine(value: $"ID: {t.Id}, Description: {t.Description}, Status: {t.Status}, Start Date: {t.StartDate}, Update Date: {t.UpdateDate}");
                        }
                        break;

                    case 3:
                        Console.Write("Enter task ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        var taskToUpdate = task.FirstOrDefault(t => t.Id == updateId);
                        if (taskToUpdate != null)
                        {
                            Console.Write("Enter new description: ");
                            taskToUpdate.Description = Console.ReadLine();
                            Console.Write("Enter new status: ");
                            taskToUpdate.Status = Console.ReadLine();
                            taskToUpdate.UpdateDate = DateTime.Now;
                            Console.WriteLine("Task updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Task not found!");
                        }
                        break;

                    case 4:
                        Console.Write("Enter task ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        var taskToDelete = task.FirstOrDefault(t => t.Id == deleteId);
                        if (taskToDelete != null)
                        {
                            task.Remove(taskToDelete);
                            Console.WriteLine("Task deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Task not found!");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                }
            }
        }
    }
}

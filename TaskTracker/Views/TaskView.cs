using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Views
{
    internal class TaskView
    {
        public void DisplayMenu()
        {
            Console.WriteLine("------ Task Tracker ---");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Update Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
        }

        public String GetInput(String input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        public String DisPlayMessage(String message)
        {
            Console.WriteLine(message);
            return message;
        }
    }
}

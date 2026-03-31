using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Views
{
    internal class TaskView
    {
        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("------ Task Tracker ---");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Update Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Update Task Status");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            Console.ResetColor();
        }

        public String GetInput(String input)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(input);
            Console.ResetColor ();
            return Console.ReadLine();
        }

        public String DisPlayMessage(String message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
            return message;
        }

        public String DisplayUpdateStatusMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("--- Status ---");
            Console.WriteLine("1. Todo");
            Console.WriteLine("2. InProgress");
            Console.WriteLine("3. Done");
            Console.Write("Select new status: ");
            Console.ResetColor();
            return Console.ReadLine();
        }
    }
}

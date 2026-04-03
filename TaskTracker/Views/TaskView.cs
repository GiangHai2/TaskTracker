using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Views
{
    internal class TaskView
    {
        public void ShowHelp() 
        {
            Console.WriteLine("\n=== TASK TRACKER CLI ===");
            Console.WriteLine("Cách sử dụng: task-cli <lệnh> [tham số]");
            Console.WriteLine("\nDanh sách các lệnh:");
            Console.WriteLine("  add \"<mô tả>\"               - Thêm công việc mới");
            Console.WriteLine("  update <id> \"<mô tả mới>\"   - Cập nhật công việc");
            Console.WriteLine("  delete <id>                 - Xóa công việc");
            Console.WriteLine("  mark-in-progress <id>       - Đánh dấu trạng thái 'đang làm'");
            Console.WriteLine("  mark-done <id>              - Đánh dấu trạng thái 'đã xong'");
            Console.WriteLine("  list                        - Hiển thị tất cả công việc");
            Console.WriteLine("  list <status>               - Lọc công việc (todo, in-progress, done)");
            Console.WriteLine("\nVí dụ: task-cli add \"Học lập trình C#\"");
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

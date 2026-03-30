using TaskTracker.Controller;
using TaskTracker.Services;
using TaskTracker.Views;

namespace TaskTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskServices services = new TaskServices();
            TaskController controller = new TaskController(services, new TaskView());
            controller.Run();
        }
    }
}

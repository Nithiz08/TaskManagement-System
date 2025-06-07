using Microsoft.AspNetCore.Mvc;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public HomeController(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            var users = await _userService.GetAllUsersAsync();

            ViewBag.TotalTasks = tasks.Count();
            ViewBag.CompletedTasks = tasks.Count(t => t.IsCompleted);
            ViewBag.PendingTasks = tasks.Count(t => !t.IsCompleted);
            ViewBag.TotalUsers = users.Count();

            return View(tasks);
        }
    }
}
using BLL.Factories;
using EDiary.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EDiary.Controllers
{
    public class TaskController : BaseController
    {
        private readonly ITaskModelFactory _taskModelFactory;

        public TaskController(ITaskModelFactory taskModelFactory)
        {
            _taskModelFactory = taskModelFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTask(int id)
        {
            var userId = User.GetLoggedInUserId<string>();
            var model = _taskModelFactory.PrepareTaskViewModel(id, userId);

            return View(model);
        }

        [HttpPost]
        public JsonResult GetTaskNotes(int taskId)
        {
            var userId = User.GetLoggedInUserId<string>();
            var model = _taskModelFactory.PrepareTaskNotesViewModel(taskId, userId);

            return CreateJsonResult(true, new { model.TaskNotes });
        }
    }
}

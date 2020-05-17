using BLL.Interfaces;
using EDiary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EDiary.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public IActionResult Index()
        {
            var model = new ToDoViewModel {
                ToDoItems = _toDoService.GetToDosList()
            };

            return View(model);
        }
    }
}
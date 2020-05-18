using BLL.Factories;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EDiary.Controllers
{
    public class ToDoController : BaseController
    {
        private readonly IToDoModelFactory _toDoModelFactory;

        public ToDoController(IToDoModelFactory toDoModelFactory)
        {
            _toDoModelFactory = toDoModelFactory;
        }

        [HttpGet]
        public IActionResult Index(ToDoFilterModel filter, SimplePagerModel pager)
        {
            var model = _toDoModelFactory.PrepareToDoViewModel(filter, pager);

            return View(model);
        }

        [HttpPost]
        public JsonResult GetToDos(ToDoFilterModel filter, SimplePagerModel pager)
        {
            var model = _toDoModelFactory.PrepareToDoViewModel(filter, pager);

            return CreateJsonResult(true, new
            {
                ToDos = model.ToDoItems,
                Pager = model.Paging
            });
        }
    }
}
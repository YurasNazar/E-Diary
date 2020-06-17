using BLL.Factories;
using DAL.Entities;
using DAL.Models;
using DAL.ViewModels;
using EDiary.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EDiary.Controllers
{
    public class ToDoController : BaseController
    {
        private readonly IToDoModelFactory _toDoModelFactory;
        private readonly UserManager<ApplicationUser> _userManager;

        public ToDoController(IToDoModelFactory toDoModelFactory, UserManager<ApplicationUser> userManager)
        {
            _toDoModelFactory = toDoModelFactory;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(ToDoFilterModel filter, SimplePagerModel pager)
        {
            var userId = User.GetLoggedInUserId<string>();
            var isTeacher = User.IsTeacher();

            var model = new ToDoViewModel();

            if (isTeacher) {
                model = _toDoModelFactory.PrepareTeacherToDoViewModel(filter, pager, userId);
            }
            else {
                model = _toDoModelFactory.PrepareToDoViewModel(filter, pager, userId);
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult GetToDos(ToDoFilterModel filter, SimplePagerModel pager)
        {
            var userId = User.GetLoggedInUserId<string>();
            var model = _toDoModelFactory.PrepareToDoViewModel(filter, pager, userId);

            return CreateJsonResult(true, new
            {
                ToDos = model.ToDoItems,
                Pager = model.Paging
            });
        }
    }
}
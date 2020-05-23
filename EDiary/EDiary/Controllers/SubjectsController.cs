using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDiary.Controllers
{
    public class SubjectsController : BaseController
    {
        public SubjectsController()
        {

        }

        [HttpGet]
        public IActionResult Index(/*ToDoFilterModel filter, SimplePagerModel pager*/)
        {
            //var userId = User.GetLoggedInUserId<string>();
            //var model = _toDoModelFactory.PrepareToDoViewModel(filter, pager, userId);

            return View();
        }

    }
}

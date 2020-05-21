using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDiary.Controllers
{
    public class TaskController : BaseController
    {
        public TaskController()
        {
                
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

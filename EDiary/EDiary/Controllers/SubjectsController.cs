using DAL.Entities;
using EDiary.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDiary.Controllers
{
    public class SubjectsController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public SubjectsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var isTeacher = User.IsTeacher();
            if (isTeacher)
            {
                return View("../Teacher/Subjects/Create");
            }

            return View();
        }
        
        [HttpGet]
        public IActionResult List()
        {
            var isTeacher = User.IsTeacher();
            if (isTeacher)
            {
                return View("../Subjects/Index");
            }

            return View();
        }
    }
}

using BLL.Interfaces;
using EDiary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDiary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index() 
        {
            var model = new HomeIndexViewModel();
            model.Users = _userService.GetUsers();
            return View(model);
        }
    }
}

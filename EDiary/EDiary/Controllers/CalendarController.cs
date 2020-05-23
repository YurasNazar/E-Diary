using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EDiary.Controllers
{
    public class CalendarController : BaseController
    {
        public CalendarController()
        {
                
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCalendarDayItems(DateTime? calendarDay)
        {
            return CreateJsonResult(true, new
            {
                ToDos = calendarDay,
            });
        }
    }
}

using BLL.Factories;
using EDiary.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDiary.Controllers
{
    public class CalendarController : BaseController
    {
        private readonly ICalendarModelFactory _calendarModelFactory;
        public CalendarController(ICalendarModelFactory calendarModelFactory)
        {
            _calendarModelFactory = calendarModelFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCalendarDayItems(DateTime? calendarDay)
        {
            var userId = User.GetLoggedInUserId<string>();
            var model = _calendarModelFactory.PrepareCalendarViewModel(calendarDay, userId);

            return CreateJsonResult(true, new
            {
                model.CalendarEvents,
            });
        }
    }
}

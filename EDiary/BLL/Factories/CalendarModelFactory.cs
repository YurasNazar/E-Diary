using BLL.Interfaces;
using Common;
using DAL.Entities;
using DAL.Models;
using DAL.ViewModels;
using System;
using System.Linq;

namespace BLL.Factories
{
    public class CalendarModelFactory : ICalendarModelFactory
    {
        private readonly ICalendarService _calendarService;
        public CalendarModelFactory(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        public CalendarViewModel PrepareCalendarViewModel(DateTime? calendarDay, string userId = "")
        {
            var pagedList = _calendarService.SearchCalendarEvents(calendarDay, userId);

            var CalendarViewModel = new CalendarViewModel
            {
                CalendarEvents = pagedList.Select(PrepareCalendarEventModel).ToList(),
            };

            return CalendarViewModel;
        }

        public CalendarEvent PrepareCalendarEventModel(UserScheculeEventMapping userEventMapping)
        {
            DateTime fromDateTime = DateTime.Today.Add(userEventMapping.ScheduleEvent.From);
            string fromTimeString = fromDateTime.ToString(Constants.TimeFormat.AMPMFormat);

            DateTime toDateTime = DateTime.Today.Add(userEventMapping.ScheduleEvent.To);
            string toTimeString = toDateTime.ToString(Constants.TimeFormat.AMPMFormat);

            return new CalendarEvent
            {
                Date = userEventMapping.ScheduleEvent.Date,
                From = fromTimeString,
                To = toTimeString,
                Title = userEventMapping.ScheduleEvent.Title,
                Location = userEventMapping.ScheduleEvent.Location,
                Description = userEventMapping.ScheduleEvent.Description,
            };
        }
    }
}

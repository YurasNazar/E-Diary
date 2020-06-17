using DAL.Entities;
using DAL.ViewModels;
using System;


namespace BLL.Factories
{
    public interface ICalendarModelFactory
    {
        public CalendarViewModel PrepareCalendarViewModel(DateTime? calendarDay, string userId = "");
        public ScheduleEvent PrepareScheduleEventModel(CreateAppointmentViewModel appointmentViewModel, string userId = "");
    }
}

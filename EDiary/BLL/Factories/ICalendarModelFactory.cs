using DAL.ViewModels;
using System;


namespace BLL.Factories
{
    public interface ICalendarModelFactory
    {
        public CalendarViewModel PrepareCalendarViewModel(DateTime? calendarDay, string userId = "");
    }
}

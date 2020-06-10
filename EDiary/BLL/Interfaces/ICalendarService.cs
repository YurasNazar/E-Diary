using BLL.PagedList;
using DAL.Entities;
using System;

namespace BLL.Interfaces
{
    public interface ICalendarService
    {
        public IPagedList<UserScheculeEventMapping> SearchCalendarEvents(DateTime? calendarDay, string userId = "");
    }
}

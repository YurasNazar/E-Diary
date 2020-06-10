using BLL.Interfaces;
using BLL.PagedList;
using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BLL.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IRepository<UserScheculeEventMapping> _userScheduleEventsMapping;

        public CalendarService(IRepository<UserScheculeEventMapping> userScheduleEventsMapping)
        {
            _userScheduleEventsMapping = userScheduleEventsMapping;
        }

        public IPagedList<UserScheculeEventMapping> SearchCalendarEvents(DateTime? calendarDay, string userId = "")
        {
            var query = GetSearchQuery(calendarDay, userId);

            return new PagedList<UserScheculeEventMapping>(query, 0, int.MaxValue);
        }

        private IQueryable<UserScheculeEventMapping> GetSearchQuery(DateTime? calendarDay, string userId = "")
        {
            var query = _userScheduleEventsMapping.TableNoTracking.Include(x => x.User)
                .Include(x => x.ScheduleEvent) as IQueryable<UserScheculeEventMapping>;

            if (calendarDay.HasValue)
            {
                query = query.Where(x => x.ScheduleEvent.Date == calendarDay.Value);
            }

            query = query.Where(x => x.User.Id == userId);

            query = query.OrderBy(x => x.ScheduleEvent.From);

            return query;
        }
    }
}

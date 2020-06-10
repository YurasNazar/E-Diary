using System;

namespace DAL.Models
{
    public class CalendarEvent
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ScheduleEvent : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}

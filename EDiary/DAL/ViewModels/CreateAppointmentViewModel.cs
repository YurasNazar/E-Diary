using System;

namespace DAL.ViewModels
{
    public class CreateAppointmentViewModel
    {
        public string Theme { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string SubjectName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}

using System;

namespace DAL.ViewModels
{
    public class CreateTaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxAssessment { get; set; }
        public int SubjectId { get; set; }
        public DateTime DeadLine { get; set; }
    }
}

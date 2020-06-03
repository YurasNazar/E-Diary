using System;

namespace DAL.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxAssessment { get; set; }
        public int? Assessment { get; set; }
        public int StatusId { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual Subject Subject { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

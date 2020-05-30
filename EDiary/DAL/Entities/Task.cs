using System;

namespace DAL.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int StatusId { get; set; }
        public string TeacherId { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public DateTime DeadLine { get; set; }
    }
}

using System;

namespace DAL.Entities
{
    public class ToDo : BaseEntity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public int SubjectId { get; set; }
        public DateTime DeadLine { get; set; }
    }
}

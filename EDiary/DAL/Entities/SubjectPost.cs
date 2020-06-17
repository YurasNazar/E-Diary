using System;

namespace DAL.Entities
{
    public class SubjectPost : BaseEntity
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
    }
}

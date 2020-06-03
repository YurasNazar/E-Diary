using System;

namespace DAL.Entities
{
    public class SubjectPost : BaseEntity
    {
        public Subject Subject { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
    }
}

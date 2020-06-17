using System;

namespace DAL.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
        public string JoinCode { get; set; }
    }
}

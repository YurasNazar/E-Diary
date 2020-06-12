using System;

namespace DAL.Entities
{
    public class TaskNote : BaseEntity
    {
        public int TaskId { get; set; }
        public ApplicationUser User { get; set; }
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

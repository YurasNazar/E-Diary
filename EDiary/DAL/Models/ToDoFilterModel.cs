using System;

namespace DAL.Models
{
    public class ToDoFilterModel
    {
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int StatusId { get; set; }
    }
}

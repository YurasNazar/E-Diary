using System;

namespace DAL.Models
{
    public class ToDoFilterModel
    {
        public string Name { get; set; }
        public string Subjects { get; set; }
        public DateTime? Deadline { get; set; }
        public int StatusId { get; set; }
    }
}

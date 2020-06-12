using Common.Enums;
using System;

namespace DAL.Models
{
    public class ToDoItem
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public string Status => ((TaskStatus)StatusId).ToString();
        public int SubjectId { get; set; }
        public string Subject { get; set; }
        public DateTime DeadLine { get; set; }
    }
}

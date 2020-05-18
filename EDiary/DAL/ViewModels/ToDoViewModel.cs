using System.Collections.Generic;
using DAL.Entities;
using DAL.Models;

namespace DAL.ViewModels
{
    public class ToDoViewModel
    {
        public List<ToDo> ToDoItems { get; set; }
        public SimplePagerModel Paging { get; set; }
        public ToDoFilterModel Filter { get; set; }
        public List<KeyValuePair<int, string>> Statuses { get; set; }
    }
}

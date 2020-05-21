using System.Collections.Generic;
using DAL.Models;

namespace DAL.ViewModels
{
    public class ToDoViewModel
    {
        public List<ToDoItem> ToDoItems { get; set; }
        public SimplePagerModel Paging { get; set; }
        public ToDoFilterModel Filter { get; set; }
        public List<KeyValuePair<int, string>> Statuses { get; set; }
    }
}

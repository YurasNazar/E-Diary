using System.Collections.Generic;
using DAL.Entities;

namespace EDiary.ViewModels
{
    public class ToDoViewModel
    {
        public IList<ToDo> ToDoItems { get; set; }
    }
}

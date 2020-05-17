using BLL.Interfaces;
using DAL.Entities;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<ToDo> _toDoRepository;
        public ToDoService(IRepository<ToDo> toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        public IList<ToDo> GetToDosList()
        {
            var toDos = _toDoRepository.Table;
            var toDosList = toDos.ToList();
            return toDosList;
        }
    }
}

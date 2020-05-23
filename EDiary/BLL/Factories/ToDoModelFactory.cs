using BLL.Extensions;
using BLL.Interfaces;
using Common;
using DAL.Entities;
using DAL.Models;
using DAL.ViewModels;
using System.Linq;

namespace BLL.Factories
{
    public class ToDoModelFactory : IToDoModelFactory
    {
        private readonly IToDoService _toDoService;
        public ToDoModelFactory(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public ToDoViewModel PrepareToDoViewModel(ToDoFilterModel filter, SimplePagerModel pager, string userId)
        {
            var pagedList = _toDoService.SearchToDos(
                subjects: filter.Subjects,
                deadline: filter.Deadline,
                name: filter.Name,
                pageIndex: pager.PageIndex, pageSize: pager.PageSize > 0 ? pager.PageSize : Constants.Paging.DefaultPageSize, userId);

            var orderListModel = new ToDoViewModel
            {
                ToDoItems = pagedList.Select(PrepareToDoModel).ToList(),
                Paging = PagerExtensions.ToSimplePagerModel(pagedList),
                Filter = filter,
            };

            return orderListModel;
        }

        public ToDoItem PrepareToDoModel(Task todo)
        {
            return new ToDoItem
            {
                Name = todo.Name,
                Description = todo.Description,
                StatusId = todo.StatusId,
                //SubjectId = todo.SubjectId,
                DeadLine = todo.DeadLine
            };
        }
    }
}

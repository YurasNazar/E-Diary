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

        public ToDoViewModel PrepareToDoViewModel(ToDoFilterModel filter, SimplePagerModel pager)
        {
            var pagedList = _toDoService.SearchToDos(
                deadline: filter.Deadline,
                description: filter.Description,
                pageIndex: pager.PageIndex, pageSize: pager.PageSize > 0 ? pager.PageSize : Constants.Paging.DefaultPageSize);

            var orderListModel = new ToDoViewModel
            {
                ToDoItems = pagedList.Select(PrepareToDoModel).ToList(),
                Paging = PagerExtensions.ToSimplePagerModel(pagedList),
                Filter = filter,
            };

            return orderListModel;
        }

        public ToDo PrepareToDoModel(ToDo todo)
        {
            return todo;
        }
    }
}

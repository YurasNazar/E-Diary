using BLL.Extensions;
using BLL.Interfaces;
using Common;
using Common.Enums;
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
                statusId: filter.StatusId,
                pageIndex: pager.PageIndex, pageSize: pager.PageSize > 0 ? pager.PageSize : Constants.Paging.DefaultPageSize, userId);

            var toDoListModel = new ToDoViewModel
            {
                ToDoItems = pagedList.Select(PrepareToDoModel).ToList(),
                Paging = PagerExtensions.ToSimplePagerModel(pagedList),
                Statuses = EnumHelpers.GetEnumKeyValuePairList<TaskStatus>(),
                Filter = filter,
            };

            return toDoListModel;
        }

        public ToDoItem PrepareToDoModel(UserTaskMapping userTask)
        {
            return new ToDoItem
            {
                TaskId = userTask.Task.Id,
                Name = userTask.Task.Name,
                Description = userTask.Task.Description,
                StatusId = userTask.Task.StatusId,
                DeadLine = userTask.Task.DeadLine,
                Subject = userTask.Task.Subject.Name
            };
        }
    }
}

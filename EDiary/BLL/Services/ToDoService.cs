using BLL.Interfaces;
using BLL.PagedList;
using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BLL.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<UserTaskMapping> _userTaskMappingRepository;

        public ToDoService(IRepository<Task> taskRepository,
                           IRepository<UserTaskMapping> userTaskMappingRepository)
        {
            _userTaskMappingRepository = userTaskMappingRepository;
        }

        public IPagedList<UserTaskMapping> SearchToDos(string subjects = null, DateTime? deadline = null, string name = null, int? statusId = null, 
            int pageIndex = 0, int pageSize = int.MaxValue, string userId = "")
        {
            var query = GetSearchTasksQuery(subjects, deadline, name, statusId, userId);

            return new PagedList<UserTaskMapping>(query, pageIndex, pageSize);
        }

        private IQueryable<UserTaskMapping> GetSearchTasksQuery(string subjects, DateTime? deadline, string name, int? statusId, string userId)
        {
            var query = _userTaskMappingRepository.TableNoTracking.Include(x => x.User)
                .Include(x => x.Task).ThenInclude(task => task.Subject)
                .Include(x => x.Task).ThenInclude(task => task.CreatedBy) as IQueryable<UserTaskMapping>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Task.Name.ToLower().Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(subjects))
            {
                query = query.Where(x => x.Task.Subject.Name.ToLower().Contains(subjects));
            }

            if (deadline.HasValue)
            {
                query = query.Where(x => x.Task.DeadLine <= deadline.Value);
            }

            if (statusId.HasValue)
            {
                query = query.Where(x => x.Task.StatusId == statusId.Value);
            }

            query = query.Where(x => x.User.Id == userId);

            query = query.OrderBy(x => x.Task.DeadLine);

            return query;
        }
    }
}

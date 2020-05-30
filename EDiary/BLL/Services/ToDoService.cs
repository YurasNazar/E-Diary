using BLL.Interfaces;
using BLL.PagedList;
using DAL.Entities;
using DAL.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BLL.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<Task> _taskRepository;
        private readonly IRepository<Subject> _subjectRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ToDoService(IRepository<Task> taskRepository,
                           IRepository<Subject> subjectRepository,
                           UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _taskRepository = taskRepository;
            _subjectRepository = subjectRepository;
        }

        public IPagedList<Task> SearchToDos(string subjects = null, DateTime? deadline = null, string name = null, int? statusId = null, int pageIndex = 0, int pageSize = int.MaxValue, string userId = "")
        {
            var query = GetSearchOrdersQuery(subjects, deadline, name, statusId, pageIndex, pageSize, userId);

            return new PagedList<Task>(query, pageIndex, pageSize);

        }

        private IQueryable<Task> GetSearchOrdersQuery(string subjects, DateTime? deadline, string name, int? statusId, int pageIndex, int pageSize, string userId)
        {
            var query = _taskRepository.TableNoTracking.Include(x => x.Subject) as IQueryable<Task>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(subjects))
            {
                query = query.Where(x => x.Subject.Name.ToLower().Contains(subjects));
            }

            if (deadline.HasValue)
            {
                query = query.Where(x => x.DeadLine <= deadline.Value);
            }

            if (statusId.HasValue)
            {
                query = query.Where(x => x.StatusId == statusId.Value);
            }

            query = query.Where(x => x.UserId == userId);

            query = query.OrderBy(x => x.DeadLine);

            return query;
        }
    }
}

using BLL.Interfaces;
using BLL.PagedList;
using DAL.Entities;
using DAL.Repository;
using Microsoft.AspNetCore.Identity;
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

        public IPagedList<Task> SearchToDos(DateTime? deadline = null, string description = null, int pageIndex = 0, int pageSize = int.MaxValue, string userId = "")
        {
            var query = GetSearchOrdersQuery(deadline, description, pageIndex, pageSize, userId);

            return new PagedList<Task>(query, pageIndex, pageSize);

        }

        private IQueryable<Task> GetSearchOrdersQuery(DateTime? deadline, string description, int pageIndex, int pageSize, string userId)
        {
            var query = _taskRepository.TableNoTracking;

            //query = query.Join(_subjectRepository.TableNoTracking,
            //    task => task.SubjectId,
            //    subject => subject.Name);

            if (!string.IsNullOrWhiteSpace(description))
            {
                query = query.Where(x => x.Description.ToLower().Contains(description));
            }

            if (deadline.HasValue)
            {
                query = query.Where(x => x.DeadLine <= deadline.Value);
            }

            query = query.Where(x => x.UserId == userId);

            query = query.OrderBy(x => x.DeadLine);

            return query;
        }
    }
}

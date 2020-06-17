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
        private readonly IRepository<TeacherTaskMapping> _teacherTaskMappingRepository;

        public ToDoService(IRepository<Task> taskRepository,
                           IRepository<UserTaskMapping> userTaskMappingRepository,
                           IRepository<TeacherTaskMapping> teacherTaskMappingRepository)
        {
            _userTaskMappingRepository = userTaskMappingRepository;
            _teacherTaskMappingRepository = teacherTaskMappingRepository;
        }

        public IPagedList<TeacherTaskMapping> SearchTeacherToDos(string subjects, DateTime? deadline, string name, int? statusId, int pageIndex, int pageSize, string userId)
        {
            var query = GetSearchTeachersTasksQuery(subjects, deadline, name, statusId, userId);

            return new PagedList<TeacherTaskMapping>(query, pageIndex, pageSize);
        }

        private IQueryable<TeacherTaskMapping> GetSearchTeachersTasksQuery(string subjects, DateTime? deadline, string name, int? statusId, string userId)
        {
            var query = _teacherTaskMappingRepository.TableNoTracking.Include(x => x.Teacher)
                .Include(x => x.Task).ThenInclude(task => task.Subject)
                .Include(x => x.Task).ThenInclude(task => task.CreatedBy) as IQueryable<TeacherTaskMapping>;

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

            query = query.Where(x => x.Teacher.Id == userId);

            query = query.OrderBy(x => x.Task.DeadLine);

            return query;
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

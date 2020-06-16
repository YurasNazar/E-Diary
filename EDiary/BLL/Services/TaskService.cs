using BLL.Interfaces;
using BLL.PagedList;
using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<Task> _taskRepository;
        private readonly IRepository<TaskNote> _taskNotesRepository;
        private readonly IRepository<TaskFileMapping> _taskFileMappingRepository;

        public TaskService(IRepository<Task> taskRepository,
                           IRepository<TaskNote> taskNotesRepository,
                           IRepository<TaskFileMapping> taskFileMappingRepository)
        {
            _taskRepository = taskRepository;
            _taskNotesRepository = taskNotesRepository;
            _taskFileMappingRepository = taskFileMappingRepository;
        }

        public Task GetById(int id)
        {
            return _taskRepository.TableNoTracking.Include(x => x.Subject).Include(x => x.CreatedBy).Where(x => x.Id == id).FirstOrDefault();
        }

        public Task GetByWithoutRelatedData(int id)
        {
            return _taskRepository.TableNoTracking.Where(x => x.Id == id).FirstOrDefault();
        }

        public void IntertTaskNote(TaskNote taskNote)
        {
            _taskNotesRepository.Insert(taskNote);
        }

        public IPagedList<TaskFileMapping> SearchTaskFiles(int taskId)
        {
            var query = GetSearchTaskFilesQuery(taskId);

            return new PagedList<TaskFileMapping>(query, 0, int.MaxValue);
        }

        public IPagedList<TaskNote> SearchTaskNotes(int taskId, string userId = "")
        {
            var query = GetSearchTaskNotesQuery(taskId, userId);

            return new PagedList<TaskNote>(query, 0, int.MaxValue);
        }

        public void UpdateTask(Task task)
        {
            _taskRepository.Update(task);
        }

        private IQueryable<TaskNote> GetSearchTaskNotesQuery(int taskId, string userId = "")
        {
            var query = _taskNotesRepository.TableNoTracking.Include(x => x.User) as IQueryable<TaskNote>;

            query = query.Where(x => x.TaskId == taskId);

            query = query.OrderBy(x => x.CreatedOn);

            return query;
        }

        private IQueryable<TaskFileMapping> GetSearchTaskFilesQuery(int taskId)
        {
            var query = _taskFileMappingRepository.TableNoTracking.Include(x => x.Task).Include(x => x.File) as IQueryable<TaskFileMapping>;

            query = query.Where(x => x.TaskId == taskId);

            return query;
        }
    }
}

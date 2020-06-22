using BLL.PagedList;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ITaskService
    {
        public Task GetById(int id);
        public Task GetByWithoutRelatedData(int id);
        public void IntertTaskNote(TaskNote taskNote);
        public void UpdateTask(Task task);
        public void CreateTask(Task task);
        public void CreateUserTaskMapping(UserTaskMapping userTaskMapping);
        public void CreateTeacherTaskMapping(TeacherTaskMapping userTaskMapping);
        public IPagedList<TaskNote> SearchTaskNotes(int taskId, string userId = "");
        public IPagedList<TaskFileMapping> SearchTaskFiles(int taskId);
        public string GetContentType(string path);
    }
}

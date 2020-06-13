using BLL.PagedList;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ITaskService
    {
        public Task GetById(int id);
        public void IntertTaskNote(TaskNote taskNote);
        public IPagedList<TaskNote> SearchTaskNotes(int taskId, string userId = "");
    }
}

using BLL.PagedList;
using DAL.Entities;
using System.Linq;

namespace BLL.Interfaces
{
    public interface ITaskService
    {
        public Task GetById(int id);
        public IPagedList<TaskNote> SearchTaskNotes(int taskId, string userId = "");
    }
}

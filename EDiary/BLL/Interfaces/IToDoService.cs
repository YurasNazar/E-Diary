using BLL.PagedList;
using DAL.Entities;
using System;

namespace BLL.Interfaces
{
    public interface IToDoService
    {
        IPagedList<UserTaskMapping> SearchToDos(string subjects = null, DateTime? deadline = null, string name = null, int? statusId = null,
            int pageIndex = 0, int pageSize = int.MaxValue, string userId = "");
        IPagedList<TeacherTaskMapping> SearchTeacherToDos(string subjects, DateTime? deadline, string name, int? statusId, int pageIndex, int pageSize, string userId);
    }
}

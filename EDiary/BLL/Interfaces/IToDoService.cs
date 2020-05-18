using BLL.PagedList;
using DAL.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IToDoService
    {
        IList<ToDo> GetToDosList();

        IPagedList<ToDo> SearchToDos(DateTime? deadline = null, string description = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}

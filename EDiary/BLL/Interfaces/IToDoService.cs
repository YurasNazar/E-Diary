﻿using BLL.PagedList;
using DAL.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IToDoService
    {
        IPagedList<Task> SearchToDos(string subjects = null, DateTime? deadline = null, string name = null,
            int pageIndex = 0, int pageSize = int.MaxValue, string userId = "");
    }
}

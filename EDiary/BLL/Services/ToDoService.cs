using BLL.Interfaces;
using BLL.PagedList;
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<ToDo> _toDoRepository;
        public ToDoService(IRepository<ToDo> toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        public IList<ToDo> GetToDosList()
        {
            var toDos = _toDoRepository.Table;
            var toDosList = toDos.ToList();
            return toDosList;
        }

        public IPagedList<ToDo> SearchToDos(DateTime? deadline = null, string description = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = GetSearchOrdersQuery(deadline, description, pageIndex, pageSize);

            query = query.OrderByDescending(o => o.DeadLine);

            //database layer paging
            return new PagedList<ToDo>(query, pageIndex, pageSize);

        }

        private IQueryable<ToDo> GetSearchOrdersQuery(DateTime? deadline, string description, int pageIndex, int pageSize)
        {
            var query = _toDoRepository.TableNoTracking;

            if (!string.IsNullOrWhiteSpace(description))
            {
                query = query.Where(x => x.Description.ToLower().Contains(description));
            }

            if (deadline.HasValue)
            {
                query = query.Where(x => x.DeadLine <= deadline.Value);
            }

            return query;
        }
    }
}

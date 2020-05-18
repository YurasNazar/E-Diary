using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.PagedList
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    [Serializable]
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public static PagedList<T> Empty()
        {
            return new PagedList<T>();
        }

        #region Constructors

        private PagedList() { }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
            {
                TotalPages++;
            }

            if (pageIndex != 0 && TotalCount % (pageIndex * pageSize) == 0 && pageIndex + 1 >= TotalPages &&
                TotalCount != (pageIndex + 1) * pageSize)
            {
                pageIndex--;
            }

            PageSize = pageSize;
            PageIndex = pageIndex;

            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(ICollection<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
            {
                TotalPages++;
            }

            if (pageIndex != 0 && TotalCount % (pageIndex * pageSize) == 0 && pageIndex + 1 >= TotalPages &&
                TotalCount != (pageIndex + 1) * pageSize)
            {
                pageIndex--;
            }

            PageSize = pageSize;
            PageIndex = pageIndex;

            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalCount">Total count</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
            {
                TotalPages++;
            }

            if (pageIndex != 0 && TotalCount % (pageIndex * pageSize) == 0 && pageIndex + 1 >= TotalPages &&
                TotalCount != (pageIndex + 1) * pageSize)
            {
                pageIndex--;
            }

            PageSize = pageSize;
            PageIndex = pageIndex;

            AddRange(source);
        }

        #endregion

        #region Fields

        public int PageIndex { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public int TotalPages { get; }

        public bool HasPreviousPage => PageIndex > 0;

        public bool HasNextPage => PageIndex + 1 < TotalPages;

        #endregion
    }
}

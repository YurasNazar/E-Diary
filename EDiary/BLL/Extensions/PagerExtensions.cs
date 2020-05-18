using BLL.PagedList;
using DAL.Models;

namespace BLL.Extensions
{
    public static class PagerExtensions
    {
        public static SimplePagerModel ToSimplePagerModel<T>(IPagedList<T> items) => new SimplePagerModel
        {
            PageSize = items.PageSize,
            TotalCount = items.TotalCount,
            TotalPages = items.TotalPages,
            HasNextPage = items.HasNextPage,
            HasPreviousPage = items.HasPreviousPage,
            PageIndex = items.PageIndex
        };
    }
}

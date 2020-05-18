using Common;

namespace DAL.Models
{
    public class SimplePagerModel
    {
        public SimplePagerModel()
        {
            TotalCount = 0;
            TotalPages = 0;
            PageSize = Constants.Paging.DefaultPageSize;
            PageIndex = 0;
            HasNextPage = false;
            HasPreviousPage = false;
        }

        /// <summary>
        ///  Gets or sets zero based page index
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        ///  Gets or sets the page size
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        ///  Gets or sets the total number of pages
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        ///  Gets or sets the has next page indicator
        /// </summary>
        public bool HasNextPage { get; set; }
        /// <summary>
        ///  Gets or sets the has previous page indicator
        /// </summary>
        public bool HasPreviousPage { get; set; }
        /// <summary>
        ///  Gets or sets the total number of records
        /// </summary>
        public int TotalCount { get; set; }
    }
}

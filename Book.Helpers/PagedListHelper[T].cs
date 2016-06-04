using System;
using System.Collections.Generic;

namespace Book.Helpers
{
    public class PagedListHelper<T> : List<T>
    {
        public PagedListHelper(IEnumerable<T> items, int pageIndex, int pageSize, long totalItemCount)
        {
            this.AddRange(items);
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalItemCount = totalItemCount;
            this.TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        }
        public PagedListHelper()
        {

        }

        public IEnumerable<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortExpression { get; set; }
        public long TotalItemCount { get; set; }
        public int TotalPageCount { get; private set; }

        public int PageFirstRecordIndex
        {
            get
            {
                return ((this.PageSize * (this.PageIndex - 1)) + 1);
            }
        }
        public int PageLastRecordIndex
        {
            get
            {
                return (int)(((this.PageSize * (this.PageIndex - 1)) + this.PageSize) > this.TotalItemCount ? this.TotalItemCount : ((this.PageSize * (this.PageIndex - 1)) + this.PageSize));
            }
        }
    }
}

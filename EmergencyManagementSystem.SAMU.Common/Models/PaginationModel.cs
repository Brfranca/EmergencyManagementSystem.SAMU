using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace EmergencyManagementSystem.SAMU.Common.Models
{
    public class PaginationModel<T>
    {
        public DataPagination DataPagination { get; set; }
        public List<T> Models { get; set; }

        public PaginationModel(List<T> list, DataPagination dataPagination)
        {
            Models = list;
            DataPagination = dataPagination;
        }
    }

    public class DataPagination : IPagedList
    {
        public int PageCount { get; set; }

        public int TotalItemCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public bool IsFirstPage { get; set; }

        public bool IsLastPage { get; set; }

        public int FirstItemOnPage { get; set; }

        public int LastItemOnPage { get; set; }

        public DataPagination(PagedListMetaData pagedListMetaData)
        {
            PageCount = pagedListMetaData.PageCount;
            TotalItemCount = pagedListMetaData.TotalItemCount;
            PageNumber = pagedListMetaData.PageNumber;
            PageSize = pagedListMetaData.PageSize;
            HasPreviousPage = pagedListMetaData.HasPreviousPage;
            HasNextPage = pagedListMetaData.HasNextPage;
            IsFirstPage = pagedListMetaData.IsFirstPage;
            IsLastPage = pagedListMetaData.IsLastPage;
            FirstItemOnPage = pagedListMetaData.FirstItemOnPage;
            LastItemOnPage = pagedListMetaData.LastItemOnPage;
        }
    }
}

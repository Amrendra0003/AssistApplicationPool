using System;
using System.Collections.Generic;

namespace Healthware.Core.DTO
{
    public class TableDisplayInfo
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalRecords { get; set; }
        public string SortColumn { get; set; }
        public bool SortDescending { get; set; }
        public string SearchColumn { get; set; }
        public string[] SearchTerms { get; set; }
        public string CustomFilter { get; set; }

        public int TotalPages
        {
            get
            {
                return ItemsPerPage == 0
                    ? 0
                    : (int) Math.Ceiling(TotalRecords/(double) ItemsPerPage);
            }
        }

        public string ExportController { get; set; }
        public string ExportAction { get; set; }
        public Action HeaderDisplayCallback { get; set; }
        public bool SortWithOrderByDto { get; set; }
        public List<TableTabInfo> TabInfo { get; set; }
    }

    public class TableTabInfo
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; } = false;
        public int NewBadgeCount { get; set; }
    }
}
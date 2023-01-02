using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Dto.Pagination
{
    public class Pager
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public Pager(int totalItems, int? currentPage, int pageSize = 10)
        {
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var page = currentPage == null ? 0 : currentPage.Value;
            var start = page - 5;
            var end = page + 4;
            if (start <= 0)
            {
                end -= (start - 1);
                start = 1;
            }
            if (end > totalPages)
            {
                end = totalPages;
                if (end > 10)
                {
                    start = end - 9;
                }
            }
            TotalPages= totalPages;
            TotalItems= TotalItems;
            CurrentPage = page;
            EndPage=end;
            StartPage = start;
        }
    }
}

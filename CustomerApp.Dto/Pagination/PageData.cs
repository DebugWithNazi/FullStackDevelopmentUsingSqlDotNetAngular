using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Dto.Pagination
{
    public class PageData<T>
    {
        public Pager pager { get; set; }
        public List<T> Data { get; set; }
        public PageData(List<T> data, int totalRecords, int? currentPage, int pageSize)
        {
            Data = data;
            pager = new Pager(totalRecords, currentPage, pageSize);
        }
    }
}

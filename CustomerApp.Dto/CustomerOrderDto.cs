using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Dto
{
    public class CustomerOrderDto
    {
        public long Id { get; set; }

        public long? CustomerId { get; set; }

        public string? OrderNo { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? ItemCount { get; set; }

        public decimal? Ammount { get; set; }

        public bool? IsDeleted { get; set; }

    }
}

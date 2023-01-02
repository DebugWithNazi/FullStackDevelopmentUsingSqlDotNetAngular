using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Dto
{
    public class CustomerDto
    {
        public long? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? RegisterationDate { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? City { get; set; }

        public string? CountryIso { get; set; }

        public virtual List<CustomerOrderDto> CustomerOrders { get; set; } = new List<CustomerOrderDto>();

    }
}

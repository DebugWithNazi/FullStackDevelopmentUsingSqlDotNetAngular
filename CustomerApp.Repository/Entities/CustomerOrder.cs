using System;
using System.Collections.Generic;

namespace CustomerApp.Repository.Entities;

public partial class CustomerOrder
{
    public long Id { get; set; }

    public long? CustomerId { get; set; }

    public string? OrderNo { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? ItemCount { get; set; }

    public decimal? Ammount { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Customer? Customer { get; set; }
}

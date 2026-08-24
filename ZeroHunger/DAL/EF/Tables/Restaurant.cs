using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<CollectRequest> CollectRequests { get; set; } = new List<CollectRequest>();
}

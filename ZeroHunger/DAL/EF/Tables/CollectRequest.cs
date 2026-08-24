using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class CollectRequest
{
    public int CollectRequestId { get; set; }

    public int RestaurantId { get; set; }

    public int? EmployeeId { get; set; }

    public string FoodDescription { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime RequestDate { get; set; }

    public DateTime PreserveUntil { get; set; }

    public string Status { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual Restaurant Restaurant { get; set; } = null!;
}

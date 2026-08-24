using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class CollectRequestModel
    {
        public int CollectRequestId { get; set; }
        public int RestaurantId { get; set; }
        public int? EmployeeId { get; set; }
        public string FoodDescription { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime PreserveUntil { get; set; }
        public string Status { get; set; } = null!;
    }
}

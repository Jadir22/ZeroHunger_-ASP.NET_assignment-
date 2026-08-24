using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class CollectRequestModel
    {
        public int CollectRequestId { get; set; }

        [Required]
        public int RestaurantId { get; set; }
        public int? EmployeeId { get; set; }

        [Required]
        public string FoodDescription { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        public DateTime PreserveUntil { get; set; }

        [Required]
        public string Status { get; set; } = null!;
    }
}

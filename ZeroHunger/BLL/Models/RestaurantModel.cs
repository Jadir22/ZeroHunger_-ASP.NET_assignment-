using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class RestaurantModel
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
    }
}

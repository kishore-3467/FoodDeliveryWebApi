using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryAppWA.Models
{
    public class FoodModel
    {
        public int id { get; set; }
        public string? foodName { get; set; }
        public string? foodDescription { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? price { get; set; }
        public string? tags { get; set; }
        public float rating { get; set; } = 0;
        public string? image { get; set; } 
        public int cookTime { get; set; }
        public DateTime? offerStartTime { get; set; }
        public DateTime? offerEndTime { get; set; }
        public int offerPercentage { get; set; }
    }
}

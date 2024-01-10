using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryAppWA.Models
{
    public class CartModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int foodId { get; set; }
        public int foodQuantity { get; set; }
        public string? foodName { get; set; }
        public string? foodImage { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double foodPrice { get; set; }
    }
}

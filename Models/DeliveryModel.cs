using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryAppWA.Models
{
    public class DeliveryModel
    {
        public int id { get; set; }
        public int deliveryManId { get; set; }
        public int userId { get; set; }
        public string? orderQueriesIn { get; set; }
        public string? orderQueriesOut { get; set; }
        public bool deliveryStatus { get; set; } = false;
        [Column(TypeName = "decimal(18, 2)")]
        public double totalPrice { get; set; }
    }
}

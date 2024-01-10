using System;
namespace FoodDeliveryAppWA.Models
{
    public class BookModel
    {
        public int bookId { get; set; }
        public string? bookTitle { get; set; }
        public string? bookAuthor { get; set; }
        public string? bookDescription { get; set; }
        public string? bookLanguage { get; set; }
        public string? bookGenre { get; set; }
        public decimal bookPrice { get; set; }
        public string? bookPublisher { get; set; }
    }
}

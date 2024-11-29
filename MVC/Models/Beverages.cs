using MVC.Interfaces;

namespace MVC.Models
{
    public class Beverages : IProducts
    {
        public int CategoriesId { get; set; } = 1;
        public string? CategoriesName { get; set; } = "BEVERAGES";
        public int Id { get; set; } 
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
        public int Count { get; set; }
    }
}

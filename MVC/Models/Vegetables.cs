using MVC.Interfaces;

namespace MVC.Models
{
    public class Vegetables : IProducts
    {
        public int CategoriesId { get; set; } = 4;
        public string? CategoriesName { get; set; } = "VEGETABLES";
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
        public int Count { get; set; }
    }
}

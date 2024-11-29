using MVC.Interfaces;

namespace MVC.Models
{
    public class Meat : IProducts
    {
        public int CategoriesId { get; set; } = 3;
        public string? CategoriesName { get; set; } = "MEAT";
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
        public int Count { get; set; }
    }
}

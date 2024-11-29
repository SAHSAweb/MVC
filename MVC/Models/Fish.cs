using MVC.Interfaces;


namespace MVC.Models
{
    public class Fish :IProducts
    {
        public int CategoriesId { get; set; } = 2;
        public string? CategoriesName { get; set; } = "FISH";
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
        public int Count { get; set; }
    }
}

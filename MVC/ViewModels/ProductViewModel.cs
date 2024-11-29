namespace MVC.ViewModels
{
    public class ProductViewModel
    {
        public int CategoriesId { get; set; }  // Определение типа продукта, который был выбран
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }
        public double? Price { get; set; }
        public string? CategoriesName { get; set; }
        public int Count { get; set; }
    }
}

namespace MVC.Interfaces
{
    public interface IProducts
    {
        public  int CategoriesId { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CategoriesName { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
        public int Count { get; set; }

    }
}

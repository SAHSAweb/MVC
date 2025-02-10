

namespace MVC.Model
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!;
        public int Amount { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public UserDto User { get; set; } = null!;
        public decimal Price { get; set; }
        // public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

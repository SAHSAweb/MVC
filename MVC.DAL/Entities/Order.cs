using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!;
        public int Amount { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
          public User User { get; set; } = null!;
        public decimal Price { get; set; }
        // public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

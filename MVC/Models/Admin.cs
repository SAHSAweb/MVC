using MVC.Model.Enams;

namespace MVC.Models
{
    public class Admin
    {

        public Guid Id { get; set; }
        //public string Name { get; set; } = "123";
        //public string Email { get; set; } = "123";
        public UserTypes UserType { get; set; } = UserTypes.Admin;
        public const string login = "123";
        public const string password = "123";
    }
}

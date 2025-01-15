using MVC.Model.Enams;


namespace MVC.Model
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserTypes UserType { get; set; }
    }
}

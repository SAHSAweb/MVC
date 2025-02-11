﻿using MVC.DAL.Entities;
using MVC.Model.Enams;

namespace MVC.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserTypes UserType { get; set; }
    }
}

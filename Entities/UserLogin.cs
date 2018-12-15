﻿namespace Entities
{
    public enum UserType { Admin, Employee, Client, Labour }
    public class UserLogin : Entity
    {
        // Id from Entity
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}

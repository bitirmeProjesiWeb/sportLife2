﻿namespace sportLife2.DTOs
{
    public class UserUpdateDTO
    {   
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Rol { get; set; }
    }
}
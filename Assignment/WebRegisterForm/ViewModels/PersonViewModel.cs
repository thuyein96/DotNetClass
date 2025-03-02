﻿namespace WebRegisterForm.Models
{
    public class PersonViewModel
    {
        public string Name { get; set; }
        public string Email {  get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string SuccessMessage { get; set; }
    }
}

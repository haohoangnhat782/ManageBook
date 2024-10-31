using DomainLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.DTOs
{
    public class UserDto
    {
        public UserDto() { }

        public UserDto(int? id, string? username, string? password, string email, string? phone, string? address)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
            Address = address;
        }

    
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
       
    }
}

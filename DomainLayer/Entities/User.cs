using System.ComponentModel.DataAnnotations;
namespace DomainLayer.Entities
{
      public class User
      {
            public User() { }

            public User(int? id, string? username, string? password, string email, string? phone, string? address)
            {
                  Id = id;
                  Username = username;
                  Password = password;
                  Email = email;
                  Phone = phone;
                  Address = address;
            }

            [Key]
            public int? Id { get; set; }
            public string? Username { get; set; }
            public string? Password { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }
            public string? Address { get; set; }
            public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
      }
}

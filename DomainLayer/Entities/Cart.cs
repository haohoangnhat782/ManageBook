
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
      public class Cart
      {
            public Cart() { }

            public Cart(int cartId, int? userId)
            {
                  CartID = cartId;
                  UserID = userId;
            }

            [Key]
            public int CartID { get; set; }
            public int? UserID { get; set; }
            public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();
            public virtual User? User { get; set; }
      }
}

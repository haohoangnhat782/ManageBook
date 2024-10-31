
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
      public class CartDetail
      {
            public CartDetail() { }

            public CartDetail(int? cartDetailId, int? cartId, int? bookId, int? quantity, float? price)
            {
                  CartDetailID = cartDetailId;
                  CartID = cartId;
                  BookID = bookId;
                  Quantity = quantity;
                  Price = price;
            }

            [Key]
            public int? CartDetailID { get; set; }
            public int? CartID { get; set; }
            public int? BookID { get; set; }
            public int? Quantity { get; set; }
            public float? Price { get; set; }
            public virtual Cart? Cart { get; set; }
            public virtual Book? Book { get; set; }
      }
}

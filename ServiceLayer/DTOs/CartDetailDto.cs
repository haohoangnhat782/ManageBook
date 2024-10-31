namespace ApplicationLayer.DTOs
{
    public class CartDetailDto
    {
        public CartDetailDto() { }

        public CartDetailDto(int cartDetailId, int cartId, int bookId, int quantity, float price)
        {
            CartDetailId = cartDetailId;
            CartId = cartId;
            BookId = bookId;
            Quantity = quantity;
            Price = price;
        }

        public int CartDetailId { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
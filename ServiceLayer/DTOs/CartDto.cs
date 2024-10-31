namespace ApplicationLayer.DTOs
{
    public class CartDto
    {
        public CartDto() { }

        public CartDto(int cartId, int userId)
        {
            CartId = cartId;
            UserId = userId;
        }

        public int CartId { get; set; }
        public int UserId { get; set; }
    }
}
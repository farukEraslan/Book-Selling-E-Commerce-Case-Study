namespace BookSeller.Entity.DTO.Order
{
    public class CartDTO : IDto
    {
        public CartDTO()
        {
            CartLines = new List<CartLineDTO>();
        }
        public List<CartLineDTO> CartLines { get; set; }

        public Guid CartId { get; set; }
        public Guid UserId { get; set; }

        public string Address { get; set; }
        public bool IsApproved { get; set; }
        public decimal CartTotalPrice { get; set; }

    }
}

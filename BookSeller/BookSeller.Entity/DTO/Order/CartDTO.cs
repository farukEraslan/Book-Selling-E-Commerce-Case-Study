namespace BookSeller.Entity.DTO.Order
{
    public class CartDTO : IDomainModel
    {
        public CartDTO()
        {
            CartLines = new List<CartLineDTO>();
        }

        public List<CartLineDTO> CartLines { get; set; }
        public Guid UserId { get; set; }
        public string Address { get; set; }
        public decimal CartTotalPrice
        {
            get
            {
                decimal cartTotalPrice = 0;
                foreach (CartLineDTO cartLine in CartLines)
                {
                    cartTotalPrice += cartLine.CartLinePrice;
                }
                return cartTotalPrice;
            }
        }
    }
}

namespace BookSeller.Entity.DTO.Order
{
    public class CartDomainModel : IDomainModel
    {
        public CartDomainModel()
        {
            CartLines = new List<CartLineDomainModel>();
        }
        public List<CartLineDomainModel> CartLines { get; set; }

        public Guid CartId { get; set; }
        public Guid UserId { get; set; }

        public string Address { get; set; }
        public bool IsApproved { get; set; }
        public decimal CartTotalPrice
        {
            get
            {
                decimal cartTotalPrice = 0;
                foreach (CartLineDomainModel cartLine in CartLines)
                {
                    cartTotalPrice += cartLine.CartLinePrice;
                }
                return cartTotalPrice;
            }
        }
    }
}

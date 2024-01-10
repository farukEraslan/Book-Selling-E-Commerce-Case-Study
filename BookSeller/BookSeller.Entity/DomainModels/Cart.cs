namespace BookSeller.Entity.DomainModels
{
    public class Cart : IDomainModel
    {
        public Cart()
        {
            this.CartLines = new List<CartLine>();
        }

        public List<CartLine> CartLines { get; set; }
        public Guid UserId { get; set; }
        public string Address { get; set; }
        public decimal CartTotalPrice
        {
            get
            {
                decimal cartTotalPrice = 0;
                foreach (CartLine cartLine in this.CartLines)
                {
                    cartTotalPrice += cartLine.CartLinePrice;
                }
                return cartTotalPrice;
            }
        }
    }
}

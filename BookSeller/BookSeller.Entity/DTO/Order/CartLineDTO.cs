namespace BookSeller.Entity.DTO.Order
{
    public class CartLineDTO : IDomainModel
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
        public decimal CartLinePrice
        {
            get
            {
                var cartLinePrice = Product.UnitPrice * Quantity;
                return cartLinePrice;
            }
        }
    }
}

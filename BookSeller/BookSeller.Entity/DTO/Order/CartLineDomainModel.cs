namespace BookSeller.Entity.DTO.Order
{
    public class CartLineDomainModel : IDomainModel
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
        public Guid CartId { get; set; }
    }
}

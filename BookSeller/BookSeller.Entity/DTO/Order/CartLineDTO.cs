namespace BookSeller.Entity.DTO.Order
{
    public class CartLineDTO : IDto
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
        public decimal CartLinePrice { get; set; }
        public Guid CartId { get; set; }
    }
}

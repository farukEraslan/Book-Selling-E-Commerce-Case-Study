namespace BookSeller.Business.Concrete
{
    public class CartLine : IEntity
    {
        // PK
        public Guid CartLineId { get; set; }

        // Product FK
        public Guid ProductId { get; set; }
        // Product Navi Prop
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal CartLinePrice {  get; set; }
    }
}

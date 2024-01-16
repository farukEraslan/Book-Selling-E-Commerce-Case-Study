namespace BookSeller.Entity.Concrete
{
    public class CartLine : IEntity
    {
        // PK
        public Guid CartLineId { get; set; }

        // Product FK
        public Guid ProductId { get; set; }
        // Product Navi Prop
        public Product Product { get; set; }

        // Cart FK
        public Guid CartId { get; set; }
        // Cart Navi Prop
        public Cart Cart { get; set; }

        public int Quantity { get; set; }
        public decimal CartLinePrice {  get; set; }
    }
}

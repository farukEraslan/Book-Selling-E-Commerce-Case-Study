namespace BookSeller.Entity.Concrete
{
    public class Product : IEntity
    {
        // Product PK
        public Guid ProductId { get; set; }

        // Category FK
        public Guid CategoryId { get; set; }

        // Category Navi Prop
        public Category Category { get; set; }

        public string BookName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public string ISBN { get; set; }
    }
}

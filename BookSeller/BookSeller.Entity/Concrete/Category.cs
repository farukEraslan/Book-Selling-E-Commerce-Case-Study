namespace BookSeller.Entity.Concrete
{
    public class Category : IEntity
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        // Category PK
        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        // Products Navi Prop
        public List<Product> Products { get; set; }
    }
}

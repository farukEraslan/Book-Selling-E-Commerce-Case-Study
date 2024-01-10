namespace BookSeller.Entity.Concrete
{
    public class UserEntity : IdentityUser<Guid>, IEntity
    {
        public UserEntity()
        {
            this.Products = new List<Product>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        // Product Navi Prop
        public List<Product> Products { get; set; }
    }
}

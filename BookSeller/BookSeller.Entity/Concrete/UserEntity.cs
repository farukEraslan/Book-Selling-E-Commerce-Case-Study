namespace BookSeller.Entity.Concrete
{
    public class UserEntity : IdentityUser<Guid>, IEntity
    {
        public UserEntity()
        {
            this.Carts = new List<Cart>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Cart> Carts { get; set; }
    }
}

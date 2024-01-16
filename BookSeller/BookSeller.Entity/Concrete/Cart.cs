namespace BookSeller.Entity.Concrete
{
    public class Cart : IEntity
    {
        public Cart()
        {
            this.CartLines = new List<CartLine>();
        }
        // PK
        public Guid CartId { get; set; }

        // CustomerId FK
        public Guid UserId { get; set; }
        // Customer Navi Prop
        public UserEntity User { get; set; }

        public string Address { get; set; }
        public decimal CartTotalPrice { get; set; }
        public bool IsApproved { get; set; }

        public List<CartLine> CartLines { get; set; }
    }
}

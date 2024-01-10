namespace BookSeller.Entity.DomainModels
{
    public class CartLine : IDomainModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal CartLinePrice
        {
            get
            {
                var cartLinePrice = this.Product.UnitPrice * this.Quantity;
                return cartLinePrice;
            }
        }
    }
}

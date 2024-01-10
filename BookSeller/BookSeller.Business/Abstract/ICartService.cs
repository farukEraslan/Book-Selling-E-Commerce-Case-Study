namespace BookSeller.Business.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Product product);
        void RemoveFromCart(Cart cart, Guid productId);
        List<CartLine> GetCartLines(Cart cart);
    }
}

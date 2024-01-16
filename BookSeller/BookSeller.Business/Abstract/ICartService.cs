namespace BookSeller.Business.Abstract
{
    public interface ICartService
    {
        bool AddToCart(CartDomainModel cart, ProductDTO product);
        void RemoveFromCart(CartDomainModel cart, Guid productId);
        void AddToDatabase(CartDTO cartDTO);
        List<CartDTO> GetCarts();
    }
}

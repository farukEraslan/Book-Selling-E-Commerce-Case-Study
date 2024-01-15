using BookSeller.Entity.DTO.Order;

namespace BookSeller.Business.Abstract
{
    public interface ICartService
    {
        bool AddToCart(CartDTO cart, ProductDTO product);
        void RemoveFromCart(CartDTO cart, Guid productId);
        List<CartLineDTO> GetCartLines(CartDTO cart);
    }
}

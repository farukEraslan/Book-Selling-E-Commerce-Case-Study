namespace BookSeller.Business.Concrete
{
    public class CartManager : ICartService
    {
        public bool AddToCart(CartDTO cart, ProductDTO product)
        {
            var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartLine != null && cartLine.Quantity < 10)
            {
                cartLine.Quantity++;
                return true;
            }
            else if (cartLine == null)
            {
                cart.CartLines.Add(new CartLineDTO
                {
                    Product = product,
                    Quantity = 1
                });
                return true;
            }
            else return false;
        }

        public void RemoveFromCart(CartDTO cart, Guid productId)
        {
            var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId);
            if (cartLine != null)
            {
                cartLine.Quantity--;
                if (cartLine.Quantity == 0)
                {
                    cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId));
                }
            }
        }

        public List<CartLineDTO> GetCartLines(CartDTO cart)
        {
            return cart.CartLines;
        }
    }
}

namespace BookSeller.Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartService _cartService;

        public CartManager(ICartService cartService)
        {
            _cartService = cartService;
        }

        public void AddToCart(Cart cart, Product product)
        {
            var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartLine != null)
            {
                cartLine.Quantity++;
            }
            else
            {
                cart.CartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = 1
                });
            }
        }

        public void RemoveFromCart(Cart cart, Guid productId)
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

        public List<CartLine> GetCartLines(Cart cart)
        {
            return cart.CartLines;
        }
    }
}

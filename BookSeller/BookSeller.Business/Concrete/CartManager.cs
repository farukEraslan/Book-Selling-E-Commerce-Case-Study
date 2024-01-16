namespace BookSeller.Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDAL _cartDAL;
        private readonly IMapper _mapper;

        public CartManager(ICartDAL cartDAL, IMapper mapper)
        {
            _cartDAL = cartDAL;
            _mapper = mapper;
        }

        public bool AddToCart(CartDomainModel cart, ProductDTO product)
        {
            var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartLine != null && cartLine.Quantity < 10)
            {
                cartLine.Quantity++;
                return true;
            }
            else if (cartLine == null)
            {
                cart.CartLines.Add(new CartLineDomainModel
                {
                    Product = product,
                    Quantity = 1
                });
                return true;
            }
            else return false;
        }

        public void RemoveFromCart(CartDomainModel cart, Guid productId)
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

        public void AddToDatabase(CartDTO cartDTO)
        {
            _cartDAL.Add(_mapper.Map<Cart>(cartDTO));
        }

        public List<CartDTO> GetCarts()
        {
            return _mapper.Map<List<CartDTO>>(_cartDAL.GetAll());
        }
    }
}

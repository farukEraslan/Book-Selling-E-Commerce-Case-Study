namespace BookSeller.WebAPI.Helpers.Concrete
{
    public class CartSessionHelper : ICartSessionHelper
    {
        IHttpContextAccessor _httpContextAccessor;

        public CartSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public CartDTO GetCart(string key)
        {
            var cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<CartDTO>(key);
            if (cartToCheck == null)
            {
                SetCart(key, new CartDTO());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<CartDTO>(key);
            }
            return cartToCheck;
        }

        public void SetCart(string key, CartDTO cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key, cart);
        }
    }
}

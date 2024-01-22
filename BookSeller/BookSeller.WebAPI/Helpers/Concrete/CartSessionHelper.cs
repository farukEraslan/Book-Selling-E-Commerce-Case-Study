namespace BookSeller.WebAPI.Helpers.Concrete
{
    public class CartSessionHelper : ICartSessionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public CartSessionHelper(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public async Task<CartDomainModel> GetCart(string key)
        {
            var cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<CartDomainModel>(key);
            if (cartToCheck == null)
            {
                SetCart(key, new CartDomainModel
                {
                    CartId = Guid.NewGuid(),
                    UserId = (await _userService.GetByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name)).Id,
                    IsApproved = false
                }); ;
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<CartDomainModel>(key);
            }

            foreach (var cartLine in cartToCheck.CartLines)
            {
                cartLine.CartId = cartToCheck.CartId;
            }

            return cartToCheck;
        }

        public void SetCart(string key, CartDomainModel cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key, cart);
        }
    }
}

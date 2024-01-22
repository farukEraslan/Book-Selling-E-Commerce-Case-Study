namespace BookSeller.WebAPI.Controllers.Order
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly ICartSessionHelper _cartSessionHelper;
        private readonly ICartLineService _cartLineService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public OrderController(ICartService cartService, IProductService productService, ICartSessionHelper cartSessionHelper, ICartLineService cartLineService, IMapper mapper, IUserService userService)
        {
            _cartService = cartService;
            _productService = productService;
            _cartSessionHelper = cartSessionHelper;
            _cartLineService = cartLineService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Authorize("Customer")]
        public async Task<IActionResult> CreateToCart(Guid productId)
        {
            var product = _productService.GetById(productId);
            var cart = await _cartSessionHelper.GetCart("cart");
            var result = _cartService.AddToCart(cart, product);

            _cartSessionHelper.SetCart("cart", cart);

            if (result)
                return Ok($"{product.BookName} sepete eklendi.");
            else
                return BadRequest($"{product.BookName} isimli üründen en fazla 10 tane sipariş edebilirsiniz.");
            
        }

        [HttpDelete]
        [Authorize("Customer")]
        public async Task<IActionResult> DeleteFromCart(Guid productId)
        {
            var product = _productService.GetById(productId);
            var cart = await _cartSessionHelper.GetCart("cart");
            _cartService.RemoveFromCart(cart, productId);

            _cartSessionHelper.SetCart("cart", cart);
            var result = $"{product.BookName} sepetten çıkarıldı.";
            return Ok(result);
        }

        [HttpGet]
        [Authorize("Customer")]
        public async Task<IActionResult> GetAllFromCart()
        {
            var model = new CartListDomainModel()
            {
                Cart = await _cartSessionHelper.GetCart("cart")
            };
            return Ok(model);
        }

        [HttpPost]
        [Authorize("Customer")]
        public async Task<IActionResult> GiveOrder(string city, string town, string street, string propertyNo, string postalCode)
        {
            var cart = await _cartSessionHelper.GetCart("cart");
            cart.Address = $"{street} mah. No:{propertyNo} {town}/{city} {postalCode}";
            _cartService.AddToDatabase(_mapper.Map<CartDTO>(cart));
            foreach (var cartLine in cart.CartLines)
            {
                _cartLineService.AddLine(_mapper.Map<CartLineDTO>(cartLine));
            }

            _cartSessionHelper.Clear();
            return Ok();
        }

        [HttpGet]
        [Authorize("Admin")]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(_cartService.GetCarts());
        }

        [HttpPost]
        [Authorize("Admin")]
        public async Task<IActionResult> ApproveOrder(Guid cartId)
        {
            var cart = _cartService.GetById(cartId);

            var user = await _userService.GetByIdAsync(cart.UserId);
            var result = _cartService.SendEmail(user.Data.Email, cartId.ToString());

            cart.IsApproved = true;
            _cartService.Update(cart);
            return Ok($"Sipariş Onaylandı.\n{result}");
        }
    }
}

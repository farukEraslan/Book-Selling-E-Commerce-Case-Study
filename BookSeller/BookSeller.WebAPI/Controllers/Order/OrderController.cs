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
        private readonly IMapper _mapper;

        public OrderController(ICartService cartService, IProductService productService, ICartSessionHelper cartSessionHelper, ICartLineService cartLineService, IMapper mapper)
        {
            _cartService = cartService;
            _productService = productService;
            _cartSessionHelper = cartSessionHelper;
            _cartLineService = cartLineService;
            _mapper = mapper;
        }

        [HttpPost]
        //[Authorize("customer")]
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
        [Authorize("customer")]
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
        //[Authorize("customer")]
        public async Task<IActionResult> GetAllFromCart()
        {
            var model = new CartListDomainModel()
            {
                Cart = await _cartSessionHelper.GetCart("cart")
            };
            return Ok(model);
        }

        [HttpPost]
        [Authorize("customer")]
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
        [Authorize("admin")]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(_cartService.GetCarts());
        }

        [HttpPost]
        [Authorize("admin")]
        public async Task<IActionResult> ApproveOrder(Guid cartId)
        {
            var cart = _cartService.GetById(cartId);
            cart.IsApproved = true;
            _cartService.Update(cart);
            // Sipariş onay maili burada atılacak.
            return Ok("Sipariş Onaylandı.");
        }


    }
}

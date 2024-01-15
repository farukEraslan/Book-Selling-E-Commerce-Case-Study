namespace BookSeller.WebAPI.Controllers.Order
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly ICartSessionHelper _cartSessionHelper;

        public OrderController(ICartService cartService, IProductService productService, ICartSessionHelper cartSessionHelper)
        {
            _cartService = cartService;
            _productService = productService;
            _cartSessionHelper = cartSessionHelper;
        }

        [HttpPost]
        public IActionResult Create(Guid productId)
        {
            var product = _productService.GetById(productId);
            var cart = _cartSessionHelper.GetCart("cart");
            var result = _cartService.AddToCart(cart, product);

            _cartSessionHelper.SetCart("cart", cart);

            if (result)
                return Ok($"{product.BookName} sepete eklendi.");
            else
                return BadRequest($"{product.BookName} isimli üründen en fazla 10 tane sipariş edebilirsiniz.");
            
        }

        [HttpDelete]
        public IActionResult Delete(Guid productId)
        {
            var product = _productService.GetById(productId);
            var cart = _cartSessionHelper.GetCart("cart");
            _cartService.RemoveFromCart(cart, productId);

            _cartSessionHelper.SetCart("cart", cart);
            var result = $"{product.BookName} sepetten çıkarıldı.";
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = new CartListDTO()
            {
                Cart = _cartSessionHelper.GetCart("cart")
            };
            return Ok(model);
        }
    }
}

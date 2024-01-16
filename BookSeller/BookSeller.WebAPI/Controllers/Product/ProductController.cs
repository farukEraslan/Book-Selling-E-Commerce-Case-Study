namespace BookSeller.WebAPI.Controllers.Product
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Authorize("admin")]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            _productService.Add(productCreateDTO);
            return Ok();
        }

        [HttpPut]
        [Authorize("admin")]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDTO)
        {
            _productService.Update(productUpdateDTO);
            return Ok();
        }

        [HttpDelete]
        [Authorize("admin")]
        public async Task<IActionResult> Delete(ProductDTO productDTO)
        {
            _productService.Delete(productDTO);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid productId)
        {
            return Ok(_productService.GetById(productId));
        }
    }
}

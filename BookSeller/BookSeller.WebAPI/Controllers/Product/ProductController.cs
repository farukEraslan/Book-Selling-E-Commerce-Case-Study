using BookSeller.Entity.DTO.Product;

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
        [Authorize("Admin")]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            _productService.Add(productCreateDTO);
            return Ok();
        }

        [HttpPut]
        [Authorize("Admin")]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDTO)
        {
            _productService.Update(productUpdateDTO);
            return Ok();
        }

        [HttpDelete]
        [Authorize("Admin")]
        public async Task<IActionResult> Delete(ProductDTO productDTO)
        {
            _productService.Delete(productDTO);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = _productService.GetAll();

            if (products is not null)
                return Ok(products);
            else
                return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid productId)
        {
            var product = _productService.GetById(productId);

            if (product is not null)
                return Ok(product);
            else
                return BadRequest();
        }
    }
}

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
            var result = _productService.Add(productCreateDTO);
            if (result.IsSuccess)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }

        [HttpPut]
        [Authorize("Admin")]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDTO)
        {
            var result = _productService.Update(productUpdateDTO);
            if (result.IsSuccess)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }

        [HttpDelete]
        [Authorize("Admin")]
        public async Task<IActionResult> Delete(ProductDTO productDTO)
        {
            var result = _productService.Delete(productDTO);
            if (result.IsSuccess)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            var result = _productService.GetAll(pageNumber, pageSize);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid productId)
        {
            var result = _productService.GetById(productId);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}

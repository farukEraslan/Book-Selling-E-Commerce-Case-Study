namespace BookSeller.WebAPI.Controllers.Category
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize("Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateDTO categoryCreateDTO)
        {
            _categoryService.Add(categoryCreateDTO);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(CategoryUpdateDTO categoryUpdateDTO)
        {
            _categoryService.Update(categoryUpdateDTO);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(CategoryDTO categoryDTO) 
        {
            _categoryService.Delete(categoryDTO);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            var categories = _categoryService.GetAll(pageNumber, pageSize);

            if (categories is not null)
                return Ok(categories);
            else
                return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid categoryId)
        {
            var category = _categoryService.GetById(categoryId);

            if (category is not null)
                return Ok(category);
            else
                return BadRequest();
        }
    }
}

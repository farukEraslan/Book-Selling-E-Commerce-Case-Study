namespace BookSeller.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDAL categoryDAL, IMapper mapper)
        {
            _categoryDAL = categoryDAL;
            _mapper = mapper;
        }

        public void Add(CategoryCreateDTO categoryDTO)
        {
            _categoryDAL.Add(_mapper.Map<Category>(categoryDTO));
        }

        public void Update(CategoryUpdateDTO categoryUpdateDTO)
        {
            _categoryDAL.Update(_mapper.Map<Category>(categoryUpdateDTO));
        }

        public void Delete(CategoryDTO categoryDTO)
        {
            _categoryDAL.Delete(_mapper.Map<Category>(categoryDTO));
        }

        public List<CategoryDTO> GetAll(int pageNumber, int pageSize)
        {
            var categories = _categoryDAL.GetAll()
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(category => _mapper.Map<CategoryDTO>(category))
                    .ToList();

            return categories;
        }

        public CategoryDTO GetById(Guid categoryId)
        {
            return _mapper.Map<CategoryDTO>(_categoryDAL.GetById(c => c.CategoryId == categoryId));
        }
    }
}

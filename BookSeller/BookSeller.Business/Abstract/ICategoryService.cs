using BookSeller.Entity.DTO.Category;

namespace BookSeller.Business.Abstract
{
    public interface ICategoryService
    {
        void Add(CategoryCreateDTO categoryDTO);
        void Update(CategoryUpdateDTO categoryUpdateDTO);
        void Delete(CategoryDTO categoryDTO);
        CategoryDTO GetById(Guid categoryId);
        List<CategoryDTO> GetAll();
    }
}

namespace BookSeller.Business.Abstract
{
    public interface IProductService
    {
        void Add(ProductCreateDTO productDTO);
        void Update(ProductUpdateDTO productUpdateDTO);
        void Delete(ProductDTO productDTO);
        ProductDTO GetById(Guid productId);
        List<ProductDTO> GetAll();
        List<ProductDTO> GetAll(Expression<Func<Product, bool>> expression);
    }
}

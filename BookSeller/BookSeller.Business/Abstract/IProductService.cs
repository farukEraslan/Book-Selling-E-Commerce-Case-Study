namespace BookSeller.Business.Abstract
{
    public interface IProductService
    {
        Result Add(ProductCreateDTO productDTO);
        Result Update(ProductUpdateDTO productUpdateDTO);
        Result Delete(ProductDTO productDTO);
        DataResult<ProductDTO> GetById(Guid productId);
        DataResult<List<ProductDTO>> GetAll(int pageNumber, int pageSize);
        DataResult<List<ProductDTO>> GetAll(Expression<Func<Product, bool>> expression, int pageNumber, int pageSize);
    }
}

namespace BookSeller.Business.Abstract
{
    public interface ICartLineService
    {
        void AddLine(CartLineDTO cartLineDTO);
        void RemoveLine(Guid productId);
        List<CartLineDTO> GetAll();
        List<CartLineDTO> GetAll(Expression<Func<Product, bool>> expression);
    }
}

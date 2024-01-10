namespace BookSeller.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;
        private readonly IMapper _mapper;

        public ProductManager(IProductDAL productDAL, IMapper mapper)
        {
            _productDAL = productDAL;
            _mapper = mapper;
        }

        public void Add(ProductCreateDTO productDTO)
        {
            _productDAL.Add(_mapper.Map<Product>(productDTO));
        }

        public void Update(ProductUpdateDTO productUpdateDTO)
        {
            _productDAL.Update(_mapper.Map<Product>(productUpdateDTO));
        }

        public void Delete(ProductDTO productDTO)
        {
            _productDAL.Delete(_mapper.Map<Product>(productDTO));
        }

        public List<ProductDTO> GetAll()
        {
            return _mapper.Map<List<ProductDTO>>(_productDAL.GetAll());
        }

        public List<ProductDTO> GetAll(Expression<Func<Product, bool>> expression)
        {
            return _mapper.Map<List<ProductDTO>>(_productDAL.GetAll(expression));
        }

        public ProductDTO GetById(Guid productId)
        {
            return _mapper.Map<ProductDTO>(_productDAL.GetById(p => p.ProductId == productId));
        }
    }
}

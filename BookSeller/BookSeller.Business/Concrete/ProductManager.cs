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

        public Result Add(ProductCreateDTO productCreateDTO)
        {
            var hasProduct = _productDAL.GetById(product => product.ISBN == productCreateDTO.ISBN);
            if (hasProduct != null)
                return new ErrorResult(Messages.AddFailAlreadyExists);

            _productDAL.Add(_mapper.Map<Product>(productCreateDTO));
            return new SuccessResult(Messages.AddSuccess);
        }

        public Result Update(ProductUpdateDTO productUpdateDTO)
        {
            var hasProduct = _productDAL.GetById(product => product.ProductId == productUpdateDTO.ProductId);
            if (hasProduct == null) 
                return new ErrorResult(Messages.NotFound);

            if (productUpdateDTO.ISBN == hasProduct.ISBN)
                return new ErrorResult(Messages.UpdateFailExist);

            _productDAL.Update(_mapper.Map<Product>(productUpdateDTO));
            return new SuccessResult(Messages.UpdateSuccess);
        }

        public Result Delete(ProductDTO productDTO)
        {
            var hasProduct = _productDAL.GetById(product => product.ProductId == productDTO.ProductId);
            if (hasProduct == null)
                return new ErrorResult(Messages.NotFound);

            _productDAL.Delete(_mapper.Map<Product>(productDTO));
            return new SuccessResult(Messages.DeleteSuccess);
        }

        public DataResult<List<ProductDTO>> GetAll(int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<ProductDTO>>(_productDAL.GetAll()
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .Select(product => _mapper.Map<ProductDTO>(product))
                   .ToList(), Messages.ListedSuccess);
        }

        public DataResult<List<ProductDTO>> GetAll(Expression<Func<Product, bool>> expression, int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<ProductDTO>>(_productDAL.GetAll(expression)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .Select(product => _mapper.Map<ProductDTO>(product))
                            .ToList(), Messages.ListedSuccess);
        }

        public DataResult<ProductDTO> GetById(Guid productId)
        {
            return new SuccessDataResult<ProductDTO>(_mapper.Map<ProductDTO>(_productDAL.GetById(p => p.ProductId == productId)), Messages.ListedSuccess);
        }
    }
}

namespace BookSeller.Business.Concrete
{
    public class CartLineManager : ICartLineService
    {
        private readonly ICartLineDAL _cartLineDAL;
        private readonly IMapper _mapper;

        public CartLineManager(ICartLineDAL cartLineDAL, IMapper mapper)
        {
            _cartLineDAL = cartLineDAL;
            _mapper = mapper;
        }

        public void AddLine(CartLineDTO cartLineDTO)
        {
            _cartLineDAL.Add(_mapper.Map<CartLine>(cartLineDTO));
        }

        public void RemoveLine(Guid productId)
        {
            throw new NotImplementedException();
        }

        public List<CartLineDTO> GetAll()
        {
            return _mapper.Map<List<CartLineDTO>>(_cartLineDAL.GetAll());
        }

        public List<CartLineDTO> GetAll(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
